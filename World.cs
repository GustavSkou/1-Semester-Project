/* World class for modeling the entire in-game world
*/

class World 
{
  Space start;
  public World () 
  {
    Space savannah    = new Savannah("Savannah");
    Space city        = new City("City");
    Space beach       = new Beach("Beach");
    Space forest      = new Forest("Forest");
    Space farm        = new Farm("Farm");
    
    /*savannah.AddEdge("Horisonten", beach);
    savannah.AddEdge("Vandhullet", city);
  
    city.AddEdge("Træerne", forest);
    city.AddEdge("Motorvej", farm);
    
    beach.AddEdge("north", city);
    beach.AddEdge("south", forest);
    
    forest.AddEdge("door", farm);
    forest.AddEdge("dsa", farm);
    
    farm.AddEdge("das", savannah);
    farm.AddEdge("door", savannah);*/
    
    this.start = savannah;
  }
  
  public void SetNextSpace()
  {

  }

  public Space GetEntry () {
    return start;
  }
}

