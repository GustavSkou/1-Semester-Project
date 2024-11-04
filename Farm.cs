class Farm : Space
{
    public Farm(string name) : base(name)
    {
        paths = ["Horisonten", "VandHullet", "Stien", "Træerne"];
        spaceDestription = "Intensive farming has damaged the soil's health.\n Repeated pesticide use and growing only one crop type remove important nutrients, making the soil less productive.\n Over time, the soil becomes harder to farm and harms animals and insects that need a healthy environment";
    }
}
