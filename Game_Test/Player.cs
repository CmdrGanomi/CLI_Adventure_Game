using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Test
{
    public class Player
    {
        public string Name { get; set; }
        public string Weapon { get; set; }
        public string Armor { get; set; }
        public int Agility { get; set; }
        public int Health { get; set; }
        public int Gold { get; set; }
        public List<string> Inventory { get; }

        public Player(string name, string weapon, string armor, int agility = 10, int health = 100)
        {
            Name = name;
            Weapon = weapon;
            Armor = armor;
            Agility = agility;
            Health = health;
            Gold = 0;
            Inventory = new List<string>();
        }
        public void Heal(int amount)
        {
            Health += amount;

            if (Health > 100)
            {
                Health = 100; // Cap health at maximum value
            }
        }
    }
}
