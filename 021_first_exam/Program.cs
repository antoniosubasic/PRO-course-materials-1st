#region Constants
const int GAME_WINS_NEEDED_SHORT = 1;
const int GAME_WINS_NEEDED_REGULAR = 4;
const int GAME_WINS_NEEDED_DOUBLE = 3;

const string PLAYER1 = "1";
const string PLAYER2 = "2";
const string QUIT = "q";

const string SHORT = "short";
const string REGULAR = "regular";
const string DOUBLE = "double";
const string CUSTOM = "custom";

const string GAME_WIN_MESSAGE = "Player {0} has won the game\n";
const string MATCH_WIN_MESSAGE = "Congratulations, player {0}, you have won the match!";
#endregion

int player1_points = 0, player2_points = 0, player1_game_wins = 0, player2_game_wins = 0;
int game_wins_needed;

Console.WriteLine($"Which type of match do you want to play ({SHORT}, {REGULAR}, {DOUBLE}, {CUSTOM}): ");
string match_type = Console.ReadLine()!;

switch (match_type)
{
    case SHORT: game_wins_needed = GAME_WINS_NEEDED_SHORT; break;
    case REGULAR: game_wins_needed = GAME_WINS_NEEDED_REGULAR; break;
    case DOUBLE: game_wins_needed = GAME_WINS_NEEDED_DOUBLE; break;
    case CUSTOM:
        bool valid_game_wins_needed;
        do
        {
            Console.WriteLine("Enter the number of wins a player needs to become match winner (0 - 10, must be odd): ");
            game_wins_needed = int.Parse(Console.ReadLine()!);
            valid_game_wins_needed = !(game_wins_needed > 0 && game_wins_needed < 10 && game_wins_needed % 2 != 0);
            if (valid_game_wins_needed) { Console.WriteLine("You must enter an odd number between 0 and 10"); }
        } while (valid_game_wins_needed);
        break;
    default:
        Console.WriteLine("You must enter a match type");
        return;
}

int current_service = Random.Shared.Next(1, 3);
bool valid_points_input = true;
do
{
    int sum = player1_points + player2_points;
    if (sum % 2 == 0 && sum != 0 && valid_points_input) { if (current_service == 1) { current_service++; } else { current_service--; } }
    Console.WriteLine($"Player {current_service} has serivce");
    Console.WriteLine($"Who has won the point (Player [{PLAYER1}], Player [{PLAYER2}], [{QUIT}]uit): ");
    switch (Console.ReadLine()!)
    {
        case PLAYER1: player1_points++; valid_points_input = true; break;
        case PLAYER2: player2_points++; valid_points_input = true; break;
        case QUIT: return;
        default: Console.WriteLine($"You must enter {PLAYER1} or {PLAYER2} or {QUIT}"); valid_points_input = false; break;
    }

    if (player1_points >= 11 || player2_points >= 11)
    {
        if (player1_points >= 11) { Console.WriteLine(GAME_WIN_MESSAGE, PLAYER1); player1_game_wins++; } else { Console.WriteLine(GAME_WIN_MESSAGE, PLAYER2); player2_game_wins++; }
        player1_points = 0;
        player2_points = 0;
        current_service = Random.Shared.Next(1, 3);
    }

    Console.WriteLine($"Games: {player1_game_wins}:{player2_game_wins}, Points: {player1_points}:{player2_points}");
} while (player1_game_wins < game_wins_needed && player2_game_wins < game_wins_needed);

if (player1_game_wins != 0 && player1_game_wins >= game_wins_needed) { Console.WriteLine(MATCH_WIN_MESSAGE, PLAYER1); } else { Console.WriteLine(MATCH_WIN_MESSAGE, PLAYER2); }