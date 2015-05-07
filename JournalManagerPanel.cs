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
    public class JournalManagerPanel : MainPanel
    {
        private CalendarManager controller;

        #region Component Designer variables

        private DataGridView journalGridView;
        private DataGridViewTextBoxColumn nameColumn;
        private DataGridViewCheckBoxColumn privateColumn;
        private DataGridViewTextBoxColumn calendarColumn;
        private DataGridViewTextBoxColumn idColumn;

        #endregion

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
            this.journalGridView = new System.Windows.Forms.DataGridView();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.privateColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.calendarColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.journalGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // journalGridView
            // 
            this.journalGridView.AllowUserToAddRows = false;
            this.journalGridView.AllowUserToDeleteRows = false;
            this.journalGridView.AllowUserToOrderColumns = true;
            this.journalGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.journalGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn,
            this.privateColumn,
            this.calendarColumn,
            this.idColumn});
            this.journalGridView.Location = new System.Drawing.Point(12, 12);
            this.journalGridView.Name = "journalGridView";
            this.journalGridView.ReadOnly = true;
            this.journalGridView.RowHeadersVisible = false;
            this.journalGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.journalGridView.Size = new System.Drawing.Size(279, 199);
            this.journalGridView.TabIndex = 1;
            // 
            // nameColumn
            // 
            this.nameColumn.DataPropertyName = "Name";
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            this.nameColumn.Width = 150;
            // 
            // privateColumn
            // 
            this.privateColumn.DataPropertyName = "Private";
            this.privateColumn.HeaderText = "Private";
            this.privateColumn.Name = "privateColumn";
            this.privateColumn.ReadOnly = true;
            this.privateColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.privateColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.privateColumn.Width = 50;
            // 
            // calendarColumn
            // 
            this.calendarColumn.DataPropertyName = "CalendarID";
            this.calendarColumn.HeaderText = "Calendar";
            this.calendarColumn.Name = "calendarColumn";
            this.calendarColumn.ReadOnly = true;
            this.calendarColumn.Width = 75;
            // 
            // idColumn
            // 
            this.idColumn.DataPropertyName = "ID";
            this.idColumn.HeaderText = "ID";
            this.idColumn.Name = "idColumn";
            this.idColumn.ReadOnly = true;
            this.idColumn.Visible = false;
            // 
            // JournalManagerPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(303, 223);
            this.Controls.Add(this.journalGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JournalManagerPanel";
            this.ShowInTaskbar = false;
            this.Text = "Journal Manager Panel";
            ((System.ComponentModel.ISupportInitialize)(this.journalGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public JournalManagerPanel(CalendarManager calendarManager) : base("Journal Manager")
        {
            InitializeComponent();
            controller = calendarManager;
            
            journalGridView.AutoGenerateColumns = false;
            journalGridView.DataSource = controller.JournalManager.JournalTable;
            journalGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView_CellFormatting);
            journalGridView.CellContentDoubleClick += new DataGridViewCellEventHandler(dataGridView_CellContentDoubleClick);
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                int calendarID = Int32.Parse(e.Value.ToString());
                e.Value = controller.CalendarList[calendarID].Name;
                e.FormattingApplied = true;
            }
        }

        private void dataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Int32.Parse(journalGridView.Rows[e.RowIndex].Cells[3].Value.ToString());

            JournalBookForm newForm = new JournalBookForm(controller.JournalManager.JournalList[id]);
            newForm.Show();
        }
    }
}
