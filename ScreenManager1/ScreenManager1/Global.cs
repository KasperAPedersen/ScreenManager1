using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ScreenManager1
{
    internal class Global
    {
        internal static int consoleWidth = Console.WindowWidth - 4;
        internal static int consoleHeight = Console.WindowHeight - 2;

        internal static string Style(string _text, char _char)
        {
            return $"[{_char}]{_text}[/{_char}]";
        }

        internal enum Get
        {
            Red,
            Blue,
            Green,
            White
        }

        internal static char Color(Get _color)
        {
            return _color switch
            {
                Get.Red => 'r',
                Get.Blue => 'b',
                Get.Green => 'g',
                Get.White => 'w',
                _ => throw new InvalidOperationException("Unknown Color."),
            };
        }
    }

    public enum Style
    {
        None = 0,
        Bold = 1,
        Italic = 3,
        Underline = 4,
        Reversed = 7,
        Blink = 5,
        DoubleUnderline = 21,

        BgBlack = 40,
        BgRed = 41,
        BgGreen = 42,
        BgYellow = 43,
        BgBlue = 44,
        BgMagenta = 45,
        BgCyan = 46,
        BgWhite = 47
    }

    public enum Padding {
        None = 0,
        Small = 2,
        Medium = 4,
        Large = 8
    }

    public struct Pos
    {
        public int x;
        public int y;

        public Pos(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    internal enum Get
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight,
        Horizontal,
        HorizontalDown,
        HorizontalUp,
        Vertical,
        VerticalLeft,
        VerticalRight,
        Cross
    }
}
