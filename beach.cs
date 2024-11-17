class Beach : Biome
{
    public Beach(string name, Dictionary<string, Space> spaces) : base(name, spaces)
    {
        // Shallow Waters   Sea Turtle NestingSite      Seagull NestingArea     TidePools

        entrySpace = spaces["Shallow Waters"];
        exitSpace = spaces["Seagull NestingArea"];

      	spaces["TidePools"].                AddEdge(spaces["Shallow Waters"].Name,          spaces["Shallow Waters"]);
        spaces["Shallow Waters"].           AddEdge(spaces["Sea Turtle NestingSite"].Name,  spaces["Sea Turtle NestingSite"]);
        spaces["Sea Turtle NestingSite"].   AddEdge(spaces["Seagull NestingArea"].Name,     spaces["Seagull NestingArea"]);
        spaces["Seagull NestingArea"].      AddEdge(spaces["TidePools"].Name,               spaces["TidePools"]);
    }
}