using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace MultiDesktop
{
    public class VisionManager
    {
        public SortedList<int, Vision> VisionList { get; private set; }
        public DataTable VisionTable { get; private set; }

        private SQLiteConnection connection;

        public VisionManager(SQLiteConnection connection)
        {
            this.connection = connection;
            VisionList = new SortedList<int, Vision>();

            VisionTable = new DataTable();
            VisionTable.TableName = "Vision Table";
            VisionTable.Columns.Add("ID", typeof(int));
            VisionTable.Columns.Add("Summary", typeof(string));
            VisionTable.Columns.Add("Description", typeof(string));
        }

        public void loadDatabase()
        {
            connection.Open();
            using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter("SELECT * FROM Vision", connection))
            {
                dataAdapter.Fill(VisionTable);
            }
            connection.Close();

            foreach (DataRow row in VisionTable.Rows)
            {
                int id = Int32.Parse(row["ID"].ToString());
                Vision newVision = new Vision(id);
                newVision.Summary = (string)row["Summary"];
                newVision.Desc = (string)row["Description"];
                VisionList.Add(newVision.ID, newVision);
            }
        }

        public Vision createVision(string summary, string desc)
        {
            string query = String.Format("INSERT INTO Vision(Summary, Description) VALUES('{0}', '{1}'); SELECT LAST_INSERT_ROWID();", summary, desc);
            SQLiteCommand command = new SQLiteCommand(query, connection);

            connection.Open();
            int id = Int32.Parse(command.ExecuteScalar().ToString());
            connection.Close();

            DataRow newRow = VisionTable.NewRow();
            newRow["ID"] = id;
            newRow["Summary"] = summary;
            newRow["Description"] = desc;
            VisionTable.Rows.Add(newRow);

            Vision newVision = new Vision(id);
            newVision.Summary = summary;
            newVision.Desc = desc;
            VisionList.Add(newVision.ID, newVision);
            return newVision;
        }

        public bool updateVision(Vision existingVision)
        {
            string query = String.Format("UPDATE Vision SET Summary = '{0}', Description = '{1}' WHERE ID = {2}", existingVision.Summary, existingVision.Desc, existingVision.ID);
            SQLiteCommand command = new SQLiteCommand(query, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            DataRow existingRow = VisionTable.Select(String.Format("ID = {0}", existingVision.ID))[0];
            existingRow["Summary"] = existingVision.Summary;
            existingRow["Description"] = existingVision.Desc;

            return true;
        }

        public bool removeVision(int id)
        {
            if (VisionList.ContainsKey(id))
            {
                VisionList.Remove(id);

                string query = String.Format("DELETE FROM Vision WHERE ID = {0}", id);
                SQLiteCommand command = new SQLiteCommand(query, connection);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                VisionTable.Rows.Remove(VisionTable.Select(String.Format("ID = {0}", id))[0]);

                return true;
            }
            return false;
        }
    }
}
