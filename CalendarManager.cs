using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DDay.iCal;
using DDay.iCal.Serialization.iCalendar;

namespace MultiDesktop
{
    public class CalendarManager
    {
        private static CalendarManager calendarManager;

        private string calendarAbsPath;
        private SortedList<string, IICalendar> icalendarList;
        private Library.MonthCalendar monthCalendar;
        private SortedList<string, ITodo> todoList;
        private DataTable todoTable;
        private BindingSource todoTableBS;

        private CalendarManager()
        {
            calendarAbsPath = System.IO.Path.GetFullPath("Calendars");
            icalendarList = new SortedList<string, IICalendar>();
            monthCalendar = new Library.MonthCalendar();

            todoList = new SortedList<string,ITodo>();
            todoTable = new DataTable();
            todoTable.TableName = "Todo Table";
            todoTable.Columns.Add("Recurrence", typeof(Bitmap));
            todoTable.Columns.Add("Summary", typeof(string));
            todoTable.Columns.Add("Category", typeof(string));
            todoTable.Columns.Add("Priority", typeof(string));
            todoTable.Columns.Add("Status", typeof(bool));
            todoTable.Columns.Add("StartDate", typeof(string));
            todoTable.Columns.Add("DueDate", typeof(string));
            todoTable.Columns.Add("UID", typeof(string));

            todoTableBS = new BindingSource();
            todoTableBS.DataSource = todoTable;
        }

        public static void initialize()
        {
            if (calendarManager == null)
                calendarManager = new CalendarManager();
        }

        public static bool loadCalendar(string filename)
        {
            if (calendarManager != null)
            {
                string file = calendarManager.calendarAbsPath + "\\" + filename;

                try
                {
                    IICalendarCollection calendars = iCalendar.LoadFromFile(file);

                    // Get the enumerator for all calendars
                    IEnumerator<IICalendar> ical = calendars.GetEnumerator();

                    // Assume that there is only one calendar per file
                    if (ical.MoveNext())
                    {
                        // Add the current calendar to the list
                        calendarManager.icalendarList.Add(filename, ical.Current);

                        // Load the current calendar to the MonthCalendar
                        calendarManager.monthCalendar.Load(ical.Current);

                        // Load the current calendar to the Todo Collection
                        // Get the enumerator for all itodos in the current calendar
                        IEnumerator<ITodo> itodo = ical.Current.Todos.GetEnumerator();

                        while (itodo.MoveNext())
                        {
                            addTodo(itodo.Current);
                        }

                        return true;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("This iCal file may not comply with RFC 5545: " + System.IO.Path.GetFileName(file));
                }
            }

            return false;
        }

        public static bool unloadCalendar(string filename)
        {
            if (calendarManager != null)
            {
                IICalendar calendar = calendarManager.icalendarList[filename];

                // Load the current calendar to the MonthCalendar
                calendarManager.monthCalendar.Unload(calendar);

                // Unload the current calendar from the Todo Collection
                // Get the enumerator for all itodos in the current calendar
                IEnumerator<ITodo> itodo = calendar.Todos.GetEnumerator();

                while (itodo.MoveNext())
                {
                    removeTodo(itodo.Current.UID);
                }

                // Remove the current calendar from the list
                calendarManager.icalendarList.Remove(filename);
            }
            return false;
        }

        public static bool saveCalendar(string filename)
        {
            if (calendarManager != null)
            {
                if (calendarManager.icalendarList.ContainsKey(filename))
                {
                    string file = calendarManager.calendarAbsPath + "\\" + filename;
                    iCalendarSerializer serializer = new iCalendarSerializer();
                    serializer.Serialize(calendarManager.icalendarList[filename], file);
                    return true;
                }
            }
            return false;
        }

        public static bool createCalendar(string filename)
        {
            if (calendarManager != null)
            {
                string file = calendarManager.calendarAbsPath + "\\" + filename;
                iCalendar iCal = new iCalendar();
                iCalendarSerializer serializer = new iCalendarSerializer();
                serializer.Serialize(iCal, file);
                calendarManager.icalendarList.Add(filename, iCal);
                return true;
            }
            return false;
        }

        public static string findCalendarFileName(IICalendar calendar)
        {
            if (calendarManager != null)
            {
                int icalIndex = calendarManager.icalendarList.IndexOfValue(calendar);
                return calendarManager.icalendarList.Keys[icalIndex];
            }
            return null;
        }

        public static Event createEvent(string filename)
        {
            if (calendarManager != null && calendarManager.icalendarList.ContainsKey(filename))
            {
                return calendarManager.icalendarList[filename].Create<Event>();
            }
            return null;
        }

        public static DataTable getEventTable(DateTime date)
        {
            DataTable eventTable = new DataTable();
            eventTable.TableName = "Event Table";
            eventTable.Columns.Add("Summary", typeof(string));
            eventTable.Columns.Add("Location", typeof(string));
            eventTable.Columns.Add("Time", typeof(string));
            eventTable.Columns.Add("UID", typeof(string));

            if (calendarManager != null)
            {
                foreach(Library.DateItem dateItem in calendarManager.monthCalendar.GetDateInfo(date))
                {
                    DataRow row = eventTable.NewRow();
                    row["Summary"] = dateItem.Event.Summary;
                    if (dateItem.Event.Location != String.Empty)
                        row["Location"] = dateItem.Event.Location;
                    if (!dateItem.Event.IsAllDay)
                        row["Time"] = "(" + dateItem.Event.Start.ToString("t");
                    row["UID"] = dateItem.Event.UID;

                    eventTable.Rows.Add(row);
                }
            }
            return eventTable;
        }

        public static ITodo createTodo(string filename)
        {
            if (calendarManager != null && calendarManager.icalendarList.ContainsKey(filename))
            {
                return calendarManager.icalendarList[filename].Create<Todo>();
            }
            return null;
        }

        public static ITodo duplicateTodo(ITodo todo)
        {
            if (calendarManager != null)
            {
                ITodo newTodo = todo.Calendar.Create<Todo>();
                newTodo.Summary = todo.Summary;
                if (todo.Start != null)
                    newTodo.Start = new iCalDateTime(todo.Start);
                if (todo.Due != null)
                    newTodo.Due = new iCalDateTime(todo.Due);
                newTodo.Priority = todo.Priority;
                newTodo.Description = todo.Description;
                newTodo.Categories.Add(todo.Categories[0]);
                newTodo.Class = todo.Class;
                return newTodo;
            }
            return null;
        }

        public static void addTodo(ITodo todo)
        {
            if (calendarManager != null)
            {
                // Add ITodo to the list
                calendarManager.todoList.Add(todo.UID, todo);

                // Add ITodo to the table
                DataRow row = calendarManager.todoTable.NewRow();
                if (todo.RecurrenceRules.Count > 0)
                    row["Recurrence"] = global::MultiDesktop.Properties.Resources.Recurrence;
                else
                    row["Recurrence"] = global::MultiDesktop.Properties.Resources.OneTime;

                row["Summary"] = todo.Summary;

                row["Category"] = todo.Categories[0];

                row["Priority"] = todo.Priority;

                if (todo.Status == TodoStatus.Completed)
                    row["Status"] = true;
                else
                    row["Status"] = false;

                if (todo.Start != null)
                    row["StartDate"] = todo.Start.Date.ToShortDateString();
                else
                    row["StartDate"] = "None";

                if (todo.Due != null)
                    row["DueDate"] = todo.Due.Date.ToShortDateString();
                else
                    row["DueDate"] = "None";

                row["UID"] = todo.UID;

                calendarManager.todoTable.Rows.Add(row);
            }
        }

        public static bool updateTodo(string UID)
        {
            if (calendarManager != null)
            {
                ITodo todo = calendarManager.todoList[UID];

                if (todo != null)
                {
                    // Find the corresponding ITodo row in the table
                    DataRow row = calendarManager.todoTable.Rows[calendarManager.todoTableBS.Find("UID", todo.UID)];

                    // Update the row
                    if (todo.RecurrenceRules.Count > 0)
                        row["Recurrence"] = global::MultiDesktop.Properties.Resources.Recurrence;
                    else
                        row["Recurrence"] = global::MultiDesktop.Properties.Resources.OneTime;

                    row["Summary"] = todo.Summary;

                    row["Category"] = todo.Categories[0];

                    row["Priority"] = todo.Priority;

                    if (todo.Status == TodoStatus.Completed)
                        row["Status"] = true;
                    else
                        row["Status"] = false;

                    if (todo.Start != null)
                        row["StartDate"] = todo.Start.Date.ToShortDateString();
                    else
                        row["StartDate"] = "None";

                    if (todo.Due != null)
                        row["DueDate"] = todo.Due.Date.ToShortDateString();
                    else
                        row["DueDate"] = "None";
                    return true;
                }
            }
            return false;
        }

        public static bool removeTodo(string UID)
        {
            if (calendarManager != null)
            {
                // Remove ITodo from the list
                calendarManager.todoList.Remove(UID);

                // Remove ITodo from the table
                calendarManager.todoTable.Rows.RemoveAt(calendarManager.todoTableBS.Find("UID", UID));

                return true;
            }
            return false;
        }

        public static Library.MonthCalendar Calendar
        {
            get
            {
                if (calendarManager != null)
                {
                    return calendarManager.monthCalendar;
                }
                return null;
            }
        }

        public static DataTable TodoTable
        {
            get
            {
                if (calendarManager != null)
                {
                    return calendarManager.todoTable;
                }
                return null;
            }
        }

        public static SortedList<string, ITodo> TodoList
        {
            get
            {
                if (calendarManager != null)
                {
                    return calendarManager.todoList;
                }
                return null;
            }
        }
    }
}
