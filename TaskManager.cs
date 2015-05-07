using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        private SqlConnection connection;

        public TaskManager(TodoManager todoManager, SqlConnection connection)
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
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Task", connection))
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

            SqlCommand command = new SqlCommand("INSERT INTO Task (UID, Summary, Start, Due, Complete, GoalID) VALUES (@UID, @Summary, @Start, @Due, @Complete, @GoalID)", connection);

            command.Parameters.Add("@UID", SqlDbType.VarChar);
            command.Parameters["@UID"].Value = newTask.Todo.UID;

            command.Parameters.Add("@Summary", SqlDbType.VarChar);
            command.Parameters["@Summary"].Value = newTask.Todo.Summary;

            command.Parameters.Add("@Start", SqlDbType.Date);
            command.Parameters["@Start"].Value = newTask.Todo.Start.Date;

            command.Parameters.Add("@Due", SqlDbType.Date);
            command.Parameters["@Due"].Value = newTask.Todo.Due.Date;
            
            command.Parameters.Add("@Complete", SqlDbType.Bit);
            command.Parameters["@Complete"].Value = newTask.Todo.Status == TodoStatus.Completed;

            command.Parameters.Add("@GoalID", SqlDbType.Int);
            command.Parameters["@GoalID"].Value = newTask.RelatedGoalID;

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

            SqlCommand command = new SqlCommand("UPDATE Task SET Summary = @Summary, Start = @Start, Due = @Due, Complete = @Complete, GoalID = @GoalID WHERE UID = @UID", connection);

            command.Parameters.Add("@UID", SqlDbType.VarChar);
            command.Parameters["@UID"].Value = existingTask.Todo.UID;

            command.Parameters.Add("@Summary", SqlDbType.VarChar);
            command.Parameters["@Summary"].Value = existingTask.Todo.Summary;

            command.Parameters.Add("@Start", SqlDbType.Date);
            command.Parameters["@Start"].Value = existingTask.Todo.Start.Date;

            command.Parameters.Add("@Due", SqlDbType.Date);
            command.Parameters["@Due"].Value = existingTask.Todo.Due.Date;

            command.Parameters.Add("@Complete", SqlDbType.Bit);
            command.Parameters["@Complete"].Value = existingTask.Todo.Status == TodoStatus.Completed;

            command.Parameters.Add("@GoalID", SqlDbType.Int);
            command.Parameters["@GoalID"].Value = existingTask.RelatedGoalID;

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

            SqlCommand command = new SqlCommand("UPDATE Task SET UID = @NewUID WHERE UID = @OldUID", connection);

            command.Parameters.Add("@OldUID", SqlDbType.VarChar);
            command.Parameters["@OldUID"].Value = oldUID;
            
            command.Parameters.Add("@NewUID", SqlDbType.VarChar);
            command.Parameters["@NewUID"].Value = newUID;

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

            SqlCommand command = new SqlCommand("DELETE FROM Task WHERE UID = @UID", connection);

            command.Parameters.Add("@UID", SqlDbType.Int);
            command.Parameters["@UID"].Value = uid;

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return true;
        }
    }
}