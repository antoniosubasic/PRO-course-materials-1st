const int ROCK = 1;
const int PAPER = 2;
const int SCISSORS = 3;
const int LIZARD = 4;
const int SPOCK = 5;

const int DRAW = 0;
const int PLAYER1_WINS = 1;
const int PLAYER2_WINS = 2;

const string POSSIBILITIES = "Player {0}, choose rock (1), paper (2), scissors (3), lizard (4), spock (5): ";

Console.WriteLine(POSSIBILITIES, "1");
int player1 = int.Parse(Console.ReadLine()!);

Console.WriteLine(POSSIBILITIES, "2");
int player2 = int.Parse(Console.ReadLine()!);

int winner = DRAW;

switch (player1)
{
    case ROCK:
        switch (player2)
        {
            case PAPER:
                winner = PLAYER2_WINS;
                break;

            case SCISSORS:
                winner = PLAYER1_WINS;
                break;

            case LIZARD:
                winner = PLAYER1_WINS;
                break;

            case SPOCK:
                winner = PLAYER2_WINS;
                break;

            default:
                break;
        }
        break;

    case PAPER:
        switch (player2)
        {
            case ROCK:
                winner = PLAYER1_WINS;
                break;

            case SCISSORS:
                winner = PLAYER2_WINS;
                break;

            case LIZARD:
                winner = PLAYER2_WINS;
                break;

            case SPOCK:
                winner = PLAYER1_WINS;
                break;

            default:
                break;
        }
        break;

    case SCISSORS:
        switch (player2)
        {
            case ROCK:
                winner = PLAYER2_WINS;
                break;

            case PAPER:
                winner = PLAYER1_WINS;
                break;

            case LIZARD:
                winner = PLAYER1_WINS;
                break;

            case SPOCK:
                winner = PLAYER2_WINS;
                break;

            default:
                break;
        }
        break;

    case LIZARD:
        switch (player2)
        {
            case ROCK:
                winner = PLAYER2_WINS;
                break;

            case PAPER:
                winner = PLAYER1_WINS;
                break;

            case SCISSORS:
                winner = PLAYER2_WINS;
                break;

            case SPOCK:
                winner = PLAYER1_WINS;
                break;

            default:
                break;
        }
        break;

    case SPOCK:
        switch (player2)
        {
            case ROCK:
                winner = PLAYER1_WINS;
                break;

            case PAPER:
                winner = PLAYER2_WINS;
                break;

            case SCISSORS:
                winner = PLAYER1_WINS;
                break;

            case LIZARD:
                winner = PLAYER2_WINS;
                break;

            default:
                break;
        }
        break;

    default:
        break;
}

if (winner == DRAW) { Console.WriteLine("\nNo winner, repeat the game"); }
else { Console.WriteLine("\nPlayer " + winner + " wins"); }