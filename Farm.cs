class Farm : Biome
{
    public Farm(string name, Dictionary<string, Space> spaces) : base(name, spaces)
    {
        entrySpace = spaces["The Barn"];
        exitSpace = spaces["The Stable"];

        spaces["The Barn"].AddEdge(spaces["Pond"].Name, spaces["Pond"]);
        spaces["Pond"].AddEdge(spaces["Crop Field"].Name, spaces["Crop Field"]);
        spaces["Crop Field"].AddEdge(spaces["The Stable"].Name, spaces["The Stable"]);
        spaces["The Stable"].AddEdge(spaces["The Barn"].Name, spaces["The Barn"]);
    }
}


//spaceDestription = "Intensive farming has damaged the soil's health. Repeated pesticide use and growing only one crop type remove important nutrients, making the soil less productive. Over time, the soil becomes harder to farm and harms animals and insects that need a healthy environment";            