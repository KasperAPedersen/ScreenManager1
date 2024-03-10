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

        public Parent(Pos _pos, int _width, int _height)
        {
            this.x = _pos.x;
            this.y = _pos.y;
            this.width = _width;
            this.height = _height;
        }
    }

    internal class Object
    {
        private Parent parent;
        private Pos pos;
        private int width, height;

        public int X { get { return pos.x; } set { pos.x = value; } }
        public int Y { get { return pos.y; } set { pos.y = value; } }
        public int Width { get { return width; } set { width = value;  } }
        public int Height { get { return height; } set { height = value; } }
        public Parent GetParent { get { return parent; } }

        public Parent MakeParent
        {
            get
            {
                return new Parent(new Pos(this.GetParent.x + this.pos.x, this.GetParent.y + this.pos.y), this.width, this.height);
            }
        }

        public Object(Parent _parent, Pos _pos, int _width, int _height)
        {
            this.pos.x = _pos.x;
            this.pos.y = _pos.y;
            this.width = _width;
            this.height = _height;
            this.parent = _parent;
        }
    }
}