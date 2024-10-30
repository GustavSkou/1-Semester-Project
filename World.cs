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
}

