using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DDay.iCal;
using PluginSDK;

namespace MultiDesktop
{
    public class IProjectManager
    {
        public DataTable ITaskTable { get; private set; }
        public SortedList<long, ITask> ITaskList { get; private set; }
        private List<IProjDBManager> projDBList;
        
        public IProjectManager()
        {
            ITaskList = new SortedList<long, ITask>();
            projDBList = new List<IProjDBManager>();
            
            ITaskTable = new DataTable();
            ITaskTable.TableName = "ITask Table";
            ITaskTable.Columns.Add("ID", typeof(long));
            ITaskTable.Columns.Add("Summary", typeof(string));
            ITaskTable.Columns.Add("Start", typeof(DateTime));
            ITaskTable.Columns.Add("Due", typeof(DateTime));
            ITaskTable.Columns.Add("Complete", typeof(bool));
        }

        public bool addDatabase(IProjDBManager projDBManager)
        {
            if (projDBList.Contains(projDBManager))
                return false;

            projDBManager.loadDatabase();
            projDBList.Add(projDBManager);

            ushort projDBID = (ushort)projDBList.IndexOf(projDBManager);

            foreach (uint taskID in projDBManager.ITaskList.Keys)
            {
                ITask task = projDBManager.ITaskList[taskID];
                long newTaskID = taskID + projDBID * ((long)uint.MaxValue + 1);
                ITaskList.Add(newTaskID, task);
                addITask(task, newTaskID);
            }

            projDBManager.DatabaseChanged += new ITaskHandler(projDBManager_DatabaseChanged);

            return true;
        }

        public bool completeITask(long id)
        {
            if (!ITaskList.ContainsKey(id))
                return false;

            ITaskList[id].Complete = true;

            // Find the corresponding Task row in the table
            DataRow existingRow = ITaskTable.Select(String.Format("UID = {0}", id))[0];
            existingRow["Complete"] = true;

            return true;
        }

        // Add ITask to the ITaskTable
        private void addITask(ITask newTask, long id)
        {
            DataRow newRow = ITaskTable.NewRow();
            newRow["ID"] = id;
            newRow["Summary"] = newTask.Summary;
            newRow["Start"] = newTask.StartDate.ToShortDateString();
            newRow["Due"] = newTask.DueDate.ToShortDateString();
            newRow["Complete"] = newTask.Complete;
            ITaskTable.Rows.Add(newRow);
        }

        private void projDBManager_DatabaseChanged(IProjDBManager sender, ITask task, StatusArgs e)
        {
            if (e.Status == ITaskStatus.Added)
            {
                uint taskID = sender.ITaskList.Keys[sender.ITaskList.IndexOfValue(task)];
                long id = taskID + projDBList.IndexOf(sender) * ((long)uint.MaxValue + 1);
                ITaskList.Add(id, task);
                addITask(task, id);
            }
            else
            {
                long id = ITaskList.Keys[ITaskList.IndexOfValue(task)];

                // Find the corresponding Task row in the table
                int rowID = ITaskTable.Rows.IndexOf(ITaskTable.Select(String.Format("ID = {0}", id))[0]);

                if (e.Status == ITaskStatus.Removed)
                {
                    ITaskList.Remove(id);
                    ITaskTable.Rows.RemoveAt(rowID);
                }
                else //if (e.Status == ITaskStatus.Modified)
                {
                    DataRow existingRow = ITaskTable.Rows[rowID];
                    existingRow["Summary"] = task.Summary;
                    existingRow["Start"] = task.StartDate.ToShortDateString();
                    existingRow["Due"] = task.DueDate.ToShortDateString();
                    existingRow["Complete"] = task.Complete;
                }
            }
        }
    }
}