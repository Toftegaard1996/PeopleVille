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
People people = new People();
Player player = new Player(PlayerName, 0);
Person person = new Person(0, "", 0, 0, "", "");
player.CreatePlayer(PlayerName, 0);
person.CreatePerson(0, "", 0, 0, "", "");
List<building> buildingList = JsonSerializer.Deserialize<List<building>>(File.ReadAllText($"{System.IO.Directory.GetCurrentDirectory()}\\buildingClass\\buildings.json"));
person.CreatePerson(0, "", 0, 0, "", "");
Console.WriteLine("Thank you!");
Console.WriteLine("Welcome to PeopleVille " + PlayerName);
Console.ReadLine();
Console.Clear();
player.RandomEvent();


Console.WriteLine("Today's population of PeopleVille is: " + person.Population);
Console.WriteLine("The time is 8 am, it's time for work.");
Console.WriteLine("Do you want to roll for a random job today? \n Yes \n No");
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
        break;
}
Console.WriteLine("So, what do you want to do now?");
Console.WriteLine("Shopping \nTrading or talking with a villager \nWalk around \nSee your inventory");

