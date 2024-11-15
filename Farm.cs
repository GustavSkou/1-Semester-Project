class Farm : Biome
{
    public Farm(string name) : base(name)
    {
		Space barn = new TheBarn("The Barn", this);
        Space pond = new Pond("Pond", this);
        Space cropField = new CropField("Crop Field", this);
        Space stable = new TheStable("The Stable", this);
    
        spaces = 
        [
            barn,
            pond,
            cropField,
            stable
        ];

        barn.AddEdge(pond.Name, pond);
        pond.AddEdge(cropField.Name, cropField);
        cropField.AddEdge(stable.Name, stable);
        stable.AddEdge(barn.Name, barn);

        entrySpace = barn;
        exitSpace = stable;
    }
}
//paths = ["The barn", "Pond", "Crop Field", "The Stable"];
//spaceDestription = "Intensive farming harms soil health and biodiversity.\nRepeated pesticide use and growing only one crop type remove important nutrients, making the soil less productive.\nThis weakens plant diversity and reduces pollinators like bees and butterflies,\n which disrupts ecosystems and affects animals that rely on healthy habitats.\n Plants and animals are essential for balanced ecosystems.\n Sustainable methods are crucial to support SDG 15: Life on Land and protect biodiversity for future generations.";


class TheBarn : Space
{

    public TheBarn (string name, Biome biome) : base(name, biome)
    {
        spaceDestription = "A cozy barn filled with livestock and tools for farming.";
        spaceQuestion = "You notice some cows looking unwell. What should you do?";
        spaceAnswerChoices = 
        [
            ("Provide fresh water and call a vet.", true),
            ("Ignore the cows; they will recover on their own.", false),
            ("Sell the cows to avoid extra costs.", false)
        ];
    }

}

class Pond : Space
{
    public Pond(string name, Biome biome) : base(name, biome)
    {
        spaceDestription = "A small pond providing water for animals and crops.";
        spaceQuestion = "The pond is polluted with trash. What will you do?";
        spaceAnswerChoices = 
        [
            ("Add more water to dilute the pollution.", false),
            ("Ignore it; nature will fix itself.", false),
            ("Clean the pond and add plants to filter the water.", true)
        ];
    }
}

class CropField : Space
{
    public CropField(string name, Biome biome) : base(name, biome)
    {
        spaceDestription = "A field used for growing crops, but the soil looks dry and cracked.";
        spaceQuestion = "What is the best method to restore soil health?";
        spaceAnswerChoices = 
        [
            ("Use chemical fertilizers.", false),
            ("Add compost and practice crop rotation.", true),
            ("Leave the soil as it is.", false)
        ];
    }
}

class TheStable : Space
{
    public TheStable(string name, Biome biome) : base(name, biome)
    {
        spaceDestription = "A stable for horses and other animals. It's peaceful, but something needs attention.";
        spaceQuestion = "The stable floor is dirty, and the animals seem uncomfortable. What will you do?";
        spaceAnswerChoices = 
        [
            ("Clean the floor and add fresh bedding.", true),
            ("Leave it; the animals will manage.", false),
            ("Move the animals outside permanently.", false)
        ];
    }
}