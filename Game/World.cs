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
        get {return startSpace;}
    }
    public Biome StartBiome
    {
        get {return startBiome;}
    }

    public Dictionary<string, Biome> BiomesSet
    {
        get {return biomesSet;}
    }

    public World()
    {
        Dictionary<string, Space> spacesDict = LoadSpaces();

        biomesSet.Add("Savannah",   new Savannah(   "Savannah", spacesDict.Where(space => space.Value.Biome == "Savannah"). ToDictionary()));
        biomesSet.Add("City",       new City(       "City",     spacesDict.Where(space => space.Value.Biome == "City").     ToDictionary()));
        biomesSet.Add("Beach",      new Beach(      "Beach",    spacesDict.Where(space => space.Value.Biome == "Beach").    ToDictionary()));
        biomesSet.Add("Forest",     new Forest(     "Forest",   spacesDict.Where(space => space.Value.Biome == "Forest").   ToDictionary()));
        biomesSet.Add("Farm",       new Farm(       "Farm",     spacesDict.Where(space => space.Value.Biome == "Farm").     ToDictionary()));

        startBiome = SetStartBiome();
        startSpace = SetStartSpace();
    }
    
    private Biome SetStartBiome()
    {
        return biomesSet.Values.ToArray()[random.Next(0, biomesSet.Count)];
    }

    private Space SetStartSpace() // Set start space to a random space
    {
        startSpace = startBiome.Spaces.Values.ToArray()[random.Next(0, startBiome.Spaces.Count)];
        return startSpace;
    }

    public Biome SetNextBiome(Biome currentBiome, Space currentSpace)
    {   
        Biome[] differentBiomes = GetDifferentNonCompletedBiome(currentBiome);
        int i = random.Next(0, differentBiomes.Length);
        
        currentSpace.AddEdge( differentBiomes[i].Name, 
            differentBiomes[i].Spaces.Values.ToArray()[random.Next(0, startBiome.Spaces.Count)]);
        
        return differentBiomes[i];   
    }

    private Biome[] GetDifferentNonCompletedBiome(Biome currentBiome)
    {
        return biomesSet.Values.Where(biome => 
            biome.GetType() != currentBiome.GetType() &&    // Picks biomes of different type from currentSpace
            !biome.Complete).ToArray();                     // Picks biomes that are not complete
    }

    public Dictionary<string, Space> LoadSpaces()
    {
        string jsonString = File.ReadAllText("spaces.json");
        Dictionary<string, Space> spaces = new Dictionary<string, Space>();
        
        try
        {
            spaces = JsonSerializer.Deserialize<Dictionary<string, Space>>(jsonString) 
                ?? new Dictionary<string, Space>();

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