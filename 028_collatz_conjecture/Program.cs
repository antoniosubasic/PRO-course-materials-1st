Console.Write("Enter a number: ");
int n = int.Parse(Console.ReadLine()!);

while (n > 1)
{
    Console.Write(n + " ");
    n = n % 2 == 0 ? n / 2 : 3 * n + 1;
}

Console.Write(1);