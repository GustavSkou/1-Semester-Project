class Room
{
    public string Name { get; }
    public string Description { get; }
    public Quest? RoomQuest { get; }
    public Npc? RoomNpc { get; }
    private bool isCleared;

    public Room(string name, string description, Quest? quest = null, Npc? npc = null)
    {
        Name = name;
        Description = description;
        RoomQuest = quest;
        RoomNpc = npc;
        isCleared = false;
    }

    public void MarkAsCleared()
    {
        isCleared = true;
    }

    public bool IsCleared()
    {
        return isCleared;
    }

    public void Explore()
    {
        Console.WriteLine($"You are in {Name}: {Description}");
    }
}
