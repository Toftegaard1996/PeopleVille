using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleVille.PeopleClasses;

namespace PeopleVille.Functions
{
    public delegate void Notify();
    public class EventPusblisher
    {
        public event Notify EventCompleted;

        public void EventStart(Person person) 
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
            

            OnEventCompletion();
        }
        protected virtual void OnEventCompletion() 
        {
            EventCompleted?.Invoke();
        }
    }
}
