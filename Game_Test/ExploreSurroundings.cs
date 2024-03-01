using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Test
{
    public class ExploreSurroundings : IExplorable
    {
        public void Explore(Player player)
        {
            Console.WriteLine($"{player.Name} explores the surroundings...");

            Random rand = new Random();
            int eventNumber = rand.Next(1, 6); // Increased range for more events

            switch (eventNumber)
            {
                case 1:
                    Console.WriteLine("You find a beautiful view!");
                    break;
                case 2:
                    Console.WriteLine("You stumble upon a hidden path.");
                    break;
                case 3:
                    Console.WriteLine("You discover a small cave.");
                    break;
                case 4:
                    Console.WriteLine("You encounter a friendly traveler.");
                    InteractWithTraveler(player);
                    break;
                case 5:
                    Console.WriteLine("You find a treasure chest!");
                    OpenTreasureChest(player);
                    break;
                default:
                    Console.WriteLine("You continue exploring...");
                    break;
            }
        }
        private void InteractWithTraveler(Player player)
        {
            Console.WriteLine("The traveler greets you warmly.");

        }
        private void OpenTreasureChest(Player player)
        {
            Console.WriteLine("You approach the treasure chest...");

            Random rand = new Random();
            int goldAmount = rand.Next(10, 101); 
            player.Gold += goldAmount;

            Console.WriteLine($"You found {goldAmount} gold coins in the treasure chest!");
        }
    }
}
