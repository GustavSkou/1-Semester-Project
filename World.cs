/* World class for modeling the entire in-game world */

using System.Text.Json;

class World
{
    private Space startSpace;
    private Biome startBiome;
    private Biome[] biomes;
    private Random random = new Random();

    public Space StartSpace
    {
        get {return startSpace;}
    }
    public Biome StartBiome
    {
        get {return startBiome;}
    }

    public Biome[] Biomes
    {
        get {return biomes;}
    }

    public World()
    {
        Dictionary<string, Space> spacesDict = LoadSpaces();
        Space[] allSpaces = spacesDict.Values.ToArray();

        biomes = 
        [
            new Savannah("Savannah", spacesDict.Where(space => space.Value.Biome == "Savannah").ToDictionary()),

            //new City("City", spacesDict.Where(space => space.Value.Biome == "City").ToDictionary()), 

            new Beach("Beach", spacesDict.Where(space => space.Value.Biome == "Beach").ToDictionary()), 

            //new Forest("Forest", spacesDict.Where(space => space.Value.Biome == "Forest").ToDictionary()), 

            //new Farm("Farm", spacesDict.Where(space => space.Value.Biome == "Farm").ToDictionary())
        ];

        startBiome = SetStartBiome();
        startSpace = SetStartSpace();
    }
    
    private Biome SetStartBiome()
    {
        return biomes[0];
    }

    private Space SetStartSpace() // Set start space to a random space
    {
        return startBiome.EntrySpace;
    }

    public Biome SetNextBiome(Biome currentBiome)
    {   
        Biome[] differentBiomes = GetDifferentNonCompletedBiome(currentBiome);
        int i = random.Next(0, differentBiomes.Length);
        currentBiome.ExitSpace.AddEdge(differentBiomes[i].Name, differentBiomes[i].EntrySpace);
        return differentBiomes[i];   
    }

    private Biome[] GetDifferentNonCompletedBiome(Biome currentBiome)
    {
        return biomes.Where(biome => 
            biome.GetType() != currentBiome.GetType() &&    // Picks biomes of different type from currentSpace
            !biome.Complete).ToArray();                     // Picks biomes that are not complete
    }

    private Dictionary<string, Space> LoadSpaces()
    {
        try 
        {
            string jsonString = File.ReadAllText("spaces.json");
            Dictionary<string, Space> spaces = JsonSerializer.Deserialize<Dictionary<string, Space>>(jsonString);
            return spaces;
        }
        catch(Exception e)
        {
            Console.WriteLine("Json did not load");
            return [];
        }
    }
}