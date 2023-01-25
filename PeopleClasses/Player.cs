using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PeopleVille.buildingClass;
using PeopleVille.ItemClass;

namespace PeopleVille.PeopleClasses
{
    public class Player:People
    {
        public Player(string name, int money, string location)
        {
            Name = name;
            Money = money;
            Location = location;
        }

        public Player()
        {

        }

        public List<Player> players= new List<Player>();

        public Player CreatePlayer(string name, int money, List<building> buildingList)
        {
            string location;
            for (int i = 0; i < RNG.Range(1, inventory.itemList.Count); i++)
            {
                int id = RNG.Range(0, inventory.itemList.Count);
                inventory.items.Add(new item(inventory.itemList[id].Name, inventory.itemList[id].Category, inventory.itemList[id].Value, inventory.itemList[id].Eatable, inventory.itemList[id].Smokeable, inventory.itemList[id].Shootable));
            }
            money = RNG.Range(100, 10000);
            int whichSpawn = RNG.Range(0, buildingList.Count);
            location = buildingList[whichSpawn].Location;
            return new Player(Name = name, Money = money, Location = location);
        }
    }
}