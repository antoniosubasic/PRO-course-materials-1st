Console.OutputEncoding = System.Text.Encoding.Default;

decimal moneyPlayer = 100m;
int round = 1;

void PlayRound()
{
    Console.WriteLine($"*** Round {round}");
    Console.WriteLine($"Your balance: {moneyPlayer}€");

    if (moneyPlayer < 190) { moneyPlayer += AskForMoreMoney(); }
    int bet = AskForBet();
    string symbols = GetAndPrintSymbols();
    AddOrSubtractMoney(symbols, bet);
}

int AskForMoreMoney()
{
    decimal upperLimit = 199 - moneyPlayer;
    Console.Write($"How much money do you want to add to your balance (10€ - {upperLimit}€, press any key for no money OR invalid input results in no money): ");
    string input = Console.ReadLine()!;

    if (int.TryParse(input, out int moneyToAdd) && moneyToAdd >= 10 && moneyToAdd <= upperLimit) { return moneyToAdd; }
    else { return 0; }
}

int AskForBet()
{
    Console.Write($"Your bet (10€ - {moneyPlayer}€, press any key for minimal bet OR invalid input results in minimal bet): ");
    string input = Console.ReadLine()!;

    if (int.TryParse(input, out int bet) && bet >= 10 && bet <= moneyPlayer) { return bet; }
    else { return 10; }
}

string GetAndPrintSymbols()
{
    string symbols = "";

    for (int i = 0; i < 4; i++)
    {
        int randomSymbolNumber = Random.Shared.Next(1, 7);
        symbols += randomSymbolNumber.ToString();

        string symbol = randomSymbolNumber switch
        {
            1 => "💵",
            2 => "⭐",
            3 => "🍉",
            4 => "🍊",
            5 => "🍒",
            _ => "🍎"
        };

        Console.Write(symbol);
    }

    return symbols;
}

void AddOrSubtractMoney(string symbols, int bet)
{
    int GetDigitOfStringNumber(int digit) => int.Parse(symbols.Substring(digit - 1, 1));

    int firstDigit = GetDigitOfStringNumber(1);
    int secondDigit = GetDigitOfStringNumber(2);
    int thirdDigit = GetDigitOfStringNumber(3);
    int fourthDigit = GetDigitOfStringNumber(4);

    bool somethingChanged;
    do
    {
        somethingChanged = false;
        if (firstDigit > secondDigit) { (secondDigit, firstDigit) = (firstDigit, secondDigit); somethingChanged = true; }
        if (secondDigit > thirdDigit) { (thirdDigit, secondDigit) = (secondDigit, thirdDigit); somethingChanged = true; }
        if (thirdDigit > fourthDigit) { (fourthDigit, thirdDigit) = (thirdDigit, fourthDigit); somethingChanged = true; }
    } while (somethingChanged);


    int symbolsEqual = 0;
    if (firstDigit == fourthDigit) { symbolsEqual = 4; }
    else if (firstDigit == thirdDigit || secondDigit == fourthDigit) { symbolsEqual = 3; }
    else if (firstDigit == secondDigit || secondDigit == thirdDigit || thirdDigit == fourthDigit) { symbolsEqual = 2; }


    if (symbolsEqual == 0) { moneyPlayer -= bet; }
    else
    {
        bool jackpot = symbolsEqual == 4 && firstDigit == 1;

        if (jackpot) { Console.WriteLine("\n\n🌟🌟🌟 JACKPOT 🌟🌟🌟"); }
        moneyPlayer += bet * (jackpot ? 10 : symbolsEqual - 1);
    }
}

do
{
    PlayRound();
    round++;

    Console.WriteLine("\n");
} while (moneyPlayer >= 10 && moneyPlayer < 200);

Console.Write("You left with ");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"{moneyPlayer}€");
Console.ResetColor();