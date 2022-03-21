/* Entity
 * 
 * A general use object for storing entites that exist
 * throughout the game. Like bullets and the balloon
 */

using Jumper.UI;

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

    public bool CollidingWith(Entity entity)
    {
        bool colliding_x;
        bool colliding_y;

        if (Frame.Width < entity.Frame.Width)
            colliding_x = (X >= entity.X && X <= entity.X2) || (X2 >= entity.X && X2 <= entity.X2);
        else
            colliding_x = (entity.X >= X && entity.X <= X2) || (entity.X2 >= X && entity.X2 <= X2);

        if (Frame.Height < entity.Frame.Height)
            colliding_y = (Y >= entity.Y && Y <= entity.Y2) || (Y2 >= entity.Y && Y2 <= entity.Y2);
        else
            colliding_y = (entity.Y >= Y && entity.Y <= Y2) || (entity.Y2 >= Y && entity.Y2 <= Y2);

        return colliding_x && colliding_y;
    }
}
