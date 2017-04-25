namespace GraphDraw
{
    partial class SetRangeForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.xMinTextBox = new System.Windows.Forms.TextBox();
            this.xMaxTextBox = new System.Windows.Forms.TextBox();
            this.xIntervalsTextBox = new System.Windows.Forms.TextBox();
            this.yMinTextBox = new System.Windows.Forms.TextBox();
            this.yMaxTextBox = new System.Windows.Forms.TextBox();
            this.yIntervalsTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.BackColor = System.Drawing.Color.Black;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(181, 89);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(264, 89);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // xMinTextBox
            // 
            this.xMinTextBox.BackColor = System.Drawing.Color.Black;
            this.xMinTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xMinTextBox.ForeColor = System.Drawing.Color.White;
            this.xMinTextBox.Location = new System.Drawing.Point(27, 29);
            this.xMinTextBox.Name = "xMinTextBox";
            this.xMinTextBox.Size = new System.Drawing.Size(100, 22);
            this.xMinTextBox.TabIndex = 2;
            this.xMinTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // xMaxTextBox
            // 
            this.xMaxTextBox.BackColor = System.Drawing.Color.Black;
            this.xMaxTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xMaxTextBox.ForeColor = System.Drawing.Color.White;
            this.xMaxTextBox.Location = new System.Drawing.Point(133, 29);
            this.xMaxTextBox.Name = "xMaxTextBox";
            this.xMaxTextBox.Size = new System.Drawing.Size(100, 22);
            this.xMaxTextBox.TabIndex = 3;
            this.xMaxTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // xIntervalsTextBox
            // 
            this.xIntervalsTextBox.BackColor = System.Drawing.Color.Black;
            this.xIntervalsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xIntervalsTextBox.ForeColor = System.Drawing.Color.White;
            this.xIntervalsTextBox.Location = new System.Drawing.Point(239, 29);
            this.xIntervalsTextBox.Name = "xIntervalsTextBox";
            this.xIntervalsTextBox.Size = new System.Drawing.Size(100, 22);
            this.xIntervalsTextBox.TabIndex = 4;
            this.xIntervalsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // yMinTextBox
            // 
            this.yMinTextBox.BackColor = System.Drawing.Color.Black;
            this.yMinTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yMinTextBox.ForeColor = System.Drawing.Color.White;
            this.yMinTextBox.Location = new System.Drawing.Point(27, 55);
            this.yMinTextBox.Name = "yMinTextBox";
            this.yMinTextBox.Size = new System.Drawing.Size(100, 22);
            this.yMinTextBox.TabIndex = 5;
            this.yMinTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // yMaxTextBox
            // 
            this.yMaxTextBox.BackColor = System.Drawing.Color.Black;
            this.yMaxTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yMaxTextBox.ForeColor = System.Drawing.Color.White;
            this.yMaxTextBox.Location = new System.Drawing.Point(133, 55);
            this.yMaxTextBox.Name = "yMaxTextBox";
            this.yMaxTextBox.Size = new System.Drawing.Size(100, 22);
            this.yMaxTextBox.TabIndex = 6;
            this.yMaxTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // yIntervalsTextBox
            // 
            this.yIntervalsTextBox.BackColor = System.Drawing.Color.Black;
            this.yIntervalsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yIntervalsTextBox.ForeColor = System.Drawing.Color.White;
            this.yIntervalsTextBox.Location = new System.Drawing.Point(239, 55);
            this.yIntervalsTextBox.Name = "yIntervalsTextBox";
            this.yIntervalsTextBox.Size = new System.Drawing.Size(100, 22);
            this.yIntervalsTextBox.TabIndex = 7;
            this.yIntervalsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Intervals";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Min";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(167, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Max";
            // 
            // SetRangeForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(352, 122);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.yIntervalsTextBox);
            this.Controls.Add(this.yMaxTextBox);
            this.Controls.Add(this.yMinTextBox);
            this.Controls.Add(this.xIntervalsTextBox);
            this.Controls.Add(this.xMaxTextBox);
            this.Controls.Add(this.xMinTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetRangeForm";
            this.Opacity = 0.9;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Coordinate System";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox xMinTextBox;
        private System.Windows.Forms.TextBox xMaxTextBox;
        private System.Windows.Forms.TextBox xIntervalsTextBox;
        private System.Windows.Forms.TextBox yMinTextBox;
        private System.Windows.Forms.TextBox yMaxTextBox;
        private System.Windows.Forms.TextBox yIntervalsTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}