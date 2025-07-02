using System.Text.Json;
using System.IO;


public class Journal
{
    public string Owner { get; set; }
    public List<Entry> Entries { get; set; } = new List<Entry>();

    public void Display()
    {
        Console.WriteLine($"Owner: {Owner}\nEntries:");
        foreach (Entry entry in Entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }
    public void Save()
    {
        // var options = new JsonSerializerOptions { WriteIndented = true };
        Console.WriteLine("What's the name of the file you'd like to save the journal to?");
        string fileName = Console.ReadLine();


        string jsonString = JsonSerializer.Serialize(this);
        Console.WriteLine(jsonString);
        File.WriteAllText($"{fileName}.json", jsonString);
    }
    public static Journal Load()
    {
        Console.WriteLine("What's the name of the file for the journal you'd like to load?");
        string fileName = Console.ReadLine() + ".json";

        if (File.Exists(fileName))
        {
            string jsonString = File.ReadAllText(fileName);

            Journal journal = JsonSerializer.Deserialize<Journal>(jsonString);

            Console.WriteLine("Journal entries loaded successfully!");
            return journal;
        }

        Console.WriteLine("File not found.");
        return new Journal();
    }
}