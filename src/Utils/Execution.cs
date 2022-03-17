/* Execution
 * 
 * Utilities for controlling the execution of the programing
 * like the wait function for precise wait times
 */

using System.Diagnostics;

namespace Jumper.Utils;

class Execution
{
    public static void Wait(int ms)
    {
        var sw = Stopwatch.StartNew();
        while (sw.ElapsedMilliseconds < ms)
            Thread.Sleep(1);
    }
}
