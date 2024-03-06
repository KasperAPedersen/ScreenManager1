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
        private readonly int currentHeight = 0;

        public Button(Parent _parent, Pos _pos, int _padding, string _text, ConsoleColor _color = ConsoleColor.White) : base(_parent, _pos, _text.Length + (_padding * 2), 3)
        {
            if (this.Width >= this.GetParent.width) this.Width = this.GetParent.width - 4;
            if (this.Height >= this.GetParent.height) this.Height = this.GetParent.height - 2;
            this.X = _parent.width - _text.Length - (_padding * 2) - 4;

            string text = string.Concat(Enumerable.Repeat(" ", _padding)) + _text + string.Concat(Enumerable.Repeat(" ", _padding));

            // Set Top Global.Border of box
            Render.Write(new Pos(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++), Global.Style(Global.Border(Get.TopLeft) + string.Concat(Enumerable.Repeat(Global.Border(Get.Horizontal), this.Width)) + Global.Border(Get.TopRight), Color.White), _color);

            // Set Top Global.Border of box
            Render.Write(new Pos(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++), Global.Style(string.Concat(Global.Border(Get.Vertical) + text + string.Concat(Global.Border(Get.Vertical))), Color.White), _color);

            // Set Top Global.Border of box
            Render.Write(new Pos(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++), Global.Style(Global.Border(Get.BottomLeft) + string.Concat(Enumerable.Repeat(Global.Border(Get.Horizontal), this.Width)) + Global.Border(Get.BottomRight), Color.White), _color);
        }
    }
}
