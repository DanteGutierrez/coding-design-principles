using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCommand
{
    public partial class Form1 : Form
    {
        public List<ICommand> commands = new List<ICommand>();
        public Form1()
        {
            InitializeComponent();

            Entity entity = new Entity(50, 50, 0, 0, "Black", "obj 1");

            pnlGame.Controls.Add(entity);

            //Movement
            ICommand command = new MoveCommand(entity, "up", 0, -10);
            CustomButton btCust = new CustomButton(0, command);
            btCust.Click += new System.EventHandler(this.btCommand_Click);
            pnlControls.Controls.Add(btCust);

            command = new MoveCommand(entity, "down", 0, 10);
            btCust = new CustomButton(1, command);
            btCust.Click += new System.EventHandler(this.btCommand_Click);
            pnlControls.Controls.Add(btCust);

            command = new MoveCommand(entity, "left", -10, 0);
            btCust = new CustomButton(2, command);
            btCust.Click += new System.EventHandler(this.btCommand_Click);
            pnlControls.Controls.Add(btCust);

            command = new MoveCommand(entity, "right", 10, 0);
            btCust = new CustomButton(3, command);
            btCust.Click += new System.EventHandler(this.btCommand_Click);
            pnlControls.Controls.Add(btCust);

            //Color
            command = new ColorCommand(entity, "blue", "Blue");
            btCust = new CustomButton(10, command);
            btCust.Click += new System.EventHandler(this.btCommand_Click);
            pnlControls.Controls.Add(btCust);

            command = new ColorCommand(entity, "red", "Red");
            btCust = new CustomButton(11, command);
            btCust.Click += new System.EventHandler(this.btCommand_Click);
            pnlControls.Controls.Add(btCust);

            command = new ColorCommand(entity, "yellow", "Yellow");
            btCust = new CustomButton(12, command);
            btCust.Click += new System.EventHandler(this.btCommand_Click);
            pnlControls.Controls.Add(btCust);

            command = new ColorCommand(entity, "Green", "Green");
            btCust = new CustomButton(13, command);
            btCust.Click += new System.EventHandler(this.btCommand_Click);
            pnlControls.Controls.Add(btCust);
        }
        private void btCommand_Click(object sender, EventArgs e)
        {
            CustomButton cb = (CustomButton)sender; 
            cb.getCommand.Execute();
            commands.Add(cb.getCommand);
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if(commands.Count > 0)
            {
                ICommand lastCommand = commands[commands.Count - 1];
                lastCommand.Undo();
                commands.Remove(lastCommand);
            }
        }
    }
}
