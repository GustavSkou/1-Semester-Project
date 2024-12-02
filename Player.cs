using System;
using System.Collections.Generic;

class Player
{
    public int Health { get; private set; }
    public int Karma { get; private set; }
    public IReadOnlyList<string> Items => items; // Read-only property to expose items

    private List<string> items; // Keeps items private for internal management

    public Enemy Enemy = new Enemy("The Mighty Gorilla Spirit");

    private List<string> possibleItems = new List<string> {"Running Shoes", "Shield"};
    Random random;

    public Player()
    {
        Health = 100;
        Karma = 0;
        items = new List<string>();
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0) Health = 0;
        Console.WriteLine($"You took {damage} damage. Remaining health: {Health}");
    }

    public void Heal(int amount)
    {
        Health += amount;
        if (Health > 100) Health = 100;
        Console.WriteLine($"You healed {amount} health. Current health: {Health}");
    }

    public void AddKarma(int points)
    {
        Karma += points;
        Console.WriteLine($"You earned {points} karma. Total karma: {Karma}");
    }

    public void DeductKarma(int points)
    {
        Karma -= points;
        if (Karma < 0) Karma = 0;
        Console.WriteLine($"You lost {points} karma. Total karma: {Karma}");
    }

    public bool HasItem(string item)
    {
        return items.Contains(item);
    }

    public void ChanceForItem() {
        int chance = random.Next(0, 100);

        if (chance < 100) {
            int index = random.Next(0, possibleItems.Count);
            AddItem(possibleItems[index]);
        }
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
        Console.WriteLine($"Health: {Health}");
        Console.WriteLine($"Karma: {Karma}");
        Console.WriteLine("Items: " + (items.Count > 0 ? string.Join(", ", items) : "None"));
    }
}
