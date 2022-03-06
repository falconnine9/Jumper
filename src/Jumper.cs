/* Jumper
 * A game about a balloon trying to dodge a bullet
 * 
 *  ----------------------------
 * 
 * Licensed under the GNU General Public License v3.0.
 * You should have been provided with a copy of the
 * license, but if not, go to
 * <https://gnu.org/licenses> for accessing and
 * copying permissions
 * 
 * ----------------------------
 * 
 * Playing the game
 * 
 * To download the game, go to the releases section of
 * the repository and download the latest version for
 * the system you're on
 * 
 * Initially you will be greeted with a message to set
 * your console font to 5. To do this, go to
 * Properties > Font and set the value to 5. Then put
 * your console in full screen to avoid unnecessary
 * line breaks
 * 
 * Don't hit the edges of the map, don't get hit by a
 * bullet, try to survive as long as possible
 */

using Jumper.Gameloop;
using Jumper.Graphics;
using Jumper.StaticSections;

namespace Jumper;

class Jumper
{
    public static ConsoleFrame Window { get; } = new(Constants.FrameWidth, Constants.FrameHeight);
    public static Random RndGenerator { get; } = new Random();

    public static void Main()
    {
        _setConsoleProperties();

        InitialMessage.Start();
        OpeningAnimation.Start();
        GameMain.Start();
    }

    private static void _setConsoleProperties() => Console.CursorVisible = false;
}