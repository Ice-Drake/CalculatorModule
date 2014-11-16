using System;
using System.Data;
using System.Windows.Forms;
using Library;
using DDay.iCal;

namespace MultiDesktop
{
    public class EventManager
    {
        private CalendarManager calendarManager;
        private BindingSource eventTableBS;

        public EventManager(CalendarManager calendarManager)
        {
            this.calendarManager = calendarManager;
            Calendar = new Library.MonthCalendar();

            EventTable = new DataTable();
            EventTable.TableName = "Event Table";
            EventTable.Columns.Add("Summary", typeof(string));
            EventTable.Columns.Add("Date", typeof(string));
            EventTable.Columns.Add("UID", typeof(string));

            eventTableBS = new BindingSource();
            eventTableBS.DataSource = EventTable;
        }

        public IEvent createEvent(string calendarName)
        {
            return calendarManager.CalendarList[calendarName].IICalendar.Create<Event>();
        }

        public void addEvent(IEvent newEvent)
        {
            IICalendar calendar = newEvent.Calendar;
            Calendar.AddDateInfo(new DateItem(newEvent));

            // Update event table if appropriate
            if (newEvent.GetOccurrences(DateTime.Today, DateTime.Today.AddDays(6)).Count > 0)
                updateEventTable();

            if (EventModify != null)
                EventModify(calendar, null);
        }

        public void updateEvent(DateItem existingDateItem)
        {
            IICalendar calendar = existingDateItem.Event.Calendar;
            existingDateItem.Update();

            // Update event table if appropriate
            if (existingDateItem.Event.GetOccurrences(DateTime.Today, DateTime.Today.AddDays(6)).Count > 0)
                updateEventTable();

            // Firing the appropriate event
            if (EventModify != null)
                EventModify(calendar, null);
        }

        public bool removeEvent(DateItem existingDateItem)
        {
            IICalendar calendar = existingDateItem.Event.Calendar;

            // Remove IEvent from the calendar
            calendar.RemoveChild(existingDateItem.Event);

            // Remove IEvent from the MonthCalendar
            Calendar.RemoveDateInfo(existingDateItem);

            // Remove ITodo from the table
            EventTable.Rows.RemoveAt(eventTableBS.Find("UID", existingDateItem.Event.UID));

            // Update event table if appropriate
            if (existingDateItem.Event.GetOccurrences(DateTime.Today, DateTime.Today.AddDays(6)).Count > 0)
                updateEventTable();

            // Firing the appropriate event
            if (EventModify != null)
                EventModify(calendar, null);

            return true;
        }

        private void updateEventTable()
        {
            EventTable.Clear();
            for (DateTime currentDate = DateTime.Today; currentDate != DateTime.Today.AddDays(6); currentDate.AddDays(1))
            {
                foreach (Library.DateItem dateItem in Calendar.GetDateInfo(currentDate))
                {
                    DataRow row = EventTable.NewRow();
                    row["Summary"] = dateItem.Event.Summary;
                    if (dateItem.Event.Location != String.Empty)
                        row["Summary"] += "@" + dateItem.Event.Location;
                    row["Date"] = currentDate.ToShortDateString();
                    if (!dateItem.Event.IsAllDay)
                        row["Summary"] += " (" + dateItem.Event.Start.ToString("t") + " - " + dateItem.Event.End.ToString("t") + ")";
                    row["UID"] = dateItem.Event.UID;

                    EventTable.Rows.Add(row);
                }
            }
        }

        public DataTable EventTable { get; private set; }

        public Library.MonthCalendar Calendar { get; private set; }

        public event EventHandler EventModify;
    }
}
