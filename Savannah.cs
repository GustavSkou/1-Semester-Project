class Savannah : Space
{
    public Savannah(string name) : base(name)
    {
        paths = ["Distant Horizon", "Hidden Water Hole", "Forgotten Path", "The Trees"];
        spaceDestription = "Land of endless horizons packed with incredible wildlife, and home to the King of the jungle. Unfortuanlty, through out the decades, the number of endagereded species has risen due to mass hunting by poachers. In addition, human induced fires during the dry season make the habit for the animals of the savanna incredely difficult to withstand and live in. Help us save the animals and maintain the savanna for the sake of our planet!";
            
        spaceQuestion = "Info card:\n One would usually assume that fires are bad for the environment, but they are actually very common and useful in the savanna!\n The fires in Africa's savanna actually comprise the largest proportion of areas burned globally, \n and has made the landscape and animals adapted to it over time.\n One of the main sources of the natural fires throughout history has been lighting, which resulted in patchy and less intense fires.\n These fires occurred during the summer wet season.\n But as humans started to settle and needed the landscape for agriculture,\n the human induced wildfires with high intensity now last for months during its dry season.\n These wildfires lead to high amounts of smoke, which negatively affects the environment by absorbing the sunlight and interacting with clouds which leads to less rainfall.\n\n Question:\n\n Good fires and bad fires occur in the savanna. How do the wildfires contributed to by humans differ from the natural fires in the savanna?";
        spaceAnswerChoices =
        [
            ("The human induced fires: \n - Occur during the dry season\n - Are far more intense\n - Lead to blocking of sunlight and less rainfall", true),
            ("That’s a trick question! There is no difference between the two types of fires.", false),
            ("The wild fires caused by humans last for a shorter amount of time and help with\n controlling invasive species in the savanna by burning their habitats.", false),
        ];
    }
}