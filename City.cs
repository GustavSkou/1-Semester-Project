class City : Biome
{
 public City(string name, Dictionary<string, Space> spaces) : base(name, spaces)
    {
        entrySpace = spaces["Highway"];
        exitSpace = spaces["Bikelane"];

      	spaces["Park"].AddEdge(spaces["Bikelane"].Name,spaces["Bikelane"]);
        spaces["Bikelane"].AddEdge(spaces["Alley"].Name,spaces["Alley"]);
        spaces["Alley"].AddEdge(spaces["Highway"].Name,spaces["Highway"]);
        spaces["Highway"].AddEdge(spaces["Park"].Name,spaces["Park"]);
    }
}

