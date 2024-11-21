class Forest : Biome
{
 public Forest (string name, Dictionary<string, Space> spaces) : base(name, spaces)
    {
        entrySpace = spaces["Forgotten Path"];
        exitSpace = spaces["Distant Horizon"];
    }
}