class Beach : Space
{
    public Beach(string name) : base(name)
    {
        paths = ["Shallow Waters", "Sea Turtle Nesting Site", "Seagull Nesting Area", "Tide Pools"];
        spaceDestription = "Plastic pollution is a major threat to coastal ecosystems.\nLitter on the beach disrupts habitats and endangers local wildlife.\nSea turtles struggle to nest among the debris, and marine animals often mistake plastic for food, which can be fatal.\nCleaning up the beach will help restore this habitat, allowing animals to live and thrive in a safer environment.";
        
        spaceQuestion = "someQuestion";
        spaceAnswerChoices =
        [
            ("Answer0", true),
            ("Answer1", false),
            ("Answer2", false),
        ];
    }
}