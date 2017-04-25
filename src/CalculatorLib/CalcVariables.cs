using System;
using System.Collections.Generic;
using System.Text;

namespace SevenZ.Calculator
{
   public partial class Calculator
   {
      public delegate void CalcVariableDelegate(object sender, EventArgs e);
      public event CalcVariableDelegate OnVariableStore;

      Dictionary<string, double> variables;

      private void LoadConstants()
      {
         variables = new Dictionary<string, double>();
         variables.Add("pi", Math.PI);
         variables.Add("e", Math.E);
         
         variables.Add("x", 0);

         variables.Add("a", 1);
         variables.Add("b", 1);
         variables.Add("c", 1);
         variables.Add("d", 1);
         variables.Add("f", 1);
         variables.Add("g", 1);
         variables.Add("h", 1);
         variables.Add("i", 1);
         variables.Add("j", 1);
         variables.Add("k", 1);

         if (OnVariableStore != null)
            OnVariableStore(this, new EventArgs());
      }

      public Dictionary<string, double> Variables
      {
         get { return variables; }
      }

      public void SetVariable(string name, double val)
      {
          if (variables.ContainsKey(name))
              variables[name] = val;
          else
              variables.Add(name, val);

              if (OnVariableStore != null)
                  OnVariableStore(this, new EventArgs());
      }

      public double GetVariable(string name)
      {  // return variable's value // if variable ha push default value, 0
         return variables.ContainsKey(name) ? variables[name] : 0;                    
      }

        public bool IsVariable(string name)
        {
            bool result = false;
            if (variables.ContainsKey(name)) result = true;

            return result;
        }
   }
}
