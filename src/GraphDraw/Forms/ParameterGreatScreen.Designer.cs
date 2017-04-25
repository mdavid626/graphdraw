namespace GraphDraw
{
    partial class ParameterGreatScreen
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
            GlacialComponents.Controls.GLColumn glColumn1 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn2 = new GlacialComponents.Controls.GLColumn();
            this.List1 = new GlacialComponents.Controls.GlacialList();
            this.fontSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.List2 = new GlacialComponents.Controls.GlacialList();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // List1
            // 
            this.List1.AllowColumnResize = false;
            this.List1.AllowMultiselect = false;
            this.List1.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.List1.AlternatingColors = false;
            this.List1.AutoHeight = false;
            this.List1.BackColor = System.Drawing.Color.Black;
            this.List1.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1";
            glColumn1.NumericSort = false;
            glColumn1.Text = "Column";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 100;
            this.List1.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1});
            this.List1.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.List1.Dock = System.Windows.Forms.DockStyle.Left;
            this.List1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.List1.FullRowSelect = true;
            this.List1.GridColor = System.Drawing.Color.White;
            this.List1.GridLines = GlacialComponents.Controls.GLGridLines.gridVertical;
            this.List1.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridNone;
            this.List1.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.List1.HeaderHeight = 0;
            this.List1.HeaderVisible = false;
            this.List1.HeaderWordWrap = false;
            this.List1.HotColumnTracking = false;
            this.List1.HotItemTracking = false;
            this.List1.HotTrackingColor = System.Drawing.Color.LightGray;
            this.List1.HoverEvents = false;
            this.List1.HoverTime = 1;
            this.List1.ImageList = null;
            this.List1.ItemHeight = 17;
            this.List1.ItemWordWrap = false;
            this.List1.Location = new System.Drawing.Point(0, 0);
            this.List1.Name = "List1";
            this.List1.Selectable = false;
            this.List1.SelectedTextColor = System.Drawing.Color.Black;
            this.List1.SelectionColor = System.Drawing.Color.White;
            this.List1.ShowBorder = false;
            this.List1.ShowFocusRect = false;
            this.List1.Size = new System.Drawing.Size(272, 364);
            this.List1.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.List1.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.List1.TabIndex = 0;
            this.List1.Text = "glacialList1";
            // 
            // fontSizeUpDown
            // 
            this.fontSizeUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fontSizeUpDown.BackColor = System.Drawing.Color.Black;
            this.fontSizeUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontSizeUpDown.ForeColor = System.Drawing.Color.White;
            this.fontSizeUpDown.Location = new System.Drawing.Point(598, 0);
            this.fontSizeUpDown.Maximum = new decimal(new int[] {
            72,
            0,
            0,
            0});
            this.fontSizeUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fontSizeUpDown.Name = "fontSizeUpDown";
            this.fontSizeUpDown.Size = new System.Drawing.Size(50, 26);
            this.fontSizeUpDown.TabIndex = 1;
            this.fontSizeUpDown.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.fontSizeUpDown.ValueChanged += new System.EventHandler(this.fontSizeUpDown_ValueChanged);
            // 
            // List2
            // 
            this.List2.AllowColumnResize = false;
            this.List2.AllowMultiselect = false;
            this.List2.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.List2.AlternatingColors = false;
            this.List2.AutoHeight = false;
            this.List2.BackColor = System.Drawing.Color.Black;
            this.List2.BackgroundStretchToFit = true;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "Column1";
            glColumn2.NumericSort = false;
            glColumn2.Text = "Column";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 100;
            this.List2.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn2});
            this.List2.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.List2.Dock = System.Windows.Forms.DockStyle.Right;
            this.List2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.List2.FullRowSelect = true;
            this.List2.GridColor = System.Drawing.Color.White;
            this.List2.GridLines = GlacialComponents.Controls.GLGridLines.gridVertical;
            this.List2.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridNone;
            this.List2.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.List2.HeaderHeight = 0;
            this.List2.HeaderVisible = false;
            this.List2.HeaderWordWrap = false;
            this.List2.HotColumnTracking = false;
            this.List2.HotItemTracking = false;
            this.List2.HotTrackingColor = System.Drawing.Color.LightGray;
            this.List2.HoverEvents = false;
            this.List2.HoverTime = 1;
            this.List2.ImageList = null;
            this.List2.ItemHeight = 17;
            this.List2.ItemWordWrap = false;
            this.List2.Location = new System.Drawing.Point(385, 0);
            this.List2.Name = "List2";
            this.List2.Selectable = false;
            this.List2.SelectedTextColor = System.Drawing.Color.Black;
            this.List2.SelectionColor = System.Drawing.Color.White;
            this.List2.ShowBorder = false;
            this.List2.ShowFocusRect = false;
            this.List2.Size = new System.Drawing.Size(263, 364);
            this.List2.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.List2.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.List2.TabIndex = 0;
            this.List2.Text = "glacialList1";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.label1.Location = new System.Drawing.Point(304, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(5, 364);
            this.label1.TabIndex = 2;
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
            // 
            // ParameterGreatScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 364);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fontSizeUpDown);
            this.Controls.Add(this.List1);
            this.Controls.Add(this.List2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ParameterGreatScreen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Functions";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ParameterGreatScreen_FormClosing);
            this.Resize += new System.EventHandler(this.ParameterGreatScreen_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GlacialComponents.Controls.GlacialList List1;
        private System.Windows.Forms.NumericUpDown fontSizeUpDown;
        private GlacialComponents.Controls.GlacialList List2;
        private System.Windows.Forms.Label label1;
    }
}