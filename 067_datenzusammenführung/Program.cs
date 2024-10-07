#region Constants
const string FILENAMES = "Datei*.csv";
const string FINAL_FILE = "Datei3.csv";
#endregion

#region Main Program
{
    var data = GetData(FILENAMES, out string[][] properties);
    var mergedData = MergeData(data, properties.SelectMany(array => array).ToArray());
    WriteToFile(mergedData, FINAL_FILE);
}
#endregion

#region Methods
(string Id, Dictionary<string, string> Items)[][] GetData(string filenames, out string[][] properties)
{
    var files = Directory.GetFiles(".", filenames);
    var data = new List<List<(string Id, Dictionary<string, string> Items)>>();
    var tempProperties = new List<string[]>();

    for (int i = 0; i < files.Length; i++)
    {
        var file = files[i];
        var lines = File.ReadAllLines(file).Select(line => line.Split(',')).ToArray();

        tempProperties.Add(lines[0][1..]);

        data.Add(new List<(string Id, Dictionary<string, string> Items)>());

        foreach (var line in lines[1..])
        {
            var items = new Dictionary<string, string>();

            for (int j = 1; j < line.Length; j++)
            {
                items.Add(lines[0][j], line[j]);
            }

            data[i].Add((line[0], items));
        }
    }

    properties = tempProperties.ToArray();
    return data.Select(item => item.ToArray()).ToArray();
}

string[][] MergeData((string Id, Dictionary<string, string> Items)[][] data, string[] properties)
{
    var ids = data
        .Select(file => file.Select(item => int.Parse(item.Id)).ToArray())
        .SelectMany(array => array)
        .Distinct()
        .ToArray();

    var output = new string[ids.Length + 1][];
    output[0] = new[] { "ID" }.Concat(properties).ToArray();

    for (int i = 0; i < ids.Length; i++)
    {
        var dataOfId = new Dictionary<string, string>();

        foreach (var file in data)
        {
            foreach (var line in file)
            {
                if (int.Parse(line.Id) == ids[i])
                {
                    dataOfId = dataOfId
                        .Concat(line.Items)
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                }
            }
        }

        var listDataOfId = dataOfId.ToList();
        for (int j = 0; j < properties.Length; j++)
        {
            if (!dataOfId.Select(item => item.Key).Contains(properties[j]))
            {
                listDataOfId.Insert(j, new KeyValuePair<string, string>(properties[j], "unbekannt"));
            }
        }

        output[i + 1] = new[] { ids[i].ToString() }
            .Concat(
                listDataOfId
                .Select(item => item.Value)
                .ToArray()
            )
            .ToArray();
    }

    return output;
}

void WriteToFile(string[][] data, string filename)
{
    File.WriteAllLines(filename, data.Select(line => string.Join(',', line)).ToArray());
}
#endregion
