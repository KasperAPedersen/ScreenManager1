using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenManager1
{
    internal class Render
    {
        internal static void SetPos(Pos _pos)
        {
            Console.SetCursorPosition(_pos.x, _pos.y);
        }
        

        internal static void Write(Pos _pos, string text = "", ConsoleColor _color = ConsoleColor.White, List<Style>? _styles = null)
        {
            SetPos(_pos);
            char[] tmp = text.ToCharArray();
            for (int i = 0; i < tmp.Length; i++)
            {
                if(_styles != null)
                {
                    string styling = "";
                    foreach(Style s in _styles)
                    {
                        styling += $"\u001b[{(int)s}m";
                    }
                    Console.ForegroundColor = _color;
                    Console.Write($"{styling}{tmp[i]}\u001b[0m");
                }
                else if (tmp[i].ToString() == "[")
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

        internal static void Remove(Pos _pos, int _width, int _height)
        {
            for(int i = 0; i < _height; i++)
            {
                Write(new Pos(_pos.x, _pos.y + i), string.Concat(Enumerable.Repeat(" ", _width)));
            }
        }
    }
}
