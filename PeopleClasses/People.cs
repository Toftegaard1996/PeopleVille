using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PeopleVille.PeopleClasses;

namespace PeopleVille.PeopleClasses
{
    public class People
    {
        int Age;
        string Name;
        int Money;
        int Insanity;
        string Job;

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
            Insanity--;
        }
    }
}