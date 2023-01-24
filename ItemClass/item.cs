using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleVille.ItemClass
{
    public class item
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Value { get; set; }
        public bool Eatable { get; set; }
        public bool Smokeable { get; set; }
        public bool Shootable { get; set; }

        public item()
        {

        }

        public item(string name, int value, bool eatable, bool smokeable, bool shootable)
        {
            Name = name;
            Value = value;
            Eatable = eatable;
            Smokeable = smokeable;
            Shootable = shootable;
        }
    }
}
