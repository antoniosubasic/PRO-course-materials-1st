#region Main Program
string input;
bool quit;
do
{
    Console.Write("Enter a number: ");
    input = Console.ReadLine()!.ToLower();
    quit = input is "q" or "quit";
    bool inputIsValid = int.TryParse(input, out int number) || quit;

    if (!inputIsValid) { Console.WriteLine("Invalid input. Try again..."); }
    else if (!quit)
    {
        Console.Write("Number in words: ");
        if (number < 0) { Console.Write("minus"); number *= -1; }
        Console.WriteLine(NineDigitNumberToLongText(number));
    }
} while (!quit);
#endregion

string OneDigitNumberToLongText(int number)
{
    return number switch
    {
        0 => "zero",
        1 => "one",
        2 => "two",
        3 => "three",
        4 => "four",
        5 => "five",
        6 => "six",
        7 => "seven",
        8 => "eight",
        9 => "nine",
        _ => "not valid"
    };
}

string TwoDigitNumberToLongText(int number)
{
    int firstDigit = number / 10;
    int lastDigit = number % 10;

    string output = "";
    switch (firstDigit)
    {
        case 0: return OneDigitNumberToLongText(number);
        case 1:
            output = number switch
            {
                10 => "ten",
                11 => "eleven",
                12 => "twelve",
                13 => "thir",
                15 => "fif",
                18 => "eigh",
                _ => OneDigitNumberToLongText(lastDigit)
            };
            break;
        case 2: output = "twen"; break;
        case 3: output = "thir"; break;
        case 5: output = "fif"; break;
        case 8: output = "eigh"; break;
        default: output = OneDigitNumberToLongText(firstDigit); break;
    }

    if (number > 12 && number < 20) { output += "teen"; }
    else if (number > 19) { output += "ty"; }

    if (lastDigit != 0 && number > 19) { output += OneDigitNumberToLongText(lastDigit); }

    return output;
}

string ThreeDigitNumberToLongText(int number)
{
    int firstDigit = number / 100;

    string output;
    if (firstDigit == 0) { return TwoDigitNumberToLongText(number); }
    else { output = $"{OneDigitNumberToLongText(firstDigit)}hundred{TwoDigitNumberToLongText(number % 100)}"; }

    output = RemoveZeroFromEnd(output);

    return output;
}

string NineDigitNumberToLongText(int number)
{
    int millions = number / 1_000_000;
    int thousands = (number / 1_000) % 1_000;
    int hundreds = number % 1_000;

    string millionsOutput = ThreeDigitNumberToLongText(millions);
    string thousandsOutput = ThreeDigitNumberToLongText(thousands);
    string hundredsOutput = ThreeDigitNumberToLongText(hundreds);

    if (hundredsOutput != "zero") { hundredsOutput = RemoveZeroFromEnd(hundredsOutput); }

    string output = "";
    if (millionsOutput != "zero") { output += $"{millionsOutput}million"; }
    if (thousandsOutput != "zero") { output += $"{thousandsOutput}thousand"; }
    if (hundredsOutput != "zero" || output == "") { output += hundredsOutput; }

    return output;
}

string RemoveZeroFromEnd(string input)
{
    int lastIndexOfZero = input.LastIndexOf("zero");
    return input != "zero" && lastIndexOfZero >= 0 && lastIndexOfZero == input.Length - 4 ? input.Substring(0, input.Length - 4) : input;
}