using System;
using PeopleVille;
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
player.CreatePlayer(PlayerName, 0);
Console.WriteLine("Thank you!");
Console.WriteLine("Welcome to PeopleVille " + PlayerName);
