using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GraphDraw
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();

            invertColorWhenCopyAndPrint.Checked = Settings.InvertColorsByCopy;
            copyFunctionListWithColorNames.Checked = Settings.CopyFunctionListWithColor;
            copyAndPrintFunctionsWithNames.Checked = Settings.CopyFunctionWithName;
            printNotes.Checked = Settings.printNotes;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Settings.InvertColorsByCopy = invertColorWhenCopyAndPrint.Checked;
            Settings.CopyFunctionListWithColor = copyFunctionListWithColorNames.Checked;
            Settings.CopyFunctionWithName = copyAndPrintFunctionsWithNames.Checked;
            Settings.printNotes = printNotes.Checked;

            this.Close();
        }
    }
}