#region Main Program
{
    string creditCardNumber = string.Join("", string.Join("", args).Where(c => char.IsDigit(c)));

    if (creditCardNumber.Length == 16)
    {
        if (ValidateCreditCardNumber(creditCardNumber))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("valid");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("invalid");
        }
    }
    else { Console.WriteLine("The credit card number must have a length of 16"); }

    Console.ResetColor();
}
#endregion

#region Methods
int GetDigitSum(int number)
{
    int sum = 0;
    for (int i = 0; i < number.ToString().Length; i++)
    {
        sum += number / (int)Math.Pow(10, i) % 10;
    }

    return sum < 10 ? sum : GetDigitSum(sum);
}

bool ValidateCreditCardNumber(string creditCardNumber)
{
    int result = 0;
    for (int i = 0; i < creditCardNumber.Length - 1; i++)
    {
        result += GetDigitSum(int.Parse(creditCardNumber[i].ToString()) * (2 - (i % 2)));
    }

    return 10 - result % 10 == int.Parse(creditCardNumber[^1].ToString());
}
#endregion