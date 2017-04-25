using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GraphDraw
{
    public partial class InsertAnnotationForm : Form
    {
        public InsertAnnotationForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string text = textBox1.Text;
                Font font = textBox1.Font;
                Color color = textBox1.ForeColor;

                try
                {
                    double x = Convert.ToDouble(xPosTextBox.Text);
                    double y = Convert.ToDouble(yPosTextBox.Text);

                    FStatic.AnnotationList.Add(new Annotation(text, font, color, x, y));

                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Bad Location!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nothing to Insert!", "Hmm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void fontButton_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();

            DialogResult dr = fontDialog.ShowDialog();

            if (dr == DialogResult.OK)
            {
                textBox1.Font = fontDialog.Font;
            }
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            DialogResult dr = colorDialog.ShowDialog();

            if (dr == DialogResult.OK)
            {
                textBox1.ForeColor = colorDialog.Color;
            }
        }
    }
}