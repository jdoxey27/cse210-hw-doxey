using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        string[] WordTexts = text.Split(
            ' ',
            StringSplitOptions.RemoveEmptyEntries
        );

        foreach (string WordText in WordTexts)
        {
            _words.Add(new Word(WordText));
        }
    }

    public void HideRandomWords(int count)
    {
        List<Word> VisibleWords = _words
            .Where(word => !word.IsHidden())
            .ToList();

        int WordsToHide = Math.Min(count, VisibleWords.Count);

        for (int i = 0; i < WordsToHide; i++)
        {
            int index = _random.Next(VisibleWords.Count);
            VisibleWords[index].Hide();
            VisibleWords.RemoveAt(index);
        }    
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    public string GetDisplayText()
    {
        string DisplayedWords = string.Join(
            " ",
            _words.Select(word => word.GetDisplayText())
        );

        return $"{_reference.GetDisplayText()} {DisplayedWords}";
    }
}