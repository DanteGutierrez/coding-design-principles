
namespace StatePattern
{
    partial class FORM_State
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BTN_State = new System.Windows.Forms.Button();
            this.LBL_State = new System.Windows.Forms.Label();
            this.PNL_Light = new System.Windows.Forms.Panel();
            this.TIMER_State = new System.Windows.Forms.Timer(this.components);
            this.LBL_Timer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BTN_State
            // 
            this.BTN_State.Location = new System.Drawing.Point(50, 220);
            this.BTN_State.Name = "BTN_State";
            this.BTN_State.Size = new System.Drawing.Size(200, 50);
            this.BTN_State.TabIndex = 0;
            this.BTN_State.Text = "Change State";
            this.BTN_State.UseVisualStyleBackColor = true;
            this.BTN_State.Click += new System.EventHandler(this.BTN_State_Click);
            // 
            // LBL_State
            // 
            this.LBL_State.AutoSize = true;
            this.LBL_State.Location = new System.Drawing.Point(50, 50);
            this.LBL_State.Name = "LBL_State";
            this.LBL_State.Size = new System.Drawing.Size(0, 29);
            this.LBL_State.TabIndex = 1;
            // 
            // PNL_Light
            // 
            this.PNL_Light.Location = new System.Drawing.Point(50, 100);
            this.PNL_Light.Name = "PNL_Light";
            this.PNL_Light.Size = new System.Drawing.Size(100, 100);
            this.PNL_Light.TabIndex = 2;
            // 
            // TIMER_State
            // 
            this.TIMER_State.Enabled = true;
            this.TIMER_State.Tick += new System.EventHandler(this.TIMER_State_Tick);
            // 
            // LBL_Timer
            // 
            this.LBL_Timer.AutoSize = true;
            this.LBL_Timer.Location = new System.Drawing.Point(50, 290);
            this.LBL_Timer.Name = "LBL_Timer";
            this.LBL_Timer.Size = new System.Drawing.Size(0, 29);
            this.LBL_Timer.TabIndex = 3;
            // 
            // FORM_State
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 371);
            this.Controls.Add(this.LBL_Timer);
            this.Controls.Add(this.PNL_Light);
            this.Controls.Add(this.LBL_State);
            this.Controls.Add(this.BTN_State);
            this.Name = "FORM_State";
            this.Text = "Street Light States";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_State;
        private System.Windows.Forms.Label LBL_State;
        private System.Windows.Forms.Panel PNL_Light;
        private System.Windows.Forms.Timer TIMER_State;
        private System.Windows.Forms.Label LBL_Timer;
    }
}

