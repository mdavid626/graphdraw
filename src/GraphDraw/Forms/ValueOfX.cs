using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace GraphDraw
{
    public partial class ValueOfX : Form
    {
        public ValueOfX()
        {
            InitializeComponent();

            foreach (Function f in FStatic.Functions)
            {
                mainComboBox.Items.Add(f.Text);
            }

            Function f1 = FStatic.FirstSelectedFunction();

            if (f1 != null)
            {
                mainComboBox.SelectedItem = f1.Text;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            Function node = FStatic.GetFunction(mainComboBox.SelectedIndex);

            if (node != null)
            {
                yText.Text = "";

                if (xText.Text == "")
                {
                    MessageBox.Show("You didn't write in any value of x!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        double x = Convert.ToDouble(xText.Text);
                        double y = node.Y(x);

                        NumberFormatInfo provider = new NumberFormatInfo();
                        provider.NaNSymbol = "-";
                        provider.CurrencyDecimalDigits = 6;
                        
                        yText.Text = Convert.ToString(y, provider);
                    }
                    catch
                    {
                        MessageBox.Show("x = ???!!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No function is selected!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mainComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            xText.Text = "";
            yText.Text = "";
        }
    }
}