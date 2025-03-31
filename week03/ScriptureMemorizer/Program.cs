using System;

/// <summary>
/// Main program to help users memorize scriptures.
/// </summary>
class Program
{
    static void Main()
    {
        // Load scriptures from JSON file - Exceeds requirement by loading multiple scriptures from an external file
        var scriptures = ScriptureLoader.LoadFromJson("scriptures.json");

        // Validate loaded scriptures
        if (scriptures == null || scriptures.Count == 0 || scriptures[0].GetDisplayText() == "Invalid Scripture")
        {
            Console.WriteLine("Error: No valid scriptures found. Check the JSON file.");
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

            if (!scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
                string input = Console.ReadLine();

                if (input?.ToLower() == "quit") break;

                scripture.HideRandomWords(difficulty);
            }
            else
            {
                Console.WriteLine("\nTest your memory! Type the full scripture:");
                string userInput = Console.ReadLine();
                string originalText = string.Join(" ", scripture.GetWords().ConvertAll(w => w.GetOriginalText()));

                if (userInput == originalText)
                {
                    Console.WriteLine("Correct! Great job!");
                    File.AppendAllText("progress.txt", $"Mastered: {scripture.GetDisplayText()}\n");
                }
                else
                {
                    Console.WriteLine("Almost! Keep practicing.");
                }
                break;
            }
        }
    }
}