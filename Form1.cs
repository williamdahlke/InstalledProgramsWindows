using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTeste
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static bool fGetInslalledProgram(String sProgramName)
        {
            sProgramName = sProgramName.ToUpper();

            List<String> teste = new List<string>();
            int i = 0;

            String sUninstall = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(sUninstall))
            {
                foreach (String skName in rk.GetSubKeyNames())
                {
                    RegistryKey sk = rk.OpenSubKey(skName);
                    try
                    {
                        teste.Add(sk.GetValue("DisplayName").ToString());
                    }
                    catch
                    {}                    
                }
                foreach(string s in teste)
                {
                    string s1 = s.ToUpper();
                    if (s1.Contains(sProgramName))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public static bool ExecutarCMD(string comando, string sProgramName)
        {
            using (Process processo = new Process())
            {
                processo.StartInfo.FileName = Environment.GetEnvironmentVariable("comspec");

                // Formata a string para passar como argumento para o cmd.exe
                processo.StartInfo.Arguments = string.Format("/c {0}", comando);

                processo.StartInfo.RedirectStandardOutput = true;
                processo.StartInfo.UseShellExecute = false;
                processo.StartInfo.CreateNoWindow = true;

                processo.Start();
                processo.WaitForExit();

                string saida = processo.StandardOutput.ReadToEnd();
                //return saida;
                if (string.IsNullOrEmpty(saida))
                {
                    return false;
                }
                else
                {
                    sProgramName = sProgramName.ToUpper();
                    if (saida.Contains(sProgramName))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        private void btn_Teste_Click(object sender, EventArgs e)
        {

            //if (fGetInslalledProgram("Framework") == true)
            //if (ExecutarCMD("dotnet --list-runtimes", "6.0") == true)
            if (verificarNetInstalled("4.6.1") == true)
            {
                MessageBox.Show("Instalado!");
            }
            else
            {
                MessageBox.Show("Não instalado!");
            }
        }

        const string subkey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\";

        private static bool verificarNetInstalled(string sVersion)
        {
            using (var ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subkey))
            {
                if (ndpKey != null && ndpKey.GetValue("Release") != null)
                {
                    string version = CheckFor45PlusVersion((int)ndpKey.GetValue("Release"));
                    
                    return true;
                }
                else
                {
                    return false;
                }
            }


        }

        // Checking the version using >= enables forward compatibility.
        private static string CheckFor45PlusVersion(int releaseKey)
        {
            if (releaseKey >= 533320)
                return "4.8.1 or later";
            if (releaseKey >= 528040)
                return "4.8";
            if (releaseKey >= 461808)
                return "4.7.2";
            if (releaseKey >= 461308)
                return "4.7.1";
            if (releaseKey >= 460798)
                return "4.7";
            if (releaseKey >= 394802)
                return "4.6.2";
            if (releaseKey >= 394254)
                return "4.6.1";
            if (releaseKey >= 393295)
                return "4.6";
            if (releaseKey >= 379893)
                return "4.5.2";
            if (releaseKey >= 378675)
                return "4.5.1";
            if (releaseKey >= 378389)
                return "4.5";
            // This code should never execute. A non-null release key should mean
            // that 4.5 or later is installed.
            return "No 4.5 or later version detected";
        }

    }
}
