Console.Clear();

Console.Write("Please type in your name: ");
string name = Console.ReadLine()!;

Console.WriteLine("\nHi " + name + ", how old are you?");
int age = int.Parse(Console.ReadLine()!);

Console.WriteLine("\nHey " + name + ", you are " + age + " years old.");