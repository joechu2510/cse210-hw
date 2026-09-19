using System.ComponentModel;
using System.Reflection.Metadata;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        string[] splitText = text.Split(' ');
        foreach (string wordText in splitText)
        {
            Word word = new Word(wordText);
            _words.Add(word);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        List<Word> availableWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                availableWords.Add(word);
            }
        }
        int hiddenCount = 0;
        while (hiddenCount < numberToHide && availableWords.Count > 0)
        {
            Random random = new Random();
            int randomIndex = random.Next(0, availableWords.Count);
            availableWords[randomIndex].Hide();
            availableWords.RemoveAt(randomIndex);
            hiddenCount++;
        }
    }
    public string GetDisplayText()
    {
        string result = _reference.GetDisplayText() + " ";
        foreach (Word word in _words)
        {
            result += word.GetDisplayText() + " ";
        }
        return result;
    }
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}