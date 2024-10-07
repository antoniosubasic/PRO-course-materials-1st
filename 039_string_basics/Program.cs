Console.OutputEncoding = System.Text.Encoding.Unicode;

const string GREETING = "Hello World!";
Console.WriteLine(GREETING);

string helloInDifferentLanguages = "Hallo Welt!";
Console.WriteLine(helloInDifferentLanguages);

helloInDifferentLanguages = "Hello World!";

string firstname = "John";
string lastname = "Doe";
string fullname = $"{firstname} {lastname}";

Console.WriteLine(fullname.Length);
Console.WriteLine(fullname.StartsWith("John"));
Console.WriteLine(fullname.EndsWith("Doe"));
Console.WriteLine(fullname.Contains("n D"));
Console.WriteLine(fullname.IndexOf("Doe"));
Console.WriteLine(fullname.LastIndexOf("o"));

// Find all o in fullname and print their index
for (int i = 0; i < fullname.Length; i++)
{
    if (fullname[i] == 'o') { Console.WriteLine(i); }
}

fullname = fullname.ToUpper();
Console.WriteLine(fullname);