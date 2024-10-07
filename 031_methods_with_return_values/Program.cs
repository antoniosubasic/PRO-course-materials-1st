// Ask user for width and height of a rectangle
// Calculate area of rectangle (width * height) IN A SPERATE METHOD
// Repeat

int width, height;

while (true)
{
    Console.Write("\nEnter the width of the rectangle: ");
    width = LetUserEnterNumber();

    Console.Write("Enter the height of the rectangle: ");
    height = LetUserEnterNumber();

    int area = CalculateArea();
    Console.WriteLine($"The are of the rectangle is: {area}");
}

int CalculateArea()
{
    return width * height;
}

int LetUserEnterNumber()
{
    int input;
    do { input = int.Parse(Console.ReadLine()!); } while (input <= 0);
    return input;
}