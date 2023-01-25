using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PeopleVille.ItemClass;
using PeopleVille.PeopleClasses;
using PeopleVille.Functions;
using System.Reflection.Metadata;

namespace PeopleVille.PeopleClasses
{
    public class People
    {
        int Age;
        string Name;
        int Money;
        int Insanity;
        string Job;
        string Location;
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

        public void RandomEvent(Person person) 
        {
            EventPusblisher subscribeEvent = new EventPusblisher();
            subscribeEvent.EventCompleted += subscribeEvent_EventCompleted;
            subscribeEvent.EventStart(person);
        }

        public static void subscribeEvent_EventCompleted() 
        {
        }
    }
}