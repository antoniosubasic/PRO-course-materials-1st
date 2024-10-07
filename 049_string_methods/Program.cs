#region Main Program
{
    char firstChar = GetCharFromUser("Char for \"IndexOf\":\t");
    char secondChar = GetCharFromUser("Char for \"Trim\":\t");

    do
    {
        Console.Write("String: ");
        string input = Console.ReadLine()!;
        if (Trim(input, ' ') == string.Empty) { break; }

        string MethodCallMessage(char c) => $"(\"{input}\", '{c}') = ";

        Console.WriteLine($"IndexOf{MethodCallMessage(firstChar)}{IndexOf(input, firstChar)}");
        Console.WriteLine($"LastIndexOf{MethodCallMessage(firstChar)}{LastIndexOf(input, firstChar)}");
        Console.WriteLine($"Contains{MethodCallMessage(firstChar)}{Contains(input, firstChar)}");

        Console.WriteLine($"TrimStart{MethodCallMessage(secondChar)}\"{TrimStart(input, secondChar)}\"");
        Console.WriteLine($"TrimEnd{MethodCallMessage(secondChar)}\"{TrimEnd(input, secondChar)}\"");
        Console.WriteLine($"Trim{MethodCallMessage(secondChar)}\"{Trim(input, secondChar)}\"");
        Console.WriteLine($"Remove(\"{input}\", 2, 2) = \"{Remove(input, 2, 2)}\"");
    } while (true);
}
#endregion

#region Other Methods
char GetCharFromUser(string prompt)
{
    char character;
    bool inputIsValid;
    do
    {
        Console.Write(prompt);
        inputIsValid = char.TryParse(Console.ReadLine()!, out character);

        if (!inputIsValid) { Console.WriteLine("Input invalid. Try again..."); }
    } while (!inputIsValid);

    return character;
}
#endregion

#region String Methods
bool Contains(string input, char searchChar)
{
    for (int i = 0; i < input.Length / 2 + 1; i++)
    {
        if (input[i] == searchChar || input[^(i + 1)] == searchChar) { return true; }
    }

    return false;
}

int IndexOf(string input, char searchChar)
{
    for (int i = 0; i < input.Length; i++)
    {
        if (input[i] == searchChar) { return i; }
    }

    return -1;
}

int LastIndexOf(string input, char searchChar)
{
    for (int i = 0; i < input.Length; i++)
    {
        if (input[^(i + 1)] == searchChar) { return input.Length - i - 1; }
    }

    return -1;
}

string TrimStart(string input, char trimChar)
{
    int start = 0;
    foreach (var c in input)
    {
        if (input[start] == trimChar) { start++; }
        else { break; }
    }

    return SubString(input, start, input.Length);
}

string TrimEnd(string input, char trimChar)
{
    int end = input.Length - 1;
    foreach (var c in input)
    {
        if (input[end] == trimChar) { end--; }
        else { break; }
    }

    return SubString(input, 0, end + 1);
}

string Trim(string input, char trimChar)
{
    return TrimEnd(TrimStart(input, trimChar), trimChar);
}

string SubString(string input, int start, int length)
{
    string output = "";
    for (int i = start; i < start + length && i < input.Length; i++) { output += input[i]; }

    return output;
}

string Remove(string input, int start, int length)
{
    string output = "";
    for (int i = 0; i < input.Length; i++)
    {
        if (!(i >= start && i < start + length)) { output += input[i]; }
    }

    return output;
}
#endregion