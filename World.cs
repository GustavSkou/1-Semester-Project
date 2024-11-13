/* World class for modeling the entire in-game world */

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
        biomes = 
        [
            new Savannah("savannah"), 
            new City("city"), 
            new Beach("beach"), 
            new Forest("forest"), 
            new Farm("farm")
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
        return startBiome.Spaces[0];
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
}