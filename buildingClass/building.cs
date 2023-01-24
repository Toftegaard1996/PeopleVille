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
    public class building
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
            stash = JsonSerializer.Deserialize<List<Supplie>>(File.ReadAllText($"{System.IO.Directory.GetCurrentDirectory()}\\ItemClass\\items.json")).Where(c => c.Category == category).ToList();
        }

        public void viewItems()
        {
            foreach (var item in stash)
            {
                Console.WriteLine(item);
            }
        }

        public void Sell(Player player, string item)
        {
            player.GainMoney(player.inventory.items.Find(c => c.Name == item).Value);
            player.inventory.RemoveItem(item);
        }

        public void Buy(Player player, string item)
        {
            player.LoseMoney(stash.Find(c => c.Name == item).Value);
            player.inventory.AddItem(
                stash.Find(c => c.Name == item).Name, 
                stash.Find(c => c.Name == item).Value, 
                stash.Find(c => c.Name == item).Eatable, 
                stash.Find(c => c.Name == item).Smokeable, 
                stash.Find(c => c.Name == item).Shootable
                );
        }
    }
}
