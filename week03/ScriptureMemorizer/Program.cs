using System;

/// <summary>
/// Main program to help users memorize scriptures.
/// </summary>
class Program
{
    static void Main()
    {
        // Initialize scripture (example: John 3:16)
        Reference reference = new Reference("John", 3, 16);
        string text = "For God so loved the world that he gave his one and only Son";
        Scripture scripture = new Scripture(reference, text);

        // Main loop for user interaction
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words are hidden. Press Enter to exit.");
                Console.ReadLine();
                break;
            }

            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input?.ToLower() == "quit")
                break;

            scripture.HideRandomWords(2); // Hide 2 words per iteration
        }
    }
}