using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GraphDraw
{
    static class Grid
    {
        //points
        public static Point Origo; //a canvas abszolut kozeppontja
        private static Point porigo;//a koordinata rendszer abszolut kozeppontja

        public static Point LeftOrigoRelative;
        public static Point RightOrigoRelative;
        public static Point UpOrigoRelative;
        public static Point DownOrigoRelative;

        public static Size OrigoFeed;

        private static double xPixel;
        private static double yPixel;

        private static double xMin;
        private static double xMax;
        private static double yMin;
        private static double yMax;
        private static double xLeptek;
        private static double yLeptek;

        public static int xIntervals;
        public static int yIntervals;

        public static bool piCoordinates;

        public static Size SizeOfCanvas;

        //colors
        public static Color longLineColor;
        public static Color smallLineColor;
        public static Color backgroundColor;
        public static Color fontColor;
        public static Color gridColor;

        //bool
        public static bool isGrid;
        public static bool isXY;
        public static bool isBorder;
        public static bool isArrow;

        //for drawing
        //pens
        private static Pen longLinePen;
        private static Pen smallLinePen;
        private static Pen gridPen;

        //brushes
        private static SolidBrush fontBrush;
        private static SolidBrush backgroundBrush;

        //fonts
        private static Font font;

        public static int fontSize;

        private static int smallLine = 5;
        private static int textSpace = 7;

        private static int textAlignX;


        #region Properties

        public static Point pOrigo
        {
            get
            {
                return porigo;
            }

            set
            {
                OrigoFeed = new Size(value.X - Origo.X, value.Y - Origo.Y);
                porigo = value;
            }
        }

        public static double XMin
        {
            get 
            { 
                return xMin; 
            }

            set
            {
                double n = Math.Abs(value);
                if (n <= 100000) xMin = value;
            }
        }

        public static double XMax
        {
            get
            {
                return xMax;
            }

            set
            {
                double n = Math.Abs(value);
                if (n <= 100000) xMax = value;
            }
        }

        public static double YMin
        {
            get
            {
                return yMin;
            }

            set
            {
                double n = Math.Abs(value);
                if (n <= 100000) yMin = value;
            }
        }

        public static double YMax
        {
            get
            {
                return yMax;
            }

            set
            {
                double n = Math.Abs(value);
                if (n <= 100000) yMax = value;
            }
        }
        #endregion

        public static void Initialize()
        {
            Grid.longLineColor = Color.White;
            Grid.smallLineColor = Color.White;
            Grid.backgroundColor = Color.Black;
            Grid.fontColor = Color.White;

            gridColor = Color.Gray;
            isGrid = false;
            isXY = false;
            isBorder = true;
            isArrow = false;

            fontBrush = new SolidBrush(fontColor);
            backgroundBrush = new SolidBrush(backgroundColor);
            

            /* patriknak :)
            Grid.longLineColor = Color.Black;
            Grid.smallLineColor = Color.Black;
            Grid.backgroundColor = Color.White;
            Grid.fontColor = Color.Black;

            gridColor = Color.Gray;
            isGrid = false;
            isXY = false;
            isBorder = true;
            isArrow = false;

            fontBrush = new SolidBrush(fontColor);
            backgroundBrush = new SolidBrush(backgroundColor);
             */ 

            longLinePen = new Pen(longLineColor, 2.0f);
            smallLinePen = new Pen(smallLineColor);
            gridPen = new Pen(gridColor);

            fontSize = 9;

            textAlignX = 8;

            OrigoFeed = new Size(0, 0);

            xMin = -4;
            xMax = 4;
            yMin = -4;
            yMax = 4;

            xIntervals = 8;
            yIntervals = 8;

            xyPixel();

            isGrid = true;
        }

        public static void setXY()
        {
            XMin = Grid.RealX(-pOrigo.X + 15);
            XMax = Grid.RealX(SizeOfCanvas.Width - pOrigo.X - 15);
            YMin = Grid.RealY(pOrigo.Y - SizeOfCanvas.Height + 15);
            YMax = Grid.RealY(pOrigo.Y - 15);
        }

        public static void Set(Size s)
        {
            SizeOfCanvas = s;
            
            Origo = new Point(SizeOfCanvas.Width / 2, SizeOfCanvas.Height / 2);

            //pOrigo = new Point(Origo.X + OrigoFeed.Width, Origo.Y + OrigoFeed.Height);
            //Grid.pOrigo = new Point(Grid.PixelX(-xMin) + 15, Grid.PixelY(yMax) + 15);

            LeftOrigoRelative = new Point(-pOrigo.X, 0);
            RightOrigoRelative = new Point(SizeOfCanvas.Width - pOrigo.X, 0);
            UpOrigoRelative = new Point(0, pOrigo.Y);
            DownOrigoRelative = new Point(0, pOrigo.Y - SizeOfCanvas.Height);


            font = new Font(new FontFamily("Arial"), fontSize, FontStyle.Regular);

            fontBrush.Color = fontColor;
            backgroundBrush.Color = backgroundColor;

            longLinePen.Color = longLineColor;
            smallLinePen.Color = smallLineColor;

            gridPen.Color = gridColor;
            gridPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
        }

        public static void xyPixel()
        {
            double xInt = 1;
            double yInt = 1;

            if (xMin <= 0 && xMax >= 0) xInt = Math.Abs(xMin) + Math.Abs(xMax);
            if (xMin >= 0 && xMax >= 0) xInt = xMax - xMin;
            if (xMin <= 0 && xMax <= 0) xInt = Math.Abs(xMin) - Math.Abs(xMax);

            if (yMin <= 0 && yMax >= 0) yInt = Math.Abs(yMin) + Math.Abs(yMax);
            if (yMin >= 0 && yMax >= 0) yInt = yMax - yMin;
            if (yMin <= 0 && yMax <= 0) yInt = Math.Abs(yMin) - Math.Abs(yMax);

            xPixel = (SizeOfCanvas.Width-30) / xInt;
            yPixel = (SizeOfCanvas.Height-30) / yInt;

            xLeptek = xInt / xIntervals;
            yLeptek = yInt / yIntervals;

            Grid.pOrigo = new Point(Grid.PixelX(-xMin) + 15, Grid.PixelY(yMax) + 15);
        }

        public static void Draw(Graphics g, Size s)
        {
            Set(s);

            //clear the canvas
            g.FillRectangle(backgroundBrush, new Rectangle(new Point(0, 0), SizeOfCanvas));

            //long lines
            g.DrawLine(longLinePen, T(LeftOrigoRelative), T(RightOrigoRelative));
            g.DrawLine(longLinePen, T(UpOrigoRelative), T(DownOrigoRelative));


            //border
            
            if (isBorder)
            {
                int width = SizeOfCanvas.Width - 1;
                int height = SizeOfCanvas.Height - 1;

                Point leftTop = new Point(1, 1);
                Point rightTop = new Point(width, 1);
                Point leftBottom = new Point(1, height);
                Point rightBottom = new Point(width, height - 1);

                g.DrawLine(longLinePen, leftTop, rightTop);
                g.DrawLine(longLinePen, rightTop, rightBottom);
                g.DrawLine(longLinePen, rightBottom, leftBottom);
                g.DrawLine(longLinePen, leftBottom, leftTop);
            }

            if (isArrow)
            {
                Pen arrowPen = new Pen(longLineColor, 1.0f);

                Point p1 = T(UpOrigoRelative);
                Point p2 = T(new Point(UpOrigoRelative.X - 4, UpOrigoRelative.Y - 12));
                g.DrawLine(arrowPen, p1, p2);

                p2 = T(new Point(UpOrigoRelative.X + 4, UpOrigoRelative.Y - 12));
                g.DrawLine(arrowPen, p1, p2);

                p1 = T(RightOrigoRelative);
                p2 = T(new Point(RightOrigoRelative.X - 12, RightOrigoRelative.Y - 4));
                g.DrawLine(arrowPen, p1, p2);

                p2 = T(new Point(RightOrigoRelative.X - 12, RightOrigoRelative.Y + 4));
                g.DrawLine(arrowPen, p1, p2);
            }

            if (isGrid)
            {
                int xp = (int)(SizeOfCanvas.Width / 10);
                int yp = (int)(SizeOfCanvas.Height / 10);

                int i = pOrigo.X + xp;
                for (; i < T(RightOrigoRelative).X; i += xp)
                {
                    Point pp1 = new Point(i, 0);
                    Point pp2 = new Point(i, SizeOfCanvas.Height);
                    g.DrawLine(gridPen, pp1, pp2);
                }

                i = pOrigo.X - xp;
                for (; i > T(LeftOrigoRelative).X; i -= xp)
                {
                    Point pp1 = new Point(i, 0);
                    Point pp2 = new Point(i, SizeOfCanvas.Height);
                    g.DrawLine(gridPen, pp1, pp2);
                }

                i = pOrigo.Y + yp;
                for (; i < T(DownOrigoRelative).Y; i += yp)
                {
                    Point pp1 = new Point(0, i);
                    Point pp2 = new Point(SizeOfCanvas.Width, i);
                    g.DrawLine(gridPen, pp1, pp2);
                }

                i = pOrigo.Y - yp;
                for (; i > T(UpOrigoRelative).Y; i -= yp)
                {
                    Point pp1 = new Point(0, i);
                    Point pp2 = new Point(SizeOfCanvas.Width, i);
                    g.DrawLine(gridPen, pp1, pp2);
                }
            }

            if (isXY)
            {
                Point p3 = T(new Point(UpOrigoRelative.X - 20, UpOrigoRelative.Y - fontSize / 2));
                g.DrawString("y", font, fontBrush, p3);

                Point p4 = T(new Point(RightOrigoRelative.X - 15, RightOrigoRelative.Y  - 17));
                g.DrawString("x", font, fontBrush, p4);
            }
            //small lines

            //horizontal - x
            
            if (!piCoordinates)
            {
                for (double i = 0; i <= xMax+0.1; i += xLeptek)
                {
                    xLines(i, g);
                }

                for (double i = 0; i >= xMin-0.1; i -= xLeptek)
                {
                    xLines(i, g);
                }
            }
            else
            {
                for (double i = 0; i <= xMax+0.1; i += xLeptek)
                {
                    xLinesPi(i, g);
                }

                for (double i = 0; i >= xMin-0.1; i -= xLeptek)
                {
                    xLinesPi(i, g);
                }
            }

            //vertical - y
            for (double i = 0; i <= yMax+0.1; i += yLeptek)
            {
                yLines(i, g);
            }

            for (double i = 0; i >= yMin-0.1; i -= yLeptek)
            {
                yLines(i, g);
            }
        }

        public static double RealX(int value)
        {
            double result = 0;
            if (xPixel != 0) result = value / xPixel;

            return result;
        }

        public static double RealY(int value)
        {
            double result = 0;
            if (yPixel != 0) result = value / yPixel;

            return result;
        }

        public static int PixelX(double value)
        {
            //int result = (int)Math.Round(value * xPixel, 0, MidpointRounding.ToEven);
            return (int)(value * xPixel);
        }

        public static int PixelY(double value)
        {
            //int result = (int)Math.Round(value * yPixel, 0, MidpointRounding.ToEven);
            return (int)(value * yPixel);
        }

        public static Point T(Point p)
        {
            return new Point(pOrigo.X + p.X, pOrigo.Y - p.Y);
        }

        public static Point TReverse(Point p)
        {
            return new Point(p.X - pOrigo.X, pOrigo.Y - p.Y);
        }

        private static string GetText(double number)
        {
            return Convert.ToString(String.Format("{0:0.###}", number));
            //return Convert.ToString(String.Format("{0:0.####################}",number));
        }

        private static string GetTextPi(double number)
        {
            string result = "";

            //double pi = Math.Round(Math.PI, 2);
            double pi = Math.PI;

            double res = Math.Round(number / pi, 3);

            if (Math.Abs(res) != 1) result = Convert.ToString(String.Format("{0:0.###}", res));
           
            result += "π";

            return result;
        }

        public static bool IsOnCanvas(Point p)
        {
            return p.X >= 0 && p.X <= SizeOfCanvas.Width && p.Y >= 0 && p.Y <= SizeOfCanvas.Height;
        }

        private static int AlignTextX(string text)
        {
            return (int)(text.Length * textAlignX / 2.0);
        }

        private static int AlignTextY()
        {
            return (int)(4 * fontSize / 5.0);
        }

        private static void xLines(double i, Graphics g)
        {
            int x = PixelX(i);

            Point p1 = T(new Point(x, smallLine));
            Point p2 = T(new Point(x, -smallLine));

            g.DrawLine(smallLinePen, p1, p2);


            string text = GetText(i);

            Point p3 = T(new Point(x - AlignTextX(text), -textSpace));

            if (i != 0) g.DrawString(text, font, fontBrush, p3);
        }

        private static void xLinesPi(double i, Graphics g)
        {
            int x = PixelX(i);

            Point p1 = T(new Point(x, smallLine));
            Point p2 = T(new Point(x, -smallLine));

            g.DrawLine(smallLinePen, p1, p2);


            string text = GetTextPi(i);

            Point p3 = T(new Point(x - AlignTextX(text), -textSpace));

            if (i != 0) g.DrawString(text, font, fontBrush, p3);
        }

        private static void yLines(double i, Graphics g)
        {
            int y = PixelY(i);

            Point p1 = T(new Point(smallLine, y));
            Point p2 = T(new Point(-smallLine, y));

            g.DrawLine(smallLinePen, p1, p2);


            string text = GetText(i);

            Point p3 = T(new Point(textSpace, y + AlignTextY()));

            if (i != 0) g.DrawString(text, font, fontBrush, p3);
        }
    }
}
