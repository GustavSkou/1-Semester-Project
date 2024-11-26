
    class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void requirementOne()
        {
            //Der skal være 5 biomer (By, Farm, Savanne, Skov, Strand)
            World world = new World();
            if (world.BiomesSet.Count == 5) 
            {
                Assert.Pass();
            }
            else {
                Assert.Fail();
            }
        }

        
        [Test]
        public void requirementfour()
        {
            // "A description of the room to give the player a sense of the surroundings."
            World world = new World();
            foreach (Biome biome in world.BiomesSet.Values)
            {
                foreach (Space space in biome.Spaces.Values)
                {
                    if (space.Quest.QuestionPromt.Length == 0 || space.Quest.QuestionPromt == null)
                    {
                        Assert.Fail();
                    }
                }
            }
            Assert.Pass();


        }

        

    }
