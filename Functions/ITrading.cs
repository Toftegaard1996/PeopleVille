using PeopleVille.PeopleClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PeopleVille.Functions
{
    interface ITrading
    {
        void StartTrading(Person person);

        void TradeItem(Person person, string npcItem, string yourItem);

        string AttemptRobbery(Person person);

        string StopTrading(Person person);
    }
}
