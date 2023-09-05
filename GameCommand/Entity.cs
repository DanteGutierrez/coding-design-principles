using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCommand
{
    public class Entity : Panel
    {
        private int x = 0;
        private int y = 0;
        private string color = "black";
        public string Description { get; set; }

        public Entity(int width, int height, int x, int y, string color, string description)
        {
            base.Width = width;
            base.Height = height;
            this.x = x;
            this.y = y; // x & y should be more specific
            this.color = color;
            this.Description = description;
            base.Location = new System.Drawing.Point(x, y);
            base.BackColor = System.Drawing.Color.FromName(color);
        }
        public void Adjust(int x, int y)
        {
            this.x += x;
            this.y += y;
            base.Location = new System.Drawing.Point(this.x, this.y);
        }
        public void Color(string color)
        {
            this.color = color;
            base.BackColor = System.Drawing.Color.FromName(this.color);
        }
        public string GetColor()
        {
            return color;
        }
    }
}
