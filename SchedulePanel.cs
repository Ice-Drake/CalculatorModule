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
    public class SchedulePanel : Form
    {
        private List<Library.DateItem> eventList;
        private List<PluginSDK.ITask> taskList;
        private List<ITodo> todoList;

        #region Component Designer variables

        private GroupBox eventBox;
        private GroupBox taskBox;
        private CheckedListBox taskListBox;
        private GroupBox todoBox;
        private CheckedListBox todoListBox;
        private DataGridView eventGridView;
        private DataGridViewTextBoxColumn eventGridColumn;
        private IContainer components = null;

        #endregion

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        

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

        #region Disable Close Button

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams param = base.CreateParams;
                param.ClassStyle = param.ClassStyle | 0x200;
                return param;
            }
        }

        #endregion

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.todoBox = new System.Windows.Forms.GroupBox();
            this.todoListBox = new System.Windows.Forms.CheckedListBox();
            this.eventBox = new System.Windows.Forms.GroupBox();
            this.eventGridView = new System.Windows.Forms.DataGridView();
            this.eventGridColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskBox = new System.Windows.Forms.GroupBox();
            this.taskListBox = new System.Windows.Forms.CheckedListBox();
            this.todoBox.SuspendLayout();
            this.eventBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventGridView)).BeginInit();
            this.taskBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // todoBox
            // 
            this.todoBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.todoBox.BackColor = System.Drawing.Color.Transparent;
            this.todoBox.Controls.Add(this.todoListBox);
            this.todoBox.Location = new System.Drawing.Point(3, 232);
            this.todoBox.Name = "todoBox";
            this.todoBox.Size = new System.Drawing.Size(193, 116);
            this.todoBox.TabIndex = 1;
            this.todoBox.TabStop = false;
            this.todoBox.Text = "To-dos";
            // 
            // todoListBox
            // 
            this.todoListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.todoListBox.CheckOnClick = true;
            this.todoListBox.FormattingEnabled = true;
            this.todoListBox.Items.AddRange(new object[] {
            "Clean Room"});
            this.todoListBox.Location = new System.Drawing.Point(6, 15);
            this.todoListBox.Name = "todoListBox";
            this.todoListBox.Size = new System.Drawing.Size(181, 94);
            this.todoListBox.TabIndex = 0;
            this.todoListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.todoListBox_ItemCheck);
            // 
            // eventBox
            // 
            this.eventBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.eventBox.BackColor = System.Drawing.Color.Transparent;
            this.eventBox.Controls.Add(this.eventGridView);
            this.eventBox.Location = new System.Drawing.Point(3, 7);
            this.eventBox.Name = "eventBox";
            this.eventBox.Size = new System.Drawing.Size(193, 90);
            this.eventBox.TabIndex = 0;
            this.eventBox.TabStop = false;
            this.eventBox.Text = "Events";
            // 
            // eventGridView
            // 
            this.eventGridView.AllowUserToAddRows = false;
            this.eventGridView.AllowUserToDeleteRows = false;
            this.eventGridView.AllowUserToResizeColumns = false;
            this.eventGridView.AllowUserToResizeRows = false;
            this.eventGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.eventGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventGridView.ColumnHeadersVisible = false;
            this.eventGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eventGridColumn});
            this.eventGridView.Location = new System.Drawing.Point(6, 15);
            this.eventGridView.Name = "eventGridView";
            this.eventGridView.RowHeadersVisible = false;
            this.eventGridView.RowTemplate.Height = 18;
            this.eventGridView.Size = new System.Drawing.Size(181, 69);
            this.eventGridView.TabIndex = 3;
            this.eventGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.eventGridView_CellContentDoubleClick);
            // 
            // eventGridColumn
            // 
            this.eventGridColumn.HeaderText = "";
            this.eventGridColumn.Name = "eventGridColumn";
            this.eventGridColumn.ReadOnly = true;
            this.eventGridColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.eventGridColumn.Width = 178;
            // 
            // taskBox
            // 
            this.taskBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.taskBox.BackColor = System.Drawing.Color.Transparent;
            this.taskBox.Controls.Add(this.taskListBox);
            this.taskBox.Location = new System.Drawing.Point(3, 103);
            this.taskBox.Name = "taskBox";
            this.taskBox.Size = new System.Drawing.Size(193, 123);
            this.taskBox.TabIndex = 2;
            this.taskBox.TabStop = false;
            this.taskBox.Text = "Tasks";
            // 
            // taskListBox
            // 
            this.taskListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.taskListBox.CheckOnClick = true;
            this.taskListBox.FormattingEnabled = true;
            this.taskListBox.Items.AddRange(new object[] {
            "Implement MultiDesktop"});
            this.taskListBox.Location = new System.Drawing.Point(6, 19);
            this.taskListBox.Name = "taskListBox";
            this.taskListBox.Size = new System.Drawing.Size(181, 94);
            this.taskListBox.TabIndex = 0;
            this.taskListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.taskListBox_ItemCheck);
            // 
            // SchedulePanel
            // 
            this.ClientSize = new System.Drawing.Size(197, 351);
            this.Controls.Add(this.taskBox);
            this.Controls.Add(this.todoBox);
            this.Controls.Add(this.eventBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SchedulePanel";
            this.ShowInTaskbar = false;
            this.Text = "Schedule";
            this.todoBox.ResumeLayout(false);
            this.eventBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eventGridView)).EndInit();
            this.taskBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public SchedulePanel()
        {
            InitializeComponent();
            eventList = new List<Library.DateItem>();
            taskList = new List<PluginSDK.ITask>();
            todoList = new List<ITodo>();
        }

        public void Update(DateTime date)
        {
            Text = "Schedule for " + date.ToShortDateString();

            eventGridView.Rows.Clear();
            for (int i = 0; i < eventList.Count; i++)
            {
                eventGridView.Rows.Add();
                eventGridView.Rows[i].Cells[0].Value = eventList[i].Event.Summary;
            }

            if (taskList.Count != 0)
            {
                if (!this.Controls.Contains(this.taskBox))
                {
                    this.Controls.Add(this.taskBox);
                    this.todoBox.Location = new System.Drawing.Point(3, 232);
                    this.todoBox.Size = new System.Drawing.Size(193, 116);
                }
                taskListBox.Items.Clear();
                for (int j = 0; j < taskList.Count; j++)
                {
                    taskListBox.Items.Add(taskList[j].Name);
                }
            }
            else
            {
                if (this.Controls.Contains(this.taskBox))
                {
                    this.Controls.Remove(this.taskBox);
                    this.todoBox.Location = new System.Drawing.Point(3, 103);
                    this.todoBox.Size = new System.Drawing.Size(193, 236);
                }
            }

            todoListBox.Items.Clear();
            for (int i = 0; i < todoList.Count; i++)
            {
                todoListBox.Items.Add(todoList[i].Summary);
            }
        }

        public List<Library.DateItem> EventList
        {
            get
            {
                return eventList;
            }
        }

        public List<ITodo> TodoList
        {
            get
            {
                return todoList;
            }
        }

        public List<PluginSDK.ITask> Tasks
        {
            get
            {
                return taskList;
            }
        }

        public event EventHandler<DateItemArgs> EventDoubleClick;

        public event EventHandler<TodoArgs> AddTodo;

        private void eventGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (EventDoubleClick != null)
                EventDoubleClick(this, new DateItemArgs(eventList[e.RowIndex]));
        }

        private void todoListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                ITodo oldTodo = todoList[e.Index];
                oldTodo.Status = TodoStatus.Completed;

                if (oldTodo.RecurrenceRules.Count > 0)
                {
                    if (oldTodo.Due.Date.Equals(oldTodo.Start.Date))
                        oldTodo.Duration = TimeSpan.FromHours(1);
                    else
                        oldTodo.Duration = oldTodo.Due.Date - oldTodo.Start.Date;
                    IList<Occurrence> list = oldTodo.GetOccurrences(oldTodo.Start.Date.AddDays(1), oldTodo.Start.Date.AddYears(10));
                    if (list.Count > 0)
                    {
                        ITodo newTodo = oldTodo.Copy<ITodo>();
                        oldTodo.RecurrenceRules.Clear();
                        oldTodo.Calendar.AddChild(newTodo);
                        if (newTodo.RecurrenceRules[0].Count > 0)
                            newTodo.RecurrenceRules[0].Count--;
                        newTodo.Start = list[0].Period.StartTime;
                        newTodo.Due = list[0].Period.EndTime;
                        newTodo.Duration = newTodo.Due.Date - newTodo.Start.Date;
                        newTodo.Status = TodoStatus.NeedsAction;
                        if (AddTodo != null)
                            AddTodo(this, new TodoArgs(newTodo));
                    }
                }
                
                todoListBox.Items.Clear();
                todoList.Remove(oldTodo);
                for (int i = 0; i < todoList.Count; i++)
                {
                    todoListBox.Items.Add(todoList[i].Summary);
                }
            }
        }


        private void taskListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                taskList[e.Index].Check();
            }
        }
    }
}
