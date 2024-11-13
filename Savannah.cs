class Savannah : Biome
{
    public Savannah(string name) : base(name)
    {
        spaces =
        [
            new Busken("busken"),
            new Træet("træet"),
            new Vandhullet("vandhullet")
        ];

        SetupEgdes();
        entrySpace = spaces[2];
        exitSpace = spaces[1];
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
        spaceQuestion = "hvad er 1 + 1?";
        spaceAnswerChoices = 
        [
            ("2",true),
            ("1",false),
            ("3",false),
        ];
    }
}

class Træet : Space
{
    public Træet(string name) : base(name)
    {
        spaceDestription = $"you are in {name}";
        spaceQuestion = "hvad er 1 + 1?";
        spaceAnswerChoices = 
        [
            ("2",true),
            ("1",false),
            ("3",false),
        ];
    }
}

class Vandhullet : Space
{
    public Vandhullet(string name) : base(name)
    {
        spaceDestription = $"you are in {name}";
        spaceQuestion = "hvad er 1 + 1?";
        spaceAnswerChoices = 
        [
            ("2",true),
            ("1",false),
            ("3",false),
        ];
    }
}