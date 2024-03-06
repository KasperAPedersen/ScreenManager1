using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ScreenManager1.Box;

namespace ScreenManager1
{
    internal class Button : Object
    {
        private int currentHeight = 0;

        public Button(Parent _parent, Pos _pos, int _padding, string _text, ConsoleColor _color = ConsoleColor.White) : base(_parent, _pos, _text.Length + (_padding * 2), 3)
        {
            if (this.Width >= this.GetParent.width) this.Width = this.GetParent.width - 4;
            if (this.Height >= this.GetParent.height) this.Height = this.GetParent.height - 2;
            this.X = _parent.width - _text.Length - (_padding * 2) - 4;

            string text = string.Concat(Enumerable.Repeat(" ", _padding)) + _text + string.Concat(Enumerable.Repeat(" ", _padding));

            // Set Top border of box
            Render.Write(new Pos(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++), Border(Get.TopLeft) + string.Concat(Enumerable.Repeat(Border(Get.Horizontal), this.Width)) + Border(Get.TopRight), _color);

            // Set Top border of box
            Render.Write(new Pos(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++), string.Concat(Border(Get.Vertical) + text + string.Concat(Border(Get.Vertical))), _color);

            // Set Top border of box
            Render.Write(new Pos(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++), Border(Get.BottomLeft) + string.Concat(Enumerable.Repeat(Border(Get.Horizontal), this.Width)) + Border(Get.BottomRight), _color);
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
