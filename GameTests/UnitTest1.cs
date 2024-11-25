
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
            World world = new World();
            Context context = new Context(world);

            foreach (Biome biome in world.BiomesSet.Values)
            {
                foreach(Space space in biome.Spaces.Values)
                {
                    space.Complete = true;
                }
            }

            if (context.IsAllSpacesComplete())
            {
                Assert.Pass();
            }
            else {
                Assert.Fail();
            }
        }

        [Test]
        public void CompleteAllBiomes()
        {
            World world = new World();
            Context context = new Context(world);

            foreach (Biome biome in world.BiomesSet.Values)
            {
                biome.Complete = true;
            }

            if (context.IsAllBiomesComplete())
            {
                Assert.Pass();
            }
            else {
                Assert.Fail();
            }
        }    
    
        [Test]
        public void CommandGo()
        {
            World world = new World();
            Context context = new Context(world);

            CommandGo go = new CommandGo();
            try
            {
                go.Execute(context, "go", ["qwerty"]);
                Assert.Pass();

            }
            catch
            {
                Assert.Fail();
            }
            
        }

    }
