using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenManager1
{
    internal class Render
    {
        internal static void SetPos(int _x, int _y)
        {
            Console.SetCursorPosition(_x, _y);
        }

        internal static void Write(int _x, int _y, string text = "")
        {
            SetPos(_x, _y);
            char[] tmp = text.ToCharArray();
            for (int i = 0; i < tmp.Length; i++) Console.Write(tmp[i]);
        }
    }
}
