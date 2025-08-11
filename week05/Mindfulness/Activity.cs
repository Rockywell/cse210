abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity()
    {
        _name = "Activity";
        _description = "This activity will help you or something.";
        _duration = 50;
    }

    public abstract void Start();
    protected void Run(Action mainCallback, Action startingCallback = null, Action finalCallback = null) {        
        Console.Clear();
        this.DisplayStartingMessage();

        _duration = int.Parse(Console.ReadLine());

        Console.Write("\nGet Ready");
        this.ShowSpinner(2);


        startingCallback?.Invoke();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime) mainCallback();
        finalCallback?.Invoke();


        this.DisplayEndingMessage();
        this.ShowSpinner(3);
    }


    public string GetName() => _name;


    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name}.\n\n{_description}\n\nHow long, in seconds, would you like for your session? ");
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"\n{_name} completed!");
    }

    public void ShowSpinner(int seconds)
    {
        string loadingChar = ".";
        int loadingSteps = 3;

        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        int cursorStart = Console.CursorLeft;
        int index = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(loadingChar);

            Thread.Sleep(350); 

            index++;
            
            //Clears current loading characters
            if((index % loadingSteps) == 0) {
                Console.CursorLeft -= loadingSteps;
                Console.Write(new string(' ', loadingSteps));
                Console.CursorLeft -= loadingSteps;
            }

            Thread.Sleep(350); 
        }
        // Console.Write("\b \n");
        Console.Write("\x1b[2K\r");
    }

    public void ShowCountDown(int seconds)
    {

        int cursorStart = Console.CursorLeft;

        for (int i = seconds; i > 0; i--)
        {
            Console.SetCursorPosition(cursorStart, Console.CursorTop);
            Console.Write(i);

            Thread.Sleep(1000);
        }
        Console.Write("\b \n");
    }
}