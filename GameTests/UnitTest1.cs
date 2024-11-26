
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

        
    }
