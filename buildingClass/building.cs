using PeopleVille.Functions;
using PeopleVille.ItemClass;
using PeopleVille.PeopleClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PeopleVille.buildingClass
{   
    public class building:IBuilding
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }

        private List<Supplie> stash;

        public building(string name, string location, string category)
        {
            Name = name;
            Location = location;
            Category = category;
            stash = itemRetrive.supplierList().Where(c => c.Category == category).ToList();
        }

        public void ViewItems()
        {
            foreach (var item in stash)
            {
                Console.WriteLine($"{item.Name} | Stock: {item.Stock}");
            }
        }

        public void SellItem(Player player)
        {
            foreach (var item in player.inventory.items)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("Please type the name of the item you want to sell.");
            string sellItem = Console.ReadLine();
            int rightItem = 0;
            while (rightItem == 0)
            {
                for (int r = 0; r < stash.Count; r++)
                {
                    if (stash[r].Name == sellItem)
                    {
                        rightItem++;
                    }
                }
                if (rightItem == 0)
                {
                    Console.WriteLine("You wrote the wrong item name, try again");
                    sellItem = Console.ReadLine();
                }
                while (sellItem == "")
                {
                    Console.WriteLine("Please type the name of the item you want to sell.");
                    sellItem = Console.ReadLine();

                }
            }
            player.GainMoney(player.inventory.items.Find(c => c.Name == sellItem).Value);
            player.inventory.RemoveItem(sellItem);
            Console.WriteLine($"You succesfully sold {sellItem} to the {Name}");
        }

        public void BuyItem(Player player)
        {
            string item = "";
            if (stash.Count != 0)
            {
                ViewItems();
                Console.WriteLine("Please type the name of the item you want to buy.");
                int rightItem = 0;
                item = Console.ReadLine();
                while (rightItem == 0)
                {
                    for (int r = 0; r < stash.Count; r++)
                    {
                        if (stash[r].Name == item)
                        {
                            rightItem++;
                        }
                    }
                    if (rightItem == 0)
                    {
                        Console.WriteLine("You wrote the wrong item name, try again");
                        item = Console.ReadLine();
                    }
                    while (item == "")
                    {
                        Console.WriteLine("Please type the name of the item you want to buy.");
                        item = Console.ReadLine();

                    }
                }
                if (stash.Find(c => c.Name == item).Stock != 0)
                {
                    player.LoseMoney(stash.Find(c => c.Name == item).Value);
                    player.inventory.AddItem(
                        stash.Find(c => c.Name == item).Name,
                        stash.Find(c => c.Name == item).Category,
                        stash.Find(c => c.Name == item).Value,
                        stash.Find(c => c.Name == item).Eatable,
                        stash.Find(c => c.Name == item).Smokeable,
                        stash.Find(c => c.Name == item).Shootable
                        );
                    stash.Find(c => c.Name == item).Stock--;
                }
                else { Console.WriteLine($"There are no more {Name}'s in stock"); }
            }
            else { Console.WriteLine($"The {Name} does not have anything to sell."); return; }
            
            Console.WriteLine($"You bougt a(n) {item}");
        }

        public void InteractBuilding(Player player)
        {
            int choice = 0;
            try
            {
                Console.WriteLine($"You entered the {Name} \n 1) Leave 2) Buy items 3) Sell your items");
                choice = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("That is not a number");
                Console.WriteLine("Please type the number of your wished action");
                choice = int.Parse(Console.ReadLine());
            }
            
            switch (choice)
            {
                case 1:
                    break;
                case 2:
                    BuyItem(player);
                    break;
                case 3:
                    SellItem(player);
                    break;
            }
        }
    }
}
