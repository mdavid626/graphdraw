using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GraphDraw
{
    public partial class FunctionsItemsForm : Form
    {
        #region Global Variables

        //interface to Main form
        private IRefresh _IRefresh;

        #endregion

        #region Construktor

        public FunctionsItemsForm(Main main)
        {
            InitializeComponent();
                
            _IRefresh = main;

            FormProperty formProperty = FStatic.GetForm(Forms.FunctionList);
            this.Bounds = formProperty.Bounds;

            LoadItems();
            AdjustListColumnsSize();
        }

        #endregion

        #region Functions

        private void DoRefresh(RefreshMode refreshmode)
        {
            _IRefresh.DoRefresh(refreshmode);

            LoadItems();
        }

        //load the functions to the list
        public void LoadItems()
        {
            //clear the list
            List.Items.Clear();

            int i = 0;
            foreach (Function f in FStatic.Functions)
            {
                List.Items.Add(f.name + ":y = " + f.Text);
                List.Items[i].SubItems[0].ForeColor = f.fS.Color;
                List.Items[i].SubItems[0].Checked = f.fS.Visible;
                List.Items[i].Selected = f.selected;
                i++;
            }

            //refresh the list
            List.Invalidate();
        }

        public void ActualizeSelectedItems()
        {
            int i = 0;
            foreach (Function f in FStatic.Functions)
            {
                List.Items[i++].Selected = f.selected;
            }

            //refresh the list
            List.Invalidate();
        }

        private void AdjustListColumnsSize()
        {
            List.Columns[0].Width = List.Width - 5;
        }

        #endregion

        #region Menu Items

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FStatic.RemoveSelectedFunctions();
            DoRefresh(RefreshMode.FunctionList);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FStatic.AddFunction_Form();
            DoRefresh(RefreshMode.FunctionList);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FStatic.EditFunction_Form();
            DoRefresh(RefreshMode.FunctionList);
        }

        private void visibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (Function f in FStatic.Functions)
            {
                if (f.selected)
                {
                    List.Items[i].SubItems[0].Checked = !List.Items[i].SubItems[0].Checked;
                    f.fS.Visible = !f.fS.Visible;
                }

                i++;
            }

            DoRefresh(RefreshMode.ReDraw);
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FStatic.ColorDialogOpen();
            DoRefresh(RefreshMode.Color);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoRefresh(RefreshMode.All);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FStatic.SelectAll();
            DoRefresh(RefreshMode.Select);
        }


        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FStatic.SelectAll();
            FStatic.RemoveSelectedFunctions();
            DoRefresh(RefreshMode.FunctionList);
        }

        #endregion        

        #region Click Events

        private void settingsButton_Click(object sender, EventArgs e)
        {
            FStatic.FunctionSettings_Form();
            DoRefresh(RefreshMode.FunctionList);
        }

        private void List_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (Function f in FStatic.Functions)
            {
                f.fS.Visible = List.Items[i].SubItems[0].Checked;
                f.selected = List.Items[i].Selected;
                i++;
            }

            DoRefresh(RefreshMode.Select);
        }

        #endregion

        #region Other Events

        private void FunctionsItemsForm_Resize(object sender, EventArgs e)
        {
            AdjustListColumnsSize();
        }

        private void FunctionsItemsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormProperty formProperty = FStatic.GetForm(Forms.FunctionList);

            formProperty.Bounds = this.Bounds;
            formProperty.menu.Checked = false;
        }

        #endregion   

    }
}