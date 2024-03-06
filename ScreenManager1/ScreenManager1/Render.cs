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
        internal static void Write(int _x, int _y, string text = "", ConsoleColor _color = ConsoleColor.White)
        {
            SetPos(_x, _y);
            char[] tmp = text.ToCharArray();
            Console.ForegroundColor = _color;
            for (int i = 0; i < tmp.Length; i++)
            {
                if (tmp[i].ToString() == "[")
                {
                    if (tmp[i+1].ToString() == "/")
                    {
                        i += 3;
                        Console.ForegroundColor = _color;
                    } 
                    else
                    {
                        switch (tmp[i + 1].ToString())
                        {
                            case "r":
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            case "g":
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case "b":
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                            case "w":
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                        }
                        Console.Write(tmp[i += 3]);
                    }
                } 
                else
                {
                    Console.Write(tmp[i]);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        internal static void Remove(int _x, int _y, int _width, int _height)
        {
            for(int i = 0; i < _height; i++)
            {
                Write(_x, _y + i, string.Concat(Enumerable.Repeat(" ", _width)));
            }
        }
    }
}
