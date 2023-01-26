using System;
using System.Collections.Generic;
using System.Linq;
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
            int whichEvent = RNG.Range(1, 2);
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
                    for (int i = 0; i < person.Persons.Count(); i++)
                    {
                        if (person.Persons[i].Job == "Jobless" && person.Persons[i].Age >= 65)
                        {
                            Console.WriteLine("CRASH!");
                            Console.WriteLine("Sounds like someone crashed their car.");
                            Console.WriteLine("They're being rushed to the hospital");
                            person.Persons[i].Location = buildingList.Find(c => c.Name == "Hospital").Location;

                        }

                    }
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
