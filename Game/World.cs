/* World class for modeling the entire in-game world */
using System.Text.Json;

public class World
{
    public Space startSpace;
    private Biome startBiome;
    private Dictionary<string, Biome> biomesSet = [];
    private Random random = new Random();

    public Space StartSpace
    {
        get { return startSpace; }
    }
    public Biome StartBiome
    {
        get { return startBiome; }
    }

    public Dictionary<string, Biome> BiomesSet
    {
        get { return biomesSet; }
    }

    public World()
    {
        Dictionary<string, Space> spacesDict = LoadSpaces();

        biomesSet.Add("Savannah", new Savannah("Savannah", spacesDict.Where(space => space.Value.Biome == "Savannah").ToDictionary()));
        biomesSet.Add("City", new City("City", spacesDict.Where(space => space.Value.Biome == "City").ToDictionary()));
        biomesSet.Add("Beach", new Beach("Beach", spacesDict.Where(space => space.Value.Biome == "Beach").ToDictionary()));
        biomesSet.Add("Forest", new Forest("Forest", spacesDict.Where(space => space.Value.Biome == "Forest").ToDictionary()));
        biomesSet.Add("Farm", new Farm("Farm", spacesDict.Where(space => space.Value.Biome == "Farm").ToDictionary()));

        startBiome = SetStartBiome();
        startSpace = SetStartSpace();
    }

    private Biome SetStartBiome()
    {
        return biomesSet.Values.ToArray()[random.Next(0, biomesSet.Count)];
    }

    private Space SetStartSpace() // Set start space to a random space
    {
        startSpace = startBiome.SpacesDict.Values.ToArray()[random.Next(0, startBiome.SpacesDict.Count)];
        return startSpace;
    }

    public Biome SetNextBiome(Biome currentBiome, Space currentSpace)
    {
        Biome[] differentBiomes = GetDifferentNonCompletedBiome(currentBiome);
        int i = random.Next(0, differentBiomes.Length);

        currentSpace.AddEdge(
            differentBiomes[i].Name,
            differentBiomes[i].SpacesDict.Values.ToArray()
                [random.Next(0, currentBiome.SpacesDict.Count)]);

        /* The SetNextBiome method makes used of the "GetDifferentNonCompletedBiome" method and the Random class to return biome that is both different not completed of randomly selected */

        return differentBiomes[i];
    }

    private Biome[] GetDifferentNonCompletedBiome(Biome currentBiome)
    {
        return biomesSet.Values.Where(biome =>
            biome.GetType() != currentBiome.GetType() &&
            !biome.Complete).ToArray();

        /* To return an array of biomes that are different from the current biome and are not completed, we have to sort out all the biomes that would fit those two criteria.
        This is done by using the linq operator Where, this will return an IEnumerable that satisfies our conditions. By doing this we can comperes the biomes in biomesSet.Values to the current biome, using getype to insure it is not the same type and by making use of the Complete property from biome to insure it is not complete.
        */
    }

    public Dictionary<string, Space> LoadSpaces()
    {
        /* Since all our spaces are stored in a json file, we need to deserialize this json file in space object so that we can access them */

        string jsonString = File.ReadAllText("spaces.json");
        Dictionary<string, Space> spaces = new Dictionary<string, Space>();

        try
        {
            spaces = JsonSerializer.Deserialize<Dictionary<string, Space>>(jsonString)
                ?? new Dictionary<string, Space>();

            /* This is done by making use of the JsonSerializer class. By doing this we can Deserialize the json file into data type that represents the way our json file is formatted. Since we have formatted ours like a dictionary with strings as keys and spaces as values, we have deserialized ours json file into this.
            By doing to 
            */

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