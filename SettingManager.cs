using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MultiDesktop
{
    public class SettingManager
    {
        private SqlConnection connection;
        
        public SettingManager()
        {
            connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Setting.mdf;Integrated Security=True");
        }

        public void loadDatabase()
        {
            CalendarAbsPath = System.IO.Path.GetFullPath("Calendars");
            SortedList<string, string> iCalDict = new SortedList<string, string>();

            CalendarManager = new CalendarManager(CalendarAbsPath);
            CategoryManager = new CategoryManager();
            GoalManager = new GoalPlanner(CalendarManager.TodoManager);
        }

        public CalendarManager CalendarManager { get; private set; }

        public CategoryManager CategoryManager { get; private set; }

        public GoalPlanner GoalManager { get; private set; }

        public string CalendarAbsPath { get; private set; }
    }
}