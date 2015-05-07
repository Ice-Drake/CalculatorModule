using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace MultiDesktop
{
    public class SchedulerPanel : Form
    {
        private static SchedulerPanel schedulerPanel;
        private List<Schedule> scheduleList;
        private string filename;
        private Schedule currentSchedule;
        
        private DataGridView scheduleGridView;
        private DataGridView summaryGridView;
        private ListBox activityListBox;
        private GroupBox scheduleBox;
        private GroupBox summaryBox;
        private GroupBox activityBox;
        private Button newButton;
        private Button loadButton;
        private Button saveButton;
        private Button saveAsButton;
        private GroupBox controlBox;
        private ComboBox scheduleComboBox;
        private Label wakeLabel;
        private Label sleepLabel;
        private DateTimePicker wakeTimePicker;
        private DateTimePicker sleepTimePicker;
        private SortedList activityList;
        private DataGridViewTextBoxColumn TimeColumn;
        private DataGridViewTextBoxColumn SundayColumn;
        private DataGridViewTextBoxColumn MondayColumn;
        private DataGridViewTextBoxColumn TuesdayColumn;
        private DataGridViewTextBoxColumn WednesdayColumn;
        private DataGridViewTextBoxColumn ThursdayColumn;
        private DataGridViewTextBoxColumn FridayColumn;
        private DataGridViewTextBoxColumn SaturdayColumn;
        private DataGridViewTextBoxColumn CategoryColumn;
        private DataGridViewTextBoxColumn SunColumn;
        private DataGridViewTextBoxColumn MonColumn;
        private DataGridViewTextBoxColumn TueColumn;
        private DataGridViewTextBoxColumn WedColumn;
        private DataGridViewTextBoxColumn ThuColumn;
        private DataGridViewTextBoxColumn FriColumn;
        private DataGridViewTextBoxColumn SatColumn;
        private DataGridViewTextBoxColumn TotalColumn;
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.scheduleGridView = new System.Windows.Forms.DataGridView();
            this.summaryGridView = new System.Windows.Forms.DataGridView();
            this.activityListBox = new System.Windows.Forms.ListBox();
            this.scheduleBox = new System.Windows.Forms.GroupBox();
            this.summaryBox = new System.Windows.Forms.GroupBox();
            this.activityBox = new System.Windows.Forms.GroupBox();
            this.newButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.saveAsButton = new System.Windows.Forms.Button();
            this.controlBox = new System.Windows.Forms.GroupBox();
            this.scheduleComboBox = new System.Windows.Forms.ComboBox();
            this.wakeLabel = new System.Windows.Forms.Label();
            this.sleepLabel = new System.Windows.Forms.Label();
            this.wakeTimePicker = new System.Windows.Forms.DateTimePicker();
            this.sleepTimePicker = new System.Windows.Forms.DateTimePicker();
            this.TimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SundayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MondayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TuesdayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WednesdayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThursdayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FridayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaturdayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SunColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThuColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FriColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SatColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.summaryGridView)).BeginInit();
            this.scheduleBox.SuspendLayout();
            this.summaryBox.SuspendLayout();
            this.activityBox.SuspendLayout();
            this.controlBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // scheduleGridView
            // 
            this.scheduleGridView.AllowDrop = true;
            this.scheduleGridView.AllowUserToAddRows = false;
            this.scheduleGridView.AllowUserToDeleteRows = false;
            this.scheduleGridView.AllowUserToResizeColumns = false;
            this.scheduleGridView.AllowUserToResizeRows = false;
            this.scheduleGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.scheduleGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TimeColumn,
            this.SundayColumn,
            this.MondayColumn,
            this.TuesdayColumn,
            this.WednesdayColumn,
            this.ThursdayColumn,
            this.FridayColumn,
            this.SaturdayColumn});
            this.scheduleGridView.Location = new System.Drawing.Point(6, 19);
            this.scheduleGridView.MultiSelect = false;
            this.scheduleGridView.Name = "scheduleGridView";
            this.scheduleGridView.RowHeadersVisible = false;
            this.scheduleGridView.Size = new System.Drawing.Size(603, 173);
            this.scheduleGridView.TabIndex = 0;
            this.scheduleGridView.DragEnter += new System.Windows.Forms.DragEventHandler(this.scheduleGridView_DragEnter);
            this.scheduleGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.scheduleGridView_KeyDown);
            this.scheduleGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.scheduleGridView_DragDrop);
            // 
            // summaryGridView
            // 
            this.summaryGridView.AllowUserToAddRows = false;
            this.summaryGridView.AllowUserToDeleteRows = false;
            this.summaryGridView.AllowUserToResizeColumns = false;
            this.summaryGridView.AllowUserToResizeRows = false;
            this.summaryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.summaryGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CategoryColumn,
            this.SunColumn,
            this.MonColumn,
            this.TueColumn,
            this.WedColumn,
            this.ThuColumn,
            this.FriColumn,
            this.SatColumn,
            this.TotalColumn});
            this.summaryGridView.Location = new System.Drawing.Point(6, 19);
            this.summaryGridView.MultiSelect = false;
            this.summaryGridView.Name = "summaryGridView";
            this.summaryGridView.RowHeadersVisible = false;
            this.summaryGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.summaryGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.summaryGridView.Size = new System.Drawing.Size(423, 220);
            this.summaryGridView.TabIndex = 1;
            // 
            // activityListBox
            // 
            this.activityListBox.FormattingEnabled = true;
            this.activityListBox.Location = new System.Drawing.Point(6, 19);
            this.activityListBox.Name = "activityListBox";
            this.activityListBox.Size = new System.Drawing.Size(162, 225);
            this.activityListBox.TabIndex = 2;
            this.activityListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.activityListBox_MouseDown);
            // 
            // scheduleBox
            // 
            this.scheduleBox.Controls.Add(this.scheduleGridView);
            this.scheduleBox.Location = new System.Drawing.Point(12, 12);
            this.scheduleBox.Name = "scheduleBox";
            this.scheduleBox.Size = new System.Drawing.Size(615, 198);
            this.scheduleBox.TabIndex = 3;
            this.scheduleBox.TabStop = false;
            this.scheduleBox.Text = "Schedule";
            // 
            // summaryBox
            // 
            this.summaryBox.Controls.Add(this.summaryGridView);
            this.summaryBox.Location = new System.Drawing.Point(12, 216);
            this.summaryBox.Name = "summaryBox";
            this.summaryBox.Size = new System.Drawing.Size(435, 245);
            this.summaryBox.TabIndex = 4;
            this.summaryBox.TabStop = false;
            this.summaryBox.Text = "Summary";
            // 
            // activityBox
            // 
            this.activityBox.Controls.Add(this.activityListBox);
            this.activityBox.Location = new System.Drawing.Point(453, 216);
            this.activityBox.Name = "activityBox";
            this.activityBox.Size = new System.Drawing.Size(174, 250);
            this.activityBox.TabIndex = 5;
            this.activityBox.TabStop = false;
            this.activityBox.Text = "Activity";
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(6, 19);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(75, 23);
            this.newButton.TabIndex = 6;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(87, 19);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 7;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(168, 19);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // saveAsButton
            // 
            this.saveAsButton.Location = new System.Drawing.Point(249, 19);
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(75, 23);
            this.saveAsButton.TabIndex = 9;
            this.saveAsButton.Text = "Save As...";
            this.saveAsButton.UseVisualStyleBackColor = true;
            // 
            // controlBox
            // 
            this.controlBox.Controls.Add(this.scheduleComboBox);
            this.controlBox.Controls.Add(this.newButton);
            this.controlBox.Controls.Add(this.saveAsButton);
            this.controlBox.Controls.Add(this.loadButton);
            this.controlBox.Controls.Add(this.saveButton);
            this.controlBox.Location = new System.Drawing.Point(12, 467);
            this.controlBox.Name = "controlBox";
            this.controlBox.Size = new System.Drawing.Size(435, 48);
            this.controlBox.TabIndex = 10;
            this.controlBox.TabStop = false;
            this.controlBox.Text = "Control";
            // 
            // scheduleComboBox
            // 
            this.scheduleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scheduleComboBox.FormattingEnabled = true;
            this.scheduleComboBox.Location = new System.Drawing.Point(330, 21);
            this.scheduleComboBox.Name = "scheduleComboBox";
            this.scheduleComboBox.Size = new System.Drawing.Size(99, 21);
            this.scheduleComboBox.TabIndex = 10;
            this.scheduleComboBox.SelectedIndexChanged += new System.EventHandler(this.scheduleComboBox_SelectedIndexChanged);
            // 
            // wakeLabel
            // 
            this.wakeLabel.AutoSize = true;
            this.wakeLabel.Location = new System.Drawing.Point(458, 475);
            this.wakeLabel.Name = "wakeLabel";
            this.wakeLabel.Size = new System.Drawing.Size(62, 13);
            this.wakeLabel.TabIndex = 11;
            this.wakeLabel.Text = "Wake Time";
            // 
            // sleepLabel
            // 
            this.sleepLabel.AutoSize = true;
            this.sleepLabel.Location = new System.Drawing.Point(458, 501);
            this.sleepLabel.Name = "sleepLabel";
            this.sleepLabel.Size = new System.Drawing.Size(60, 13);
            this.sleepLabel.TabIndex = 12;
            this.sleepLabel.Text = "Sleep Time";
            // 
            // wakeTimePicker
            // 
            this.wakeTimePicker.Enabled = false;
            this.wakeTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.wakeTimePicker.Location = new System.Drawing.Point(524, 472);
            this.wakeTimePicker.Name = "wakeTimePicker";
            this.wakeTimePicker.Size = new System.Drawing.Size(103, 20);
            this.wakeTimePicker.TabIndex = 13;
            this.wakeTimePicker.Value = new System.DateTime(1753, 1, 1, 8, 0, 0, 0);
            // 
            // sleepTimePicker
            // 
            this.sleepTimePicker.Enabled = false;
            this.sleepTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.sleepTimePicker.Location = new System.Drawing.Point(524, 498);
            this.sleepTimePicker.Name = "sleepTimePicker";
            this.sleepTimePicker.Size = new System.Drawing.Size(103, 20);
            this.sleepTimePicker.TabIndex = 14;
            this.sleepTimePicker.Value = new System.DateTime(1753, 1, 2, 0, 0, 0, 0);
            // 
            // TimeColumn
            // 
            this.TimeColumn.DataPropertyName = "Time";
            dataGridViewCellStyle2.Format = "t";
            dataGridViewCellStyle2.NullValue = null;
            this.TimeColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.TimeColumn.DividerWidth = 2;
            this.TimeColumn.HeaderText = "Time";
            this.TimeColumn.Name = "TimeColumn";
            this.TimeColumn.ReadOnly = true;
            // 
            // SundayColumn
            // 
            this.SundayColumn.DataPropertyName = "Sunday";
            this.SundayColumn.HeaderText = "Sunday";
            this.SundayColumn.Name = "SundayColumn";
            this.SundayColumn.ReadOnly = true;
            // 
            // MondayColumn
            // 
            this.MondayColumn.DataPropertyName = "Monday";
            this.MondayColumn.HeaderText = "Monday";
            this.MondayColumn.Name = "MondayColumn";
            this.MondayColumn.ReadOnly = true;
            // 
            // TuesdayColumn
            // 
            this.TuesdayColumn.DataPropertyName = "Tuesday";
            this.TuesdayColumn.HeaderText = "Tuesday";
            this.TuesdayColumn.Name = "TuesdayColumn";
            this.TuesdayColumn.ReadOnly = true;
            // 
            // WednesdayColumn
            // 
            this.WednesdayColumn.DataPropertyName = "Wednesday";
            this.WednesdayColumn.HeaderText = "Wednesday";
            this.WednesdayColumn.Name = "WednesdayColumn";
            this.WednesdayColumn.ReadOnly = true;
            // 
            // ThursdayColumn
            // 
            this.ThursdayColumn.DataPropertyName = "Thursday";
            this.ThursdayColumn.HeaderText = "Thursday";
            this.ThursdayColumn.Name = "ThursdayColumn";
            this.ThursdayColumn.ReadOnly = true;
            // 
            // FridayColumn
            // 
            this.FridayColumn.DataPropertyName = "Friday";
            this.FridayColumn.HeaderText = "Friday";
            this.FridayColumn.Name = "FridayColumn";
            this.FridayColumn.ReadOnly = true;
            // 
            // SaturdayColumn
            // 
            this.SaturdayColumn.DataPropertyName = "Saturday";
            this.SaturdayColumn.HeaderText = "Saturday";
            this.SaturdayColumn.Name = "SaturdayColumn";
            this.SaturdayColumn.ReadOnly = true;
            // 
            // CategoryColumn
            // 
            this.CategoryColumn.DataPropertyName = "Category";
            this.CategoryColumn.HeaderText = "";
            this.CategoryColumn.Name = "CategoryColumn";
            this.CategoryColumn.ReadOnly = true;
            // 
            // SunColumn
            // 
            this.SunColumn.DataPropertyName = "Sunday";
            this.SunColumn.HeaderText = "Sun";
            this.SunColumn.Name = "SunColumn";
            this.SunColumn.ReadOnly = true;
            this.SunColumn.Width = 40;
            // 
            // MonColumn
            // 
            this.MonColumn.DataPropertyName = "Monday";
            this.MonColumn.HeaderText = "Mon";
            this.MonColumn.Name = "MonColumn";
            this.MonColumn.ReadOnly = true;
            this.MonColumn.Width = 40;
            // 
            // TueColumn
            // 
            this.TueColumn.DataPropertyName = "Tuesday";
            this.TueColumn.HeaderText = "Tue";
            this.TueColumn.Name = "TueColumn";
            this.TueColumn.ReadOnly = true;
            this.TueColumn.Width = 40;
            // 
            // WedColumn
            // 
            this.WedColumn.DataPropertyName = "Wednesday";
            this.WedColumn.HeaderText = "Wed";
            this.WedColumn.Name = "WedColumn";
            this.WedColumn.ReadOnly = true;
            this.WedColumn.Width = 40;
            // 
            // ThuColumn
            // 
            this.ThuColumn.DataPropertyName = "Thursday";
            this.ThuColumn.HeaderText = "Thu";
            this.ThuColumn.Name = "ThuColumn";
            this.ThuColumn.ReadOnly = true;
            this.ThuColumn.Width = 40;
            // 
            // FriColumn
            // 
            this.FriColumn.DataPropertyName = "Friday";
            this.FriColumn.HeaderText = "Fri";
            this.FriColumn.Name = "FriColumn";
            this.FriColumn.ReadOnly = true;
            this.FriColumn.Width = 40;
            // 
            // SatColumn
            // 
            this.SatColumn.DataPropertyName = "Saturday";
            this.SatColumn.HeaderText = "Sat";
            this.SatColumn.Name = "SatColumn";
            this.SatColumn.ReadOnly = true;
            this.SatColumn.Width = 40;
            // 
            // TotalColumn
            // 
            this.TotalColumn.DataPropertyName = "Total";
            this.TotalColumn.HeaderText = "Total";
            this.TotalColumn.Name = "TotalColumn";
            this.TotalColumn.ReadOnly = true;
            this.TotalColumn.Width = 40;
            // 
            // SchedulerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 527);
            this.Controls.Add(this.sleepTimePicker);
            this.Controls.Add(this.wakeTimePicker);
            this.Controls.Add(this.sleepLabel);
            this.Controls.Add(this.wakeLabel);
            this.Controls.Add(this.controlBox);
            this.Controls.Add(this.activityBox);
            this.Controls.Add(this.summaryBox);
            this.Controls.Add(this.scheduleBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SchedulerPanel";
            this.ShowInTaskbar = false;
            this.Text = "Scheduler Panel";
            ((System.ComponentModel.ISupportInitialize)(this.scheduleGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.summaryGridView)).EndInit();
            this.scheduleBox.ResumeLayout(false);
            this.summaryBox.ResumeLayout(false);
            this.activityBox.ResumeLayout(false);
            this.controlBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SchedulerPanel()
        {
            InitializeComponent();

            activityList = new SortedList();
            foreach (Category category in Setting.CategoryList)
            {
                if (category.Name != "Contact" && category.Name != "Habits")
                {
                    activityList.Add(category.Name, category);
                    activityListBox.Items.Add(category.Name);
                }

                if (category.Subcategories.Count != 0)
                {
                    foreach (Subcategory subcategory in category.Subcategories)
                    {
                        activityList.Add(subcategory.Name, subcategory);
                        activityListBox.Items.Add(subcategory.Name);
                    }
                }
            }

            filename = "Schedule.xml";
            initializeSchedule();
            
            foreach (Schedule schedule in scheduleList)
            {
                scheduleComboBox.Items.Add(schedule.Name);
            }

            scheduleGridView.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(scheduleGridView_DataBindingComplete);
        }

        public static void initialize()
        {
            if (schedulerPanel == null)
                schedulerPanel = new SchedulerPanel();
        }

        public static Form Panel
        {
            get
            {
                if (schedulerPanel != null)
                    return schedulerPanel;
                else
                    return null;
            }
        }

        private void initializeSchedule()
        {
            scheduleList = new List<Schedule>();

            // Iterate on the node set
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filename);
                XmlNodeList schedules = doc.SelectNodes("/configuration/schedules/schedule");
                
                foreach (XmlNode node in schedules)
                {
                    DateTime wakeTime = DateTime.Parse(node.Attributes["wake"].Value);
                    DateTime sleepTime = DateTime.Parse(node.Attributes["sleep"].Value);
                    Schedule newSchedule = new Schedule(wakeTime, sleepTime, node.Attributes["name"].Value);
                    SortedList<DateTime, DataRow> rowList = new SortedList<DateTime, DataRow>();

                    foreach (XmlNode dayNode in node.ChildNodes)
                    {
                        foreach (XmlNode timeNode in dayNode.ChildNodes)
                        {
                            DateTime from = DateTime.Parse(timeNode.Attributes["from"].Value);
                            DateTime to = DateTime.Parse(timeNode.Attributes["to"].Value);
                            int i = 0;
                            while (from.AddMinutes(i * 30) < to)
                            {
                                DataRow row;
                                DateTime key = from.AddMinutes(i * 30);
                                if (rowList.ContainsKey(key))
                                {
                                    row = rowList[key];
                                }
                                else
                                {
                                    row = newSchedule.Table.NewRow();
                                    row["Time"] = key;
                                    rowList.Add(key, row);
                                }
                                string activity = timeNode.Attributes["activity"].Value;
                                string day = dayNode.Attributes["name"].Value;
                                row[day] = activity;
                                int index;

                                if (activityList[activity].GetType() == typeof(Category))
                                {
                                    index = Setting.CategoryList.IndexOf((Category)activityList[activity]);
                                }
                                else
                                {
                                    index = Setting.CategoryList.IndexOf(((Subcategory)activityList[activity]).Category);
                                }

                                newSchedule.incrementSummaryPoint(index, day);
                                i++;
                            }
                        }
                    }

                    for (int i = 0; wakeTime.AddMinutes(i * 30) < sleepTime; i++)
                    {
                        DateTime key = wakeTime.AddMinutes(i * 30);
                        if (rowList.ContainsKey(key))
                            newSchedule.Table.Rows.Add(rowList[key]);
                        else
                        {
                            DataRow row = newSchedule.Table.NewRow();
                            row["Time"] = wakeTime.AddMinutes(i * 30);
                            newSchedule.Table.Rows.Add(row);
                        }
                    }



                    scheduleList.Add(newSchedule);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static List<Schedule> ScheduleList
        {
            get
            {
                if (schedulerPanel != null)
                    return schedulerPanel.scheduleList;
                else
                    return null;
            }
        }

        public static SortedList ActivityList
        {
            get
            {
                if (schedulerPanel != null)
                    return schedulerPanel.activityList;
                else
                    return null;
            }
        }

        public static void fillSchedule(ComboBox comboBox)
        {
            if (schedulerPanel != null)
            {
                foreach (Schedule schedule in schedulerPanel.scheduleList)
                {
                    comboBox.Items.Add(schedule.Name);
                }
            }
        }

        private void load(Schedule s)
        {
            currentSchedule = s;
            wakeTimePicker.Value = s.WakeTime;
            sleepTimePicker.Value = s.SleepTime;
            scheduleGridView.DataSource = s.Table;
            summaryGridView.DataSource = s.Summary;
        }

        private void scheduleGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                for (int i = 1; i < row.Cells.Count; i++)
                {
                    string category = row.Cells[i].Value.ToString();

                    if (category.Length != 0)
                    {
                        if (activityList[category].GetType() == typeof(Category))
                        {
                            row.Cells[i].Style.BackColor = ((Category)activityList[category]).Color;
                        }
                        else
                        {
                            row.Cells[i].Style.BackColor = ((Subcategory)activityList[category]).Category.Color;
                        }
                    }
                    else
                    {
                        row.Cells[i].Style.BackColor = Color.Empty;
                    }
                }
            }
            dataGridView.Update();
        }

        private void scheduleGridView_DragDrop(object sender, DragEventArgs e)
        {
            DataGridView destination = (DataGridView)sender;

            if (e.Data.GetDataPresent(typeof(string)))
            {
                Point p = destination.PointToClient(new Point(e.X, e.Y));
                DataGridView.HitTestInfo info = destination.HitTest(p.X, p.Y);
                if (info.RowIndex >= 0)
                {

                    if (info.RowIndex >= 0 && info.ColumnIndex >= 1)
                    {
                        string dragged = (string)e.Data.GetData(typeof(string));
                        string current = destination.Rows[info.RowIndex].Cells[info.ColumnIndex].Value.ToString();
                        int draggedIndex;
                        int currentIndex;
                        if (dragged.Length != 0)
                        {
                            if (current.Length != 0)
                            {
                                if (activityList[current].GetType() == typeof(Category))
                                {
                                    currentIndex = Setting.CategoryList.IndexOf((Category)activityList[current]);
                                    currentSchedule.decrementSummaryPoint(currentIndex, info.ColumnIndex);
                                }
                                else
                                {
                                    currentIndex = Setting.CategoryList.IndexOf(((Subcategory)activityList[current]).Category);
                                    currentSchedule.decrementSummaryPoint(currentIndex, info.ColumnIndex);
                                }
                            }

                            if (activityList[dragged].GetType() == typeof(Category))
                            {
                                draggedIndex = Setting.CategoryList.IndexOf((Category)activityList[dragged]);
                                currentSchedule.incrementSummaryPoint(draggedIndex, info.ColumnIndex);
                            }
                            else
                            {
                                draggedIndex = Setting.CategoryList.IndexOf(((Subcategory)activityList[dragged]).Category);
                                currentSchedule.incrementSummaryPoint(draggedIndex, info.ColumnIndex);
                            }

                            currentSchedule.Table.Rows[info.RowIndex][info.ColumnIndex] = dragged;
                        }
                    }
                }
            }
        }

        private void scheduleGridView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void activityListBox_MouseDown(object sender, MouseEventArgs e)
        {
            ListBox source = (ListBox)sender;
            DoDragDrop(source.SelectedItem, DragDropEffects.Move);
        }

        private void scheduleGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && scheduleGridView.SelectedCells != null)
            {
                if (scheduleGridView.SelectedCells[0].ColumnIndex != 0)
                {
                    string current = scheduleGridView.SelectedCells[0].Value.ToString();
                    if (current.Length != 0)
                    {
                        int row;
                        int column = scheduleGridView.SelectedCells[0].ColumnIndex;

                        if (activityList[current].GetType() == typeof(Category))
                        {
                            row = Setting.CategoryList.IndexOf((Category)activityList[current]);
                            currentSchedule.decrementSummaryPoint(row, column);
                        }
                        else
                        {
                            row = Setting.CategoryList.IndexOf(((Subcategory)activityList[current]).Category);
                            currentSchedule.decrementSummaryPoint(row, column);
                        }

                        currentSchedule.Table.Rows[scheduleGridView.SelectedCells[0].RowIndex][column] = "";
                    }
                }
            }
        }

        private void scheduleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(schedulerPanel != null)
                load(schedulerPanel.scheduleList[scheduleComboBox.SelectedIndex]);
        }

        public static DataTable SummaryTable
        {
            get
            {
                if (schedulerPanel != null)
                    return schedulerPanel.currentSchedule.Summary;
                else
                    return null;
            }
        }
    }
}