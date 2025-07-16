/* I exceeded requirements by having the program pick a random scripture out of a list of scriptures.
I also filtered out already hidden words in the HideRandomWords method so that it only hides visible words. */

using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.\n");

        List<Scripture> scriptures = [
            new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.")
        ];

        Scripture chosenScripture = scriptures[random.Next(scriptures.Count)];
        Console.WriteLine(chosenScripture.GetText);

        string userInput;

        do
        {
            Console.WriteLine("\nPress enter to hide text or type quit to exit.");
            userInput = Console.ReadLine();

            if (userInput != "quit")
            {
                chosenScripture.HideRandomWords(3);

                Console.Clear();
                Console.WriteLine(chosenScripture.GetText);
            }
        }
        while (userInput != "quit" && !chosenScripture.IsFullyHidden);
    }
}