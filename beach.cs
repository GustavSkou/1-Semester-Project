class Beach : Biome
{
    public Beach(string name) : base(name)
    {
        Space shallowWaters = new ShallowWaters("Shallow Waters", this);
        Space seaTurtleNestingSite = new SeaTurtleNestingSite("Sea Turtle Nesting Site", this);
        Space seagullNestingArea = new SeagullNestingArea("Seagull Nesting Area", this);
        Space tidePools = new TidePools("Tide Pools", this);
    
        spaces =
        [
            shallowWaters,
            seaTurtleNestingSite,
            seagullNestingArea,
            tidePools
        ];

        entrySpace = spaces[0];
        exitSpace = spaces[2];

      	tidePools.AddEdge("Shallow Waters", shallowWaters);
        shallowWaters.AddEdge("Sea Turtle Nesting Site", seaTurtleNestingSite);
        seaTurtleNestingSite.AddEdge("Seagull Nesting Area", seagullNestingArea);
        seagullNestingArea.AddEdge("Tide Pools", tidePools);
    }
}
//"Plastic pollution is a major threat to coastal ecosystems. Litter on the beach disrupts habitats and endangers local wildlife. Sea turtles struggle to nest among the debris, and marine animals often mistake plastic for food, which can be fatal. Cleaning up the beach will help restore this habitat, allowing animals to live and thrive in a safer environment.";
//infoCard = "Did you know that cigarette butts are the most common plastic pollutant found on beaches worldwide? Although they might seem small and harmless, cigarette filters are made of plastic fibers that break down slowly, polluting the sand and water.";


class ShallowWaters : Space 
{
    public ShallowWaters (string name, Biome biome) : base(name, biome)
    {
        spaceDestription = "Skubdi doo";
        spaceQuestion = "You have found a fish tangled in a plastic bag. What will you do?";
        spaceAnswerChoices = [
            ("Untangle the fish", true),
            ("Ignore it", false),
            ("Kill the fish", false)
        ];
    }
}

class SeaTurtleNestingSite : Space 
{
    public SeaTurtleNestingSite (string name, Biome biome) : base(name, biome)
    {
        spaceDestription = "bubidi doo";
        spaceQuestion = "You stumbled upon a sea turtle laying it's eggs. What will you do?";
        spaceAnswerChoices = 
        [
            ("Get close and take some photos", false),
            ("Ignore it", true),
            ("Try to help it", false)
        ];
    }
}

class SeagullNestingArea : Space 
{
    public SeagullNestingArea (string name, Biome biome) : base(name, biome)
    {
        spaceDestription = "flabbe flabbe";
        spaceQuestion = "You see a flock of seagulls eating some trash by the trashcan. WHat will you do?";
        spaceAnswerChoices = 
        [
            ("Attack them", false),
            ("Scare them away and throw the trash in the bin", true),
            ("Ignore it", false),
        ];
    }
}

class TidePools : Space 
{
    public TidePools (string name, Biome biome) : base(name, biome)
    {
        spaceDestription = "Pooli pooli";
        spaceQuestion = "You step into a tide pool. What will you do?";
        spaceAnswerChoices = 
        [
            ("Do it again", false),
            ("Be upset for weeks", false),
            ("Make sure to be more aware next time", true),
		];
	}
}