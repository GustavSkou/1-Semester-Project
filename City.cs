class City : Space
{
    public City(string name) : base(name)
    {
        paths = ["Highway", "Park", "Bikelane", "Alley"];
        spaceDestription = "Urbanization leads to significant habitat loss and degradation through direct destruction,\n fragmentation, pollution, and the introduction of invasive species.\n This combination severely impacts ecosystems and threatens the survival of many native species.\n Although cities create green spaces to address this problem,\n these efforts do not adequately tackle the root issue of overconsumption.";
    }
}