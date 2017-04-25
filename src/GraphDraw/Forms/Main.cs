using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Printing;
using System.Xml;
using System.Threading;
using ParameterControlLibrary;
using System.IO;
using System.Xml.Serialization;

namespace GraphDraw
{
    #region Interfaces

    interface IFstatic
    {
        void AddFromKeyboarFunction();
        void AddTextToMainInput(string text);
        void ClearText();
    }

    interface IRefresh
    {
        void DoRefresh(RefreshMode refreshmode);
    }

    #endregion

    #region Enum

    public enum WorkMode
    {
        Standard,
        Trace,
        MoveOrigo,
        MoveGraph,
        SetCoordSystem,
        FreeDraw
    };

    public enum Direction
    {
        Out,
        In
    };

    public enum Forms
    {
        MainForm,
        ParameterWindow,
        KeyBoard,
        FunctionList,
        xCrossWindow
    };

    public enum RefreshMode
    {
        All,
        Paint,
        ReDraw,
        Select,
        MovingCanvas,
        FunctionList,
        Color,
        ReCount
    };

    #endregion

    public partial class Main : Form, IFstatic, IRefresh
    {
        #region Global Variables

        //FullScreen variables
        private bool FullScreen; //the windows is now full screen?
        private bool Maximized; //the windows is maximized?
        private Rectangle m_Bounds; //to save Bounds - window state

        //Parameters visible
        private bool ParametersVisible;

        //points
        private Point MousePoint;
        private Point MouseDownPoint;

        private bool shiftPressed;
        private Point shiftPressedPoint;
        private bool shiftSavePoint;

        private Point tracePlotPoint;

        private Pen setRangeRectanglePen;

        //parameter
        private ParameterControl[] parameterControls;

        private bool moveGraphParam; //resize the canvas & parameter labels

        private bool GreatRefresh;

        private bool MouseIsOnCanvas;
        private bool IsMouseDown;

        private WorkMode workmode;

        private ArrayList freeDrawStore;

        private Bitmap bmCache;

        private Size moveGraphFeed;

        private Point freeDrawHelpPoint;
        private Pen freeDrawPen;


        private FunctionsItemsForm functionItemsForm;
        private KeyBoardFormControl keyboardFormControl;
        private ParameterGreatScreen parameterGreatScreen;
        private xCrossWindow xcrossWindow;

        PrintPreviewDialog printPreviewDialog;

        //printing
        //private StreamReader streamToPrint;
        private bool isSaved;
        private string filePath;
        public bool isOpenFile;
        
        private readonly Point AbsoluteOrigo = new Point(0, 0);

        private bool canvasRefresh;

        private bool shouldSave;

        private bool isMouseDownOnMainForm;
        private Point mousePointOnMainForm;

        //fade in - fade out
        private System.Windows.Forms.Timer fadeTimerUp;
        private System.Windows.Forms.Timer fadeTimerDown;

        public double opacityIncrease;
        public double opacityDecrease;
        public int fadeIntervalUp;
        public int fadeIntervalDown;

        #endregion

        #region Properties

        public Size SizeOfCanvas
        {
            get
            {
                return canvas.Size;
            }

            set
            {
                canvas.Size = value;
            }
        }

        public ComboBox mainInputInterface
        {
            get
            {
                return mainInput;
            }

            set
            {
                mainInput = value;
            }
        }

        #endregion

        #region Construktor
        public Main()
        {
            InitializeComponent();

            #region fade effect

            opacityIncrease = .05;
            opacityDecrease = .1;
            fadeIntervalUp = 30;
            fadeIntervalDown = 10;

            //fade in - fade out
            fadeTimerUp = new System.Windows.Forms.Timer();
            fadeTimerUp.Tick += new System.EventHandler(FadeHandlerUp);
            fadeTimerUp.Interval = fadeIntervalUp;

            //fadeTimerDown = new System.Windows.Forms.Timer();
            //fadeTimerDown.Tick += new System.EventHandler(FadeHandlerDown);
            //fadeTimerDown.Interval = fadeIntervalDown;
            

            this.Opacity = 0;
            fadeTimerUp.Start();

            #endregion

            parameterControls = new ParameterControl[10];
            parameterPanel.AutoScroll = false;

            for (int i = 0; i < 10; i++)
            {
                parameterControls[i] = new ParameterControl();

                parameterControls[i].Location = new Point(0, i * 30);
                parameterControls[i].Size = new Size(parameterPanel.Size.Width - 3, 30);
                parameterControls[i].Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));

                parameterPanel.Controls.Add(parameterControls[i]);
            }

            parameterPanel.AutoScroll = true;

            //fullscreen
            FullScreen = false;

            //setRangeRectangle
            setRangeRectanglePen = new Pen(Color.Gray, 1);
            setRangeRectanglePen.DashPattern = new float[] { 1f, 1f };

            shiftPressed = false;
            shiftSavePoint = true;

            moveGraphParam = false;
            GreatRefresh = false;

            MouseIsOnCanvas = false;

            //pi mode or standard mode
            standardModeToolStripMenuItem.Checked = true;
            Grid.piCoordinates = false;

            ModeSelect(WorkMode.Standard);

            freeDrawStore = new ArrayList();

            moveGraphFeed = new Size(0, 0);

            Settings.parameterGreatScreenFontSize = 40;
            Settings.parameterGreatScreenLabel1Location = new Point(100, 0);

            Settings.InvertColorsByCopy = true;

            freeDrawPen = new Pen(Color.Red, 1f);

            FStatic.Initialize();

            Grid.SizeOfCanvas = canvas.Size;
            Grid.Initialize();

            int deskHeight = Screen.PrimaryScreen.Bounds.Height;
            int deskWidth = Screen.PrimaryScreen.Bounds.Width;

            int deskX1 = 2 * deskWidth / 3;
            int deskY1 = deskHeight / 3;

            //a plusz ablakok inicializacioja
            Settings.formProperties.Add(new FormProperty(Forms.FunctionList, new Rectangle(deskX1, deskY1, 278, 413), false, functionListToolStripMenuItem));
            Settings.formProperties.Add(new FormProperty(Forms.KeyBoard, new Rectangle(deskX1, deskY1, 458, 231), false, keyboardToolStripMenuItem));
            Settings.formProperties.Add(new FormProperty(Forms.ParameterWindow, new Rectangle(new Point(10, 10), new Size(deskWidth - 20, 110)), false, functionParametersToolStripMenuItem));
            Settings.formProperties.Add(new FormProperty(Forms.xCrossWindow, new Rectangle(deskX1, deskY1, 235, 352), false, xCrossWindowMenuToolStripMenuItem));
            Settings.formProperties.Add(new FormProperty(Forms.MainForm, new Rectangle(), true, mainFormToolStripMenuItem));

            functionItemsForm = new FunctionsItemsForm(this);
            keyboardFormControl = new KeyBoardFormControl(this);
            parameterGreatScreen = new ParameterGreatScreen();
            xcrossWindow = new xCrossWindow(this);

            functionItemsForm.Visible = FStatic.GetForm(Forms.FunctionList).menu.Checked;
            keyboardFormControl.Visible = FStatic.GetForm(Forms.KeyBoard).menu.Checked;
            parameterGreatScreen.Visible = FStatic.GetForm(Forms.ParameterWindow).menu.Checked;
            xcrossWindow.Visible = FStatic.GetForm(Forms.xCrossWindow).menu.Checked;

            if (parameterGreatScreen != null && !parameterGreatScreen.IsDisposed)
            {
                Settings.parameterGreatScreenLabel1Location = new Point(parameterGreatScreen.Width / 2, 0);
            }

            //parameters panel
            ParametersVisible = false;
            parameterPanel.Visible = ParametersVisible;
            parametersToolStripMenuItem.Checked = ParametersVisible;
            SetCanvasSize();

            Settings.KeyInterval = 1;
            Settings.ShowBalloonTips = true;
            Settings.CopyFunctionListWithColor = false;
            Settings.CopyFunctionWithName = true;
            Settings.shouldOnTop = false;
            Settings.printNotes = true;
            Settings.shouldxCrossPointsDraw = true;
            Settings.xCrossPointFontColor = Color.White;
            Settings.InvertColorsByCopy = true;

            printGraph.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);

            isSaved = false;
            isOpenFile = false;

            DoRefresh(RefreshMode.All);
        }

        #endregion

        #region visual effects

        private void FadeHandlerUp(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += opacityIncrease;
            }
        }

        #endregion

        #region Menu

        #region File Menuitem

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            DialogResult dr = DialogResult.No;

            if (isOpenFile)
            {
                string message = "Do you want to save changes";

                if (!isSaved)
                {
                    message += "?";
                }
                else
                {
                    message += " to\n" + filePath + "?";
                }

                dr = MessageBox.Show(message, "Save File", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

                if (dr == DialogResult.Yes)
                {
                    SaveFunctions();
                }
            }

            if (dr != DialogResult.Cancel)
            {
                isSaved = false;
                FStatic.Functions.Clear();
                FStatic.xCrossList.Clear();
                FStatic.AnnotationList.Clear();
                this.freeDrawStore.Clear();

                Grid.Initialize();

                this.Text = "GraphDraw";

                DoRefresh(RefreshMode.All);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            openFileDialog1.FileName = "";

            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                OpenFunctions(openFileDialog1.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFunctions();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isSaved = false;
            SaveFunctions();
        }

        private void saveAsimageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bm = CanvasDrawInvert(canvas.Size);

            if (saveImage.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    switch (saveImage.FilterIndex)
                    {
                        case 1:
                            bm.Save(saveImage.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        case 2:
                            bm.Save(saveImage.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;

                        case 3:
                            bm.Save(saveImage.FileName, System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                    }

                    if (MessageBox.Show(this, "Image saved, would you like to open it?", "Image saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        System.Diagnostics.Process.Start(saveImage.FileName);
                }
                catch
                {
                    MessageBox.Show(this, "Error! Image not saved!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.PageSettings = printGraph.DefaultPageSettings;

            pageSetupDialog1.ShowDialog();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog == null || printPreviewDialog.IsDisposed)
            {
                printPreviewDialog = new PrintPreviewDialog();
            }

            printPreviewDialog.Document = printGraph;
            printPreviewDialog.Show();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog1 = new PrintDialog();

            printDialog1.AllowSomePages = true;
            printDialog1.ShowHelp = true;
            printDialog1.AllowPrintToFile = false;
            printDialog1.AllowSelection = false;
            printDialog1.AllowSomePages = false;
            printDialog1.Document = printGraph;

            DialogResult result = printDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                printGraph.DefaultPageSettings = pageSetupDialog1.PageSettings;
                printGraph.Print();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Edit Menuitem

        private void copyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(CanvasDrawInvert(canvas.Size));

            ShowBalloonTip("Graph Copied to Clipboard");
        }

        private void copyFunctionListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FStatic.Functions.Count > 0)
            {
                string s = "";

                foreach (Function f in FStatic.Functions)
                {
                    s += f.name + " : y = " + f.TrueValueToString();

                    if (Settings.CopyFunctionListWithColor)
                    {
                        s += "  " + f.fS.Color.ToString();
                    }

                    s += "\n";
                }

                Clipboard.SetText(s);
                ShowBalloonTip("Function List Copied to Clipboard");
            }
            else
            {
                ShowBalloonTip("There Is No Function to Copy");
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Function f in FStatic.Functions)
            {
                f.selected = true;
            }

            DoRefresh(RefreshMode.Select);
        }

        private void insertAnnotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertAnnotationForm form = new InsertAnnotationForm();
            form.ShowDialog();

            DoRefresh(RefreshMode.ReDraw);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            FStatic.RemoveSelectedFunctions();
            DoRefresh(RefreshMode.FunctionList);
        }

        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FStatic.SelectAll();
            FStatic.RemoveSelectedFunctions();
            DoRefresh(RefreshMode.FunctionList);
        }

        private void deleteFreeDrawingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            freeDrawStore.Clear();
            DoRefresh(RefreshMode.ReDraw);
        }

        private void deleteIntersectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FStatic.xCrossList.Clear();
            DoRefresh(RefreshMode.ReDraw);
        }

        private void deleteAnnotationstoolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FStatic.AnnotationList.Clear();
            DoRefresh(RefreshMode.ReDraw);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoRefresh(RefreshMode.All);
        }

        #endregion

        #region View Menuitem

        private void functionParametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProperty formProperty = FStatic.GetForm(Forms.ParameterWindow);

            if (parameterGreatScreen == null || parameterGreatScreen.IsDisposed)
            {
                parameterGreatScreen = new ParameterGreatScreen();
                parameterGreatScreen.Show();

                formProperty.menu.Checked = true;
            }
            else
            {
                bool check = !formProperty.menu.Checked;
                formProperty.menu.Checked = check;
                parameterGreatScreen.Visible = check;
            }
        }

        private void functionListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProperty formProperty = FStatic.GetForm(Forms.FunctionList);

            if (functionItemsForm == null || functionItemsForm.IsDisposed)
            {
                functionItemsForm = new FunctionsItemsForm(this);
                functionItemsForm.Show();

                formProperty.menu.Checked = true;
            }
            else
            {
                bool check = !formProperty.menu.Checked;
                formProperty.menu.Checked = check;
                functionItemsForm.Visible = check;
            }
        }

        private void parametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeParametersVisible(!parameterPanel.Visible);
        }

        private void keyboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProperty formProperty = FStatic.GetForm(Forms.KeyBoard);

            if (keyboardFormControl == null || keyboardFormControl.IsDisposed)
            {
                keyboardFormControl = new KeyBoardFormControl(this);
                keyboardFormControl.Show();

                formProperty.menu.Checked = true;
            }
            else
            {
                bool check = !formProperty.menu.Checked;
                formProperty.menu.Checked = check;
                keyboardFormControl.Visible = check;
            }
        }

        private void fullScreenLeave_Click(object sender, EventArgs e)
        {
            //change to fullscreen, if fullscreen == false then the window is not in fullscreen mode
            //therefore we change to fullscreen
            if (FullScreen == false)
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    Maximized = true;
                    this.WindowState = FormWindowState.Normal;
                }

                this.FormBorderStyle = FormBorderStyle.None;
                m_Bounds = this.Bounds;

                this.Bounds = Screen.PrimaryScreen.Bounds;
                //this.TopMost = true;
            }
            else
            {
                if (Maximized == true) this.WindowState = FormWindowState.Maximized;

                this.Bounds = m_Bounds;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                //this.TopMost = false;

                Maximized = false;
            }

            fullScreenToolStripMenuItem.Checked = !fullScreenToolStripMenuItem.Checked;
            FullScreen = !FullScreen;
            fullScreenLeave.Visible = !fullScreenLeave.Visible;
        }

        #endregion

        #region Mode Menuitem

        private void modeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkMode mode = WorkMode.Standard;

            if (sender == standardModeToolStripMenuItem || sender == standardButton)
            {
                mode = WorkMode.Standard;
            }

            if (sender == traceFunctionToolStripMenuItem || sender == tracePlotButton)
            {
                mode = WorkMode.Trace;
            }

            if (sender == setOrigoToolStripMenuItem || sender == moveOrigo)
            {
                mode = WorkMode.MoveOrigo;
            }

            if (sender == moveCanvasManualToolStripMenuItem || sender == moveGraphButton)
            {
                mode = WorkMode.MoveGraph;
            }

            if (sender == setCoordSystemToolStripMenuItem || sender == setRange)
            {
                mode = WorkMode.SetCoordSystem;
            }

            if (sender == freeDrawToolStripMenuItem || sender == freeDrawButton)
            {
                mode = WorkMode.FreeDraw;
            }

            ModeSelect(mode);

            //DoRefresh();
        }

        private void setOrigoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SetOrigoForm form = new SetOrigoForm();
            form.ShowDialog();

            DoRefresh(RefreshMode.ReCount);
        }

        private void setCoordSystemFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetRangeForm form = new SetRangeForm();
            form.ShowDialog();

            DoRefresh(RefreshMode.ReCount);
        }

        private void resetOrigoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Grid.pOrigo = Grid.Origo;

            DoRefresh(RefreshMode.ReCount);
        }

        private void resetCoordSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Grid.XMin = -4;
            Grid.XMax = 4;
            Grid.YMin = -4;
            Grid.YMax = 4;

            Grid.xIntervals = 8;
            Grid.xIntervals = 8;

            Grid.pOrigo = Grid.Origo;

            Grid.xyPixel();
            DoRefresh(RefreshMode.ReCount);
        }

        #endregion

        #region Coord. System Menuitem

        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender == zoomOutToolStripMenuItem || sender == outFullButton)
            {
                Grid.XMin = NextZoom(Grid.XMin, Direction.Out);
                Grid.XMax = NextZoom(Grid.XMax, Direction.Out);

                Grid.YMin = NextZoom(Grid.YMin, Direction.Out);
                Grid.YMax = NextZoom(Grid.YMax, Direction.Out);
            }

            if (sender == zoomOutHorizontallyToolStripMenuItem || sender == outHorizontalButton)
            {
                Grid.XMin = NextZoom(Grid.XMin, Direction.Out);
                Grid.XMax = NextZoom(Grid.XMax, Direction.Out);
            }

            if (sender == zoomOutVerticallyToolStripMenuItem || sender == outVerticalButton)
            {
                Grid.YMin = NextZoom(Grid.YMin, Direction.Out);
                Grid.YMax = NextZoom(Grid.YMax, Direction.Out);
            }

            if (sender == zoomInToolStripMenuItem || sender == inFullButton)
            {
                Grid.XMin = NextZoom(Grid.XMin, Direction.In);
                Grid.XMax = NextZoom(Grid.XMax, Direction.In);

                Grid.YMin = NextZoom(Grid.YMin, Direction.In);
                Grid.YMax = NextZoom(Grid.YMax, Direction.In);
            }

            if (sender == zoomInHorizontallyToolStripMenuItem || sender == inHorizontalButton)
            {
                Grid.XMin = NextZoom(Grid.XMin, Direction.In);
                Grid.XMax = NextZoom(Grid.XMax, Direction.In);
            }

            if (sender == zoomInVerticallyToolStripMenuItem || sender == inVerticalButton)
            {
                Grid.YMin = NextZoom(Grid.YMin, Direction.In);
                Grid.YMax = NextZoom(Grid.YMax, Direction.In);
            }

            Grid.xyPixel();
            DoRefresh(RefreshMode.ReCount);
        }

        private void standardModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            standardModeToolStripMenuItem.Checked = true;
            piValuesToolStripMenuItem.Checked = false;

            Grid.piCoordinates = false;

            DoRefresh(RefreshMode.ReDraw);
        }

        private void piValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            standardModeToolStripMenuItem.Checked = false;
            piValuesToolStripMenuItem.Checked = true;

            Grid.piCoordinates = true;

            DoRefresh(RefreshMode.ReDraw);
        }

        #endregion

        #region Function Menuitem

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FStatic.EditFunction_Form();
            DoRefresh(RefreshMode.FunctionList);
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FStatic.ColorDialogOpen();
            DoRefresh(RefreshMode.Color);
        }

        private void thicknessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float thickness = 1;
            if (sender == pt1ToolStripMenuItem) thickness = 1;
            if (sender == pt2ToolStripMenuItem) thickness = 2;
            if (sender == pt3ToolStripMenuItem) thickness = 3;
            if (sender == pt4ToolStripMenuItem) thickness = 4;
            if (sender == pt5ToolStripMenuItem) thickness = 5;
            if (sender == pt6ToolStripMenuItem) thickness = 6;

            foreach (Function f in FStatic.Functions)
            {
                if (f.selected) f.fS.Thickness = thickness;
            }

            DoRefresh(RefreshMode.ReDraw);
        }

        private void visibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender == visibleToolStripMenuItem)
            {
                visibleRapidAccessButton.Checked = !visibleRapidAccessButton.Checked;

                visibleToolStripMenuItem.Checked = visibleRapidAccessButton.Checked;
            }

            foreach (Function f in FStatic.Functions)
            {
                if (f.selected) f.fS.Visible = visibleRapidAccessButton.Checked;
            }

            DoRefresh(RefreshMode.FunctionList);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FStatic.FunctionSettings_Form();
            DoRefresh(RefreshMode.FunctionList);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FStatic.AddFunction_Form();
            DoRefresh(RefreshMode.FunctionList);
        }

        #endregion

        #region Tools

        private void accurateValueOfXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ValueOfX form = new ValueOfX();
            form.ShowDialog();
        }

        private void coordSystemSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetGrid form = new SetGrid();
            form.ShowDialog();

            DoRefresh(RefreshMode.ReDraw);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //show options
            Options options = new Options();
            if (FullScreen == true) options.TopMost = true;
            else options.TopMost = false;

            options.ShowDialog();

            DoRefresh(RefreshMode.All);
        }

        private void intersectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FStatic.Functions.Count == 2)
            {
                Function f1 = FStatic.GetFunction(0);
                Function f2 = FStatic.GetFunction(1);

                if (f1 != null && f2 != null) xCrossCalculate(f1, f2);
            }
            else
            {
                if (FStatic.SelectedItems == 2)
                {
                    Function f1 = null;
                    Function f2 = null;

                    foreach (Function f in FStatic.Functions)
                    {
                        if (f.selected)
                        {
                            if (f1 == null)
                            {
                                f1 = f;
                            }
                            else
                            {
                                f2 = f;
                            }
                        }
                    }

                    if (f1 != null && f2 != null) xCrossCalculate(f1, f2);
                }
                else
                {
                    MessageBox.Show("Error! You must select 2 functions!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Help

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\Manual.pdf";

            try
            {
                System.Diagnostics.Process.Start(path);
            }
            catch
            {
                MessageBox.Show("Not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void samplesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\Function Samples";

            try
            {
                System.Diagnostics.Process.Start(path);
            }
            catch
            {
                MessageBox.Show("Not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tutorialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\Tutorials";

            try
            {
                System.Diagnostics.Process.Start(path);
            }
            catch
            {
                MessageBox.Show("Not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Settings.activated)
            {
                MessageBox.Show("Your program is activated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                RegisterForm form = new RegisterForm();
                form.ShowDialog();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpacityForm opacityform = new OpacityForm();
            About about = new About();

            opacityform.Size = this.Size;
            opacityform.Location = this.Location;
            opacityform.Show();

            about.autoClose = false;
            about.Start();

            if (opacityform != null && !opacityform.IsDisposed)
            {
                opacityform.Close();
            }
        }

        #endregion

        #endregion

        #region Button Events

        private void addButton_Click(object sender, EventArgs e)
        {
            Function f = new Function(mainInput.Text);

            if (f.itsOk)
            {
                FStatic.Add(f);
                DoRefresh(RefreshMode.FunctionList);
            }
        }

        #endregion

        #region Draw-Functions

        private Bitmap CanvasDraw(Size size)
        {
            Bitmap bm = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage(bm);

            DrawBase(g, size);

            if (IsMouseDown)
            {
                if (workmode == WorkMode.Trace)
                {
                    TracePlotFunction(g);
                }

                if (workmode == WorkMode.MoveOrigo)
                {
                    Grid.pOrigo = ShiftAlign(MousePoint);
                    Grid.setXY();
                }

                if (workmode == WorkMode.MoveGraph)
                {
                    Point p = ShiftAlign(MousePoint);
                    Grid.pOrigo = new Point(p.X + moveGraphFeed.Width, p.Y + moveGraphFeed.Height);
                    Grid.setXY();
                }

                if (workmode == WorkMode.SetCoordSystem)
                {
                    SetRangeFunction(g);
                }
            }

            return bm;
        }

        private Bitmap CanvasDrawInvert(Size size)
        {
            if (!Settings.InvertColorsByCopy)
            {
                return CanvasDraw(size);
            }
            else
            {
                Bitmap result;

                //save colors
                Color longLineColorOriginal = Grid.longLineColor;
                Color smallLineColorOriginal = Grid.smallLineColor;
                Color backgroundColorOriginal = Grid.backgroundColor;
                Color fontColorOriginal = Grid.fontColor;

                //a szinek invertalasa
                Grid.longLineColor = InvertColor(Grid.longLineColor);
                Grid.smallLineColor = InvertColor(Grid.smallLineColor);
                Grid.backgroundColor = InvertColor(Grid.backgroundColor);
                Grid.fontColor = InvertColor(Grid.fontColor);
                Settings.xCrossPointFontColor = InvertColor(Settings.xCrossPointFontColor);

                int n = 5;
                if (FStatic.Functions.Count > 0) n = FStatic.Functions.Count;

                bool[] backup = new bool[n];

                if (Settings.CopyFunctionWithName && FStatic.Functions.Count > 0)
                {
                    int i = 0;
                    foreach (Function f in FStatic.Functions)
                    {
                        backup[i++] = f.fS.NameDraw;
                        f.fS.NameDraw = true;
                    }
                }

                foreach (Annotation an in FStatic.AnnotationList)
                {
                    an.color = InvertColor(an.color);
                }

                result = CanvasDraw(size);

                //a szinek visszaallitasa
                Grid.longLineColor = longLineColorOriginal;
                Grid.smallLineColor = smallLineColorOriginal;
                Grid.backgroundColor = backgroundColorOriginal;
                Grid.fontColor = fontColorOriginal;
                Settings.xCrossPointFontColor = Color.White;

                if (Settings.CopyFunctionWithName && FStatic.Functions.Count > 0)
                {
                    int i = 0;
                    foreach (Function f in FStatic.Functions)
                    {
                        f.fS.NameDraw = backup[i++];
                    }

                    //DoRefresh();
                }

                foreach (Annotation an in FStatic.AnnotationList)
                {
                    an.color = InvertColor(an.color);
                }

                return result;
            }
        }

        private void DrawBase(Graphics g, Size size)
        {
            Grid.Draw(g, size);
            FunctionsDraw(g);
            xCrossPaint(g);
            annotationPain(g);
            FreeDrawPaint(g);
        }

        private void annotationPain(Graphics g)
        {
            foreach (Annotation an in FStatic.AnnotationList)
            {
                an.Draw(g);
            }
        }

        private void FunctionsDraw(Graphics g)
        {
            foreach (Function f in FStatic.Functions)
            {
                if (f.fS.Visible)
                {
                    //if (f.selected || ((workmode == WorkMode.MoveOrigo || workmode == WorkMode.MoveGraph) && IsMouseDown)) f.ReCount();
                    if (((workmode == WorkMode.MoveOrigo || workmode == WorkMode.MoveGraph) && IsMouseDown)
                        || f.shouldRecount) f.ReCount();
                    f.Draw(g);
                }
            }
        }

        private void SetRangeFunction(Graphics g)
        {
            Rectangle rec = new Rectangle(MouseDownPoint.X, MouseDownPoint.Y, MousePoint.X - MouseDownPoint.X, MousePoint.Y - MouseDownPoint.Y);

            g.DrawRectangle(setRangeRectanglePen, rec);
        }

        private void TracePlotFunction(Graphics g)
        {
            Pen pen = new Pen(Color.Blue);

            Function f = FStatic.FirstSelectedFunction();

            if (f != null && MouseIsOnCanvas == true)
            {
                Point p = Grid.TReverse(MousePoint);

                int y = Grid.PixelY(f.Y(Grid.RealX(p.X)));

                //horizontal
                Point p1 = new Point(0, Grid.pOrigo.Y - y);
                Point p2 = new Point(canvas.Width, Grid.pOrigo.Y - y);

                if (Grid.IsOnCanvas(p1) && Grid.IsOnCanvas(p2))
                {
                    g.DrawLine(pen, p1, p2);

                    //vertical
                    Point p3 = new Point(MousePoint.X, 0);
                    Point p4 = new Point(MousePoint.X, canvas.Height);

                    if (Grid.IsOnCanvas(p3) && Grid.IsOnCanvas(p3))
                    {
                        g.DrawLine(pen, p3, p4);
                    }

                    tracePlotPoint = new Point(p3.X, p1.Y);
                }
            }
        }

        private void xCrossPaint(Graphics g)
        {
            foreach (xCrossEntry entry in FStatic.xCrossList)
            {
                entry.Draw(g);
            }
        }

        private void FreeDrawPaint(Graphics g)
        {
            foreach (LineStoreGraph ln in freeDrawStore)
            {
                //g.DrawLine(ln.pen, Grid.T(ln.pr1), Grid.T(ln.pr2));
                g.DrawLine(ln.pen, ln.p1, ln.p2);
            }
        }

        #endregion

        #region Canvas

        //canvas-mouse-events----------------------------------------------------------
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            MousePoint = new Point(e.X, e.Y);

            statusLabelChange();

            //free draw
            if (workmode == WorkMode.FreeDraw && IsMouseDown)
            {
                LineStoreGraph ln = new LineStoreGraph(Grid.TReverse(ShiftAlign(freeDrawHelpPoint)), Grid.TReverse(ShiftAlign(MousePoint)), freeDrawPen);
                freeDrawStore.Add(ln);

                Graphics g = Graphics.FromHwnd(canvas.Handle);
                g.DrawLine(freeDrawPen, ShiftAlign(freeDrawHelpPoint), ShiftAlign(MousePoint));

                freeDrawHelpPoint = MousePoint;
            }

            if (IsMouseDown)
            {
                if (workmode == WorkMode.Trace || workmode == WorkMode.SetCoordSystem)
                {
                    DoRefresh(RefreshMode.Paint);
                }
                else
                {
                    DoRefresh(RefreshMode.ReDraw);
                }
            }
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseDownPoint = new Point(e.X, e.Y);
                IsMouseDown = true;

                moveGraphFeed.Width = Grid.pOrigo.X - MouseDownPoint.X;
                moveGraphFeed.Height = Grid.pOrigo.Y - MouseDownPoint.Y;

                freeDrawHelpPoint = new Point(MouseDownPoint.X, MouseDownPoint.Y);
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (workmode == WorkMode.SetCoordSystem)
                {
                    Point p1 = Grid.TReverse(MouseDownPoint);
                    Point p2 = Grid.TReverse(MousePoint);

                    if (p2.X > p1.X && p2.Y < p1.Y)
                    {
                        double xMin = Grid.RealX(p1.X);
                        double xMax = Grid.RealX(p2.X);
                        double yMin = Grid.RealY(p2.Y);
                        double yMax = Grid.RealY(p1.Y);

                        Grid.XMin = Math.Round(xMin, 3);
                        Grid.XMax = Math.Round(xMax, 3);
                        Grid.YMin = Math.Round(yMin, 3);
                        Grid.YMax = Math.Round(yMax, 3);

                        Grid.xyPixel();

                        DoRefresh(RefreshMode.ReCount);
                    }
                }

                IsMouseDown = false;
                DoRefresh(RefreshMode.ReDraw);
            }
        }

        private void canvas_MouseEnter(object sender, EventArgs e)
        {
            MouseIsOnCanvas = true;
        }

        private void canvas_MouseLeave(object sender, EventArgs e)
        {
            MouseIsOnCanvas = false;
        }
        //canvas-mouse-events-end------------------------------------------------------



        //canvas-other-events--------------------------------------------------
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (canvasRefresh && bmCache != null)
            {
                g.DrawImage(bmCache, AbsoluteOrigo);
            }
            else
            {
                bmCache = CanvasDraw(canvas.Size);
                g.DrawImage(bmCache, AbsoluteOrigo);
            }
            
            if (IsMouseDown)
            {
                if (workmode == WorkMode.Trace)
                {
                    TracePlotFunction(g);
                }

                if (workmode == WorkMode.SetCoordSystem)
                {
                    SetRangeFunction(g);
                }
            }
        }

        private void canvas_Resize(object sender, EventArgs e)
        {
            Grid.SizeOfCanvas = canvas.Size;
            Grid.xyPixel();
        }
        //canvas-other-events-end----------------------------------------------

        #endregion

        #region Functions

        private void SetCanvasSize()
        {
            int Height;

            if (ParametersVisible == true)
                Height = parameterPanel.Location.Y - canvas.Location.Y - 6;
            else
                Height = parameterPanel.Location.Y - canvas.Location.Y + parameterPanel.Size.Height;

            canvas.Size = new Size(canvas.Size.Width, Height);
        }

        private void ChangeParametersVisible(bool value)
        {
            //if (parameterPanel.Height == 0) parameterPanel.Height = 129;

            parametersToolStripMenuItem.Checked = value;

            ParametersVisible = value;
            parameterPanel.Visible = value;
            resizeLabel1.Visible = value;

            SetCanvasSize();

            DoRefresh(RefreshMode.ReCount);
        }

        private void statusLabelChange()
        {
            double x = 0;
            double y = 0;

            if (workmode == WorkMode.Trace && IsMouseDown)
            {
                x = Grid.RealX(tracePlotPoint.X - Grid.pOrigo.X);
                y = Grid.RealY(Grid.pOrigo.Y - tracePlotPoint.Y);
            }
            else
            {
                x = Grid.RealX(MousePoint.X - Grid.pOrigo.X);
                y = Grid.RealY(Grid.pOrigo.Y - MousePoint.Y);
            }

            coordinatesLabel.Text = "x = " + String.Format("{0:0.000}", x) + ", y = " + String.Format("{0:0.000}", y);
        }

        private double NextZoom(double number, Direction dir)
        {
            if (number == 0) return 1;

            bool negFlag = number > 0 ? false : true;
            number = Math.Abs(number);

            double div = 1, _div = 10;
            if (number > 1) _div = 0.1;

            double n = number;
            while (n >= 10 || n < 1)
            {
                div *= _div;
                n = number * div;
            }

            double final = 0;
            if (dir == Direction.In)
            {
                if (n >= 0 && n <= 1) final = 0.5;
                if (n > 1 && n <= 2) final = 1;
                if (n > 2 && n <= 5) final = 2;
                if (n > 5) final = 5;
            }
            else
            {
                if (n < 2) final = 2;
                if (n >= 2 && n < 5) final = 5;
                if (n >= 5) final = 10;
            }

            double result = final / div;
            return negFlag ? -result : result;
        }

        public void DoRefresh(RefreshMode refreshmode)
        {
            standardModeToolStripMenuItem.Checked = false;
            piValuesToolStripMenuItem.Checked = false;

            if (Grid.piCoordinates)
            {
                piValuesToolStripMenuItem.Checked = true;
            }
            else
            {
                standardModeToolStripMenuItem.Checked = true;
            }

            if (refreshmode == RefreshMode.FunctionList || refreshmode == RefreshMode.Color || refreshmode == RefreshMode.All)
            {
                if (functionItemsForm != null && !functionItemsForm.IsDisposed) functionItemsForm.LoadItems();

                if (parameterGreatScreen != null && !parameterGreatScreen.IsDisposed) parameterGreatScreen.DoRefresh();

                shouldSave = true;
            }

            if (refreshmode == RefreshMode.FunctionList || refreshmode == RefreshMode.All)
            {
                GreatRefresh = true;

                mainInput.Items.Clear();
                foreach (Function f in FStatic.Functions)
                {
                    mainInput.Items.Add(f.Text);
                }

                if (xcrossWindow != null && !xcrossWindow.IsDisposed) xcrossWindow.DoRefresh();

                shouldSave = true;
            }

            if (refreshmode == RefreshMode.Select || refreshmode == RefreshMode.FunctionList || refreshmode == RefreshMode.All)
            {
                #region selection changed

                if (parameterGreatScreen != null && !parameterGreatScreen.IsDisposed) parameterGreatScreen.DoRefresh();

                Function selected = FStatic.FirstSelectedFunction();

                if (selected != null)
                {
                    label2.Visible = true;

                    selectedFunctionLabel.Visible = true;
                    selectedFunctionLabel.Text = selected.Text;
                    selectedFunctionLabel.ForeColor = selected.fS.Color;
                    selectedFunctionParamLabel.Text = selected.TrueValueToString();
                    selectedFunctionParamLabel.Visible = true;
                    selectedFunctionParamLabel.ForeColor = selected.fS.Color;

                    label1.Text = selected.name + " : y =";

                    bool activePar = false;

                    for (int i = 0; i < 10; i++)
                    {
                        if (selected.pArray[i].active)
                        {
                            activePar = true;
                            break;
                        }
                    }

                    selectedFunctionParamLabel.Visible = activePar;

                    visibleRapidAccessButton.Checked = selected.fS.Visible;
                    visibleToolStripMenuItem.Checked = selected.fS.Visible;

                    if (FStatic.SelectedItems > 1)
                    {
                        //tobb mint egy 
                        editFunctionButton.BackColor = Color.Gray;
                        completeSettingFunctionButton.BackColor = Color.Gray;
                        thicknessFunctionPickerButton.BackColor = Color.Gray;
                        colorSetLabelButton.BackColor = Color.Gray;
                        visibleRapidAccessButton.BackColor = Color.Gray;
                        thicknessFunctionPickerButton.Text = "T";
                        label2.Text = "Multiple S. Functions";
                    }
                    else
                    {
                        //csak egy van kijelolve
                        thicknessFunctionPickerButton.Text = Convert.ToString(selected.fS.Thickness);
                        editFunctionButton.BackColor = Color.Black;
                        completeSettingFunctionButton.BackColor = Color.Black;
                        thicknessFunctionPickerButton.BackColor = Color.Black;
                        visibleRapidAccessButton.BackColor = Color.Black;
                        colorSetLabelButton.BackColor = selected.fS.Color;
                        label2.Text = "Selected Function";
                    }
                }
                else
                {
                    //egy funkcio sincs kijelolve

                    label2.Visible = false;
                    selectedFunctionLabel.Visible = false;
                    selectedFunctionParamLabel.Visible = false;

                    //rapid access functions
                    editFunctionButton.BackColor = Color.Black;
                    completeSettingFunctionButton.BackColor = Color.Black;
                    thicknessFunctionPickerButton.BackColor = Color.Black;
                    colorSetLabelButton.BackColor = Color.Black;
                    visibleRapidAccessButton.BackColor = Color.Black;
                    visibleRapidAccessButton.Checked = false;
                    thicknessFunctionPickerButton.Text = "T";

                    label1.Text = FStatic.NextName() + " : y =";

                    visibleToolStripMenuItem.Checked = false;
                }

            #endregion

                GreatRefresh = true;

                if (selected != null)
                {
                    mainInput.SelectedItem = selected.Text;
                    mainInput.SelectAll();
                }
                else
                {
                    mainInput.SelectedItem = null;
                    mainInput.Text = "";
                }

                MakeParameterControls();

                shouldSave = true;
            }

            if (refreshmode == RefreshMode.ReCount || refreshmode == RefreshMode.All)
            {
                foreach (Function f in FStatic.Functions)
                {
                    f.shouldRecount = true;
                }

                shouldSave = true;
            }

            if (refreshmode == RefreshMode.ReDraw || refreshmode == RefreshMode.FunctionList || 
                refreshmode == RefreshMode.Color || refreshmode == RefreshMode.ReCount || refreshmode == RefreshMode.All)
            {
                canvasRefresh = false;
                canvas.Invalidate();

                //shouldSave = true;
            }

            if (refreshmode == RefreshMode.Paint)
            {
                canvasRefresh = true;
                canvas.Invalidate();
            }

            //mainInput.Focus();
        }

        private Point ShiftAlign(Point p)
        {
            if (shiftPressed)
            {
                int xt = Math.Abs(MousePoint.X - shiftPressedPoint.X);
                int yt = Math.Abs(MousePoint.Y - shiftPressedPoint.Y);

                if (xt <= yt) return new Point(shiftPressedPoint.X, p.Y);
                if (xt > yt) return new Point(p.X, shiftPressedPoint.Y);
                return p;
            }
            else
            {
                return p;
            }
        }

        private Color InvertColor(Color color)
        {
            byte bRed = (byte)~(color.R);
            byte bGreen = (byte)~(color.G);
            byte bBlue = (byte)~(color.B);

            return Color.FromArgb(bRed, bGreen, bBlue);
        }

        private void ParameterControlChanging(object sender, ParameterControlEventArgs e)
        {
            foreach (Function f in FStatic.Functions)
            {
                if (f.selected && f.pArray[e.Id].active)
                {
                    f.pArray[e.Id].value = e.Value;
                    f.pArray[e.Id].minValue = e.MinValue;
                    f.pArray[e.Id].maxValue = e.MaxValue;
                    f.pArray[e.Id].frequency = e.Frequency;
                    f.shouldRecount = true;
                }
            }

            Function fn = FStatic.FirstSelectedFunction();
            if (fn != null) selectedFunctionParamLabel.Text = fn.TrueValueToString();

            if (parameterGreatScreen != null && !parameterGreatScreen.IsDisposed) parameterGreatScreen.DoRefresh();

            DoRefresh(RefreshMode.ReDraw);
        }

        private void MakeParameterControls()
        {
            int j = 0;
            for (int i = 0; i < 10; i++)
            {
                bool okay = false;

                foreach (Function f in FStatic.Functions)
                {
                    if (f.pArray[i].active && f.selected) okay = true;
                }

                if (okay)
                {
                    Function selected = FStatic.FirstSelectedFunction();

                    parameterControls[j].Initialize(i, selected.pArray[i].value, selected.pArray[i].minValue, selected.pArray[i].maxValue, selected.pArray[i].frequency);

                    parameterControls[j].ControlChanged += new ParameterControlEvents(ParameterControlChanging);
                    parameterControls[j].Visible = true;

                    j++;
                }
                else
                {
                    parameterControls[i].Visible = false;
                }
            }
        }

        private void AdjustPanelsSize()
        {
            int h = resizeLabel1.Location.Y - canvas.Location.Y;
            canvas.Size = new Size(canvas.Width, h);

            parameterPanel.Location = new Point(parameterPanel.Location.X, resizeLabel1.Location.Y + 6);

            h = mainInput.Location.Y - 9 - parameterPanel.Location.Y;
            parameterPanel.Size = new Size(parameterPanel.Width, h);

            //if (parameterPanel.Height == 0) ChangeParametersVisible();
        }

        private void xCrossCalculate(Function f1, Function f2)
        {
            //FStatic.xCrossList.Clear();

            double i = Grid.XMin;

            for (; i <= Grid.XMax; i += 0.001)
            {
                double y1 = f1.Y(i);
                double y2 = f2.Y(i);

                double res = Math.Abs(y1 - y2);

                if (res < 0.01)
                {
                    double x = Math.Round(i, 3);
                    double _yy = Math.Round(y1, 3);

                    xCrossEntry entry = new xCrossEntry(x, _yy);


                    double ii = i - 0.1;
                    double maxi = i + 0.1;

                    for (; ii <= maxi; ii += 0.0001)
                    {
                        double y1i = f1.Y(ii);
                        double y2i = f2.Y(ii);

                        double s1 = Math.Round(y1i, 4, MidpointRounding.ToEven);
                        double s2 = Math.Round(y2i, 4, MidpointRounding.ToEven);

                        if (s1 == s2)
                        {
                            double _x = Math.Round(ii, 3 ,MidpointRounding.ToEven);
                            double _y = Math.Round(s1, 3, MidpointRounding.ToEven);
                            entry = new xCrossEntry(_x, _y);
                            break;
                        }
                    }

                    FStatic.xCrossList.Add(entry);
                    i += 0.1;
                }
            }
             

            if (xcrossWindow == null || xcrossWindow.IsDisposed)
            {
                xcrossWindow = new xCrossWindow(this);
            }

            xcrossWindow.Show();
            xcrossWindow.DoRefresh();
            DoRefresh(RefreshMode.ReDraw);
        }

        //Keyboard -----------------------------------
        public void AddFromKeyboarFunction()
        {
            addButton_Click(null, null);
        }

        public void AddTextToMainInput(string text)
        {
            mainInput.Text += text;
        }

        public void ClearText()
        {
            mainInput.Text = "";
        }
        //Keyboard -----------------------------------

        private void ModeSelect(WorkMode mode)
        {
            Color notSel = Color.Black;
            Color sel = Color.Gray;

            canvas.Cursor = Cursors.Cross;
            canvas.ContextMenuStrip = mainContextMenu;

            standardToolStripMenuItem.Checked = false;
            traceFunctionToolStripMenuItem.Checked = false;
            setOrigoToolStripMenuItem.Checked = false;
            setCoordSystemToolStripMenuItem.Checked = false;
            moveCanvasManualToolStripMenuItem.Checked = false;
            freeDrawToolStripMenuItem.Checked = false;

            standardButton.BackColor = notSel;
            tracePlotButton.BackColor = notSel;
            moveOrigo.BackColor = notSel;
            moveGraphButton.BackColor = notSel;
            setRange.BackColor = notSel;
            freeDrawButton.BackColor = notSel;

            switch (mode)
            {
                case WorkMode.Standard:
                    {
                        standardToolStripMenuItem.Checked = true;
                        workmode = WorkMode.Standard;
                        standardButton.BackColor = sel;

                        canvas.Cursor = Cursors.Cross;
                        break;
                    }
                case WorkMode.Trace:
                    {
                        traceFunctionToolStripMenuItem.Checked = true;
                        workmode = WorkMode.Trace;
                        tracePlotButton.BackColor = sel;

                        //bmCache = new Bitmap(CanvasDraw(canvas.Size));
                        break;
                    }
                case WorkMode.MoveOrigo:
                    {
                        setOrigoToolStripMenuItem.Checked = true;
                        workmode = WorkMode.MoveOrigo;
                        moveOrigo.BackColor = sel;

                        canvas.Cursor = Cursors.SizeAll;
                        break;
                    }
                case WorkMode.MoveGraph:
                    {
                        moveCanvasManualToolStripMenuItem.Checked = true;
                        workmode = WorkMode.MoveGraph;
                        moveGraphButton.BackColor = sel;

                        canvas.Cursor = Cursors.NoMove2D;
                        break;
                    }
                case WorkMode.SetCoordSystem:
                    {
                        setCoordSystemToolStripMenuItem.Checked = true;
                        workmode = WorkMode.SetCoordSystem;
                        setRange.BackColor = sel;
                        canvas.ContextMenuStrip = null;
                        break;
                    }
                case WorkMode.FreeDraw:
                    {
                        freeDrawToolStripMenuItem.Checked = true;
                        workmode = WorkMode.FreeDraw;
                        freeDrawButton.BackColor = sel;
                        canvas.ContextMenuStrip = freeDrawMenuStrip;

                        canvas.Cursor = Cursors.Arrow;
                        break;
                    }
            }

            //mainInput.Focus();
        }

        private void ShowBalloonTip(string text)
        {
            if (Settings.ShowBalloonTips)
            {
                trayNotifyIcon.ShowBalloonTip(3000, "Information", text, ToolTipIcon.Info);
            }
        }

        #endregion

        #region Other Events

        private void Form_DragEnter(object sender, DragEventArgs e)
        {
            // make sure they're actually dropping files (not text or anything else)
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
                // allow them to continue
                // (without this, the cursor stays a "NO" symbol
                e.Effect = DragDropEffects.All;
        }

        private void Form_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string file = files[0];

            //foreach (string file in files)
            //{
                System.IO.FileInfo fileAttr = new System.IO.FileInfo(file);

                if ((fileAttr.Attributes & System.IO.FileAttributes.Directory) != System.IO.FileAttributes.Directory &&
                    System.IO.Path.GetExtension(file) == ".gdf")
                {
                    OpenFunctions(file);
                }
            //}
        }

        private void mainInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!GreatRefresh)
            {
                FStatic.SelectNone();

                Function f = FStatic.GetFunction(mainInput.SelectedIndex);
                if (f != null) f.selected = true;

                DoRefresh(RefreshMode.Select);
            }
            else
            {
                GreatRefresh = false;
            }
        }

        private void mainInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift)
            {
                shiftPressed = true;
                if (shiftSavePoint)
                {
                    shiftPressedPoint = MousePoint;
                    shiftSavePoint = false;
                }
            }

            if ((e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Up || e.KeyCode == Keys.Down) && e.Alt || e.KeyCode == Keys.Escape)
            {
                if (e.KeyCode == Keys.Left)
                {
                    Grid.pOrigo = new Point(Grid.pOrigo.X - Settings.KeyInterval, Grid.pOrigo.Y);
                }

                if (e.KeyCode == Keys.Right)
                {
                    Grid.pOrigo = new Point(Grid.pOrigo.X + Settings.KeyInterval, Grid.pOrigo.Y);
                }

                if (e.KeyCode == Keys.Up)
                {
                    Grid.pOrigo = new Point(Grid.pOrigo.X, Grid.pOrigo.Y - Settings.KeyInterval);
                }

                if (e.KeyCode == Keys.Down)
                {
                    Grid.pOrigo = new Point(Grid.pOrigo.X, Grid.pOrigo.Y + Settings.KeyInterval);
                }

                if (e.KeyCode == Keys.Escape)
                {
                    IsMouseDown = false;
                }

                DoRefresh(RefreshMode.ReCount);
            }
        }

        private void mainInput_KeyUp(object sender, KeyEventArgs e)
        {
            shiftPressed = e.Shift;
            shiftSavePoint = true;
        }

        private void mainInput_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = addButton;
        }

        private void mainInput_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = null;
        }

        private void resizeLabel1_MouseDown(object sender, MouseEventArgs e)
        {
            moveGraphParam = true;
            MouseDownPoint = new Point(e.X, e.Y);
        }

        private void resizeLabel1_MouseUp(object sender, MouseEventArgs e)
        {
            moveGraphParam = false;
            MouseDownPoint = Point.Empty;

            DoRefresh(RefreshMode.ReCount);
        }

        private void resizeLabel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moveGraphParam)
            {
                resizeLabel1.Top = Math.Max(0, e.Y + resizeLabel1.Top - MouseDownPoint.Y);

                AdjustPanelsSize();;
            }
        }

        private void mainInput_MouseHover(object sender, EventArgs e)
        {
            Function node = FStatic.FirstSelectedFunction();

            if (node != null)
            {
                if (node.fS.Notes != "") notesToolTip1.Show(node.fS.Notes, mainInput);
            }
        }

        private void mainInput_MouseLeave(object sender, EventArgs e)
        {
            //notesToolTip1.Hide(mainInput);
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            FormProperty formProperty = FStatic.GetForm(Forms.MainForm);

            formProperty.Bounds = this.Bounds;

            Grid.xyPixel();
            DoRefresh(RefreshMode.ReCount);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (shouldSave)
            {
                string message = "Do you want to save changes";

                if (!isSaved)
                {
                    message += "?";
                }
                else
                {
                    message += " to\n" + filePath + "?";
                }

                DialogResult dr = MessageBox.Show(message, "Save Functions", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

                if (dr == DialogResult.Yes)
                {
                    if (!SaveFunctions()) e.Cancel = true; else e.Cancel = false;
                }

                if (dr == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }

                SaveSettings();
            }
        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDownOnMainForm = true;
            mousePointOnMainForm = new Point(e.X, e.Y);
        }

        private void Main_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDownOnMainForm = false;
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDownOnMainForm)
            {
                //Move the form
                this.Location = new Point(this.Left - (this.mousePointOnMainForm.X - e.X), this.Top - (this.mousePointOnMainForm.Y - e.Y));

                //Redraw the form//
                this.Invalidate();
            }
        }

        #endregion

        #region FunctionRapidAccess

        private void colorSetLabelButton_Click(object sender, EventArgs e)
        {
            if (FStatic.SelectedItems > 0)
            {
                ColorPicker colorPicker = new ColorPicker(this);

                // convert picker location to screen coordinates.
                Point loc = colorSetLabelButton.Parent.PointToScreen(colorSetLabelButton.Location);

                Screen currentScreen = Screen.FromPoint(loc);
                Rectangle screenRect = currentScreen.WorkingArea;

                // Position the dropdown X coordinate in order to be displayed in its entirely.
                if (loc.X < screenRect.X)
                    loc.X = screenRect.X;
                else if ((loc.X + colorPicker.Width) > screenRect.Right)
                    loc.X = screenRect.Right - colorPicker.Width;

                // Do the same for the Y coordinate.
                if ((loc.Y + colorSetLabelButton.Height + colorPicker.Height) > screenRect.Bottom)
                    loc.Offset(0, -colorPicker.Height - 2);  // dropdown will be above the picker control
                else
                    loc.Offset(0, colorSetLabelButton.Height + 2); // dropdown will be below the picker

                colorPicker.Location = loc;

                colorPicker.Show();
            }
        }

        private void thicknessFunctionPickerButton_Click(object sender, EventArgs e)
        {
            if (FStatic.SelectedItems > 0)
            {
                ThicknessPicker thicknessPicker = new ThicknessPicker(this);

                // convert picker location to screen coordinates.
                Point loc = thicknessFunctionPickerButton.Parent.PointToScreen(thicknessFunctionPickerButton.Location);

                Screen currentScreen = Screen.FromPoint(loc);
                Rectangle screenRect = currentScreen.WorkingArea;

                // Position the dropdown X coordinate in order to be displayed in its entirely.
                if (loc.X < screenRect.X)
                    loc.X = screenRect.X;
                else if ((loc.X + thicknessPicker.Width) > screenRect.Right)
                    loc.X = screenRect.Right - thicknessPicker.Width;

                // Do the same for the Y coordinate.
                if ((loc.Y + colorSetLabelButton.Height + thicknessPicker.Height) > screenRect.Bottom)
                    loc.Offset(0, -thicknessPicker.Height - 2);  // dropdown will be above the picker control
                else
                    loc.Offset(0, colorSetLabelButton.Height + 2); // dropdown will be below the picker

                thicknessPicker.Location = loc;

                thicknessPicker.Show();
            }
        }
        #endregion

        #region Context menus

        #region FreeDraw context menu

        private void colorFreeDrawMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = freeDrawColorDialog.ShowDialog();

            if (dr == DialogResult.OK)
            {
                freeDrawPen = new Pen(freeDrawColorDialog.Color, freeDrawPen.Width);
            }
        }

        private void thicknessFreeDrawMenuItem_Click(object sender, EventArgs e)
        {
            float th = 1;

            if (sender == thickness1ptFreeDrawMenuItem) th = 1;
            if (sender == thickness2ptFreeDrawMenuItem) th = 2;
            if (sender == thickness3ptFreeDrawMenuItem) th = 3;
            if (sender == thickness4ptFreeDrawMenuItem) th = 4;
            if (sender == thickness5ptFreeDrawMenuItem) th = 5;
            if (sender == thickness6ptFreeDrawMenuItem) th = 6;

            freeDrawPen = new Pen(freeDrawPen.Color, th);
        }

        #endregion

        #region Tray context menu

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showBalloonTipsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.ShowBalloonTips = !Settings.ShowBalloonTips;
            showBalloonTipsToolStripMenuItem.Checked = Settings.ShowBalloonTips;
        }

        private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.shouldOnTop = !Settings.shouldOnTop;
            bool shouldOnTop = Settings.shouldOnTop;

            alwaysOnTopToolStripMenuItem.Checked = shouldOnTop;

            if (functionItemsForm != null && !functionItemsForm.IsDisposed) functionItemsForm.TopMost = shouldOnTop;
            if (keyboardFormControl != null && !keyboardFormControl.IsDisposed) keyboardFormControl.TopMost = shouldOnTop;
            if (parameterGreatScreen != null && !parameterGreatScreen.IsDisposed) parameterGreatScreen.TopMost = shouldOnTop;
            if (xcrossWindow != null && !xcrossWindow.IsDisposed) xcrossWindow.TopMost = shouldOnTop;
            this.TopMost = shouldOnTop;
        }

        #endregion

        #endregion

        #region Print

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            for (int i = 0; i < printGraph.PrinterSettings.Copies; i++)
            {
                Print(sender, e);
                e.HasMorePages = true;
            }

            e.HasMorePages = false;
        }

        private void Print(object sender, PrintPageEventArgs e)
        {
            Rectangle m = e.MarginBounds;
            int xPos = m.X;
            int yPos = m.Y;

            int w;
            int h;

            if (e.PageSettings.Landscape)
            {
                w = (int)(m.Width * 0.7);
                h = (int)(m.Height * 0.9);
            }
            else
            {
                w = m.Width;
                h = (int)(m.Width);
            }

            Size graphSize = new Size(w, h);

            foreach (Function f in FStatic.Functions)
            {
                f.shouldRecount = true;
            }

            Grid.SizeOfCanvas = graphSize;
            Grid.xyPixel();

            Bitmap image = CanvasDrawInvert(graphSize);

            foreach (Function f in FStatic.Functions)
            {
                f.shouldRecount = true;
            }

            Grid.SizeOfCanvas = canvas.Size;
            Grid.xyPixel();

            Font printFont = new Font("Courier New", 12);

            //fent a szoveg kiirasa
            PrintString("GraphDraw 1.0 © 2009", printFont, ref yPos, xPos, e, Color.Black);


            //draw graph
            Rectangle destRec = new Rectangle(xPos, yPos, graphSize.Width, graphSize.Height);
            e.Graphics.DrawImage(image, destRec);


            //set yPos and new font
            if (e.PageSettings.Landscape)
            {
                xPos = destRec.Right + 30;
                yPos = destRec.Y;
            }
            else
            {
                yPos += graphSize.Height + (int)(1.5 * printFont.GetHeight(e.Graphics));
            }

            printFont = new Font("Courier New", 14, FontStyle.Bold);

            PrintString("Functions on screen:", printFont, ref yPos, xPos, e, Color.Black);


            //set new font
            printFont = new Font("Courier New", 14, FontStyle.Regular);

            foreach (Function f in FStatic.Functions)
            {
                if (f.fS.Visible)
                {
                    string text = f.name + " : y = " + f.TrueValueToString();

                    if (Settings.printNotes && f.fS.Notes != "")
                    {
                        text += " (" + f.fS.Notes + ")";
                    }
                    PrintString(text, printFont, ref yPos, xPos, e, f.fS.Color);
                }
            }
        }

        private void PrintString(string text, Font font, ref int yPos, int xPos, PrintPageEventArgs e, Color color)
        {
            SolidBrush br = new SolidBrush(color);

            e.Graphics.DrawString(text, font, br, xPos, yPos, new StringFormat());
            yPos += (int)(1.5 * font.GetHeight(e.Graphics));
        }

        #endregion

        #region Function Save & Open

        public bool SaveFunctions()
        {
            if (!isSaved)
            {
                DialogResult dr = saveFileDialog.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    isSaved = true;
                    filePath = saveFileDialog.FileName;

                    if (Path.GetExtension(saveFileDialog.FileName) != ".gdf")
                    {
                        filePath += ".gdf";
                    }
                }
                else return false;
            }

            if (isSaved)
            {
                string path = filePath;

                FunctionSave fsave = new FunctionSave();

                fsave.GridLongLineColor.R = Grid.longLineColor.R;
                fsave.GridLongLineColor.G = Grid.longLineColor.G;
                fsave.GridLongLineColor.B = Grid.longLineColor.B;

                fsave.GridSmallLineColor.R = Grid.smallLineColor.R;
                fsave.GridSmallLineColor.G = Grid.smallLineColor.G;
                fsave.GridSmallLineColor.B = Grid.smallLineColor.B;

                fsave.GridBackgroundColor.R = Grid.backgroundColor.R;
                fsave.GridBackgroundColor.G = Grid.backgroundColor.G;
                fsave.GridBackgroundColor.B = Grid.backgroundColor.B;

                fsave.GridFontColor.R = Grid.fontColor.R;
                fsave.GridFontColor.G = Grid.fontColor.G;
                fsave.GridFontColor.B = Grid.fontColor.B;

                fsave.GridFontSize = Grid.fontSize;
                fsave.GridOrigoFeedX = Grid.OrigoFeed.Width;
                fsave.GridOrigoFeedY = Grid.OrigoFeed.Height;
                fsave.GridXMin = Grid.XMin;
                fsave.GridXMax = Grid.XMax;
                fsave.GridYMin = Grid.YMin;
                fsave.GridYMax = Grid.YMax;
                fsave.GridXIntervals = Grid.xIntervals;
                fsave.GridYIntervals = Grid.yIntervals;

                fsave.GridGridColor.R = Grid.gridColor.R;
                fsave.GridGridColor.G = Grid.gridColor.G;
                fsave.GridGridColor.B = Grid.gridColor.B;

                fsave.GridIsGrid = Grid.isGrid;
                fsave.GridIsXY = Grid.isXY;
                fsave.GridIsBorder = Grid.isBorder;
                fsave.GridIsArrow = Grid.isArrow;
                fsave.GridPiCoordinates = Grid.piCoordinates;

                fsave.shouldXCrossTextDraw = Settings.shouldxCrossPointsDraw;

                fsave.xCrossTextColor.R = Settings.xCrossPointFontColor.R;
                fsave.xCrossTextColor.G = Settings.xCrossPointFontColor.G;
                fsave.xCrossTextColor.B = Settings.xCrossPointFontColor.B;

                foreach (xCrossEntry entry in FStatic.xCrossList)
                {
                    FunctionSavexCrossEntry fentry = new FunctionSavexCrossEntry();

                    fentry.x = entry.x;
                    fentry.y = entry.y;
                    fentry.X = entry.X;
                    fentry.Y = entry.Y;
                    fentry.name = entry.name;
                    fentry.selected = entry.selected;

                    fsave.xCrossList.Add(fentry);
                }

                foreach (Function f in FStatic.Functions)
                {
                    FunctionSaveEntry fentry = new FunctionSaveEntry();

                    fentry.Text = f.Text;
                    fentry.selected = f.selected;
                    fentry.name = f.name;

                    fentry.fs.color.R = f.fS.Color.R;
                    fentry.fs.color.G = f.fS.Color.G;
                    fentry.fs.color.B = f.fS.Color.B;
                    fentry.fs.Thickness = f.fS.Thickness;
                    fentry.fs.Visible = f.fS.Visible;
                    fentry.fs.Notes = f.fS.Notes;
                    fentry.fs.Precisity = f.fS.Precisity;
                    fentry.fs.NameDraw = f.fS.NameDraw;
                    fentry.fs.NameDrawPoint = f.fS.NameDrawPoint;

                    for (int i = 0; i < 10; i++)
                    {
                        fentry.pArray[i].value = f.pArray[i].value;
                        fentry.pArray[i].minValue = f.pArray[i].minValue;
                        fentry.pArray[i].maxValue = f.pArray[i].maxValue;
                        fentry.pArray[i].frequency = f.pArray[i].frequency;
                    }

                    fsave.functions.Add(fentry);
                }

                //save to file
                TextWriter w = default(TextWriter);

                try
                {
                    XmlSerializer s = new XmlSerializer(typeof(FunctionSave));
                    w = new StreamWriter(path);
                    s.Serialize(w, fsave);
                }
                finally
                {
                    if (w != null)
                    {
                        w.Close();
                    }

                    this.Text = "GraphDraw - " + Path.GetFileName(path);
                    isOpenFile = true;
                }

                shouldSave = false;
            }
            return true;
        }

        public void OpenFunctions(string path)
        {
            DialogResult dr = DialogResult.No;

            if (isOpenFile)
            {
                string message = "Do you want to save changes";

                if (!isSaved)
                {
                    message += "?";
                }
                else
                {
                    message += " to\n" + filePath + "?";
                }

                dr = MessageBox.Show(message, "Save File", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

                if (dr == DialogResult.Yes)
                {
                    SaveFunctions();
                }
            }

            if (dr != DialogResult.Cancel)
            {
                FStatic.Functions.Clear();
                FStatic.xCrossList.Clear();
                FStatic.AnnotationList.Clear();
                this.freeDrawStore.Clear();

                Grid.Initialize();

                FunctionSave result = default(FunctionSave);
                TextReader r = default(TextReader);

                try
                {
                    XmlSerializer s = new XmlSerializer(typeof(FunctionSave));
                    r = new StreamReader(path);
                    result = s.Deserialize(r) as FunctionSave;

                    FStatic.Functions.Clear();

                    Grid.longLineColor = Color.FromArgb(result.GridLongLineColor.R, result.GridLongLineColor.G, result.GridLongLineColor.B);
                    Grid.smallLineColor = Color.FromArgb(result.GridSmallLineColor.R, result.GridSmallLineColor.G, result.GridSmallLineColor.B);
                    Grid.backgroundColor = Color.FromArgb(result.GridBackgroundColor.R, result.GridBackgroundColor.G, result.GridBackgroundColor.B);
                    Grid.fontColor = Color.FromArgb(result.GridFontColor.R, result.GridFontColor.G, result.GridFontColor.B);

                    Grid.fontSize = result.GridFontSize;
                    Grid.OrigoFeed.Width = result.GridOrigoFeedX;
                    Grid.OrigoFeed.Height = result.GridOrigoFeedY;
                    Grid.XMin = result.GridXMin;
                    Grid.XMax = result.GridXMax;
                    Grid.YMin = result.GridYMin;
                    Grid.YMax = result.GridYMax;
                    Grid.xIntervals = result.GridXIntervals;
                    Grid.yIntervals = result.GridYIntervals;
                    Grid.piCoordinates = result.GridPiCoordinates;
                    Grid.xyPixel();

                    Grid.gridColor = Color.FromArgb(result.GridGridColor.R, result.GridGridColor.G, result.GridGridColor.B);
                    Grid.isGrid = result.GridIsGrid;
                    Grid.isXY = result.GridIsXY;
                    Grid.isBorder = result.GridIsBorder;
                    Grid.isArrow = result.GridIsArrow;

                    Settings.shouldxCrossPointsDraw = result.shouldXCrossTextDraw;

                    Settings.xCrossPointFontColor = Color.FromArgb(result.xCrossTextColor.R, result.xCrossTextColor.G, result.xCrossTextColor.B);

                    foreach (FunctionSavexCrossEntry fentry in result.xCrossList)
                    {
                        xCrossEntry entry = new xCrossEntry(fentry.X, fentry.Y);

                        entry.x = fentry.x;
                        entry.y = fentry.y;
                        entry.name = fentry.name;
                        entry.selected = fentry.selected;

                        FStatic.xCrossList.Add(entry);
                    }

                    foreach (FunctionSaveEntry fentry in result.functions)
                    {
                        Function f = new Function(fentry.Text);

                        f.selected = fentry.selected;
                        f.name = fentry.name;

                        f.fS.Color = Color.FromArgb(fentry.fs.color.R, fentry.fs.color.G, fentry.fs.color.B);

                        f.fS.Thickness = fentry.fs.Thickness;
                        f.fS.Visible = fentry.fs.Visible;
                        f.fS.Notes = fentry.fs.Notes;
                        f.fS.Precisity = fentry.fs.Precisity;
                        f.fS.NameDraw = fentry.fs.NameDraw;
                        f.fS.NameDrawPoint = fentry.fs.NameDrawPoint;

                        for (int i = 0; i < 10; i++)
                        {
                            f.pArray[i].value = fentry.pArray[i].value;
                            f.pArray[i].minValue = fentry.pArray[i].minValue;
                            f.pArray[i].maxValue = fentry.pArray[i].maxValue;
                            f.pArray[i].frequency = fentry.pArray[i].frequency;
                        }

                        FStatic.Functions.Add(f);
                    }

                    this.Text = "GraphDraw - " + Path.GetFileName(path);
                    isSaved = true;
                    filePath = path;
                    isOpenFile = true;

                    DoRefresh(RefreshMode.All);
                }
                catch
                {
                    MessageBox.Show("Error while loading the file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (r != null)
                    {
                        r.Close();
                    }
                }

            }
        }

        #endregion

        #region SettingsSave

        public void SaveSettings()
        {
            SaveSettings fsave = new SaveSettings();

            //settings
            fsave.InvertColorsByCopy = Settings.InvertColorsByCopy;

            fsave.CopyFunctionListWithColor = Settings.CopyFunctionListWithColor;
            fsave.CopyFunctionWithName = Settings.CopyFunctionWithName;
            fsave.InvertColorsByCopy = Settings.InvertColorsByCopy;
            fsave.KeyInterval = Settings.KeyInterval;
            fsave.parameterGreatScreenFontSize = Settings.parameterGreatScreenFontSize;
            fsave.parameterGreatScreenLabel1Location.x = Settings.parameterGreatScreenLabel1Location.X;
            fsave.parameterGreatScreenLabel1Location.y = Settings.parameterGreatScreenLabel1Location.Y;
            fsave.printNotes = Settings.printNotes;
            fsave.shouldOnTop = Settings.shouldOnTop;
            fsave.shouldxCrossPointsDraw = Settings.shouldxCrossPointsDraw;
            fsave.ShowBalloonTips = Settings.ShowBalloonTips;

            fsave.xCrossPointFontColor.R = Settings.xCrossPointFontColor.R;
            fsave.xCrossPointFontColor.G = Settings.xCrossPointFontColor.G;
            fsave.xCrossPointFontColor.B = Settings.xCrossPointFontColor.B;

            fsave.parametersPanel = parameterPanel.Visible;

            FStatic.GetForm(Forms.FunctionList).Bounds = functionItemsForm.Bounds;
            FStatic.GetForm(Forms.KeyBoard).Bounds = keyboardFormControl.Bounds;
            FStatic.GetForm(Forms.ParameterWindow).Bounds = parameterGreatScreen.Bounds;
            FStatic.GetForm(Forms.xCrossWindow).Bounds = xcrossWindow.Bounds;
            FStatic.GetForm(Forms.MainForm).Bounds = this.Bounds;
            FStatic.GetForm(Forms.MainForm).isMaximized = this.Maximized;

            foreach (FormProperty formProperty in Settings.formProperties)
            {
                FormBounds f = new FormBounds();

                f.x = formProperty.Bounds.X;
                f.y = formProperty.Bounds.Y;
                f.width = formProperty.Bounds.Width;
                f.height = formProperty.Bounds.Height;

                f.visible = formProperty.menu.Checked;

                fsave.formBounds.Add(f);
            }

            //save to file
            TextWriter w = default(TextWriter);

            try
            {
                XmlSerializer s = new XmlSerializer(typeof(SaveSettings));

                string path = Settings.programPath + "config.xml";
                w = new StreamWriter(path);
                s.Serialize(w, fsave);
            }
            finally
            {
                if (w != null)
                {
                    w.Close();
                }
            }
        }

        public void OpenSettings()
        {
            SaveSettings result = default(SaveSettings);
            TextReader r = default(TextReader);
            string path = Settings.programPath + "config.xml";

            try
            {
                r = new StreamReader(path);
            }
            catch
            {
                MessageBox.Show("Config.xml not found!\nLoading default settings!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SaveSettings();
            }
            finally
            {
                if (r != null)
                {
                    r.Close();
                }


                try
                {
                    XmlSerializer s = new XmlSerializer(typeof(SaveSettings));

                    r = new StreamReader(path);
                    result = s.Deserialize(r) as SaveSettings;
                }
                catch
                {
                    result = new SaveSettings();
                    result.InvertColorsByCopy = true;
                }
                finally
                {
                    if (r != null)
                    {
                        r.Close();
                    }
                }

                //load settings
                Settings.CopyFunctionListWithColor = result.CopyFunctionListWithColor;
                Settings.CopyFunctionWithName = result.CopyFunctionWithName;
                Settings.InvertColorsByCopy = result.InvertColorsByCopy;
                Settings.KeyInterval = result.KeyInterval;
                Settings.parameterGreatScreenFontSize = result.parameterGreatScreenFontSize;

                Settings.parameterGreatScreenLabel1Location = new Point(result.parameterGreatScreenLabel1Location.x, result.parameterGreatScreenLabel1Location.y);

                Settings.printNotes = result.printNotes;
                Settings.shouldOnTop = result.shouldOnTop;
                Settings.shouldxCrossPointsDraw = result.shouldxCrossPointsDraw;
                Settings.ShowBalloonTips = result.ShowBalloonTips;
                Settings.xCrossPointFontColor = Color.FromArgb(result.xCrossPointFontColor.G, result.xCrossPointFontColor.G, result.xCrossPointFontColor.B);

                ChangeParametersVisible(result.parametersPanel);

                int i = 0;
                foreach (FormBounds f in result.formBounds)
                {
                    Settings.formProperties[i].Bounds.X = f.x;
                    Settings.formProperties[i].Bounds.Y = f.y;
                    Settings.formProperties[i].Bounds.Width = f.width;
                    Settings.formProperties[i].Bounds.Height = f.height;

                    Settings.formProperties[i].menu.Checked = f.visible;

                    if (Settings.formProperties[i].Id == Forms.FunctionList)
                    {
                        functionItemsForm.Visible = f.visible;
                        functionItemsForm.Bounds = Settings.formProperties[i].Bounds;
                    }

                    if (Settings.formProperties[i].Id == Forms.KeyBoard)
                    {
                        keyboardFormControl.Visible = f.visible;
                        keyboardFormControl.Bounds = Settings.formProperties[i].Bounds;
                    }

                    if (Settings.formProperties[i].Id == Forms.ParameterWindow)
                    {
                        parameterGreatScreen.Visible = f.visible;
                        parameterGreatScreen.Bounds = Settings.formProperties[i].Bounds;
                    }

                    if (Settings.formProperties[i].Id == Forms.xCrossWindow)
                    {
                        xcrossWindow.Visible = f.visible;
                        xcrossWindow.Bounds = Settings.formProperties[i].Bounds;
                    }

                    if (Settings.formProperties[i].Id == Forms.MainForm)
                    {
                        this.Bounds = Settings.formProperties[i].Bounds;
                    }

                    i++;
                }

                DoRefresh(RefreshMode.All);
            }            
        }

        #endregion

        private void canvas_Click(object sender, EventArgs e)
        {

        }
    }
}