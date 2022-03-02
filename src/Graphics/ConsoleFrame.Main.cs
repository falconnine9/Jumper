/* ConsoleFrame
 * 
 * A 2D console based graphical interface utility
 * 
 * Works by creating a 2D byte array of brightness values that
 * are 0-255 (0 being black, 255 being white).
 * 
 * The values are converted to a character value using the scale
 * below. Since the scale is 64 characters long and the
 * brightness values can be between 0-255, the value is bit-
 * -shifted right by 2
 * 
 *   {
 *    {0, 255, 0, 255},
 *    {255, 0, 255, 0},
 *    {0, 255, 0, 255}
 *   }
 * 
 * is converted to
 * 
 *    $ $
 *   $ $
 *    $ $
 */

using System.Text;

namespace Jumper.Graphics;

partial class ConsoleFrame // ConsoleFrame.Main
{
    private static string _scale = "$@B%8&WM#*oahkbdpqwmZO0QLCJUYXzcvunxrjft/|()1{}[]?+-~i!Il;:,^.' ";

    public int Width { get => _width; set => _resizeFrame(value, _height); }
    public int Height { get => _height; set => _resizeFrame(_width, value); }

    private int _width;
    private int _height;
    private byte[] _frame;

    public ConsoleFrame(int width, int height)
    {
        _width = width;
        _height = height;
        _frame = new byte[width * height];
    }

    public byte Get(int x, int y)
    {
        if (x < 0 || y < 0 || x >= _width || y >= _height)
            return 0;
        else
            return _frame[y * _width + x];
    }

    public void Set(int x, int y, byte value)
    {
        if (x < 0 || y < 0 || x >= _width || y >= _height)
            return;
        else
            _frame[y * _width + x] = value;
    }

    public void PushToConsole()
    {
        StringBuilder buffer = new();

        for (int y = 0; y < _height; y++) {
            for (int x = 0; x < _width; x++) {
                _ = buffer.Append(_scale[Get(x, y) >> 2]);
            }
            _ = buffer.Append('\n');
        }

        Console.SetCursorPosition(0, 0);
        Console.Write(buffer.ToString());
    }

    private void _resizeFrame(int width, int height)
    {
        if (width == _width && height == _height)
            return;

        _width = width;
        _height = height;
        _frame = new byte[width * height];
    }
}
