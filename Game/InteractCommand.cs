class InteractCommand : BaseCommand, ICommand
{
    public InteractCommand()
    {
        description = "Interact with objects or tasks in the current room.";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        // Debug: Confirm if a room exists in the context
        if (context.CurrentRoom == null)
        {
            Console.WriteLine("Debug: Current room is null.");
            Console.WriteLine("There is nothing to interact with here.");
            return;
        }

        Room currentRoom = context.CurrentRoom;

        // Debug: Check for task or NPC in the room
        Console.WriteLine($"Debug: RoomQuest is {(currentRoom.RoomQuest != null ? "present" : "null")}.");
        Console.WriteLine($"Debug: RoomNpc is {(currentRoom.RoomNpc != null ? "present" : "null")}.");

        if (parameters.Length == 0)
        {
            Console.WriteLine("What would you like to interact with? (e.g., 'task' or 'npc')");
            return;
        }

        string target = string.Join(' ', parameters).ToLower();

        if (target == "task" && currentRoom.RoomQuest != null)
        {
            Console.WriteLine($"Interacting with the task: {currentRoom.RoomQuest.QuestionPromt}");
            Console.WriteLine("Choices:");
            foreach (var choice in currentRoom.RoomQuest.Choices)
            {
                Console.WriteLine($"{choice.Key}. {choice.Value.Choice}");
            }

            Console.Write("Enter your choice: ");
            string? input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Invalid choice. Please try again.");
                return;
            }

            if (currentRoom.RoomQuest.IsCorrectChoice(input))
            {
                Console.WriteLine("Correct! You solved the challenge.");
                currentRoom.MarkAsCleared();
            }
            else
            {
                Console.WriteLine("Wrong answer! You face consequences.");
            }
            return;
        }

        if (target == "npc" && currentRoom.RoomNpc != null)
        {
            Console.WriteLine($"You talk to {currentRoom.RoomNpc.Name}: {currentRoom.RoomNpc.Dialogue}");
            return;
        }

        Console.WriteLine($"You can't interact with '{target}'. Try 'task' or 'npc'.");
    }
}
