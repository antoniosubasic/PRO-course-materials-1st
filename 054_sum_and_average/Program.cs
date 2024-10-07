// Benutzer fragen, wie viele Zahlen er eingeben will
// Alle Zahlen erfassen (in Array)
// Am Ende die Summe und den Durchschnitt ausgeben

Console.Write("How many numbers do you want to enter: ");
var count = int.Parse(Console.ReadLine()!);

var numbers = new int[count];
for (var i = 0; i < count; i++)
{
    Console.Write($"Please enter the {i + 1}. number: ");
    numbers[i] = int.Parse(Console.ReadLine()!);
}

Console.WriteLine(numbers.Sum());
Console.WriteLine(numbers.Average());
