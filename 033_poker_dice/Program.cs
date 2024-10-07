#region Constants
const string HAND1 = "Five of a kind";
const string HAND2 = "Four of a kind";
const string HAND3 = "Full House";
const string HAND4 = "Straight";
const string HAND5 = "Three of a kind";
const string HAND6 = "Two pairs";
const string HAND7 = "One pair";
const string HAND8 = "Bust";
#endregion

int player1Hand = 0, player2Hand = 0;
int dice1 = 0, dice2 = 0, dice3 = 0, dice4 = 0, dice5 = 0;
bool fixed1 = false, fixed2 = false, fixed3 = false, fixed4 = false, fixed5 = false;

for (int i = 0; i < 2; i++) { PlayGame(i + 1); }
DetermineWinner();

void PlayGame(int player)
{
    Console.WriteLine($"PLAYER {player}:");
    Console.WriteLine("=========");
    fixed1 = fixed2 = fixed3 = fixed4 = fixed5 = false;
    for (int i = 0; i < 3 && !(fixed1 && fixed2 && fixed3 && fixed4 && fixed5); i++)
    {
        RollDice();
        Console.Write($"Dice Roll #{i + 1} (out of 3): ");
        SortDice();
        PrintDice();

        if (i != 2) { Console.WriteLine("Which dice do you want to fix/unfix? (1 - 5, or 'r' to roll the dice)"); FixDice(); }
        Console.WriteLine("---");
    }

    AnalyzeAndPrintResult(player);
    Console.WriteLine();
}

void RollDice()
{
    dice1 = fixed1 ? dice1 : Random.Shared.Next(1, 7);
    dice2 = fixed2 ? dice2 : Random.Shared.Next(1, 7);
    dice3 = fixed3 ? dice3 : Random.Shared.Next(1, 7);
    dice4 = fixed4 ? dice4 : Random.Shared.Next(1, 7);
    dice5 = fixed5 ? dice5 : Random.Shared.Next(1, 7);
}

void SortDice()
{
    bool somethingChanged;
    do
    {
        somethingChanged = false;

        if (dice1 > dice2) { somethingChanged = true; (dice1, dice2) = (dice2, dice1); }
        if (dice2 > dice3) { somethingChanged = true; (dice2, dice3) = (dice3, dice2); }
        if (dice3 > dice4) { somethingChanged = true; (dice3, dice4) = (dice4, dice3); }
        if (dice4 > dice5) { somethingChanged = true; (dice4, dice5) = (dice5, dice4); }
    } while (somethingChanged);
}

void PrintDice()
{
    Console.WriteLine($"{dice1}, {dice2}, {dice3}, {dice4}, {dice5}");
}

void FixDice()
{
    fixed1 = fixed2 = fixed3 = fixed4 = fixed5 = false;

    while (true)
    {
        string keyInput = Console.ReadLine()!;
        switch (keyInput)
        {
            case "1": fixed1 = !fixed1; break;
            case "2": fixed2 = !fixed2; break;
            case "3": fixed3 = !fixed3; break;
            case "4": fixed4 = !fixed4; break;
            case "5": fixed5 = !fixed5; break;
            case "r": return;
            default:
                Console.WriteLine("You must enter a dice number (1 - 5) or 'r' to roll again");
                break;
        }

        string fixedDice = "Fixed: ";
        fixedDice += fixed1 ? "1 " : "";
        fixedDice += fixed2 ? "2 " : "";
        fixedDice += fixed3 ? "3 " : "";
        fixedDice += fixed4 ? "4 " : "";
        fixedDice += fixed5 ? "5" : "";
        Console.WriteLine(fixedDice);
    }
}

void AnalyzeAndPrintResult(int player)
{
    string hand = "";
    int[] repetitions = new int[] { dice1, dice2, dice3, dice4, dice5 };

    if (dice1 == dice5) { hand = HAND1; }
    else if (dice1 == dice4 || dice2 == dice5) { hand = HAND2; }
    else if (dice1 == dice3 && dice4 == dice5 || dice3 == dice5 && dice1 == dice2) { hand = HAND3; }
    else if (CheckIfStraight(repetitions)) { hand = HAND4; }
    else if (dice1 == dice3 || dice2 == dice4 || dice3 == dice5) { hand = HAND5; }
    else if (CheckIfHasNPairs(repetitions, 2)) { hand = HAND6; }
    else if (CheckIfHasNPairs(repetitions, 1)) { hand = HAND7; }
    else { hand = HAND8; }

    Console.WriteLine(hand);

    if (player == 1) { player1Hand = GetPointsBasedOnHand(hand); } else { player2Hand = GetPointsBasedOnHand(hand); }
}

bool CheckIfStraight(int[] repetitions)
{
    for (int i = 0; i < repetitions.Length; i++)
    {
        if (repetitions[0] + i != repetitions[i]) { return false; }
    }

    return true;
}

bool CheckIfHasNPairs(int[] repetitions, int pairs)
{
    int pairsFound = 0;
    for (int i = 0; i < repetitions.Length - 1; i++)
    {
        if (repetitions[i] == repetitions[i + 1]) { pairsFound++; i++; }
    }

    return pairsFound >= pairs;
}

int GetPointsBasedOnHand(string hand) => hand switch { HAND1 => 1, HAND2 => 2, HAND3 => 3, HAND4 => 4, HAND5 => 5, HAND6 => 6, HAND7 => 7, _ => 8 };

void DetermineWinner()
{
    Console.WriteLine(player1Hand == player2Hand ? "It's a draw!" : "Player " + (player1Hand < player2Hand ? "1" : "2") + " wins!");
}