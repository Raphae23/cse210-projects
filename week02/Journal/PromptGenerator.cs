using System;
using System.Collections.Generic;

namespace JournalProgram
{
    public class PromptGenerator
    {
        private List<string> _prompts;

        private Random _rand;

        public PromptGenerator()
        {
            _rand = new Random();

            _prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?",
                "What is one small win I had today?",
                "What surprised me about today?"
            };
        }

        public string GetRandomPrompt()
        {
            if (_prompts == null || _prompts.Count == 0)
            {
                return "";
            }

            int idx = _rand.Next(_prompts.Count);
            return _prompts[idx];
        }
    }
}