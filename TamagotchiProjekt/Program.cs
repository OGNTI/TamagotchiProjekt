
Tamagotchi intern = new();

Console.WriteLine("What is your unpaid interns name?");
intern.name = Console.ReadLine();

while (intern.GetAlive())
{
    Console.WriteLine("\nWhat do you wish to do now? \nTeach your unpaid intern a new word [type: teach] \nGreet your unpaid intern [type: greet] \nFeed your unpaid intern [type: feed] \nDo nothing [don't type the above]");
    string action = Console.ReadLine().ToLower(); 
    Console.WriteLine();

    if (action == "teach")
    {
        intern.Teach();
        intern.Tick();
    }
    else if (action == "greet")
    {
        intern.Hi();
        intern.Tick();
    }
    else if (action == "feed")
    {
        intern.Feed();
        intern.Tick();
    }
    else
    {
        intern.Tick();
        Console.WriteLine("You did nothing.");
    }
    intern.PrintStats();
}

Console.WriteLine("End");
Console.ReadLine();