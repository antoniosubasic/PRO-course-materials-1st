Console.Clear();

Console.Write("Enter the radius of the ball: ");
int radius = int.Parse(Console.ReadLine()!);
double ball = 4d / 3 * Math.PI * Math.Pow(radius, 3);

Console.WriteLine("The volume of your ball is: " + ball);