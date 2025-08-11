/* 
I exceeded requirement by making Run work as a base method/function in Activity by using callbacks to go through the parameters it for the child classes.
I also made is to the listing Activity also gives you a list of the items you listed not just the number of items.
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");

        var breathing = new BreathingActivity();
        var reflecting = new ReflectingActivity();
        var listing = new ListingActivity();

        var activities = new List<Activity> { breathing, reflecting, listing };

        void Menu()
        {
            Console.WriteLine("Menu Options:\n");

            for (int i = 0; i < activities.Count; i++) 
                Console.WriteLine($"\t{i + 1}. Start {activities[i].GetName()}");

            Console.WriteLine($"\t{activities.Count + 1}. Quit\n");
        };

        int choice = 0;
        Menu();
        do {
            Console.Write("Select a choice from the menu: ");
            choice = int.Parse(Console.ReadLine());

            if (choice <= activities.Count) {
                activities[choice - 1].Start();

                Console.Clear();
                Menu();
            }


        }
        while(choice != activities.Count + 1);

    }
}