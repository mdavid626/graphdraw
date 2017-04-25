using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GraphDraw
{
    public partial class KeyBoardFormControl : Form
    {
        private bool IsMouseDown;
        private Point LastCursorPosition;
        private IFstatic _IFstatic;

        public KeyBoardFormControl(Main main)
        {
            InitializeComponent();

            _IFstatic = main;

            FormProperty formProperty = FStatic.GetForm(Forms.KeyBoard);
            this.Bounds = formProperty.Bounds;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseDown = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.IsMouseDown)
            {
                //Move the form
                this.Location = new Point(this.Left - (this.LastCursorPosition.X - e.X), this.Top - (this.LastCursorPosition.Y - e.Y));

                //Redraw the form//
                this.Invalidate();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
            LastCursorPosition = new Point(e.X, e.Y);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InsertText(object sender, EventArgs e)
        {
            string Text = "";

            if (sender == xButton) Text = "x";

            if (sender == number0Button) Text = "0";
            if (sender == number1Button) Text = "1";
            if (sender == number2Button) Text = "2";
            if (sender == number3Button) Text = "3";
            if (sender == number4Button) Text = "4";
            if (sender == number5Button) Text = "5";
            if (sender == number6Button) Text = "6";
            if (sender == number7Button) Text = "7";
            if (sender == number8Button) Text = "8";
            if (sender == number9Button) Text = "9";
            if (sender == dotSymbolButton) Text = ".";

            if (sender == aPButton) Text = "a";
            if (sender == bPButton) Text = "b";
            if (sender == cPButton) Text = "c";
            if (sender == dPButton) Text = "d";
            if (sender == fPButton) Text = "f";
            if (sender == gPButton) Text = "g";
            if (sender == hPButton) Text = "h";
            if (sender == iPButton) Text = "i";
            if (sender == jPButton) Text = "j";
            if (sender == kPButton) Text = "k";

            if (sender == sinButton) Text = "sin(";
            if (sender == cosButton) Text = "cos(";
            if (sender == tanButton) Text = "tg(";
            if (sender == aSinButton) Text = "arcsin(";
            if (sender == aCosButton) Text = "arccos(";
            if (sender == aTanButton) Text = "arctg(";
            if (sender == log10Button) Text = "log10(";
            if (sender == logButton) Text = "log(";
            if (sender == lnButton) Text = "ln(";
            if (sender == expButton) Text = "exp(";
            if (sender == absButton) Text = "abs(";
            if (sender == rtButton) Text = "rt(";
            if (sender == rootSymbolButton) Text = "^2";
            if (sender == root3SymbolButton) Text = "^3";
            if (sender == minus1PowerSymbolButton) Text = "1/";

            if (sender == addSymbolButton) Text = "+";
            if (sender == subtracktSymbolButton) Text = "-";
            if (sender == multipleSymbolButton) Text = "*";
            if (sender == divideSymbolButton) Text = "/";
            if (sender == separatorSymbolButton) Text = ";";
            if (sender == powerSymbolButton) Text = "^";
            if (sender == faktorialSymbolButton) Text = "!";
            if (sender == parenthesesOpenButton) Text = "(";
            if (sender == piSymbolButton) Text = "pi";
            if (sender == sqrtButton) Text = "sqrt(";
            if (sender == modSymbolButton) Text = "%";
            if (sender == parenthesesCloseButton) Text = ")";
            if (sender == eSymbolButton) Text = "e";

            _IFstatic.AddTextToMainInput(Text);
        }

        private void Clear(object sender, EventArgs e)
        {
            _IFstatic.ClearText();
        }

        private void addFunctionButton_Click(object sender, EventArgs e)
        {
            _IFstatic.AddFromKeyboarFunction();
        }

        private void KeyBoardFormControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormProperty formProperty = FStatic.GetForm(Forms.KeyBoard);

            formProperty.Bounds = this.Bounds;
            formProperty.menu.Checked = false;
        }
    }

}