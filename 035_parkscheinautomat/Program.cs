int parkingTime = 0;

void PrintWelcome()
{
    Console.WriteLine("Parkscheinautomat mit Mindestparkdauer 30 Min und Höchstparkdauer 1:30 Stunden");
    Console.WriteLine("Tarif pro Stunde: 1 Euro");
    Console.WriteLine("Zulässige Münzen: 5 (Cents), 10 (Cents), 20 (Cents), 50 (Cents), 1 (Euro), 2 (Euro)");
    Console.WriteLine("Parkschein drucken mit d oder D");
}

void EnterCoins()
{
    string input;
    while (true)
    {
        PrintParkingTime();

        Console.Write("Ihre Eingabe: ");
        input = Console.ReadLine()!.ToLower();

        if (input == "d")
        {
            if (parkingTime < 30) { Console.WriteLine($"Mindesteinwurf 50 Cent, bisher haben Sie {parkingTime * 100 / 60} Cent eingeworfen"); } else { PrintParkingTime(true); }
        }
        else if (int.Parse(input) is 5 or 10 or 20 or 50 or 1 or 2) { AddParkingTime(int.Parse(input)); }
        else { Console.WriteLine("Dies ist keine zulässige Münze"); }
    }
}

void PrintParkingTime(bool endMessage = false)
{
    int hours = (int)parkingTime / 60;
    int minutes = parkingTime - hours * 60;

    int donationEuro = Math.Max(0, hours - 1);
    hours -= donationEuro;

    int donationCent = hours > 0 ? Math.Max(0, minutes - 30) * 100 / 60 : 0;
    minutes -= donationCent * 60 / 100;

    Console.WriteLine();
    if (endMessage || donationEuro != 0 || donationCent != 0)
    {
        if (donationEuro != 0 && minutes < 30)
        {
            donationEuro--;
            (minutes, donationCent) = (30, donationCent + 100 - (30 - minutes) * 100 / 60);
        }
        Console.WriteLine($"Sie dürfen {hours}:{minutes} Studen parken");
        PrintDonation(donationEuro, donationCent);
    }
    else { Console.WriteLine($"Parkzeit bisher: {hours}:{minutes}"); }
}

void PrintDonation(int donationEuro, int donationCent)
{
    if (donationEuro != 0 || donationCent != 0) { Console.WriteLine($"Danke für Ihre Spende von {donationEuro} Euro {donationCent} Cent"); }
    Environment.Exit(0);
}

void AddParkingTime(int moneyGiven)
{
    moneyGiven *= 60;
    parkingTime += moneyGiven > 2 * 60 ? moneyGiven / 100 : moneyGiven;
}

PrintWelcome();
EnterCoins();