/* World class for modeling the entire in-game world */

class World
{
    private Space startSpace;
    private Biome startBiome;
    private Biome[] biomes;
    private Random random = new Random();
    private readonly int edges;

    public Space StartSpace
    {
        get {return startSpace;}
    }
    public Space StartBiome
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
            new Savannah("Savannah"), 
            /*new City("City"), 
            new Beach("Beach"), 
            new Forest("Forest"), 
            new Farm("Farm")*/
        ];
        edges = 1;
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

    /*public void SetNextSpaces(Space currentSpace, Dictionary<Space,bool> completedSpaces)
    {
        if (currentSpace.Edges.Count > 0)
        {
            currentSpace.RemoveEdges();
        }
        
        Space[] differentSpaces = GetDifferentNonCompletedSpaces(currentSpace, completedSpaces);

        for (int edge = 0; edge < edges; edge++)
        {
            int spaceIndex = random.Next(0, differentSpaces.Length);

            currentSpace.AddEdge(differentSpaces[spaceIndex].Name, differentSpaces[spaceIndex]);
            
            differentSpaces = differentSpaces.Where(space => space != differentSpaces[spaceIndex]).ToArray();

            if (differentSpaces.Length < 1)
            {
                break;
            }
        }
    }

    private Space[] GetDifferentNonCompletedSpaces(Space currentSpace, Dictionary<Space,bool> completedSpaces)
    {
        return spaces.Where(space => 
            space.GetType() != currentSpace.GetType() &&    // Picks spaces of different type from currentSpace
            !completedSpaces[space]).ToArray();             // Picks spaces that are not complete
    }*/
}