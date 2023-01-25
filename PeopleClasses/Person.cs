using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PeopleVille.buildingClass;
using PeopleVille.Functions;
using PeopleVille.ItemClass;
using PeopleVille.PeopleClasses;

namespace PeopleVille.PeopleClasses
{
    public class Person:People, IWorking
    {
        public List<Person> Persons = new List<Person>();
        public int Population;
        public string[] jobs;

        public Person(int age, string name, int money, int insanity, string job, string location)
        {
            Age = age;
            Name = name;
            Money = money;
            Insanity = insanity;
            Job = job;
            Location = location;
        }
        public Person(int age, string name, int money, int insanity, string job, string location, inventory items)
        {
            Age = age;
            Name = name;
            Money = money;
            Insanity = insanity;
            Job = job;
            Location = location;
            inventory = items;
        }

        public Person CreatePerson(int age, string name, int money, int insanity, string job, List<building> buildingList) 
        {
            Population = RNG.Range(11, 22);
            string location = "";
            for (int i = 0; i < Population; i++)
            {
                string[] names = { "Karl", "Inge", "Lars", "Knud", "Grete", "Annabelle", "Ib", "Søren", "AnneMarie", "Gerda", "Kurt", "Lone", "Elisabeth", "Sofus", "Sofie", "Micheal" };
                int whichName = RNG.Range(0, 16);
                string[] jobs = { "Cashier", "Police", "Nurse", "Doctor", "Librarian", "Teacher", "WeaponCashier" };
                int whichJob = RNG.Range(0, 6);
                int whichSpawn = RNG.Range(0, buildingList.Count);

                age = RNG.Range(0, 100);
                name = names[whichName];
                money = RNG.Range(100, 10000);
                var personInventory = new inventory();
                insanity = RNG.Range(0, 100);
                if (age <= 15 && age > 5)
                {
                    job = "Student";
                }
                if (age <= 5 || age > 65)
                {
                    job = "Jobless";
                }
                else
                {
                    job = jobs[whichJob];
                }
                location = buildingList[whichSpawn].Location;

                for (int k = 0; k < RNG.Range(1, inventory.itemList.Count); k++)
                {
                    int id = RNG.Range(0, inventory.itemList.Count);
                    personInventory.items.Add(new item(inventory.itemList[id].Name, inventory.itemList[id].Category, inventory.itemList[id].Value, inventory.itemList[id].Eatable, inventory.itemList[id].Smokeable, inventory.itemList[id].Shootable));
                }
                Persons.Add(new Person(age, name, money, insanity, job, location, personInventory));
            }

            return new Person(age, name, money, insanity, job, location);
        }

        public void StartWorking() 
        {
            for (int i = 0; i < Persons.Count(); i++)
            {
                switch (Persons[i].Job)
                {
                    case "Cashier": 
                        break;
                    case "Police":
                        break;
                    case "Nurse":
                        break;
                    case "Doctor":
                        break;
                    case "Librarian":
                        break;
                    case "Teacher":
                        break;
                    case "WeaponCashier":
                        break;
                }
            }
        }

        public void StopWorking() 
        {
            for (int i = 0; i < Persons.Count(); i++)
            {
                //Go to random location
            }
        }
    }
}