class Biome
{
    public string Name { get; }
    public List<Room> Rooms { get; }

    public Biome(string name)
    {
        Name = name;
        Rooms = new List<Room>();
    }

    public void AddRoom(Room room)
    {
        Rooms.Add(room);
    }

    public void ListRooms() {
        int index = 1;
        foreach (Room room in Rooms) {
            Console.WriteLine($"{index}. {room.Name}");
            index++;
        }
        Console.WriteLine();
    }
}
