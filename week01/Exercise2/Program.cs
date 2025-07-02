using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        Console.WriteLine("What percent did you get in your class?");
        int grade = int.Parse(Console.ReadLine());

        string letter = grade switch//More efficient than if-else
        {
            >= 90 => "A",
            >= 80 => "B",
            >= 70 => "C",
            >= 60 => "D",
            < 60 => "F"
        };

        // Technically proper
        // if (grade >= 90)
        // {
        //     letter = "A";
        // }
        // else if (grade >= 80)
        // {
        //     letter = "B";
        // }
        // else if (grade >= 70)
        // {
        //     letter = "C";
        // }
        // else if (grade >= 60)
        // {
        //     letter = "D";
        // }
        // else
        // {
        //     letter = "F";
        // }

        letter += (grade % 10) switch
        {
            >= 7 when !"AF".Contains(letter) => '+',
            <= 3 when letter != "F" => '-',
            _ => ""
        };


        Console.WriteLine($"{letter} | {(grade >= 70 ? "You passed" : "You didn't quite make it, try again")}!");
    }
}