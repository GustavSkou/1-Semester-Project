/* World class for modeling the entire in-game world
*/

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
}

