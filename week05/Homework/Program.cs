using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Homework Project.");

        var assign = new Assignment("Samuel Bennett", "Multiplication");

        Console.WriteLine(assign.GetSummary());

        var mathAssign = new MathAssignment("Robert Rodriguez", "Fractions", "7.3", "8-19");

        Console.WriteLine($"\n{mathAssign.GetSummary()}\n{mathAssign.GetHomeworkList()}");

        var writingAssign = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");

        Console.WriteLine($"\n{writingAssign.GetSummary()}\n{writingAssign.GetWritingInformation()}");
    }
}