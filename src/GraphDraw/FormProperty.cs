using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace GraphDraw
{
    class FormProperty
    {
        public Forms Id;
        public Rectangle Bounds;
        public ToolStripMenuItem menu;
        public bool isMaximized;

        public FormProperty(Forms id, Rectangle mBounds, bool visible, ToolStripMenuItem menu)
        {
            this.Id = id;
            this.Bounds = mBounds;
            this.menu = menu;
            this.menu.Checked = visible;
            this.isMaximized = false;
        }
    }
}
