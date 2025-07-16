class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {

        _reference = reference;

        foreach (string word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide = 1)
    {
        IEnumerable<Word> selectedWords = _words.Where(word => !word.IsHidden).OrderBy(_ => _random.Next()).Take(numberToHide);

        foreach (Word word in selectedWords) word.Hide();
    }

    public bool IsFullyHidden => _words.All(word => word.IsHidden);

    public string GetText => $"{_reference.GetText} {string.Join(" ", _words.Select(word => word.GetText))}";
}