using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DDay.iCal;

namespace MultiDesktop
{
    public class TodoPanel : MainPanel
    {
        private TodoManager controller;

        #region Component Designer variables

        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGridView assignedTodoGridView;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Button clearButton;
        private DataGridView completedTodoGridView;
        private DataGridView unassignedTodoGridView;

        #endregion
        private DataGridViewImageColumn recurrenceColumn;
        private DataGridViewTextBoxColumn nameColumn;
        private DataGridViewTextBoxColumn categoryColumn;
        private DataGridViewTextBoxColumn priorityColumn;
        private DataGridViewTextBoxColumn dueDateColumn;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewImageColumn dataGridViewImageColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewImageColumn dataGridViewImageColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn Column3;

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.assignedTodoGridView = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.unassignedTodoGridView = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.completedTodoGridView = new System.Windows.Forms.DataGridView();
            this.clearButton = new System.Windows.Forms.Button();
            this.recurrenceColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priorityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dueDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.assignedTodoGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unassignedTodoGridView)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.completedTodoGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(378, 237);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.assignedTodoGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(370, 211);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Assigned";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // assignedTodoGridView
            // 
            this.assignedTodoGridView.AllowUserToAddRows = false;
            this.assignedTodoGridView.AllowUserToDeleteRows = false;
            this.assignedTodoGridView.AllowUserToOrderColumns = true;
            this.assignedTodoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.assignedTodoGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.recurrenceColumn,
            this.nameColumn,
            this.categoryColumn,
            this.priorityColumn,
            this.dueDateColumn,
            this.Column1});
            this.assignedTodoGridView.Location = new System.Drawing.Point(6, 6);
            this.assignedTodoGridView.Name = "assignedTodoGridView";
            this.assignedTodoGridView.ReadOnly = true;
            this.assignedTodoGridView.RowHeadersVisible = false;
            this.assignedTodoGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.assignedTodoGridView.Size = new System.Drawing.Size(358, 199);
            this.assignedTodoGridView.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.unassignedTodoGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(370, 211);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Unassigned";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // unassignedTodoGridView
            // 
            this.unassignedTodoGridView.AllowUserToAddRows = false;
            this.unassignedTodoGridView.AllowUserToDeleteRows = false;
            this.unassignedTodoGridView.AllowUserToOrderColumns = true;
            this.unassignedTodoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.unassignedTodoGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn9});
            this.unassignedTodoGridView.Location = new System.Drawing.Point(45, 6);
            this.unassignedTodoGridView.Name = "unassignedTodoGridView";
            this.unassignedTodoGridView.ReadOnly = true;
            this.unassignedTodoGridView.RowHeadersVisible = false;
            this.unassignedTodoGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.unassignedTodoGridView.Size = new System.Drawing.Size(279, 199);
            this.unassignedTodoGridView.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.completedTodoGridView);
            this.tabPage3.Controls.Add(this.clearButton);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(370, 211);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Completed";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // completedTodoGridView
            // 
            this.completedTodoGridView.AllowUserToAddRows = false;
            this.completedTodoGridView.AllowUserToDeleteRows = false;
            this.completedTodoGridView.AllowUserToOrderColumns = true;
            this.completedTodoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.completedTodoGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn2,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.Column3});
            this.completedTodoGridView.Location = new System.Drawing.Point(6, 6);
            this.completedTodoGridView.Name = "completedTodoGridView";
            this.completedTodoGridView.ReadOnly = true;
            this.completedTodoGridView.RowHeadersVisible = false;
            this.completedTodoGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.completedTodoGridView.Size = new System.Drawing.Size(358, 170);
            this.completedTodoGridView.TabIndex = 4;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(147, 182);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // recurrenceColumn
            // 
            this.recurrenceColumn.DataPropertyName = "Recurrence";
            this.recurrenceColumn.HeaderText = "";
            this.recurrenceColumn.Name = "recurrenceColumn";
            this.recurrenceColumn.ReadOnly = true;
            this.recurrenceColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.recurrenceColumn.Width = 25;
            // 
            // nameColumn
            // 
            this.nameColumn.DataPropertyName = "Summary";
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            // 
            // categoryColumn
            // 
            this.categoryColumn.DataPropertyName = "Category";
            this.categoryColumn.HeaderText = "Category";
            this.categoryColumn.Name = "categoryColumn";
            this.categoryColumn.ReadOnly = true;
            this.categoryColumn.Width = 75;
            // 
            // priorityColumn
            // 
            this.priorityColumn.DataPropertyName = "Priority";
            this.priorityColumn.HeaderText = "Priority";
            this.priorityColumn.Name = "priorityColumn";
            this.priorityColumn.ReadOnly = true;
            this.priorityColumn.Width = 75;
            // 
            // dueDateColumn
            // 
            this.dueDateColumn.DataPropertyName = "DueDate";
            this.dueDateColumn.HeaderText = "Due Date";
            this.dueDateColumn.Name = "dueDateColumn";
            this.dueDateColumn.ReadOnly = true;
            this.dueDateColumn.Width = 80;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "UID";
            this.Column1.HeaderText = "UID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "Recurrence";
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 25;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Summary";
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Category";
            this.dataGridViewTextBoxColumn2.HeaderText = "Category";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 75;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Priority";
            this.dataGridViewTextBoxColumn3.HeaderText = "Priority";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 75;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "UID";
            this.dataGridViewTextBoxColumn9.HeaderText = "UID";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.DataPropertyName = "Recurrence";
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn2.Width = 25;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Summary";
            this.dataGridViewTextBoxColumn5.HeaderText = "Name";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Category";
            this.dataGridViewTextBoxColumn6.HeaderText = "Category";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 75;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Priority";
            this.dataGridViewTextBoxColumn7.HeaderText = "Priority";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 75;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "DueDate";
            this.dataGridViewTextBoxColumn8.HeaderText = "Due Date";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 80;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "UID";
            this.Column3.HeaderText = "UID";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // TodoPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(402, 261);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TodoPanel";
            this.ShowInTaskbar = false;
            this.Text = "To-do Panel";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.assignedTodoGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.unassignedTodoGridView)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.completedTodoGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public TodoPanel(TodoManager todoManager) : base("Todo Manager")
        {
            InitializeComponent();
            controller = todoManager;

            DataView assignedTodoView = new DataView();
            assignedTodoView.Table = controller.TodoTable;
            assignedTodoView.RowFilter = "Status = false AND IIF(StartDate = 'None' AND DueDate = 'None', false, true)";

            DataView unassignedTodoView = new DataView();
            unassignedTodoView.Table = controller.TodoTable;
            unassignedTodoView.RowFilter = "Status = false AND IIF(StartDate = 'None' AND DueDate = 'None', true, false)";

            DataView completedTodoView = new DataView();
            completedTodoView.Table = controller.TodoTable;
            completedTodoView.RowFilter = "Status = true";
            
            assignedTodoGridView.AutoGenerateColumns = false;
            assignedTodoGridView.DataSource = assignedTodoView;
            assignedTodoGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView_CellFormatting);
            assignedTodoGridView.CellContentDoubleClick += new DataGridViewCellEventHandler(dataGridView_CellContentDoubleClick);

            unassignedTodoGridView.AutoGenerateColumns = false;
            unassignedTodoGridView.DataSource = unassignedTodoView;
            unassignedTodoGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView_CellFormatting);
            unassignedTodoGridView.CellContentDoubleClick += new DataGridViewCellEventHandler(dataGridView_CellContentDoubleClick);

            completedTodoGridView.AutoGenerateColumns = false;
            completedTodoGridView.DataSource = completedTodoView;
            completedTodoGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView_CellFormatting);
            completedTodoGridView.CellContentDoubleClick += new DataGridViewCellEventHandler(dataGridView_CellContentDoubleClick);
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            /*DataGridView dataGridView = (DataGridView)sender;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {*/
            if (e.ColumnIndex == 3)
            {
                int priority = Int32.Parse(/*row.Cells[3].Value.ToString()*/e.Value.ToString());

                if (priority == 1)
                {
                    /*row.Cells[3].Style*/
                    e.CellStyle.ForeColor = Color.Red;
                    e.Value = "Critical";
                    e.FormattingApplied = true;
                }
                else if (priority == 2)
                {
                    e.CellStyle.ForeColor = Color.OrangeRed;
                    e.Value = "Very High";
                    e.FormattingApplied = true;
                }
                else if (priority == 3)
                {
                    e.CellStyle.ForeColor = Color.Orange;
                    e.Value = "High";
                    e.FormattingApplied = true;
                }
                else if (priority == 4)
                {
                    e.CellStyle.ForeColor = Color.Yellow;
                    e.Value = "Above Normal";
                    e.FormattingApplied = true;
                }
                else if (priority == 5)
                {
                    e.CellStyle.ForeColor = Color.Green;
                    e.Value = "Normal";
                    e.FormattingApplied = true;
                }
                else if (priority == 4 || priority == 3)
                {
                    e.CellStyle.ForeColor = Color.Teal;
                    e.Value = "Low";
                    e.FormattingApplied = true;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Blue;
                    e.Value = "Very Low";
                    e.FormattingApplied = true;
                }
            }

            //dataGridView.Update();
        }

        private void dataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            int index = dataGridView != unassignedTodoGridView ? 5 : 4;
            string UID = dataGridView.Rows[e.RowIndex].Cells[index].Value.ToString();
            TodoForm newForm = new TodoForm(controller.TodoList[UID]);
            newForm.Show();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in completedTodoGridView.Rows)
            {
                controller.removeTodo(row.Cells[5].Value.ToString());
            }
        }
    }
}
