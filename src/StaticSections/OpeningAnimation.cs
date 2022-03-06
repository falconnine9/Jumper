/* OpeningAnimation
 * 
 * Methods for running the opening animation with the
 * moving borders
 */

using System.Diagnostics;

using Jumper.Utils;

namespace Jumper.StaticSections;

class OpeningAnimation
{
    public static void Start()
    {
        Console.Clear();

        int t_line = Constants.FrameHeight / 3;
        int l_line = Constants.FrameWidth / 3;
        int b_line = (int)Math.Round(Constants.FrameHeight / 1.5);
        int r_line = (int)Math.Round(Constants.FrameWidth / 1.5);

        while (true) {
            var st = Stopwatch.StartNew();

            if (t_line > 0)
                t_line -= 1;

            if (b_line < Constants.FrameHeight - 1)
                b_line += 1;

            if (l_line > 0)
                l_line -= 1;

            if (r_line < Constants.FrameWidth - 1)
                r_line += 1;

            Jumper.Window.Fill(255);

            Jumper.Window.SetRow(t_line, Constants.BorderColor);
            Jumper.Window.SetRow(b_line, Constants.BorderColor);

            Jumper.Window.SetColumn(l_line, Constants.BorderColor);
            Jumper.Window.SetColumn(r_line, Constants.BorderColor);

            Jumper.Window.PushToConsole();
            Execution.Wait(Math.Abs((int)(1000 / Constants.FrameRate - st.ElapsedMilliseconds)));
            st.Stop();

            if (t_line <= 0 && b_line >= Constants.FrameHeight - 1 && l_line <= 0 && r_line >= Constants.FrameWidth - 1)
                break;
        }

        Keyboard.ResetKeyboardState();
    }
}
