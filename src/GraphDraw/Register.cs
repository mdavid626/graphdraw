using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Management;

namespace GraphDraw
{
    enum RunTypes
    {
        NotActivated,
        Activated,
        Error
    }

    class Register
    {
        private string strPath;
        private string st1, st2, st3, st4, st5, st6;

        public Register()
        {
            strPath = @"Software\GraphDraw\Settings";
        }

        public RunTypes Check()
        {
            RunTypes result = RunTypes.NotActivated;
            Settings.activated = false;

            RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey(strPath);
            st1 = (string)regKeyAppRoot.GetValue("st1");

            //first run
            if (st1 == null)
            {
                SaveDateTime(DateTime.Now, out st2, out st3, out st4);

                try
                {
                    regKeyAppRoot.SetValue("st1", "465re66");
                    regKeyAppRoot.SetValue("st2", st2);
                    regKeyAppRoot.SetValue("st3", st3);
                    regKeyAppRoot.SetValue("st4", st4);
                    regKeyAppRoot.SetValue("st5", "");
                    regKeyAppRoot.SetValue("st6", GetRegistrationCode());
                }
                catch
                {
                    MessageBox.Show("Can not write to registry!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return RunTypes.Error;
                }
            }

            try
            {
                st1 = (string)regKeyAppRoot.GetValue("st1");
                st2 = (string)regKeyAppRoot.GetValue("st2");
                st3 = (string)regKeyAppRoot.GetValue("st3");
                st4 = (string)regKeyAppRoot.GetValue("st4");
                st5 = (string)regKeyAppRoot.GetValue("st5");
                st6 = (string)regKeyAppRoot.GetValue("st6");
            }
            catch
            {
                MessageBox.Show("Can not read from registry!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return RunTypes.Error;
            }

            Settings.regNumber = st6;

            string actCode = GenerateActivationCode(st6);

            if (st5 == actCode)
            {
                result = RunTypes.Activated;
                Settings.activated = true;
                Settings.shdays = -1;
            }
            else
            {
                Settings.shdays = GoodTime(GetDateTime(st2, st3, st4));

                if (Settings.shdays != -1)
                {
                    result = RunTypes.Activated;
                }
            }

            return result;
        }

        public void WriteActCode()
        {
            RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey(strPath);

            string actCode = GenerateActivationCode(Settings.regNumber);

            regKeyAppRoot.SetValue("st5", actCode);
        }

        #region date

        private DateTime GetDateTime(string year, string month, string day)
        {
            year = year.Substring(0, year.Length - 1).Replace("s", "2");
            month = month.Substring(0, month.Length - 1).Replace("e", "3");
            day = day.Substring(0, day.Length - 1).Replace("j", "4");

            int yearM = Convert.ToInt32(year) / 1254;
            int monthM = Convert.ToInt32(month) / 3223;
            int dayM = Convert.ToInt32(day) / 6564;

            return new DateTime(yearM, monthM, dayM);
        }

        private void SaveDateTime(DateTime dt, out string yearS, out string monthS, out string dayS)
        {
            int year = dt.Year;
            int month = dt.Month;
            int day = dt.Day;

            int yearM = year * 1254;
            int monthM = month * 3223;
            int dayM = day * 6564;

            int p1 = yearM % 9;
            int p2 = monthM % 9;
            int p3 = dayM % 9;

            string yearH = yearM.ToString().Replace("2", "s");
            string monthH = monthM.ToString().Replace("3", "e");
            string dayH = dayM.ToString().Replace("4", "j");

            yearS = yearH + p1.ToString();
            monthS = monthH + p2.ToString();
            dayS = dayH + p3.ToString();
        }

        private int GoodTime(DateTime dt)
        {
            int result = -1;

            DateTime a = new DateTime(2009, 1, 1);
            DateTime b = new DateTime(2009, 1, 30);
            long tick = b.Ticks - a.Ticks;

            DateTime now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            long atick = now.Ticks - dt.Ticks;

            if (atick <= tick && atick >= 0)
            {
                DateTime n = new DateTime(atick);
                result = 30 - (n.Day - 1);
            }

            return result;
        }

        #endregion

        #region regcode

        public string GetRegistrationCode()
        {
            string id = GetMACAddress();

            string final = "12345";

            if (id.Length >= 6)
            {
                string a1 = id.Substring(0, 2);
                string a2 = id.Substring(2, 2);
                string a3 = id.Substring(4, 2);

                int i1 = Int32.Parse(a1);
                int i2 = Int32.Parse(a2);
                int i3 = Int32.Parse(a3);

                int m1 = (i1 * 3453432) % 7;
                int m2 = (i2 * 4323344) % 9;
                int m3 = (i3 * 3453244) % 5;

                string n1 = m1.ToString();
                string n2 = m2.ToString();
                string n3 = m3.ToString();

                final = a1 + n1 + "-" + a2 + n2 + "-" + a3 + n3;
            }

            return final;
        }

        private string GetMACAddress()
        {
            string MACAddress = String.Empty;

            try
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();

                foreach (ManagementObject mo in moc)
                {
                    if (MACAddress == String.Empty)  // only return MAC Address from first card
                    {
                        if ((bool)mo["IPEnabled"] == true) MACAddress = mo["MacAddress"].ToString();
                    }
                    mo.Dispose();
                }
            }
            catch
            {
            }

            if (MACAddress != String.Empty)
            {
                MACAddress = MACAddress.Replace(":", "");

                long n = Int64.Parse(MACAddress, System.Globalization.NumberStyles.HexNumber);

                if (n < 1000000)
                {
                    MessageBox.Show("Error2");
                }

                MACAddress = n.ToString();
            }
            else
            {
                //MessageBox.Show("Can not determine the computer's MAC address!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "143282";
            }

            return MACAddress;
        }

        private string GetCPUId()
        {
            string cpuInfo = String.Empty;
            string temp = String.Empty;
            ManagementClass mc = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (cpuInfo == String.Empty)
                {// only return cpuInfo from first CPU
                    cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                }
            }

            cpuInfo = cpuInfo.Substring(0, 6);

            long n = Int32.Parse(cpuInfo, System.Globalization.NumberStyles.HexNumber);

            cpuInfo = n.ToString();
            return cpuInfo;
        }

        public string GenerateActivationCode(string id)
        {
            string result = "";

            if (id.Length == 11)
            {
                try
                {
                    string st = id.Replace("-", "");

                    string a1 = st.Substring(0, 2);
                    string a2 = st.Substring(3, 2);
                    string a3 = st.Substring(6, 2);

                    int i1 = Int32.Parse(a1);
                    int i2 = Int32.Parse(a2);
                    int i3 = Int32.Parse(a3);

                    int m1 = (i1 * 3453432) % 7;
                    int m2 = (i2 * 4323344) % 9;
                    int m3 = (i3 * 3453244) % 5;

                    string w1 = st.Substring(2, 1);
                    string w2 = st.Substring(5, 1);
                    string w3 = st.Substring(8, 1);

                    int e1 = Int32.Parse(w1);
                    int e2 = Int32.Parse(w2);
                    int e3 = Int32.Parse(w3);

                    if (m1 == e1 && m2 == e2 && m3 == e3)
                    {
                        int t1 = (i1 * e3) % 9;
                        int t2 = (i3 * e2) % 9;
                        int t3 = (i2 * e1) % 9;
                        int t4 = (i2 * e3) % 9;

                        int t5 = (i2 * e3 * 4) % 8;
                        int t6 = (i1 * e2 * 2) % 8;
                        int t7 = (i2 * e1 * 7) % 8;
                        int t8 = (i3 * e3 * 6) % 8;

                        int t9 = (i2 * e1) % 7;
                        int t10 = (i1 * e1) % 7;
                        int t11 = (i2 * e3) % 8;
                        int t12 = (i3 * e2) % 6;

                        int t13 = (i2 * e1) % 8;
                        int t14 = (i1 * e3) % 9;
                        int t15 = (i3 * e2) % 7;
                        int t16 = (i2 * e1) % 8;

                        result = t1.ToString() + t2.ToString() + t3.ToString() + t4.ToString() + "-" +
                                 t5.ToString() + t6.ToString() + t7.ToString() + t8.ToString() + "-" +
                                 t9.ToString() + t10.ToString() + t11.ToString() + t12.ToString() + "-" +
                                 t13.ToString() + t14.ToString() + t15.ToString() + t16.ToString();
                    }
                    else
                    {
                        //throw new Exception("Error!");
                    }
                }
                catch (Exception e)
                {
                    //MessageBox.Show("Error: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //MessageBox.Show("Error!");
            }

            return result;
        }

        #endregion
    }
}
