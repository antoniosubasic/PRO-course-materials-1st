Console.OutputEncoding = System.Text.Encoding.Default;

for (int i = 0; i < 15; i++)
{
    for (int j = 0; j < 15; j++)
    {
        Console.Write((i * 15 + j) % 2 == 0 ? "😄" : "🍕");
    }
    Console.WriteLine();
}