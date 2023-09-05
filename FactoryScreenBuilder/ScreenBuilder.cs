using FactoryScreenBuilder.Factory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FactoryScreenBuilder
{
    public partial class ScreenBuilder : Form
    {
        uint num = 0;
        public ScreenBuilder()
        {
            InitializeComponent();
        }

        private void BTN_ADD_BTN_Click(object sender, EventArgs e)
        {
            PNL_CONTROLS.Controls.Add(new CustomButton(num, PNL_CONTROLS.Width - 30, new Control()));
            num++;
        }

        private void BTN_ADD_LBL_Click(object sender, EventArgs e)
        {
            PNL_CONTROLS.Controls.Add(new CustomLabel(num, PNL_CONTROLS.Width - 30, new Control()));
            num++;
        }
        private void BTN_UNDO_Click(object sender, EventArgs e)
        {
            if (PNL_CONTROLS.Controls.Count < 1) return;
            PNL_CONTROLS.Controls.RemoveAt(PNL_CONTROLS.Controls.Count - 1);
            num--;
        }

        private void BTN_EXPORT_HTML_Click(object sender, EventArgs e)
        {
            List<Control> controls = new List<Control>();
            foreach(Control control in PNL_CONTROLS.Controls)
            {
                controls.Add(((CustomControl)control).GetControl());
            }
            IFactory factory = Factory.Factory.GetFactory(FactoryType.HTML);
            factory.Build("controls", controls);
        }

        private void BTN_EXPORT_JSON_Click(object sender, EventArgs e)
        {
            List<Control> controls = new List<Control>();

            // Preparing control list
            foreach (Control control in PNL_CONTROLS.Controls)
            {
                controls.Add(((CustomControl)control).GetControl());
            }

            // Asking factory for a factory
            IFactory factory = Factory.Factory.GetFactory(FactoryType.JSON);

            // Build (Save) controls
            factory.Build("controls", controls);
        }

        private void BTN_READ_HTML_Click(object sender, EventArgs e)
        {
            // Asking factory for factory
            IFactory factory = Factory.Factory.GetFactory(FactoryType.HTML);

            // Reading in a file for the controls
            List<Control> controls = factory.Read("controls");

            if (controls == null) return;

            num = (uint)controls.Count;
            PNL_CONTROLS.Controls.Clear();
            PNL_CONTROLS.Controls.AddRange(controls.ToArray());
        }

        private void BTN_READ_JSON_Click(object sender, EventArgs e)
        {
            IFactory factory = Factory.Factory.GetFactory(FactoryType.JSON);

            List<Control> controls = factory.Read("controls");

            if (controls == null) return;

            num = (uint)controls.Count;
            PNL_CONTROLS.Controls.Clear();
            PNL_CONTROLS.Controls.AddRange(controls.ToArray());
        }
    }
}
