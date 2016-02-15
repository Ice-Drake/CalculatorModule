using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using DDay.iCal;
using PluginSDK;

namespace MultiDesktop
{
    public class TaskManager
    {
        public SortedList<string, GTask> GTaskList { get; private set; }
        public DataTable TaskTable { get; private set; }

        private TodoManager todoManager;
        private SQLiteConnection connection;

        public TaskManager(TodoManager todoManager, SQLiteConnection connection)
        {
            this.todoManager = todoManager;
            this.connection = connection;
            GTaskList = new SortedList<string, GTask>();

            TaskTable = new DataTable();
            TaskTable.TableName = "GTask Table";
            TaskTable.Columns.Add("UID", typeof(string));
            TaskTable.Columns.Add("Summary", typeof(string));
            TaskTable.Columns.Add("Start", typeof(DateTime));
            TaskTable.Columns.Add("Due", typeof(DateTime));
            TaskTable.Columns.Add("Complete", typeof(bool));
            TaskTable.Columns.Add("GoalID", typeof(int));
        }

        public void loadDatabase()
        {
            connection.Open();
            using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter("SELECT * FROM Task", connection))
            {
                dataAdapter.Fill(TaskTable);
            }
            connection.Close();

            foreach (DataRow row in TaskTable.Rows)
            {
                if (todoManager.TodoList.ContainsKey((string)row["UID"]))
                {
                    bool difference = false;
                    ITodo existingTodo = todoManager.TodoList[(string)row["UID"]];
                    int goalID = Int32.Parse(row["GoalID"].ToString());
                    GTask newTask = new GTask(existingTodo, goalID);
                    if (!existingTodo.Summary.Equals(row["Summary"]))
                    {
                        existingTodo.Summary = (string)row["Summary"];
                        difference = true;
                    }

                    if (!existingTodo.Start.Date.Equals(row["Start"]))
                    {
                        existingTodo.Start = new iCalDateTime(DateTime.Parse(row["Start"].ToString()));
                        difference = true;
                    }
                    
                    if (!existingTodo.Due.Date.Equals(row["Due"]))
                    {
                        existingTodo.Due = new iCalDateTime(DateTime.Parse(row["Due"].ToString()));
                        difference = true;
                    }
                    
                    if (!((existingTodo.Status == TodoStatus.Completed) == (bool)row["Complete"]))
                    {
                        existingTodo.Status = (bool)row["Complete"] ? TodoStatus.Completed : TodoStatus.NeedsAction;
                        difference = true;
                    }

                    if (difference)
                        todoManager.updateTodo(existingTodo);
                    
                    GTaskList.Add(newTask.Todo.UID, newTask);
                }
            }
        }

        public GTask createGTask(int relatedGoalID, int calendarID = 1)
        {
            return new GTask(todoManager.createTodo(calendarID), relatedGoalID);
        }

        public bool addGTask(GTask newTask)
        {
            if (GTaskList.ContainsKey(newTask.Todo.UID))
                return false;

            DataRow newRow = TaskTable.NewRow();
            newRow["UID"] = newTask.Todo.UID;
            newRow["Summary"] = newTask.Todo.Summary;
            newRow["Start"] = newTask.Todo.Start.Date.ToShortDateString();
            newRow["Due"] = newTask.Todo.Due.Date.ToShortDateString();
            newRow["Complete"] = newTask.Todo.Status == TodoStatus.Completed;
            newRow["GoalID"] = newTask.RelatedGoalID;
            TaskTable.Rows.Add(newRow);

            string query = String.Format("INSERT INTO Task (UID, Summary, Start, Due, Complete, GoalID) VALUES ('{0}', '{1}', '{2}', '{3}', {4}, {5})", newTask.Todo.UID, newTask.Todo.Summary, newTask.Todo.Start.Date.ToShortDateString(), newTask.Todo.Due.Date.ToShortDateString(), newTask.Todo.Status == TodoStatus.Completed ? 1 : 0, newTask.RelatedGoalID);
            SQLiteCommand command = new SQLiteCommand(query, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            if (!todoManager.TodoList.ContainsKey(newTask.Todo.UID))
                todoManager.addTodo(newTask.Todo);
            GTaskList.Add(newTask.Todo.UID, newTask);            

            return true;
        }

        public void updateGTask(GTask existingTask)
        {
            // Initially missing todo, thus yield no existing task
            if (!GTaskList.ContainsValue(existingTask))
                GTaskList.Add(existingTask.Todo.UID, existingTask);

            // Find the corresponding Task row in the table
            DataRow existingRow = TaskTable.Select(String.Format("UID = '{0}'", existingTask.Todo.UID))[0];
            existingRow["Summary"] = existingTask.Todo.Summary;
            existingRow["Start"] = existingTask.Todo.Start.Date.ToShortDateString();
            existingRow["Due"] = existingTask.Todo.Due.Date.ToShortDateString();
            existingRow["Complete"] = existingTask.Todo.Status == TodoStatus.Completed;
            existingRow["GoalID"] = existingTask.RelatedGoalID;

            string query = String.Format("UPDATE Task SET Summary = '{0}', Start = '{1}', Due = '{2}', Complete = {3}, GoalID = {4} WHERE UID = '{5}'", existingTask.Todo.Summary, existingTask.Todo.Start.Date.ToShortDateString(), existingTask.Todo.Due.Date.ToShortDateString(), existingTask.Todo.Status == TodoStatus.Completed ? 1 : 0, existingTask.RelatedGoalID, existingTask.Todo.UID);
            SQLiteCommand command = new SQLiteCommand(query, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            todoManager.updateTodo(existingTask.Todo);
        }

        public void replaceGTaskID(string oldUID, string newUID)
        {
            // Find the corresponding Task row in the table
            DataRow existingRow = TaskTable.Select(String.Format("UID = '{0}'", oldUID))[0];
            existingRow["UID"] = newUID;

            string query = String.Format("UPDATE Task SET UID = '{0}' WHERE UID = '{1}'", newUID, oldUID);
            SQLiteCommand command = new SQLiteCommand(query, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public bool removeGTask(string uid)
        {
            if (!GTaskList.ContainsKey(uid))
                return false;

            // Find the corresponding Task row in the table
            int rowID = TaskTable.Rows.IndexOf(TaskTable.Select(String.Format("UID = '{0}'", uid))[0]);

            ITodo existingTodo = GTaskList[uid].Todo;

            GTaskList.Remove(uid);
            TaskTable.Rows.RemoveAt(rowID);

            todoManager.removeTodo(existingTodo.UID);

            string query = String.Format("DELETE FROM Task WHERE UID = '{0}'", uid);
            SQLiteCommand command = new SQLiteCommand(query, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return true;
        }
    }
}