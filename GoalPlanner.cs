using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Library;

namespace MultiDesktop
{
    public class GoalPlanner
    {
        public VisionManager VisionManager { get; private set; }
        public TaskManager TaskManager { get; private set; }
        public SortedList<int, Goal> GoalList { get; private set; }
        public DataTable LGoalTable { get; private set; }
        public DataTable SGoalTable { get; private set; }
        public ProjectManager ProjectManager { get; private set; }
        public event EventHandler GoalModify;

        private SQLiteConnection connection;

        public GoalPlanner(TodoManager todoManager)
        {
            connection = new SQLiteConnection("Data Source=Goal.sqlite;Version=3;");
            VisionManager = new VisionManager(connection);
            TaskManager = new TaskManager(todoManager, connection);
            GoalList = new SortedList<int, Goal>();

            LGoalTable = new DataTable();
            LGoalTable.TableName = "LGoal Table";
            LGoalTable.Columns.Add("ID", typeof(int));
            LGoalTable.Columns.Add("Summary", typeof(string));
            LGoalTable.Columns.Add("Complete", typeof(bool));
            LGoalTable.Columns.Add("Category", typeof(string));
            LGoalTable.Columns.Add("Description", typeof(string));
            LGoalTable.Columns.Add("Predecessor", typeof(string));
            LGoalTable.Columns.Add("Start", typeof(DateTime));
            LGoalTable.Columns.Add("Due", typeof(DateTime));
            LGoalTable.Columns.Add("Scheme", typeof(int));
            LGoalTable.Columns.Add("VisionID", typeof(int));

            SGoalTable = new DataTable();
            SGoalTable.TableName = "SGoal Table";
            SGoalTable.Columns.Add("ID", typeof(int));
            SGoalTable.Columns.Add("Summary", typeof(string));
            SGoalTable.Columns.Add("Complete", typeof(bool));
            SGoalTable.Columns.Add("Category", typeof(string));
            SGoalTable.Columns.Add("Description", typeof(string));
            SGoalTable.Columns.Add("Predecessor", typeof(string));
            SGoalTable.Columns.Add("Start", typeof(DateTime));
            SGoalTable.Columns.Add("Due", typeof(DateTime));
            SGoalTable.Columns.Add("Days Remaining", typeof(int));
            SGoalTable.Columns.Add("Priority", typeof(int));
            SGoalTable.Columns.Add("LGoalID", typeof(int));

            ProjectManager = new ProjectManager();
        }

        public void loadDatabase()
        {
            VisionManager.loadDatabase();

            connection.Open();
            using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter("SELECT A.*, B.* FROM LGoal A LEFT JOIN Goal B ON A.ID = B.ID", connection))
            {
                dataAdapter.Fill(LGoalTable);
            }

            using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter("SELECT A.*, B.* FROM SGoal A LEFT JOIN Goal B ON A.ID = B.ID", connection))
            {
                dataAdapter.Fill(SGoalTable);
            }
            connection.Close();

            foreach (DataRow row in LGoalTable.Rows)
            {
                int rowID = Int32.Parse(row["ID"].ToString());
                LGoal newGoal = new LGoal(rowID, DateTime.Parse(row["Start"].ToString()));
                newGoal.Name = (string)row["Summary"];
                newGoal.Complete = (bool)row["Complete"] ? 1.0f : 0.0f;
                newGoal.Category = (string)row["Category"];
                newGoal.Desc = (string)row["Description"];
                newGoal.Predecessors = (string)row["Predecessor"];
                if (row["Due"] != DBNull.Value)
                    newGoal.DueDate = DateTime.Parse(row["Due"].ToString());
                newGoal.Scheme = Int32.Parse(row["Scheme"].ToString());
                newGoal.VisionID = Int32.Parse(row["VisionID"].ToString());

                GoalList.Add(newGoal.ID, newGoal);
                ProjectManager.Add(newGoal);
            }

            foreach (DataRow row in SGoalTable.Rows)
            {
                int rowID = Int32.Parse(row["ID"].ToString());
                SGoal newGoal = new SGoal(rowID, DateTime.Parse(row["Due"].ToString()));
                newGoal.Name = (string)row["Summary"];
                newGoal.Complete = (bool)row["Complete"] ? 1.0f : 0.0f;
                newGoal.Category = (string)row["Category"];
                newGoal.Desc = (string)row["Description"];
                newGoal.Predecessors = (string)row["Predecessor"];
                if (row["Start"] != DBNull.Value)
                    newGoal.StartDate = DateTime.Parse(row["Start"].ToString());
                newGoal.Priority = Int32.Parse(row["Priority"].ToString());

                if (newGoal.StartDate != DateTime.MinValue && newGoal.StartDate >= DateTime.Today)
                {
                    TimeSpan diff = newGoal.DueDate - newGoal.StartDate;
                    row["Days Remaining"] = diff.Days;
                }
                else
                {
                    TimeSpan diff = newGoal.DueDate - DateTime.Today;
                    if (diff.Days > 0)
                        row["Days Remaining"] = diff.Days;
                    else
                        row["Days Remaining"] = 0;
                }

                GoalList.Add(newGoal.ID, newGoal);
                ProjectManager.Add(newGoal);

                int lGoalID = Int32.Parse(row["LGoalID"].ToString());
                if (GoalList.ContainsKey(lGoalID))
                {
                    newGoal.LGoal = (LGoal)GoalList[lGoalID];
                    ProjectManager.Group(newGoal.LGoal, newGoal);
                }
            }

            foreach (Goal goal in GoalList.Values)
            {
                updatePredecessors(goal);
            }
            
            TaskManager.loadDatabase();
        }

        public DataTable findPossiblePredecessors(Goal goal)
        {
            DataTable predecessorTable = new DataTable();
            predecessorTable.TableName = "Predecessor Table";
            predecessorTable.Columns.Add("Checked", typeof(bool));            
            predecessorTable.Columns.Add("Summary", typeof(string));
            predecessorTable.Columns.Add("ID", typeof(string));

            if (goal != null)
            {
                List<Goal> currentDependants = new List<Goal>();
                foreach (Task task in ProjectManager.DependantsOf(goal))
                {
                    currentDependants.Add((Goal)task);
                }

                List<Goal> currentPredecessors = new List<Goal>();
                foreach (Task task in ProjectManager.DirectPrecedentsOf(goal))
                {
                    currentPredecessors.Add((Goal)task);
                }

                foreach (Goal currentGoal in GoalList.Values)
                {
                    if (currentPredecessors.Contains(currentGoal))
                    {
                        // Current Predecessors
                        DataRow newRow = predecessorTable.NewRow();
                        newRow["ID"] = currentGoal.ID;
                        newRow["Summary"] = currentGoal.Name;
                        newRow["Checked"] = true;
                        predecessorTable.Rows.Add(newRow);
                    }
                    else if (!currentDependants.Contains(currentGoal) && currentGoal != goal)
                    {
                        // Possible Predecessors
                        DataRow newRow = predecessorTable.NewRow();
                        newRow["ID"] = currentGoal.ID;
                        newRow["Summary"] = currentGoal.Name;
                        newRow["Checked"] = false;
                        predecessorTable.Rows.Add(newRow);
                    }
                }
            }
            else
            {
                foreach (Goal currentGoal in GoalList.Values)
                {
                    DataRow newRow = predecessorTable.NewRow();
                    newRow["ID"] = currentGoal.ID;
                    newRow["Summary"] = currentGoal.Name;
                    newRow["Checked"] = false;
                    predecessorTable.Rows.Add(newRow);
                }
            }
            return predecessorTable;
        }

        public bool createLGoal(string summary, bool complete, string category, string desc, string predecessor, DateTime startDate, DateTime dueDate, int scheme, int visionID)
        {
            int id = createGoal(summary, complete, category, desc, predecessor);
            
            LGoal newGoal = new LGoal(id, startDate);
            newGoal.Name = summary;
            newGoal.Complete = complete ? 1.0f : 0.0f;
            newGoal.Category = category;
            newGoal.Desc = desc;
            newGoal.Predecessors = predecessor;
            newGoal.StartDate = startDate;
            newGoal.DueDate = dueDate;
            newGoal.Scheme = scheme;
            newGoal.VisionID = visionID;

            string query = String.Format("INSERT INTO LGoal (ID, Start, Due, Scheme, VisionID) VALUES ({0}, '{1}', '{2}', {3}, {4})", id, startDate.ToShortDateString(), dueDate != DateTime.MinValue ? dueDate.ToShortDateString() : "NULL", scheme, visionID);
            SQLiteCommand command = new SQLiteCommand(query, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            GoalList.Add(newGoal.ID, newGoal);
            ProjectManager.Add(newGoal);
            updatePredecessors(newGoal);

            DataRow newRow = LGoalTable.NewRow();
            newRow["ID"] = newGoal.ID;
            newRow["Summary"] = newGoal.Name;
            newRow["Complete"] = newGoal.Complete == 1.0f;
            newRow["Category"] = newGoal.Category;
            newRow["Description"] = newGoal.Desc;
            newRow["Predecessor"] = newGoal.Predecessors;
            newRow["Start"] = newGoal.StartDate.ToShortDateString();
            if (newGoal.DueDate != DateTime.MinValue)
                newRow["Due"] = newGoal.DueDate.ToShortDateString();
            newRow["Scheme"] = newGoal.Scheme;
            newRow["VisionID"] = newGoal.VisionID;
            LGoalTable.Rows.Add(newRow);

            if (GoalModify != null)
                GoalModify(newGoal, null);

            return true;
        }

        public bool updateLGoal(LGoal existingGoal)
        {
            updateGoal(existingGoal);

            string query = String.Format("UPDATE LGoal SET Start = '{0}', Due = '{1}', Scheme = {2}, VisionID = {3} WHERE ID = {4}", existingGoal.StartDate.ToShortDateString(), existingGoal.DueDate != DateTime.MinValue ? existingGoal.DueDate.ToShortDateString() : "NULL", existingGoal.Scheme, existingGoal.VisionID, existingGoal.ID);
            SQLiteCommand command = new SQLiteCommand(query, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            updatePredecessors(existingGoal);

            DataRow existingRow = LGoalTable.Select(String.Format("ID = {0}", existingGoal.ID))[0];
            existingRow["Summary"] = existingGoal.Name;
            existingRow["Complete"] = existingGoal.Complete == 1.0f;
            existingRow["Category"] = existingGoal.Category;
            existingRow["Description"] = existingGoal.Desc;
            existingRow["Predecessor"] = existingGoal.Predecessors;
            existingRow["Start"] = existingGoal.StartDate.ToShortDateString();
            if (existingGoal.DueDate != DateTime.MinValue)
                existingRow["Due"] = existingGoal.DueDate.ToShortDateString();
            else
                existingRow["Due"] = DBNull.Value;
            existingRow["Scheme"] = existingGoal.Scheme;
            existingRow["VisionID"] = existingGoal.VisionID;

            if (GoalModify != null)
                GoalModify(existingGoal, null);

            // Ensure all start and due dates of its SGoal remain to be in a valid range
            foreach (DataRow row in SGoalTable.Select("LGoalID = " + existingGoal.ID))
            {
                SGoal goal = (SGoal)GoalList[Int32.Parse(row["ID"].ToString())];
                if (goal.StartDate != DateTime.MinValue && goal.StartDate < existingGoal.StartDate)
                {
                    TimeSpan gap = existingGoal.StartDate - goal.StartDate;
                    goal.StartDate = existingGoal.StartDate;
                    if ((existingGoal.DueDate != DateTime.MinValue && goal.DueDate.AddDays(gap.Days) <= existingGoal.DueDate) ||
                        (existingGoal.DueDate == DateTime.MinValue && goal.DueDate.AddDays(gap.Days) <= existingGoal.StartDate.AddDays(365)))
                        goal.DueDate = goal.DueDate.AddDays(gap.Days);
                    else
                        goal.DueDate = existingGoal.DueDate;

                    updateSGoal(goal);
                }
                else if (goal.StartDate == DateTime.MinValue && goal.DueDate.AddDays(-30) < existingGoal.StartDate)
                {
                    TimeSpan gap = existingGoal.StartDate - goal.DueDate.AddDays(-30);
                    goal.DueDate = goal.DueDate.AddDays(gap.Days);
                    
                    updateSGoal(goal);
                }
                else if (existingGoal.DueDate != DateTime.MinValue && goal.DueDate > existingGoal.DueDate)
                {
                    TimeSpan gap = goal.DueDate - existingGoal.DueDate;
                    goal.DueDate = existingGoal.DueDate;

                    if (goal.StartDate != DateTime.MinValue)
                        goal.StartDate = goal.StartDate.AddDays(-gap.Days);
                    
                    updateSGoal(goal);
                }
                else if (existingGoal.DueDate == DateTime.MinValue && goal.DueDate > existingGoal.StartDate.AddDays(365))
                {
                    TimeSpan gap = goal.DueDate - existingGoal.StartDate.AddDays(365);
                    goal.DueDate = existingGoal.StartDate.AddDays(365);

                    if (goal.StartDate != DateTime.MinValue)
                        goal.StartDate = goal.StartDate.AddDays(-gap.Days);

                    updateSGoal(goal);
                }
            }

            return true;
        }

        public bool removeLGoal(int id)
        {
            removeGoal(id);

            string query = String.Format("DELETE FROM LGoal WHERE ID = {0}", id);
            SQLiteCommand command = new SQLiteCommand(query, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            Goal goal = GoalList[id];
            ProjectManager.Delete(goal);
            GoalList.Remove(id);

            LGoalTable.Rows.Remove(LGoalTable.Select(String.Format("ID = {0}", id))[0]);

            if (GoalModify != null)
                GoalModify(goal, null);

            return true;
        }

        public bool createSGoal(string summary, bool complete, string category, string desc, string predecessor, DateTime startDate, DateTime dueDate, int priority, int lGoalID)
        {
            int id = createGoal(summary, complete, category, desc, predecessor);
            
            SGoal newGoal = new SGoal(id, dueDate);
            newGoal.Name = summary;
            newGoal.Complete = complete ? 1.0f : 0.0f;
            newGoal.Category = category;
            newGoal.Desc = desc;
            newGoal.Predecessors = predecessor;
            newGoal.DueDate = dueDate;
            newGoal.StartDate = startDate;
            newGoal.Priority = priority;
            if (lGoalID != 0 && GoalList[lGoalID].GetType() == typeof(LGoal))
                newGoal.LGoal = (LGoal)GoalList[lGoalID];

            string query = String.Format("INSERT INTO SGoal (ID, Start, Due, Priority, LGoalID) VALUES ({0}, '{1}', '{2}', {3}, {4})", id, startDate != DateTime.MinValue ? startDate.ToShortDateString() : "NULL", dueDate.ToShortDateString(), priority, lGoalID);
            SQLiteCommand command = new SQLiteCommand(query, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            GoalList.Add(newGoal.ID, newGoal);
            ProjectManager.Add(newGoal);
            updatePredecessors(newGoal);

            if (newGoal.LGoal != null)
                ProjectManager.Group(newGoal.LGoal, newGoal);

            DataRow newRow = SGoalTable.NewRow();
            newRow["ID"] = newGoal.ID;
            newRow["Summary"] = newGoal.Name;
            newRow["Complete"] = newGoal.Complete == 1.0f;
            newRow["Category"] = newGoal.Category;
            newRow["Description"] = newGoal.Desc;
            newRow["Predecessor"] = newGoal.Predecessors;
            if (newGoal.StartDate != DateTime.MinValue)
                newRow["Start"] = newGoal.StartDate.ToShortDateString();
            newRow["Due"] = newGoal.DueDate.ToShortDateString();

            if (newGoal.StartDate != DateTime.MinValue && newGoal.StartDate >= DateTime.Today)
            {
                TimeSpan diff = newGoal.DueDate - newGoal.StartDate;
                newRow["Days Remaining"] = diff.Days;
            }
            else
            {
                TimeSpan diff = newGoal.DueDate - DateTime.Today;
                if (diff.Days > 0)
                    newRow["Days Remaining"] = diff.Days;
                else
                    newRow["Days Remaining"] = 0;
            }
            
            newRow["Priority"] = newGoal.Priority;
            newRow["LGoalID"] = lGoalID;
            SGoalTable.Rows.Add(newRow);

            if (GoalModify != null)
                GoalModify(newGoal, null);

            return true;
        }

        public bool updateSGoal(SGoal existingGoal)
        {
            updateGoal(existingGoal);
            
            LGoal lGoal = (LGoal)ProjectManager.ParentOf(existingGoal);
            if (ProjectManager.IsMember(existingGoal) && lGoal != existingGoal.LGoal)
            {
                ProjectManager.Ungroup(lGoal, existingGoal);
                ProjectManager.Group(existingGoal.LGoal, existingGoal);
            }

            string query = String.Format("UPDATE SGoal SET Start = '{0}', Due = '{1}', Priority = {2}, LGoalID = {3} WHERE ID = {4}", existingGoal.StartDate != DateTime.MinValue ? existingGoal.StartDate.ToShortDateString() : "NULL", existingGoal.DueDate.ToShortDateString(), existingGoal.Priority, existingGoal.LGoal != null ? existingGoal.LGoal.ID : 0,  existingGoal.ID);
            SQLiteCommand command = new SQLiteCommand(query, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            updatePredecessors(existingGoal);

            DataRow existingRow = SGoalTable.Select(String.Format("ID = {0}", existingGoal.ID))[0];
            existingRow["Summary"] = existingGoal.Name;
            existingRow["Complete"] = existingGoal.Complete == 1.0f;
            existingRow["Category"] = existingGoal.Category;
            existingRow["Description"] = existingGoal.Desc;
            existingRow["Predecessor"] = existingGoal.Predecessors;
            if (existingGoal.StartDate != DateTime.MinValue)
                existingRow["Start"] = existingGoal.StartDate.ToShortDateString();
            else
                existingRow["Due"] = DBNull.Value;
            existingRow["Due"] = existingGoal.DueDate.ToShortDateString();

            if (existingGoal.StartDate != DateTime.MinValue && existingGoal.StartDate >= DateTime.Today)
            {
                TimeSpan diff = existingGoal.DueDate - existingGoal.StartDate;
                existingRow["Days Remaining"] = diff.Days;
            }
            else
            {
                TimeSpan diff = existingGoal.DueDate - DateTime.Today;
                if (diff.Days > 0)
                    existingRow["Days Remaining"] = diff.Days;
                else
                    existingRow["Days Remaining"] = 0;
            }
            
            existingRow["Priority"] = existingGoal.Priority;
            existingRow["LGoalID"] = existingGoal.LGoal != null ? existingGoal.LGoal.ID : 0;

            if (GoalModify != null)
                GoalModify(existingGoal, null);

            // Ensure all start and due dates of its GTask remain to be in a valid range
            foreach (DataRow row in TaskManager.TaskTable.Select("GoalID = " + existingGoal.ID))
            {
                GTask task = (GTask)TaskManager.GTaskList[row["UID"].ToString()];
                if (existingGoal.StartDate == DateTime.MinValue && task.Todo.Start.Date < existingGoal.DueDate.AddDays(-30))
                {
                    TimeSpan gap = existingGoal.DueDate.AddDays(-30) - task.Todo.Start.Date;
                    task.Todo.Start = new DDay.iCal.iCalDateTime(existingGoal.DueDate.AddDays(-30));
                    if (task.Todo.Due.Date.AddDays(gap.Days) > existingGoal.DueDate)
                        task.Todo.Due = new DDay.iCal.iCalDateTime(existingGoal.DueDate);
                    else
                        task.Todo.Due = new DDay.iCal.iCalDateTime(task.Todo.Due.Date.AddDays(gap.Days));

                    TaskManager.updateGTask(task);
                }
                else if (existingGoal.StartDate != DateTime.MinValue && task.Todo.Start.Date < existingGoal.StartDate)
                {
                    TimeSpan gap = existingGoal.StartDate - task.Todo.Start.Date;
                    task.Todo.Start = new DDay.iCal.iCalDateTime(existingGoal.StartDate);
                    if (task.Todo.Due.Date.AddDays(gap.Days) > existingGoal.DueDate)
                        task.Todo.Due = new DDay.iCal.iCalDateTime(existingGoal.DueDate);
                    else
                        task.Todo.Due = new DDay.iCal.iCalDateTime(task.Todo.Due.Date.AddDays(gap.Days));

                    TaskManager.updateGTask(task);
                }
                else if (task.Todo.Due.Date > existingGoal.DueDate)
                {
                    TimeSpan gap = task.Todo.Due.Date - existingGoal.DueDate;
                    task.Todo.Due = new DDay.iCal.iCalDateTime(existingGoal.DueDate);
                    if (existingGoal.StartDate != DateTime.MinValue && task.Todo.Start.Date.AddDays(-gap.Days) < existingGoal.StartDate)
                        task.Todo.Start = new DDay.iCal.iCalDateTime(existingGoal.StartDate);
                    else if (existingGoal.StartDate != DateTime.MinValue && task.Todo.Start.Date.AddDays(-gap.Days) >= existingGoal.StartDate)
                        task.Todo.Start = new DDay.iCal.iCalDateTime(task.Todo.Start.Date.AddDays(-gap.Days));

                    TaskManager.updateGTask(task);
                }
            }

            return true;
        }

        public bool removeSGoal(int id)
        {
            removeGoal(id);

            string query = String.Format("DELETE FROM SGoal WHERE ID = {0}", id);
            SQLiteCommand command = new SQLiteCommand(query, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            Goal goal = GoalList[id];
            ProjectManager.Delete(goal);
            GoalList.Remove(id);

            SGoalTable.Rows.Remove(SGoalTable.Select(String.Format("ID = {0}", id))[0]);

            if (GoalModify != null)
                GoalModify(goal, null);

            return true;
        }

        private int createGoal(string summary, bool complete, string category, string desc, string predecessor)
        {
            string query = String.Format("INSERT INTO Goal (Summary, Complete, Category, Description, Predecessor) VALUES ('{0}', {1}, '{2}', '{3}', '{4}'); SELECT LAST_INSERT_ROWID();", summary, complete ? 1 : 0, category, desc, predecessor);
            SQLiteCommand command = new SQLiteCommand(query, connection);

            connection.Open();
            int id = Int32.Parse(command.ExecuteScalar().ToString());
            connection.Close();
            
            return id;
        }

        private bool updateGoal(Goal existingGoal)
        {
            string query = String.Format("UPDATE Goal SET Summary = '{0}', Complete = {1}, Category = '{2}', Description = '{3}', Predecessor = '{4}' WHERE ID = {5}", existingGoal.Name, existingGoal.Complete == 1.0f ? 1 : 0, existingGoal.Category, existingGoal.Desc, existingGoal.Predecessors, existingGoal.ID);
            SQLiteCommand command = new SQLiteCommand(query, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return true;
        }

        private bool removeGoal(int id)
        {
            string query = String.Format("DELETE FROM Goal WHERE ID = {0}", id);
            SQLiteCommand command = new SQLiteCommand(query, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return true;
        }

        private void updatePredecessors(Goal existingGoal)
        {
            List<Goal> currentPredecessors = new List<Goal>();
            foreach (Task task in  ProjectManager.DirectPrecedentsOf(existingGoal))
            {
                currentPredecessors.Add((Goal)task);
            }

            List<string> newPredecessors;
            if (!existingGoal.Predecessors.Equals(""))
                newPredecessors = new List<string>(existingGoal.Predecessors.Split(','));
            else
                newPredecessors = new List<string>();
                
            foreach (Goal goal in currentPredecessors)
            {
                if (newPredecessors.Contains(goal.ID.ToString()))
                {
                    // Keep Relation
                    newPredecessors.Remove(goal.ID.ToString());
                }
                else
                {
                    // Remove Relation
                    ProjectManager.Unrelate(goal, existingGoal);
                }
            }

            foreach (string predecessor in newPredecessors)
            {
                int id = Int32.Parse(predecessor);
                // Valid Predecessor ID
                if (GoalList.ContainsKey(id))
                {
                    // Create Relation
                    ProjectManager.Relate(GoalList[id], existingGoal);
                }
            }
        }
    }
}
