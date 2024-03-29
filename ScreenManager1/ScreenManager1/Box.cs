﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenManager1
{
    internal class Box : Object
    {
        private readonly int currentHeight = 0;

        public Box(Parent _parent, Pos _pos, int _width, int _height) : base(_parent, _pos, _width, _height)
        {
            if (this.Width >= this.GetParent.width) this.Width = this.GetParent.width - 4;
            if (this.Height >= this.GetParent.height) this.Height = this.GetParent.height - 2;

            Render.Write(new Pos(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++), string.Concat(Global.Border(Get.TopLeft) + string.Concat(Enumerable.Repeat(Global.Border(Get.Horizontal), this.Width - 2)) + Global.Border(Get.TopRight)));

            if (this.Height < 3) this.Height = 3;
            for (int i = 0; i < this.Height - 2; i++)
            {
                Render.Write(new Pos(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++), string.Concat(Global.Border(Get.Vertical) + string.Concat(Enumerable.Repeat(" ", this.Width - 2)) + string.Concat(Global.Border(Get.Vertical))));
            }

            Render.Write(new Pos(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++), string.Concat(Global.Border(Get.BottomLeft) + string.Concat(Enumerable.Repeat(Global.Border(Get.Horizontal), this.Width - 2)) + Global.Border(Get.BottomRight)));
        }
    }
}
