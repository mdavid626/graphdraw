using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace GraphDraw
{
    static class FStatic
    {
        private static readonly string[] abc = {  "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q","r",
                                          "s", "t", "u", "v", "w", "x", "y", "z", "a", "b", "c", "d" };

        public static ArrayList Functions;
        public static ArrayList xCrossList;
        public static ArrayList AnnotationList;

        public static int SelectedItems
        {
            get
            {
                return CountSelected();
            }

            set {}
        }

        private static int CountSelected()
        {
            int selectedItems = 0;

            foreach (Function f in Functions)
            {
                if (f.selected)
                {
                    selectedItems++;
                }
            }

            return selectedItems;
        }

        public static Function Add(Function f)
        {
            if (f.itsOk == false)
            {
                return null;
            }
            else
            {
                SelectNone();

                Functions.Add(f);

                f.name = abc[Functions.Count% 26];

                return f;
            }
        }

        public static void Remove(Function f)
        {
            Functions.Remove(f);
        }

        public static Function FirstSelectedFunction()
        {
            Function selected = null;
            bool isSelected = false;

            foreach (Function f in Functions)
            {
                if (f.selected && !isSelected)
                {
                    isSelected = true;
                    selected = f;
                }
            }

            if (isSelected)
            {
                return selected;
            }
            else
            {
                return null;
            }
        }

        public static void SelectNone()
        {
            foreach (Function f in Functions)
            {
                f.selected = false;
            }
        }

        public static void SelectAll()
        {
            foreach (Function f in Functions)
            {
                f.selected = true;
            }
        }

        public static void Initialize()
        {
            Functions = new ArrayList();
            xCrossList = new ArrayList();
            Settings.formProperties = new List<FormProperty>();
            AnnotationList = new ArrayList();
        }

        public static string NextName()
        {
            return abc[(Functions.Count + 1) % 26];
        }

        public static void AddFunction_Form()
        {
            AddFunctionForm form = new AddFunctionForm();
            form.ShowDialog();
        }

        public static void EditFunction_Form()
        {
            Function f = FirstSelectedFunction();

            if (f != null)
            {
                EditFunctionForm form = new EditFunctionForm(f);
                form.ShowDialog();
            }
        }

        public static void FunctionSettings_Form()
        {
            Function f = FirstSelectedFunction();

            if (f != null)
            {
                FunctionSettingsForm form = new FunctionSettingsForm(f);
                form.ShowDialog();
            }
        }

        public static void RemoveSelectedFunctions()
        {
            ArrayList newFunctions = new ArrayList();

            foreach (Function f in Functions)
            {
                if (!f.selected)
                {
                    newFunctions.Add(f);
                }
            }

            Functions = newFunctions;
        }

        public static Function GetFunction(int index)
        {
            if (index > -1 && index < Functions.Count)
            {
                return (Function)Functions[index];
            }

            return null;
        }

        public static void ColorDialogOpen()
        {
            ColorDialog colorDialog1 = new ColorDialog();

            if (FStatic.SelectedItems > 0)
            {
                DialogResult dr = colorDialog1.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    foreach (Function f in FStatic.Functions)
                    {
                        if (f.selected)
                        {
                            f.fS.Color = colorDialog1.Color;
                        }
                    }
                }
            }
        }

        public static FormProperty GetForm(Forms form)
        {
            foreach (FormProperty fp in Settings.formProperties)
            {
                if (fp.Id == form) return fp;
            }

            return null;
        }
    }
}
