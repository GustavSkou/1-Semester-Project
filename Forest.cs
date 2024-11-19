class Forest : Biome
{
 public Forest (string name, Dictionary<string, Space> spaces) : base(name, spaces)
    {

        entrySpace = spaces["Forgotten Path"];
        exitSpace = spaces["Distant Horizon"];

      	spaces["The Trees"].AddEdge(spaces["Distant Horizon"].Name,spaces["Distant Horizon"]);
        spaces["Distant Horizon"].AddEdge(spaces["Hidden WaterHole"].Name,spaces["Hidden WaterHole"]);
        spaces["Hidden WaterHole"].AddEdge(spaces["Forgotten Path"].Name,spaces["Forgotten Path"]);
        spaces["Forgotten Path"].AddEdge(spaces["The Trees"].Name,spaces["The Trees"]);
    }
}