Console.Clear();
Console.ResetColor();
Console.CursorVisible = false;

const int PADDLE_WIDTH = 10;
const int PADDLE_DISTANCE_FROM_BOTTOM = 3;

int paddlePosX = (Console.WindowWidth - PADDLE_WIDTH) / 2;
int paddlePosY = Console.WindowHeight - PADDLE_DISTANCE_FROM_BOTTOM;

int ballPosX = Console.WindowWidth / 2;
int ballPosY = 0;

int speedVectorX = 1;
int speedVectorY = 1;

while (true)
{
    Console.SetCursorPosition(0, paddlePosY); // moving cursor to the given x and y coordinates
    for (var i = 0; i < Console.WindowWidth; i++)
    {
        Console.Write(i >= paddlePosX && i <= paddlePosX + PADDLE_WIDTH ? "=" : " ");
    }

    Console.SetCursorPosition(ballPosX, ballPosY);
    Console.Write(" ");

    ballPosX += speedVectorX;
    ballPosY += speedVectorY;

    if (ballPosY == Console.WindowHeight - 1) { return; } else if (ballPosY == 0) { speedVectorY *= -1; }
    else if (ballPosY == paddlePosY && ballPosX >= paddlePosX && ballPosX <= paddlePosX + PADDLE_WIDTH) { speedVectorY *= -1; }
    if (ballPosX == Console.WindowWidth - 1 || ballPosX == 0) { speedVectorX *= -1; }

    Console.SetCursorPosition(ballPosX, ballPosY);
    Console.Write("O");

    Thread.Sleep(35);

    for (int i = 0; i < 2; i++)
    {
        if (Console.KeyAvailable) // true if any key is pressed - false if no key is pressed
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow: if (paddlePosX > 0) { paddlePosX--; } break;
                case ConsoleKey.RightArrow: if (paddlePosX + PADDLE_WIDTH + 1 < Console.WindowWidth) { paddlePosX++; } break;
            }
        }
    }
}