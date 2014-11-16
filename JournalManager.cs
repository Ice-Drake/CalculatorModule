using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DDay.iCal;
using DDay.iCal.Serialization.iCalendar;

namespace MultiDesktop
{
    public class JournalManager
    {
        private CalendarManager calendarManager;

        public JournalManager(CalendarManager calendarManager)
        {
            this.calendarManager = calendarManager;
            JournalList = new SortedList<string,IJournal>();
        }

        public IJournal createJournal(string calendarName)
        {
            return calendarManager.CalendarList[calendarName].IICalendar.Create<Journal>();
        }

        public void addJournal(IJournal newJournal)
        {
            IICalendar calendar = newJournal.Calendar;

            JournalList.Add(newJournal.UID, newJournal);

            if (JournalModify != null)
                JournalModify(calendar, null);
        }

        public void updateJournal(IJournal existingJournal)
        {
            IICalendar calendar = existingJournal.Calendar;

            if (JournalModify != null)
                JournalModify(calendar, null);
        }

        public bool removeJournal(string uid)
        {
            if (!JournalList.ContainsKey(uid))
                return false;
            IJournal existingJournal = JournalList[uid];
            IICalendar calendar = existingJournal.Calendar;

            // Remove IJournal from the calendar
            calendar.RemoveChild(existingJournal);

            // Remove IJournal from the list
            JournalList.Remove(uid);

            if (JournalModify != null)
                JournalModify(calendar, null);

            return true;
        }

        public SortedList<string, IJournal> JournalList
        {
            get;
            internal set;
        }

        public event EventHandler JournalModify;
    }
}
