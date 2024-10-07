#region Constants
const int SEED = 4711;
const int N_NUMBERS = 1_000_000;
const int MIN = 1;
const int MAX = 1_000_000_000;
#endregion

#region Program
{
    var (min, max) = GetMinAndMax();

    Console.WriteLine((max - min) / (double)(N_NUMBERS - 1));
}
#endregion

#region Methods
(int, int) GetMinAndMax()
{
    var rand = new Random(SEED);

    int min = int.MaxValue, max = int.MinValue;
    for (int i = 0; i < N_NUMBERS + 1; i++)
    {
        var random = rand.Next(MIN, MAX + 1);

        if (random < min) { min = random; }
        else if (random > max) { max = random; }
    }

    return (min, max);
}
#endregion
