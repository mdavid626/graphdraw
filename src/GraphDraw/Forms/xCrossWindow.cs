using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GraphDraw
{
    public partial class xCrossWindow : Form
    {
        private IRefresh _IRefresh;

        public xCrossWindow(Main main)
        {
            InitializeComponent();

            _IRefresh = main;

            FormProperty formProperty = FStatic.GetForm(Forms.xCrossWindow);
            this.Bounds = formProperty.Bounds;

            AdjustSizes();
        }

        public void DoRefresh()
        {
            List1.Items.Clear();

            int i = 0;
            foreach (xCrossEntry entry in FStatic.xCrossList)
            {
                List1.Items.Add("" + (i + 1) + ") " + entry.name);

                List1.Items[i].ForeColor = Color.White;

                List1.Items[i++].Selected = entry.selected;
            }

            List1.Invalidate();
        }

        private void xCrossWindow_Resize(object sender, EventArgs e)
        {
            AdjustSizes();
        }

        private void AdjustSizes()
        {
            List1.Columns[0].Width = List1.Width - 5;
        }

        private void List1_Click(object sender, EventArgs e)
        {
            int i = 0;

            foreach (xCrossEntry entry in FStatic.xCrossList)
            {
                entry.selected = List1.Items[i++].Selected;
            }

            _IRefresh.DoRefresh(RefreshMode.ReDraw);
        }

        private void xCrossWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormProperty formProperty = FStatic.GetForm(Forms.xCrossWindow);

            formProperty.Bounds = this.Bounds;
            formProperty.menu.Checked = false;
        }
    }
}