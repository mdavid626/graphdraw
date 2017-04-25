using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ParameterControlLibrary
{
    public delegate void ParameterControlEvents(object sender, ParameterControlEventArgs e);

    public partial class ParameterControl : UserControl
    {
        private double value;
        public double minValue;
        public double maxValue;
        public double frequency;

        public int Id;
        public string Name;

        private readonly string[] pChar = { "a", "b", "c", "d", "f", "g", "h", "i", "j", "k" };

        public event ParameterControlEvents ControlChanged;


        public double Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

        public double MinValue
        {
            get
            {
                return minValue;
            }

            set
            {
                minValue = value;
            }
        }

        public double MaxValue
        {
            get
            {
                return maxValue;
            }

            set
            {
                maxValue = value;
            }
        }

        public double Frequency
        {
            get
            {
                return frequency;
            }

            set
            {
                frequency = value;

                mainTrackBar.Minimum = (int)(MinValue / value);
                mainTrackBar.Maximum = (int)(MaxValue / value);
                mainTrackBar.Value = (int)(Value / value);

                decimal inc = (decimal)value;
                valueUpDown.Increment = inc;
                minValueUpDown.Increment = inc;
                maxValueUpDown.Increment = inc;

                frequencyUpDown.Value = inc;
            }
        }

        public ParameterControl()
        {
            InitializeComponent();
        }

        public void Initialize(int id, double _value, double _minValue, double _maxValue, double _frequency)
        {
            Id = id;

            if (Id > 9 || Id < 0) Id = 9;
            if (_minValue > _maxValue) _minValue = _maxValue - 1;
            if (_maxValue < _minValue) _maxValue = _minValue + 1;
            if (_value < _minValue || _value > _maxValue) _value = _minValue;

            Name = pChar[Id];

            label1.Text = Name + " =";

            Frequency = 100;
            frequencyUpDown.Value = (decimal)Frequency;

            minValueUpDown.Minimum = int.MinValue;
            maxValueUpDown.Maximum = int.MaxValue;

            valueUpDown.Minimum = (int)_minValue;
            mainTrackBar.Minimum = (int)(_minValue * Frequency);
            minValueUpDown.Value = (decimal)_minValue;

            valueUpDown.Maximum = (int)_maxValue;
            mainTrackBar.Maximum = (int)(_maxValue * Frequency);
            maxValueUpDown.Value = (decimal)_maxValue;

            Value = _value;
            valueUpDown.Value = (decimal)_value;
            MinValue = _minValue;
            MaxValue = _maxValue;
            Frequency = _frequency;
        }

        private void Change()
        {
            if (ControlChanged != null) ControlChanged(this, new ParameterControlEventArgs(Value, Id, Name, MinValue, MaxValue, Frequency));
        }

        private void mainTrackBar_Scroll(object sender, EventArgs e)
        {
            Value = mainTrackBar.Value * Frequency;
            valueUpDown.Value = (decimal)Value;

            Change();
        }

        private void valueUpDown_ValueChanged(object sender, EventArgs e)
        {
            Value = (double)valueUpDown.Value;
            mainTrackBar.Value = (int)(Value / Frequency);

            Change();
        }

        private void minValueUpDown_ValueChanged(object sender, EventArgs e)
        {
            MinValue = (double)minValueUpDown.Value;

            decimal vv = (decimal)MinValue;

            valueUpDown.Minimum = vv;
            mainTrackBar.Minimum = (int)((double)vv / Frequency);

            maxValueUpDown.Minimum = (int)vv;

            Change();
        }

        private void maxValueUpDown_ValueChanged(object sender, EventArgs e)
        {
            MaxValue = (double)maxValueUpDown.Value;

            decimal vv = (decimal)MaxValue;

            valueUpDown.Maximum = vv;
            mainTrackBar.Maximum = (int)((double)vv / Frequency);

            minValueUpDown.Maximum = (int)vv;

            Change();
        }

        private void frequencyUpDown_ValueChanged(object sender, EventArgs e)
        {
            Frequency = (double)frequencyUpDown.Value;

            Change();
        }
    }
}