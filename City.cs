class City : Space
{
    public City(string name) : base(name)
    {
        paths = ["Highway", "Park", "Bikelane", "Alley"];
        spaceDestription = "Urbanization leads to significant habitat loss and degradation through direct destruction,\nfragmentation, pollution, and the introduction of invasive species.\nThis combination severely impacts ecosystems and threatens the survival of many native species.\nAlthough cities create green spaces to address this problem,\nthese efforts do not adequately tackle the root issue of overconsumption.";

        spaceQuestion = "someQuestion";
        spaceAnswerChoices =
        [
            ("Answer0", true),
            ("Answer1", false),
            ("Answer2", false),
        ];
    }
}