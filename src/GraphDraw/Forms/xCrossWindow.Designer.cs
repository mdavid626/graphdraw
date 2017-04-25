namespace GraphDraw
{
    partial class xCrossWindow
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
            this.List1 = new GlacialComponents.Controls.GlacialList();
            this.SuspendLayout();
            // 
            // List1
            // 
            this.List1.AllowColumnResize = false;
            this.List1.AllowMultiselect = true;
            this.List1.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.List1.AlternatingColors = false;
            this.List1.AutoHeight = true;
            this.List1.BackColor = System.Drawing.Color.Black;
            this.List1.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1";
            glColumn1.NumericSort = false;
            glColumn1.Text = "x";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 100;
            this.List1.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1});
            this.List1.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.List1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.List1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.List1.Selectable = true;
            this.List1.SelectedTextColor = System.Drawing.Color.Black;
            this.List1.SelectionColor = System.Drawing.Color.White;
            this.List1.ShowBorder = false;
            this.List1.ShowFocusRect = false;
            this.List1.Size = new System.Drawing.Size(219, 318);
            this.List1.SortType = GlacialComponents.Controls.SortTypes.None;
            this.List1.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.List1.TabIndex = 2;
            this.List1.Text = "glacialList1";
            this.List1.Click += new System.EventHandler(this.List1_Click);
            // 
            // xCrossWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(219, 318);
            this.Controls.Add(this.List1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "xCrossWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Points";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.xCrossWindow_FormClosing);
            this.Resize += new System.EventHandler(this.xCrossWindow_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private GlacialComponents.Controls.GlacialList List1;



    }
}