// reads entire file
var fileContent = File.ReadAllText(@"C:\Users\anton\Dropbox\Schule\HTL\PRO\062_files\my-folder\poem.txt");
Console.WriteLine(fileContent);

// reads file line by line and returns an array where each element is one line in the file
var lines = File.ReadAllLines(@"C:\Users\anton\Dropbox\Schule\HTL\PRO\062_files\my-folder\poem.txt");
foreach (var line in lines) { Console.WriteLine(line); }

File.WriteAllText("my-folder/poem2.txt", "Hänschen klein, ging allein, in die weite Welt hinein.");

var linesToWrite = new[]
{
    "Hänschen klein,",
    "ging allein,",
    "in die weite Welt hinein."
};
File.WriteAllLines("my-folder/poem3.txt", linesToWrite);
