using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GraphDraw
{
    public partial class SetOrigoForm : Form
    {
        public SetOrigoForm()
        {
            InitializeComponent();
            xTextBox.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                double xd = Convert.ToDouble(xTextBox.Text);
                double yd = Convert.ToDouble(yTextBox.Text);

                int x = Grid.PixelX(xd);
                int y = Grid.PixelY(yd);

                Grid.pOrigo = Grid.T(new Point(x, y));

                Grid.setXY();

                this.Close();
            }
            catch
            {
                MessageBox.Show("Not a number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}