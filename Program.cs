using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MultiDesktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SplashScreen.ShowSplashScreen();
            MultiDesktopBar form = new MultiDesktopBar();

            SplashScreen.SetStatus("now loading setting");
            SplashScreen.Progress = 0.10;
            form.loadSetting();

            SplashScreen.SetStatus("now loading calendars");
            SplashScreen.Progress = 0.20;
            form.loadCalendars();

            SplashScreen.SetStatus("now loading goals");
            SplashScreen.Progress = 0.40;
            form.loadGoals();

            SplashScreen.SetStatus("now loading panels");
            SplashScreen.Progress = 0.60;
            form.loadPanels();

            SplashScreen.SetStatus("now loading plugins");
            SplashScreen.Progress = 0.80;
            form.loadPlugins();

            SplashScreen.SetStatus("now loading plugin database");
            SplashScreen.Progress = 0.90;
            form.loadPluginDatabase();

            SplashScreen.Progress = 1;
            SplashScreen.CloseForm();

            Application.Run(form);
        }
    }
}