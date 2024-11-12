/* World class for modeling the entire in-game world */

class World
{
    private Space startSpace;
    private Space[] spaces;
    private Random random = new Random();
    private readonly int edges;

    public Space StartSpace
    {
        get {return startSpace;}
    }

    public Space[] Spaces
    {
        get {return spaces;}
    }

    public World()
    {
        spaces = 
        [
            new Savannah("Savannah"), 
            new City("City"), 
            new Beach("Beach"), 
            new Forest("Forest"), 
            new Farm("Farm")
        ];
        edges = 2;
        startSpace = SetStartSpace();
    }
    
    private Space SetStartSpace() // Set start space to a random space
    {
        return spaces[0];
    }

    /*public void SetNextSpaces(Space currentSpace, Dictionary<Space,bool> completedSpaces)
    {
        if (currentSpace.Edges.Count > 0)
        {
            currentSpace.RemoveEdges();
        }
        
        Space[] differentSpaces = GetDifferentNonCompletedSpaces(currentSpace, completedSpaces);
        string[] paths = currentSpace.Paths;

        for (int edge = 0; edge < edges; edge++)
        {
            int pathIndex = random.Next(0, paths.Length);
            int spaceIndex = random.Next(0, differentSpaces.Length);

            currentSpace.AddEdge(paths[pathIndex], differentSpaces[spaceIndex]);
            
            paths = paths.Where(path => path != paths[pathIndex]).ToArray();
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