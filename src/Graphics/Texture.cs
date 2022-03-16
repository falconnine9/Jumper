/* Texture
 * 
 * Stores complex textures and includes functions for loading
 * them from files
 * 
 * A texture is split vertically by newlines and horizontally
 * by commas.
 * 
 * Some examples of textures can be found in the
 * textures folder at the root of the repository
 */

using System.Text;

namespace Jumper.Graphics;

class Texture
{
    public static Texture Balloon { get; } = ReadTextureFile("balloon.texture");
    public static Texture BalloonBroken { get; } = ReadTextureFile("balloon-broken.texture");
    public static Texture BulletLeft { get; } = ReadTextureFile("bullet-left.texture");
    public static Texture BulletRight { get; } = ReadTextureFile("bullet-right.texture");
    public static Texture Paused { get; } = ReadTextureFile("paused.texture");
    public static Texture Dead { get; } = ReadTextureFile("dead.texture");

    public int Width { get; }
    public int Height { get; }
    public string FileName { get; }
    public byte[][] Frame { get; }

    public Texture(int w, int h, string file, byte[][] frame)
    {
        Width = w;
        Height = h;
        FileName = file;
        Frame = frame;
    }

    public static Texture ReadTextureFile(string file)
    {
        string[] lines = File.ReadAllLines(Directory.GetCurrentDirectory() + "/textures/" + file);
        List<byte[]> matrix = new();

        foreach (string line in lines) {
            List<byte> buffer = new();

            foreach (char c in line)
                buffer.Add((byte)(ConsoleFrame.Scale.IndexOf(c) << 2));

            matrix.Add(buffer.ToArray());
        }

        return new Texture(matrix[0].Length, matrix.Count, file, matrix.ToArray());
    }
}
