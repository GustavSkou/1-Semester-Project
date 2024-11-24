using System.Text.Json;

class GameSave
{
    private string currentBiome, currentSpace;
    private string[] completedBiomes, completedSpaces;

    public string CurrentBiome 
    {
        get {return currentBiome;} 
        set {currentBiome = value;}
    }

    public string CurrentSpace
    {
        get {return currentSpace;} 
        set {currentSpace = value;}
    }

    public string[] CompletedBiomes
    {
        get {return completedBiomes;} 
        set {completedBiomes = value;}
    }

    public string[] CompletedSpaces
    {
        get {return completedSpaces;} 
        set {completedSpaces = value;}
    }

    public void Save(Context context)
    {
        currentBiome = context.CurrentBiome.Name;
        currentSpace = context.CurrentSpace.Name;
        completedBiomes = SaveBiomes(context);
        completedSpaces = SaveSpaces(context);

        string jsonString = JsonSerializer.Serialize(this);
        File.WriteAllText("savefile.json", jsonString);
    }

    private string[] SaveSpaces(Context context)
    {
        List<string> completedSpaces = new List<string>();
        foreach (Biome biome in context.World.BiomesSet.Values) 
        {
            foreach (Space space in biome.Spaces.Values) 
            {
                if (space.Complete) completedSpaces.Add(space.Name);
            }
        }
        return completedSpaces.ToArray();
    }

    private string[] SaveBiomes(Context context)
    {
        return context.World.BiomesSet
            .Where(biome => biome.Value.Complete == true)
            .Select(biome => biome.Key)
            .ToArray();
    }
}