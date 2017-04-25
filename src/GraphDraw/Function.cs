using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using SevenZ.Calculator;

namespace GraphDraw
{
    public class Function
    {
        private string text;
        public bool itsOk;
        public bool selected;
        public string name;
        public bool shouldRecount;
        
        //pen for drawing
        private Pen pen;
        
        //beallitasokra
        public FunctionSettings fS;

        //a vonalak eltarolasara
        public ArrayList sequenceStore = new ArrayList();

        //a parameterek tarolasara
        public Parameter[] pArray = new Parameter[pArraySize];

        //a text feldolgozasara
        private Calculator clc = new Calculator();

        //constansok
        private const int pArraySize = 10;
        private readonly string[] pChar = { "a", "b", "c", "d", "f", "g", "h", "i", "j", "k" };
        private readonly string[] abc = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l","m",
                                          "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        private readonly string abcString = "abcdefghijklmnopqrstuvwxyz";

        public string Text
        {
            get
            {
                return text;
            }

            set
            {
                text = value;
                Set();
            }
        }

        public Function()
        {
            itsOk = true;
        }

        public Function(string t)
        {
            //letrehozom rogton az elejen a parametereket mert szukseg lesz ra
            for (int i = 0; i < pArraySize; i++)
            {
                pArray[i] = new Parameter(pChar[i], 1);
            }

            //uj fuggveny ezert legyen kijelolve
            selected = true;

            //inicializalja a fuggveny settingjeit
            fS = new FunctionSettings();

            //get a new random color
            Random random = new Random();

            fS.Color = Color.FromArgb((random.Next(0, 255)),
                                      (random.Next(0, 255)),
                                      (random.Next(0, 255)));

            fS.NameDraw = false;

            //legyen lathato
            fS.Visible = true;

            //es legyen 1 a vastagsaga
            fS.Thickness = 1f;

            //pontossag
            fS.Precisity = 1;

            //notes
            fS.Notes = "";


            // inicializalja a fuggvenyt
            Text = t;
        }

        private void Set()
        {
            for (int i = 0; i < clc.active.Length; i++)
            {
                clc.active[i] = false;
            }

            clc.Qs = true;

            Count();

            clc.Qs = false;

            for (int i = 0; i < pArraySize; i++)
            {
                pArray[i].active = clc.active[i];
            }

            if (itsOk) ReCount();
        }

        private double Count()
        {
            try
            {
                double result = clc.Evaluate(Text);
                itsOk = true;
                return result;
            }
            catch (CalculateException ex)
            {
                MessageBox.Show(ex.Message, "Calculator error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                itsOk = false;
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\nPlease check if any of binary functions is missing one of it's input parameters",
                "Calculator error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                itsOk = false;
                return -1;
            }
        }

        public void ReCount()
        {
            sequenceStore.Clear();

            int i = Grid.LeftOrigoRelative.X;

            int _y = Grid.PixelY(Y(Grid.RealX(i)));

            for (; i <= Grid.RightOrigoRelative.X; i += fS.Precisity)
            {
                int y = Grid.PixelY(Y(Grid.RealX(i + fS.Precisity)));

                Point p1 = new Point(i, _y);
                Point p2 = new Point(i + fS.Precisity, y);

                LineStoreGraph ln = new LineStoreGraph(p1, p2);
                sequenceStore.Add(ln);

                if (Grid.IsOnCanvas(ln.p1) && Grid.IsOnCanvas(ln.p2))
                {
                    ln.active = true;
                }

                _y = y;
            }

            fS.IsNameDraw = false;

            if (sequenceStore.Count > 0)
            {
                Random rand = new Random();
                int t = rand.Next(sequenceStore.Count - 1);
                fS.IsNameDraw = false;

                i = 0;
                foreach (LineStoreGraph ln in sequenceStore)
                {
                    if (ln.active && t == i)
                    {
                        fS.NameDrawPoint = ln.p1;
                        fS.IsNameDraw = true;
                    }

                    i++;
                }
            }

            shouldRecount = false;
        }

        public double Y(double x)
        {            
            //beallitom az x erteket
            clc.SetVariable("x", x);

            //beallitom az osszes parameter erteket
            for (int i = 0; i < pArraySize; i++)
            {
                if (pArray[i].active)
                    clc.SetVariable(pChar[i], pArray[i].value);
            }

            return Count();
        }

        public string TrueValueToString()
        {
            string final = Text;

            for (int i = 0; i < pArraySize; i++)
            {
                string work = "";

                for (int j = 0; j < final.Length; j++)
                {
                    string p = pChar[i];
                    string b = Convert.ToString(final[j]);

                    string b1, b2;

                    //az elotte levo betut mentsuk el
                    if (j == 0)
                    {
                        b1 = "(";
                    }
                    else
                    {
                        b1 = Convert.ToString(final[j - 1]);
                    }

                    //itt az utana levot mentsuk
                    if (j == final.Length - 1)
                    {
                        b2 = "(";
                    }
                    else
                    {
                        b2 = Convert.ToString(final[j + 1]);
                    }

                    //itt pedig megnezzuk hogy abc egy betuje-e az elotte es utana levo betu
                    if (b == p && !abcString.Contains(b1) && !abcString.Contains(b2))
                    {
                        double val = pArray[i].value;
                        string valS = pArray[i].value.ToString();

                        if (val >= 0)
                        {
                            work += valS;
                        }
                        else
                        {
                            work += "(" + valS + ")";
                        }
                    }
                    else
                    {
                        work += final[j];
                    }
                        
                }

                final = work;
            }

            return final;
        }

        public void Draw(Graphics g)
        {
            pen = new Pen(fS.Color, fS.Thickness);

            if (fS.Visible)
            {
                foreach (LineStoreGraph lineSG in sequenceStore)
                {
                    if (lineSG.active) g.DrawLine(pen, lineSG.p1, lineSG.p2);
                }
            }

            if (fS.NameDraw && fS.IsNameDraw)
            {
                g.DrawString(this.name, new Font("Courier New", 12), new SolidBrush(fS.Color), fS.NameDrawPoint);
            }
        }
    }
}
