using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatePattern
{
    public partial class FORM_State : Form
    {
        public enum LightState {Green, Yellow, Red };
        public LightState CurrentState = LightState.Green;
        public int timeElapsed = 0;
        public FORM_State()
        {
            InitializeComponent();
            StateChanged();
            TimeElapsedLabel();
        }
        private void StateChanged()
        {
            string color = "";
            switch (CurrentState)
            {
                case LightState.Green:
                    color = "Green";
                    PNL_Light.BackColor = Color.Green;
                    break;
                case LightState.Yellow:
                    color = "Yellow";
                    PNL_Light.BackColor = Color.Yellow;
                    break;
                case LightState.Red:
                    color = "Red";
                    PNL_Light.BackColor = Color.Red;
                    break;
                default:
                    color = "NULL";
                    PNL_Light.BackColor = Color.Black;
                    break;
            }
            LBL_State.Text = "Street Light changed to: " + color;
        }
        private void BTN_State_Click(object sender, EventArgs e)
        {
            TimeElapsedLabel();
            timeElapsed = 0;
            TIMER_State.Stop();
            TIMER_State.Start();
            switch(CurrentState)
            {
                case LightState.Green:
                    CurrentState = LightState.Yellow;
                    StateChanged();
                    break;
                case LightState.Yellow:
                    CurrentState = LightState.Red;
                    StateChanged();
                    break;
                case LightState.Red:
                    CurrentState = LightState.Green;
                    StateChanged();
                    break;
                default:
                    break;
            }
        }
        private void TimeElapsedLabel()
        {
            LBL_Timer.Text = "Timer: " + ((double)(20 + timeElapsed) / 10) + "s";
        }
        private void TIMER_State_Tick(object sender, EventArgs e)
        {
            timeElapsed -= 1;
            TimeElapsedLabel();
            if (timeElapsed <= -20) BTN_State_Click(sender, e);
        }
    }
}
