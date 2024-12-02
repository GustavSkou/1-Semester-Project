using System;

class Enemy
{
    public string Name { get; private set; }

    public Enemy(string name)
    {
        Name = name;
    }

    public void Attack(Player player)
    {
        int damage = new Random().Next(10, 20);
        Console.WriteLine($"{Name} attacks you and deals {damage} damage!");
        player.TakeDamage(damage);
    }
}
