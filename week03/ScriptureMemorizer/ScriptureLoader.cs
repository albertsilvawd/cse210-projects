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
        var options = new JsonSerializerOptions { IncludeFields = true };
        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Scripture>>(json, options);
    }
}