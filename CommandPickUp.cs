class CommandPickUp : BaseCommand, ICommand
{
    public CommandPickUp()
    {
        description = "Use: pickup (item)";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        string itemName = parameters[0].ToLower();

        if (!context.CurrentBiome.Inventory.ContainsKey(itemName) || context.CurrentBiome.Inventory[itemName] <= 0)
        {
            context.CurrentSpace.Print($"There are no {itemName}s to pick up here.");
            return;
        }

        // Decrease count in inventory and increment shardsCollected if it's a shard
        context.CurrentBiome.Inventory[itemName]--;
        if (itemName == "shard")
        {
            context.CurrentBiome.ShardsCollected++;
            context.CurrentSpace.Print($"You have picked up a shard! {context.CurrentBiome.ShardsCollected}/{context.CurrentBiome.Spaces.Count} shards collected.");
        }

        // Check if all shards are collected
        if (context.CurrentBiome.IsInfoCardUnlocked())
        {
            context.CurrentSpace.Print($"You have collected all the shards for {context.CurrentBiome.InfoCard.InfoCardName}!");
            context.CurrentSpace.Print($"You can now assemble it using: assemble {context.CurrentBiome.InfoCard.InfoCardName}");
        }
    }
}
