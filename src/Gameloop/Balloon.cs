/* Balloon
 * 
 * General methods for the game loop. Such as the balloon
 * physics and creating the balloon.
 */

using Jumper.GameObjects;
using Jumper.Graphics;

namespace Jumper.Gameloop;

class Balloon
{
    public static Entity MakeBalloon() => new(
        Texture.Balloon,
        Constants.FrameWidth / 2 - Texture.Balloon.Width / 2,
        Constants.FrameHeight / 2 - Texture.Balloon.Height / 2,
        0, 0
    );

    public static void EvaluateBalloonPhysics()
    {
        Entity balloon = GameMain.Player;

        if (balloon.YVelocity != 0)
            balloon.Y = (int)Math.Floor(balloon.Y + balloon.YVelocity);

        if (balloon.Y < 0) {
            balloon.Y = 0;
            GameMain.Failed = true;
        }
        else if (balloon.Y2 >= Constants.FrameHeight) {
            balloon.Y = Constants.FrameHeight - balloon.Frame.Height - 1;
            GameMain.Failed = true;
        }

        if (balloon.YVelocity < Constants.TerminalVel)
            balloon.YVelocity += Constants.Gravity;
    }
}
