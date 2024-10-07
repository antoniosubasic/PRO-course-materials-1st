// Lotto

// Frage den Benutzer um 6 Zahl zwischen 1 und 45
// Keine Zahl darf doppelt eingegeben werden
// Speichere die Zahlen in einem Array der Länge 6

// Ermittle 6 Zufallszahlen zwischen 1 und 45
// Keine Zahl darf doppelt vorkommen
// Schreibe eine Methode, die beide Arrays bekommt und ermittelt, wie viele Zahlen übereinstimmen

#region Main Program
{
    var lottoNumbers = new int[6];
    for (int i = 0; i < lottoNumbers.Length; i++) { lottoNumbers[i] = GetNumberFromUser(lottoNumbers); }

    var randomNumbers = new int[6];
    for (int i = 0; i < randomNumbers.Length; i++)
    {
        do { randomNumbers[i] = Random.Shared.Next(1, 46); } while (randomNumbers[..i].Contains(randomNumbers[i]));
    }

    Console.WriteLine("\nyour numbers: ");
    foreach (var number in lottoNumbers) { Console.Write($"{number} "); }

    Console.WriteLine("\nrandomly generated numbers: ");
    foreach (var number in randomNumbers) { Console.Write($"{number} "); }

    Console.WriteLine($"\n\nmatching Numbers: {NumberOfIntersectingElements(lottoNumbers, randomNumbers)}");
}
#endregion

#region Methods
int GetNumberFromUser(int[] array)
{
    int random; bool inputIsValid;
    do
    {
        Console.Write("Bitte geben Sie eine Zahl zwischen 1 und 45 ein: ");
        random = int.Parse(Console.ReadLine()!);
        inputIsValid = random >= 1 && random <= 45 && !array.Contains(random);

        if (!inputIsValid) { Console.WriteLine("Nur Zahlen zwischen 1 und 45 die noch nicht gewählt wurden sind möglich"); }
    } while (!inputIsValid);

    return random;
}

int NumberOfIntersectingElements(int[] array1, int[] array2) => array1.Count(v => array2.Contains(v));
#endregion
