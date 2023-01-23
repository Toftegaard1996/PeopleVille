using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PeopleVille.PeopleClasses;

namespace PeopleVille.PeopleClasses
{
    public class Person:People
    {
        int Age;
        string Name;
        int Money;
        int Insanity;
        string Job;
        public List<Person> Persons = new List<Person>();
        public int Population;

        public Person(int age, string name, int money, int insanity, string job) 
        {
            Age = age;
            Name = name;
            Money = money;
            Insanity = insanity;
            Job = job;
        }
        public Person CreatePerson(int age, string name, int money, int insanity, string job) 
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
                Persons.Add(new Person(age, name, money, insanity, job));
            }

            return new Person(age, name, money, insanity, job);
        }
    }
}