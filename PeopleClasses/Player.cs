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
        public string Name;
        public int Money;
        public string Location;
        public Player(string name, int money, string location)
        {
            Name = name;
            Money = money;
            Location = location;
        }
        public Player CreatePlayer(string name, int money, string location)
        {
            money = RNG.Range(100, 10000);
            location = "";
            return new Player(name, money, location);
        }
        public void Interact() 
        {
            
        }

        public void Trade() 
        {
            
        }

        public void Work() 
        {
            
        }
    }
}