class GoCommand : BaseCommand, ICommand
{
    public GoCommand()
    {
        description = "Move to a specific biome or room.";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (GuardEq(parameters, 1))
        {
            Console.WriteLine("Usage: go [biome/room]");
            return;
        }

        string target = parameters[0].ToLower();

        // Check for biome
        var biome = context.Biomes.Find(b => b.Name.ToLower() == target);
        if (biome != null)
        {
            context.CurrentBiome = biome;
            context.CurrentRoom = null; // Reset room when switching biome
            Console.WriteLine($"You enter the {biome.Name} biome.");
            context.CurrentBiome.ListRooms();
            return;
        }

        // Check for room (if already in a biome)
        if (context.CurrentBiome != null)
        {
            context.CurrentBiome.ListRooms();

            var room = context.CurrentBiome.Rooms.Find(r => r.Name.ToLower() == target);
            if (room != null)
            {
                context.CurrentRoom = room;
                Console.WriteLine($"You enter the {room.Name}.");
                return;
            }
        }

        Console.WriteLine($"No such biome or room: {target}");
    }
}
