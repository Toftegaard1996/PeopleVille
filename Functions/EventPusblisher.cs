using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PeopleVille.buildingClass;
using PeopleVille.PeopleClasses;

namespace PeopleVille.Functions
{
    public delegate void Notify();
    public class EventPusblisher
    {
        public event Notify EventCompleted;

        public void EventStart(Person person, List<building> buildingList) 
        {
            foreach (var item in person.Persons)
            {
                if (item.Insanity == 0)
                {
                    Console.WriteLine($"Seems like {item.Name} about to lose it?..");
                    Console.WriteLine("Is that yelling in the background?");
                    Console.WriteLine("Seems to have stopped now");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            int whichEvent = RNG.Range(1, 5);
            switch (whichEvent)
            {
                case 1:
                    Console.WriteLine("There's a fire at the store! Every police officer is rushing over to stop it");
                    Console.WriteLine("Look at them go!");
                    for (int i = 0; i < person.Persons.Count(); i++)
                    {
                        if (person.Persons[i].Job == "Police")
                        {
                            Console.WriteLine(person.Persons[i].Name);
                        }
                    }
                    break;
                case 2:
                    string luckyPerson = "";
                    for (int i = 0; i < person.Persons.Count(); i++)
                    {
                        if (person.Persons[i].Job == "Jobless" && person.Persons[i].Age >= 65)
                        {
                            luckyPerson = person.Persons[i].Name;
                            person.Persons[i].Location = buildingList.Find(c => c.Name == "Hospital").Location;
                        }

                    }
                    Console.WriteLine("CRASH!");
                    Console.WriteLine("Sounds like someone crashed their car.");
                    Console.WriteLine($"{luckyPerson} is being rushed to the hospital");
                    
                    break;
                case 3:
                    Console.WriteLine("BOOM");
                    Console.WriteLine($"A car just exploded. \n And killed");
                    for (int i = 0; i < RNG.Range(1,21); i++)
                    {
                        Console.WriteLine(person.Persons[i].Name);
                        person.Persons.Remove(person.Persons[i]);
                    }
                    Console.WriteLine("Look how the paramedics is rushing to the killed people");
                    for (int i = 0; i < person.Persons.Count(); i++)
                    {
                        if (person.Persons[i].Job == "Doctor" || person.Persons[i].Job == "Nurse")
                        {
                            Console.WriteLine(person.Persons[i].Name);
                        }
                    }
                    break;
                case 4:
                    Console.WriteLine($"Inge just robbed {person.Persons[RNG.Range(1, person.Persons.Count)].Name}");
                    break;
                case 5:
                    string personName = person.Persons[RNG.Range(1, person.Persons.Count)].Name;
                    Console.WriteLine($"A unicorn just ran through the city and stumped down {personName}");
                    person.Persons.Remove(person.Persons.Find(c => c.Name == personName));
                    break;
            }


            OnEventCompletion();
        }

        protected virtual void OnEventCompletion() 
        {
            EventCompleted?.Invoke();
        }
    }
}
