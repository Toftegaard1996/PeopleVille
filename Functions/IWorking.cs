using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleVille.buildingClass;
using PeopleVille.PeopleClasses;

namespace PeopleVille.Functions
{
    interface IWorking
    {
        void Working(List<building> buildingList);
    }
}
