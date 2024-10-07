#region Constants
const string TOO_FEW_ARGUMENTS = "Too few arguments";
const string TOO_MANY_ARGUMENTS = "Too many arguments";
const string INVALID_COMMAND = "Invalid command, must be \"build\" or \"analyze\"";
const string INVALID_ARGUMENT_LENGTH = "{0} has wrong length, must contain {1} digits";
const string INVALID_ARGUMENT = "{0} must be a positive integer";
const string INVALID_COUNTRY_CODE = "Wrong country code, we currently only support \"NO\"";
const string INVALID_NATIONAL_DIGIT = "Wrong national check digit, we currently only support \"7\"";
const string INVALID_IBAN_LENGTH = "Wrong length of IBAN";
#endregion

#region Main Program
{
    if (args.Length < 2) { Console.WriteLine(TOO_FEW_ARGUMENTS); }
    else
    {
        bool commandIsValid = args[0] is "build" or "analyze";
        bool build = args[0] == "build";
        bool inputIsValid = commandIsValid;

        if (!commandIsValid) { PrintError(INVALID_COMMAND, ref inputIsValid); }
        else if (build)
        {
            if (args.Length < 3) { PrintError(TOO_FEW_ARGUMENTS, ref inputIsValid); }
            else if (args.Length > 3) { PrintError(TOO_MANY_ARGUMENTS, ref inputIsValid); }
            else
            {
                if (!uint.TryParse(args[1], out _)) { PrintError(string.Format(INVALID_ARGUMENT, "Bank code"), ref inputIsValid); }
                if (args[1].Length != 4) { PrintError(string.Format(INVALID_ARGUMENT_LENGTH, "Bank code", 4), ref inputIsValid); }

                if (!uint.TryParse(args[2], out _)) { PrintError(string.Format(INVALID_ARGUMENT, "Account Number"), ref inputIsValid); }
                if (args[2].Length != 6) { PrintError(string.Format(INVALID_ARGUMENT_LENGTH, "Accout Number", 6), ref inputIsValid); }
            }
        }
        else
        {
            if (args.Length < 2) { PrintError(TOO_FEW_ARGUMENTS, ref inputIsValid); }
            else if (args.Length > 2) { PrintError(TOO_MANY_ARGUMENTS, ref inputIsValid); }
            else
            {
                if (args[1].Length != 15) { PrintError(INVALID_IBAN_LENGTH, ref inputIsValid); }
                if (!args[1].StartsWith("NO")) { PrintError(INVALID_COUNTRY_CODE, ref inputIsValid); }
                if (!args[1].EndsWith('7')) { PrintError(INVALID_NATIONAL_DIGIT, ref inputIsValid); }
            }
        }

        if (inputIsValid)
        {
            if (build)
            {
                uint bankCode = uint.Parse(args[1]);
                uint accountNumber = uint.Parse(args[2]);
                Console.WriteLine(BuildIban("NO", bankCode, accountNumber, 7));
            }
            else
            {
                (string countryCode, uint checksum, uint bankCode, uint accountNumber, uint nationalCheckDigit) = AnalyzeIban(args[1]);
                
                bool checksumVerified = Checksum(new uint[]
                    {
                        bankCode,
                        accountNumber,
                        nationalCheckDigit,
                        GetNumberOfCountryCode(countryCode)
                    }, checksum) != 1;

                Console.WriteLine(string.Format("Checksum {0} be verified\n", checksumVerified ? "could" : "couldn't"));
                Console.WriteLine($"Bank code is {bankCode}");
                Console.WriteLine($"Account number is {accountNumber}");
            }
        }
    }
}
#endregion

#region Methods
void PrintError(string message, ref bool inputIsValid)
{
    inputIsValid = false;
    Console.WriteLine(message);
}

string BuildIban(string countryCode, uint bankCode, uint accountNumber, uint nationalCheckDigit)
{
    uint checksum = 98 - Checksum(new uint[]
            {
                bankCode,
                accountNumber,
                nationalCheckDigit,
                (uint)((uint)(countryCode[0] % 'A' + 10) * MoveDecimal(2) + (uint)(countryCode[1] % 'A' + 10))
            });

    return $"{countryCode}{checksum.ToString().PadLeft(2, '0')}{bankCode.ToString().PadLeft(4, '0')}{accountNumber.ToString().PadLeft(6, '0')}{nationalCheckDigit}";
}

(string, uint, uint, uint, uint) AnalyzeIban(string iban)
{
    string countryCode = iban.Substring(0, 2);
    uint checksum = uint.Parse(iban.Substring(2, 2));
    uint bankCode = uint.Parse(iban.Substring(4, 4));
    uint accountNumber = uint.Parse(iban.Substring(8, 6));
    uint nationalCheckDigit = uint.Parse(iban[^1].ToString());

    return (countryCode, checksum, bankCode, accountNumber, nationalCheckDigit);
}

uint Checksum(uint[] numbers, uint checksum = 0)
{
    ulong result = numbers[0] % 97;

    for (int i = 1; i < numbers.Length; i++)
    {
        result *= MoveDecimal(numbers[i].ToString().Length);
        result += numbers[i];
        result %= 97;
    }

    return (uint)((result * MoveDecimal(2) + (ulong)checksum) % 97);
}

uint GetNumberOfCountryCode(string countryCode) => (uint)((uint)(countryCode[0] % 'A' + 10) * MoveDecimal(2) + (uint)(countryCode[1] % 'A' + 10));

ulong MoveDecimal(int decimalPlaces) => (ulong)Math.Pow(10, decimalPlaces);
#endregion
