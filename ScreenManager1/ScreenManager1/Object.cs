using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenManager1
{
    internal class Object
    {
        public struct Parent
        {
            public int x;
            public int y;
            public int width;

            public Parent(int x, int y, int width)
            {
                this.x = x;
                this.y = y;
                this.width = width;
            }
        }

        private static List<Parent> parents = new List<Parent>();
        private Parent parent;
        private int x, y, width, height;

        public int GetX { get { return x; } }
        public int GetY { get { return y; } }
        public int GetWidth { get { return width; } }
        public int GetHeight { get { return height; } }
        public Parent GetParent { get { return parent; } }
        

        public Object(int _x, int _y, int _width, int _height)
        {
            this.x = _x;
            this.y = _y;
            this.width = _width;
            this.height = _height;
            parent = parents.Any() ? parents.Last() : new Parent(0, 0, 0);
            parents.Add(new Parent(x, y, width));
        }

        internal void Remove()
        {
            if(parents.Any()) parents.RemoveAt(parents.Count - 1);
        }
    }
}