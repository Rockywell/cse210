using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");

        List<int> numbers = new List<int>();
        int input;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());

            if (input != 0)
            {
                numbers.Add(input);
            }

        } while (input != 0);


        double max, sum;
        max = sum = numbers.Count > 0 ? numbers[0] : double.NaN;

        foreach (int number in numbers.Skip(1))
        {
            sum += number;
            if (number > max)
            {
                max = number;
            }
        }

        double average = sum / numbers.Count;

        Console.WriteLine($"\nSum: {sum}\nAverage: {average}\nMaximum: {max}");

    }
}