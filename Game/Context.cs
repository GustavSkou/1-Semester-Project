using System.Collections.Generic;

class Context
{
    public Player Player { get; private set; }
    public List<Biome> Biomes { get; private set; }
    public Biome? CurrentBiome { get; set; }
    public Room? CurrentRoom { get; set; }

    public Context(Player player)
    {
        Player = player;
        Biomes = new List<Biome>();
        CurrentBiome = null;
        CurrentRoom = null;
    }

    public void LoadBiomes(string filePath)
    {
        Biomes = DataLoader.LoadBiomes(filePath); // Load biomes using the DataLoader
    }
}
