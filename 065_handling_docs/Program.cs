// Write a method that searches a given substring in a longer substring.
// It must return the numer of occurrences.

// When Adam saw Eve, he said: "Hello". Eve said Hello back.
// Hello -> 2

var input = "When Adam saw Eve, he said: \"Hello\". Eve said Hello back.";

// https://learn.microsoft.com/en-us/dotnet/api/system.string.indexof?view=net-7.0
var occurrences = 0;
var index = 0;
do
{
    index = input.IndexOf("hello", index, StringComparison.OrdinalIgnoreCase);
    if (index != -1) { occurrences++; }
} while (index++ != -1);

Console.WriteLine(occurrences);

// =========================================================

// https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getfiles?view=net-7.0
var files = Directory.GetFiles(@"C:\Users\anton\Dropbox\Schule\HTL\PRO\065_handling_docs", "*.cs", SearchOption.AllDirectories);
foreach (var file in files) { Console.WriteLine(file); }
