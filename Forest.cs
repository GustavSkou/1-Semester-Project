class Forest : Space
{
    public Forest(string name) : base(name)
    {
        paths = ["Distant Horizon", "Hidden Water Hole", "Forgotten Path", "The Trees"];
        spaceDestription = "Deforestation is the large-scale removal and destruction of forests, often to make way for agricultural development, urbanization, and industrial activities.\nForests, which cover around 31% of the Earth's land area, play a vital role in maintaining the balance of the planet's ecosystems.\nThey provide habitats for wildlife, help regulate the climate, purify air and water, and maintain the water cycle.";
        
        spaceQuestion = "someQuestion";
        spaceAnswerChoices =
        [
            ("Answer0", true),
            ("Answer1", false),
            ("Answer2", false),
        ];
    }
}
