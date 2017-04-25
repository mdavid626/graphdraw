namespace GraphDraw
{
    partial class FunctionSettingsForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.mainTextBox = new System.Windows.Forms.TextBox();
            this.colorLabel = new System.Windows.Forms.Label();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.visibleBox = new System.Windows.Forms.CheckBox();
            this.thicknessUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.showNameCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.thicknessUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(463, 227);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(382, 227);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // mainTextBox
            // 
            this.mainTextBox.BackColor = System.Drawing.Color.Black;
            this.mainTextBox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainTextBox.ForeColor = System.Drawing.Color.White;
            this.mainTextBox.Location = new System.Drawing.Point(60, 36);
            this.mainTextBox.Name = "mainTextBox";
            this.mainTextBox.Size = new System.Drawing.Size(478, 26);
            this.mainTextBox.TabIndex = 0;
            // 
            // colorLabel
            // 
            this.colorLabel.BackColor = System.Drawing.Color.DarkRed;
            this.colorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorLabel.Location = new System.Drawing.Point(12, 75);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(170, 25);
            this.colorLabel.TabIndex = 0;
            this.colorLabel.Text = "Color";
            this.colorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.colorLabel.Click += new System.EventHandler(this.colorLabel_Click);
            // 
            // notesTextBox
            // 
            this.notesTextBox.AcceptsReturn = true;
            this.notesTextBox.BackColor = System.Drawing.Color.Black;
            this.notesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notesTextBox.ForeColor = System.Drawing.Color.White;
            this.notesTextBox.Location = new System.Drawing.Point(12, 131);
            this.notesTextBox.Multiline = true;
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.notesTextBox.Size = new System.Drawing.Size(526, 79);
            this.notesTextBox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Definition";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Notes";
            // 
            // visibleBox
            // 
            this.visibleBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.visibleBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.visibleBox.Location = new System.Drawing.Point(207, 74);
            this.visibleBox.Name = "visibleBox";
            this.visibleBox.Size = new System.Drawing.Size(93, 25);
            this.visibleBox.TabIndex = 10;
            this.visibleBox.Text = "Visible";
            this.visibleBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.visibleBox.UseVisualStyleBackColor = true;
            // 
            // thicknessUpDown
            // 
            this.thicknessUpDown.BackColor = System.Drawing.Color.Black;
            this.thicknessUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thicknessUpDown.ForeColor = System.Drawing.Color.White;
            this.thicknessUpDown.Location = new System.Drawing.Point(495, 75);
            this.thicknessUpDown.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.thicknessUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.thicknessUpDown.Name = "thicknessUpDown";
            this.thicknessUpDown.Size = new System.Drawing.Size(43, 24);
            this.thicknessUpDown.TabIndex = 11;
            this.thicknessUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(419, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Thickness";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "f : y = ";
            // 
            // showNameCheckBox
            // 
            this.showNameCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.showNameCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showNameCheckBox.Location = new System.Drawing.Point(306, 74);
            this.showNameCheckBox.Name = "showNameCheckBox";
            this.showNameCheckBox.Size = new System.Drawing.Size(93, 25);
            this.showNameCheckBox.TabIndex = 14;
            this.showNameCheckBox.Text = "Show Name";
            this.showNameCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.showNameCheckBox.UseVisualStyleBackColor = true;
            // 
            // FunctionSettingsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(550, 262);
            this.Controls.Add(this.showNameCheckBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.thicknessUpDown);
            this.Controls.Add(this.visibleBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.notesTextBox);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.mainTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FunctionSettingsForm";
            this.Opacity = 0.9;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Selected Function(s)";
            ((System.ComponentModel.ISupportInitialize)(this.thicknessUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox mainTextBox;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox visibleBox;
        private System.Windows.Forms.NumericUpDown thicknessUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox showNameCheckBox;
    }
}