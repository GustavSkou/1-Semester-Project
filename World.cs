/* World class for modeling the entire in-game world
*/

class World
{
    private Space startSpace;
    private Space[] spaces;
    private Random random = new Random();

    public World()
    {
        Space savannah = new Savannah("Savannah");
        Space city = new City("City");
        Space beach = new Beach("Beach");
        Space forest = new Forest("Forest");
        Space farm = new Farm("Farm");

        spaces = [savannah, city, beach, forest, farm];

        startSpace = SetStartSpace();
        SetNextSpaces(startSpace);
    }

    public void SetNextSpaces(Space currentSpace)
    {
        string GetRandomPath(Space currentSpace)    
        {
            return currentSpace.GetPaths()[random.Next(0, currentSpace.GetPaths().Length)];
        }

        Space GetRandomSpace(Space currentSpace)    //Get random different space
        {
            Space[] differentSpaces = new Space[4];

            for (int i = 0, n = 0; i < spaces.Length; i++)
            {
                if(spaces[i].GetType() == currentSpace.GetType())
                {
                    continue;
                }
                differentSpaces[n++] = spaces[i];
            }

            return differentSpaces[random.Next(0,differentSpaces.Length)];
        }
        
        currentSpace.AddEdge(GetRandomPath(currentSpace), GetRandomSpace(currentSpace));
    }

    private Space SetStartSpace() // Set start space to a random space
    {
        return spaces[random.Next(0, spaces.Length)];
    }

    public Space GetStartSpace()
    {
        return startSpace;
    }
}

