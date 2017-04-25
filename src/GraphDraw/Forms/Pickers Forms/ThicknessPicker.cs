using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GraphDraw
{
    public partial class ThicknessPicker : Form
    {
        IRefresh _IRefresh;

        public ThicknessPicker(Main main)
        {
            InitializeComponent();

            _IRefresh = main;
        }

        private void ThicknessPicker_Deactivate(object sender, EventArgs e)
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

            float thickness = 1;

            if (sender == label1) thickness = 1f;
            if (sender == label2) thickness = 2f;
            if (sender == label3) thickness = 3f;
            if (sender == label4) thickness = 4f;
            if (sender == label5) thickness = 5f;
            if (sender == label6) thickness = 6f;

            foreach (Function f in FStatic.Functions)
            {
                if (f.selected) f.fS.Thickness = thickness;
            }

            _IRefresh.DoRefresh(RefreshMode.Select);
            _IRefresh.DoRefresh(RefreshMode.ReDraw);

            this.Close();
        }
    }
}