using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GraphDraw
{
    public partial class FunctionSettingsForm : Form
    {
        private Function fn;

        public FunctionSettingsForm(Function f)
        {
            InitializeComponent();

            fn = f;

            colorLabel.BackColor = f.fS.Color;
            visibleBox.Checked = f.fS.Visible;
            thicknessUpDown.Value = (decimal)f.fS.Thickness;
            notesTextBox.Text = f.fS.Notes;
            showNameCheckBox.Checked = f.fS.NameDraw;

            if (FStatic.SelectedItems == 1)
            {
                this.Text = "Set Selected Function";
                mainTextBox.Text = f.Text;
                label1.Text = f.name + " : y =";
            }
            else
            {
                this.Text = "Set Selected Functions";
                mainTextBox.ReadOnly = true;
                label1.ForeColor = Color.Gray;
                label2.ForeColor = Color.Gray;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (FStatic.SelectedItems == 1)
            {
                Function proba = new Function(mainTextBox.Text);
                if (proba.itsOk)
                {
                    fn.Text = mainTextBox.Text;

                    FunctionSettings fs = new FunctionSettings(colorLabel.BackColor, (float)thicknessUpDown.Value, visibleBox.Checked, notesTextBox.Text, fn.fS.Precisity);
                    fs.NameDraw = showNameCheckBox.Checked;

                    fn.fS = fs;

                    this.Close();
                }
            }
            else
            {

                foreach (Function f in FStatic.Functions)
                {
                    if (f.selected)
                    {
                        FunctionSettings fs = new FunctionSettings(colorLabel.BackColor, (float)thicknessUpDown.Value, visibleBox.Checked, notesTextBox.Text, fn.fS.Precisity);
                        fs.NameDraw = showNameCheckBox.Checked;

                        f.fS = fs;
                    }
                }

                this.Close();
            }
        }

        private void colorLabel_Click(object sender, EventArgs e)
        {
            DialogResult dx = colorDialog1.ShowDialog();;

            if (dx == DialogResult.OK)
            {
                colorLabel.BackColor = colorDialog1.Color;
            }
        }
    }
}