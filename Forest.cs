class Forest : Biome
{
    public Forest(string name) : base(name)
    {
        Space hiddenwaterhole = new HiddenWaterHole("Hidden Water Hole");
        Space trees = new TheTrees("The Trees");
        Space forgottenpath = new ForgottenPath("Forgotten Path");
        Space distanthorizon = new DistantHorizon ("Distant horizon");

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
}

class HiddenWaterHole : Space
{
    public HiddenWaterHole (string name) : base(name)
    {
        spaceDestription ="";
        spaceQuestion = " You've found a hidden water hole deep in the forest, and you notice that animals come here to drink. However, there's some trash around the water. What should you do to help protect this water source?";
        spaceAnswerChoices =
        [
            ("Leave the trash as it is so you don't disturb the area.", true),
            ("Clean up the trash to keep the water safe for animals.", false),
            ("Add more signs to show other people where the water hole is located.", false),
        ];
    }
}

class TheTrees: Space
{
    public TheTrees(string name) : base(name)
    {
        spaceDestription ="";
        spaceQuestion = "While exploring the forest, you notice that many trees have been cut down, and the ground is bare. What is the best action to help restore this part of the forest?";
        spaceAnswerChoices =
        [
            ("Plant new trees to replace the ones that were cut down.", true),
            ("Build a road through the forest for easier access.", false),
            ("Clear more land to make space for new buildings.", false)
        ];
    }
}

class ForgottenPath : Space
{
    public ForgottenPath(string name) : base(name)
    {
        spaceDestription ="";
        spaceQuestion = "As you walk along the forgotten path, you notice fewer animals and hear less birdsong than usual. Why might animals be disappearing from this area of the forest?";
        spaceAnswerChoices =
        [
            ("Deforestation is destroying their homes, leaving them with nowhere to live and find food.", true),
            ("The animals are migrating to other forests for a change of scenery.", false),
            ("Animals are becoming less active during the day because they prefer cooler temperatures.", false)
        ];
    }
}

class DistantHorizon : Space
{
    public DistantHorizon (string name) : base(name)
    {
        spaceDestription ="";
        spaceQuestion = "From the distant horizon, you spot a deer limping near a dry riverbed. It seems to be searching for water. What can you do to help animals like this deer survive in a changing environment?";
        spaceAnswerChoices =
        [
            ("Try to guide the deer toward the nearest town for help.", false),
            ("Feed the deer some food you have with you to help it regain strength.", false),
            ("Support efforts to restore water sources, so animals have a place to drink.", true)
		];
	}
}
			