#region Constants
const string NORTH = "north";
const string EAST = "east";
const string SOUTH = "south";
const string WEST = "west";
const string FLEE = "flee";
const string FIGHT = "fight";
const string DOOR1 = "door 1";
const string DOOR2 = "door 2";
const string ENTER_PIN = "enter pin";
const string LEAVE = "leave";

const int INTRO_SCENE = 0;
const int SHOW_SHADOW_FIGURE = 1;
const int CAMERA_SCENE = 2;
const int PIN_ROOM = 3;
const int HAUNTED_ROOM = 4;
const int TRAP_ROOM = 5;
const int KEY_ROOM = 6;
const int SHOW_SKELETONS = 7;
const int STRANGE_CREATURE = 8;
const int CONNECTION = 9;
const int FORBIDDEN_CHAMBER = 10;
const int HINT_ROOM = 11;
const int DECISION_ROOM = 12;
const int TORCH_ROOM = 13;
const int DEAD_END_WALL = 14;
const int DEAD = 15;
const int EXIT = 16;
#endregion


#region Main Program
{
    PrintWelcome();
    GetAndPrintName();

    bool dead = false, foundExit = false;
    bool weaponFound = false, torchFound = false, keyFound = false;
    bool goulKilled = false, goulKilledRecently = false, trapTriggered = false;
    string deathMessage = "";

    int currentRoom = INTRO_SCENE;
    do
    {
        Console.WriteLine();
        int oldRoom = currentRoom;
        currentRoom = currentRoom switch
        {
            INTRO_SCENE => IntroScene(),
            SHOW_SHADOW_FIGURE => ShowShadowFigure(),
            CAMERA_SCENE => CameraScene(),
            PIN_ROOM => PinRoom(ref deathMessage),
            HAUNTED_ROOM => HauntedRoom(),
            TRAP_ROOM => TrapRoom(ref trapTriggered, ref deathMessage),
            KEY_ROOM => KeyRoom(ref keyFound),
            SHOW_SKELETONS => ShowSkeletons(),
            STRANGE_CREATURE => StrangeCreature(ref weaponFound, ref goulKilled, ref goulKilledRecently, ref deathMessage),
            CONNECTION => Connection(),
            FORBIDDEN_CHAMBER => ForbiddenChamber(torchFound),
            HINT_ROOM => HintRoom(),
            DECISION_ROOM => DecisionRoom(ref keyFound),
            TORCH_ROOM => TorchRoom(ref torchFound),
            _ => currentRoom
        };

        switch (currentRoom)
        {
            case DEAD: Dead(ref dead, deathMessage); break;
            case EXIT: Exit(ref foundExit); break;
            case DEAD_END_WALL: DeadEndWall(oldRoom, ref currentRoom, ref weaponFound); break;
        }
    }
    while (!dead && !foundExit);
}
#endregion


# region Methods
void PrintWelcome()
{
    Console.WriteLine(@"Welcome to the Adventure Game!
==============================
As an avid traveler, you have decided to visit the Catacombs of Paris.
However, during your exploration, you find yourself lost.
You can choose to walk in multiple directions to find a way out.");
}

void GetAndPrintName()
{
    Console.Write("Let's start with your name: ");
    Console.WriteLine($"Good luck, {Console.ReadLine()!}\n");
}

string GetOption(string[] possibleOptions)
{
    bool inputIsValid;
    string input;
    do
    {
        Console.WriteLine($"Options: {String.Join("/", possibleOptions)}");
        input = Console.ReadLine()!.ToLower();
        inputIsValid = possibleOptions.Contains(input);
        if (!inputIsValid) { Console.WriteLine("Input invalid. Try again..."); }
    } while (!inputIsValid);

    return input;
}

int IntroScene()
{
    Console.WriteLine("You are at a crossroads, and you can choose to go down any of the four hallways. Where would you like to go?");

    return GetOption(new string[] { NORTH, EAST, SOUTH, WEST }) switch
    {
        NORTH => DEAD_END_WALL,
        EAST => SHOW_SKELETONS,
        SOUTH => HAUNTED_ROOM,
        WEST => SHOW_SHADOW_FIGURE,
        _ => INTRO_SCENE
    };
}

int ShowShadowFigure()
{
    Console.WriteLine("You see a dark shadowy figure appear in the distance. You are creeped out. Where would you like to go?");

    return GetOption(new string[] { NORTH, EAST, SOUTH }) switch
    {
        NORTH => CAMERA_SCENE,
        EAST => INTRO_SCENE,
        SOUTH => DEAD_END_WALL,
        _ => SHOW_SHADOW_FIGURE
    };
}

int CameraScene()
{
    Console.WriteLine("You see a camera that has been dropped on the ground. Someone has been here recently. Where would you like to go?");

    return GetOption(new string[] { NORTH, SOUTH }) switch
    {
        NORTH => PIN_ROOM,
        SOUTH => SHOW_SHADOW_FIGURE,
        _ => CAMERA_SCENE
    };
}

int HauntedRoom()
{
    Console.WriteLine("You hear strange voices. You think you have awoken some of the dead. Where would you like to go?");

    return GetOption(new string[] { NORTH, EAST, WEST }) switch
    {
        NORTH => INTRO_SCENE,
        EAST => DEAD_END_WALL,
        WEST => TRAP_ROOM,
        _ => HAUNTED_ROOM
    };
}

int ShowSkeletons()
{
    Console.WriteLine("You see a wall of skeletons as you walk into the room. Someone is watching you. Where would you like to go?");

    return GetOption(new string[] { NORTH, EAST, WEST }) switch
    {
        NORTH => DEAD_END_WALL,
        EAST => STRANGE_CREATURE,
        WEST => INTRO_SCENE,
        _ => SHOW_SKELETONS
    };
}

int StrangeCreature(ref bool weaponFound, ref bool goulKilled, ref bool goulKilledRecently, ref string deathMessage)
{
    string[] possibleOptions;
    if (goulKilled)
    {
        if (goulKilledRecently) { goulKilledRecently = false; Console.WriteLine("You kill the goul with the knife you found earlier."); }
        else { Console.WriteLine("You see the Goul-like creature that you killed earlier. What a relief! Where would you like to go?"); }
        possibleOptions = new string[] { NORTH, WEST };
    }
    else
    {
        Console.WriteLine("A strange Goul-like creature has appeared. You can either run or fight it. What would you like to do?");
        possibleOptions = new string[] { FLEE, FIGHT };
    }

    string option = GetOption(possibleOptions);
    int newRoom = option switch
    {
        NORTH => CONNECTION,
        WEST => SHOW_SKELETONS,
        FLEE => SHOW_SKELETONS,
        FIGHT => weaponFound ? STRANGE_CREATURE : DEAD,
        _ => STRANGE_CREATURE
    };

    if (option == FIGHT && weaponFound) { goulKilled = goulKilledRecently = true; }
    if (newRoom == DEAD) { deathMessage = "Multiple Goul-like creatures start emerging as you enter the room. You are killed."; }
    return newRoom;
}

int ForbiddenChamber(bool torchFound)
{
    Console.WriteLine("As you step into the room, you feel a chill run down your spine. It's pitch black and you can't see anything. You hear faint scurrying noises coming from the shadows, and you realize that this room is home to nocturnal creatures that only come out at night.");

    if (torchFound)
    {
        Console.WriteLine("You'll need to be cautious in this room and use the light of your torch to navigate your way through the darkness. Keep a watchful eye out for any signs of movement, as you never know what might be lurking in the shadows.");

        return GetOption(new string[] { EAST, WEST }) switch
        {
            EAST => CONNECTION,
            WEST => HINT_ROOM,
            _ => FORBIDDEN_CHAMBER
        };
    }
    else
    {
        Console.WriteLine("Without a source of light, you'll be at a severe disadvantage in this room. You'll need to find a way to illuminate your surroundings if you hope to make it out alive.");
        return CONNECTION;
    }
}

int Connection()
{
    Console.WriteLine("You enter an empty room. Where would you like to go?");

    return GetOption(new string[] { EAST, SOUTH, WEST }) switch
    {
        EAST => DECISION_ROOM,
        SOUTH => STRANGE_CREATURE,
        WEST => FORBIDDEN_CHAMBER,
        _ => CONNECTION
    };
}

int PinRoom(ref string deathMessage)
{
    Console.WriteLine("You enter the room and immediately notice something strange. Instead of the usual dark, damp walls of the catacombs, this room looks oddly modern. As you take a closer look, you see a touch pad on the wall, and a message appears on the screen. Choose your input carefully.");

    switch (GetOption(new string[] { ENTER_PIN, LEAVE }))
    {
        case ENTER_PIN:
            Console.Write("Enter the PIN: ");

            if (Console.ReadLine()!.Trim() == "9289") { return EXIT; }
            else { deathMessage= "The door slams shut behind you. You hear a loud click, and the door locks. You are trapped in the room. "; return DEAD; }

        default:
            return CAMERA_SCENE;
    }
}

int DecisionRoom(ref bool keyFound)
{
    Console.WriteLine("You find yourself standing in a dimly lit room with two passageways leading off in opposite directions. To the north, you can see a door with a large, rusty lock. To the south, a set of heavy iron bars blocks your path.");
    if (keyFound)
    {
        Console.WriteLine("Where would you like to go? Choose wisely");

        string option = GetOption(new string[] { NORTH, SOUTH, WEST });
        if (option is NORTH or SOUTH) { keyFound = false; }

        return option switch
        {
            NORTH => EXIT,
            SOUTH => TORCH_ROOM,
            WEST => CONNECTION,
            _ => DECISION_ROOM
        };
    }
    else
    {
        Console.WriteLine("It's clear that you'll need a key to proceed in either direction.");
        return CONNECTION;
    }
}

int TorchRoom(ref bool torchFound)
{
    Console.WriteLine("You find that this door opens into a empty room. As you enter the room, you notice a faint glow emanating from the far corner. Curious, you make your way over and discover a torch along with a flint resting on a pedestal. After a couple of tries you manage to light the torch.");
    torchFound = true;

    return CONNECTION;
}

int HintRoom()
{
    Console.WriteLine("You've made it all the way through the forbidding chamber, but there's no exit to be found here. Just when you think all hope is lost, you come across piece of paper having the number '9289' scribbled onto it.");

    return FORBIDDEN_CHAMBER;
}

int TrapRoom(ref bool trapTriggered, ref string deathMessage)
{
    if (trapTriggered)
    {
        Console.WriteLine("The path to this room blocked, as the trap triggered the collapse.");

        return HAUNTED_ROOM;
    }
    else
    {
        trapTriggered = true;
        Console.WriteLine("You enter a room with a large, wooden door. As you approach the door, you notice a large, rusty nail protruding from the floor. You decide to step over it, but as you do, the nail falls out of the floor and triggers a trap. The path you came from collapses, leaving you with no way back. There's no other option but to choose one of the two doors in front of you, but you can't shake off the feeling that one of them might lead to your demise. Which one do you choose?");

        string option = GetOption(new string[] { DOOR1, DOOR2 });
        if (option == DOOR1) { deathMessage = "You've made the wrong choice. The door you chose leads to a room filled with poisonous gas. You are killed."; }

        return option switch
        {
            DOOR1 => DEAD,
            DOOR2 => KEY_ROOM,
            _ => TRAP_ROOM
        };
    }
}

int KeyRoom(ref bool keyFound)
{
    keyFound = true;
    Console.WriteLine("As you enter the room, you feel a sense of relief wash over you. You made the right choice. You take the key that's stuck inside the wall and find a narrow path that leads back.");

    return HAUNTED_ROOM;
}

void DeadEndWall(int oldRoom, ref int currentRoom, ref bool weaponFound)
{
    if (oldRoom == SHOW_SKELETONS && !weaponFound)
    {
        weaponFound = true;
        Console.WriteLine("You find that this door opens into a wall. You open some of the drywall to discover a knife");
    }
    else { Console.WriteLine("You find that this door opens into a wall."); }

    currentRoom = oldRoom;
}

void Dead(ref bool dead, string deathMessage)
{
    dead = true;
    Console.WriteLine($"\n{deathMessage}");
}

void Exit(ref bool foundExit)
{
    foundExit = true;
    Console.WriteLine("\nYou made it! You've found an exit.");
}
#endregion