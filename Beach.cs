class Beach : Space
{
    public Beach(string name) : base(name)
    {
        paths = ["Shallow Waters", "Sea Turtle Nesting Site", "Seagull Nesting Area", "Tide Pools"];
        spaceDestription = "Plastic pollution is a major threat to coastal ecosystems. Litter on the beach disrupts habitats and endangers local wildlife. Sea turtles struggle to nest among the debris, and marine animals often mistake plastic for food, which can be fatal. Cleaning up the beach will help restore this habitat, allowing animals to live and thrive in a safer environment.";
        
        infoCard = "Did you know that cigarette butts are the most common plastic pollutant found on beaches worldwide? Although they might seem small and harmless, cigarette filters are made of plastic fibers that break down slowly, polluting the sand and water.";

        spaceQuestion = "someQuestion";
        spaceAnswerChoices =
        [
            ("Answer0", true),
            ("Answer1", false),
            ("Answer2", false),
        ];
    }
}