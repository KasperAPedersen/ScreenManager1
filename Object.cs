using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenManager1
{
    internal class Object : Render
    {
        private int x, y, width, height;

        public int GetX { get { return x; } }
        public int GetY { get { return y; } }
        public int GetWidth { get { return width; } }
        public int GetHeight { get { return height; } }

        public Object(int _x, int _y, int _width, int _height)
        {
            this.x = _x;
            this.y = _y;
            this.width = _width;
            this.height = _height;

        }
    }
}
