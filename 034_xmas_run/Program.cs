const string BACKGROUND = "Images/Background/BG_00.png";
const string SURFACE = "Images/surface.png";
const string HERO_CHARACTER = "Boy";

int backgroundWidth = 0, backgroundHeight = 0;
int heroWidthWalk = 0, heroHeightWalk = 0;
int surfaceWidth = 0, surfaceHeight = 0;

float animationFrame = 0f;
const float ANIMATION_SPEED = 0.5f;
float heroX = 0;

void Setup(P5 p5)
{
    p5.Background("#00ccff");

    P5Image background = p5.LoadImage(BACKGROUND);
    backgroundWidth = background.Width;
    backgroundHeight = background.Height;
    
    P5Image surface = p5.LoadImage(SURFACE);
    surfaceWidth = surface.Width;
    surfaceHeight = surface.Height;
    
    P5Image hero = p5.LoadImage($"Images/{HERO_CHARACTER}/Walk_000.png");
    heroWidthWalk = hero.Width;
    heroHeightWalk = hero.Height;
}

void Draw(P5 p5)
{
    float ratio = backgroundHeight / p5.Height;
    p5.Image(BACKGROUND, 0, 0, backgroundWidth / ratio, p5.Height);

    for (int i = 0; i < p5.Width / 50; i++)
    {
        p5.Image(SURFACE, i * surfaceWidth, p5.Height - surfaceHeight);
    }

    p5.Image($"Images/{HERO_CHARACTER}/Walk_0{(int)animationFrame:00}.png", heroX, p5.Height - heroHeightWalk - surfaceHeight);
    animationFrame = (animationFrame + ANIMATION_SPEED) % 16;

    if (p5.KeyIsDown(Key.A) && heroX > 0) { heroX -= 10; }
    else if (p5.KeyIsDown(Key.D)) { heroX += 10; }
}

void KeyDown(P5 p5, Key key)
{
}

GameApplication.Run(new(
    Setup: Setup,
    Draw: Draw,
    KeyDown: KeyDown
));
