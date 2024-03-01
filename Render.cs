using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenManager1
{
    internal class Render
    {
        internal static void SetCursor(int _x, int _y)
        {
            Console.SetCursorPosition(_x, _y);
        }

        internal static void Write(int _x, int _y, string text = "")
        {
            SetCursor(_x, _y);
            string[] tmp = text.Split();
            for(int i = 0; i < tmp.Length; i++)
            {
                Console.WriteLine(tmp[i] + " ");
            }
        }
    }
}
