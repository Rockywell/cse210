using System.IO; 
// using System.Text.Json;

public class GoalManager
{
    private static readonly List<Func<object[], Goal>> _goalFactories = new List<Func<object[], Goal>>
    {
        args => new SimpleGoal(
            (string)args[0],
            (string)args[1],
            (int)args[2],
            args.Length > 3 && args[3] is bool b ? b : false
        ),
        
        args => new EternalGoal(
            (string)args[0],
            (string)args[1],
            (int)args[2]
        ),

        args => new ChecklistGoal(
            (string)args[0],
            (string)args[1],
            (int)args[2],
            (int)args[3],
            (int)args[4],
            args.Length > 5 && args[5] is int completed ? completed : 0
        )
    };
    private static readonly Dictionary<string, int> _goalNameToIndex = new Dictionary<string, int>
    {
        ["SimpleGoal"] = 0,
        ["EternalGoal"] = 1,
        ["ChecklistGoal"] = 2
    };

    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {

        int Menu()
        {
            DisplayPlayerInfo();
            Console.WriteLine($"\nMenu Options:\n");

            Console.WriteLine("""
                1. Create New Goal
                2. List Goals
                3. Save Goals
                4. Load Goals
                5. Record Event
                6. Quit
            """);

            Console.Write("Select a choice from the menu: ");
          
            return int.TryParse(Console.ReadLine(), out int choice) ? choice : 0;
        };

        int choice = 0;
        do
        {     
            choice = Menu();

            Action action = choice switch
            {
                1 => CreateGoal,
                2 => ListGoalDetails,
                3 => SaveGoals,
                4 => LoadGoals,
                5 => RecordEvent,
                6 => () => Console.WriteLine("Exiting..."),
                _ => () => Console.WriteLine("Invalid Command")
            };
                
            action();
        }
        while(choice != 6);

    }//- This is the "main" function for this class. It is called by Program.cs, and then runs the menu loop.
   
    public void DisplayPlayerInfo() {
        Console.WriteLine($"You have {_score} points.");
    }// - Displays the players current score.

    public void ListGoalNames() {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            var goal = _goals[i];

            Console.WriteLine($"\t{i+1}. {goal.GetName()}");
        }
        Console.WriteLine();
    }// - Lists the names of each of the goals.
    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            var goal = _goals[i];

            Console.WriteLine($"\t{i+1}. {goal.GetDetailsString()}");
        }
        Console.WriteLine();
    }// - Lists the details of each goal (including the checkbox of whether it is complete).

    private Goal CreateGoal(int index, params object[] args)
    {
        Goal newGoal = _goalFactories[index](args);

        _goals.Add(newGoal);

        return newGoal;
    }

    private Goal CreateGoal(string className, params object[] args)
    {
        int index = _goalNameToIndex[className];
        return CreateGoal(index, args);
    }
    public void CreateGoal()
    {
        Console.WriteLine("""
        The types of goals are:
            1. Simple Goal
            2. Eternal Goal
            3. Checklist Goal
        """);

        Console.Write("Which type of goal would you like to create? ");
        int choice = int.Parse(Console.ReadLine());

        if(choice > _goalFactories.Count) {
            Console.WriteLine("Invalid Command");
            CreateGoal();
        } else {

            Console.Write("What is the name of your goal? ");
            string goalName = Console.ReadLine();

            Console.Write("What is a short description of it? ");
            string goalDescription = Console.ReadLine();

            Console.Write("What is the amount of points associated with it? ");
            int goalPoints = int.Parse(Console.ReadLine());

            List<object> args = new List<object> {goalName, goalDescription, goalPoints};

            if(choice == 3)
            {
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    int goalTarget = int.Parse(Console.ReadLine());

                    args.Add(goalTarget);

                    Console.Write("What is the amount of points for the bonus for accomplishing it that many times? ");
                    int goalBonus = int.Parse(Console.ReadLine());

                    args.Add(goalBonus);
            } 

            CreateGoal(choice - 1, args.ToArray());
        }
    }// - Asks the user for the information about a new goal. Then, creates the goal and adds it to the list.
    
    public void RecordEvent() {
        ListGoalNames();

        Console.Write("Which goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine());

        if(choice > _goals.Count) {
            Console.WriteLine("Invalid Command");
            RecordEvent();
        } else {
            Goal goal = _goals[choice - 1];

            int points = goal.RecordEvent();
            _score += points;
            
            Console.WriteLine($"Congratulations you have earned {points} points!\nYou have a total of {_score} points.\n");
        }

    }// - Asks the user which goal they have done and then records the event by calling the RecordEvent method on that goal.

    public void SaveGoals()
    {
        Console.Write("What is the file name for the goal file? ");
        string fileName = Console.ReadLine() + ".txt";

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_score);

            _goals.ForEach(goal => {
                outputFile.WriteLine(goal.GetStringRepresentation());
            });
        }

    }// - Saves the list of goals to a file.
    public void LoadGoals()
    {
        Console.Write("What is the file name for the goal file? ");
        string fileName = Console.ReadLine() + ".txt";

        string[] lines = System.IO.File.ReadAllLines(fileName);

        _score = int.Parse(lines.First());    
        _goals = new List<Goal>();

        foreach (string line in lines.Skip(1))
        {
            string[] colonParts = line.Split(':');
            string className = colonParts[0]; 

            string remainingLine = colonParts[1];
            string[] argString = remainingLine.Split(",");

            //If I went with a JSON file I could've skipped all this below and instead done just -> object[] args = JsonSerializer.Deserialize<object[]>(argString); CreateGoal(className, arg.ToArray());
            
            //Starting arguments for Goal.
            string name = argString[0];
            string description = argString[1];
            int points = int.Parse(argString[2]);

            List<object> args = new List<object> {name, description, points};

            switch (className)
            {
                case "SimpleGoal":
                    //Adds bool isComplete.
                    args.Add(bool.Parse(argString[3]));
                    break;
                case "ChecklistGoal":
                    int target = int.Parse(argString[3]);
                    int bonus = int.Parse(argString[4]);
                    int amountCompleted = int.Parse(argString[5]);

                    args.AddRange(new object[] {target, bonus, amountCompleted});
                    break;
            }
            

            CreateGoal(className, args.ToArray());
        }
    }// - Loads the list of goals from a file.
}