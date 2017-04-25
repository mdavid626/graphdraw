using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GraphDraw
{
    public partial class ColorPicker : Form
    {
        private IRefresh _IRefresh;

        public ColorPicker(Main main)
        {
            InitializeComponent();

            _IRefresh = main;
        }

        private void ColorPicker_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Labels_MouseHover(object sender, EventArgs e)
        {
            Label lab = (Label)sender;
            lab.BorderStyle = BorderStyle.Fixed3D;
        }

        private void Labels_MouseLeave(object sender, EventArgs e)
        {
            Label lab = (Label)sender;
            lab.BorderStyle = BorderStyle.None;
        }

        private void Labels_Click(object sender, EventArgs e)
        {
            Label lab = (Label)sender;

            foreach (Function f in FStatic.Functions)
            {
                if (f.selected) f.fS.Color = lab.BackColor;
            }

            _IRefresh.DoRefresh(RefreshMode.Select);
            _IRefresh.DoRefresh(RefreshMode.Color);
            this.Close();
        }
    }
}