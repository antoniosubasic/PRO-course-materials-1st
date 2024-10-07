//* ref (reference) parameter
int x = 1;

Incremeant(ref x);

void Incremeant(ref int a)
{
    a++;
}

Console.WriteLine(x);


//? ==============================================================


//* out (special reference) parameter
Console.WriteLine();

GenerateTwoRandomNumbers(out int r1, out int r2);
Console.WriteLine(r1 + " " + r2);

void GenerateTwoRandomNumbers(out int a, out int b)
{
    a = Random.Shared.Next(100);
    b = Random.Shared.Next(100);
}


//? ==============================================================


//* examples

//! 1
Console.WriteLine();

Console.Write("Please enter a number: ");
string input = Console.ReadLine()!;
// int inputNumber = int.Parse(input);
if (int.TryParse(input, out int inputNumber))
{
    Console.WriteLine(inputNumber);
}
else
{
    Console.WriteLine("you messed up!");
}

//! 2
Console.WriteLine();

if (TryDivide(10, 0, out int result))
{
    // Divide was successful
    Console.WriteLine(result);
}
else
{
    Console.WriteLine("Cannot divide");
}

int Divide(int a, int b)
{
    return a / b;
}

bool TryDivide(int a, int b, out int result)
{
    if (b == 0)
    {
        result = 0;
        return false;
    }

    result = a / b;
    return true;
}