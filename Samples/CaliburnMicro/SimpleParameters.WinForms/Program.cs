﻿using System;
#if WISEJ
using Wisej.Web;
#else
using System.Windows.Forms;
#endif

namespace SimpleParameters.UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
#if WINFORMS
        [STAThread]
#endif
        private static void Main()
        {
#if WINFORMS
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#endif

            new AppBootstrapper().Run();
        }
    }
}