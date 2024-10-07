Console.Write("Enter the size of the flat: ");
int size = int.Parse(Console.ReadLine()!);

Console.Write("Enter the number of bedrooms: ");
int numberOfBedrooms = int.Parse(Console.ReadLine()!);

Console.Write("Enter whether the flat has a balcony or a patio (1 for balcony, 2 for patio, 3 for none, 4 for both): ");
int balconyBedroom = int.Parse(Console.ReadLine()!);

if (size >= 100 && numberOfBedrooms >= 2 && balconyBedroom != 3)
{
    Console.WriteLine("\nThis flat fulfills all requirements");
}
else
{
    Console.WriteLine("\nUnfortunately, this flat doesn't fulfill all requirements");
}