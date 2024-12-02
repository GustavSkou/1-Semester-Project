using System.Text.Json;

public class DataLoader
{
    static public Dictionary<string, Space> LoadSpaces()
    {
        /* Since all our spaces are stored in a json file, we need to deserialize this json file in space object so that we can access them */

        string jsonString = File.ReadAllText("spaces.json");
        Dictionary<string, Space> spaces = new Dictionary<string, Space>();

        try
        {
            spaces = JsonSerializer.Deserialize<Dictionary<string, Space>>(jsonString)
                ?? new Dictionary<string, Space>();

            /* This is done by making use of the JsonSerializer class. By doing this we can Deserialize the json file into a data type that represents the way our json file is formatted. Since we have formatted ours like a dictionary with strings as keys and spaces as values, we have deserialized ours json file into this.
            By doing to */


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