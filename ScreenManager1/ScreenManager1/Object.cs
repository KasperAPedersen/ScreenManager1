using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenManager1
{
    public struct Parent
    {
        public int x;
        public int y;
        public int width;
        public int height;

        public Parent(int _x, int _y, int _width, int _height)
        {
            this.x = _x;
            this.y = _y;
            this.width = _width;
            this.height = _height;
        }
    }

    internal class Object
    {
        

        private Parent parent;
        private int x, y, width, height;

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public int Width { get { return width; } set { width = value;  } }
        public int Height { get { return height; } set { height = value; } }
        public Parent GetParent { get { return parent; } }

        public Parent MakeParent
        {
            get
            {
                return new Parent(this.GetParent.x + this.X, this.GetParent.y + this.Y, this.width, this.height);
            }
        }
        

        public Object(Parent _parent, int _x, int _y, int _width, int _height)
        {
            this.x = _x;
            this.y = _y;
            this.width = _width;
            this.height = _height;
            this.parent = _parent;
        }
    }
}