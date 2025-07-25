class Comment
{
    private string _author;
    private string _content;

    public Comment(string author, string content)
    {
        _author = author;
        _content = content;
    }

    public string GetText => $"{_author}: {_content}";
}