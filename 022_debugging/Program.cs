// Frage Benutzer um eine Zahl
// Gib alle Zahlen zwischen 0 und der eingegebenen
// Zahl am Bildschirm aus

Console.Write("Enter a number: ");
int upperBound = int.Parse(Console.ReadLine()!);

for (int i = 0; i <= upperBound; i++) { Console.WriteLine(i); }

Console.Write("\nGoodbye!");