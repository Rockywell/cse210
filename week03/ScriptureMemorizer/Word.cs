class Word
{
    private string _text;
    private bool _isHidden = false;

    public Word(string text, bool isHidden = false)
    {
        _text = text;
        _isHidden = isHidden;
    }

    public void Hide() => _isHidden = true;
    public void Show() => _isHidden = false;
    public bool IsHidden => _isHidden;
    public string GetText => this.IsHidden ? new string('_', _text.Length) : _text;
}