/*class Forest : Biome
{
    public Forest(string name, Dictionary<string, Space> spaces) : base(name, spaces)
    {
        Space hiddenwaterhole = new HiddenWaterHole("Hidden Water Hole", this);
        Space trees = new TheTrees("The Trees", this);
        Space forgottenpath = new ForgottenPath("Forgotten Path", this);
        Space distanthorizon = new DistantHorizon ("Distant horizon", this);

		spaces =
        [
            hiddenwaterhole,
			trees,
			forgottenpath,
			distanthorizon
        ];
		
        entrySpace = hiddenwaterhole;
        exitSpace = forgottenpath;

        hiddenwaterhole.AddEdge(trees.Name, trees);
		trees.AddEdge(forgottenpath.Name, forgottenpath);
		forgottenpath.AddEdge(distanthorizon.Name, distanthorizon);
		distanthorizon.AddEdge(hiddenwaterhole.Name, hiddenwaterhole);	

       //spaceDestription = "Deforestation is the large-scale removal and destruction of forests, often to make way for agricultural development, urbanization, and industrial activities. Forests, which cover around 31% of the Earth's land area, play a vital role in maintaining the balance of the planet's ecosystems. They provide habitats for wildlife, help regulate the climate, purify air and water, and maintain the water cycle.";
    }
}*/