using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenManager1
{
    internal class Label : Object
    {
        public Label(Parent _parent, int _x, int _y, int _padding, string _text) : base(_parent, _x, _y, _text.Length + _padding, 1)
        {
            // make padding
            Render.Write(this.GetParent.x + this.X, this.GetParent.y + this.Y, _text);
        }
    }
}
