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
        

        internal static void Write(Pos _pos, string text = "", ConsoleColor _color = ConsoleColor.White, Style _style = Style.None)
        {
            SetPos(_pos);
            char[] tmp = text.ToCharArray();
            for (int i = 0; i < tmp.Length; i++)
            {
                if(_style != Style.None)
                {
                    Console.ForegroundColor = _color;
                    string styling = "";
                    switch (_style)
                    {
                        case Style.Bold:
                            styling = "\u001b[1m";
                            break;
                        case Style.Italic:
                            styling = "\u001b[3m";
                            break;
                        case Style.Underline:
                            styling = "\u001b[4m";
                            break;
                        default:
                            break;
                    }
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
