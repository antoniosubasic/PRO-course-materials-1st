#region Constants
const string ALPHABET = "abcdefghijklmnopqrstuvwxyz";
const string ENCRYPT = "e";
const string DECRYPT = "d";
#endregion

#region Main Program
{
    string option;
    bool inputIsValid;
    do
    {
        Console.Write($"Encrypt or Decrypt? ({ENCRYPT}/{DECRYPT}): ");
        option = Console.ReadLine()!.ToLower();

        inputIsValid = option is DECRYPT or ENCRYPT;
        if (!inputIsValid) { Console.WriteLine("Invalid input. Try again..."); }
    } while (!inputIsValid);

    bool decrypt = option == DECRYPT;

    Console.Write("\nYour input: ");
    string input = Console.ReadLine()!;

    Console.Write("Enter a keyword: ");
    string keyword = GetKeyword(input);

    Console.WriteLine();
    Console.Write(decrypt ? "Decrypted" : "Encrypted");
    Console.WriteLine($" output: {Cryptograph(input, keyword, decrypt)}");
}
#endregion

#region Methods
string GetKeyword(string input)
{
    string keyword = Console.ReadLine()!;

    string output = "";
    int nonLettersFound = 0;
    for (int i = 0; i < input.Length; i++)
    {
        char inputChar = input[i];
        char outputChar = keyword[(i - nonLettersFound) % keyword.Length];

        if (!char.IsLetter(inputChar)) { nonLettersFound++; outputChar = inputChar; }

        output += outputChar;
    }

    return output;
}

string Cryptograph(string input, string keyword, bool decrypt)
{
    string output = "";

    for (int i = 0; i < input.Length; i++)
    {
        char outputChar;

        if (!char.IsLetter(input[i])) { outputChar = input[i]; }
        else
        {
            int inputCharIndex = ALPHABET.IndexOf(char.ToLower(input[i]));
            int offset = ALPHABET.IndexOf(char.ToLower(keyword[i])) * (decrypt ? -1 : 1);

            outputChar = ALPHABET[(ALPHABET.Length + inputCharIndex + offset) % ALPHABET.Length];
        }
        
        output += char.IsUpper(input[i]) ? char.ToUpper(outputChar) : outputChar;
    }

    return output;
}
#endregion