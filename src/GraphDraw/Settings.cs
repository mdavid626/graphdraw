using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;

namespace GraphDraw
{
    static class Settings
    {
        public static List<FormProperty> formProperties;

        public static bool InvertColorsByCopy;
        public static int KeyInterval;
        public static bool ShowBalloonTips;
        public static bool CopyFunctionListWithColor;
        public static bool CopyFunctionWithName;

        public static float parameterGreatScreenFontSize;
        public static Point parameterGreatScreenLabel1Location;

        public static bool shouldOnTop;

        public static bool printNotes;

        //xCrossPaint
        public static bool shouldxCrossPointsDraw;
        public static Color xCrossPointFontColor;

        public static string programPath;

        //registration
        public static bool activated;
        public static int shdays;

        public static string regNumber;
    }
}
