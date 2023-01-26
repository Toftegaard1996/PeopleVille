using System;
using System.Text.Json;
using PeopleVille;
using PeopleVille.buildingClass;
using PeopleVille.ItemClass;
using PeopleVille.PeopleClasses;

Console.WriteLine("Welcome to PeopleVille");
Console.WriteLine("The little simulation village where you can interact, trade and walk around town");
Console.WriteLine("Before you enter PeopleVille, we need your name");
string PlayerName = Console.ReadLine();
while (PlayerName == "")
{
    Console.WriteLine("You didn't enter your name, please try again");
    PlayerName = Console.ReadLine();
}
List<building> buildingList = itemRetrive.buildingList();
Player player = new Player();
Person person = new Person(0, "", 0, 0, "", "");
player.CreatePlayer(PlayerName, 0, buildingList);
person.CreatePerson(0, "", 0, 0, "", buildingList);
Console.WriteLine("Thank you!");
Console.WriteLine("Welcome to PeopleVille " + PlayerName);
Console.WriteLine("Here's your stats!");
Console.WriteLine($"You have {player.Money} coins | You spawn at {player.Location}");
Console.ReadLine();
Console.Clear();
bool StartNewDay = true;
while (StartNewDay)
{
    Console.WriteLine("Ready to start a new day in PeopleVille? \nYes \nNo");
    string ChooseNewDay = Console.ReadLine();
    switch (ChooseNewDay)
    {
        case "Yes":
            player.TimeOfDay = 0;
            player.RandomEvent(person, buildingList);
            Console.WriteLine("Today's population of PeopleVille is: " + person.Population);
            Console.WriteLine("The time is 8 am, it's time for work.");
            Console.WriteLine("Do you want to work today? If yes, you'll be assigned a random job \nYes \nNo");
            string chooseToWork = Console.ReadLine();
            switch (chooseToWork)
            {
                case "Yes":
                    for (int i = 0; i < 9; i++)
                    {
                      player.Tick();
                    }
                    Console.WriteLine("You've worked for 8 hours.");
                    Console.WriteLine("You have four left of the day.");
                    break;
                case "No":
                    Console.WriteLine("Maybe tomorrow then");
                    Console.ReadLine();
                    Console.Clear();
                    
                    for (int i = 0; i < 9; i++)
                    {
                        Console.WriteLine("So, what do you want to do now?");
                        Console.WriteLine("1: Trading or talking with a villager \n2: Walk around \n3: See your inventory \n4: Shopping \n5: Go to a specific building");
                        int whatNext = int.Parse(Console.ReadLine());
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
                                while (buildingName == "")
                                {
                                    Console.WriteLine("Please type the building you want to enter.");
                                    buildingName = Console.ReadLine();
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
                        player.Tick();
                        person.Working(buildingList);
                        Console.ReadLine();
                        Console.Clear();
                    }
                    break;
            }
            //End of normal 8 hour workday, 4 left of the day
            Console.ReadLine();
            Console.Clear();
            break;
        
        //End your time at PeopleVille
        case "No":
            Console.WriteLine("No problem");
            Console.WriteLine("Thank you for visiting PeopleVille, we hope to see you soon!");
            StartNewDay= false;
            break;
    }

}
