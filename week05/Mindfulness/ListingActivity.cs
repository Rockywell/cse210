class ListingActivity : Activity
{
    private int _count;
    private List<string> _personalList;
    private List<string> _prompts;
    private readonly Random _rand = new Random();

    public ListingActivity() : base()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _duration = 50;
        _count = 0;
        _personalList = [];
        _prompts = ["Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"];
    }

    public override void Start()
    {
        this.Run(() =>
        {
            _personalList.Add(Console.ReadLine());

            _count++;
        }, () => {
            this.DisplayPrompt();
            
            Console.Write("You may begin in: ");
            this.ShowCountDown(5);

            _personalList = [];
            Console.WriteLine("Please keep listing items.");
        }, () => {
            Console.WriteLine($"\nYou listed {_count} items!\nItems: {string.Join(", ", this.GetListFromUser())}");
        });
    }

    public string GetRandomPrompt() => _prompts[_rand.Next(_prompts.Count)];
    public void DisplayPrompt() => Console.WriteLine($"{this.GetRandomPrompt()}\n");

    public List<string> GetListFromUser() => _personalList;
}