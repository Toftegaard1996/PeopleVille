using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PeopleVille.buildingClass;

namespace PeopleVille.ItemClass
{
    public static class itemRetrive
    {
        public static List<item> itemsList()
        {
            return JsonSerializer.Deserialize<List<item>>(File.ReadAllText($"{System.IO.Directory.GetCurrentDirectory()}\\ItemClass\\items.json"));
        }

        public static List<Supplie> supplierList()
        {
            return JsonSerializer.Deserialize<List<Supplie>>(File.ReadAllText($"{System.IO.Directory.GetCurrentDirectory()}\\ItemClass\\items.json"));
        }

        public static List<building> buildingList()
        {
            return JsonSerializer.Deserialize<List<building>>(File.ReadAllText($"{System.IO.Directory.GetCurrentDirectory()}\\ItemClass\\items.json"));
        }
    }
}
