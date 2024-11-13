class Savannah : Biome
{
    public Savannah(string name) : base(name)
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

        entrySpace = spaces[2];
        exitSpace = spaces[1];

        busken.AddEdge(træet.Name, træet);
        træet.AddEdge(vandhullet.Name, vandhullet);
        vandhullet.AddEdge(busken.Name, busken);
    }
	//"Land of endless horizons packed with incredible wildlife, and home to the King of the jungle.\nUnfortuanlty, through out the decades, the number of endagereded species has risen due to mass hunting by poachers.\nIn addition, human induced fires during the dry season make the habit for the animals of the savanna incredely difficult to withstand and live in. Help us save the animals and maintain the savanna for the sake of our planet!";
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