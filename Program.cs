
using static System.Net.Mime.MediaTypeNames;

Console.Title = "Hunting the Manticore";


int number = AskForNumberInRange("Player 1, how far away from the city do you want to station the Manticore? ", 0, 100);

Console.Clear();

int round = 1;
int city = 15;
int manticore = 10;
int damage = 1;


Console.WriteLine("Player 2, it is your turn.");

while (true)
{
    if (manticore <= 0)
        break;

    if (city <= 0) 
    {
        Console.WriteLine("The City has been destroyed! The city of Consolas is doomed...");
        Console.WriteLine("Do you want to try again? Press any key when you're ready.");
        Console.ReadKey(true);
        Console.Clear();
        city = 15;
        manticore = 10;
        round = 1;
        continue;
    }

    DisplayRows();

    Console.WriteLine($"STATUS:   Round: {round}   City: {city}/15   Manticore: {manticore}/10");

    damage = CannonDamage(round);

    int guess = AskForNumber("Enter desired cannon range: ");

    DisplayingCannonDamageTaken(guess);

    round++;

}
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
Console.ForegroundColor= ConsoleColor.White;






//METHODS


/// <summary>
/// Display a text, get respons from user, return only if entered number is between min and max value.
/// </summary>

int AskForNumberInRange(string text, int min, int max)
{
    while (true)
    {
        int number = AskForNumber(text);
        if (number >= min && number <= max)
            return number;
    }
}





///<summary>
///Display text, get respons from user, loop til right guess.
///</summary>

int AskForNumber(string text)
{
    bool input = false;
    int number = 0;

    Console.Write(text + " ");

    while (!input)
    {

        input = int.TryParse(Console.ReadLine(), out number);

        if (!input)
            Console.WriteLine("Guess a real number please.");

    }
    return number;
}


///<summary>
/// compute how much damage the cannon will deal this round. Displaying this to the player.
/// 10p if both 3 && 5 / 3p if 3 || 5 / 1p otherwise.
///</summary>

int CannonDamage(int i) 
    {

    int damage = 0;
    Console.Write("The cannon is expected to deal ");
    Console.ForegroundColor = ConsoleColor.Red;

    if (i % 3 == 0 && i % 5 == 0)
    {
        Console.Write("10 damage ");
        damage = 10;
    }

    else if (i % 3 == 0)
    {
        Console.Write("3 damage ");
        damage = 3;
    }

    else if (i % 5 == 0)
    {
        Console.Write("3 damage ");
        damage = 3;
    }

    else
    {
        Console.Write("1 damage ");
        damage = 1;
    }

    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("this round.");
    Console.WriteLine();
    
    return damage;
}




///<summary>
///Displaying "---" for separating the rounds
///</summary>
void DisplayRows() 
{
    int row = 100;

    for (int i = 1; i <= row; i++) 
    {
        Console.Write("-");
    }
    Console.WriteLine();
}




///<summary>
///Displaying how much Cannon damage was taken this round.
///</summary>
///

void DisplayingCannonDamageTaken(int guess) 
{
    Console.Write("That round ");
    if (guess > number)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("OVERSHOT ");

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("of the target.");
        city--;
    }
    else if (guess < number)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("FELL SHORT ");

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("of the target.");

        city--;
    }
    else if (guess == number)
    {
        Console.Write("was a ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("DIRECT HIT!");

        Console.ForegroundColor = ConsoleColor.White;

        manticore -= damage;
        city--;
    }
    Console.WriteLine();
}