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
        private string[] titles = ["ID", "Fornavn", "Efternavn", "EmailAdr", "Mobil", "Addresse", "Titel", "Slet", "Edit"];
        private List<string[]> content = [];
        private int fullWidth, paddingWidth;
        private int currentHeight = 0;
        private int active = 0;
        private int maxHeight = 28;
        private static int userID = 0;

        public int Active { get { return active; } }
        public static int UserId {  get { return userID; } }

        public Table (Parent _parent, int _x, int _y, int _width, int _height) : base(_parent, _x, _y, _width, _height)
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
            string text = Border(Get.TopLeft) + string.Concat(Enumerable.Repeat(Border(Get.Horizontal), this.fullWidth - 2)) + Border(Get.TopRight);
            Render.Write(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++, text);

            text = Border(Get.Vertical);
            foreach(string s in titles)
            {
                text += Aligner.Align(s, Alignment.Center, this.paddingWidth, " ");
                text += titles.Last() == s ? $" {Border(Get.Vertical)}" : Border(Get.Vertical);
            }
            Render.Write(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++, text);

            text = Border(Get.VerticalLeft) + string.Concat(Enumerable.Repeat(Border(Get.Horizontal), this.fullWidth - 2)) + Border(Get.VerticalRight);
            Render.Write(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++, text);
        }

        internal void BuildFooter()
        {
            string text = Border(Get.BottomLeft) + string.Concat(Enumerable.Repeat(Border(Get.Horizontal), this.fullWidth - 2)) + Border(Get.BottomRight);
            Render.Write(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++, text);
        }

        internal void BuildContent()
        {
            if(content != null)
            {
                for(int i = 0; i < content.Count; i++)
                {
                    string text = Border(Get.Vertical);
                    for(int o = 0; o < 9; o++)
                    {
                        text += Aligner.Align(content[i][o], Alignment.Center, this.paddingWidth, " ");
                        text += o == 8 ? $" {Border(Get.Vertical)}" : Border(Get.Vertical);
                    }
                    Render.Write(this.GetParent.x + this.X, this.GetParent.y + this.Y + currentHeight++, text, active == i ? ConsoleColor.Red : ConsoleColor.White);
                }
            }
        }

        internal void Update(int _active, string[]? _content = null)
        {
            Render.Remove(this.GetParent.x + this.X, this.GetParent.y + this.Y, this.fullWidth, this.Height + this.currentHeight);

            if(_content != null && (content.Count - 1) < maxHeight)
            {
                Table.userID++;
                content.Add(_content);
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
                if ((_active - 1) > 0) active = --_active;
                Update(active);
            }
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
