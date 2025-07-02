using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        string hint = "Nice, first try!";
        int guess;
        int magicNumber = new Random().Next(1, 101);

        do
        {
            Console.WriteLine("What is your guess?");
            guess = int.Parse(Console.ReadLine());

            if (guess > magicNumber)
            {
                hint = "lower";
            }
            else if (guess < magicNumber)
            {
                hint = "higher";
            }

            Console.WriteLine(hint);

        }
        while (guess != magicNumber);

        Console.WriteLine("You guessed it!");
    }
}