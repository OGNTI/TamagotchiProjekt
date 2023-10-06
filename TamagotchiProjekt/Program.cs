
Tamagotchi intern = new();

Console.WriteLine("What is your unpaid interns name?");
intern.name = Console.ReadLine().ToLower();
if (intern.name.Length >= 2) //if string has enough characters for command below
{
    intern.name = char.ToUpper(intern.name[0]) + intern.name.Substring(1); //Capitalize first letter then add rest of string
}

while (intern.GetAlive())
{
    Console.WriteLine("\nWhat do you wish to do now? \nTeach your unpaid intern a new word [type: teach] \nGreet your unpaid intern [type: greet] \nFeed your unpaid intern [type: feed] \nDo nothing [don't type the above]");
    string action = Console.ReadLine().ToLower();
    Console.WriteLine();

    if (action == "teach")
    {
        intern.Teach();
    }
    else if (action == "greet")
    {
        intern.Hi();
    }
    else if (action == "feed")
    {
        intern.Feed();
    }
    else
    {
        Console.WriteLine("You did nothing.");
    }
    intern.Tick();
    intern.PrintStats();
}

Console.WriteLine("End");
Console.ReadLine();