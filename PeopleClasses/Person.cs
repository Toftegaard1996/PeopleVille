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
    public class Person:People
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
                string[] jobs = { "Cashier", "Police", "Nurse", "Doctor", "Librarian", "Teacher", "WeaponCashier", "MusicCashier", "Banker" };
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

        public override void Working(List<building> buildingList) 
        {
            for (int i = 0; i < Persons.Count(); i++)
            {
                switch (Persons[i].Job)
                {
                    case "Cashier":
                        if (TimeOfDay >= 2 && TimeOfDay <= 9)
                        {
                            Persons[i].Location = buildingList.Find(c => c.Location == "IDCVej").Location;
                        }
                        else
                        {
                            int whereNow = RNG.Range(0, buildingList.Count());
                            Persons[i].Location = buildingList.Find(c => c.Location == buildingList[whereNow].Location).Location;
                        }
                        break;
                    case "Police":
                        Persons[i].Location = buildingList.Find(c => c.Location == "Garden Way").Location;
                        break;
                    case "Nurse":
                        Persons[i].Location = buildingList.Find(c => c.Location == "Royalty Street").Location;
                        break;
                    case "Doctor":
                        Persons[i].Location = buildingList.Find(c => c.Location == "Royalty Street").Location;
                        break;
                    case "Librarian":
                        if (TimeOfDay >= 2 && TimeOfDay <= 9)
                        {
                            Persons[i].Location = buildingList.Find(c => c.Location == "Main Way").Location;
                        }
                        else
                        {
                            int whereNow = RNG.Range(0, buildingList.Count());
                            Persons[i].Location = buildingList.Find(c => c.Location == buildingList[whereNow].Location).Location;
                        }
                        break;
                    case "Teacher":
                        if (TimeOfDay >= 0 && TimeOfDay <= 7)
                        {
                            Persons[i].Location = buildingList.Find(c => c.Location == "Cherry Row").Location;
                        }
                        else
                        {
                            int whereNow = RNG.Range(0, buildingList.Count());
                            Persons[i].Location = buildingList.Find(c => c.Location == buildingList[whereNow].Location).Location;
                        }
                        break;
                    case "WeaponCashier":
                        if (TimeOfDay >= 2 && TimeOfDay <= 9)
                        {
                            Persons[i].Location = buildingList.Find(c => c.Location == "Garden Way").Location;
                        }
                        else
                        {
                            int whereNow = RNG.Range(0, buildingList.Count());
                            Persons[i].Location = buildingList.Find(c => c.Location == buildingList[whereNow].Location).Location;
                        }
                        break;
                    case "Student":
                        if (TimeOfDay >= 0 && TimeOfDay <= 7)
                        {
                            Persons[i].Location = buildingList.Find(c => c.Location == "Cherry Row").Location;
                        }
                        else
                        {
                            int whereNow = RNG.Range(0, buildingList.Count());
                            Persons[i].Location = buildingList.Find(c => c.Location == buildingList[whereNow].Location).Location;
                        }
                        break;
                    case "MusicCashier":
                        if (TimeOfDay >= 2 && TimeOfDay <= 9)
                        {
                            Persons[i].Location = buildingList.Find(c => c.Location == "Cherry Row").Location;
                        }
                        else
                        {
                            int whereNow = RNG.Range(0, buildingList.Count());
                            Persons[i].Location = buildingList.Find(c => c.Location == buildingList[whereNow].Location).Location;
                        }
                        break;
                    case "Banker":
                        if (TimeOfDay >= 2 && TimeOfDay <= 9)
                        {
                            Persons[i].Location = buildingList.Find(c => c.Location == "General Row").Location;
                        }
                        else
                        {
                            int whereNow = RNG.Range(0, buildingList.Count());
                            Persons[i].Location = buildingList.Find(c => c.Location == buildingList[whereNow].Location).Location;
                        }
                        break;
                }
            }
        }
    }
}