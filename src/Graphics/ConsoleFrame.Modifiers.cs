/* ConsoleFrame
 * 
 * A file explanation for the ConsoleFrame can be
 * found in ConsoleFrame.Main.cs
 */

namespace Jumper.Graphics;

partial class ConsoleFrame // ConsoleFrame.Modifiers
{
    public void Fill(byte value)
    {
        for (int y = 0; y < _height; y++) {
            for (int x = 0; x < _width; x++) {
                Set(x, y, value);
            }
        }
    }

    public void SetRow(int y, byte value)
    {
        if (y >= _height)
            return;

        for (int x = 0; x < _width; x++) {
            SetSafe(x, y, value);
        }
    }

    public void SetColumn(int x, byte value)
    {
        if (x >= _width)
            return;

        for (int y = 0; y < _height; y++) {
            SetSafe(x, y, value);
        }
    }

    public void DrawBox(Square settings)
    {
        for (int y = settings.Y; y < settings.Y + settings.Height; y++) {
            for (int x = settings.X; x < settings.X + settings.Width; x++) {
                SetSafe(x, y, settings.Color);
            }
        }
    }

    public void DrawTexture(int x, int y, Texture texture, bool safe = true)
    {
        for (int i = y; i < y + texture.Height; i++) {
            for (int j = x; j < x + texture.Width; j++) {
                if (safe)
                    SetSafe(j, i, texture.Frame[i - y][j - x]);
                else
                    Set(j, i, texture.Frame[i - y][j - x]);
            }
        }
    }
}
