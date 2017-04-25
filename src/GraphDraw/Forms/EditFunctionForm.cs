using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GraphDraw
{
    public partial class EditFunctionForm : Form
    {
        private Function f;

        public EditFunctionForm(Function f)
        {
            InitializeComponent();

            this.f = f;
            mainInput.Text = this.f.Text;
            label1.Text = this.f.name + " : y =";
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            string newDef = mainInput.Text;

            Function editFunction = new Function(newDef);
            
            if (editFunction.itsOk)
            {
                f.Text = newDef;
                this.Close();
            }         
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}