﻿/* Bullets
 * 
 * General methods for the game loop. Such as bullet physics
 * and creating new bullets
 */

using Jumper.GameObjects;
using Jumper.Graphics;

namespace Jumper.Gameloop;

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
        }

        foreach (Entity bullet in to_destroy)
            _ = GameMain.BulletList.Remove(bullet);
    }

    public static Entity MakeNewBullet()
    {
        int direction = Jumper.RndGenerator.Next(0, 2);
        
        int y_pos = Jumper.RndGenerator.Next(0, Constants.FrameHeight - Texture.BulletLeft.Height);
        int x_pos = direction == 0
            ? -Texture.BulletLeft.Width
            : Constants.FrameWidth + Texture.BulletLeft.Width - 1;

        int velocity = (int)Math.Floor(direction == 0 ? GameMain.BulletSpeed : -GameMain.BulletSpeed);
        Texture texture = direction == 0 ? Texture.BulletRight : Texture.BulletLeft;

        return new Entity(texture, x_pos, y_pos, velocity, 0);
    }
}