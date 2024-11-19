class Savannah : Biome
{
    public Savannah(string name, Dictionary<string, Space> spaces) : base(name, spaces)
    {
        entrySpace = spaces["Sunset Ridge"];
        exitSpace = spaces["Trees"];
        
        spaces["The WaterHole"].AddEdge(spaces["Trees"].Name, spaces["Trees"]);
        spaces["Trees"].AddEdge(spaces["Sunset Ridge"].Name, spaces["Sunset Ridge"]);
        spaces["Sunset Ridge"].AddEdge(spaces["The WaterHole"].Name, spaces["The WaterHole"]);
    }
	//"Land of endless horizons packed with incredible wildlife, and home to the King of the jungle.\nUnfortuanlty, through out the decades, the number of endagereded species has risen due to mass hunting by poachers.\nIn addition, human induced fires during the dry season make the habit for the animals of the savanna incredely difficult to withstand and live in. Help us save the animals and maintain the savanna for the sake of our planet!";
}
