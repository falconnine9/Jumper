/* Keyboard
 * 
 * Utilities for getting keyboard input or controllers
 * for the keyboard
 */

namespace Jumper.Utils;

class Keyboard
{
    private static List<ConsoleKey> _statePoll = new();

    public static bool IsKeyPressed(ConsoleKey k)
    {
        foreach (ConsoleKey key in _statePoll) {
            if (k == key)
                return true;
        }
        return false;
    }

    public static void GetState()
    {
        _statePoll.Clear();

        while (Console.KeyAvailable)
            _statePoll.Add(Console.ReadKey(true).Key);
    }

    public static void ClearKeyBuffer()
    {
        while (Console.KeyAvailable)
            _ = Console.ReadKey(true);
    }
}
