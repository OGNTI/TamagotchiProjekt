
List<Tamagotchi> Interns = new List<Tamagotchi>();
int internIndex = 0;
bool gaming = false;

Console.WriteLine("Do you wish to hire a new unpaid intern? [Yes/No]");
string input = Console.ReadLine().ToLower();

if (input == "yes")
{
    HireIntern();
    gaming = true;
}
else
{
    Console.WriteLine("You did not want to hire a unpaid intern.");
    Console.ReadLine();
    Environment.Exit(0);
}

while (gaming)
{
    Console.Clear();
    foreach (Tamagotchi i in Interns)
    {
        i.firstRound = false;
    }

    if (!Interns[internIndex].GetAlive())
    {
        Console.WriteLine($"You are supervising {Interns[internIndex].name} but {Interns[internIndex].name} is fucking dead, who do you want to supervise instead?");
        ChangeIntern();
    }
    else
    {
        Console.WriteLine($"You are supervising {Interns[internIndex].name}. \n\nWhat do you wish to do now? \nTeach your unpaid intern a new word [type: teach] \nGreet your unpaid intern [type: greet] \nFeed your unpaid intern [type: feed] \n\nHire a new unpaid intern [type: hire] \nChange which unpaid intern you are supervising [type: change] \n\nDo nothing [don't type the above]");
        string action = Console.ReadLine().ToLower();
        Console.WriteLine();

        if (action == "teach")
        {
            Interns[internIndex].Teach();
        }
        else if (action == "greet")
        {
            Interns[internIndex].Hi();
        }
        else if (action == "feed")
        {
            Interns[internIndex].Feed();
        }
        else if (action == "hire")
        {
            HireIntern();
        }
        else if (action == "change")
        {
            Console.WriteLine($"Which intern do you wish to supervise next?");
            ChangeIntern();
        }
        else
        {
            Console.WriteLine("You did nothing.");
        }
        foreach (Tamagotchi i in Interns)
        {
            i.Tick();
            i.PrintStats();
            gaming = false;
            if (i.GetAlive())
            {
                gaming = true;
            }
        }

    }
    Console.WriteLine("\nPress Enter to continue.");
    Console.ReadLine();
}

Console.WriteLine("All of your unpaid interns died, lol. \nAs you now have a 100% death ratio, no more people want to be hired by you and a police investigaion is started to find out what the fuck you did with the interns.");
Console.ReadLine();


void HireIntern()
{
    Console.WriteLine("What is your new unpaid interns name?");
    string nameInput = Console.ReadLine();
    bool exists = false;
    foreach (Tamagotchi i in Interns)
    {
        if (i.nameID == nameInput)
        {
            exists = true;
        }
    }

    if (exists)
    {
        Console.WriteLine("\nYou already have an unpaid intern with that name, the universe does not allow multiple interns with he same name.");
    }
    else
    {
        Interns.Add(new Tamagotchi());
        internIndex = Interns.Count - 1;
        Interns[internIndex].Name(nameInput);
        Interns[internIndex].firstRound = true;
    }
}

void ChangeIntern()
{
    foreach (Tamagotchi i in Interns)
    {
        string alive = "";
        if (!i.GetAlive())
        {
            alive = "[dead]";
        }
        Console.WriteLine($"- {i.name} {alive}");
    }
    input = Console.ReadLine().ToLower();
    for (int i = 0; i < Interns.Count; i++)
    {
        if (Interns[i].nameID == input)
        {
            internIndex = i;
        }
    }
}