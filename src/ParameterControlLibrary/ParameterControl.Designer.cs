namespace ParameterControlLibrary
{
    partial class ParameterControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainTrackBar = new System.Windows.Forms.TrackBar();
            this.valueUpDown = new System.Windows.Forms.NumericUpDown();
            this.minValueUpDown = new System.Windows.Forms.NumericUpDown();
            this.maxValueUpDown = new System.Windows.Forms.NumericUpDown();
            this.frequencyUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minValueUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxValueUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTrackBar
            // 
            this.mainTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTrackBar.AutoSize = false;
            this.mainTrackBar.Location = new System.Drawing.Point(182, 0);
            this.mainTrackBar.Maximum = 1000;
            this.mainTrackBar.Minimum = -1000;
            this.mainTrackBar.Name = "mainTrackBar";
            this.mainTrackBar.Size = new System.Drawing.Size(396, 30);
            this.mainTrackBar.TabIndex = 0;
            this.mainTrackBar.TickFrequency = 10;
            this.mainTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.mainTrackBar.Scroll += new System.EventHandler(this.mainTrackBar_Scroll);
            // 
            // valueUpDown
            // 
            this.valueUpDown.BackColor = System.Drawing.Color.Black;
            this.valueUpDown.DecimalPlaces = 2;
            this.valueUpDown.ForeColor = System.Drawing.Color.Green;
            this.valueUpDown.Location = new System.Drawing.Point(47, 5);
            this.valueUpDown.Name = "valueUpDown";
            this.valueUpDown.Size = new System.Drawing.Size(55, 20);
            this.valueUpDown.TabIndex = 1;
            this.valueUpDown.Tag = "";
            this.valueUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            131072});
            this.valueUpDown.ValueChanged += new System.EventHandler(this.valueUpDown_ValueChanged);
            // 
            // minValueUpDown
            // 
            this.minValueUpDown.BackColor = System.Drawing.Color.Black;
            this.minValueUpDown.DecimalPlaces = 2;
            this.minValueUpDown.ForeColor = System.Drawing.Color.White;
            this.minValueUpDown.Location = new System.Drawing.Point(123, 5);
            this.minValueUpDown.Name = "minValueUpDown";
            this.minValueUpDown.Size = new System.Drawing.Size(55, 20);
            this.minValueUpDown.TabIndex = 2;
            this.minValueUpDown.ValueChanged += new System.EventHandler(this.minValueUpDown_ValueChanged);
            // 
            // maxValueUpDown
            // 
            this.maxValueUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxValueUpDown.BackColor = System.Drawing.Color.Black;
            this.maxValueUpDown.DecimalPlaces = 2;
            this.maxValueUpDown.ForeColor = System.Drawing.Color.White;
            this.maxValueUpDown.Location = new System.Drawing.Point(581, 5);
            this.maxValueUpDown.Name = "maxValueUpDown";
            this.maxValueUpDown.Size = new System.Drawing.Size(55, 20);
            this.maxValueUpDown.TabIndex = 3;
            this.maxValueUpDown.ValueChanged += new System.EventHandler(this.maxValueUpDown_ValueChanged);
            // 
            // frequencyUpDown
            // 
            this.frequencyUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.frequencyUpDown.BackColor = System.Drawing.Color.Black;
            this.frequencyUpDown.DecimalPlaces = 2;
            this.frequencyUpDown.ForeColor = System.Drawing.Color.Blue;
            this.frequencyUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.frequencyUpDown.Location = new System.Drawing.Point(656, 5);
            this.frequencyUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.frequencyUpDown.Name = "frequencyUpDown";
            this.frequencyUpDown.Size = new System.Drawing.Size(55, 20);
            this.frequencyUpDown.TabIndex = 4;
            this.frequencyUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.frequencyUpDown.ValueChanged += new System.EventHandler(this.frequencyUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "a =";
            // 
            // ParameterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.frequencyUpDown);
            this.Controls.Add(this.maxValueUpDown);
            this.Controls.Add(this.minValueUpDown);
            this.Controls.Add(this.valueUpDown);
            this.Controls.Add(this.mainTrackBar);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "ParameterControl";
            this.Size = new System.Drawing.Size(716, 30);
            ((System.ComponentModel.ISupportInitialize)(this.mainTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minValueUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxValueUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar mainTrackBar;
        private System.Windows.Forms.NumericUpDown valueUpDown;
        private System.Windows.Forms.NumericUpDown minValueUpDown;
        private System.Windows.Forms.NumericUpDown maxValueUpDown;
        private System.Windows.Forms.NumericUpDown frequencyUpDown;
        private System.Windows.Forms.Label label1;
    }
}
