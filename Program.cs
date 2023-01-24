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
People people = new People();
Player player = new Player(PlayerName, 0, "");
Person person = new Person(0, "", 0, 0, "", "");
player.CreatePlayer(PlayerName, 0,"");
person.CreatePerson(0, "", 0, 0, "", "");
person.CreatePerson(0, "", 0, 0, "", "");
Console.WriteLine("Thank you!");
Console.WriteLine("Welcome to PeopleVille " + PlayerName);
Console.ReadLine();
Console.Clear();
//While løkke til at starte ny dag
Console.WriteLine("Today's population of PeopleVille is: " + person.Population);
Console.WriteLine("The time is 8 am, it's time for work.");
Console.WriteLine("Do you want to work today? If yes, you'll be assigned a random job \nYes \nNo");
string chooseToWork = Console.ReadLine();
switch (chooseToWork)
{
    case "Yes":
        for (int i = 0; i < 9; i++)
        {
            people.Tick();
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
            Console.WriteLine("1: Trading or talking with a villager \n2: Walk around \n3: See your inventory \n4: Shopping");
            int whatNext = int.Parse(Console.ReadLine());
            switch (whatNext)
            {
                case 1:
                    break;
                case 2:
                    Console.WriteLine("You walk around the town and see the different buildings");
                    for (int q = 0; q < buildingList.Count(); q++)
                    {
                        Console.WriteLine(buildingList[i].Name);
                    }
                    Console.WriteLine("What a nice town");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 3:
                    Console.WriteLine("Your inventory, right");
                    for (int w = 0; w < player.inventory.items.Count(); w++)
                    {
                        Console.WriteLine(player.inventory.items[w].Name);
                        Console.WriteLine(player.inventory.items[w].Value);
                    }
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 4:
                    break;
            }
            people.Tick();
            Console.ReadLine();
            Console.Clear();
        }
        break;
}
Console.WriteLine("So, what do you want to do now?");
Console.WriteLine("Shopping \nTrading or talking with a villager \nWalk around \nSee your inventory");








