using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GraphDraw
{
    static class Program
    {
        public static Main mainForm;
        private static RegisterForm registerForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Settings.programPath = Application.ExecutablePath.Substring(0, 1 + Application.ExecutablePath.LastIndexOf("\\"));

            InitGraphDraw(args);
            InitRegister();

            Register reg = new Register();

            RunTypes run = reg.Check();
            if (run == RunTypes.Activated)
            if (1==1)
            {
                About about = new About();
                about.Start();

                System.Threading.Thread.Sleep(1000);

                Application.Run(mainForm);
            }
            else
            {
                if (run == RunTypes.NotActivated)
                {
                    Application.Run(registerForm);
                }
                else
                {
                    //
                }
            }
        }

        private static void InitGraphDraw(string[] args)
        {
            mainForm = new Main();

            mainForm.OpenSettings();

            if (args.Length == 1)
            {
                mainForm.OpenFunctions(args[0]);
            }

            mainForm.isOpenFile = true;
        }

        private static void InitRegister()
        {
            registerForm = new RegisterForm();
        }
    }
}