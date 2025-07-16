class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int? _endVerse;


    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        (_chapter, _verse) = (chapter, verse);
    }
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        (_chapter, _verse, _endVerse) = (chapter, startVerse, endVerse);
    }

    public string GetText => $"{_book} {_chapter}:{_verse}{(_endVerse.HasValue ? "-" + _endVerse : "")}";
}