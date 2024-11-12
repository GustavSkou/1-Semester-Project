class Forest : Space
{
    public Forest(string name) : base(name)
    {
        paths = ["Distant Horizon", "Hidden Water Hole", "Forgotten Path", "The Trees"];
        spaceDestription = "Deforestation is the large-scale removal and destruction of forests, often to make way for agricultural development, urbanization,\nand industrial activities.\nForests, which cover around 31% of the Earth's land area, play a vital role in maintaining the balance of the planet's ecosystems.\nThey provide habitats for wildlife, help regulate the climate, purify air and water, and maintain the water cycle.";
        
        spaceQuestion = "Info card:\n Cattle ranching for beef production is a major threat to forest ecosystems. \n To make room for feeding land, vast areas of forest are often cleared, which leads to massive deforestation.\n This not only removes trees that absorb carbon dioxide but also disrupts the entire forest ecosystem, impacting animals by causing them to lose their natural habitats,\nfood sources, and shelter. \n When trees are cut down, the carbon dioxide they once absorbed is released back into the atmosphere, contributing to global warming. \n Forests are essential in regulating the Earth's climate, acting as carbon sinks by capturing and storing carbon dioxide. \n Without these forests, the climate balance is disrupted, leading to more severe weather patterns and rising temperatures. \n \n \n An environmental activist, urgently seeks your help. Illegal cattle ranching is devastating the Amazon rainforest.\n She asks you to investigate and stop the ranchers before they destroy more of the forest. \n You've tracked the cattle ranchers and you now have a chance to act. \n\n The question is: What will you do to stop the destruction?";
        spaceAnswerChoices =
        [
            ("Confront the ranchers directly and ask them to stop.", false),
            ("Report the ranchers to local authorities and expose the illegal activities.", true),
            ("Destroy the ranchers'  equipment to stop the expansion.", false),
        ];
    }
}
