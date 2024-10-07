var lines = File.ReadAllLines("data.csv");
var result = new YearlyRevenue[lines.Length];
for (var i = 0; i < lines.Length; i++)
{
    var splittedLine = lines[i].Split(',');
    var revenue = new YearlyRevenue(
        int.Parse(splittedLine[0]),
        decimal.Parse(splittedLine[1].Replace('.', ','))
    );

    result[i] = revenue;
}

// What is the total revenue?
// var totalRevenue = result.Sum(year => year.Revenue);
var sum = 0m;
foreach (var r in result)
{
    sum += r.Revenue;
}
Console.WriteLine(sum);

// What is the average revenue?
// var averageRevenue = result.Average(year => year.Revenue);
var avg = sum / result.Length;
Console.WriteLine(avg);

// What is the year with the maximum revenue?
// var maxRevenue = result.Max(year => year.Revenue);
var max = 0m;
foreach (var r in result)
{
    if (r.Revenue > max) { max = r.Revenue; }
}
Console.WriteLine(max);

// Revenue is in EUR, change it to USD (1 EUR = 1.09 USD)
for (var i = 0; i < result.Length; i++)
{
    result[i] = result[i] with { Revenue = result[i].Revenue * 1.09m };
}

// Oh, there is a mistake in the year. Everything has been shifted by 5 years
for (var i = 0; i < result.Length; i++)
{
    result[i] = result[i] with { Year = result[i].Year + 5 };
}

record YearlyRevenue(int Year, decimal Revenue);
