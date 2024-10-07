// Ask the user for three integer numbers a, b, c.
// Each number must be > 0 and < 100.
int input = 0;

Console.Write("Please enter a: ");
LetUserEnterNumber();
int a = input;

// Print a spereation line consisting of 100 = characters between a - b and b - c
PrintSeperationLine();

Console.Write("Please enter b: ");
LetUserEnterNumber();
int b = input;

PrintSeperationLine();

Console.Write("Please enter c: ");
LetUserEnterNumber();
int c = input;

PrintSeperationLine();

void LetUserEnterNumber()
{
    do
    {
        input = int.Parse(Console.ReadLine()!);
        if (input <= 0 || input >= 100) { Console.WriteLine("Invalid"); }
    } while (input <= 0 || input >= 100);
}

void PrintSeperationLine()
{
    for (int i = 0; i < 100; i++) { Console.Write("="); }
    Console.WriteLine();
}