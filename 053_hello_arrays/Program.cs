Console.Write("How many numbers do you want to enter: ");
var count = int.Parse(Console.ReadLine()!);
var numbers = new int[count];

for (var i = 0; i < count; i++)
{
    Console.Write($"Please enter the {i + 1}. number: ");
    numbers[i] = int.Parse(Console.ReadLine()!);
}

Console.WriteLine(numbers);
foreach (var number in numbers) { Console.WriteLine(number); }

var fibonacci = new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 };
