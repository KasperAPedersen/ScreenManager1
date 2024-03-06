using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ScreenManager1
{
    internal class Input
    {
        private static List<string> content = [];
        internal static void Run(Parent _parent, Pos _pos, bool edit = false, int currentActive = 0)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = true;

            content.Add(edit ? currentActive.ToString() : (Table.UserId + 1).ToString());

            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(_parent.x + _pos.x + 2, _parent.y + _pos.y + (i * 3) + 1);
                string tmp = "";
                bool keepRunning = true;
                while (keepRunning && i != 6 - 1)
                {
                    if (tmp.Length < 15)
                    {
                        ConsoleKeyInfo input = Console.ReadKey();
                        switch (input.Key)
                        {
                            case ConsoleKey.Enter:
                                keepRunning = false;
                                break;
                            case ConsoleKey.Backspace:
                                if (tmp.Length > 0)
                                {
                                    tmp = tmp.Remove(tmp.Length - 1, 1);
                                    Render.Remove(new Pos(Console.CursorLeft, Console.CursorTop), 1, 1);
                                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                }
                                else
                                {
                                    Console.SetCursorPosition(_parent.x + _pos.x, _parent.y + (i * 3));
                                }
                                break;
                            default:
                                tmp += input.KeyChar;
                                break;
                        }
                    }
                    else
                    {
                        keepRunning = false;
                    }
                }
                Render.Write(new Pos(_parent.x + _pos.x + 2, _parent.y + _pos.y + (i*3) + 1), tmp);
                content.Add(tmp);
            }

            content.Add("Slet");
            content.Add("Edit");
            Console.CursorVisible = false;
        }

        internal static string[] Get(string _gender)
        {
            string[] aUserContent = new string[9];
            for (int i = 0; i < content.Count; i++)
            {
                aUserContent[i] = i == 6 ? _gender : content[i];
            }
            content = [];
            return aUserContent;
        }
    }
}
