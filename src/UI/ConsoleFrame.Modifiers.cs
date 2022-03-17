/* ConsoleFrame
 * 
 * A file explanation for the ConsoleFrame can be
 * found in ConsoleFrame.Main.cs
 */

namespace Jumper.UI;

partial class ConsoleFrame // ConsoleFrame.Modifiers
{
    public void Fill(byte value) => Array.Fill(_frame, value);

    public void SetRow(int y, byte value) => Array.Fill(_frame, value, y * _width, Constants.FrameWidth);

    public void SetColumn(int x, byte value)
    {
        if (x >= _width)
            return;

        for (int y = 0; y < Constants.FrameHeight; y++) {
            SetSafe(x, y, value);
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
