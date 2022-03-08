using System;

namespace DesignPatterns.Strategy
{
    public class Gargoyle : Monster
    {
        public Gargoyle(string name, int strength, int defence, int agile)
        {
            Name = name;
            Strength = strength;
            Defence = defence;
            Agile = agile;
        }

        public override void Attack(Monster monster, int strength)
        {
            Console.WriteLine(Name + " attacks " + monster.Name + " by: " + strength);
        }

        public override void Avoid(Monster monster)
        {
            Console.WriteLine(Name + " avoids " + monster.Name + " attack");
        }

        public override void Defense(Monster monster)
        {
            Console.WriteLine(Name + " defenses " + monster.Name + " attack ");
        }

        public void SplashWater(Monster monster)
        {
            Console.WriteLine(Name + " splashes water to " + monster.Name);
        }
    }
}