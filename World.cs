/* World class for modeling the entire in-game world */

class World
{
    private Space startSpace;
    private Space[] spaces;
    private Random random = new Random();

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

        startSpace = SetStartSpace();
    }

    private Space SetStartSpace() // Set start space to a random space
    {
        return spaces[random.Next(0, spaces.Length)];
    }

    public Space GetStartSpace()
    {
        return startSpace;
    }

    public Space[] GetSpaces()
    {
        return spaces;
    }

    public void SetNextSpaces(Space currentSpace, Dictionary<Space,bool> completedSpaces)
    {
        Space[] differentSpaces = GetDifferentNonCompletedSpaces(currentSpace, completedSpaces);
        string[] paths = currentSpace.Paths;

        if (differentSpaces.Length < 1)
        {
            currentSpace.AddEdge("Ending", new End("The end"));
            return;
        }

        for (int edges = 0; edges < 2; edges++)
        {
            if (differentSpaces.Length < 2)
            {
                edges++;
            }

            int pathIndex = random.Next(0, paths.Length);
            int spaceIndex = random.Next(0, differentSpaces.Length);

            currentSpace.AddEdge(paths[pathIndex], differentSpaces[spaceIndex]);
            
            paths = paths.Where(path => path != paths[pathIndex]).ToArray();
            differentSpaces = differentSpaces.Where(space => space != differentSpaces[spaceIndex]).ToArray();
        }
    }

    private Space[] GetDifferentNonCompletedSpaces(Space currentSpace, Dictionary<Space,bool> completedSpaces)
    {
        return this.spaces.Where(space => 
            space.GetType() != currentSpace.GetType() &&    // Picks spaces of different type from currentSpace
            !completedSpaces[space]).ToArray();             // Picks spaces that are not complete
    }
}