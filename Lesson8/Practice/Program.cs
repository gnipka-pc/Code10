using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

// Идея игры:
// Игрок управляет героем, который может сражаться с монстрами и собирать сокровища.
// В игре есть несколько типов монстров и предметов. Герой может атаковать и получать урон.


// Creature - абстрактный базовый класс, представляющий общее существо с именем и здоровьем. Включает абстрактный метод Attack и виртуальный метод TakeDamage.
// Hero - класс, представляющий героя, наследует Creature. Реализует метод Attack, который атакует другое существо.
// Monster - класс, представляющий монстра, наследует Creature. Также реализует метод Attack.
// Item - базовый класс для предметов, содержит имя и описание, а также виртуальный метод Use.
// HealingPotion - класс, представляющий зелье лечения, наследует Item. Переопределяет метод Use, чтобы увеличивать здоровье героя.
// Game - класс, управляющий игрой. Содержит героя, список монстров и инвентарь предметов. Метод Play запускает игру, где герой сражается с монстрами и использует предметы.
// Program - основной класс, запускающий игру.

abstract class Creature
{
    public string Name { get; set; }
    public int Health { get; set; }

    public Creature(string name, int health)
    {
        Name = name;
        Health = health;
    }

    public abstract void Attack(Creature target);
    public virtual void TakeDamage(int damage) 
    {
        Health -= damage;
        if (Health < 0)
        {
            Health = 0;
        }
    }
}

class Hero : Creature
{
    public int AttackPower { get; set; }
    public Hero(string name, int health, int attackPower) : base(name, health)
    {
        AttackPower = attackPower;
    }

    public override void Attack(Creature target)
    {
        target.TakeDamage(AttackPower);
        System.Console.WriteLine($"{Name} attacks {target.Name} for {AttackPower} damage");
    }
}

class Monster : Creature
{
    public int AttackPower { get; set; }

    public Monster(string name, int health, int attackPower) : base(name, health)
    {
        AttackPower = attackPower;
    }

    public override void Attack(Creature target)
    {
        target.TakeDamage(AttackPower);
        System.Console.WriteLine($"{Name} attacks {target.Name} for {AttackPower} damage");
    }
}

class Item
{
    public string Name { get; set; }
    public string Description { get; set; }

    public Item(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public virtual void Use(Hero player)
    {
        // Практика B 3.
    }
}



public class Program
{
    public static void Main()
    {

    }
}