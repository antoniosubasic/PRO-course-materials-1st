#region Constants
const int DECIMAL_PLACES = 2;
const string FIRST = "first";
const string SECOND = "second";
#endregion

double firstOperand = LetUserEnterOperand(FIRST);
double secondOperand = LetUserEnterOperand(SECOND);

Console.Write("Enter the result: ");
double result = double.Parse(Console.ReadLine()!);

string operand = "+";
if (firstOperand + secondOperand == result) { PrintTerm(FIRST); }

operand = "-";
if (firstOperand - secondOperand == result) { PrintTerm(FIRST); }
if (secondOperand - firstOperand == result) { PrintTerm(SECOND); }

operand = "*";
if (firstOperand * secondOperand == result) { PrintTerm(FIRST); }

operand = "/";
if (Math.Round(firstOperand / secondOperand, DECIMAL_PLACES) == result) { PrintTerm(FIRST); }
if (Math.Round(secondOperand / firstOperand, DECIMAL_PLACES) == result) { PrintTerm(SECOND); }

operand = "^";
if (Math.Pow(firstOperand, secondOperand) == result) { PrintTerm(FIRST); }
if (Math.Pow(secondOperand, firstOperand) == result && firstOperand != secondOperand) { PrintTerm(SECOND); }

operand = "%";
if (firstOperand % secondOperand == result) { PrintTerm(FIRST); }
if (secondOperand % firstOperand == result) { PrintTerm(SECOND); }

double LetUserEnterOperand(string nthOperand)
{
    Console.Write($"Enter the {nthOperand} operand: ");
    return double.Parse(Console.ReadLine()!);
}

void PrintTerm(string firstOrSecond)
{
    Console.WriteLine();
    bool first = firstOrSecond == "first";
    Console.Write(first ? firstOperand : secondOperand);
    Console.Write($" {operand} ");
    Console.Write(first ? secondOperand : firstOperand);
    Console.Write($" = {result}");
}