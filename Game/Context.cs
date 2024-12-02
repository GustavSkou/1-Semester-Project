using System.Collections.Generic;

class Context
{
    private Space currentSpace;
    private Biome currentBiome;
    private Biome? nextBiome;
    private World world;
    private Question? currentQuestion;
    private bool done, inQuestion;
    private int health, karma;
    public int Health { get { return health; } set { health = value; } }
    public int Karma { get { return karma; } set { karma = value; } }
    public IReadOnlyList<string> Items => items;

    private List<string> items; // Keeps items private for internal management



    public Space CurrentSpace
    {
        get { return currentSpace; }
    }

    public Question? CurrentQuestion
    {
        get { return currentQuestion; }
        set { currentQuestion = value; }
    }

    public bool Done
    {
        get { return done; }
        set { done = value; }
    }

    public bool InQuestion
    {
        get { return inQuestion; }
        set { inQuestion = value; }
    }

    public Biome CurrentBiome
    {
        get { return currentBiome; }
        set { currentBiome = value; }
    }

    public Biome? NextBiome
    {
        get { return nextBiome; }
        set { nextBiome = value; }
    }

    public World World
    {
        get { return world; }
        set { world = value; }
    }

    public Context(World world)
    {
        this.world = world;
        currentSpace = world.StartSpace;
        currentBiome = world.StartBiome;
        nextBiome = null;
        currentQuestion = new Question();
    }

    public void Transition(string direction)
    {
        Console.Clear();
        currentSpace.DisplayGoodbye();

        Space nextSpace = currentSpace.FollowEdge(direction);
        if (currentSpace.Biome != nextSpace.Biome) currentBiome = nextBiome;

        currentSpace = nextSpace;
        currentQuestion = currentSpace.Quest;
        currentSpace.DisplayWelcome();
        DisplayContext();
    }

    public void DisplayContext()
    {


        /*if (currentSpace.Description != null) currentSpace.DisplayDescription();
        if (currentQuestion != null && !currentSpace.Complete)
        {
            currentSpace.DisplayQuestion(this);
        }
        if (!inQuestion)
        {
            currentSpace.DisplayExits();
        }
        return;*/
    }

    public bool IsAllSpacesComplete()
    {
        foreach (Space space in currentBiome.SpacesDict.Values)
        {
            if (!space.Complete) return false;
        }
        return true;
    }

    public bool IsAllBiomesComplete()
    {
        foreach (Biome biome in world.BiomesSet.Values)
        {
            if (!biome.Complete) return false;
        }
        return true;
    }

    public void QuitGame()
    {
        done = true;
        return;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0) Health = 0;
        Console.WriteLine($"You took {damage} damage. Remaining health: {health}");
    }

    public void Heal(int amount)
    {
        health += amount;
        if (health > 100) health = 100;
        Console.WriteLine($"You healed {amount} health. Current health: {health}");
    }

    public void AddKarma(int points)
    {
        karma += points;
        Console.WriteLine($"You earned {points} karma. Total karma: {karma}");
    }

    public void DeductKarma(int points)
    {
        karma -= points;
        if (karma < 0) karma = 0;
        Console.WriteLine($"You lost {points} karma. Total karma: {karma}");
    }

    public bool HasItem(string item)
    {
        return items.Contains(item);
    }

    public void AddItem(string item)
    {
        if (!items.Contains(item))
        {
            items.Add(item);
            Console.WriteLine($"You picked up {item}!");
        }
        else
        {
            Console.WriteLine($"You already have {item}.");
        }
    }

    public void ShowStatus()
    {
        Console.WriteLine($"Health: {health}");
        Console.WriteLine($"Karma: {karma}");
        Console.WriteLine("Items: " + (items.Count > 0 ? string.Join(", ", items) : "None"));
    }
}
