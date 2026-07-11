using System;

namespace JournalProgram
{
    public class Entry
    {
        private string _date;
        private string _promptText;
        private string _entryText;
         private string _otherInfo;

        public string Date => _date;
        public string PromptText => _promptText;
        public string EntryText => _entryText;
        public string OtherInfo => _otherInfo;

        public Entry(string date, string promptText, string entryText,  string otherInfo = "")
        {
            _date = date ?? "";
            _promptText = promptText ?? "";
            _entryText = entryText ?? "";
            _otherInfo = otherInfo ?? "";
        }

        public void Display()
        {
            Console.WriteLine("---- Entry ----");
            Console.WriteLine($"Date: {_date}");
            Console.WriteLine($"Prompt: {_promptText}");
            Console.WriteLine("Response:");
            Console.WriteLine(_entryText);
            if (!string.IsNullOrWhiteSpace(_otherInfo))
            {
                Console.WriteLine();
                Console.WriteLine("Other information:");
                Console.WriteLine(_otherInfo);
            }
            Console.WriteLine();
        }
    }
}