/* GameLoop
 * 
 * Methods for running the main game loop including the
 * physics for the balloon, height records and the bullet
 * shooting from the sides
 */

using Jumper.Graphics;
using Jumper.Utils;

namespace Jumper.Sections;

class GameLoop
{
    private static bool _failed = false;

    private static int _balloon_x = Constants.FrameWidth / 2 - Texture.Balloon.Width / 2;
    private static int _balloon_y = Constants.FrameHeight / 2 - Texture.Balloon.Height / 2;

    private static int _highest_position = _balloon_y - 1;
    private static int _lowest_position = _balloon_y + Texture.Balloon.Height;

    private static float _balloon_velocity = 0;

    public static void Start()
    {
        int frame = 0;

        while (!_failed) {
            Execution.Wait(1000 / Constants.FrameRate);
            Jumper.Window.Fill(255);

            if (Keyboard.IsKeyPressed(Constants.Updraft))
                _balloon_velocity -= Constants.Lift;

            if (frame % Constants.PhysicsRate == 0)
                _runPhysics();
            if (frame == Constants.FrameRate)
                frame = 0;

            _setRecords();
            _drawAssets();
            Jumper.Window.PushToConsole();
        }
    }

    private static void _runPhysics()
    {
        _balloon_y = (int)Math.Floor(_balloon_y + _balloon_velocity);

        if (_balloon_y < 1) {
            _balloon_y = 1;
            _failed = true;
        }
        else if (_balloon_y + Texture.Balloon.Height >= Constants.FrameHeight) {
            _balloon_y = Constants.FrameHeight - Texture.Balloon.Height - 1;
            _failed = true;
        }

        if (_balloon_velocity < Constants.TerminalVel)
            _balloon_velocity += Constants.Gravity;
    }

    private static void _drawAssets()
    {
        Jumper.Window.SetRow(0, Constants.BorderColor);
        Jumper.Window.SetRow(Constants.FrameHeight - 1, Constants.BorderColor);

        Jumper.Window.SetColumn(0, Constants.BorderColor);
        Jumper.Window.SetColumn(Constants.FrameWidth - 1, Constants.BorderColor);

        Jumper.Window.SetRow(_highest_position, 200);
        Jumper.Window.SetRow(_lowest_position, 200);

        Jumper.Window.DrawTexture(_balloon_x, _balloon_y, Texture.Balloon);
    }

    private static void _setRecords()
    {
        if (_balloon_y < _highest_position)
            _highest_position = _balloon_y - 1;
        if (_balloon_y + Texture.Balloon.Height > _lowest_position)
            _lowest_position = _balloon_y + Texture.Balloon.Height;
    }
}
