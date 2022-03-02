/* Keyboard
 * 
 * Utilities for getting keyboard input or controllers
 * for the keyboard
 */

namespace Jumper.Utils;

class Keyboard
{
    private static List<ConsoleKeyInfo> _inputPoll = new();

    public static bool IsKeyPressed(ConsoleKey key_num)
    {
        while (Console.KeyAvailable) {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == key_num)
                return true;
            else
                _inputPoll.Add(key);
        }

        foreach (ConsoleKeyInfo key in _inputPoll) {
            if (key.Key == key_num) {
                _ = _inputPoll.Remove(key);
                return true;
            }
        }

        return false;
    }

    public static void ResetKeyboardState()
    {
        _inputPoll.Clear();
        while (Console.KeyAvailable)
            _ = Console.ReadKey(true);
    }
}
