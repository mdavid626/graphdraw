using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GraphDraw
{
    public partial class SetGrid : Form
    {
        public SetGrid()
        {
            InitializeComponent();

            backgroundColor.BackColor = Grid.backgroundColor;
            axesColor.BackColor = Grid.longLineColor;
            smallLineColor.BackColor = Grid.smallLineColor;
            fontColor.BackColor = Grid.fontColor;
            gridColor.BackColor = Grid.gridColor;
            fontSizeUpDown.Value = (decimal)Grid.fontSize;

            gridCheckBox.Checked = Grid.isGrid;
            xYCheckBox.Checked = Grid.isXY;
            bordersCheckbox.Checked = Grid.isBorder;
            arrowsCheckBox.Checked = Grid.isArrow;

            intersectionTextColorLabel.BackColor = Settings.xCrossPointFontColor;
            showIntersectionTextCh.Checked = Settings.shouldxCrossPointsDraw;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Grid.backgroundColor = backgroundColor.BackColor;
            Grid.longLineColor = axesColor.BackColor;
            Grid.smallLineColor = smallLineColor.BackColor;
            Grid.fontColor = fontColor.BackColor;
            Grid.gridColor = gridColor.BackColor;
            Grid.fontSize = (int)fontSizeUpDown.Value;

            Grid.isGrid = gridCheckBox.Checked;
            Grid.isXY = xYCheckBox.Checked;
            Grid.isBorder = bordersCheckbox.Checked;
            Grid.isArrow = arrowsCheckBox.Checked;

            Settings.xCrossPointFontColor = intersectionTextColorLabel.BackColor;
            Settings.shouldxCrossPointsDraw = showIntersectionTextCh.Checked;

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ColorSet(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            DialogResult dr = colorDialog.ShowDialog();

            if (dr == DialogResult.OK)
            {
                Label lb = (Label)sender;
                lb.BackColor = colorDialog.Color;
            }
        }
    }
}