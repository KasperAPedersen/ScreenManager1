using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenManager1
{
    internal class Label : Object
    {
        public Label(Parent _parent, int _x, int _y, int _padding, string _text, ConsoleColor _color = ConsoleColor.White) : base(_parent, _x, _y, _text.Length + _padding, 1)
        {
            // make padding
            string text = string.Concat(Enumerable.Repeat(" ", _padding)) + _text + string.Concat(Enumerable.Repeat(" ", _padding));
            Render.Write(this.GetParent.x + this.X, this.GetParent.y + this.Y, text, _color);
        }
    }
}
