class City : Biome
{
    public City(string name) : base(name)
    {
        spaces =
        [
            new Busken("busken"),
            new Træet("træet"),
            new Vandhullet("vandhullet")
        ];
        
        SetupEgdes();
        entrySpace = spaces[0];
        exitSpace = spaces[2];    
    }

    private void SetupEgdes()
    {
        spaces[0].AddEdge(spaces[1].Name, spaces[1]);
        spaces[1].AddEdge(spaces[2].Name, spaces[2]);
        spaces[2].AddEdge(spaces[0].Name, spaces[0]);
    }
}

        //paths = ["Highway", "Park", "Bikelane", "Alley"];
		//spaceDestription = "Urbanization leads to significant habitat loss and degradation through direct destruction, fragmentation, pollution, and the introduction of invasive species. This combination severely impacts ecosystems and threatens the survival of many native species. Although cities create green spaces to address this problem, these efforts do not adequately tackle the root issue of overconsumption.";
