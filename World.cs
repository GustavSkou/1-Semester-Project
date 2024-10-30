/* World class for modeling the entire in-game world
*/

class World 
{
  private Space startSpace;
  private Space[] spaces;

  public World () 
  {
    Space savannah    = new Savannah("Savannah");
    Space city        = new City("City");
    Space beach       = new Beach("Beach");
    Space forest      = new Forest("Forest");
    Space farm        = new Farm("Farm");
    
    spaces = [savannah, city, beach, forest, farm];

    this.startSpace = SetStartSpace();
  }
  
  public void GetNextSpace(Space currentSpace)
  {
    Random random = new Random();
    currentSpace.AddEdge(currentSpace.GetPaths()[ random.Next(0, currentSpace.GetPaths().Length) ], spaces[ random.Next(0, spaces.Length) ]);
  }

  private Space SetStartSpace()
  {
    Random random = new Random();
    return spaces[ random.Next(0, spaces.Length) ];
  }

  public Space GetStartSpace () {
    return startSpace;
  }
}

