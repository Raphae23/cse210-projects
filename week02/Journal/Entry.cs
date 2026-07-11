using System;

namespace JournalProgram
{
    public class Entry
    {
        private string _date;
        private string _promptText;
        private string _entryText;

        public string Date => _date;
        public string PromptText => _promptText;
        public string EntryText => _entryText;

        public Entry(string date, string promptText, string entryText)
        {
            _date = date ?? "";
            _promptText = promptText ?? "";
            _entryText = entryText ?? "";
        }

        public void Display()
        {
            Console.WriteLine("---- Entry ----");
            Console.WriteLine($"Date: {_date}");
            Console.WriteLine($"Prompt: {_promptText}");
            Console.WriteLine("Response:");
            Console.WriteLine(_entryText);
            Console.WriteLine();
        }
    }
}