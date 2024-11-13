class Savannah : Biome
{
    public Savannah(string name) : base(name)
    {
        spaces = new Space[]
        {
            new Busken("busken"),
            new Træet("træet"),
            new Vandhullet("vandhullet")
        };

        SetupEgdes();
    }

    private void SetupEgdes()
    {
        spaces[0].AddEdge(spaces[1].Name, spaces[1]);
        spaces[1].AddEdge(spaces[2].Name, spaces[2]);
        spaces[2].AddEdge(spaces[0].Name, spaces[0]);
    }
}

class Busken : Space
{
    public Busken(string name) : base(name)
    {
        spaceDestription = $"you are in {name}";
    }
}

class Træet : Space
{
    public Træet(string name) : base(name)
    {
        spaceDestription = $"you are in {name}";
    }
}

class Vandhullet : Space
{
    public Vandhullet(string name) : base(name)
    {
        spaceDestription = $"you are in {name}";
    }
}

/*
ind i et nyt biome (savannah)
savannah har et masse forskellige spaces (vandhullet, træet, busken)


*/