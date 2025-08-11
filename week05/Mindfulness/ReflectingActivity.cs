class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private readonly Random _rand = new Random();

    public ReflectingActivity() : base()
    {
        _name = "Reflecting Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _duration = 100;

        _prompts = ["Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."];

        _questions = ["Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"];
    }

    public override void Start()
    {
       this.Run(() =>
        {
            this.DisplayQuestions();
            this.ShowSpinner(15);
        }, () => {
            this.DisplayPrompt();
            Console.WriteLine("When you have something in mind press enter to continue.");
            Console.Read();
        });
    }


    public string GetRandomPrompt() => _prompts[_rand.Next(_prompts.Count)];
    public string GetRandomQuestion() => _questions[_rand.Next(_questions.Count)];

    public void DisplayPrompt() => Console.WriteLine($"{this.GetRandomPrompt()}\n");
    public void DisplayQuestions() => Console.Write(this.GetRandomQuestion());
}