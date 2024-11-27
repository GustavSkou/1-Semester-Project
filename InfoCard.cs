public class InfoCard {
    public string InfoCardName {get; set;}
    public string InfoCardDescription {get; set;}

    public int Shards {get; set;}

    public InfoCard(string name, string description) {
        InfoCardName = name;
        InfoCardDescription = description;
        Shards = 0;
    }

    public void FindShard() {
        Shards++;
        Console.WriteLine($"You have found a Shard of an Info Card {Shards}/4!");
    }

    public void ReadInfoCard() {
        if (Shards >= 4) {
            Console.WriteLine(InfoCardDescription);
        }
    }

    public void ViewInfoCard(Context context)
    {
        if (context.CurrentBiome.IsInfoCardUnlocked())
        {
            Console.WriteLine($"InfoCard for {context.CurrentBiome.Name}:");
            Console.WriteLine(context.CurrentBiome.InfoCard.InfoCardDescription);
        }
        else
        {
            Console.WriteLine($"You have not unlocked the InfoCard for {context.CurrentBiome.Name} yet.");
        }
    }

}