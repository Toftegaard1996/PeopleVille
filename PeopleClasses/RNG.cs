using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleVille.PeopleClasses
{
    public static class RNG
    {
        private static Random _rnd = new Random();

        public static int Range(int a, int b)
        {
            return _rnd.Next(a, b);
        }

    }
}
