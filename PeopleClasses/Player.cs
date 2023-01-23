using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeopleVille.PeopleClasses
{
    public class Player:People
    {
        public string Name;
        public int Money;
        public Player(string name, int money)
        {
            Name = name;
            Money = money;
        }
        public Player CreatePlayer(string name, int money)
        {
            money = RNG.Range(100, 10000);
            //Inventory and items
            return new Player(name, money);
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