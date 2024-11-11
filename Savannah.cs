class Savannah : Space
{
    public Savannah(string name) : base(name)
    {
        paths = ["Distant Horizon", "Hidden Water Hole", "Forgotten Path", "The Trees"];
        spaceDestription = "Welcome to the savanna! \nLand of endless horizons packed with incredible wildlife, and home to the King of the jungle. \n Unfortuanlty, through out the decades, the number of endagereded species has risen due to mass hunting by poachers. \nIn addition, human induced fires during the dry season make the habit for the animals of the savanna incredely difficult to withstand and live in. Help us save the animals and maintain the savanna for the sake of our planet!";
            
        spaceQuestion = "someQuestion";
        spaceAnswerChoices =
        [
            ("Answer0", true),
            ("Answer1", false),
            ("Answer2", false),
        ];
    }
}