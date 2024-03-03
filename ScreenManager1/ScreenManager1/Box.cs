using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenManager1
{
    internal class Box : Object
    {
        public Box(int _x, int _y, int _width, int _height) : base(_x, _y, _width, _height)
        {
            // Set Top border of box
            Render.Write(this.GetParent.x + this.GetParent.width + this.GetX, this.GetParent.y + this.GetY, string.Concat(Border(Get.TopLeft) + string.Concat(Enumerable.Repeat(Border(Get.Horizontal), this.GetWidth - 2)) + Border(Get.TopRight)));

            // Set Top border of box
            

            // Set Top border of box
            Render.Write(this.GetParent.x + this.GetParent.width + this.GetX, this.GetParent.y + this.GetY + this.GetHeight, string.Concat(Border(Get.BottomLeft) + string.Concat(Enumerable.Repeat(Border(Get.Horizontal), this.GetWidth - 2)) + Border(Get.BottomRight)));
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
