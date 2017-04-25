namespace GraphDraw
{
    partial class Options
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.printNotes = new System.Windows.Forms.CheckBox();
            this.copyAndPrintFunctionsWithNames = new System.Windows.Forms.CheckBox();
            this.copyFunctionListWithColorNames = new System.Windows.Forms.CheckBox();
            this.invertColorWhenCopyAndPrint = new System.Windows.Forms.CheckBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(277, 276);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Black;
            this.tabPage1.Controls.Add(this.printNotes);
            this.tabPage1.Controls.Add(this.copyAndPrintFunctionsWithNames);
            this.tabPage1.Controls.Add(this.copyFunctionListWithColorNames);
            this.tabPage1.Controls.Add(this.invertColorWhenCopyAndPrint);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(269, 250);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Basic";
            // 
            // printNotes
            // 
            this.printNotes.AutoSize = true;
            this.printNotes.Location = new System.Drawing.Point(6, 75);
            this.printNotes.Name = "printNotes";
            this.printNotes.Size = new System.Drawing.Size(78, 17);
            this.printNotes.TabIndex = 3;
            this.printNotes.Text = "Print Notes";
            this.printNotes.UseVisualStyleBackColor = true;
            // 
            // copyAndPrintFunctionsWithNames
            // 
            this.copyAndPrintFunctionsWithNames.AutoSize = true;
            this.copyAndPrintFunctionsWithNames.Location = new System.Drawing.Point(6, 52);
            this.copyAndPrintFunctionsWithNames.Name = "copyAndPrintFunctionsWithNames";
            this.copyAndPrintFunctionsWithNames.Size = new System.Drawing.Size(205, 17);
            this.copyAndPrintFunctionsWithNames.TabIndex = 2;
            this.copyAndPrintFunctionsWithNames.Text = "Copy and Print Functions With Names";
            this.copyAndPrintFunctionsWithNames.UseVisualStyleBackColor = true;
            // 
            // copyFunctionListWithColorNames
            // 
            this.copyFunctionListWithColorNames.AutoSize = true;
            this.copyFunctionListWithColorNames.Location = new System.Drawing.Point(6, 29);
            this.copyFunctionListWithColorNames.Name = "copyFunctionListWithColorNames";
            this.copyFunctionListWithColorNames.Size = new System.Drawing.Size(201, 17);
            this.copyFunctionListWithColorNames.TabIndex = 1;
            this.copyFunctionListWithColorNames.Text = "Copy Function List With Color Names";
            this.copyFunctionListWithColorNames.UseVisualStyleBackColor = true;
            // 
            // invertColorWhenCopyAndPrint
            // 
            this.invertColorWhenCopyAndPrint.AutoSize = true;
            this.invertColorWhenCopyAndPrint.Location = new System.Drawing.Point(6, 6);
            this.invertColorWhenCopyAndPrint.Name = "invertColorWhenCopyAndPrint";
            this.invertColorWhenCopyAndPrint.Size = new System.Drawing.Size(184, 17);
            this.invertColorWhenCopyAndPrint.TabIndex = 0;
            this.invertColorWhenCopyAndPrint.Text = "Invert Color When Copy and Print";
            this.invertColorWhenCopyAndPrint.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(129, 294);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(210, 294);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // Options
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(301, 329);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.tabControl1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.Opacity = 0.9;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox printNotes;
        private System.Windows.Forms.CheckBox copyAndPrintFunctionsWithNames;
        private System.Windows.Forms.CheckBox copyFunctionListWithColorNames;
        private System.Windows.Forms.CheckBox invertColorWhenCopyAndPrint;
    }
}