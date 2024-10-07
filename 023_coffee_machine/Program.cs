Console.OutputEncoding = System.Text.Encoding.Default;

#region Constants
const string MONEYFED = "Please enter the amount of money 💵 that you fed into the machine (multiple of 0.5€): ";
const string NOTENOUGHMONEY = "Sorry, you do not have enough credit 😔";
const string REMAINING_MONEY_BEGIN = "You get ";
const string REMAINING_MONEY_MIDDLE = " x ";
const string REMAINING_MONEY_END = " pieces";

const string CAPPUCCINO = "1";
const decimal CAPPUCCINO_PRICE = 3.5m;
const string TEA = "2";
const decimal TEA_PRICE = 1.5m;
const string CACAO = "3";
const decimal CACAO_PRICE = 2.5m;
const string NOTHING = "4";

const System.ConsoleColor GREETING_FAREWELL_COLOR = ConsoleColor.DarkGreen;
const System.ConsoleColor DEFAULT_COLOR = ConsoleColor.White;
const System.ConsoleColor MONEY_COLOR = ConsoleColor.Yellow;
const System.ConsoleColor PIECES_COLOR = ConsoleColor.Blue;
#endregion

// greeting
{
    Console.ForegroundColor = GREETING_FAREWELL_COLOR;
    Console.WriteLine("======================================================"); Console.Write("========== ");
    Console.ForegroundColor = DEFAULT_COLOR;

    Console.Write("Welcome to the coffee machine ☕");

    Console.ForegroundColor = GREETING_FAREWELL_COLOR;
    Console.WriteLine(" =========="); Console.WriteLine("======================================================\n");
    Console.ForegroundColor = DEFAULT_COLOR;
}

// asking for money fed
Console.Write(MONEYFED);
decimal money = decimal.Parse(Console.ReadLine()!);
while (money % 0.5m != 0)
{
    Console.WriteLine("Amount of money must be multiple of 0.5€❗");
    Console.Write(MONEYFED);
    money = decimal.Parse(Console.ReadLine()!);
}

decimal originalMoney = money;
for (int i = 0; i < 20; i++) { Console.Write("#"); }
Console.WriteLine();

// checking if enough money is available
bool enoughMoney = money >= TEA_PRICE;
if (!enoughMoney) { Console.WriteLine(NOTENOUGHMONEY); }

// asking for product
string selectedProduct = "";
while (selectedProduct != NOTHING && enoughMoney)
{
    Console.WriteLine("Which product would you like to buy? 🤔");
    Console.WriteLine($"[{CAPPUCCINO}] Cappuccino (3.5€), [{TEA}] Tea (1.5€), [{CACAO}] Cacao (2.5€), [{NOTHING}] Nothing else");
    selectedProduct = Console.ReadLine()!;

    switch (selectedProduct)
    {
        case CAPPUCCINO:
            if (money < CAPPUCCINO_PRICE) { Console.WriteLine(NOTENOUGHMONEY); }
            else { money -= CAPPUCCINO_PRICE; }
            break;
        case TEA:
            if (money < TEA_PRICE) { Console.WriteLine(NOTENOUGHMONEY); }
            else { money -= TEA_PRICE; }
            break;
        case CACAO:
            if (money < CACAO_PRICE) { Console.WriteLine(NOTENOUGHMONEY); }
            else { money -= CACAO_PRICE; }
            break;
        case NOTHING: break;
        default:
            Console.WriteLine($"You must enter {CAPPUCCINO} or {TEA} or {CACAO} or {NOTHING}❗");
            break;
    }

    // print percentage
    Console.WriteLine();
    decimal barsMoneyLeft = (100 * money) / originalMoney / 5;
    for (int i = 0; i < barsMoneyLeft; i++) { Console.Write("#"); }
    for (decimal i = barsMoneyLeft; i < 20; i++) { Console.Write("."); }
    Console.WriteLine();

    // checking if enough money is available
    enoughMoney = money >= TEA_PRICE;
    if (!enoughMoney) { Console.WriteLine(NOTENOUGHMONEY); }

}

// remaining money
{
    // print remaining money
    {
        Console.Write("\nYou get ");
        Console.ForegroundColor = MONEY_COLOR;
        Console.Write($"{money}€");
        Console.ForegroundColor = DEFAULT_COLOR;
        Console.WriteLine(" back");
    }

    // calculate pieces
    int two_euro_coins = (int)(money / 2);
    money -= two_euro_coins * 2;

    int one_euro_coins = (int)money;
    money -= one_euro_coins;

    int fifty_cent_coins = (int)(money * 2);

    // print pieces
    if (two_euro_coins != 0)
    {
        Console.Write(REMAINING_MONEY_BEGIN);

        {
            Console.ForegroundColor = PIECES_COLOR;
            Console.Write(two_euro_coins);
            Console.ForegroundColor = DEFAULT_COLOR;
        }

        Console.Write(REMAINING_MONEY_MIDDLE);

        {
            Console.ForegroundColor = MONEY_COLOR;
            Console.Write("2€");
            Console.ForegroundColor = DEFAULT_COLOR;
        }

        Console.WriteLine(REMAINING_MONEY_END);
    }
    if (one_euro_coins != 0)
    {
        Console.Write(REMAINING_MONEY_BEGIN);

        {
            Console.ForegroundColor = PIECES_COLOR;
            Console.Write(one_euro_coins);
            Console.ForegroundColor = DEFAULT_COLOR;
        }

        Console.Write(REMAINING_MONEY_MIDDLE);

        {
            Console.ForegroundColor = MONEY_COLOR;
            Console.Write("1€");
            Console.ForegroundColor = DEFAULT_COLOR;
        }

        Console.WriteLine(REMAINING_MONEY_END);
    }
    if (fifty_cent_coins != 0)
    {
        Console.Write(REMAINING_MONEY_BEGIN);

        {
            Console.ForegroundColor = PIECES_COLOR;
            Console.Write(fifty_cent_coins);
            Console.ForegroundColor = DEFAULT_COLOR;
        }

        Console.Write(REMAINING_MONEY_MIDDLE);

        {
            Console.ForegroundColor = MONEY_COLOR;
            Console.Write("0.5€");
            Console.ForegroundColor = DEFAULT_COLOR;
        }

        Console.WriteLine(REMAINING_MONEY_END);
    }
}

// farewell
{
    Console.ForegroundColor = GREETING_FAREWELL_COLOR;
    Console.WriteLine("\n======================================================="); Console.Write("===================== ");
    Console.ForegroundColor = DEFAULT_COLOR;

    Console.Write("Goodbye! 👋");

    Console.ForegroundColor = GREETING_FAREWELL_COLOR;
    Console.WriteLine(" ====================="); Console.WriteLine("=======================================================");
    Console.ForegroundColor = DEFAULT_COLOR;
}