using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Resumes Project.");

        Job job1 = new Job
        {
            _jobTitle = "Software Engineer",
            _company = "Microsoft",
            _startYear = 2019,
            _endYear = 2022
        };

        Job job2 = new Job
        {
            _jobTitle = "Software Engineer",
            _company = "Apple",
            _startYear = 2022,
            _endYear = 2023
        };

        // Console.WriteLine($"{job1._company}\n{job2._company}");
        job1.Display();
        job2.Display();


        Resume resume = new Resume
        {
            _name = "Allison Rose",
            _jobs = [job1, job2]
        };

        resume.Display();
    }
}