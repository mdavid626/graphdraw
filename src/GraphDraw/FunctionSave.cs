using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GraphDraw
{
    public class FunctionSave
    {
        public List<FunctionSaveEntry> functions;
        public List<FunctionSavexCrossEntry> xCrossList;

        public SaveColor GridLongLineColor;
        public SaveColor GridSmallLineColor;
        public SaveColor GridBackgroundColor;
        public SaveColor GridFontColor;
        public int GridFontSize;
        public int GridOrigoFeedX;
        public int GridOrigoFeedY;
        public double GridXMin;
        public double GridXMax;
        public double GridYMin;
        public double GridYMax;
        public int GridXIntervals;
        public int GridYIntervals;

        public SaveColor GridGridColor;

        public bool GridIsGrid;
        public bool GridIsXY;
        public bool GridIsBorder;
        public bool GridIsArrow;
        public bool GridPiCoordinates;

        public bool shouldXCrossTextDraw;
        public SaveColor xCrossTextColor;

        public FunctionSave()
        {
            functions = new List<FunctionSaveEntry>();
            xCrossList = new List<FunctionSavexCrossEntry>();

            GridLongLineColor = new SaveColor();
            GridSmallLineColor = new SaveColor();
            GridBackgroundColor = new SaveColor();
            GridFontColor = new SaveColor();
            GridGridColor = new SaveColor();

            xCrossTextColor = new SaveColor();
        }
    }

    public class FunctionSaveEntry
    {
        public string Text;
        public bool selected;
        public string name;
        public FunctionSaveEntryFS fs;
        public FunctionSaveEntryParameter[] pArray;

        public FunctionSaveEntry()
        {
            fs = new FunctionSaveEntryFS();
            pArray = new FunctionSaveEntryParameter[10];

            for (int i = 0; i < 10; i++)
            {
                pArray[i] = new FunctionSaveEntryParameter();
            }
        }
    }

    public class FunctionSaveEntryFS
    {
        public SaveColor color;
        public float Thickness;
        public bool Visible;
        public string Notes;
        public int Precisity;
        public bool NameDraw;
        public Point NameDrawPoint;
        public bool IsNameDraw;

        public FunctionSaveEntryFS()
        {
            color = new SaveColor();
        }
    }

    public class FunctionSaveEntryParameter
    {
        public double value;
        public double minValue;
        public double maxValue;
        public double frequency;
    }

    public class FunctionSavexCrossEntry
    {
        public string x;
        public string y;

        public double X;
        public double Y;

        public bool selected;

        public string name;
    }
}
