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
    public partial class CustomLabel : CustomControl
    {
        public CustomLabel(uint id, int controlWidth, Control control) : base(id, controlWidth, control)
        {
            Label lbl = new Label()
            {
                Text = "Label: ",
                Location = new Point(0, 5),
                Width = 80,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
            };
            Controls.Add(lbl);
        }
        public override Control GetControl()
        {
            return new Label()
            {
                Text = control.Text,
                Height = control.Height,
                Width = control.Width,
                Top = control.Top,
                Left = control.Left
            };
        }
    }
}
