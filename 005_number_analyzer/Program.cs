Console.Clear();

Console.Write("Please enter a number: ");
int number = int.Parse(Console.ReadLine()!);

int remainder = number % 2;
bool isEvenNumber = remainder == 0;
Console.WriteLine("\nIt is " + isEvenNumber + " that the number is even.");

bool isGreaterThanFive = number > 5;
Console.WriteLine("It is " + isGreaterThanFive + " that the number is greater than 5.");

number++;
Console.WriteLine("The next number is " + number);