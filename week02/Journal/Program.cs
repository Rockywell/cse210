@"I showed my creativity by allowing the writer of the journal to put themselves as the owner/author of the journal and formatted all the classes to work with JSON files."
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Journal Project.");



        Journal journal = new Journal();

        int option = 5;

        do
        {
            if (option == 5)
            {
                Console.WriteLine("This journal is property of:");
                journal.Owner = Console.ReadLine();
            }

            Console.Write("Please select a choice.\n1. Write\n2. Display\n3. Load\n4. Save\n5. Quit\n");

            option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Entry entry = new Entry();
                    entry.Prompt();
                    journal.Entries.Add(entry);
                    break;
                case 2:
                    journal.Display();
                    break;
                case 3:
                    journal = Journal.Load();
                    break;
                case 4:
                    journal.Save();
                    break;
                case 5:
                    Console.WriteLine($"Thank you for journaling me, {journal.Owner}!");
                    break;
            }

        } while (option != 5);
    }
}