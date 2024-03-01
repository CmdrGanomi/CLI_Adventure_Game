using System;
using System.Numerics;

namespace Game_Test
{
    class Game_Main
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Welcome to the Adventure Game!");
            Console.WriteLine("\n\nPlease Enter your name");

            Console.Write("Name: ");
            string playerName = Console.ReadLine();

            string weapon = "";
            while (true)
            {
                Console.WriteLine("Pick your weapon: \n1. Sword \n2. Bow");
                Console.Write("Enter your choice: ");
                string weaponChoice = Console.ReadLine();

                switch (weaponChoice)
                {
                    case "1":
                        weapon = "Sword";
                        break;
                    case "2":
                        weapon = "Bow";
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please choose either '1' for Sword or '2' for Bow.");
                        continue;
                }
                break;
            }

            string armor = "";
            while (true)
            {
                Console.WriteLine("Pick your armor: \n1. Leather \n2. Steel Plate");
                Console.Write("Enter your choice: ");
                string armorChoice = Console.ReadLine();

                switch (armorChoice)
                {
                    case "1":
                        armor = "Leather";
                        break;
                    case "2":
                        armor = "Steel Plate";
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please choose either '1' for Leather or '2' for Steel Plate.");
                        continue;
                }
                break;
            }

            Player player = new Player(playerName, weapon, armor);

            EquipmentAttributes weaponAttributes;
            EquipmentAttributes armorAttributes;

            switch (weapon)
            {
                case "Sword":
                    weaponAttributes = new EquipmentAttributes("Sword", 10); // Assuming sword has a damage of 10
                    break;
                case "Bow":
                    weaponAttributes = new EquipmentAttributes("Bow", 8); // Assuming bow has a damage of 8
                    break;
                default:
                    // Default weapon attributes (you can set these as you prefer)
                    weaponAttributes = new EquipmentAttributes("Fist", 5); // Default damage
                    break;
            }
            player.Inventory.Add(weapon);

            switch (armor)
            {
                case "Leather":
                    armorAttributes = new EquipmentAttributes("Leather Pads", 3); // Assuming leather armor has a defense of 3
                    break;
                case "Steel Plate":
                    armorAttributes = new EquipmentAttributes("Steel Plate", 5); // Assuming steel plate armor has a defense of 5
                    break;
                default:
                    // Default armor attributes (you can set these as you prefer)
                    armorAttributes = new EquipmentAttributes("Clothes", 1); // Default defense
                    break;
            }            
            player.Inventory.Add(armor);

            EncounterEnemy encounterEnemy = new EncounterEnemy(weaponAttributes, armorAttributes);

            bool gameOver = false;
            while (!gameOver)
            {
                Console.WriteLine("1. Explore");
                Console.WriteLine("2. Inventory");
                Console.WriteLine("3. Quit");
                string input = GetValidInput("Enter your choice: ", new List<string> { "1", "2", "3" });

                switch (input)
                {
                    case "1":
                        Explore(player, weaponAttributes, armorAttributes);
                        break;
                    case "2":
                        DisplayInventory(player);
                        break;
                    case "3":
                        gameOver = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }

            Console.WriteLine("Thanks for playing!");
        }
        public static string GetValidInput(string prompt, List<string> validChoices)
        {
            string choice;
            do
            {
                Console.Write(prompt);
                choice = Console.ReadLine();
            } while (!validChoices.Contains(choice));

            return choice;
        }
        public static void Explore(Player player, EquipmentAttributes weaponAttributes, EquipmentAttributes armorAttributes)
        {
            Random rand = new Random();
            int encounter = rand.Next(1, 4);

            IExplorable encounterType;

            switch (encounter)
            {
                case 1:
                    encounterType = new ExploreSurroundings();
                    break;
                case 2:
                    encounterType = new EncounterEnemy(weaponAttributes, armorAttributes);
                    break;
                default:
                    encounterType = new ExploreSurroundings();
                    break;
            }

            encounterType.Explore(player);
        }

        static void DisplayInventory(Player player)
        {
            Console.WriteLine($"{player.Name}'s Inventory:");

            if (player.Inventory.Count == 0 && player.Gold == 0)
            {
                Console.WriteLine("Inventory is empty");
            }
            else
            {
                foreach (string item in player.Inventory)
                {
                    Console.WriteLine(item);
                }
                if (player.Gold > 0)
                {
                    Console.WriteLine($"Gold: {player.Gold}");
                }
            }
        }
    }
}