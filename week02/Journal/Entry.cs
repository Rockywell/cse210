using System.Text.Json.Serialization;

public class Entry
{
    public List<string> _prompts = [
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "Did I do anything adventurous today?",
        "What was my dream like today?",
        "What did I wish I could do differently today?",
        "What do I want to try and do tomorrow?"
    ];
    [JsonInclude]
    private string _prompt;
    [JsonInclude]
    private string _response;
    [JsonInclude]
    private string _date;

    public void Prompt()
    {
        Console.WriteLine(_prompt = _prompts[new Random().Next(_prompts.Count)]);
        _response = Console.ReadLine();
        _date = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
    }
    public void Display()
    {
        Console.WriteLine($"{_date}\n\n{_prompt}\n{_response}");
    }
}