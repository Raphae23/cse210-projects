using System;
using System.Collections.Generic;
using System.Linq;
namespace ScriptureMemoizerApp;

// I included a feature that asks users if they want to memorize another scripture after completing one. If they choose to continue, a new scripture is randomly selected from the library for memorization.

class Program
{
    static void Main()
    {
        List<Scripture> scriptureLibrary = new List<Scripture>
        {
            
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his one and only Son, that whoever believeth in him should not perish, but have everlasting life."
            ),
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the LORD with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."
            ),
            new Scripture(
                new Reference("Philippians", 4, 8),
                "Finally, brethren, whatsoever things are true, whatsoever things are honest, whatsoever things are just, whatsoever things are pure, whatsoever things are lovely, whatsoever things are of good report; if there be any virtue, and if there be any praise, think on these things."
            ),
            new Scripture(
                new Reference("Psalms", 23, 1, 6),
                "The LORD is my shepherd, I lack nothing. He makes me lie down in green pastures, he leads me beside quiet waters, he refreshes my soul. He guides me along the right paths for his name's sake."
            ),
            new Scripture(
                new Reference("Matthew", 6, 9, 13),
                "Our Father in heaven, hallowed be your name, your kingdom come, your will be done, on earth as it is in heaven. Give us today our daily bread. And forgive us our debts, as we also have forgiven our debtors."
            )
        };

        Random random = new Random();

        while (true)
        {
            Scripture currentScripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];

            RunMemorizationSession(currentScripture);

            Console.WriteLine();
            Console.Write("Would you like to memorize another scripture? (yes/no): ");
            string continueInput = Console.ReadLine();

            if (continueInput.ToLower() != "yes" && continueInput.ToLower() != "y")
            {
                Console.WriteLine("Thank you for using my Scripture Memorizer. Goodbye!");
                break;
            }
        }
    }


    static void RunMemorizationSession(Scripture scripture)
    {
        // Main session loop
        while (true)
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("Congratulations! You have completed the scripture memorization.");
                break;
            }

            Console.Write("Press Enter to hide more words, or type 'quit' to exit: ");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }
}
