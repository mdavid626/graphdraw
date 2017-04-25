using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GraphDraw
{
    public partial class ParameterGreatScreen : Form
    {
        private float fontSize;
        private bool moveLists;
        private Point MouseDownPoint;

        public Point Label1Location
        {
            get
            {
                return label1.Location;
            }

            set
            {
                label1.Location = value;
            }
        }

        public float FontSize
        {
            get
            {
                return fontSize;
            }

            set
            {
                fontSize = value;
                fontSizeUpDown.Value = Convert.ToDecimal(value);

                List1.Font = new Font("Microsoft Sanf Serif", value);
                List2.Font = new Font("Microsoft Sanf Serif", value);

                List1.ItemHeight = (int)FontSize + (int)(FontSize / 2);
                List2.ItemHeight = (int)FontSize + (int)(FontSize / 2);

                Settings.parameterGreatScreenFontSize = value;
            }
        }

        public ParameterGreatScreen()
        {
            InitializeComponent();

            FormProperty formProperty = FStatic.GetForm(Forms.ParameterWindow);
            this.Bounds = formProperty.Bounds;

            moveLists = false;

            DoRefresh();
        }

        public void DoRefresh()
        {
            FontSize = Settings.parameterGreatScreenFontSize;
            label1.Location = Settings.parameterGreatScreenLabel1Location;

            //clear the lists
            List1.Items.Clear();
            List2.Items.Clear();

            if (FStatic.Functions.Count > 0)
            {
                int i = 0;
                foreach (Function f in FStatic.Functions)
                {
                    if (f.selected)
                    {
                        List1.Items.Add(f.name + ":y = " + f.Text);
                        List1.Items[i].ForeColor = f.fS.Color;

                        List2.Items.Add(f.TrueValueToString());
                        List2.Items[i].ForeColor = f.fS.Color;

                        i++;
                    }
                }
            }

            //refresh the list
            List1.Invalidate();
            List2.Invalidate();
            AdjustSizes();
        }

        private void fontSizeUpDown_ValueChanged(object sender, EventArgs e)
        {
            FontSize = (float)fontSizeUpDown.Value;

            List1.Invalidate();
            List2.Invalidate();
        }

        private void ParameterGreatScreen_Resize(object sender, EventArgs e)
        {
            AdjustSizes();
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            moveLists = true;
            MouseDownPoint = new Point(e.X, e.Y);
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            moveLists = false;
            MouseDownPoint = Point.Empty;
            Settings.parameterGreatScreenLabel1Location = label1.Location;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moveLists)
            {
                label1.Left = Math.Max(0, e.X + label1.Left - MouseDownPoint.X);

                AdjustSizes();
            }
        }

        private void AdjustSizes()
        {
            List1.Size = new Size(label1.Location.X, List1.Height);
            List2.Size = new Size(this.Width - label1.Location.X - label1.Width - 10, List2.Height);

            List1.Columns[0].Width = List1.Width;
            List2.Columns[0].Width = List2.Width;
        }

        private void ParameterGreatScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormProperty formProperty = FStatic.GetForm(Forms.ParameterWindow);

            formProperty.Bounds = this.Bounds;
            formProperty.menu.Checked = false;
        }
    }
}