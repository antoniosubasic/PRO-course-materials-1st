//going for gold

//defining variables
int value;
int gold = 0;
Console.Write("Enter how much ore you gathered: ");
int ore = int.Parse(Console.ReadLine()!);

//first rule
value = Math.Min(ore, 10);
gold += value * 10;
ore -= value;

//second rule
value = Math.Min(ore, 5);
gold += value * 5;
ore -= value;

//third rule
value = Math.Min(ore, 3);
gold += value * 2;
ore -= value;

//fourth rule
gold += ore;

Console.WriteLine("You get " + gold + " gold coins");