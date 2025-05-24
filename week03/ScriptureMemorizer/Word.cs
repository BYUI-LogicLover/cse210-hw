namespace ScriptureMemorizer;

public class Word
{
    // private fields start with underscore
    private readonly string _text;
    private bool _isHidden;

    public Word(string text) => _text = text;

    public void Hide() => _isHidden = true;

    public bool IsHidden() => _isHidden;

    public string Display() => _isHidden ? new string('_', _text.Length) : _text;
}