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

        internal static string Style(string _text, Color _color)
        {
            return $"\u001b[{(int)_color}m{_text}\u001b[0m";
        }

        internal static string Border(Get _part)
        {
            return _part switch
            {
                Get.TopLeft => "┌",
                Get.TopRight => "┐",
                Get.BottomLeft => "└",
                Get.BottomRight => "┘",
                Get.Horizontal => "─",
                Get.HorizontalDown => "┬",
                Get.HorizontalUp => "┴",
                Get.Vertical => "│",
                Get.VerticalLeft => "├",
                Get.VerticalRight => "┤",
                Get.Cross => "┼",
                _ => throw new InvalidOperationException("Unknown Global.Border part."),
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

    public enum Color
    {
        Black = 30,
        Red = 31,
        Green = 32,
        Yellow = 33,
        Blue = 34,
        Magenta = 35,
        Cyan = 36,
        White = 37
    }

    public enum Padding {
        None = 0,
        Small = 2,
        Medium = 4,
        Large = 8
    }

    public struct Pos(int x, int y)
    {
        public int x = x;
        public int y = y;
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
