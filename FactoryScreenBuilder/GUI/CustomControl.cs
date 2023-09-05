using FactoryScreenBuilder.Factory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FactoryScreenBuilder
{
    public abstract partial class CustomControl : Panel
    {
        protected Control control;
        private int starter = 80;
        public CustomControl(uint id, int controlWidth, Control control) : base()
        {
            Width = controlWidth;
            Height = 30;
            BorderStyle = BorderStyle.FixedSingle;
            this.control = control;
            SetPosition(id);
            Setup("text", control.Text);
            Setup("height", control.Height.ToString());
            Setup("width", control.Width.ToString());
            Setup("top", control.Top.ToString());
            Setup("left", control.Left.ToString());
        }
        protected void SetPosition(uint id)
        {
            Point xyLoc;
            int xPos = 0;
            int yPos = (int)(base.Height * id);
            xyLoc = new Point(xPos, yPos);
            Location = xyLoc;
        }
        protected void Setup(string value, string initial)
        {
            Label lbl = new Label() {
                Text = value + ": ",
                Location = new Point(starter, 5),
                Width = 40
            };
            //lbl.Text = value + ": ";
            //lbl.Location = new System.Drawing.Point(starter, 5);
            //lbl.Width = 40;
            starter += lbl.Width;

            TextBox box = new TextBox()
            {
                Name = value,
                Location = new Point(starter, 5),
                Width = 40,
                Text = initial
            };
            //box.Name = value;
            box.TextChanged += OnChangedValue;
            //box.Width = 40;
            //box.Location = new System.Drawing.Point(starter, 5);

            starter += box.Width;

            Controls.Add(box);
            Controls.Add(lbl);
        }
        public void OnChangedValue(object sender, EventArgs e)
        {
            TextBox box = ((TextBox)sender);
            switch (box.Name)
            {
                case "text":
                    control.Text = box.Text;
                    break;
                case "height":
                    control.Height = int.Parse(box.Text);
                    break;
                case "width":
                    control.Width = int.Parse(box.Text);
                    break;
                case "top":
                    control.Top = int.Parse(box.Text);
                    break;
                case "left":
                    control.Left = int.Parse(box.Text);
                    break;
                default:
                    break;
            }
        }
        public virtual Control GetControl()
        {
            return control;
        }
    }
}
