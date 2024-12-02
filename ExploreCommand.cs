class ExploreCommand : BaseCommand, ICommand
{
    public ExploreCommand()
    {
        description = "Explore rooms within the current biome.";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (context.CurrentBiome == null)
        {
            Console.WriteLine("No biome selected. Use 'go [biome]' to navigate to a biome first.");
            return;
        }

        if (parameters.Length == 0)
        {
            Console.WriteLine($"Rooms in the biome {context.CurrentBiome.Name}:");
            foreach (var room in context.CurrentBiome.Rooms)
            {
                string clearedStatus = room.IsCleared() ? "(Cleared)" : "(Uncleared)";
                Console.WriteLine($"- {room.Name} {clearedStatus}");
            }
            Console.WriteLine("Use 'explore [room]' to explore a specific room.");
            return;
        }

        string roomName = string.Join(" ", parameters); // Handle multi-word room names
        var roomToExplore = context.CurrentBiome.Rooms.Find(room => room.Name.Equals(roomName, StringComparison.OrdinalIgnoreCase));

        if (roomToExplore == null)
        {
            Console.WriteLine($"Room '{roomName}' not found in the biome {context.CurrentBiome.Name}.");
            return;
        }

        Console.WriteLine($"Exploring the room: {roomToExplore.Name}");
        context.CurrentRoom = roomToExplore;
        roomToExplore.Explore();

        if (roomToExplore.RoomQuest != null)
        {
            Console.WriteLine("This room has a challenge or a task! Use 'interact task' to engage.");
        }

        if (roomToExplore.RoomNpc != null)
        {
            Console.WriteLine($"You see {roomToExplore.RoomNpc.Name} here.");
        }

        roomToExplore.MarkAsCleared();
    }
}
