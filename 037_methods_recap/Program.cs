string greeting = "Hello ";
int greetingCounter = 0;
string name = "Tom";

Console.WriteLine("Wohin möchten Sie fahren? 1 für Links und 2 für Rechts: ");
int selectedMenuItem = GetNumber(1, 2);

Console.WriteLine("Was möchsten Sie essen? 1 für Apfel, 2 für Banane und 3 für Birne: ");
int selectedFood = GetNumber(1, 3);

int min = 5;
int max = 10;
Console.WriteLine("Geben Sie eine Zahl zwischen 5 und 10 ein: ");
GetNumber(min, max);

// Methodenaufruf
SayHello();
Console.WriteLine(name);

// Methodendefinition
void SayHello()
{
    string name = "Max";

    Console.WriteLine(greeting + name);
    greetingCounter++;
}

// Ask user for input of a number. The number must be between 1 or 2.
// Store the result in selectedMenuItem
int GetNumber(int min, int max)
{
    bool isValid;
    int number;
    do
    {
        number = int.Parse(Console.ReadLine()!);
        isValid = number >= min && number <= max;
        if (!isValid) { Console.WriteLine($"Invalid input - input must be between {min} and {max}"); }
    } while (!isValid);
    return number;
}

// Write a method that receives a number and returns true if the number is even, otherwise false
bool IsEven(int number) => number % 2 == 0;
Console.WriteLine(IsEven(2));
Console.WriteLine(IsEven(3));

string myName = "Antonio";
string myGreeting = GenerateGreeting(myName);
Console.WriteLine(myGreeting);

Console.WriteLine(GenerateGreeting("Antonio"));

// Write a method that receives a name as parameter and returns a greeing in the form of "Hello <name>".
string GenerateGreeting(string name) => $"Hello {name}";

var randomCard = Random.Shared.Next(1, 14);
Console.WriteLine($"You have a {GetCardName(randomCard)}");

// Write a method that receives a number between 1 and 13.
// It has to return "Ace" for 1, "2" for 2, "3" for 3, ...
// "Jack" for 11, "Queen" for 12, "King" for 13
string GetCardName(int number)
{
    return number switch
    {
        1 => "Ace",
        11 => "Jack",
        12 => "Queen",
        13 => "King",
        _ => number.ToString()
    };
}