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
        public List<item> itemList = itemRetrive.itemsList();

        public List<item> items = new List<item>();

        public void RemoveItem(string item)
        {
            items.Remove(items[items.FindIndex(c => c.Name == item)]);
        }

        public void AddItem(string item, string category,int value, bool eatable, bool smokeable, bool shootable)
        {
            items.Add(new ItemClass.item(item, category, value, eatable, smokeable, shootable));
        }
    }
}
