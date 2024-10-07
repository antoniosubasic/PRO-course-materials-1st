int first = 0;
int second = 1;
int last = 0;

// do while
do
{
    Console.Write(first + " ");
    last = first;
    first = second;
    second += last;
}
while (first <= 34);

Console.WriteLine();

// while
first = 0;
second = 1;
last = 0;
while (first <= 34)
{
    Console.Write(first + " ");
    last = first;
    first = second;
    second += last;
}