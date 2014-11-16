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
        private TodoManager todoManager;
        private SortedList<long, ITask> iTaskList;
        private List<IProjDBManager> projDBList;
        private SqlConnection connection;
        private DataTable iTaskTable;

        public TaskManager(TodoManager todoManager, SqlConnection connection)
        {
            this.todoManager = todoManager;
            this.connection = connection;
            iTaskList = new SortedList<long, ITask>();
            projDBList = new List<IProjDBManager>();
            GTaskList = new SortedList<string, GTask>();

            TaskTable = new DataTable();
            TaskTable.TableName = "Task Table";
            TaskTable.Columns.Add("UID", typeof(string));
            TaskTable.Columns.Add("Summary", typeof(string));
            TaskTable.Columns.Add("Start", typeof(string));
            TaskTable.Columns.Add("Due", typeof(string));
            TaskTable.Columns.Add("Complete", typeof(bool));
            TaskTable.Columns.Add("GoalID", typeof(int));

            iTaskTable = new DataTable();
            iTaskTable.TableName = "ITask Table";
            iTaskTable.Columns.Add("UID", typeof(string));
            iTaskTable.Columns.Add("Summary", typeof(string));
            iTaskTable.Columns.Add("Start", typeof(string));
            iTaskTable.Columns.Add("Due", typeof(string));
            iTaskTable.Columns.Add("Complete", typeof(bool));
        }

        public void loadDatabase(bool create = false)
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
                        existingTodo.Start = new iCalDateTime((DateTime)row["Start"]);
                        difference = true;
                    }
                    
                    if (!existingTodo.Due.Date.Equals(row["Due"]))
                    {
                        existingTodo.Due = new iCalDateTime((DateTime)row["Due"]);
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
                else if (create)
                {
                    ITodo newTodo = todoManager.createTodo("Personal");
                    int goalID = Int32.Parse(row["GoalID"].ToString());
                    GTask newTask = new GTask(newTodo, goalID);
                    newTodo.Summary = (string)row["Summary"];
                    newTodo.Start = new iCalDateTime((DateTime)row["Start"]);
                    newTodo.Due = new iCalDateTime((DateTime)row["Due"]);
                    newTodo.Status = (bool)row["Complete"] ? TodoStatus.Completed : TodoStatus.NeedsAction;
                    
                    todoManager.addTodo(newTodo);

                    GTaskList.Add(newTask.Todo.UID, newTask);
                }
            }
        }

        public bool addDatabase(IProjDBManager projDBManager)
        {
            if (projDBList.Contains(projDBManager))
                return false;

            projDBManager.LoadDatabase();
            projDBList.Add(projDBManager);

            ushort projDBID = (ushort)projDBList.IndexOf(projDBManager);

            foreach (uint taskID in projDBManager.ITaskList.Keys)
            {
                ITask task = projDBManager.ITaskList[taskID];
                long newTaskID = taskID + projDBID * ((long)uint.MaxValue + 1);
                iTaskList.Add(newTaskID, task);
                addITask(task, newTaskID);
            }

            projDBManager.DatabaseChanged += new ITaskHandler(projDBManager_DatabaseChanged);

            return true;
        }

        public GTask createGTask(int relatedGoalID, string calendarName = "Personal")
        {
            return new GTask(todoManager.createTodo(calendarName), relatedGoalID);
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

            todoManager.addTodo(newTask.Todo);
            GTaskList.Add(newTask.Todo.UID, newTask);            

            return true;
        }

        public bool updateGTask(GTask existingTask)
        {
            if (!GTaskList.ContainsValue(existingTask))
                return false;

            // Find the corresponding Task row in the table
            DataRow existingRow = TaskTable.Select(String.Format("UID = {0}", existingTask.Todo.UID))[0];
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

            return true;
        }

        public bool removeGTask(string uid)
        {
            if (!GTaskList.ContainsKey(uid))
                return false;

            // Find the corresponding Task row in the table
            int rowID = TaskTable.Rows.IndexOf(TaskTable.Select(String.Format("UID = {0}", uid))[0]);

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

        public bool completeITask(long id)
        {
            if (!iTaskList.ContainsKey(id))
                return false;

            iTaskList[id].Complete = true;

            // Find the corresponding Task row in the table
            DataRow existingRow = iTaskTable.Select(String.Format("UID = {0}", id))[0];
            existingRow["Complete"] = true;

            return true;
        }

        public SortedList<string, GTask> GTaskList { get; private set; }
        public DataTable TaskTable { get; private set; }

        // Add ITask to the TaskTable
        private void addITask(ITask newTask, long id)
        {
            DataRow newRow = iTaskTable.NewRow();
            newRow["UID"] = id.ToString();
            newRow["Summary"] = newTask.Summary;
            newRow["Start"] = newTask.StartDate.ToShortDateString();
            newRow["Due"] = newTask.DueDate.ToShortDateString();
            newRow["Complete"] = newTask.Complete;
            iTaskTable.Rows.Add(newRow);
        }

        private void projDBManager_DatabaseChanged(IProjDBManager sender, ITask task, StatusArgs e)
        {
            if (e.Status == ITaskStatus.Added)
            {
                uint taskID = sender.ITaskList.Keys[sender.ITaskList.IndexOfValue(task)];
                long id = taskID + projDBList.IndexOf(sender) * ((long)uint.MaxValue + 1);
                iTaskList.Add(id, task);
                addITask(task, id);
            }
            else
            {
                long id = iTaskList.Keys[iTaskList.IndexOfValue(task)];

                // Find the corresponding Task row in the table
                int rowID = iTaskTable.Rows.IndexOf(iTaskTable.Select(String.Format("UID = {0}", id))[0]);

                if (e.Status == ITaskStatus.Removed)
                {
                    iTaskList.Remove(id);
                    iTaskTable.Rows.RemoveAt(rowID);
                }
                else //if (e.Status == ITaskStatus.Modified)
                {
                    DataRow existingRow = iTaskTable.Rows[rowID];
                    existingRow["Summary"] = task.Summary;
                    existingRow["Start"] = task.StartDate.ToShortDateString();
                    existingRow["Due"] = task.DueDate.ToShortDateString();
                    existingRow["Complete"] = task.Complete;
                }
            }
        }
    }
}