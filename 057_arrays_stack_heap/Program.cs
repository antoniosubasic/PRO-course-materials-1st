//! Kopieren/verschieben von Werten
int x = 10;
int y = x;
y++;
Console.WriteLine(x);
Console.WriteLine(y);


//! Kopieren/verschieben von Werten in Arrays
var array1 = new[] { 1, 2, 3 };
var array2 = array1;
array2[0]++;
Console.WriteLine(array1[0]);
Console.WriteLine(array2[0]);


//! Array und Methoden
var array3 = new[] { 4, 5, 6 };
var n = 4;
IncrementArrayBy1(array3);
IncrementBy1(n);
Console.WriteLine(n);
Console.WriteLine(array3[0]);

// Methode, die alle Zahlen eines Array um 1 erhöht
void IncrementArrayBy1(int[] numbers)
{
    for (int i = 0; i < numbers.Length; i++)
    {
        numbers[i]++;
    }
}

void IncrementBy1(int number)
{
    number++;
}


//! Strings
var s1 = "ABC";
var s2 = s1;
s2 = s2.Substring(1);
Console.WriteLine(s1);
Console.WriteLine(s2);

// String.Split
const string NUMBERS = "1,2,3,4,5,6,7,8,9,10,11";

// Zerteile Numbers in eine Array, wobei jedes Array-Element jeweils eine Zahl enthält
var numbersAsArray = NUMBERS.Split(',');
foreach (var item in numbersAsArray) { Console.WriteLine(item); }

// String.Split Übung 2
const string NUMBER_IN_LINES = """
    1
    2
    3
    4
    5
    """;


// Zerteile NumbersInLines in eine Array, wobei jedes Array-Element jeweils eine Zahl enthält
var numbersInLinesAsArray = NUMBER_IN_LINES.Split('\n');
foreach (var item in numbersInLinesAsArray) { Console.WriteLine(item); }

// String.Split Übung 3
const string CSV = "10,20;30,40;50";
var numbersFromCSV = CSV.Split(',', ';');
foreach (var item in numbersFromCSV) { Console.WriteLine(item); }

const string MATRIX = """
    1,2,3
    4,5,6
    7,8,9
    """;
var matrixArray = MATRIX.Split('\n');
var numbersFromMatrix = matrixArray[0].Split(',');