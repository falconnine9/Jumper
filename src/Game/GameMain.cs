/* GameMain
 * 
 * The main point at which the game is run. Including the
 * balloon physics, bullet physics, and everything else
 */

using System.Diagnostics;

using Jumper.GameObjects;
using Jumper.Utils;

namespace Jumper.Game;

class GameMain
{
    public static Entity Player { get; private set; } = Balloon.MakeBalloon();
    public static List<Entity> BulletList { get; private set; } = new();

    public static bool Failed = false;

    public static double BulletSpeed = 2;
    public static int MaxBullets = 1;

    public static int Score = 0;
    public static bool Paused = false;

    private static long _frame = 0;
    private static double _bulletNumInc = 0;

    public static void Start()
    {
        while (!Failed) {
            var sw = Stopwatch.StartNew();

            if (_frame % Constants.PhysicsRate == 0 && !Paused) {
                Balloon.EvaluateBalloonPhysics();
                Bullets.EvaluateBulletPhysics();

                if (BulletList.Count == 0) {
                    while (BulletList.Count < MaxBullets)
                        Bullets.HandleBulletStages(ref _bulletNumInc);
                }
            }

            _handleKeyPresses();
            Drawing.DrawAssets();

            sw.Stop();
            Execution.Wait((int)(1000 / Constants.FrameRate - sw.ElapsedMilliseconds));

            if (!Paused)
                _frame++;
        }
        
        Drawing.DrawDeathScreen();
    }

    public static void Reset()
    {
        Player = Balloon.MakeBalloon();
        BulletList = new();

        Failed = false;

        BulletSpeed = 2;
        MaxBullets = 1;

        Score = 0;

        Paused = false;
        _frame = 0;
        _bulletNumInc = 0;
    }

    private static void _handleKeyPresses()
    {
        Keyboard.GetState();

        if (Keyboard.IsKeyPressed(Constants.Updraft) && !Paused)
            Player.YVelocity -= Constants.Lift;

        if (Keyboard.IsKeyPressed(Constants.Pause))
            Paused = !Paused;

        if (Keyboard.IsKeyPressed(Constants.Quit)) {
            Failed = true;
            Jumper.Quit = true;
        }
    }
}
