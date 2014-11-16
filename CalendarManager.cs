using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DDay.iCal;
using DDay.iCal.Serialization.iCalendar;

namespace MultiDesktop
{
    public class CalendarManager
    {
        private string calendarAbsPath;
        private SortedList<string, IICalendar> loadCalendarList;
        private SqlConnection connection;
        private BindingSource calendarTableBS;
        
        public CalendarManager(string calendarPath)
        {
            calendarAbsPath = calendarPath;
            loadCalendarList = new SortedList<string, IICalendar>();
            TodoManager = new TodoManager(this);
            EventManager = new EventManager(this);
            JournalManager = new JournalManager(this);
            CalendarList = new SortedList<string, Calendar>();
            
            CalendarTable = new DataTable();
            CalendarTable.TableName = "Calendar Table";
            CalendarTable.Columns.Add("Name", typeof(string));
            CalendarTable.Columns.Add("Filename", typeof(string));
            CalendarTable.Columns.Add("Included", typeof(bool));

            connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Setting.mdf;Integrated Security=True");

            calendarTableBS = new BindingSource();
            calendarTableBS.DataSource = CalendarTable;
        }

        public void loadDatabase()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Calendar", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    try
                    {
                        string name = reader[0].ToString();
                        string filename = reader[1].ToString();

                        Calendar newCalendar = new Calendar(name, filename);

                        DataRow newRow = CalendarTable.NewRow();
                        newRow["Name"] = name;
                        newRow["Filename"] = filename;

                        if(Boolean.Parse(reader[2].ToString()))
                        {
                            newRow["Included"] = true;
                            loadCalendar(newCalendar, true);
                        }
                        else
                        {
                            newCalendar.Included = false;
                            newRow["Included"] = false;
                        }

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

            //Setup eventhandlers
            TodoManager.TodoModify += new EventHandler(saveCalendar);
            EventManager.EventModify += new EventHandler(saveCalendar);
            JournalManager.JournalModify += new EventHandler(saveCalendar);
        }

        public bool loadCalendar(Calendar calendar, bool initialize = false)
        {
            try
            {
                IICalendarCollection calendars = iCalendar.LoadFromFile(calendarAbsPath + "\\" + calendar.Filename);

                // Get the enumerator for all calendars
                IEnumerator<IICalendar> ical = calendars.GetEnumerator();

                // Assume that there is only one calendar per file
                if (ical.MoveNext())
                {
                    // Load the current calendar to the MonthCalendar
                    EventManager.Calendar.Load(ical.Current);

                    // Load the current calendar to the Todo Collection
                    // Get the enumerator for all itodos in the current calendar
                    IEnumerator<ITodo> iTodo = ical.Current.Todos.GetEnumerator();

                    while (iTodo.MoveNext())
                    {
                        TodoManager.addTodo(iTodo.Current);
                    }

                    // Load the current calendar to the Journal Collection
                    // Get the enumerator for all ijournals in the current calendar
                    IEnumerator<IJournal> iJournal = ical.Current.Journals.GetEnumerator();

                    while (iJournal.MoveNext())
                    {
                        JournalManager.addJournal(iJournal.Current);
                    }
                }

                // Initialize the calendar and add it to the list
                calendar.IICalendar = ical.Current;
                loadCalendarList.Add(calendar.Name, calendar.IICalendar);
                CalendarList.Add(calendar.Name, calendar);

                if (!initialize)
                {
                    // Update database
                    calendar.Included = true;
                    SqlCommand command = new SqlCommand("UPDATE Calendar SET Included = @NewIncluded WHERE Filename = @Filename", connection);
                    
                    command.Parameters.Add("@NewIncluded", SqlDbType.Bit);
                    command.Parameters["@NewIncluded"].Value = calendar.Included;

                    command.Parameters.Add("@Filename", SqlDbType.VarChar);
                    command.Parameters["@Filename"].Value = calendar.Filename;

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
            if (loadCalendarList.ContainsKey(calendar.Name))
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

                // Unload the current calendar from the Journal Collection
                // Get the enumerator for all ijournals in the current calendar
                IEnumerator<IJournal> iJournal = calendar.IICalendar.Journals.GetEnumerator();

                while (iJournal.MoveNext())
                {
                    JournalManager.removeJournal(iJournal.Current.UID);
                }

                // Remove the current calendar from the list
                loadCalendarList.Remove(calendar.Name);
                CalendarList.Remove(calendar.Name);

                calendar.Included = false;

                // Update table
                DataRow row = CalendarTable.Rows[calendarTableBS.Find("Filename", calendar.Filename)];
                row["Included"] = false;

                // Update database
                SqlCommand command = new SqlCommand("UPDATE Calendar SET Included = @NewIncluded WHERE Filename = @Filename", connection);

                command.Parameters.Add("@NewIncluded", SqlDbType.Bit);
                command.Parameters["@NewIncluded"].Value = calendar.Included;

                command.Parameters.Add("@Filename", SqlDbType.VarChar);
                command.Parameters["@Filename"].Value = calendar.Filename;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public string findCalendarName(IICalendar calendar)
        {
            return loadCalendarList.Keys[loadCalendarList.IndexOfValue(calendar)];
        }

        public bool createCalendar(string name, string filename)
        {
            if(CalendarList.ContainsKey(name) || calendarTableBS.Find("Filename", filename) >= 0)
                return false;
            else
            {
                Calendar newCalendar = new Calendar(name, filename);
                iCalendar newIICalendar = new iCalendar();
                newCalendar.IICalendar = newIICalendar;

                // Insert to table
                DataRow newRow = CalendarTable.NewRow();
                newRow["Name"] = name;
                newRow["Filename"] = filename;
                newRow["Included"] = true;
                CalendarTable.Rows.Add(newRow);

                // Insert to database
                SqlCommand command = new SqlCommand("INSERT INTO Calendar VALUES (@Name, @Filename, @Included)", connection);

                command.Parameters.Add("@Name", SqlDbType.VarChar);
                command.Parameters["@Name"].Value = name;

                command.Parameters.Add("@Filename", SqlDbType.VarChar);
                command.Parameters["@Filename"].Value = filename;

                command.Parameters.Add("@Included", SqlDbType.Bit);
                command.Parameters["@Included"].Value = true;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                return true;
            }
        }

        public bool renameCalendar(string newName, string oldName)
        {
            int oldRowID = calendarTableBS.Find("Name", oldName);
            int newRowID = calendarTableBS.Find("Name", newName);

            if (oldRowID < 0)
                return false;

            if (newRowID > 0)
                return false;

            if (CalendarList.ContainsKey(oldName))
            {
                Calendar calendar = CalendarList[oldName];
                calendar.Name = newName;
                CalendarList.Remove(oldName);
                CalendarList.Add(newName, calendar);

                IICalendar iCalendar = loadCalendarList[oldName];
                loadCalendarList.Remove(oldName);
                loadCalendarList.Add(newName, iCalendar);
            }
            
            string filename = CalendarTable.Rows[oldRowID]["Filename"].ToString();

            // Update database
            SqlCommand command = new SqlCommand("UPDATE Calendar SET Name = @NewName WHERE Filename = @Filename", connection);

            command.Parameters.Add("@NewName", SqlDbType.VarChar);
            command.Parameters["@NewName"].Value = newName;

            command.Parameters.Add("@Filename", SqlDbType.VarChar);
            command.Parameters["@Filename"].Value = filename;

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            DataRow row = CalendarTable.Rows[calendarTableBS.Find("Name", oldName)];
            row["Name"] = newName;
            
            return true;
        }

        public bool deleteCalendar(Calendar calendar)
        {
            if (!CalendarList.ContainsValue(calendar))
                return false;

            unloadCalendar(calendar);

            // Remove from table
            CalendarTable.Rows.RemoveAt(calendarTableBS.Find("Filename", calendar.Filename));

            // Remove from database
            SqlCommand command = new SqlCommand("DELETE FROM Calendar WHERE Filename = @Filename", connection);

            command.Parameters.Add("@Filename", SqlDbType.VarChar);
            command.Parameters["@Filename"].Value = calendar.Filename;

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return true;
        }

        private void saveCalendar(object sender, EventArgs e)
        {
            IICalendar calendar = (IICalendar)sender;
            string filename = CalendarList[findCalendarName(calendar)].Filename;
            iCalendarSerializer serializer = new iCalendarSerializer();
            serializer.Serialize(calendar, calendarAbsPath + "\\" + filename);
        }

        public TodoManager TodoManager { get; private set; }

        public EventManager EventManager { get; private set; }

        public JournalManager JournalManager { get; private set; }

        public SortedList<string, Calendar> CalendarList { get; private set; }

        public DataTable CalendarTable { get; private set; }
    }
}
