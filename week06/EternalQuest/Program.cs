/* 
I exceeded the requirements of the project by making a factory in GoalManager that can create any Goal class, with just two arguments.
I also made it so that GetStringRepresentation() could become realistically virtual within Goal.cs to have a default that works and can be added to other child classes by appending to the base function.
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the EternalQuest Project.");

        var myGoalManager = new GoalManager();
        myGoalManager.Start();
    }
}