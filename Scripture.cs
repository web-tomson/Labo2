using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        string[] parts = text.Split(' ');

        foreach (string word in parts)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords()
    {
        // Hide 3 random unhidden words per iteration
        int wordsToHide = 3;
        int count = 0;

        List<int> unhiddenIndices = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                unhiddenIndices.Add(i);
            }
        }

        if (unhiddenIndices.Count == 0) return;

        while (count < wordsToHide && unhiddenIndices.Count > 0)
        {
            int randIndex = _random.Next(unhiddenIndices.Count);
            int wordIndex = unhiddenIndices[randIndex];
            _words[wordIndex].Hide();

            unhiddenIndices.RemoveAt(randIndex);
            count++;
        }
    }

    public string GetDisplayText()
    {
        string result = _reference.GetDisplayText() + " ";
        foreach (Word word in _words)
        {
            result += word.GetDisplayText() + " ";
        }
        return result.Trim();
    }

    public bool AllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden()) return false;
        }
        return true;
    }
}
