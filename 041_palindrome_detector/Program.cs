// TODO: 1. Ask the user for a string input
// TODO: 2. Check if input is a palindrome
// TODO: 3. Print a message indicating whether the input is a palindrome or not

Console.Write("Enter a text to check if it is a palindrome: ");
string input = Console.ReadLine()!;

Console.Write("The text is");
if (!IsPalindrome(input)) { Console.Write(" not"); }
Console.Write(" a Palindrome");

bool IsPalindrome(string text)
{
    if (text.Length == 0) { return false; }
    
    text = text
        .Replace(" ", "")
        .Replace(",", "")
        .Replace("-", "")
        .ToLower();

    for (int i = 0; i < text.Length / 2; i++)
    {
        if (text[i] != text[^(i + 1)])
        {
            return false;
        }
    }

    return true;
}