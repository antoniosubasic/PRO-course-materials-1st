using ScottPlot; // package: https://scottplot.net/

#region Constants/Variables
const string FILE = "data.txt";
const char CHART_CHAR = '█';
#endregion

#region Main Program
{
    ComputeFile(FILE);
}
#endregion

#region Methods
void ComputeFile(string file)
{
    var data = File.ReadAllLines(file)
                .Select(line =>
                {
                    var parts = line.Split(',');
                    return (Year: int.Parse(parts[0]), Co2Emission: double.Parse(parts[1]));
                })
                .ToArray();

    foreach (var (year, co2Emission) in data)
    {
        int barLength = (int)(co2Emission * 40 / 80_000_000);

        string formattedEmission = co2Emission.ToString($"#,##0");
        string bar = new string(CHART_CHAR, barLength);

        Console.WriteLine($"{year}: {formattedEmission} {bar}");
    }

    var years = data.Select(line => (double)line.Year).ToArray();
    var co2Emissions = data.Select(line => line.Co2Emission).ToArray();

    CreatePlot($"data_{years.Min()}-{years.Max()}.png", (years, co2Emissions), ("Year", "CO2 Emissions"), "CO2 Emissions");
}

void CreatePlot(string filename, (double[] X, double[] Y) axis, (string X, string Y) label, string title)
{
    var plot = new Plot(1000, 750);

    plot.AddScatter(axis.X, axis.Y);
    plot.Title(title);
    plot.XLabel(label.X);
    plot.YLabel(label.Y);

    plot.SaveFig(filename);
}
#endregion
