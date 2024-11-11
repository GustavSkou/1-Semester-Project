class Forest : Space
{
    public Forest(string name) : base(name)
    {
        paths = ["Distant Horizon", "Hidden Water Hole", "Forgotten Path", "The Trees"];
        spaceDestription = "Cattle ranching for beef production is a major threat to forest ecosystems. \nTo make room for feeding land, vast areas of forest are often cleared, which leads to massive deforestation. \nThis not only removes trees that absorb carbon dioxide but also disrupts the entire forest ecosystem, \nimpacting animals by causing them to lose their natural habitats, food sources, and shelter.";
      
        spaceQuestion = "someQuestion";
        spaceAnswerChoices =
        [
            ("Answer0", true),
            ("Answer1", false),
            ("Answer2", false),
        ];
    }
}
