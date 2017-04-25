using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GraphDraw
{
    public partial class SetRangeForm : Form
    {
        public SetRangeForm()
        {
            InitializeComponent();

            double xMin = Math.Round(Grid.XMin, 3);
            double xMax = Math.Round(Grid.XMax, 3);
            double yMin = Math.Round(Grid.YMin, 3);
            double yMax = Math.Round(Grid.YMax, 3);

            xMinTextBox.Text = xMin.ToString();
            xMaxTextBox.Text = xMax.ToString();

            yMinTextBox.Text = yMin.ToString();
            yMaxTextBox.Text = yMax.ToString();

            xIntervalsTextBox.Text = Grid.xIntervals.ToString();
            yIntervalsTextBox.Text = Grid.yIntervals.ToString();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                SevenZ.Calculator.Calculator clc = new SevenZ.Calculator.Calculator();


                double xMin = clc.Evaluate(xMinTextBox.Text);
                double xMax = clc.Evaluate(xMaxTextBox.Text);

                double yMin = clc.Evaluate(yMinTextBox.Text);
                double yMax = clc.Evaluate(yMaxTextBox.Text);

                int xIntervals = Convert.ToInt32(clc.Evaluate(xIntervalsTextBox.Text));
                int yIntervals = Convert.ToInt32(clc.Evaluate(yIntervalsTextBox.Text));

                if (xMin < xMax && xMax > xMin && yMin < yMax && yMax > yMin && xIntervals > 0 && yIntervals > 0)
                {
                    Grid.XMin = xMin;
                    Grid.XMax = xMax;
                    Grid.YMin = yMin;
                    Grid.YMax = yMax;
                    Grid.xIntervals = xIntervals;
                    Grid.yIntervals = yIntervals;

                    Grid.xyPixel();

                    this.Close();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                MessageBox.Show("Not a number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}