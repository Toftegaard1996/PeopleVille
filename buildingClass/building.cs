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

        public void Sell(Player player)
        {
            
        }

        public void Buy(Player player, string item)
        {
            player.LoseMoney(int.Parse(stash.Find(c => c.Name == item).Value));
        }
    }
}
