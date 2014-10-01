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

            Setting.initialize();
            CalendarManager.initialize();

            foreach (string filename in Setting.CalendarList.Values)
            {
                CalendarManager.loadCalendar(filename);
            }

            MultiDesktopBar form = new MultiDesktopBar();
            Application.Run(form);
        }
    }
}