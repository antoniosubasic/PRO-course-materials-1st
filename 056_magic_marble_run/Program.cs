#region Main Program
{
    string marbleRun = args[0];

    var teleporters = AnalyzeTeleporters(marbleRun);
    var visitedPositions = new HashSet<int>();
    int numberSegments = 0, numberTeleports = 0, currentPosition = 0;

    for (; currentPosition < marbleRun.Length; numberSegments++)
    {
        if (!IsValidMarbleRun(visitedPositions, currentPosition))
        {
            numberSegments = numberTeleports = currentPosition = 0;
            visitedPositions.Clear();
            IncrementCombination(teleporters);

            if (CheckForEnd(teleporters)) { Console.WriteLine("No possible run detected. Run aborted."); return; }
        }
        else { visitedPositions.Add(currentPosition); }

        switch (marbleRun[currentPosition])
        {
            case '<': currentPosition--; break;
            case '>': currentPosition++; break;
            default:
                numberSegments--;
                numberTeleports++;
                currentPosition = CalcNewPos(marbleRun, currentPosition, teleporters);
                break;
        }
    }

    Console.WriteLine($"\n# of segments: {numberSegments}");
    Console.WriteLine($"# of teleports: {numberTeleports}");
}
#endregion

#region Methods
HashSet<Teleporter> AnalyzeTeleporters(string marbleRun)
{
    var teleporters = new HashSet<Teleporter>();

    for (int i = 0; i < marbleRun.Length; i++)
    {
        if (!(marbleRun[i] is '>' or '<'))
        {
            string number = marbleRun.Substring(i, 4);
            bool isDecimal = number.All(char.IsDigit);

            teleporters.Add(new Teleporter
            {
                Index = i,
                Base = isDecimal ? 10 : 16,
                IsMutable = isDecimal
            });

            i += 4;
        }
    }

    return teleporters;
}

void IncrementCombination(HashSet<Teleporter> teleporters)
{
    for (int i = 0; i < teleporters.Count; i++)
    {
        var currentIndex = ^(i + 1);
        var currentElement = teleporters.ElementAt(currentIndex);

        if (currentElement.IsMutable)
        {
            teleporters.Remove(currentElement);

            teleporters.Add(new Teleporter
            {
                Index = currentElement.Index,
                Base = 26 - currentElement.Base,
                IsMutable = currentElement.IsMutable
            });

            if (currentElement.Base == 10) { break; }
        }
    }
}

bool CheckForEnd(HashSet<Teleporter> teleporters) => teleporters.Where(v => v.IsMutable).All(v => v.Base == 10);

bool IsValidMarbleRun(HashSet<int> visitedPositions, int currentPosition) => !visitedPositions.Contains(currentPosition);

int CalcNewPos(string marbleRun, int currentPosition, HashSet<Teleporter> teleporters)
{
    bool numberIsAfter = char.IsDigit(marbleRun[currentPosition + 1]);
    int startingIndex = currentPosition + (numberIsAfter ? 0 : -3);

    return Convert.ToInt32(marbleRun.Substring(startingIndex, 4), BaseOfCurrentTeleporter(teleporters, startingIndex));
}

int BaseOfCurrentTeleporter(HashSet<Teleporter> teleporters, int index)
{
    foreach (var teleporter in teleporters)
    {
        if (teleporter.Index == index) { return teleporter.Base; }
    }

    throw new IndexOutOfRangeException($"Teleporter base of Index '{index}' not found.");
}
#endregion

#region Classes
class Teleporter
{
    public int Index { get; set; }
    public int Base { get; set; }
    public bool IsMutable { get; set; }
}
#endregion
