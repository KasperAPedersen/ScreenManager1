using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenManager1
{
    internal class Box : Object
    {
        private int currentHeight = 0;

        public Box(Parent _parent, Pos _pos, int _width, int _height) : base(_parent, _pos, _width, _height)
        {
            if (this.Width >= this.GetParent.width) this.Width = this.GetParent.width - 4;
            if (this.Height >= this.GetParent.height) this.Height = this.GetParent.height - 2;

            // Set Top border of box
            Render.Write(new Pos(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++), string.Concat(Border(Get.TopLeft) + string.Concat(Enumerable.Repeat(Border(Get.Horizontal), this.Width - 2)) + Border(Get.TopRight)));

            // Set Top border of box
            if (this.Height < 3) this.Height = 3;
            for (int i = 0; i < this.Height - 2; i++)
            {
                Render.Write(new Pos(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++), string.Concat(Border(Get.Vertical) + string.Concat(Enumerable.Repeat(" ", this.Width - 2)) + string.Concat(Border(Get.Vertical))));
            }

            // Set Top border of box
            Render.Write(new Pos(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++), string.Concat(Border(Get.BottomLeft) + string.Concat(Enumerable.Repeat(Border(Get.Horizontal), this.Width - 2)) + Border(Get.BottomRight)));
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
