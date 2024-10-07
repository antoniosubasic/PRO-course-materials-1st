int[] temperature = "-8, -6, 9, 18, 19, 12, -18, 3, -10, 21, 8, 20, 32, -13, 24, 5, 13, -14, 29, 7, -12, 17, 1, 33, -19, -9, 31, 34, 14, -4, -17, -7, 22, 6, 26, -11, -1, -3, 25, 10, -15, -16, 23, -2, 30, 15, 28, 35, 11, 16"
                        .Split(", ")
                        .Select(int.Parse)
                        .ToArray();


var closesToZero = new HashSet<int> { temperature[0] };

for (int i = 1; i < temperature.Length; i++)
{
    int currentTempAbs = Math.Abs(temperature[i]);
    int minTempAbs = Math.Abs(closesToZero.Min());

    if (currentTempAbs <= minTempAbs)
    {
        if (currentTempAbs < minTempAbs) { closesToZero.Clear(); }
        closesToZero.Add(temperature[i]);
    }
}


foreach (var item in closesToZero) { Console.WriteLine(item); }
