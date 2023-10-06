
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
        List<string> food = new() {"2an apple", "0an old sock", "3half a hamburger", "1a single french fry", "1paper towels", "4a live pig", "0pocket lint", "0a food coupon", "5six pizzas", "2a loaf of bread"}; //list of possible food
        int index = generator.Next(food.Count); //get one food from list
        int.TryParse(food[index][0].ToString(), out int foodIndex); //get the first character from food, which is how much hunger it satisfies, and convert to int
        Console.WriteLine($"You gave {name} {food[index].Substring(1)} and {name} ate it like they haven't eaten in 8 years.");
        hunger -= foodIndex; 
    }

    public void Hi()
    {
        if (words.Count > 0)
        {
            int index = generator.Next(words.Count); //get one word from list
            Console.WriteLine($"{name} says {words[index]}.");
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
        Console.WriteLine($"You taught {name} the word: {word}.");
    }

    public void Tick()
    {
        hunger++;
        boredom++;

        if (hunger > 10 || boredom > 10)
        {
            isAlive = false;
        }
        if (hunger < 0)
        {
            hunger = 0;
        }
        if (boredom < 0)
        {
            boredom = 0;
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
            if (hunger > 10 && boredom > 10)
            {
                Console.WriteLine($"{name} died from starvation and boredom, lol.");
            }
            else if (hunger > 10)
            {
                Console.WriteLine($"{name} died from starvation, lol.");
            }
            else if (boredom > 10)
            {
                Console.WriteLine($"{name} died from boredom, lol.");
            }
        }
    }

    public bool GetAlive()
    {
        return isAlive;
    }

    void ReduceBoredom()
    {
        boredom -= 2;
    }
}
