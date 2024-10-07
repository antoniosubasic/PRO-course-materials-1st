#region Constants
const string GREATER_LESS_EQUAL_MESSAGE = "Is your number [g]reater, [l]ess or [e]qual (type 'exit' to exit the game): ";
#endregion

int tries = 1;
int lower_bound = 1;
int upper_bound = 1001;
string greater_less_equal;

do
{
    int guessed_number = Random.Shared.Next(lower_bound, upper_bound);
    Console.WriteLine("My guess is: " + guessed_number);

    Console.Write(GREATER_LESS_EQUAL_MESSAGE);
    greater_less_equal = Console.ReadLine()!;
    while (greater_less_equal != "g" && greater_less_equal != "l" && greater_less_equal != "e" && greater_less_equal != "exit")
    {
        Console.Write(GREATER_LESS_EQUAL_MESSAGE);
        greater_less_equal = Console.ReadLine()!;
    }

    switch (greater_less_equal)
    {
        case "g":
            lower_bound = guessed_number + 1;
            break;
        case "l":
            upper_bound = guessed_number;
            break;
        case "e":
            Console.Write("\nI have found the number within " + tries + " ");
            if (tries == 1) { Console.Write("try."); } else { Console.Write("tries."); }
            return;
        default:
            break;
    }

    if (lower_bound >= upper_bound) { Console.WriteLine("You are cheating!"); return; }

    tries++;
}
while (greater_less_equal != "exit");

Console.WriteLine("Exiting the game...");