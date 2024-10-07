const int ROCK = 1;
const int PAPER = 2;
const int SCISSORS = 3;
const int LIZARD = 4;
const int SPOCK = 5;

const int DRAW = 0;
const int PLAYER1_WINS = 1;
const int PLAYER2_WINS = 2;

const string POSSIBILITIES = ", choose rock (1), paper (2), scissors (3), lizard (4), spock (5): ";

Console.WriteLine("Player 1" + POSSIBILITIES);
int player1 = int.Parse(Console.ReadLine()!);
Console.WriteLine("Player 2" + POSSIBILITIES);
int player2 = int.Parse(Console.ReadLine()!);
int winner = DRAW;

if (player1 == ROCK)
{
    if (player2 == PAPER) { winner = PLAYER2_WINS; }
    else if (player2 == SCISSORS) { winner = PLAYER1_WINS; }
    else if (player2 == LIZARD) { winner = PLAYER1_WINS; }
    else if (player2 == SPOCK) { winner = PLAYER2_WINS; }
}

else if (player1 == PAPER)
{
    if (player2 == ROCK) { winner = PLAYER1_WINS; }
    else if (player2 == SCISSORS) { winner = PLAYER2_WINS; }
    else if (player2 == LIZARD) { winner = PLAYER2_WINS; }
    else if (player2 == SPOCK) { winner = PLAYER1_WINS; }
}

else if (player1 == SCISSORS)
{
    if (player2 == ROCK) { winner = PLAYER2_WINS; }
    else if (player2 == PAPER) { winner = PLAYER1_WINS; }
    else if (player2 == LIZARD) { winner = PLAYER1_WINS; }
    else if (player2 == SPOCK) { winner = PLAYER2_WINS; }
}

else if (player1 == LIZARD)
{
    if (player2 == ROCK) { winner = PLAYER2_WINS; }
    else if (player2 == PAPER) { winner = PLAYER1_WINS; }
    else if (player2 == SCISSORS) { winner = PLAYER2_WINS; }
    else if (player2 == SPOCK) { winner = PLAYER1_WINS; }
}

else if (player1 == SPOCK)
{
    if (player2 == ROCK) { winner = PLAYER1_WINS; }
    else if (player2 == PAPER) { winner = PLAYER2_WINS; }
    else if (player2 == SCISSORS) { winner = PLAYER1_WINS; }
    else if (player2 == LIZARD) { winner = PLAYER2_WINS; }
}

if (winner == DRAW) { Console.WriteLine("No winner, repeat the game"); }
else { Console.WriteLine("Player " + winner + " wins"); }