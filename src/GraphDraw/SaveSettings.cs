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
    public class SaveSettings
    {
        public bool InvertColorsByCopy;

        public int KeyInterval;
        public bool ShowBalloonTips;
        public bool CopyFunctionListWithColor;
        public bool CopyFunctionWithName;

        public float parameterGreatScreenFontSize;
        public SavePoint parameterGreatScreenLabel1Location;

        public bool shouldOnTop;
        public bool parametersPanel;

        //grid
        public bool border;

        public bool printNotes;

        //xCrossPaint
        public bool shouldxCrossPointsDraw;
        public SaveColor xCrossPointFontColor;

        public List<FormBounds> formBounds;

        public SaveSettings()
        {
            parameterGreatScreenLabel1Location = new SavePoint();
            xCrossPointFontColor = new SaveColor();

            formBounds = new List<FormBounds>();
        }
    }

    public class SaveColor
    {
        public int R;
        public int G;
        public int B;
    }

    public class SavePoint
    {
        public int x;
        public int y;
    }

    public class FormBounds
    {
        public int x;
        public int y;
        public int width;
        public int height;
        
        public bool visible;

        public string id;
    }
}
