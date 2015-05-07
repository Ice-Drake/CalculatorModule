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
    public class JournalManager
    {
        public SortedList<int, JournalBook> JournalList { get; private set; }
        public DataTable JournalTable { get; private set; }
        public event EventHandler JournalModify;
        public delegate void JournalBookEventHandler(JournalBook sender);
        public event JournalBookEventHandler JournalBookCreate;
        public event JournalBookEventHandler JournalBookRemove;

        private CalendarManager calendarManager;
        private SqlConnection connection;

        public JournalManager(CalendarManager calendarManager, SqlConnection connection)
        {
            this.calendarManager = calendarManager;
            this.connection = connection;
            JournalList = new SortedList<int, JournalBook>();

            JournalTable = new DataTable();
            JournalTable.TableName = "Journal Table";
            JournalTable.Columns.Add("ID", typeof(int));
            JournalTable.Columns.Add("Name", typeof(string));
            JournalTable.Columns.Add("Private", typeof(bool));
            JournalTable.Columns.Add("CalendarID", typeof(int));
        }

        public void loadDatabase()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Journal", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    try
                    {
                        int id = Int32.Parse(reader[0].ToString());
                        string name = reader[1].ToString();
                        bool privateType = Boolean.Parse(reader[2].ToString());
                        int calendarID = Int32.Parse(reader[4].ToString());

                        JournalBook newJournal = new JournalBook(name, privateType, calendarID);
                        if (privateType)
                            newJournal.Password = reader[3].ToString();

                        newJournal.EntryModify += new JournalBook.EntryModifyEventHandler(saveJournal);
                        JournalList.Add(id, newJournal);

                        DataRow newRow = JournalTable.NewRow();
                        newRow["ID"] = id;
                        newRow["Name"] = name;
                        newRow["Private"] = privateType;
                        newRow["CalendarID"] = calendarID;
                        JournalTable.Rows.Add(newRow);
                    }
                    catch (FormatException)
                    {
                        System.Windows.Forms.MessageBox.Show("Corrupted Journal Setting Database! Click OK to proceed on clearing it.");
                    }
                    finally
                    {
                        //Remove and reconstruct Journal Table.
                    }
                }
            }
            finally
            {
                reader.Close();
            }

            connection.Close();
        }

        public void load(Calendar calendar)
        {
            // Prepare a list for convenient JournalBook searching
            SortedList<string, JournalBook> searchList = new SortedList<string, JournalBook>();
            foreach (JournalBook journal in JournalList.Values)
            {
                if (journal.CalendarID == calendar.ID)
                    searchList.Add(journal.Name, journal);
            }

            IEnumerator<IJournal> iJournal = calendar.IICalendar.Journals.GetEnumerator();

            while (iJournal.MoveNext())
            {
                if (iJournal.Current.Categories.Count != 0 && searchList.ContainsKey(iJournal.Current.Categories[0]))
                {
                    searchList[iJournal.Current.Categories[0]].addEntry(iJournal.Current);
                }
            }
        }

        public void unload(Calendar calendar)
        {
            foreach (JournalBook journal in JournalList.Values)
            {
                if (journal.CalendarID == calendar.ID)
                {
                    journal.clear();
                }
            }
        }

        public void createJournal(int calendarID, string name, bool privateType, string password = "")
        {
            // Insert to database
            SqlCommand command = new SqlCommand("INSERT INTO Journal (Name, Private, Password, CalendarID) VALUES (@Name, @Private, @Password, @CalendarID); SELECT SCOPE_IDENTITY();", connection);

            command.Parameters.Add("@Name", SqlDbType.VarChar);
            command.Parameters["@Name"].Value = name;

            command.Parameters.Add("@Private", SqlDbType.Bit);
            command.Parameters["@Private"].Value = privateType;

            command.Parameters.Add("@Password", SqlDbType.VarChar);
            command.Parameters["@Password"].Value = privateType ? password : (object)DBNull.Value;
            
            command.Parameters.Add("@CalendarID", SqlDbType.Int);
            command.Parameters["@CalendarID"].Value = calendarID;

            connection.Open();
            int id = Int32.Parse(command.ExecuteScalar().ToString());
            connection.Close();

            // Insert to table
            DataRow newRow = JournalTable.NewRow();
            newRow["ID"] = id;
            newRow["Name"] = name;
            newRow["Private"] = privateType;
            newRow["CalendarID"] = calendarID;
            JournalTable.Rows.Add(newRow);

            // Add it to the list
            JournalBook newJournal = new JournalBook(name, privateType, calendarID);
            if (privateType)
                newJournal.Password = password;
            newJournal.Enabled = true;
            newJournal.EntryModify += new JournalBook.EntryModifyEventHandler(saveJournal);
            JournalList.Add(id, newJournal);

            if (JournalBookCreate != null)
                JournalBookCreate(newJournal);
        }

        public bool containsJournal(string name)
        {
            foreach (JournalBook journal in JournalList.Values)
            {
                if (journal.Name.Equals(name))
                    return true;
            }

            return false;
        }

        public void updateJournal(JournalBook existingJournal)
        {
            int id = JournalList.Keys[JournalList.IndexOfValue(existingJournal)];

            // Update database
            SqlCommand command = new SqlCommand("UPDATE Journal SET Name = @Name, Password = @Password WHERE ID = @ID", connection);

            command.Parameters.Add("@Name", SqlDbType.VarChar);
            command.Parameters["@Name"].Value = existingJournal.Name;

            command.Parameters.Add("@Password", SqlDbType.VarChar);
            command.Parameters["@Password"].Value = existingJournal.Private ? existingJournal.Password : (object)DBNull.Value;
            
            command.Parameters.Add("@ID", SqlDbType.Int);
            command.Parameters["@ID"].Value = id;

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            // Update table
            DataRow row = JournalTable.Select(String.Format("ID = {0}", id))[0];
            row["Name"] = existingJournal.Name;
            row["Private"] = existingJournal.Private;
        }

        public bool removeJournal(JournalBook existingJournal)
        {
            if (!JournalList.ContainsValue(existingJournal))
                return false;
            int id = JournalList.Keys[JournalList.IndexOfValue(existingJournal)];
            IICalendar calendar = calendarManager.CalendarList[existingJournal.CalendarID].IICalendar;

            while (existingJournal.getEntrySize() > 0)
            {
                IJournal journal = existingJournal.getEntry(0);
                
                // Remove IJournal from the calendar
                journal.Calendar.RemoveChild(journal);
                
                // Remove entry from the JournalBook
                existingJournal.removeEntry(0);
            }

            // Remove JournalBook from the table
            int rowID = JournalTable.Rows.IndexOf(JournalTable.Select(String.Format("ID = {0}", id))[0]);
            JournalTable.Rows.RemoveAt(rowID);

            // Remove JournalBook from the list
            JournalList.Remove(id);

            // Remove all eventhandlers
            existingJournal.EntryModify -= new JournalBook.EntryModifyEventHandler(saveJournal);

            if (JournalModify != null)
                JournalModify(calendar, null);

            return true;
        }

        private void saveJournal(int calendarID)
        {
            if (calendarManager.CalendarList.ContainsKey(calendarID) && JournalModify != null)
                JournalModify(calendarManager.CalendarList[calendarID].IICalendar, null);
        }
    }
}
