Console.OutputEncoding = System.Text.Encoding.Default;

const string WIN_WITH_BLACKJACK = " with blackjack";

decimal moneyPlayer = 100m;
int round = 1;

int cardValuesPlayer = 0, cardValuesComputer = 0;
int numberOfCardsPlayer = 2, numberOfCardsComputer = 0;
int playerAces = 0, computerAces = 0;

void PrintWelcome()
{
    Console.WriteLine("*** WELCOME TO BLACKJACK ***\n");
    Console.WriteLine($"You have {moneyPlayer}€ in your pocket. Try to double it!");
    Console.WriteLine("You will lose if you have no money left");
}

void PlayRound()
{
    Console.WriteLine($"\n*** Round {round}, you have {moneyPlayer}€ left.\n");

    cardValuesPlayer += HandoutAndPrintRandomCard();

    int bet = AskForBet();

    cardValuesPlayer += HandoutAndPrintRandomCard();

    bool lessThan21 = cardValuesPlayer < 21;
    string input = "y";
    while (input != "n" && lessThan21)
    {
        Console.Write("Do you want another card? (y/n): ");
        input = Console.ReadLine()!.ToLower();

        if (input == "y") { cardValuesPlayer += HandoutAndPrintRandomCard(); numberOfCardsPlayer++; }
        else if (input != "n") { Console.WriteLine("Invalid input"); }
        lessThan21 = cardValuesPlayer < 21;
    }

    if (cardValuesPlayer < 21 || cardValuesPlayer == 21 && numberOfCardsPlayer > 2)
    {
        Console.WriteLine("Dealers turn...");
        while (cardValuesComputer < 17)
        {
            cardValuesComputer += HandoutAndPrintRandomCard("Dealer"); numberOfCardsComputer++;
        }
    }

    PrintWinner(bet);
}

int HandoutAndPrintRandomCard(string currentTurn = "You")
{
    bool playersTurn = currentTurn == "You";
    int cardsCurrentValue = playersTurn ? cardValuesPlayer : cardValuesComputer;

    int cardValue = Random.Shared.Next(2, 12);
    int cardsTotalValue = cardsCurrentValue + cardValue;

    Console.Write(currentTurn + " " + (playersTurn ? "have" : "has"));
    PrintCard(cardValue);

    if (cardValue == 11)
    {
        if (playersTurn) { playerAces++; }
        else { computerAces++; }
    }

    if (cardsTotalValue > 21)
    {
        if (playersTurn && playerAces > 0) { cardValue = 1; playerAces--; }
        else if (!playersTurn && computerAces > 0) { cardValue = 1; computerAces--; }
        cardsTotalValue = cardsCurrentValue + cardValue;
    }

    Console.WriteLine($"{cardsTotalValue}.");

    return cardValue;
}

void PrintCard(int cardValue)
{
    string card = cardValue switch
    {
        10 => Random.Shared.Next(1, 5) switch
            {
                1 => "10",
                2 => "Jack",
                3 => "Queen",
                _ => "King"
            },
        11 => "Ace",
        _ => cardValue.ToString()
    };

    Console.Write($" {card}, hand value is ");
}

int AskForBet()
{
    Console.Write($"How much do you want to bet? Bet must be >= 10€ and <= {moneyPlayer}€ (Press Enter for minimal bet): ");
    string input = Console.ReadLine()!;

    if (int.TryParse(input, out int bet))
    {
        if (bet >= 10 && bet <= moneyPlayer) { return bet; }
        else { Console.WriteLine("Invalid input - minimal bet automatically selected"); }
    }
    return 10;
}

void PrintWinner(int bet)
{
    bool playerWins = cardValuesPlayer <= 21, computerWins = cardValuesComputer <= 21;
    if (playerWins && computerWins)
    {
        playerWins = cardValuesPlayer > cardValuesComputer || cardValuesPlayer == 21 && numberOfCardsPlayer == 2;
        computerWins = cardValuesComputer > cardValuesPlayer || cardValuesComputer == 21 && numberOfCardsComputer == 2;
    }

    if (playerWins)
    {
        Console.Write("You win");
        if (numberOfCardsPlayer == 2) { moneyPlayer += bet * 1.5m; Console.Write(WIN_WITH_BLACKJACK); }
        else { moneyPlayer += bet; }
        Console.WriteLine("!");
    }
    else if (computerWins)
    {
        Console.Write("Dealer wins");
        moneyPlayer -= bet;
        if (numberOfCardsComputer == 2) { Console.Write(WIN_WITH_BLACKJACK); }
        Console.WriteLine("!");
    }
    else { Console.WriteLine("Standoff!"); }
}

void ResetVariables()
{
    cardValuesPlayer = cardValuesComputer = playerAces = computerAces = numberOfCardsComputer = 0;
    numberOfCardsPlayer = 2;
}

Console.Clear();
PrintWelcome();
do
{
    PlayRound();
    ResetVariables();
    round++;
} while (moneyPlayer >= 10 && moneyPlayer < 200);

Console.WriteLine($"\nYou left with {moneyPlayer}€");