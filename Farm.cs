class Farm : Space
{
    public Farm(string name) : base(name)
    {
        paths = ["Distant Horizon", "Hidden Water Hole", "Forgotten Path", "The Trees"];
        spaceDestription = "Intensive farming has damaged the soil's health.\nRepeated pesticide use and growing only one crop type remove important nutrients, making the soil less productive.\nOver time, the soil becomes harder to farm and harms animals and insects that need a healthy environment";
            
        spaceQuestion = "someQuestion";
        spaceAnswerChoices =
        [
            ("Answer0", true),
            ("Answer1", false),
            ("Answer2", false),
        ];
    }
}
