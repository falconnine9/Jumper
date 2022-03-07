﻿/* GameMain
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
    public static readonly Entity Player = Balloon.MakeBalloon();
    public static readonly List<Entity> BulletList = new();

    public static bool Failed = false;

    public static double BulletSpeed = 1;
    public static int MaxBullets = 1;

    private static long _frame = 0;
    private static double _bullet_nums = 0;

    public static void Start()
    {
        while (!Failed) {
            var sw = Stopwatch.StartNew();

            if (_frame % Constants.PhysicsRate == 0) {
                Balloon.EvaluateBalloonPhysics();
                Bullets.EvaluateBulletPhysics();

                while (BulletList.Count < MaxBullets) {
                    if (BulletSpeed < Constants.TerminalVel)
                        BulletSpeed += Constants.BulletIncrement;

                    _bullet_nums += Constants.BulletIncrement / 2;
                    if (_bullet_nums >= 1 && BulletList.Count < Constants.MaxBulletNum) {
                        _bullet_nums = 0;
                        MaxBullets += 1;
                    }

                    BulletList.Add(Bullets.MakeNewBullet());
                }
            }

            _handleKeyPresses();
            _drawAssets();

            sw.Stop();
            Execution.Wait((int)(1000 / Constants.FrameRate - sw.ElapsedMilliseconds));
        }
    }

    private static void _handleKeyPresses()
    {
        if (Keyboard.IsKeyPressed(Constants.Updraft))
            Player.YVelocity -= Constants.Lift;
    }

    private static void _drawAssets()
    {
        Jumper.Window.Fill(255);

        Jumper.Window.SetRow(0, 0);
        Jumper.Window.SetRow(Constants.FrameHeight - 1, 0);
        Jumper.Window.SetColumn(0, 0);
        Jumper.Window.SetColumn(Constants.FrameWidth - 1, 0);

        Jumper.Window.DrawTexture(Player.X, Player.Y, Player.Frame);

        foreach (Entity bullet in BulletList)
            Jumper.Window.DrawTexture(bullet.X, bullet.Y, bullet.Frame);

        Jumper.Window.PushToConsole();
    }
}