
    class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void requirementOne()
        {
            //There has to be  5 biomes (City, Farm, Savannah, Forest, Beach)
            World world = new World();
            Biome[] bimoes = [new City ("City", null), new Farm("Farm", null), new Savannah("Savannah", null), new Forest("Forest", null), new Beach("Beach", null)];

            foreach(Biome biome in bimoes)
            {
                if (!world.BiomesSet.ContainsKey(biome.Name))
                {
                    
                    Assert.Fail();
                };
            }
            Assert.Pass();
        }
    }
