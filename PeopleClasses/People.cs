using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using PeopleVille.Functions;
using PeopleVille.ItemClass;
using PeopleVille.PeopleClasses;
using PeopleVille.Functions;
using System.Reflection.Metadata;
using PeopleVille.buildingClass;

namespace PeopleVille.PeopleClasses
{
    public abstract class People:ITrading, IWorking
    {
        public int Age;
        public string Name;
        public int Money;
        public int Insanity;
        public string Job;
        public string Location;
        public int TimeOfDay;
        public inventory inventory = new inventory();

        public int GainMoney(int Incoming)
        {
            Money += Incoming;
            return Money;
        }
        public int LoseMoney(int outGoing)
        {
            Money -= outGoing;
            return Money;
        }
        public void Tick()
        {
            TimeOfDay++;
            Insanity--;
        }
        public void StartTrading(Person person)
        {
            Console.Clear();
            Console.WriteLine("Your Inventory:");
            for (int i = 0; i < inventory.items.Count; i++)
            {
                Console.WriteLine(inventory.items[i].Name);
            }
            Console.WriteLine($"\nNPC Inventory | {person.Name}:");
            for (int k = 0; k < person.inventory.items.Count; k++)
            {
                Console.WriteLine(person.inventory.items[k].Name);
            }

            Console.WriteLine($"\n1) Cancel trade 2) Attempt Robbery 3) Select item");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine(StopTrading(person));
                    break;
                case 2:
                    if(person.inventory.items.Count != 0)
                        Console.WriteLine(AttemptRobbery(person));
                    else
                        Console.WriteLine($"Can't trade with {person.Name} at the moment...");
                    break;
                case 3:
                    Console.WriteLine("Type the name of the item you want. \nAnd you wanna trade. \nFx. (npcItem,yourItem) CASE SENSITIVE");
                    string[] item = Console.ReadLine().Split(",");
                    string npcItem = item[0];
                    string yourItem = item[1];
                    TradeItem(person, npcItem, yourItem);
                    break;
            }
        }
        public string AttemptRobbery(Person person)
        {
            Console.WriteLine($"You are now trying to steal {person.Name}'s items.");

            if (RNG.Range(0,100) < 50)
            {
                foreach (var item in person.inventory.items.ToList())
                {
                    inventory.AddItem(
                        item.Name,
                        item.Category,
                        item.Value,
                        item.Eatable,
                        item.Smokeable,
                        item.Shootable
                        );
                    person.inventory.RemoveItem(item.Name);
                }
                return $"You successfully robbed {person.Name}";
            }
            foreach (var item in inventory.items.ToList())
            {
                person.inventory.AddItem(
                        item.Name,
                        item.Category,
                        item.Value,
                        item.Eatable,
                        item.Smokeable,
                        item.Shootable
                );
                inventory.RemoveItem(item.Name);
            }
            return $"You failed the robbery and got beaten up. And lost your items.";
        }
        public string StopTrading(Person person)
        {
            Console.Clear();
            return $"You canceled the trade with {person.Name}";
        }
        public void TradeItem(Person person, string npcItem, string yourItem)
        {
            inventory.AddItem(
                person.inventory.items.Find(c => c.Name == npcItem).Name,
                person.inventory.items.Find(c => c.Name == npcItem).Category,
                person.inventory.items.Find(c => c.Name == npcItem).Value,
                person.inventory.items.Find(c => c.Name == npcItem).Eatable,
                person.inventory.items.Find(c => c.Name == npcItem).Shootable,
                person.inventory.items.Find(c => c.Name == npcItem).Smokeable
                );
            person.inventory.RemoveItem(npcItem);
            person.inventory.AddItem(
            inventory.items.Find(c => c.Name == yourItem).Name,
            inventory.items.Find(c => c.Name == yourItem).Category,
            inventory.items.Find(c => c.Name == yourItem).Value,
            inventory.items.Find(c => c.Name == yourItem).Eatable,
            inventory.items.Find(c => c.Name == yourItem).Shootable,
            inventory.items.Find(c => c.Name == yourItem).Smokeable
            );
            inventory.RemoveItem(yourItem);
            Console.WriteLine($"You and {person.Name} has successfully traded.");
        }

        public void RandomEvent(Person person, List<building> buildingList) 
        {
            EventPusblisher subscribeEvent = new EventPusblisher();
            subscribeEvent.EventCompleted += subscribeEvent_EventCompleted;
            subscribeEvent.EventStart(person, buildingList);
        }

        public static void subscribeEvent_EventCompleted() 
        {
            Console.WriteLine("Event done..");
        }

        public virtual void Working(List<building> buildingList)
        {
            Console.WriteLine("It's time for work");
        }
    }
}