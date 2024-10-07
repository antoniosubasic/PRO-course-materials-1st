Console.Clear();

Console.Write("Enter the radius of your circle: ");
int radius = int.Parse(Console.ReadLine()!);

Console.WriteLine("The area of your circle is: " + Math.PI * Math.Pow(radius, 2));