using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PeopleVille.Functions;
using PeopleVille.PeopleClasses;

namespace PeopleVille.PeopleClasses
{
    public class Person:People, IWorking
    {
        int Age;
        string Name;
        int Money;
        public int Insanity { get; set; }
        string Job;
        public string Location;
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
        public Person CreatePerson(int age, string name, int money, int insanity, string job, string location) 
        {
            string[] names = { "Karl", "Inge", "Lars", "Knud", "Grete", "Annabelle", "Ib", "Søren", "AnneMarie", "Gerda", "Kurt", "Lone", "Elisabeth", "Sofus", "Sofie", "Micheal" };
            int whichName = RNG.Range(0, 11);
            string[] jobs = { "Cashier", "Police", "Nurse", "Doctor", "Librarian", "Teacher", "WeaponCashier" };
            int whichJob = RNG.Range(0, 6);
            Population = RNG.Range(11, 22);
            
            age = RNG.Range(0, 100);
            name = names[whichName];
            money = RNG.Range(100, 10000);
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

            for (int i = 0; i < Population; i++)
            {
                Persons.Add(new Person(age, name, money, insanity, job, location));
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