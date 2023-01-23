using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeopleVille.PeopleClasses
{
    public class People
    {
        int Age;
        string Name;
        string Gender;
        int Money;
        int Insanity;
        string Job;

        public int GainMoney()
        {
            return Money;
        }
        
        public int LoseMoney()
        {
            return Money;
        }

        public int SanityLevel() 
        {
            return Insanity;
        }
    }
}