
public class Tamagotchi
{
    int hunger;
    int boredom;
    List<string> words = new();
    bool isAlive = true;
    Random generator = new();
    public string name;

    public void Feed()
    {
        hunger -= 2;
        if (hunger < 0)
        {
            hunger = 0;
        }
        Console.WriteLine($"You fed {name}.");
    }

    public void Hi()
    {
        if (words.Count > 0)
        {
            int index = generator.Next(words.Count);
            Console.WriteLine($"{words[index]}");
            ReduceBoredom();
        }
        else 
        {
            Console.WriteLine($"{name} does not know any words to greet you with so {name} just gives you the finger."); 
        }
    }

    public void Teach()
    {
        Console.WriteLine($"What word do you wish to teach {name}?");
        string word = Console.ReadLine();
        words.Add(word);
        ReduceBoredom();
        Console.WriteLine($"You taught your unpaid intern the word: {word}.");
    }

    public void Tick()
    {
        hunger++;
        boredom++;

        if (hunger > 10 || boredom > 10)
        {
            isAlive = false;
        }
    }

    public void PrintStats()
    {
        Console.WriteLine($"\nHunger: {hunger}\nBoredom: {boredom}");
        if (isAlive == true)
        {
            Console.WriteLine($"{name} is alive.");
        }
        else
        {
            Console.WriteLine($"{name} is dead, lol.");
        }
    }

    public bool GetAlive()
    {
        return isAlive;
    }

    void ReduceBoredom()
    {
        boredom -= 2;
        if (boredom < 0)
        {
            boredom = 0;
        }
    }
}
