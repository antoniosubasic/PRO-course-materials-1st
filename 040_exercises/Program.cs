string selection;
bool quitSelection;
do
{
    Console.Clear();
    Console.WriteLine("What do you want to execute?");
    Console.WriteLine("============================");
    Console.WriteLine();
    Console.WriteLine("0. Calculate Circle Area");
    Console.WriteLine("1. Random in Range");
    Console.WriteLine("2. To FizzBuzz");
    Console.WriteLine("3. Fibonacci by Index");
    Console.WriteLine("4. Ask for Number in Range");
    Console.WriteLine("5. Is palindrome?");
    Console.WriteLine("6. Is palindrome? (advanced)");
    Console.WriteLine("7. Chart Bar");
    Console.WriteLine("8. Count Smiling Faces");
    Console.WriteLine("9. Highest In Geometric Sequence");
    Console.WriteLine("q to Quit");
    selection = Console.ReadLine()!.ToLower();
    quitSelection = selection == "q";

    if (!quitSelection)
    {
        Console.Clear();
        switch (selection)
        {
            case "0": RunCalculateCircleArea(); break;
            // TODO: Add additional cases for other methods here
            case "1": RunRandomInRange(); break;
            case "2": RunFizzBuzz(); break;
            case "3": RunFibonaccyByIndex(); break;
            case "4": RunAskForNumberInRange(); break;
            case "5": RunIsPalindrome(); break;
            case "6": RunIsPalindromeAdvanced(); break;
            case "7": RunChartBar(); break;
            case "8": RunCountSmilingFaces(); break;
            case "9": RunHighestInGeometricSequence(); break;
            default: break;
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
while (!quitSelection);

// TODO: Create one code region for each level
#region Calculate Circle Area
void RunCalculateCircleArea()
{
    Console.Write("Enter radius:");
    var radius = double.Parse(Console.ReadLine()!);
    var area = CalculateCircleArea(radius);
    Console.WriteLine($"Area of circle with radius {radius} is {area}");
}

double CalculateCircleArea(double radius) => Math.Pow(radius, 2) * Math.PI;
#endregion

#region Random In Range
void RunRandomInRange()
{
    int zeroCount = 0;
    int oneCount = 0;
    int twoCount = 0;
    for (int i = 0; i < 1_000_000; i++)
    {
        switch (RandomInRange(0, 2))
        {
            case 0: zeroCount++; break;
            case 1: oneCount++; break;
            default: twoCount++; break;
        }
    }

    Console.WriteLine($"Zeros occured {zeroCount} times");
    Console.WriteLine($"Ones occured {oneCount} times");
    Console.WriteLine($"Twos occured {twoCount} times");
}

int RandomInRange(int min, int max) => Random.Shared.Next(min, max + 1);
#endregion

#region Fizz Buzz
void RunFizzBuzz()
{
    Console.Write("Enter the number: ");
    int number = int.Parse(Console.ReadLine()!);

    Console.WriteLine(FizzBuzz(number));
}

string FizzBuzz(int number)
{
    string fizzBuzz = number.ToString();
    if (number % 15 == 0) { fizzBuzz = "FizzBuzz"; }
    else if (number % 5 == 0) { fizzBuzz = "Buzz"; }
    else if (number % 3 == 0) { fizzBuzz = "Fizz"; }

    return fizzBuzz;
}
#endregion

#region Fibonacci By Index
void RunFibonaccyByIndex()
{
    Console.Write("Enter the number: ");
    int number = int.Parse(Console.ReadLine()!);

    Console.WriteLine($"The number is: {FibonacciByIndex(number)}");
}

ulong FibonacciByIndex(int number)
{
    ulong firstNumber = 0, secondNumber = 1;

    for (int i = 0; i < number; i++) { (firstNumber, secondNumber) = (secondNumber, firstNumber + secondNumber); }

    return firstNumber;
}
#endregion

#region Ask For Number In Range
void RunAskForNumberInRange()
{
    Console.WriteLine(AskForNumberInRange(5, 10));
    Console.WriteLine("Thank you, your input is valid!");
}

int AskForNumberInRange(int min, int max)
{
    int input;
    bool isValid;
    do
    {
        Console.Write($"Enter a value between {min} and {max}: ");
        input = int.Parse(Console.ReadLine()!);

        isValid = input >= min && input <= max;
        if (!isValid)
        {
            Console.Write($"Wrong number. Your input is too ");
            Console.Write(input < min ? $"low. The minimum is {min}" : $"high. The maximum is {max}");
            Console.WriteLine("Try again!");
        }
    } while (!isValid);

    return input;
}
#endregion

#region Is Palindrome
void RunIsPalindrome()
{
    Console.Write("Enter your word: ");
    string input = Console.ReadLine()!;

    Console.WriteLine(IsPalindrome(input));
}

bool IsPalindrome(string word)
{
    string wordReversed = "";
    for (int i = word.Length; i > 0; i--) { wordReversed += word[i - 1]; }

    return word == wordReversed;
}
#endregion

#region Is Palindrome Advanced
void RunIsPalindromeAdvanced()
{
    Console.Write("Enter your word: ");
    string input = Console.ReadLine()!.ToLower();

    Console.WriteLine(IsPalindromeAdvanced(input));
}

bool IsPalindromeAdvanced(string word)
{
    string replaceChars = " ,-";
    for (int i = 0; i < replaceChars.Length; i++)
    {
        word = word.Replace(replaceChars[i].ToString(), "");
    }

    string wordReversed = "";
    for (int i = word.Length; i > 0; i--) { wordReversed += word[i - 1]; }

    return word == wordReversed;
}
#endregion

#region Chart Bar
void RunChartBar()
{
    Console.Write("Enter your value: ");
    double input = double.Parse(Console.ReadLine()!);

    Console.WriteLine(ChartBar(input));
}

string ChartBar(double value)
{
    string chartBar = "";

    int numberOfBars = value > 1 ? 0 : (int)Math.Floor(value * 10);
    int numberOfDots = 10 - numberOfBars;
    for (int i = 0; i < numberOfBars; i++) { chartBar += "o"; }
    for (int i = 0; i < numberOfDots; i++) { chartBar += "."; }

    return chartBar;
}
#endregion

#region Count Smiling Faces
void RunCountSmilingFaces()
{
    Console.Write("Enter your text: ");
    string input = Console.ReadLine()!;

    Console.WriteLine($"Number of smiling faces: {CountSmilingFaces(input)}");
}

int CountSmilingFaces(string text)
{
    int smilingFaces = 0;

    for (int i = 0; i < text.Length - 2; i++)
    {
        if (text.Substring(i, 3) == ":-)") { smilingFaces++; }
    }

    return smilingFaces;
}
#endregion

#region Highest In Geometric Sequence
void RunHighestInGeometricSequence()
{
    Console.Write("Enter a: ");
    double a = double.Parse(Console.ReadLine()!);

    Console.Write("Enter r: ");
    double r = double.Parse(Console.ReadLine()!);

    Console.Write("Enter maximum: ");
    double max = double.Parse(Console.ReadLine()!);

    Console.WriteLine($"Highest element in geometric sequence: {HighestInGeometricSequence(a, r, max)}");
}

double HighestInGeometricSequence(double a, double r, double max)
{
    double currentSequenceValue;
    int i = 0;

    do
    {
        currentSequenceValue = a * Math.Pow(r, i);
        i++;
    } while (!(r >= 1 && currentSequenceValue >= max || r < 1 && currentSequenceValue <= max));

    if (currentSequenceValue > max) { currentSequenceValue = a * Math.Pow(r, i - 2); }

    return currentSequenceValue;
}
#endregion