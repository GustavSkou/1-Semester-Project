using System.Text.Json;

public class DataLoader
{
    public Dictionary<string, Space> LoadSpaces()
    {
        /* Since all our spaces are stored in a json file, we need to deserialize this json file in space objects so that they can be access as objects */

        string jsonString = File.ReadAllText("spaces.json");
        Dictionary<string, Space> spaces = new Dictionary<string, Space>();

        try
        {
            spaces = JsonSerializer.Deserialize<Dictionary<string, Space>>(jsonString)
                ?? new Dictionary<string, Space>();

            spaces = spaces.ToDictionary(
                space => space.Key.ToLower(),
                space => space.Value
            );

            /* This is done by making use of the JsonSerializer class. 
            By doing this we can Deserialize the json file into a data type that represents the way our json file is formatted. 
            Since we have formatted ours like a dictionary where the keys are strings containing the space name. 
            The values are written so that they match onto the Space class's properties, insuring that the values contains a space object. 
            By doing this we insure that the json file will deserialized into a dictionary. */

        }
        catch (JsonException jsonEx)
        {
            Console.WriteLine($"JSON Deserialization Error: {jsonEx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General Error: {ex.Message}");
        }
        return spaces;
    }
}