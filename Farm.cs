class Farm : Biome
{
    public Farm(string name) : base(name)
    {
		Space busken = new Busken("busken");
		Space træet = new Træet("træet");
		Space vandhullet = new Vandhullet("vandhullet");
	
        spaces =
        [
            busken,
            træet,
            vandhullet
        ];

        busken.AddEdge(træet.Name, træet);
        træet.AddEdge(vandhullet.Name, vandhullet);
        vandhullet.AddEdge(busken.Name, busken);

        entrySpace = busken;
        exitSpace = vandhullet;
    }
}


//paths = ["Distant Horizon", "Hidden Water Hole", "Forgotten Path", "The Trees"];
//spaceDestription = "Intensive farming has damaged the soil's health. Repeated pesticide use and growing only one crop type remove important nutrients, making the soil less productive. Over time, the soil becomes harder to farm and harms animals and insects that need a healthy environment";            