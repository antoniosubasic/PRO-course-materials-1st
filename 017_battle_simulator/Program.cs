#region Constants
const int PIRATE_HEALTH = 20;
const int PIRATE_ATTACK = 3;
const int PIRATE_ARMOR = 3;
const int PIRATE_SPEED = 3;

const int STONE_CHEWER_HEALTH = 50;
const int STONE_CHEWER_ATTACK = 8;
const int STONE_CHEWER_ARMOR = 10;
const int STONE_CHEWER_SPEED = 1;

const int GHOST_WARRIOR_HEALTH = 20;
const int GHOST_WARRIOR_ATTACK = 2;
const int GHOST_WARRIOR_ARMOR = 2;
const int GHOST_WARRIOR_SPEED = 5;

const int OUTWORLDER_HEALTH = 15;
const int OUTWORLDER_ATTACK = 1;
const int OUTWORLDER_ARMOR = 2;
const int OUTWORLDER_SPEED = 10;

const int MONSTER_KNIGHT_HEALTH = 15;
const int MONSTER_KNIGHT_ATTACK = 4;
const int MONSTER_KNIGHT_ARMOR = 3;
const int MONSTER_KNIGHT_SPEED = 3;

const int DARK_GOBLIN_HEALTH = 10;
const int DARK_GOBLIN_ATTACK = 1;
const int DARK_GOBLIN_ARMOR = 8;
const int DARK_GOBLIN_SPEED = 3;
#endregion

string player1;
double player1_health;
int player1_attack;
double player1_armor;
int player1_speed;

string player2;
double player2_health;
int player2_attack;
double player2_armor;
int player2_speed;

const string CHARACTERS = ", please choose a character (p - Pirate, s - Stone Chewer, g - Ghost Warrior, o - Outworlder, m - Monster Knight, d - Dark Goblin): ";
const string MUST_CHOOSE = "You must choose a character";
int round = 1;

Console.WriteLine("Welcome to the battle simulator!");
Console.WriteLine("Player 1" + CHARACTERS);
player1 = Console.ReadLine()!;
switch (player1)
{
    case "p":
        player1 = "Pirate";
        player1_health = PIRATE_HEALTH;
        player1_attack = PIRATE_ATTACK;
        player1_armor = PIRATE_ARMOR;
        player1_speed = PIRATE_SPEED;
        break;
    case "s":
        player1 = "Stone Chewer";
        player1_health = STONE_CHEWER_HEALTH;
        player1_attack = STONE_CHEWER_ATTACK;
        player1_armor = STONE_CHEWER_ARMOR;
        player1_speed = STONE_CHEWER_SPEED;
        break;
    case "g":
        player1 = "Ghost Warrior";
        player1_health = GHOST_WARRIOR_HEALTH;
        player1_attack = GHOST_WARRIOR_ATTACK;
        player1_armor = GHOST_WARRIOR_ARMOR;
        player1_speed = GHOST_WARRIOR_SPEED;
        break;
    case "o":
        player1 = "Outworlder";
        player1_health = OUTWORLDER_HEALTH;
        player1_attack = OUTWORLDER_ATTACK;
        player1_armor = OUTWORLDER_ARMOR;
        player1_speed = OUTWORLDER_SPEED;
        break;
    case "m":
        player1 = "Monster Knight";
        player1_health = MONSTER_KNIGHT_HEALTH;
        player1_attack = MONSTER_KNIGHT_ATTACK;
        player1_armor = MONSTER_KNIGHT_ARMOR;
        player1_speed = MONSTER_KNIGHT_SPEED;
        break;
    case "d":
        player1 = "Dark Goblin";
        player1_health = DARK_GOBLIN_HEALTH;
        player1_attack = DARK_GOBLIN_ATTACK;
        player1_armor = DARK_GOBLIN_ARMOR;
        player1_speed = DARK_GOBLIN_SPEED;
        break;
    default:
        Console.WriteLine(MUST_CHOOSE);
        return;
}
player1 += " (Player 1)";

Console.WriteLine("\nPlayer 2" + CHARACTERS);
player2 = Console.ReadLine()!;
switch (player2)
{
    case "p":
        player2 = "Pirate";
        player2_health = PIRATE_HEALTH;
        player2_attack = PIRATE_ATTACK;
        player2_armor = PIRATE_ARMOR;
        player2_speed = PIRATE_SPEED;
        break;
    case "s":
        player2 = "Stone Chewer";
        player2_health = STONE_CHEWER_HEALTH;
        player2_attack = STONE_CHEWER_ATTACK;
        player2_armor = STONE_CHEWER_ARMOR;
        player2_speed = STONE_CHEWER_SPEED;
        break;
    case "g":
        player2 = "Ghost Warrior";
        player2_health = GHOST_WARRIOR_HEALTH;
        player2_attack = GHOST_WARRIOR_ATTACK;
        player2_armor = GHOST_WARRIOR_ARMOR;
        player2_speed = GHOST_WARRIOR_SPEED;
        break;
    case "o":
        player2 = "Outworlder";
        player2_health = OUTWORLDER_HEALTH;
        player2_attack = OUTWORLDER_ATTACK;
        player2_armor = OUTWORLDER_ARMOR;
        player2_speed = OUTWORLDER_SPEED;
        break;
    case "m":
        player2 = "Monster Knight";
        player2_health = MONSTER_KNIGHT_HEALTH;
        player2_attack = MONSTER_KNIGHT_ATTACK;
        player2_armor = MONSTER_KNIGHT_ARMOR;
        player2_speed = MONSTER_KNIGHT_SPEED;
        break;
    case "d":
        player2 = "Dark Goblin";
        player2_health = DARK_GOBLIN_HEALTH;
        player2_attack = DARK_GOBLIN_ATTACK;
        player2_armor = DARK_GOBLIN_ARMOR;
        player2_speed = DARK_GOBLIN_SPEED;
        break;
    default:
        Console.WriteLine(MUST_CHOOSE);
        return;
}
player2 += " (Player 2)";

while (player1_health > 0 && player2_health > 0)
{
    string round_output = "Round " + round + " {0}:";
    string player_output = "{0} - Health: {1}, Armor: {2}";
    
    double player1_attack_damage = 0;
    for (int i = 0; i < player1_speed; i++)
    {
        player1_attack_damage += player1_attack * Random.Shared.Next(85, 116) / 100d;
    }
    double player2_attack_damage = 0;
    for (int i = 0; i < player2_speed; i++)
    {
        player2_attack_damage += player2_attack * Random.Shared.Next(85, 116) / 100d;
    }

    Console.WriteLine("\n" + round_output, "begin");
    Console.WriteLine(player_output, player1, player1_health, player1_armor + ", Attack by opponent: " + player2_attack_damage);
    Console.WriteLine(player_output, player2, player2_health, player2_armor + ", Attack by opponent: " + player1_attack_damage);

    if (player1_armor != 0)
    {
        player1_armor -= player2_attack_damage;
        if (player1_armor < 0) { player1_health += player1_armor; player1_armor = 0; }
    }
    else { player1_health -= player2_attack_damage; }
    if (player1_health < 0) { player1_health = 0; }

    if (player2_armor != 0)
    {
        player2_armor -= player1_attack_damage;
        if (player2_armor < 0) { player2_health += player2_armor; player2_armor = 0; }
    }
    else { player2_health -= player1_attack_damage; }
    if (player2_health < 0) { player2_health = 0; }

    Console.WriteLine(round_output, "end");
    Console.WriteLine(player_output, player1, player1_health, player1_armor);
    Console.WriteLine(player_output, player2, player2_health, player2_armor);

    round++;
}

Console.WriteLine();

round--;
string won_message = "{0} has won after " + round + " rounds!";

if (player1_health <= 0 && player2_health <= 0)
{
    Console.WriteLine("DRAW! Both characters died after " + round + " rounds");
}
else if (player1_health <= 0)
{
    Console.WriteLine(won_message, player2);
}
else
{
    Console.WriteLine(won_message, player1);
}