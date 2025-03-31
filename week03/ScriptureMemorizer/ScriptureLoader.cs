using System.Collections.Generic;
using System.Text.Json;
using System.IO;

/// <summary>
/// Loads scriptures from a JSON file into a list.
/// </summary>
public static class ScriptureLoader
{
    public static List<Scripture> LoadFromJson(string filePath)
    {
        var options = new JsonSerializerOptions
        {
            IncludeFields = true, // Include private fields during deserialization
            PropertyNameCaseInsensitive = true // Allow case-insensitive JSON properties
        };

        try
        {
            string json = File.ReadAllText(filePath);
            var scriptures = JsonSerializer.Deserialize<List<Scripture>>(json, options);

            // Initialize words for each scripture after deserialization
            foreach (var scripture in scriptures)
            {
                scripture.InitializeWords();
            }

            return scriptures;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: File '{filePath}' not found."); // Added for debugging
            return new List<Scripture>();
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON deserialization error: {ex.Message}"); // Added for debugging
            return new List<Scripture>();
        }
    }
}