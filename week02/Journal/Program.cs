using System;

namespace JournalProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            var journal = new Journal();
            var promptGenerator = new PromptGenerator();

            while (true)
            {
                ShowMenu();
                Console.Write("Select an option (1-5): ");
                string choice = Console.ReadLine()?.Trim();

                switch (choice)
                {
                    case "1":
                        WriteNewEntry(journal, promptGenerator);
                        break;
                    case "2":
                        journal.DisplayAll();
                        break;
                    case "3":
                        Console.Write("Enter filename to save to: ");
                        string saveFile = Console.ReadLine();
                        journal.SaveToFile(saveFile);
                        break;
                    case "4":
                        Console.Write("Enter filename to load from: ");
                        string loadFile = Console.ReadLine();
                        journal.LoadFromFile(loadFile);
                        break;
                    case "5":
                        Console.WriteLine("Exiting program. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please select 1-5.");
                        break;
                }
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Journal Program");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
        }

        private static void WriteNewEntry(Journal journal, PromptGenerator promptGenerator)
        {
            string prompt = promptGenerator.GetRandomPrompt();
            Console.WriteLine();
            Console.WriteLine($"Prompt: {prompt}");
            Console.Write("Your response: ");
            string response = ReadMultilineInput();
            string date = DateTime.Now.ToString("yyyy-MM-dd");

            var entry = new Entry(date, prompt, response);
            journal.AddEntry(entry);
            Console.WriteLine("Entry added.");
        }

        private static string ReadMultilineInput()
        {
            Console.WriteLine("(Type your response. Press Enter on an empty line to finish.)");
            string line;
            string result = "";
            while (true)
            {
                line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }
                if (result.Length > 0) result += Environment.NewLine;
                result += line;
            }

            return result;
        }
    }
}