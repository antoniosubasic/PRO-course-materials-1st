#region Constants
const string ENTER_DIRECTION_MESSAGE = "Enter a direction (n for North, e for East, s for South, w for West, q if all movements were entered): ";
const string ENTER_DIRECTION_WARNING = "You must enter one of these characters: n, e, s, w, q";
const string ENTER_DISTANCE_MESSAGE = "Enter the distance you have to go: ";
const string ENTER_DISTANCE_WARNING = "You must enter a positive float";
const string NORTH = "n";
const string SOUTH = "s";
const string EAST = "e";
const string WEST = "w";
const string QUIT = "q";
#endregion

double vertical_distance = 0;
double horizontal_distance = 0;
double total_distance = 0;
string direction;
double distance;

do
{
    bool inputIsValid;
    do
    {
        Console.WriteLine(ENTER_DIRECTION_MESSAGE);
        direction = Console.ReadLine()!;

        inputIsValid = !(direction is NORTH or SOUTH or EAST or WEST or QUIT);
        if (inputIsValid) { Console.WriteLine(ENTER_DIRECTION_WARNING); }
    } while (inputIsValid);

    if (direction != QUIT)
    {
        do
        {
            Console.WriteLine(ENTER_DISTANCE_MESSAGE);
            distance = double.Parse(Console.ReadLine()!);

            inputIsValid = !(distance > 0);
            if (inputIsValid) { Console.WriteLine(ENTER_DISTANCE_WARNING); }
        } while (inputIsValid);

        total_distance += distance;

        if (direction is SOUTH or WEST) { distance *= -1; }
        if (direction is NORTH or SOUTH) { vertical_distance += distance; } else { horizontal_distance += distance; }
    }
    Console.WriteLine();
}
while (direction != QUIT);


string vertical_direction;
string horizontal_direction;

if (vertical_distance < 0)
{
    vertical_distance *= -1;
    vertical_direction = "South";
}
else { vertical_direction = "North"; }

if (horizontal_distance < 0)
{
    horizontal_distance *= -1;
    horizontal_direction = "West";
}
else { horizontal_direction = "East"; }

Console.Write("You have to go ");

if (vertical_distance != 0) { Console.Write(vertical_distance + "km " + vertical_direction); }
if (horizontal_distance != 0) { Console.Write(" and " + horizontal_distance + "km " + horizontal_direction); }

Console.WriteLine();
Console.Write($"You saved {total_distance - Math.Abs(vertical_distance) - Math.Abs(horizontal_distance)}km of walking");