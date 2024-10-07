Console.Clear();

Console.Write("Enter the length: ");
int length = int.Parse(Console.ReadLine()!);

Console.Write("Enter the width: ");
int width = int.Parse(Console.ReadLine()!);

Console.Write("Enter the height: ");
int height = int.Parse(Console.ReadLine()!);

Console.WriteLine("The volume is: " + length * width * height);