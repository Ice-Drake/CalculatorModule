using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        private SqlConnection connection;

        public GoalPlanner(TodoManager todoManager)
        {
            connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Goal.mdf;Integrated Security=True");
            VisionManager = new VisionManager(connection);
            TaskManager = new TaskManager(todoManager, connection);
            GoalList = new SortedList<int, Goal>();

            LGoalTable = new DataTable();
            LGoalTable.TableName = "LGoal Table";
            LGoalTable.Columns.Add("ID", typeof(string));
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
            SGoalTable.Columns.Add("ID", typeof(string));
            SGoalTable.Columns.Add("Summary", typeof(string));
            SGoalTable.Columns.Add("Complete", typeof(bool));
            SGoalTable.Columns.Add("Category", typeof(string));
            SGoalTable.Columns.Add("Description", typeof(string));
            SGoalTable.Columns.Add("Predecessor", typeof(string));
            SGoalTable.Columns.Add("Start", typeof(DateTime));
            SGoalTable.Columns.Add("Due", typeof(DateTime));
            SGoalTable.Columns.Add("Priority", typeof(int));
            SGoalTable.Columns.Add("LGoalID", typeof(int));

            ProjectManager = new ProjectManager();
        }

        public void loadDatabase()
        {
            VisionManager.loadDatabase();

            connection.Open();
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT A.*, B.* FROM Goal A LEFT JOIN LGoal B ON A.ID = B.ID", connection))
            {
                dataAdapter.Fill(LGoalTable);
            }

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT A.*, B.* FROM Goal A LEFT JOIN SGoal B ON A.ID = B.ID", connection))
            {
                dataAdapter.Fill(SGoalTable);
            }
            connection.Close();

            foreach (DataRow row in LGoalTable.Rows)
            {
                int rowID = Int32.Parse(row["ID"].ToString());
                LGoal newGoal = new LGoal(rowID, (DateTime)row["Start"]);
                newGoal.Name = (string)row["Summary"];
                newGoal.Complete = (bool)row["Complete"] ? 1.0f : 0.0f;
                newGoal.Category = (string)row["Category"];
                newGoal.Desc = (string)row["Description"];
                newGoal.Predecessors = (string)row["Predecessor"];

                if ((DateTime)row["Due"] != DateTime.MinValue)
                    newGoal.DueDate = (DateTime)row["Due"];

                newGoal.Scheme = Int32.Parse(row["Scheme"].ToString());
                newGoal.VisionID = Int32.Parse(row["VisionID"].ToString());

                GoalList.Add(newGoal.ID, newGoal);
                ProjectManager.Add(newGoal);
            }

            foreach (DataRow row in SGoalTable.Rows)
            {
                int rowID = Int32.Parse(row["ID"].ToString());
                SGoal newGoal = new SGoal(rowID, (DateTime)row["Due"]);
                newGoal.Name = (string)row["Summary"];
                newGoal.Complete = (bool)row["Complete"] ? 1.0f : 0.0f;
                newGoal.Category = (string)row["Category"];
                newGoal.Desc = (string)row["Description"];
                newGoal.Predecessors = (string)row["Predecessor"];

                if ((DateTime)row["Start"] != DateTime.MinValue)
                    newGoal.StartDate = (DateTime)row["Start"];

                newGoal.Priority = Int32.Parse(row["Priority"].ToString());

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
            predecessorTable.Columns.Add("ID", typeof(string));
            predecessorTable.Columns.Add("Summary", typeof(string));
            predecessorTable.Columns.Add("Checked", typeof(bool));

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

            SqlCommand command = new SqlCommand("INSERT INTO LGoal (ID, Start, Due, Scheme, VisionID) VALUES (@ID, @Start, @Due, @Scheme, @VisionID)", connection);

            command.Parameters.Add("@ID", SqlDbType.Int);
            command.Parameters["@ID"].Value = id;
            
            command.Parameters.Add("@Start", SqlDbType.Date);
            command.Parameters["@Start"].Value = startDate;
            
            command.Parameters.Add("@Due", SqlDbType.Date);
            command.Parameters["@Due"].Value = dueDate != DateTime.MinValue ? dueDate : (object)DBNull.Value;
            
            command.Parameters.Add("@Scheme", SqlDbType.Int);
            command.Parameters["@Scheme"].Value = scheme;
            
            command.Parameters.Add("@VisionID", SqlDbType.Int);
            command.Parameters["@VisionID"].Value = visionID;

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

            SqlCommand command = new SqlCommand("UPDATE LGoal SET Start = @Start, Due = @Due, Scheme = @Scheme, VisionID = @VisionID WHERE ID = @ID", connection);

            command.Parameters.Add("@ID", SqlDbType.Int);
            command.Parameters["@ID"].Value = existingGoal.ID;

            command.Parameters.Add("@Start", SqlDbType.Date);
            command.Parameters["@Start"].Value = existingGoal.StartDate;

            command.Parameters.Add("@Due", SqlDbType.Date);
            command.Parameters["@Due"].Value = existingGoal.DueDate != DateTime.MinValue ? existingGoal.DueDate : (object)DBNull.Value;

            command.Parameters.Add("@Scheme", SqlDbType.Int);
            command.Parameters["@Scheme"].Value = existingGoal.Scheme;

            command.Parameters.Add("@VisionID", SqlDbType.Int);
            command.Parameters["@VisionID"].Value = existingGoal.VisionID;

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
            existingRow["Scheme"] = existingGoal.Scheme;
            existingRow["VisionID"] = existingGoal.VisionID;

            if (GoalModify != null)
                GoalModify(existingGoal, null);

            return false;
        }

        public bool removeLGoal(int id)
        {
            removeGoal(id);

            SqlCommand command = new SqlCommand("DELETE FROM LGoal WHERE ID = @ID", connection);

            command.Parameters.Add("@ID", SqlDbType.Int);
            command.Parameters["@ID"].Value = id;

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

            SqlCommand command = new SqlCommand("INSERT INTO SGoal (ID, Start, Due, Priority, LGoalID) VALUES (@ID, @Start, @Due, @Priority, @LGoalID)", connection);

            command.Parameters.Add("@ID", SqlDbType.Int);
            command.Parameters["@ID"].Value = id;

            command.Parameters.Add("@Start", SqlDbType.Date);
            command.Parameters["@Start"].Value = startDate != DateTime.MinValue ? startDate : (object)DBNull.Value;

            command.Parameters.Add("@Due", SqlDbType.Date);
            command.Parameters["@Due"].Value = dueDate;

            command.Parameters.Add("@Priority", SqlDbType.Int);
            command.Parameters["@Priority"].Value = priority;

            command.Parameters.Add("@LGoalID", SqlDbType.Int);
            command.Parameters["@LGoalID"].Value = lGoalID;

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
            
            SqlCommand command = new SqlCommand("UPDATE SGoal SET Start = @Start, Due = @Due, Priority = @Priority, LGoalID = @LGoalID WHERE ID = @ID", connection);

            command.Parameters.Add("@ID", SqlDbType.Int);
            command.Parameters["@ID"].Value = existingGoal.ID;

            command.Parameters.Add("@Start", SqlDbType.Date);
            command.Parameters["@Start"].Value = existingGoal.StartDate != DateTime.MinValue ? existingGoal.StartDate : (object)DBNull.Value;
            
            command.Parameters.Add("@Due", SqlDbType.Date);
            command.Parameters["@Due"].Value = existingGoal.DueDate;
            
            command.Parameters.Add("@Priority", SqlDbType.Int);
            command.Parameters["@Priority"].Value = existingGoal.Priority;
            
            command.Parameters.Add("@LGoalID", SqlDbType.Int);
            command.Parameters["@LGoalID"].Value = existingGoal.LGoal != null ? existingGoal.LGoal.ID : 0;

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
            existingRow["Due"] = existingGoal.DueDate.ToShortDateString();
            existingRow["Priority"] = existingGoal.Priority;
            existingRow["LGoalID"] = existingGoal.LGoal != null ? existingGoal.LGoal.ID : 0;

            if (GoalModify != null)
                GoalModify(existingGoal, null);

            return true;
        }

        public bool removeSGoal(int id)
        {
            removeGoal(id);

            SqlCommand command = new SqlCommand("DELETE FROM SGoal WHERE ID = @ID", connection);

            command.Parameters.Add("@ID", SqlDbType.Int);
            command.Parameters["@ID"].Value = id;

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
            SqlCommand command = new SqlCommand("INSERT INTO Goal (Summary, Complete, Category, Description, Predecessor) VALUES (@Summary, @Complete, @Category, @Description, @Predecessor); SELECT SCOPE_IDENTITY();", connection);

            command.Parameters.Add("@Summary", SqlDbType.VarChar);
            command.Parameters["@Summary"].Value = summary;
            
            command.Parameters.Add("@Complete", SqlDbType.Bit);
            command.Parameters["@Complete"].Value = complete;
            
            command.Parameters.Add("@Category", SqlDbType.VarChar);
            command.Parameters["@Category"].Value = category;
            
            command.Parameters.Add("@Description", SqlDbType.VarChar);
            command.Parameters["@Description"].Value = desc;
            
            command.Parameters.Add("@Predecessor", SqlDbType.VarChar);
            command.Parameters["@Predecessor"].Value = predecessor;

            connection.Open();
            int id = Int32.Parse(command.ExecuteScalar().ToString());
            connection.Close();
            
            return id;
        }

        private bool updateGoal(Goal existingGoal)
        {
            SqlCommand command = new SqlCommand("UPDATE Goal SET Summary = @Summary, Complete = @Complete, Category = @Category, Description = @Description, Predecessor = @Predecessor WHERE ID = @ID", connection);

            command.Parameters.Add("@ID", SqlDbType.Int);
            command.Parameters["@ID"].Value = existingGoal.ID;
            
            command.Parameters.Add("@Summary", SqlDbType.VarChar);
            command.Parameters["@Summary"].Value = existingGoal.Name;
            
            command.Parameters.Add("@Complete", SqlDbType.Bit);
            command.Parameters["@Complete"].Value = existingGoal.Complete == 1.0f;
            
            command.Parameters.Add("@Category", SqlDbType.VarChar);
            command.Parameters["@Category"].Value = existingGoal.Category;
            
            command.Parameters.Add("@Description", SqlDbType.VarChar);
            command.Parameters["@Description"].Value = existingGoal.Desc;
            
            command.Parameters.Add("@Predecessor", SqlDbType.VarChar);
            command.Parameters["@Predecessor"].Value = existingGoal.Predecessors;

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return true;
        }

        private bool removeGoal(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Goal WHERE ID = @ID", connection);

            command.Parameters.Add("@ID", SqlDbType.Int);
            command.Parameters["@ID"].Value = id;

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
