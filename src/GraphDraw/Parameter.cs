using System;
using System.Collections.Generic;
using System.Text;

namespace GraphDraw
{
    public class Parameter
    {
        public double value;
        public double minValue;
        public double maxValue;
        public double frequency;

        public bool active;
        public string id;
        
        public Parameter(string name, double v)
        {
            value = v;
            id = name;

            active = false;

            minValue = -10;
            maxValue = 10;
            frequency = 0.01;
        }

        public Parameter(string name, double v, double _minValue, double _maxValue, double _frequency)
        {
            value = v;
            id = name;

            active = false;

            minValue = _minValue;
            maxValue = _maxValue;
            frequency = _frequency;
        }

        public double SetValue(double v)
        {
            value = v;
            active = true;
            return value;
        }
    }
}
