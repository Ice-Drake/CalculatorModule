﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DDay.iCal;
using DDay.iCal.Serialization.iCalendar;

namespace MultiDesktop
{
    public class CalendarManager
    {
        public TodoManager TodoManager { get; private set; }
        public EventManager EventManager { get; private set; }
        public SortedList<int, Calendar> CalendarList { get; private set; }
        public DataTable CalendarTable { get; private set; }
        public string CalendarAbsPath { get; private set; }
        
        private SortedList<int, IICalendar> loadCalendarList;
        private SQLiteConnection connection;
        private BindingSource calendarTableBS;
        
        public CalendarManager(string calendarPath)
        {
            CalendarAbsPath = calendarPath;
            loadCalendarList = new SortedList<int, IICalendar>();
            connection = new SQLiteConnection("Data Source=Setting.sqlite;Version=3;");

            TodoManager = new TodoManager(this);
            EventManager = new EventManager(this);
            CalendarList = new SortedList<int, Calendar>();
            
            CalendarTable = new DataTable();
            CalendarTable.TableName = "Calendar Table";
            CalendarTable.Columns.Add("ID", typeof(int));
            CalendarTable.Columns.Add("Name", typeof(string));
            CalendarTable.Columns.Add("Filename", typeof(string));
            CalendarTable.Columns.Add("Included", typeof(bool));

            calendarTableBS = new BindingSource();
            calendarTableBS.DataSource = CalendarTable;
        }

        public void loadDatabase()
        {
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM Calendar", connection);
            connection.Open();
            SQLiteDataReader reader = command.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    try
                    {
                        int id = Int32.Parse(reader[0].ToString());
                        string name = reader[1].ToString();
                        string filename = reader[2].ToString();

                        Calendar newCalendar = new Calendar(id, filename);
                        newCalendar.Name = name;

                        DataRow newRow = CalendarTable.NewRow();
                        newRow["ID"] = id;
                        newRow["Name"] = name;
                        newRow["Filename"] = filename;

                        if(reader[3].ToString().Equals("1"))
                        {
                            newRow["Included"] = true;
                            loadCalendar(newCalendar, true);
                        }
                        else
                        {
                            newCalendar.Included = false;
                            newRow["Included"] = false;
                        }

                        CalendarList.Add(newCalendar.ID, newCalendar);
                        CalendarTable.Rows.Add(newRow);
                    }
                    catch (FormatException)
                    {
                        System.Windows.Forms.MessageBox.Show("Corrupted Calendar Setting Database! Click OK to proceed on restoring it.");
                    }
                    finally
                    {
                        //Remove and reconstruct Calendar Table.
                    }
                }
            }
            finally
            {
                reader.Close();
            }

            connection.Close();

            EventManager.updateEventTable();

            //Setup eventhandlers
            TodoManager.TodoModify += new EventHandler(saveCalendar);
            EventManager.EventModify += new EventHandler(saveCalendar);
        }

        public bool loadCalendar(Calendar calendar, bool initialize = false)
        {
            try
            {
                IICalendarCollection calendars = iCalendar.LoadFromFile(CalendarAbsPath + "\\" + calendar.Filename);

                // Get the enumerator for all calendars
                IEnumerator<IICalendar> ical = calendars.GetEnumerator();

                // Assume that there is only one calendar per file
                if (ical.MoveNext())
                {
                    // Initialize the calendar
                    calendar.IICalendar = ical.Current;

                    // Load the current calendar to the MonthCalendar
                    EventManager.Calendar.Load(ical.Current);

                    // Load the current calendar to the Todo Collection
                    // Get the enumerator for all itodos in the current calendar
                    IEnumerator<ITodo> iTodo = ical.Current.Todos.GetEnumerator();

                    while (iTodo.MoveNext())
                    {
                        TodoManager.addTodo(iTodo.Current);
                    }

                    // Add it to the list
                    loadCalendarList.Add(calendar.ID, calendar.IICalendar);
                }

                if (!initialize)
                {
                    // Update database
                    calendar.Included = true;
                    string query = String.Format("UPDATE Calendar SET Included = {0} WHERE ID = {1}", 1, calendar.ID);
                    SQLiteCommand command = new SQLiteCommand(query, connection);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                
                    // Update table
                    DataRow row = CalendarTable.Rows[calendarTableBS.Find("Filename", calendar.Filename)];
                    row["Included"] = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("This iCal file may not comply with RFC 5545: " + System.IO.Path.GetFileName(calendar.Filename));
                return false;
            }

            return true;
        }

        public void unloadCalendar(Calendar calendar)
        {
            if (loadCalendarList.ContainsKey(calendar.ID))
            {
                // Load the current calendar to the MonthCalendar
                EventManager.Calendar.Unload(calendar.IICalendar);

                // Unload the current calendar from the Todo Collection
                // Get the enumerator for all itodos in the current calendar
                IEnumerator<ITodo> iTodo = calendar.IICalendar.Todos.GetEnumerator();

                while (iTodo.MoveNext())
                {
                    TodoManager.removeTodo(iTodo.Current.UID);
                }

                // Remove the current calendar from the list
                loadCalendarList.Remove(calendar.ID);
                
                calendar.Included = false;

                // Update table
                DataRow row = CalendarTable.Rows[calendarTableBS.Find("Filename", calendar.Filename)];
                row["Included"] = false;

                // Update database
                string query = String.Format("UPDATE Calendar SET Included = {0} WHERE ID = {1}", 0, calendar.ID);
                SQLiteCommand command = new SQLiteCommand(query, connection);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public int findCalendarID(IICalendar calendar)
        {
            return loadCalendarList.Keys[loadCalendarList.IndexOfValue(calendar)];
        }

        public bool createCalendar(string name, string filename, bool included, bool created = true)
        {
            if (calendarTableBS.Find("Name", name) >= 0 || calendarTableBS.Find("Filename", filename) >= 0)
                return false;
            else
            {
                // Insert to database
                string query = String.Format("INSERT INTO Calendar VALUES ('{0}', '{1}', {2}); SELECT LAST_INSERT_ROWID();", name, filename, included ? 1 : 0);
                SQLiteCommand command = new SQLiteCommand(query, connection);

                connection.Open();
                int id = Int32.Parse(command.ExecuteScalar().ToString());
                connection.Close();

                Calendar newCalendar = new Calendar(id, filename);
                newCalendar.Name = name;
                
                // Insert to table
                DataRow newRow = CalendarTable.NewRow();
                newRow["ID"] = id;
                newRow["Name"] = name;
                newRow["Filename"] = filename;
                newRow["Included"] = included;
                CalendarTable.Rows.Add(newRow);

                // Create calendar if needed
                if (created)
                {
                    iCalendar newIICalendar = new iCalendar();
                    newCalendar.IICalendar = newIICalendar;
                }

                // Load calendar if included
                if (included)
                    loadCalendar(newCalendar);

                // Add it to the list
                CalendarList.Add(id, newCalendar);

                return true;
            }
        }

        public bool renameCalendar(int calendarID, string newName)
        {
            int newRowID = calendarTableBS.Find("Name", newName);

            if (newRowID > 0)
                return false;

            if (CalendarList.ContainsKey(calendarID))
            {
                Calendar calendar = CalendarList[calendarID];
                calendar.Name = newName;
                
                // Update database
                string query = String.Format("UPDATE Calendar SET Name = '{0}' WHERE ID = {1}", newName, calendarID);
                SQLiteCommand command = new SQLiteCommand(query, connection);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                // Update table
                DataRow row = CalendarTable.Rows[calendarTableBS.Find("ID", calendarID)];
                row["Name"] = newName;

                return true;
            }
            else
                return false;
        }

        public bool deleteCalendar(Calendar calendar)
        {
            if (!CalendarList.ContainsValue(calendar))
                return false;

            unloadCalendar(calendar);

            // Remove from table
            CalendarTable.Rows.RemoveAt(calendarTableBS.Find("ID", calendar.ID));

            // Remove from database
            string query = String.Format("DELETE FROM Calendar WHERE ID = {0}", calendar.ID);
            SQLiteCommand command = new SQLiteCommand(query, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return true;
        }

        private void saveCalendar(object sender, EventArgs e)
        {
            IICalendar calendar = (IICalendar)sender;
            string filename = CalendarList[findCalendarID(calendar)].Filename;
            iCalendarSerializer serializer = new iCalendarSerializer();
            serializer.Serialize(calendar, CalendarAbsPath + "\\" + filename);
        }
    }
}
