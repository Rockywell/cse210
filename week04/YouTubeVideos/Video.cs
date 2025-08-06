class Video
{
    private string _title;
    private string _author;
    private int _length; //Length of video in seconds.
    private List<Comment> _comments;

    public Video(string title, string author, int length, List<Comment> comments = null)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = comments ?? new();
    }

    public int GetNumComments => _comments.Count;
    public string GetInfo() => $"Title: {_title}\nAuthor: {_author}\nLength: {_length} seconds\nNumber of Comments: {this.GetNumComments}";
    public string GetComments() => "\t" + string.Join("\n\t", _comments.Select(comment => comment.GetText));

    public void AddComment(Comment comment) => _comments.Add(comment);
    public void DisplayAll() => Console.WriteLine($"{this.GetInfo()}\n\nComments:\n{this.GetComments()}\n");
}