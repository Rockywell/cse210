class BreathingActivity : Activity
{
    public BreathingActivity() : base()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        _duration = 50;
    }

    public override void Start()
    {
        this.Run(() =>
        {
            Console.Write("\nBreathe in...");

            this.ShowCountDown(3);

            Console.Write("Breathe out...");

            this.ShowCountDown(3);
        });
    }
}