using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace GraphDraw
{
    public partial class About : Form
    {
        private Thread mainThread;
        private System.Windows.Forms.Timer stopTimer;
        private System.Windows.Forms.Timer fadeTimerUp;
        private System.Windows.Forms.Timer fadeTimerDown;

        public double opacityIncrease = .05;
        public double opacityDecrease = .1;
        public int fadeIntervalUp;
        public int fadeIntervalDown;
        public int onTime;
        public bool autoClose;

        public About()
        {
            InitializeComponent();

            if (Settings.activated)
            {
                registerLabel1.Text = "Activated";
                registerLabelDays.Visible = false;
            }
            else
            {
                registerLabel1.Text = "Not activated";
                registerLabelDays.Text = Settings.shdays.ToString() + " day(s) remaining";
            }

            regCode.Text = Settings.regNumber;

            opacityIncrease = .05;
            opacityDecrease = .1;
            onTime = 2000;
            fadeIntervalUp = 50;
            fadeIntervalDown = 50;
            autoClose = true;

            mainThread = new Thread(new ThreadStart(DoSplash));
            mainThread.IsBackground = true;

            stopTimer = new System.Windows.Forms.Timer();
            stopTimer.Tick += new System.EventHandler(StopSplash);
            stopTimer.Interval = onTime;

            fadeTimerUp = new System.Windows.Forms.Timer();
            fadeTimerUp.Tick += new System.EventHandler(FadeHandlerUp);
            fadeTimerUp.Interval = fadeIntervalUp;

            fadeTimerDown = new System.Windows.Forms.Timer();
            fadeTimerDown.Tick += new System.EventHandler(FadeHandlerDown);
            fadeTimerDown.Interval = fadeIntervalDown;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:mdavid626@gmail.com");
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void About_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Opacity != 0) e.Cancel = true;
            fadeTimerDown.Start();
        }

        public void Start()
        {
            mainThread.Start();
        }

        private void DoSplash()
        {
            if (autoClose) stopTimer.Start();

            this.Opacity = 0;

            fadeTimerUp.Start();
            Application.Run(this);
        }

        private void StopSplash(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FadeHandlerUp(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += opacityIncrease;
            }
        } 

        private void FadeHandlerDown(object sender, EventArgs e)
        {
            if (this.Opacity >= 0)
            {
                this.Opacity -= opacityDecrease;
            }

            if (this.Opacity == 0) this.Close();
        }
    }
}