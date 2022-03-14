/* Bullets
 * 
 * General methods for the game loop. Such as bullet physics
 * and creating new bullets
 */

using Jumper.GameObjects;
using Jumper.Graphics;

namespace Jumper.Game;

class Bullets
{
    public static void EvaluateBulletPhysics()
    {
        List<Entity> to_destroy = new();

        foreach (Entity bullet in GameMain.BulletList) {
            if (bullet.XVelocity != 0)
                bullet.X = (int)Math.Floor(bullet.X + bullet.XVelocity);

            if (bullet.X2 < 0 && bullet.Left)
                to_destroy.Add(bullet);
            else if (bullet.X >= Constants.FrameWidth && bullet.Right)
                to_destroy.Add(bullet);

            if (bullet.CollidingWith(GameMain.Player)) {
                GameMain.Failed = true;
                return;
            }
        }

        foreach (Entity bullet in to_destroy)
            _ = GameMain.BulletList.Remove(bullet);
    }

    public static void HandleBulletStages(ref double increment)
    {
        if (GameMain.BulletSpeed < Constants.TerminalVel)
            GameMain.BulletSpeed += Constants.BulletIncrement;

        increment += Constants.BulletIncrement / 2;
        if (increment >= GameMain.MaxBullets && GameMain.BulletList.Count < Constants.MaxBulletNum) {
            increment = 0;
            GameMain.MaxBullets += 1;
        }

        GameMain.BulletList.Add(MakeNewBullet());

        if (GameMain.Score < 999)
            GameMain.Score++;
    }

    public static Entity MakeNewBullet()
    {
        int direction = Jumper.RndGenerator.Next(0, 2);

        int y_pos = Jumper.RndGenerator.Next(1, Constants.FrameHeight - Texture.BulletLeft.Height);
        int x_pos = direction == 0
            ? -Texture.BulletLeft.Width
            : Constants.FrameWidth + Texture.BulletLeft.Width - 1;

        int velocity = (int)Math.Floor(GameMain.BulletSpeed) * (direction == 0 ? 1 : -1);
        Texture texture = direction == 0 ? Texture.BulletRight : Texture.BulletLeft;

        return new Entity(texture, x_pos, y_pos, velocity, 0);
    }
}