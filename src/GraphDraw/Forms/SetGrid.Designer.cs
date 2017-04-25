namespace GraphDraw
{
    partial class SetGrid
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.backgroundColor = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.fontSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.axesColor = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.gridCheckBox = new System.Windows.Forms.CheckBox();
            this.xYCheckBox = new System.Windows.Forms.CheckBox();
            this.arrowsCheckBox = new System.Windows.Forms.CheckBox();
            this.bordersCheckbox = new System.Windows.Forms.CheckBox();
            this.smallLineColor = new System.Windows.Forms.Label();
            this.fontColor = new System.Windows.Forms.Label();
            this.gridColor = new System.Windows.Forms.Label();
            this.intersectionTextColorLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.showIntersectionTextCh = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(80, 268);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(161, 268);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Background Color";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Axes Color";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Font Color";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Small Line Color";
            // 
            // backgroundColor
            // 
            this.backgroundColor.BackColor = System.Drawing.Color.Red;
            this.backgroundColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.backgroundColor.Location = new System.Drawing.Point(196, 10);
            this.backgroundColor.Name = "backgroundColor";
            this.backgroundColor.Size = new System.Drawing.Size(35, 15);
            this.backgroundColor.TabIndex = 2;
            this.backgroundColor.Click += new System.EventHandler(this.ColorSet);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Font Size";
            // 
            // fontSizeUpDown
            // 
            this.fontSizeUpDown.BackColor = System.Drawing.Color.Black;
            this.fontSizeUpDown.ForeColor = System.Drawing.Color.White;
            this.fontSizeUpDown.Location = new System.Drawing.Point(191, 161);
            this.fontSizeUpDown.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.fontSizeUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fontSizeUpDown.Name = "fontSizeUpDown";
            this.fontSizeUpDown.Size = new System.Drawing.Size(40, 20);
            this.fontSizeUpDown.TabIndex = 4;
            this.fontSizeUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // axesColor
            // 
            this.axesColor.BackColor = System.Drawing.Color.Red;
            this.axesColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.axesColor.Location = new System.Drawing.Point(196, 35);
            this.axesColor.Name = "axesColor";
            this.axesColor.Size = new System.Drawing.Size(35, 15);
            this.axesColor.TabIndex = 2;
            this.axesColor.Click += new System.EventHandler(this.ColorSet);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 112);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Grid Color";
            // 
            // gridCheckBox
            // 
            this.gridCheckBox.AutoSize = true;
            this.gridCheckBox.Location = new System.Drawing.Point(12, 200);
            this.gridCheckBox.Name = "gridCheckBox";
            this.gridCheckBox.Size = new System.Drawing.Size(45, 17);
            this.gridCheckBox.TabIndex = 6;
            this.gridCheckBox.Text = "Grid";
            this.gridCheckBox.UseVisualStyleBackColor = true;
            // 
            // xYCheckBox
            // 
            this.xYCheckBox.AutoSize = true;
            this.xYCheckBox.Location = new System.Drawing.Point(63, 200);
            this.xYCheckBox.Name = "xYCheckBox";
            this.xYCheckBox.Size = new System.Drawing.Size(42, 17);
            this.xYCheckBox.TabIndex = 6;
            this.xYCheckBox.Text = "x, y";
            this.xYCheckBox.UseVisualStyleBackColor = true;
            // 
            // arrowsCheckBox
            // 
            this.arrowsCheckBox.AutoSize = true;
            this.arrowsCheckBox.Location = new System.Drawing.Point(178, 200);
            this.arrowsCheckBox.Name = "arrowsCheckBox";
            this.arrowsCheckBox.Size = new System.Drawing.Size(58, 17);
            this.arrowsCheckBox.TabIndex = 6;
            this.arrowsCheckBox.Text = "Arrows";
            this.arrowsCheckBox.UseVisualStyleBackColor = true;
            // 
            // bordersCheckbox
            // 
            this.bordersCheckbox.AutoSize = true;
            this.bordersCheckbox.Location = new System.Drawing.Point(111, 200);
            this.bordersCheckbox.Name = "bordersCheckbox";
            this.bordersCheckbox.Size = new System.Drawing.Size(62, 17);
            this.bordersCheckbox.TabIndex = 7;
            this.bordersCheckbox.Text = "Borders";
            this.bordersCheckbox.UseVisualStyleBackColor = true;
            // 
            // smallLineColor
            // 
            this.smallLineColor.BackColor = System.Drawing.Color.Red;
            this.smallLineColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.smallLineColor.Location = new System.Drawing.Point(196, 60);
            this.smallLineColor.Name = "smallLineColor";
            this.smallLineColor.Size = new System.Drawing.Size(35, 15);
            this.smallLineColor.TabIndex = 2;
            this.smallLineColor.Click += new System.EventHandler(this.ColorSet);
            // 
            // fontColor
            // 
            this.fontColor.BackColor = System.Drawing.Color.Red;
            this.fontColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fontColor.Location = new System.Drawing.Point(196, 85);
            this.fontColor.Name = "fontColor";
            this.fontColor.Size = new System.Drawing.Size(35, 15);
            this.fontColor.TabIndex = 2;
            this.fontColor.Click += new System.EventHandler(this.ColorSet);
            // 
            // gridColor
            // 
            this.gridColor.BackColor = System.Drawing.Color.Red;
            this.gridColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridColor.Location = new System.Drawing.Point(196, 110);
            this.gridColor.Name = "gridColor";
            this.gridColor.Size = new System.Drawing.Size(35, 15);
            this.gridColor.TabIndex = 2;
            this.gridColor.Click += new System.EventHandler(this.ColorSet);
            // 
            // intersectionTextColorLabel
            // 
            this.intersectionTextColorLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.intersectionTextColorLabel.Location = new System.Drawing.Point(196, 135);
            this.intersectionTextColorLabel.Name = "intersectionTextColorLabel";
            this.intersectionTextColorLabel.Size = new System.Drawing.Size(35, 15);
            this.intersectionTextColorLabel.TabIndex = 10;
            this.intersectionTextColorLabel.Click += new System.EventHandler(this.ColorSet);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Intersections Text Color";
            // 
            // showIntersectionTextCh
            // 
            this.showIntersectionTextCh.AutoSize = true;
            this.showIntersectionTextCh.Location = new System.Drawing.Point(12, 223);
            this.showIntersectionTextCh.Name = "showIntersectionTextCh";
            this.showIntersectionTextCh.Size = new System.Drawing.Size(135, 17);
            this.showIntersectionTextCh.TabIndex = 11;
            this.showIntersectionTextCh.Text = "Show Intersection Text";
            this.showIntersectionTextCh.UseVisualStyleBackColor = true;
            // 
            // SetGrid
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(248, 303);
            this.Controls.Add(this.showIntersectionTextCh);
            this.Controls.Add(this.intersectionTextColorLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bordersCheckbox);
            this.Controls.Add(this.arrowsCheckBox);
            this.Controls.Add(this.xYCheckBox);
            this.Controls.Add(this.gridCheckBox);
            this.Controls.Add(this.fontSizeUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gridColor);
            this.Controls.Add(this.fontColor);
            this.Controls.Add(this.smallLineColor);
            this.Controls.Add(this.axesColor);
            this.Controls.Add(this.backgroundColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetGrid";
            this.Opacity = 0.9;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Graph Paper Settings";
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label backgroundColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown fontSizeUpDown;
        private System.Windows.Forms.Label axesColor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox gridCheckBox;
        private System.Windows.Forms.CheckBox xYCheckBox;
        private System.Windows.Forms.CheckBox arrowsCheckBox;
        private System.Windows.Forms.CheckBox bordersCheckbox;
        private System.Windows.Forms.Label smallLineColor;
        private System.Windows.Forms.Label fontColor;
        private System.Windows.Forms.Label gridColor;
        private System.Windows.Forms.Label intersectionTextColorLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox showIntersectionTextCh;
    }
}