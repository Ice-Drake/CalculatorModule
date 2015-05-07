using System;
using System.Collections.Generic;
using DDay.iCal;

namespace MultiDesktop
{
    public class JournalBook
    {
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                if (NameChange != null)
                    NameChange(this, null);
            }
        }

        public bool Enabled
        {
            get
            {
                return enable;
            }
            set
            {
                enable = value;
                if (!enable && JournalDisable != null)
                    JournalDisable(this, null);
            }
        }

        public bool Private { get; private set; }
        public string Password { get; set; }
        public int CalendarID { get; private set; }
        public event EventHandler JournalDisable;
        public delegate void EntryModifyEventHandler(int calendarID);
        public event EntryModifyEventHandler EntryModify;
        public event EventHandler NameChange;
        
        private string name;
        private bool enable;
        private SortedList<string, IJournal> entryList;

        public JournalBook(string name, bool privateType, int calendarID)
        {
            Name = name;
            Enabled = false;
            Private = privateType;
            CalendarID = calendarID;
            entryList = new SortedList<string, IJournal>();
        }

        public void addEntry(IJournal newEntry)
        {
            entryList.Add(newEntry.UID, newEntry);
            
            save();

            if (!Enabled)
                Enabled = true;
        }

        public IJournal getEntry(int index)
        {
            return entryList.Values[index];
        }

        public bool removeEntry(int index)
        {
            if (index >= 0 && index < entryList.Values.Count)
            {
                IJournal existingEntry = entryList.Values[index];
                IICalendar calendar = existingEntry.Calendar;

                // Remove IJournal from the calendar
                calendar.RemoveChild(existingEntry);

                // Remove IJournal from the list
                entryList.RemoveAt(index);

                save();

                return true;
            }
            else
                return false;
        }

        public int getEntrySize()
        {
            return entryList.Count;
        }

        public void save()
        {
            if (EntryModify != null)
                EntryModify(CalendarID);
        }

        public void clear()
        {
            entryList.Clear();
            Enabled = false;
        }
    }
}
