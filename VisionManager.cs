using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MultiDesktop
{
    public class VisionManager
    {
        public SortedList<int, Vision> VisionList { get; private set; }
        public DataTable VisionTable { get; private set; }

        private SqlConnection connection;

        public VisionManager(SqlConnection connection)
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
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Vision", connection))
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
            SqlCommand command = new SqlCommand("INSERT INTO Vision(Summary, Description) VALUES(@Summary, @Description); SELECT SCOPE_IDENTITY();", connection);

            command.Parameters.Add("@Summary", SqlDbType.VarChar);
            command.Parameters["@Summary"].Value = summary;
            
            command.Parameters.Add("@Description", SqlDbType.VarChar);
            command.Parameters["@Description"].Value = desc;

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
            SqlCommand command = new SqlCommand("UPDATE Vision SET Summary = @Summary, Description = @Description WHERE ID = @ID", connection);

            command.Parameters.Add("@ID", SqlDbType.Int);
            command.Parameters["@ID"].Value = existingVision.ID;

            command.Parameters.Add("@Summary", SqlDbType.VarChar);
            command.Parameters["@Summary"].Value = existingVision.Summary;

            command.Parameters.Add("@Description", SqlDbType.VarChar);
            command.Parameters["@Description"].Value = existingVision.Desc;

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

                SqlCommand command = new SqlCommand("DELETE FROM Vision WHERE ID = @ID", connection);

                command.Parameters.Add("@ID", SqlDbType.Int);
                command.Parameters["@ID"].Value = id;

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
