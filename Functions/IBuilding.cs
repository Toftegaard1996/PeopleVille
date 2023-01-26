using PeopleVille.PeopleClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleVille.Functions
{
    internal interface IBuilding
    {
        void BuyItem(Player player);
        void SellItem(Player player);
        void ViewItems();
        void InteractBuilding(Player player);
    }
}
