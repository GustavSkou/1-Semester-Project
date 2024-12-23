/* World class for modeling the entire in-game world */

public class World
{
    public Space startSpace;
    private Biome startBiome;
    private Dictionary<string, Biome> biomesSet = [];
    private Random random = new Random();

    private Dictionary<string, Space> spacesDict = [];

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
        DataHandler();

        biomesSet.Add("Savannah", new Biome("Savannah", spacesDict.Where(space => space.Value.Biome == "Savannah").ToDictionary()));
        biomesSet.Add("City", new Biome("City", spacesDict.Where(space => space.Value.Biome == "City").ToDictionary()));
        biomesSet.Add("Beach", new Biome("Beach", spacesDict.Where(space => space.Value.Biome == "Beach").ToDictionary()));
        biomesSet.Add("Forest", new Biome("Forest", spacesDict.Where(space => space.Value.Biome == "Forest").ToDictionary()));
        biomesSet.Add("Farm", new Biome("Farm", spacesDict.Where(space => space.Value.Biome == "Farm").ToDictionary()));

        startBiome = SetStartBiome();
        startSpace = SetStartSpace();
    }

    private Biome SetStartBiome()
    {
        return biomesSet.Values.ToArray()[
            random.Next(0, biomesSet.Count)];
    }

    private Space SetStartSpace()
    {
        return startBiome.SpacesDict.Values.ToArray()[
            random.Next(0, startBiome.SpacesDict.Count)];
    }

    public Biome SetNextBiome(Biome currentBiome, Space currentSpace)
    {
        Biome[] differentBiomes = GetDifferentNonCompletedBiome(currentBiome);
        int i = random.Next(0, differentBiomes.Length);

        currentSpace.AddEdge(
            differentBiomes[i].Name,
            differentBiomes[i].SpacesDict.Values.ToArray()
                [random.Next(0, differentBiomes[i].SpacesDict.Count)]);

        /* The SetNextBiome method makes used of the "GetDifferentNonCompletedBiome" method and the Random class to return biome that is both different not completed of randomly selected */

        return differentBiomes[i];
    }

    private Biome[] GetDifferentNonCompletedBiome(Biome currentBiome)
    {
        return biomesSet.Values.Where(biome =>
            biome.Name != currentBiome.Name &&
            !biome.Complete).ToArray();

        /* To return an array of biomes that are different from the current biome and are not completed, we have to sort out all the biomes that would fit those two criteria.
        This is done by using the linq operator Where, this will return an IEnumerable that satisfies our conditions. By doing this we can comperes the biomes in biomesSet.Values to the current biome, using Biome's Name property to insure it is not the same Biome and by making use of the Complete property to insure it has not been completed. */
    }

    private void DataHandler()
    {
        DataLoader dataLoader = new DataLoader();
        spacesDict = dataLoader.LoadSpaces();
    }
}