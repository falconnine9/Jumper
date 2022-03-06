/* Entity
 * 
 * A general use object for storing entites that exist
 * throughout the game. Like bullets and the balloon
 */

using Jumper.Graphics;

namespace Jumper.GameObjects;

class Entity
{
    public Texture Frame { get; }
    public int X { get; set; }
    public int Y { get; set; }

    public double XVelocity { get; set; }
    public double YVelocity { get; set; }

    public int X2 => X + Frame.Width;
    public int Y2 => Y + Frame.Height - 1;

    public bool Up => XVelocity < 0;
    public bool Down => YVelocity > 0;
    public bool Left => XVelocity < 0;
    public bool Right => XVelocity > 0;

    public Entity(Texture texture, int x, int y, double xv, double yv)
    {
        Frame = texture;
        X = x;
        Y = y;
        XVelocity = xv;
        YVelocity = yv;
    }
}
