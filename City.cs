class City : Space
{
    public City(string name) : base(name)
    {
        paths = ["Horisonten", "VandHullet", "Stien", "Træerne"];
        spaceDestription = "Urban populations consume vast amounts of food, water, and energy. \nTo meet these needs, forests are often cleared to make way for agricultural land, \nwhich can lead to habitat loss and biodiversity decline.";
    }
}