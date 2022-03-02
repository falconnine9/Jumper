/* InitialMessage
 * 
 * Methods for running the initial message about
 * resizing the console values
 */

using Jumper.Utils;

namespace Jumper.Sections;

class InitialMessage
{
    public static void Start()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;

        int iteration = 50;
        bool is_red = true;

        while (true) {
            Execution.Wait(10);

            if (iteration == 50) {
                if (is_red)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else
                    Console.ForegroundColor = ConsoleColor.Red;
                
                is_red = !is_red;
                iteration = 0;
                
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Please set your console font size to 5 and put it in full screen. Press space once you're ready");
            }

            if (Keyboard.IsKeyPressed(ConsoleKey.Spacebar)) {
                Console.ForegroundColor = ConsoleColor.White;
                break;
            }

            iteration++;
        }
    }
}
