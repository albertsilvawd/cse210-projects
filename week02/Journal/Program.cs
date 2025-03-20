using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        bool running = true;

        // Schedule daily reminder (this is just a simulation, for a real reminder we would need a background service)
        DateTime nextReminder = DateTime.Today.AddHours(20); // Remind user at 8 PM every day
        Console.WriteLine($"Next reminder: {nextReminder}");

        while (running)
        {
            // Check if it's time for a reminder
            if (DateTime.Now >= nextReminder)
            {
                Console.WriteLine("\nReminder: It's time to write your journal entry!");
                nextReminder = nextReminder.AddDays(1); // Update to the next day's reminder
            }

            Console.WriteLine("\nJournal Program");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal entries");
            Console.WriteLine("3. Save journal to file (CSV/JSON)");
            Console.WriteLine("4. Load journal from file (CSV/JSON)");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    journal.SaveToFile();
                    break;
                case "4":
                    journal.LoadFromFile();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }
}

class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public Entry(string prompt, string response)
    {
        Date = DateTime.Now.ToShortDateString();
        Prompt = prompt;
        Response = response;
    }

    public override string ToString()
    {
        return $"{Date} | {Prompt} | {Response}";
    }
}

class Journal
{
    private List<Entry> entries = new List<Entry>();
    private List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public void AddEntry()
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];

        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        entries.Add(new Entry(prompt, response));
        Console.WriteLine("Entry saved.");
    }

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
            return;
        }

        Console.WriteLine("\nJournal Entries:");
        foreach (Entry entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile()
    {
        Console.Write("Enter filename to save (include .csv or .json extension): ");
        string filename = Console.ReadLine();

        if (filename.EndsWith(".csv"))
        {
            SaveToCsv(filename);
        }
        else if (filename.EndsWith(".json"))
        {
            SaveToJson(filename);
        }
        else
        {
            Console.WriteLine("Invalid file format. Please choose either .csv or .json.");
        }
    }

    private void SaveToCsv(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                writer.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
            }
        }
        Console.WriteLine("Journal saved as CSV.");
    }

    private void SaveToJson(string filename)
    {
        string json = JsonConvert.SerializeObject(entries, Formatting.Indented);
        File.WriteAllText(filename, json);
        Console.WriteLine("Journal saved as JSON.");
    }

    public void LoadFromFile()
    {
        Console.Write("Enter filename to load (include .csv or .json extension): ");
        string filename = Console.ReadLine();

        if (filename.EndsWith(".csv"))
        {
            LoadFromCsv(filename);
        }
        else if (filename.EndsWith(".json"))
        {
            LoadFromJson(filename);
        }
        else
        {
            Console.WriteLine("Invalid file format. Please choose either .csv or .json.");
        }
    }

    private void LoadFromCsv(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 3)
            {
                entries.Add(new Entry(parts[1], parts[2]) { Date = parts[0] });
            }
        }
        Console.WriteLine("Journal loaded from CSV.");
    }

    private void LoadFromJson(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string json = File.ReadAllText(filename);
        entries = JsonConvert.DeserializeObject<List<Entry>>(json);
        Console.WriteLine("Journal loaded from JSON.");
    }
}
