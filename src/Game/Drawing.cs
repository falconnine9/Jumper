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
    private static Texture[] _numbers = new Texture[]
    {
        Texture.ReadTextureFile("numbers/0.texture"),
        Texture.ReadTextureFile("numbers/1.texture"),
        Texture.ReadTextureFile("numbers/2.texture"),
        Texture.ReadTextureFile("numbers/3.texture"),
        Texture.ReadTextureFile("numbers/4.texture"),
        Texture.ReadTextureFile("numbers/5.texture"),
        Texture.ReadTextureFile("numbers/6.texture"),
        Texture.ReadTextureFile("numbers/7.texture"),
        Texture.ReadTextureFile("numbers/8.texture"),
        Texture.ReadTextureFile("numbers/9.texture")
    };

    public static void DrawAssets()
    {
        Jumper.Window.Fill(255);

        Jumper.Window.DrawTexture(GameMain.Player.X, GameMain.Player.Y, GameMain.Player.Frame);

        foreach (Entity bullet in GameMain.BulletList)
            Jumper.Window.DrawTexture(bullet.X, bullet.Y, bullet.Frame);

        _drawBorders();
        _drawScore(2, GameMain.Score);
        _drawScore(20, Jumper.HighScore > GameMain.Score ? Jumper.HighScore : GameMain.Score);

        if (GameMain.Paused) {
            int x = Constants.FrameWidth / 2 - Texture.Paused.Width / 2;
            int y = Constants.FrameHeight / 2 - Texture.Paused.Height / 2;
            Jumper.Window.DrawTexture(x, y, Texture.Paused);
        }

        Jumper.Window.PushToConsole();
    }

    public static void DrawDeathScreen()
    {
        Jumper.Window.Fill(255);

        Jumper.Window.DrawTexture(GameMain.Player.X, GameMain.Player.Y, Texture.BalloonBroken);

        _drawBorders();
        _drawScore(2, GameMain.Score);
        _drawScore(20, Jumper.HighScore > GameMain.Score ? Jumper.HighScore : GameMain.Score);

        int x = Constants.FrameWidth / 2 - Texture.Dead.Width / 2;
        int y = Constants.FrameHeight / 2 - Texture.Dead.Height / 2;
        Jumper.Window.DrawTexture(x, y, Texture.Dead);

        Jumper.Window.PushToConsole();
    }

    private static void _drawBorders()
    {
        Jumper.Window.SetRow(0, 0);
        Jumper.Window.SetRow(Constants.FrameHeight - 1, 0);
        Jumper.Window.SetColumn(0, 0);
        Jumper.Window.SetColumn(Constants.FrameWidth - 1, 0);
    }

    private static void _drawScore(int y, int score)
    {
        string score_str = score.ToString();
        for (int i = 0; i < score_str.Length; i++) {
            Jumper.Window.DrawTexture(
                Constants.FrameWidth + Constants.NumWidth * i + i + 6,
                y, _numbers[score_str[i] - 48], false
            );
        }
    }
}
