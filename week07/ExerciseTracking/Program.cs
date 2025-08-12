using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ExerciseTracking Project.\n");

        DateTime todaysDate = DateTime.Now;

        var runData = new Running(todaysDate, 83, 20.5);
        var cycleData = new Cycling(todaysDate, 46, 20.1);
        var swimData = new Swimming(todaysDate, 22, 20);

        List<Activity> activities = new List<Activity> {runData, cycleData, swimData};

        activities.ForEach(activity => {
            Console.WriteLine(activity.GetSummary());
        });
    }
}