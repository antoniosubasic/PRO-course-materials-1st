int number1 = 999, number2 = 999;
int largestPalindrom = 0, largestPalindromOperand1 = 0, largestPalindromOperand2 = 0;

for (int i = 1; i <= number1; i++)
{
    for (int j = 1; j <= number2; j++)
    {
        int number = i * j;
        int originalNumber = number;

        int numberLength = 1;
        while (number % 10 != number) { numberLength++; number /= 10; }
        number = originalNumber;

        int numberReversed = 0;
        for (int k = 1; k <= numberLength; k++)
        {
            numberReversed += (number % 10) * (int)Math.Pow(10, numberLength - k);
            number /= 10;
        }

        if (originalNumber == numberReversed && originalNumber > largestPalindrom) { largestPalindrom = originalNumber; largestPalindromOperand1 = i; largestPalindromOperand2 = j; }
    }
}

Console.WriteLine($"The largest palindrom is {largestPalindrom} ({largestPalindromOperand1} * {largestPalindromOperand2})");