using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemoizerApp
{
   
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

            string[] wordTexts = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string wordText in wordTexts)
            {
                _words.Add(new Word(wordText));
            }
        }

              public void HideRandomWords(int numberToHide)
        {
            for (int i = 0; i < numberToHide; i++)
            {
                int randomIndex = _random.Next(_words.Count);
                _words[randomIndex].Hide();
            }
        }

    
        public string GetDisplayText()
        {
            string referenceText = _reference.GetDisplayText();
            string scriptureText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
            return $"{referenceText}\n\n{scriptureText}";
        }

        
        public bool IsCompletelyHidden()
        {
            return _words.All(w => w.IsHidden());
        }
    }
}
