using System;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using DDay.iCal;

namespace MultiDesktop
{
    public class TodoManager
    {
        private BindingSource todoTableBS;
        private CalendarManager calendarManager;

        public DataTable TodoTable { get; private set; }

        public SortedList<string, ITodo> TodoList { get; private set; }

        public event EventHandler TodoModify;

        public TodoManager(CalendarManager calendarManager)
        {
            this.calendarManager = calendarManager;
            TodoList = new SortedList<string,ITodo>();
            
            TodoTable = new DataTable();
            TodoTable.TableName = "Todo Table";
            TodoTable.Columns.Add("Recurrence", typeof(Bitmap));
            TodoTable.Columns.Add("Summary", typeof(string));
            TodoTable.Columns.Add("Category", typeof(string));
            TodoTable.Columns.Add("Priority", typeof(string));
            TodoTable.Columns.Add("Status", typeof(bool));
            TodoTable.Columns.Add("StartDate", typeof(string));
            TodoTable.Columns.Add("DueDate", typeof(string));
            TodoTable.Columns.Add("UID", typeof(string));

            todoTableBS = new BindingSource();
            todoTableBS.DataSource = TodoTable;
        }

        public ITodo createTodo(string calendarName)
        {
            return calendarManager.CalendarList[calendarName].IICalendar.Create<Todo>();
        }

        public void addTodo(ITodo newTodo)
        {
            IICalendar calendar = newTodo.Calendar;

            // Add ITodo to the list
            TodoList.Add(newTodo.UID, newTodo);

            // Add ITodo to the table
            DataRow row = TodoTable.NewRow();
            if (newTodo.RecurrenceRules.Count > 0)
                row["Recurrence"] = global::MultiDesktop.Properties.Resources.Recurrence;
            else
                row["Recurrence"] = global::MultiDesktop.Properties.Resources.OneTime;

            row["Summary"] = newTodo.Summary;

            row["Category"] = newTodo.Categories[0];

            row["Priority"] = newTodo.Priority;

            if (newTodo.Status == TodoStatus.Completed)
                row["Status"] = true;
            else
                row["Status"] = false;

            if (newTodo.Start != null)
                row["StartDate"] = newTodo.Start.Date.ToShortDateString();
            else
                row["StartDate"] = "None";

            if (newTodo.Due != null)
                row["DueDate"] = newTodo.Due.Date.ToShortDateString();
            else
                row["DueDate"] = "None";

            row["UID"] = newTodo.UID;

            TodoTable.Rows.Add(row);

            if (TodoModify != null)
                TodoModify(calendar, null);
        }

        public void setNextOccurrence(ITodo existingTodo)
        {
            if (existingTodo.RecurrenceRules.Count > 0)
            {
                existingTodo.Start.IsUniversalTime = true;

                // Determine the next occurrences
                IRecurrencePattern pattern = existingTodo.RecurrenceRules[0];
                IList<Occurrence> list;
                
                DateTime baseDate = existingTodo.Start.Date;
                if (existingTodo.Due != null && existingTodo.Due.Date != DateTime.MinValue)
                    baseDate = existingTodo.Due.Date;
                
                switch (pattern.Frequency)
                {
                    case FrequencyType.Daily:
                        list = existingTodo.GetOccurrences(baseDate.AddDays(1), baseDate.Date.AddDays(7));
                        break;

                    case FrequencyType.Weekly:
                        list = existingTodo.GetOccurrences(baseDate.AddDays(1), baseDate.AddMonths(5));
                        break;

                    case FrequencyType.Monthly:
                        list = existingTodo.GetOccurrences(baseDate.AddDays(1), baseDate.AddYears(5));
                        break;

                    case FrequencyType.Yearly:
                    default:
                        list = existingTodo.GetOccurrences(baseDate.AddDays(1), baseDate.AddYears(10));
                        break;
                }

                // Decrement repeat count if applicable
                if (pattern.Count > 0)
                {
                    pattern.Count--;
                    if (pattern.Count == 1)
                    {
                        existingTodo.RecurrenceRules.Clear();
                    }
                }
                
                // Duplicate todo if there is another occurrence and set a new start date for the current todo
                if (list.Count > 0)
                {
                    ITodo newTodo = duplicateTodo(existingTodo);
                    newTodo.Status = TodoStatus.Completed;
                    addTodo(newTodo);

                    // Cover the special case where both Start and Due are defined, but the correct next occurrence is out of order.
                    int index = 0;
                    while (index < list.Count)
                    {
                        if (baseDate < list[index].Period.StartTime.Date)
                        {
                            TimeSpan duration = existingTodo.Duration;
                            existingTodo.Start = list[index].Period.StartTime;

                            if (existingTodo.Due != null && existingTodo.Due.Date != DateTime.MinValue)
                                existingTodo.Due = new iCalDateTime(existingTodo.Start.Date.Add(duration));

                            break;
                        }
                        index++;
                    }

                    // Cover the special case where todo might contain invalid values
                    if (index == list.Count)
                    {
                        existingTodo.RecurrenceRules.Clear();
                        existingTodo.Status = TodoStatus.Completed;
                    }
                }
                // Cover the special case where todo might contain invalid values
                else
                {
                    existingTodo.RecurrenceRules.Clear();
                    existingTodo.Status = TodoStatus.Completed;
                }
            }
        }

        public void updateTodo(ITodo existingTodo)
        {
            IICalendar calendar = existingTodo.Calendar;

            // Find the corresponding ITodo row in the table
            DataRow row = TodoTable.Rows[todoTableBS.Find("UID", existingTodo.UID)];

            // Update the row
            if (existingTodo.RecurrenceRules.Count > 0)
                row["Recurrence"] = global::MultiDesktop.Properties.Resources.Recurrence;
            else
                row["Recurrence"] = global::MultiDesktop.Properties.Resources.OneTime;

            row["Summary"] = existingTodo.Summary;

            row["Category"] = existingTodo.Categories[0];

            row["Priority"] = existingTodo.Priority;

            if (existingTodo.Status == TodoStatus.Completed)
                row["Status"] = true;
            else
                row["Status"] = false;

            if (existingTodo.Start != null)
                row["StartDate"] = existingTodo.Start.Date.ToShortDateString();
            else
                row["StartDate"] = "None";

            if (existingTodo.Due != null)
                row["DueDate"] = existingTodo.Due.Date.ToShortDateString();
            else
                row["DueDate"] = "None";

            if (TodoModify != null)
                TodoModify(calendar, null);
        }

        public bool removeTodo(string uid)
        {
            if (!TodoList.ContainsKey(uid))
                return false;
            ITodo existingTodo = TodoList[uid];
            IICalendar calendar = existingTodo.Calendar;

            // Remove ITodo from the calendar
            calendar.RemoveChild(existingTodo);

            // Remove ITodo from the list
            TodoList.Remove(uid);

            // Remove ITodo from the table
            TodoTable.Rows.RemoveAt(todoTableBS.Find("UID", uid));

            if (TodoModify != null)
                TodoModify(calendar, null);

            return true;
        }

        private ITodo duplicateTodo(ITodo todo)
        {
            ITodo newTodo = todo.Calendar.Create<Todo>();
            newTodo.Summary = todo.Summary;
            if (todo.Start != null && todo.Start.Date != DateTime.MinValue)
            {
                newTodo.Start = new iCalDateTime(todo.Start);
                newTodo.Start.IsUniversalTime = true;
            }
            if (todo.Due != null && todo.Due.Date != DateTime.MinValue)
            {
                newTodo.Due = new iCalDateTime(todo.Due);
                newTodo.Due.IsUniversalTime = true;
            }
            newTodo.Priority = todo.Priority;
            newTodo.Description = todo.Description;
            newTodo.Categories.Add(todo.Categories[0]);
            newTodo.Class = todo.Class;
            return newTodo;
        }
    }
}
