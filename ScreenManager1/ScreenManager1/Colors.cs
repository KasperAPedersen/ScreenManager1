using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenManager1
{
    internal class Colors
    {
        internal static string Set(string _text, char _char)
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
}
