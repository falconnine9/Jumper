/* GameMain
 * 
 * The main point at which the game is run. Including the
 * balloon physics, bullet physics, and everything else
 */

using System.Diagnostics;

using Jumper.GameObjects;
using Jumper.Graphics;
using Jumper.Utils;

namespace Jumper.Game;

class GameMain
{
    public static Entity Player { get; private set; } = Balloon.MakeBalloon();
    public static List<Entity> BulletList { get; private set; } = new();

    public static bool Failed = false;

    public static double BulletSpeed = 2;
    public static int MaxBullets = 1;

    private static bool _paused = false;
    private static long _frame = 0;
    private static double _bullet_nums = 0;

    public static void Start()
    {
        while (!Failed) {
            var sw = Stopwatch.StartNew();

            if (_frame % Constants.PhysicsRate == 0 && !_paused) {
                Balloon.EvaluateBalloonPhysics();
                Bullets.EvaluateBulletPhysics();

                while (BulletList.Count < MaxBullets) {
                    if (BulletSpeed < Constants.TerminalVel)
                        BulletSpeed += Constants.BulletIncrement;

                    _bullet_nums += Constants.BulletIncrement / 2;
                    if (_bullet_nums >= MaxBullets && BulletList.Count < Constants.MaxBulletNum) {
                        _bullet_nums = 0;
                        MaxBullets += 1;
                    }

                    BulletList.Add(Bullets.MakeNewBullet());
                }
            }

            _handleKeyPresses();
            Drawing.DrawAssets();

            sw.Stop();
            Execution.Wait((int)(1000 / Constants.FrameRate - sw.ElapsedMilliseconds));

            if (!_paused)
                _frame++;
        }

        Console.Beep();
        Drawing.DrawDeathScreen();
    }

    public static void Reset()
    {
        Player = Balloon.MakeBalloon();
        BulletList = new();

        Failed = false;

        BulletSpeed = 2;
        MaxBullets = 1;

        _paused = false;
        _frame = 0;
        _bullet_nums = 0;
    }

    private static void _handleKeyPresses()
    {
        if (Keyboard.IsKeyPressed(Constants.Updraft) && !_paused)
            Player.YVelocity -= Constants.Lift;

        if (Keyboard.IsKeyPressed(Constants.Pause))
            _paused = !_paused;

        if (Keyboard.IsKeyPressed(Constants.Quit)) {
            Failed = true;
            Jumper.Quit = true;
        }
    }
}
