using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GraphDraw
{
    public class FunctionSettings
    {
        public Color Color;
        public float Thickness;
        public bool Visible;
        public string Notes;
        public int Precisity; 
        public bool NameDraw;
        public Point NameDrawPoint;
        public bool IsNameDraw;

        public FunctionSettings()
        {
        }

        public FunctionSettings(Color color, float thickness, bool visible, string notes, int precisity)
        {
            Color = color;
            Thickness = thickness;
            Visible = visible;
            Notes = notes;
            Precisity = precisity;
        }
    }
}
