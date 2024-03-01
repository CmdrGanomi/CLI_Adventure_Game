using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Test
{
    public class EncounterEnemy : IExplorable
    {
        private readonly EquipmentAttributes weapon;
        private readonly EquipmentAttributes armor;

        public EncounterEnemy(EquipmentAttributes weapon, EquipmentAttributes armor)
        {
            this.weapon = weapon;
            this.armor = armor;
        }

        public void Explore(Player player)
        {
            Console.WriteLine($"{player.Name} encounters a hostile enemy!");

            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Run away");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AttackEnemy(player);
                    break;
                case "2":
                    RunAway(player);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Explore(player);
                    break;
            }
        }

        private void AttackEnemy(Player player)
        {
            int playerAttack = weapon.DamageOrDefense;
            int playerHealth = player.Health;
            int armorLevel = ConvertArmorToLevel(player.Armor);

            Console.WriteLine($"Player health: {playerHealth}");

            int enemyHealth = GenerateEnemyHealth();

            Console.WriteLine($"Enemy health: {enemyHealth}");

            while (enemyHealth > 0 && playerHealth > 0)
            {
                Console.WriteLine($"You attack the enemy with power {playerAttack}!");
                enemyHealth -= playerAttack;

                if (enemyHealth <= 0)
                {
                    Console.WriteLine("You defeated the enemy!");
                    break;
                }
                else
                {
                    int enemyAttackPower = GenerateEnemyAttackPower(armorLevel);
                    AttackWithEnemyPower(enemyAttackPower, ref playerHealth);

                    if (playerHealth <= 0)
                    {
                        Console.WriteLine("You were defeated by the enemy!");
                        break;
                    }
                }

                Console.WriteLine($"Player health: {playerHealth}");
                Console.WriteLine($"Enemy health: {enemyHealth}");

                string actionChoice = PromptPlayerAction();

                if (actionChoice != "1" && actionChoice != "2")
                {
                    Console.WriteLine("Invalid choice. Please choose again.");
                    continue; 
                }

                switch (actionChoice)
                {
                    case "1":
                        break;
                    case "2":
                        Console.WriteLine("You chose to run away. Combat ends.");
                        return;
                }
                HandleHealing(player);
            }
        }

        private void RunAway(Player player)
        {
            Console.WriteLine("You attempt to run away...");

            bool escaped = DetermineEscape(player);

            if (escaped)
            {
                Console.WriteLine("You successfully escaped from the enemy!");
            }
            else
            {
                Console.WriteLine("You failed to escape and must face the enemy!");
                AttackEnemy(player);
            }
        }

        private bool DetermineEscape(Player player)
        {
            int agility = player.Agility;
            int armorLevel = ConvertArmorToLevel(player.Armor);

            int escapeChance = agility * 2 + armorLevel * 3;

            Random rand = new Random();
            int escapeRoll = rand.Next(1, 101);

            return escapeRoll <= escapeChance;
        }

        private int ConvertArmorToLevel(string armor)
        {
            switch (armor)
            {
                case "Leather":
                    return 3;
                case "Steel Plate":
                    return 5;
                default:
                    return 1; 
            }
        }

        private int GenerateEnemyHealth()
        {
            return new Random().Next(10, 21);
        }

        private int GenerateEnemyAttackPower(int armorLevel)
        {
            int basePower = new Random().Next(5, 15);
            return Math.Max(0, basePower - armorLevel);
        }

        private void AttackWithPlayerPower(int playerAttack, int enemyHealth)
        {
            Console.WriteLine($"You attack the enemy with power {playerAttack}!");
            enemyHealth -= playerAttack;
        }

        private void AttackWithEnemyPower(int enemyAttackPower, ref int playerHealth)
        {
            Console.WriteLine($"The enemy strikes back! The enemy attacks you with power {enemyAttackPower}!");
            playerHealth -= enemyAttackPower;
        }

        private string PromptPlayerAction()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Run away");
            return Console.ReadLine();
        }

        private void HandleHealing(Player player)
        {
            if (player.Health < 100)
            {
                Console.WriteLine("Do you want to heal?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                string healChoiceAfterBattle = Console.ReadLine();

                switch (healChoiceAfterBattle)
                {
                    case "1":
                        player.Heal(20);
                        Console.WriteLine("You healed yourself.");
                        break;
                    case "2":
                        Console.WriteLine("You chose not to heal.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. You chose not to heal.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Your health is already at maximum. No need to heal.");
            }
        }
    }
}

