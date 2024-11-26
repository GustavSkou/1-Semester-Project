
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
            //There has to be  5 biomes (City, Farm, Savannah, Forest, Beach)
            World world = new World();
            Biome[] bimoes = [new City ("City", null), new Farm("Farm", null), new Savannah("Savannah", null), new Forest("Forest", null), new Beach("Beach", null)];

            foreach(Biome biome in bimoes)
            {
                if (!world.BiomesSet.ContainsKey(biome.Name))
                {        
                    Assert.Fail();
                }
            }
            Assert.Pass();
        }

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
    }
    

        

    [Test]
    public void requirementFive()
    {
        World world = new World(); 
        Dictionary<string, Space> spacesDict = world.LoadSpaces(); //Vil gerne have alle spaces.

        foreach(Space space in spacesDict.Values) //forreach loop. Kigger på hvert space i space dictionaryet.
        {
            if(space.Quest == null) //"space.Value" går ind i space objectet i the current dictionary entry. ".Quest" checker om der er en quest i det space.
            {
                Assert.Fail($"Room {space.Name} has no quest"); //Efter at have gået ind og tjekket om der er en quest på linje 45, skriver den dette, hvis der ikke er en quest.
            };
        }
        Assert.Pass();
    }
    
}