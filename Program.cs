using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Diagnostics;

namespace GDlauncher2
{
    public class SteamCheck
    {
        public string installPath = "n0ll";
        public bool SteamInstalled = false;

        public static void Error()
        {
            Console.ReadKey();
            System.Environment.Exit(-1);
        }

        public static void StartGD()
        {
            try
            {
                System.Diagnostics.Process.Start("steam://rungameid/322170");
            }
            catch
            {
                Console.WriteLine("Geometry dash could not be opened!\n");
                SteamCheck.Error();
            }
        }

        public static void Check()
        {
            Object obj = new Object();
            var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            var key = hklm.OpenSubKey(@"SOFTWARE\WOW6432Node\Valve\Steam");
            var installPath = key.GetValue("InstallPath").ToString();
            bool SteamInstalled = (installPath != null);
            hklm.Close();
            if (SteamInstalled)
            {
                SteamCheck.StartGD();
            }
            else
            {
                Console.WriteLine("Steam was not found, Is it installed?");
                SteamCheck.Error();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SteamCheck.Check();
        }
    }
}
