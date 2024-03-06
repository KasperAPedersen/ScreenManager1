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

        public ComboBox(Parent _parent, Pos _pos, int _width, int _height) : base(_parent, _pos, _width, _height)
        {
            string text = Global.Border(Get.TopLeft) + string.Concat(Enumerable.Repeat(Global.Border(Get.Horizontal), this.Width - 7)) + Global.Border(Get.TopRight);
            text += Global.Border(Get.TopLeft) + string.Concat(Enumerable.Repeat(Global.Border(Get.Horizontal), 3)) + Global.Border(Get.TopRight);
            Render.Write(new Pos(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++), text);

            // Set Top Global.Border of box
            if (this.Height < 3) this.Height = 3;
            for (int i = 0; i < this.Height - 2; i++)
            {
                text = string.Concat(Global.Border(Get.Vertical) + string.Concat(Enumerable.Repeat(" ", this.Width - 7)) + string.Concat(Global.Border(Get.Vertical)));
                text += Global.Border(Get.Vertical) + Aligner.Align(Global.Border(Get.ArrowDown), Alignment.Center, 3, " ") + Global.Border(Get.Vertical);
                Render.Write(new Pos(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++), text);
            }

            // Set Top Global.Border of box
            text = string.Concat(Global.Border(Get.BottomLeft) + string.Concat(Enumerable.Repeat(Global.Border(Get.Horizontal), this.Width - 7)) + Global.Border(Get.BottomRight));
            text += Global.Border(Get.BottomLeft) + string.Concat(Enumerable.Repeat(Global.Border(Get.Horizontal), 3)) + Global.Border(Get.BottomRight);
            Render.Write(new Pos(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++), text);
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
            string text = Global.Border(Get.TopLeft) + string.Concat(Enumerable.Repeat(Global.Border(Get.Horizontal), this.Width - 2)) + Global.Border(Get.TopRight);
            Render.Write(new Pos(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++), Global.Style(text, Color.White));

            for(int i = 0; i < this.options.Length; i++)
            {
                text = Global.Style(Global.Border(Get.Vertical), Color.White) + Aligner.Align(active == i ? $"> {this.options[i]}" : this.options[i], Alignment.Center, this.Width - 2, " ") + Global.Style(Global.Border(Get.Vertical), Color.White);
                Render.Write(new Pos(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++), text);
            }

            text = Global.Border(Get.BottomLeft) + string.Concat(Enumerable.Repeat(Global.Border(Get.Horizontal), this.Width - 2)) + Global.Border(Get.BottomRight);
            Render.Write(new Pos(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++), Global.Style(text, Color.White));
        }

        internal void RemoveComboBox()
        {
            Render.Remove(new Pos(this.GetParent.x + this.X, this.GetParent.y + this.Y + 3), this.Width, this.Height + options.Length);
        }
    }
}
