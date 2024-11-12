class Beach : Space
{
    public Beach(string name) : base(name)
    {
        paths = ["Shallow Waters", "Sea Turtle Nesting Site", "Seagull Nesting Area", "Tide Pools"];
        Space shallowWaters = new ShallowWaters("Shallow Waters");
        Space seaTurtleNestingSite = new SeaTurtleNestingSite("Sea Turtle Nesting Site");
        Space seagullNestingArea = new SeagullNestingArea("Seagull Nesting Area");
        Space tidePools = new TidePools("Tide Pools");

        AddEdge("Shallow Waters", shallowWaters);
        shallowWaters.AddEdge(this.Name, this);

        AddEdge("Sea Turtle Nesting Site", seaTurtleNestingSite);
        seaTurtleNestingSite.AddEdge(this.Name, this);

        AddEdge("Seagull Nesting Area", seagullNestingArea);
        seagullNestingArea.AddEdge(this.Name, this);

        AddEdge("Tide Pools", tidePools);
        tidePools.AddEdge(this.Name, this);

        spaceDestription = "test";//"Plastic pollution is a major threat to coastal ecosystems. Litter on the beach disrupts habitats and endangers local wildlife. Sea turtles struggle to nest among the debris, and marine animals often mistake plastic for food, which can be fatal. Cleaning up the beach will help restore this habitat, allowing animals to live and thrive in a safer environment.";
        
        //infoCard = "Did you know that cigarette butts are the most common plastic pollutant found on beaches worldwide? Although they might seem small and harmless, cigarette filters are made of plastic fibers that break down slowly, polluting the sand and water.";

        spaceQuestion = null;
        /*spaceAnswerChoices =
        [
            ("Answer0", true),
            ("Answer1", false),
            ("Answer2", false),
        ];*/
    }
}

class ShallowWaters : Space {
    public ShallowWaters (string name) : base(name) 
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

class SeaTurtleNestingSite : Space {
    public SeaTurtleNestingSite (string name) : base(name) 
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

class SeagullNestingArea : Space {
    public SeagullNestingArea (string name) : base(name) 
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

class TidePools : Space {
    public TidePools (string name) : base(name) 
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