/* Constants
 * 
 * A list of constant values for gameplay
 */

namespace Jumper;

class Constants
{
    public static readonly int NumWidth = 12; // Width of each number texture
    public static readonly int MaxNums = 3;   // Maximum amount of score numbers

    public static readonly int FrameWidth = 220;   // Width of the console frame
    public static readonly int FrameHeight = 140;  // Height of the console frame
    public static readonly int FrameRate = 24;     // Framerate of the console frame
    public static readonly byte BorderColor = 0;   // Color of the console frame border
    public static readonly int AnimationDiff = 10; // Initial animation line offset

    public static readonly int PhysicsRate = 1; // Rate of physics in correlation to fps
    public static readonly int TerminalVel = 4; // Terminal velocity

    public static readonly double Gravity = 0.4; // Gravity rate
    public static readonly int Lift = 4;         // Updraft rate

    public static readonly int BulletTerminalVel = 15;   // Terminal velocity of bullets
    public static readonly int MaxBulletNum = 5;         // Max number of bullets
    public static readonly double BulletIncrement = 0.2; // Increment of bullet speed each iteration

    public static readonly ConsoleKey Updraft = ConsoleKey.UpArrow;
    public static readonly ConsoleKey Pause = ConsoleKey.Escape;
    public static readonly ConsoleKey Quit = ConsoleKey.Q;
    public static readonly ConsoleKey Restart = ConsoleKey.Spacebar;
}
