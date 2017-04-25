using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GraphDraw
{
    class xCrossEntry
    {
        public string x;
        public string y;

        public double X;
        public double Y;

        public bool selected;

        public string name;

        public xCrossEntry(double x, double y)
        {
            this.X = x;
            this.Y = y;

            this.x = Convert.ToString(x);
            this.y = Convert.ToString(y);

            selected = false;

            name = "[ " + x + " ; " + y + " ]";
        }

        public void DrawPointsCoordinates(Graphics g)
        {
            Point p = Grid.T(new Point(Grid.PixelX(X), Grid.PixelY(Y)));
            g.DrawString(name, new Font("Arial", 12, FontStyle.Regular) ,new SolidBrush(Settings.xCrossPointFontColor), p);
        }

        public void Draw(Graphics g)
        {
            Color fillColor = Color.Red;
            Color lineColor = Color.Yellow;
            int r = 3;

            if (selected)
            {
                //ha ki van valasztva
                r = 8;
                fillColor = Color.Red;
                lineColor = Color.Yellow;
            }
            else
            {
                //ha nincs kivalasztva
                r = 3;
                fillColor = Color.Red;
                lineColor = Color.Yellow;
            }

            int xt = Grid.PixelX(X);
            int yt = Grid.PixelY(Y);

            Point p = Grid.T(new Point(xt, yt));

            Rectangle rec = new Rectangle(new Point(p.X - r, p.Y - r), new Size(2 * r, 2 * r));

            g.FillEllipse(new SolidBrush(fillColor), rec);
            g.DrawEllipse(new Pen(lineColor), rec);

            if (Settings.shouldxCrossPointsDraw)
            {
                DrawPointsCoordinates(g);
            }
        }
    }
}
