class City : Space
{
    private string spaceDestription = "Her er der meget skrald";

    public City(string name) : base (name)
    {
        paths = ["Horisonten", "VandHullet", "Stien", "Træerne"];
    }

    public override void Destription()
    {
        Console.WriteLine(spaceDestription);
    }

}