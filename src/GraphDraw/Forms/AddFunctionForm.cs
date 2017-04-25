using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GraphDraw
{
    public partial class AddFunctionForm : Form
    {
        public AddFunctionForm()
        {
            InitializeComponent();

            label1.Text = FStatic.NextName() + " : y =";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Function newFunction = new Function(mainInput.Text);
           
            if (newFunction.itsOk)
            {
                FStatic.Add(newFunction);
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}