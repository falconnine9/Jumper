/* GameLoop
 * 
 * Methods for running the main game loop including the
 * physics for the balloon, height records and the bullet
 * shooting from the sides
 */

using System.Diagnostics;

using Jumper.Graphics;
using Jumper.Utils;

namespace Jumper.Sections;

class GameLoop
{
    private static bool _failed = false;

    private static int _balloonX = Constants.FrameWidth / 2 - Texture.Balloon.Width / 2;
    private static int _balloonY = Constants.FrameHeight / 2 - Texture.Balloon.Height / 2;

    private static int _highestPosition = _balloonY - 1;
    private static int _lowestPosition = _balloonY + Texture.Balloon.Height;

    private static float _balloonVelocity = 0;

    public static void Start()
    {
        int frame = 0;

        while (!_failed) {
            var st = Stopwatch.StartNew();

            Jumper.Window.Fill(255);

            if (Keyboard.IsKeyPressed(Constants.Updraft) && _balloonVelocity < 10)
                _balloonVelocity -= Constants.Lift;

            if (frame % Constants.PhysicsRate == 0)
                _runPhysics();

            _setRecords();
            _drawAssets();
            Jumper.Window.PushToConsole();

            Execution.Wait(Math.Abs((int)(1000 / Constants.FrameRate - st.ElapsedMilliseconds)));
            st.Stop();
        }
    }

    private static void _runPhysics()
    {
        _balloonY = (int)Math.Floor(_balloonY + _balloonVelocity);

        if (_balloonY < 1) {
            _balloonY = 1;
            _failed = true;
        }
        else if (_balloonY + Texture.Balloon.Height >= Constants.FrameHeight) {
            _balloonY = Constants.FrameHeight - Texture.Balloon.Height - 1;
            _failed = true;
        }

        if (_balloonVelocity < Constants.TerminalVel)
            _balloonVelocity += Constants.Gravity;
    }

    private static void _drawAssets()
    {
        Jumper.Window.SetRow(0, Constants.BorderColor);
        Jumper.Window.SetRow(Constants.FrameHeight - 1, Constants.BorderColor);

        Jumper.Window.SetColumn(0, Constants.BorderColor);
        Jumper.Window.SetColumn(Constants.FrameWidth - 1, Constants.BorderColor);

        Jumper.Window.SetRow(_highestPosition, 200);
        Jumper.Window.SetRow(_lowestPosition, 200);

        Jumper.Window.DrawTexture(_balloonX, _balloonY, Texture.Balloon);
    }

    private static void _setRecords()
    {
        if (_balloonY < _highestPosition)
            _highestPosition = _balloonY - 1;
        if (_balloonY + Texture.Balloon.Height > _lowestPosition)
            _lowestPosition = _balloonY + Texture.Balloon.Height;
    }
}
