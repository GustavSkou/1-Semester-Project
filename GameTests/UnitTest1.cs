
using System.Runtime.CompilerServices;

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
<<<<<<< HEAD
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
=======
                if (!world.BiomesSet.ContainsKey(biome.Name))
                {        
                    Assert.Fail();
>>>>>>> 5ec03b03d0aa280afbb1cc630a05e51e34efacf0
                }
            }
            Assert.Pass();


        }

<<<<<<< HEAD
        
=======
        [Test]
        public void requirementTwoRooms()
        {
            //Each biome has 4 rooms 

          World world = new World();
          Dictionary<string, Space> spacesDict = world.LoadSpaces();
        
           foreach(Biome bio in world.BiomesSet.Values)
          {

             if (bio.Spaces.Count < 3)
          {
              Assert.Fail();
            
          }

            else 
          {
            Assert.Pass();
          }
          }
        }
    
    [Test]
    public void requirementTwoQuest()
    {
        //you are asked a question in each room.
        World world = new World();
     
     foreach(Biome biome in world.BiomesSet.Values)
     {
        foreach(Space space in biome.Spaces.Values)
        {

            if(space.Quest == null)
            {
                Assert.Fail();
            }
        }
     }
    Assert.Pass();
>>>>>>> 5ec03b03d0aa280afbb1cc630a05e51e34efacf0

    }
}    
