using System;
using System.Collections.Generic;
using System.Text;

namespace ParameterControlLibrary
{
    public class ParameterControlEventArgs
    {
        public double Value;
        public int Id;
        public string Name;
        public double MinValue;
        public double MaxValue;
        public double Frequency;

        public ParameterControlEventArgs(double value, int id, string name, double minValue, double maxValue, double frequency)
        {
            Value = value;
            Id = id;
            Name = name;

            MinValue = minValue;
            MaxValue = maxValue;
            Frequency = frequency;
        }
    }
}
