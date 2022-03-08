/* Drawing
 * 
 * General functions for drawing lines and textures
 * during the main execution of the game
 */

using Jumper.GameObjects;
using Jumper.Graphics;

namespace Jumper.Game;

class Drawing
{
    public static void DrawAssets()
    {
        Jumper.Window.Fill(255);

        Jumper.Window.SetRow(0, 0);
        Jumper.Window.SetRow(Constants.FrameHeight - 1, 0);
        Jumper.Window.SetColumn(0, 0);
        Jumper.Window.SetColumn(Constants.FrameWidth - 1, 0);

        Jumper.Window.DrawTexture(GameMain.Player.X, GameMain.Player.Y, GameMain.Player.Frame);

        foreach (Entity bullet in GameMain.BulletList)
            Jumper.Window.DrawTexture(bullet.X, bullet.Y, bullet.Frame);

        Jumper.Window.PushToConsole();
    }

    public static void DrawDeathScreen()
    {
        Jumper.Window.Fill(255);

        Jumper.Window.SetRow(0, 0);
        Jumper.Window.SetRow(Constants.FrameHeight - 1, 0);
        Jumper.Window.SetColumn(0, 0);
        Jumper.Window.SetColumn(Constants.FrameWidth - 1, 0);

        Jumper.Window.DrawTexture(GameMain.Player.X, GameMain.Player.Y, Texture.BalloonBroken);

        Jumper.Window.PushToConsole();
    }
}
