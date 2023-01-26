﻿using System;
using System.Text.Json;
using PeopleVille;
using PeopleVille.buildingClass;
using PeopleVille.ItemClass;
using PeopleVille.PeopleClasses;
using PeopleVille.Functions;

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
NormalDay normalDay = new NormalDay();
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
                        normalDay.GivingDay(player, person, buildingList);
                        player.Tick();
                        person.Working(buildingList);
                        Console.ReadLine();
                        Console.Clear();
                    }
                    break;
            }
            //End of normal 8 hour workday, 4 left of the day
            for (int i = 0; i < 5; i++)
            {
                normalDay.GivingDay(player, person, buildingList);
                player.Tick();
                person.Working(buildingList);
                Console.ReadLine();
                Console.Clear();
            }
            break;
        
        //End your time at PeopleVille
        case "No":
            Console.WriteLine("No problem");
            Console.WriteLine("Thank you for visiting PeopleVille, we hope to see you soon!");
            StartNewDay= false;
            break;
    }

}
