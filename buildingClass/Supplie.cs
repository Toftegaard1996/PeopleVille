using PeopleVille.PeopleClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleVille.buildingClass
{
    public class Supplie
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Value { get; set; }

        public int Stock = RNG.Range(0,50);
        public bool Eatable { get; set; }
        public bool Smokeable { get; set; }
        public bool Shootable { get; set; }

        public Supplie(string name)
        {
            Name = name;
        }
    }
}
