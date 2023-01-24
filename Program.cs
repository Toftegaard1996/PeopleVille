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
Player player = new Player(PlayerName, 0);
Person person = new Person(0, "", 0, 0, "");
People people = new People();
player.CreatePlayer(PlayerName, 0);
List<building> buildingList = JsonSerializer.Deserialize<List<building>>(File.ReadAllText($"{System.IO.Directory.GetCurrentDirectory()}\\buildingClass\\buildings.json"));
person.CreatePerson(0, "", 0, 0, "");
Console.WriteLine("Thank you!");
Console.WriteLine("Welcome to PeopleVille " + PlayerName);
Console.ReadLine();
Console.Clear(); 
Console.WriteLine("Today's population of PeopleVille is: " + person.Population);
