namespace ScriptureMemorizer;

public class Scripture
{
    private readonly Reference _reference;
    private readonly List<Word> _words;
    private readonly Random _random = new();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(_reference);
        Console.WriteLine(string.Join(" ", _words.Select(w => w.Display())));
    }

    public void HideRandomWords()
    {
        int count = _random.Next(1, 4);
        for (int i = 0; i < count; i++)
        {
            int randomIndex = _random.Next(_words.Count);
            while (_words[randomIndex].IsHidden())
            {
                randomIndex = _random.Next(_words.Count);
            }

            _words[randomIndex].Hide();
        }
    }
    
    public bool AllWordsHidden() => _words.All(w => w.IsHidden());
}