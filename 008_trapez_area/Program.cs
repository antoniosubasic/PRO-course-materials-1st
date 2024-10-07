// bare Program
{
    Console.Clear();

    Console.Write("Enter a: ");
    int a = int.Parse(Console.ReadLine()!);

    Console.Write("Enter c: ");
    int c = int.Parse(Console.ReadLine()!);

    Console.Write("Enter h: ");
    int h = int.Parse(Console.ReadLine()!);

    double area = (a + c) * h / 2d;

    Console.WriteLine("The area is: " + area);

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
}



// ascii art
{
    Console.Clear();

    string trapez = @"
            c
     ______________
    /|             \
   / |              \
  /  | h             \
 /   |                \
/____|_________________\
            a
";
    Console.WriteLine(trapez);

    Console.Write("\n\nEnter a: ");
    int a = int.Parse(Console.ReadLine()!);

    Console.Write("Enter c: ");
    int c = int.Parse(Console.ReadLine()!);

    Console.Write("Enter h: ");
    int h = int.Parse(Console.ReadLine()!);

    double area = (a + c) * h / 2d;

    Console.WriteLine("The area is: " + area);
}