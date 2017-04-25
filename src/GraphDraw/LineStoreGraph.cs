using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GraphDraw
{
    class LineStoreGraph
    {
        public Point p1, p2;
        public Point pr1, pr2;
        public bool active;
        public Pen pen;

        private void Store(Point r1, Point r2)
        {
            p1 = Grid.T(r1);
            p2 = Grid.T(r2);

            pr1 = r1;
            pr2 = r2;
        }

        public LineStoreGraph(Point r1, Point r2)
        {
            Store(r1, r2);

            active = false;
            pen = new Pen(Color.White);
        }

        public LineStoreGraph(Point r1, Point r2, Pen pen)
        {
            Store(r1, r2);

            active = false;
            this.pen = pen;
        }
    }
}
