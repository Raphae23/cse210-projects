using System;
using System.Collections.Generic;
using System.IO;

namespace JournalProgram
{
    public class Journal
    {
        private List<Entry> _entries;

        private const string Separator = "~|~";

        public Journal()
        {
            _entries = new List<Entry>();
        }

        public void AddEntry(Entry newEntry)
        {
            if (newEntry == null) return;
            _entries.Add(newEntry);
        }

        public void DisplayAll()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("The journal is empty.");
                return;
            }

            foreach (var entry in _entries)
            {
                entry.Display();
            }
        }

        public void SaveToFile(string file)
        {
            if (string.IsNullOrWhiteSpace(file))
            {
                Console.WriteLine("Invalid filename.");
                return;
            }

            try
            {
                using (var writer = new StreamWriter(file))
                {
                    foreach (var e in _entries)
                    {
                        string safeEntryText = e.EntryText?.Replace("\r", "").Replace("\n", "\\n") ?? "";
                        string safePrompt = e.PromptText?.Replace(Separator, " ") ?? "";
                        string safeDate = e.Date?.Replace(Separator, " ") ?? "";

                        string line = $"{safeDate}{Separator}{safePrompt}{Separator}{safeEntryText}";
                        writer.WriteLine(line);
                    }
                }
                Console.WriteLine($"Saved {_entries.Count} entr{(_entries.Count==1? "y":"ies")} to '{file}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to file: {ex.Message}");
            }
        }

        public void LoadFromFile(string file)
        {
            if (string.IsNullOrWhiteSpace(file))
            {
                Console.WriteLine("Invalid filename.");
                return;
            }

            if (!File.Exists(file))
            {
                Console.WriteLine($"File '{file}' not found.");
                return;
            }

            try
            {
                var lines = File.ReadAllLines(file);
                var loaded = new List<Entry>();

                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var parts = line.Split(new string[] { Separator }, StringSplitOptions.None);

                   if (parts.Length >= 3)
                    {
                        string date = parts[0];
                        string prompt = parts[1];
                        string entryText = parts[2];
                        string otherInfo = "";

                        if (parts.Length == 3)
                        {
                            otherInfo = "";
                        }
                        else
                        {
                            otherInfo = parts[3];
                            if (parts.Length > 4)
                            {
                                for (int i = 4; i < parts.Length; i++)
                                {
                                    otherInfo += Separator + parts[i];
                                }
                            }
                        }

                        entryText = entryText.Replace("\\n", Environment.NewLine);
                        otherInfo = otherInfo.Replace("\\n", Environment.NewLine);

                        var entry = new Entry(date, prompt, entryText, otherInfo);
                        loaded.Add(entry);
                    }
                    else
                    {
                        continue;
                    }
                }

                _entries = loaded;
                Console.WriteLine($"Loaded {_entries.Count} entr{(_entries.Count==1? "y":"ies")} from '{file}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading from file: {ex.Message}");
            }
        }
    }
}