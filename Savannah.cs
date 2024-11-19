class Savannah : Biome
{
    public Savannah(string name, Dictionary<string, Space> spaces) : base(name, spaces)
    {
        entrySpace = spaces["Vandhullet"];
        exitSpace = spaces["Træet"];
        
        spaces["Busken"].AddEdge(spaces["Træet"].Name, spaces["Træet"]);
        spaces["Træet"].AddEdge(spaces["Vandhullet"].Name, spaces["Vandhullet"]);
        spaces["Vandhullet"].AddEdge(spaces["Busken"].Name, spaces["Busken"]);
    }
	//"Land of endless horizons packed with incredible wildlife, and home to the King of the jungle.\nUnfortuanlty, through out the decades, the number of endagereded species has risen due to mass hunting by poachers.\nIn addition, human induced fires during the dry season make the habit for the animals of the savanna incredely difficult to withstand and live in. Help us save the animals and maintain the savanna for the sake of our planet!";
}
