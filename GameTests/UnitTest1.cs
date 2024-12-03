class Tests
{
    [SetUp]
    public void Setup()
    {
    }


    [Test]
    public void RequirementOne()
    {
        // There has to be 5 biomes (City, Farm, Savannah, Forest, Beach)
        World world = new World();

        Biome[] biomes =
        [
            new Biome("City", []),
            new Biome("Farm", []),
            new Biome("Savannah", []),
            new Biome("Forest", []),
            new Biome("Beach", [])
        ];

        foreach (Biome biome in biomes)
        {
            if (!world.BiomesSet.ContainsKey(biome.Name)) Assert.Fail();
        }

        Assert.Pass();
    }

    [Test]
    public void RequirementFour()
    {
        // "A description of the room to give the player a sense of the surroundings."
        World world = new World();
        foreach (Biome biome in world.BiomesSet.Values)
        {
            foreach (Space space in biome.SpacesDict.Values)
            {
                if (space.Quest.QuestionPromt.Length == 0 || space.Quest.QuestionPromt == null)
                {
                    Assert.Fail();
                }
            }
        }
        Assert.Pass();
    }

    [Test]
    public void RequirementTwoRooms()
    {
        //Each biome has 4 spaces

        World world = new World();
        List<string> failedBiomes = new List<string>();

        foreach (Biome biome in world.BiomesSet.Values)
        {
            int count = 0;
            foreach (Space space in biome.SpacesDict.Values)
            {
                count = count + 1;
            }
            if (count < 4) failedBiomes.Add($"{biome.Name}: {count}, ");
        }

        if (failedBiomes.Count > 0) Assert.Fail($"{string.Join(" ", failedBiomes)}");

        Assert.Pass();
    }

    [Test]
    public void RequirementTwoQuest()
    {
        // These is a question in each room.

        World world = new World();

        foreach (Biome biome in world.BiomesSet.Values)
        {
            foreach (Space space in biome.SpacesDict.Values)
            {
                if (space.Quest == null) Assert.Fail($"Room {space.Name} has no quest");
            }
        }
        Assert.Pass();
    }
}