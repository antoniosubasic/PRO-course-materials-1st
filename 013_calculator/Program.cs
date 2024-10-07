const string askForNumber = "Please enter the {0} number: ";
const string result = "The result is: ";
double value;

Console.Write(askForNumber, "first");
double firstNumber = double.Parse(Console.ReadLine()!);

Console.Write(askForNumber, "second");
double secondNumber = double.Parse(Console.ReadLine()!);

Console.Write("Please enter the operation [ +  -  *  / ]: ");
string operation = Console.ReadLine()!;

switch (operation)
{
    case "+":
        value = firstNumber + secondNumber;
        break;

    case "-":
        value = firstNumber - secondNumber;
        break;

    case "*":
        value = firstNumber * secondNumber;
        break;

    case "/":
        value = firstNumber / secondNumber;
        break;

    default:
        Console.WriteLine("You must enter an operation");
        return;
}

Console.WriteLine("\n" + result + value);