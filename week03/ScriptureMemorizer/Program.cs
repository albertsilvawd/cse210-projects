using System;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// Main program to help users memorize scriptures.
/// </summary>
class Program
{
    static void Main()
    {
        // Load scriptures from JSON file - Exceeds requirement by loading multiple scriptures from an external file
        var scriptures = ScriptureLoader.LoadFromJson("scriptures.json");

        if (scriptures == null || scriptures.Count == 0)
        {
            Console.WriteLine("Error: No scriptures found in the JSON file.");
            return;
        }

        var random = new Random();
        var scripture = scriptures[random.Next(scriptures.Count)];

        // Allow user to choose difficulty (number of words to hide per step) - Provides customization beyond the basic requirements
        Console.WriteLine("Choose difficulty (1-3 words to hide per step):");
        if (!int.TryParse(Console.ReadLine(), out int difficulty) || difficulty < 1 || difficulty > 3)
        {
            difficulty = 2; // Default difficulty
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            // Check if all words are hidden - Indicates user has completed memorization for that scripture
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nTest your memory! Type the full scripture:");
                string userInput = Console.ReadLine();
                string originalText = string.Join(" ", scripture.GetWords().ConvertAll(w => w.GetOriginalText()));

                if (userInput == originalText)
                {
                    Console.WriteLine("Correct! Great job!");
                    // Save the progress to a file - Tracks user progress beyond basic requirements
                    File.AppendAllText("progress.txt", $"Mastered: {scripture.GetDisplayText()}\n");
                }
                else
                {
                    Console.WriteLine("Almost! Keep practicing.");
                }
                break;
            }

            // Option for the user to quit the game
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            if (Console.ReadLine()?.ToLower() == "quit") break;

            // Hide a random set of words based on the chosen difficulty - Adds randomness and variability to the game
            scripture.HideRandomWords(difficulty);
        }
    }
}
