using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ScreenManager1
{
    internal class Table : Object
    {
        private readonly string[] titles = ["ID", "Fornavn", "Efternavn", "EmailAdr", "Mobil", "Addresse", "Titel", "Slet", "Edit"];
        private readonly List<string[]> content = [];
        private readonly int fullWidth, paddingWidth;
        private int currentHeight = 0;
        private int activeSelector = 8;
        private int active = 0;
        private readonly int maxHeight = 28;
        private static int userID = 0;

        public int Active { get { return active; } }
        public int ActiveSelector { get { return activeSelector; } set { activeSelector = value; } }
        public static int UserId {  get { return userID; } }

        public Table (Parent _parent, Pos _pos, int _width, int _height) : base(_parent, _pos, _width, _height)
        {
            this.fullWidth = this.GetParent.width - this.GetParent.x;
            this.paddingWidth = this.fullWidth / this.titles.Length - 1;
            BuildHeader();
            BuildContent();
            BuildFooter();
            this.Height += this.currentHeight;
        }

        internal void BuildHeader()
        {
            string text = Global.Border(Get.TopLeft) + string.Concat(Enumerable.Repeat(Global.Border(Get.Horizontal), this.fullWidth - 2)) + Global.Border(Get.TopRight);
            Render.Write(new Pos(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++), text);

            text = Global.Border(Get.Vertical);
            foreach(string s in titles)
            {
                text += Aligner.Align(s, Alignment.Center, this.paddingWidth, " ");
                text += titles.Last() == s ? $" {Global.Border(Get.Vertical)}" : Global.Border(Get.Vertical);
            }
            Render.Write(new Pos(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++), text);

            text = Global.Border(Get.VerticalLeft) + string.Concat(Enumerable.Repeat(Global.Border(Get.Horizontal), this.fullWidth - 2)) + Global.Border(Get.VerticalRight);
            Render.Write(new Pos(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++), text);
        }

        internal void BuildFooter()
        {
            string text = Global.Border(Get.BottomLeft) + string.Concat(Enumerable.Repeat(Global.Border(Get.Horizontal), this.fullWidth - 2)) + Global.Border(Get.BottomRight);
            Render.Write(new Pos(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++), text);
        }

        internal void BuildContent()
        {
            if(content != null)
            {
                for(int i = 0; i < content.Count; i++)
                {
                    string text = Global.Border(Get.Vertical);
                    for(int o = 0; o < 9; o++)
                    {
                        if(active == i && this.activeSelector == o)
                        {
                            text += Global.Style($"{Aligner.Align("> " + content[i][o], Alignment.Center, this.paddingWidth, " ")}", Color.Red);
                        } else
                        {
                            text += Global.Style($"{Aligner.Align(content[i][o], Alignment.Center, this.paddingWidth, " ")}", Color.White);
                        }
                        text += o == 8 ? $" {Global.Border(Get.Vertical)}" : Global.Border(Get.Vertical);
                    }
                    Render.Write(new Pos(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++), text);
                }
            }
        }

        internal void Update(int _active, string[]? _content = null, bool edit = false)
        {
            Render.Remove(new Pos(this.GetParent.x + this.X, this.GetParent.y + this.Y), this.fullWidth, this.Height + this.currentHeight);

            if(_content != null && (content.Count - 1) < maxHeight)
            {
                if (edit)
                {
                    content[_active] = _content;
                } else
                {
                    Table.userID++;
                    content.Add(_content);
                }
            }

            if (_active != this.active) this.active = _active > content.Count - 1 ? 0 : (_active < 0 ? content.Count - 1 : _active);

            this.currentHeight = 0;
            BuildHeader();
            BuildContent();
            BuildFooter();
        }

        internal void Remove(int _active)
        {
            if (content != null && content.Count > 0)
            {
                content.RemoveAt(_active);
                if ((_active - 1) > 0)
                {
                    active = (active - 1 < 0 || active - 1 > content.Count - 1) ? 0 : --_active;
                }
                Update(active);
            }
        }
    }
}
