using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenManager1
{
    internal class ComboBox : Object
    {
        bool keepRunning = true;
        private int currentHeight = 0;
        private readonly string[] options = ["Mr.", "Mrs.", "Ms."];
        private int active = 0;
        private string chosenOption = "Mr.";

        public string Chosen { get { return chosenOption; } }

        public ComboBox(Parent _parent, int _x, int _y, int _width, int _height) : base(_parent, _x, _y, _width, _height)
        {
            string text = Border(Get.TopLeft) + string.Concat(Enumerable.Repeat(Border(Get.Horizontal), this.Width - 7)) + Border(Get.TopRight);
            text += Border(Get.TopLeft) + string.Concat(Enumerable.Repeat(Border(Get.Horizontal), 3)) + Border(Get.TopRight);
            Render.Write(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++, text);

            // Set Top border of box
            if (this.Height < 3) this.Height = 3;
            for (int i = 0; i < this.Height - 2; i++)
            {
                text = string.Concat(Border(Get.Vertical) + string.Concat(Enumerable.Repeat(" ", this.Width - 7)) + string.Concat(Border(Get.Vertical)));
                text += Border(Get.Vertical) + Aligner.Align(Border(Get.Cross), Alignment.Center, 3, " ") + Border(Get.Vertical);
                Render.Write(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++, text);
            }

            // Set Top border of box
            text = string.Concat(Border(Get.BottomLeft) + string.Concat(Enumerable.Repeat(Border(Get.Horizontal), this.Width - 7)) + Border(Get.BottomRight));
            text += Border(Get.BottomLeft) + string.Concat(Enumerable.Repeat(Border(Get.Horizontal), 3)) + Border(Get.BottomRight);
            Render.Write(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++, text);
        }

        internal void Run()
        {
            BuildComboBox();

            while(keepRunning)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.CursorVisible = false;

                switch(Console.ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        chosenOption = options[active];
                        keepRunning = false;
                        break;
                    case ConsoleKey.UpArrow:
                        this.active = this.active <= 0 ? this.options.Length - 1 : this.active - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        this.active = this.active >= options.Length - 1 ? 0 : this.active + 1;
                        break;
                    default:
                        break;
                }

                currentHeight = currentHeight - options.Length - 2;
                if (!keepRunning)
                {
                    RemoveComboBox();
                }
                else
                {
                    BuildComboBox();
                }
            }
        }

        internal void BuildComboBox()
        {
            string text = Border(Get.TopLeft) + string.Concat(Enumerable.Repeat(Border(Get.Horizontal), this.Width - 2)) + Border(Get.TopRight);
            Render.Write(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++, text);

            for(int i = 0; i < this.options.Length; i++)
            {
                text = Border(Get.Vertical) + Aligner.Align(this.options[i], Alignment.Center, this.Width - 2, " ") + Border(Get.Vertical);
                Render.Write(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++, text, active == i ? ConsoleColor.Red : ConsoleColor.White);
            }

            text = Border(Get.BottomLeft) + string.Concat(Enumerable.Repeat(Border(Get.Horizontal), this.Width - 2)) + Border(Get.BottomRight);
            Render.Write(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++, text);
        }

        internal void RemoveComboBox()
        {
            Render.Remove(this.GetParent.x + this.X, this.GetParent.y + this.Y + 3, this.Width, this.Height + options.Length);
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

        internal string Border(Get _part)
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
                _ => throw new InvalidOperationException("Unknown border part."),
            };
        }
    }
}
