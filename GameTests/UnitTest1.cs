
    class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LoadJsonFile()
        {
            World world = new World();
            if (world.BiomesSet.Count > 0) 
            {
                Assert.Pass();
            }
            else {
                Assert.Fail();
            }
        }

        [Test]
        public void CompleteAllSpaces()
        {
            
        }
    }
