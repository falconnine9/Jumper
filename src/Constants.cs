/* Constants
 * 
 * A list of constant values for gameplay
 */

namespace Jumper;

class Constants
{
    public static readonly int FrameWidth = 220;
    public static readonly int FrameHeight = 140;
    public static readonly int FrameRate = 24;
    public static readonly byte BorderColor = 0;

    public static readonly int PhysicsRate = 1;
    public static readonly int TerminalVel = 4;

    public static readonly double Gravity = 0.4;
    public static readonly int Lift = 4;

    public static readonly int BulletTerminalVel = 15;
    public static readonly int MaxBulletNum = 5;
    public static readonly double BulletIncrement = 0.2;

    public static readonly ConsoleKey Updraft = ConsoleKey.W;
    public static readonly ConsoleKey Pause = ConsoleKey.R;
    public static readonly ConsoleKey Quit = ConsoleKey.T;
}
