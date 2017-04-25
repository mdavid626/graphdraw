using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GraphDraw
{
    class Annotation
    {
        public string text;
        public Font font;
        public Color color;
        public double x;
        public double y;

        public Annotation(string text, Font font, Color color, double x, double y)
        {
            this.text = text;
            this.font = font;
            this.color = color;
            this.x = x;
            this.y = y;
        }

        public void Draw(Graphics g)
        {
            g.DrawString(text, font, new SolidBrush(color), Grid.T(new Point(Grid.PixelX(x), Grid.PixelY(y))));
        }
    }
}
