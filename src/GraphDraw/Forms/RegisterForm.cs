using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GraphDraw
{
    public partial class RegisterForm : Form
    {
        Register reg;
        string acode;

        public RegisterForm()
        {
            InitializeComponent();            
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (acode == actCode.Text)
            {
                reg.WriteActCode();
                MessageBox.Show("Activation Complete!\nYou must restart the program to take effect!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Bad activation code! Try again!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            reg = new Register();
            regCode.Text = Settings.regNumber;
            acode = reg.GenerateActivationCode(regCode.Text);

            if (Settings.shdays != -1)
            {
                label4.Text = Settings.shdays.ToString() + " day(s) remaining";
            }
            else
            {
                label4.Text = "Trial period expired!";
            }
        }
    }
}