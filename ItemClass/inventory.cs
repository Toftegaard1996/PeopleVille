using PeopleVille.PeopleClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PeopleVille.ItemClass
{
    public class inventory
    {
        private List<item> itemList = JsonSerializer.Deserialize<List<item>>(File.ReadAllText($"{System.IO.Directory.GetCurrentDirectory()}\\ItemClass\\items.json"));

        public List<item> items = new List<item>();
        public void RandomItem()
        {
            for (int i = 0; i < RNG.Range(0,itemList.Count); i++)
            {
                int id = RNG.Range(0, itemList.Count);
                items.Add(new item(itemList[id].Name, itemList[id].Value, itemList[id].Eatable, itemList[id].Smokeable, itemList[id].Shootable));
            }
        }

        public void RemoveItem(string item)
        {
            items.Remove(items[items.FindIndex(c => c.Name == item)]);
        }

        public void AddItem(string item, int value, bool eatable, bool smokeable, bool shootable)
        {
            items.Add(new ItemClass.item(item, value, eatable, smokeable, shootable));
        }
    }
}
