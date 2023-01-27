using PeopleVille.buildingClass;
using PeopleVille.PeopleClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleVille.Functions
{
    public class NormalDay
    {
        public void GivingDay(Player player, Person person, List<building> buildingList) 
        {
            int whatNext = 0;
            try
            {
                Console.WriteLine("So, what do you want to do now?");
                Console.WriteLine("Type the number of the wished action:");
                Console.WriteLine("1: Trading with a villager \n2: Walk around \n3: See your inventory \n4: Shopping \n5: Go to a specific building");
                whatNext = int.Parse(Console.ReadLine());

            }
            catch (Exception ex)
            {
                Console.WriteLine("That is not a number");
                Console.WriteLine("Please type the number of your wished action");
                whatNext = int.Parse(Console.ReadLine());
            }
            Console.Clear();
            switch (whatNext)
            {
                case 1:
                    for (int j = 0; j < person.Persons.Count; j++)
                    {
                        if (person.Persons[j].Location == player.Location)
                            Console.WriteLine(person.Persons[j].Name);
                    }
                    Console.WriteLine("\nType the name of the person you want to trade with.");
                    string whichPerson = Console.ReadLine();
                    int rightName = 0;
                    while (rightName == 0)
                    {
                        for (int r = 0; r < person.Persons.Count(); r++)
                        {
                            if (person.Persons[r].Name == whichPerson)
                            {
                                rightName++;
                            }
                        }
                        if (rightName == 0)
                        {
                            Console.WriteLine("You wrote the wrong name, try again");
                            whichPerson = Console.ReadLine();
                        }
                        while (whichPerson == "")
                        {
                            Console.WriteLine("Please type the name of the person you want to trade with.");
                            whichPerson = Console.ReadLine();
                            
                        }
                    }
                    
                    player.StartTrading(person.Persons.Find(c => c.Name == whichPerson));
                    break;
                case 2:
                    Console.WriteLine("You walk around the town and see the different buildings");
                    for (int q = 0; q < buildingList.Count(); q++)
                    {
                        Console.WriteLine(buildingList[q].Name);
                    }
                    Console.WriteLine("What a nice town");
                    break;
                case 3:
                    Console.WriteLine($"Your inventory, right | Wallet {player.Money}$ ");
                    for (int w = 0; w < player.inventory.items.Count(); w++)
                    {
                        Console.WriteLine($"{player.inventory.items[w].Name} | {player.inventory.items[w].Value}$");
                    }
                    break;
                case 4:
                    Console.WriteLine("In your location there is.");
                    for (int w = 0; w < buildingList.Count; w++)
                    {
                        if (buildingList[w].Location != player.Location)
                            continue;
                        Console.WriteLine(buildingList[w].Name);
                    }
                    Console.WriteLine("Type the name of the building you wanna enter.");
                    string buildingName = Console.ReadLine();
                    int rightBuilding = 0;
                    while (rightBuilding == 0)
                    {
                        for (int r = 0; r < buildingList.Count; r++)
                        {
                            if (buildingList[r].Name == buildingName)
                            {
                                rightBuilding++;
                            }
                        }
                        if (rightBuilding == 0)
                        {
                            Console.WriteLine("You wrote the wrong building name, try again");
                            buildingName = Console.ReadLine();
                        }
                        while (buildingName == "")
                        {
                            Console.WriteLine("Please type the name of the you want to enter.");
                            buildingName = Console.ReadLine();

                        }
                    }
                    buildingList.Find(c => c.Name == buildingName).InteractBuilding(player);
                    break;
                case 5:
                    Console.WriteLine($"You are at {player.Location} where the {buildingList.Find(c => c.Location == player.Location).Name} is");
                    Console.WriteLine("Where do you want to go?");
                    for (int w = 0; w < buildingList.Count; w++)
                    {
                        if (buildingList[w].Location != player.Location)
                        {
                            Console.WriteLine(buildingList[w].Name);
                        }
                    }
                    Console.WriteLine("Type the name of the building you want to go to.");
                    string placeToGo = Console.ReadLine();
                    int rightPlaceToGo = 0;
                    while (rightPlaceToGo == 0)
                    {
                        for (int r = 0; r < buildingList.Count(); r++)
                        {
                            if (buildingList[r].Name == placeToGo)
                            {
                                rightPlaceToGo++;
                            }
                        }
                        if (rightPlaceToGo == 0)
                        {
                            Console.WriteLine("You wrote the wrong name, try again");
                            placeToGo = Console.ReadLine();
                        }
                        while (placeToGo == "")
                        {
                            Console.WriteLine("Please type the name of the person you want to trade with.");
                            placeToGo = Console.ReadLine();

                        }
                    }
                    player.Location = buildingList.Find(c => c.Name == placeToGo).Location;
                    Console.WriteLine($"You have now arrived at {player.Location} where the {buildingList.Find(c => c.Location == player.Location).Name} is");
                    Console.WriteLine("Other people in this area are:");
                    for (int q = 0; q < person.Persons.Count(); q++)
                    {
                        if (person.Persons[q].Location == player.Location)
                        {
                            Console.WriteLine(person.Persons[q].Name);
                        }
                    }
                    break;
            }   
        }
    }
}
