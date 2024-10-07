decimal[] stockPrices = "110.34, 111.30, 117.70, 114.70, 114.77, 115.07, 118.12, 120.86, 120.32, 122.51, 122.88, 122.65, 119.82, 120.65, 117.50, 118.14, 118.22, 118.87, 118.78, 115.90, 115.48".Split(", ").Select(decimal.Parse).ToArray();

var maxWin = new decimal[3];
var maxLoss = new decimal[3];
for (int i = 0; i < stockPrices.Length - 1; i++)
{
    decimal dayToDay = stockPrices[i + 1] - stockPrices[i];
    int currentDay = i + 1, nextDay = i + 2;

    if (dayToDay > 0 && dayToDay > maxWin[2])
    {
        maxWin = new[] { currentDay, nextDay, dayToDay };
    }
    else if (dayToDay < 0 && dayToDay < maxLoss[2])
    {
        maxLoss = new[] { currentDay, nextDay, dayToDay };
    }
}

Console.WriteLine($"Max Win, day {maxWin[0]} - {maxWin[1]}: {maxWin[2]}");
Console.WriteLine($"Max Loss, day {maxLoss[0]} - {maxLoss[1]}: {Math.Abs(maxLoss[2])}");