/* Square
 * 
 * The settings for a graphically drawable square
 */

namespace Jumper.Graphics;

class Square
{
    public int X { get; }
    public int Y { get; }
    public int Width { get; }
    public int Height { get; }
    public byte Color { get; }

    public Square(int x, int y, int w, int h, byte color)
    {
        X = x;
        Y = y;
        Width = w;
        Height = h;
        Color = color;
    }
}
