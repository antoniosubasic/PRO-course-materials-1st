int n = LetUserEnterNumber("first");
int firstNumber = n;

int o = LetUserEnterNumber("second");
int secondNumber = o;

int lengthFirstNumber = 1;
int lengthSecondNumber = 1;
while (n > 1 || o > 1)
{
    if (n > 1) { lengthFirstNumber++; n = GetNextNumberOfHailstoneSequence(n); }
    if (o > 1) { lengthSecondNumber++; o = GetNextNumberOfHailstoneSequence(o); }
}

Console.WriteLine();
if (lengthFirstNumber == lengthSecondNumber) { Console.WriteLine("The length of the Hailstone sequence of these two numbers is the same"); }
else { Console.WriteLine("The number {0} has the longer Hailstone sequence", lengthFirstNumber > lengthSecondNumber ? firstNumber : secondNumber); }

int LetUserEnterNumber(string nthNumber)
{
    Console.Write($"Enter the {nthNumber} number: ");
    return int.Parse(Console.ReadLine()!);
}

int GetNextNumberOfHailstoneSequence(int currentNumber)
{
    return currentNumber % 2 == 0 ? currentNumber / 2 : 3 * currentNumber + 1;
}