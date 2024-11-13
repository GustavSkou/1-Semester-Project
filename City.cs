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