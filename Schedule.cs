using System;
using System.Collections;
using System.Data;
using System.Text;

namespace MultiDesktop
{
    public class Schedule
    {
        private DateTime wakeTime;
        private DateTime sleepTime;
        private string name;
        private Hashtable sundaySchedule;
        private Hashtable mondaySchedule;
        private Hashtable tuesdaySchedule;
        private Hashtable wednesdaySchedule;
        private Hashtable thursdaySchedule;
        private Hashtable fridaySchedule;
        private Hashtable saturdaySchedule;
        private DataTable table;
        private DataTable summary;

        public Schedule(DateTime wakeTime, DateTime sleepTime, string name)
        {
            this.wakeTime = wakeTime;
            this.sleepTime = sleepTime;
            this.name = name;
            sundaySchedule = new Hashtable();
            mondaySchedule = new Hashtable();
            tuesdaySchedule = new Hashtable();
            wednesdaySchedule = new Hashtable();
            thursdaySchedule = new Hashtable();
            fridaySchedule = new Hashtable();
            saturdaySchedule = new Hashtable();

            DataColumn[] scheduleKeys = new DataColumn[1];

            table = new DataTable();
            table.TableName = "Schedule Table";
            scheduleKeys[0] = new DataColumn("Time", typeof(DateTime));
            table.Columns.Add(scheduleKeys[0]);
            table.Columns.Add("Monday", typeof(string));
            table.Columns.Add("Tuesday", typeof(string));
            table.Columns.Add("Wednesday", typeof(string));
            table.Columns.Add("Thursday", typeof(string));
            table.Columns.Add("Friday", typeof(string));
            table.Columns.Add("Saturday", typeof(string));
            table.Columns.Add("Sunday", typeof(string));
            table.PrimaryKey = scheduleKeys;

            DataColumn[] summaryKeys = new DataColumn[1];

            summary = new DataTable();
            summary.TableName = "Summary Table";
            summaryKeys[0] = new DataColumn("Category", typeof(string));
            summary.Columns.Add(summaryKeys[0]);
            summary.Columns.Add("Monday", typeof(float));
            summary.Columns.Add("Tuesday", typeof(float));
            summary.Columns.Add("Wednesday", typeof(float));
            summary.Columns.Add("Thursday", typeof(float));
            summary.Columns.Add("Friday", typeof(float));
            summary.Columns.Add("Saturday", typeof(float));
            summary.Columns.Add("Sunday", typeof(float));

            DataColumn totalColumn = new DataColumn("Total", typeof(float));
            totalColumn.Expression = "Monday + Tuesday + Wednesday + Thursday + Friday + Saturday + Sunday";
            summary.Columns.Add(totalColumn);
            summary.PrimaryKey = summaryKeys;

            //Initialize Summary Table
            foreach (Category category in Setting.CategoryList)
            {
                if (category.Name != "Contact")
                {
                    DataRow row = summary.NewRow();
                    row["Category"] = category.Name;
                    for (int i = 1; i < 9; i++)
                        row[i] = 0.0;
                    summary.Rows.Add(row);
                }
            }

            DataRow totalRow = summary.NewRow();
            totalRow["Category"] = "Total";
            for (int i = 1; i < 9; i++)
                totalRow[i] = 0.0;
            summary.Rows.Add(totalRow);

            DataRow slackRow = summary.NewRow();
            slackRow["Category"] = "Slack";
            TimeSpan elapsed = sleepTime.Subtract(wakeTime);
            for (int i = 1; i < 9; i++)
                slackRow[i] = elapsed.TotalHours;
            summary.Rows.Add(slackRow);
        }

        public DateTime WakeTime
        {
            get
            {
                return wakeTime;
            }
            set
            {
                wakeTime = value;
            }
        }

        public DateTime SleepTime
        {
            get
            {
                return sleepTime;
            }
            set
            {
                sleepTime = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public Hashtable SundaySchedule
        {
            get
            {
                return sundaySchedule;
            }
        }

        public Hashtable MondaySchedule
        {
            get
            {
                return mondaySchedule;
            }
        }

        public Hashtable TuesdaySchedule
        {
            get
            {
                return tuesdaySchedule;
            }
        }

        public Hashtable WednesdaySchedule
        {
            get
            {
                return wednesdaySchedule;
            }
        }

        public Hashtable ThursdaySchedule
        {
            get
            {
                return thursdaySchedule;
            }
        }

        public Hashtable FridaySchedule
        {
            get
            {
                return fridaySchedule;
            }
        }

        public Hashtable SaturdaySchedule
        {
            get
            {
                return saturdaySchedule;
            }
        }

        public DataTable Table
        {
            get
            {
                return table;
            }
        }

        public DataTable Summary
        {
            get
            {
                return summary;
            }
        }

        public void incrementSummaryPoint(int row, int column)
        {
            int size = summary.Rows.Count;
            summary.Rows[row][column] = Single.Parse(summary.Rows[row][column].ToString()) + 0.5;
            summary.Rows[size - 2][column] = Single.Parse(summary.Rows[size - 2][column].ToString()) + 0.5;
            summary.Rows[size - 1][column] = Single.Parse(summary.Rows[size - 1][column].ToString()) - 0.5;
        }

        public void incrementSummaryPoint(int row, string column)
        {
            int size = summary.Rows.Count;
            summary.Rows[row][column] = Single.Parse(summary.Rows[row][column].ToString()) + 0.5;
            summary.Rows[size - 2][column] = Single.Parse(summary.Rows[size - 2][column].ToString()) + 0.5;
            summary.Rows[size - 1][column] = Single.Parse(summary.Rows[size - 1][column].ToString()) - 0.5;
        }

        public void decrementSummaryPoint(int row, int column)
        {
            int size = summary.Rows.Count;
            summary.Rows[row][column] = Single.Parse(summary.Rows[row][column].ToString()) - 0.5;
            summary.Rows[size - 2][column] = Single.Parse(summary.Rows[size - 2][column].ToString()) - 0.5;
            summary.Rows[size - 1][column] = Single.Parse(summary.Rows[size - 1][column].ToString()) + 0.5;
        }

        public void decrementSummaryPoint(int row, string column)
        {
            int size = summary.Rows.Count;
            summary.Rows[row][column] = Single.Parse(summary.Rows[row][column].ToString()) - 0.5;
            summary.Rows[size - 2][column] = Single.Parse(summary.Rows[size - 2][column].ToString()) - 0.5;
            summary.Rows[size - 1][column] = Single.Parse(summary.Rows[size - 1][column].ToString()) + 0.5;
        }
    }
}
