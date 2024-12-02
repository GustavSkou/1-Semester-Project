using System.Collections.Generic;

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
}
