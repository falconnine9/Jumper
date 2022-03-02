/* Keyboard
 * 
 * Utilities for getting keyboard input or controllers
 * for the keyboard
 */

namespace Jumper.Utils;

class Keyboard
{
    public static bool IsKeyPressed(ConsoleKey key_num)
    {
        if (Console.KeyAvailable) {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == key_num)
                return true;
        }
        return false;
    }
}
