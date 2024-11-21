class City : Biome
{
 public City(string name, Dictionary<string, Space> spaces) : base(name, spaces)
    {
        entrySpace = spaces["Highway"];
        exitSpace = spaces["Bikelane"];
    }
}

