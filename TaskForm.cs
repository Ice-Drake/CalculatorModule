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
    public class TaskForm : Form
    {
        public static TaskManager TaskController { private get; set; }
        public static SettingManager SettingController { private get; set; }

        private GTask m_gtask;
        private ITodo m_todo;
        private TimeSpan m_duration;
        private string oldUID;

        #region Component Designer variables

        private IContainer components = null;
        private Label calendarLabel;
        private ComboBox calendarComboBox;
        private Label summaryLabel;
        private TextBox summaryField;
        private Label startDateLabel;
        private DateTimePicker startDateBox;
        private DateTimePicker dueDateBox;
        private Label dueDateLabel;
        private ComboBox importanceComboBox;
        private Label importanceLabel;
        private Label priorityLabel;
        private Label categoryLabel;
        private ComboBox urgencyComboBox;
        private RichTextBox descriptionTextBox;
        private ComboBox categoryComboBox;
        private CheckBox reminderCheckBox;
        private DateTimePicker reminderDate;
        private DateTimePicker reminderTime;
        private Button alarmButton;
        private ToolStrip eventToolStrip;
        private ToolStripButton saveButton;
        private CheckBox privateCheckBox;
        private ToolStripButton deleteButton;
        private TableLayoutPanel tableLayoutPanel;
        private Panel topPanel;
        private Panel bottomPanel;
        private Label goalLabel;
        private ComboBox goalComboBox;
        private CheckBox completedCheckBox;

        #endregion

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
            this.calendarLabel = new System.Windows.Forms.Label();
            this.calendarComboBox = new System.Windows.Forms.ComboBox();
            this.summaryLabel = new System.Windows.Forms.Label();
            this.summaryField = new System.Windows.Forms.TextBox();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.dueDateLabel = new System.Windows.Forms.Label();
            this.importanceComboBox = new System.Windows.Forms.ComboBox();
            this.importanceLabel = new System.Windows.Forms.Label();
            this.priorityLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.urgencyComboBox = new System.Windows.Forms.ComboBox();
            this.descriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.reminderCheckBox = new System.Windows.Forms.CheckBox();
            this.reminderDate = new System.Windows.Forms.DateTimePicker();
            this.reminderTime = new System.Windows.Forms.DateTimePicker();
            this.eventToolStrip = new System.Windows.Forms.ToolStrip();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.deleteButton = new System.Windows.Forms.ToolStripButton();
            this.privateCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.alarmButton = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.goalLabel = new System.Windows.Forms.Label();
            this.goalComboBox = new System.Windows.Forms.ComboBox();
            this.completedCheckBox = new System.Windows.Forms.CheckBox();
            this.startDateBox = new System.Windows.Forms.DateTimePicker();
            this.dueDateBox = new System.Windows.Forms.DateTimePicker();
            this.eventToolStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // calendarLabel
            // 
            this.calendarLabel.Location = new System.Drawing.Point(7, 31);
            this.calendarLabel.Name = "calendarLabel";
            this.calendarLabel.Size = new System.Drawing.Size(57, 13);
            this.calendarLabel.TabIndex = 0;
            this.calendarLabel.Text = "Calendar:";
            // 
            // calendarComboBox
            // 
            this.calendarComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.calendarComboBox.Location = new System.Drawing.Point(70, 28);
            this.calendarComboBox.Name = "calendarComboBox";
            this.calendarComboBox.Size = new System.Drawing.Size(251, 21);
            this.calendarComboBox.TabIndex = 1;
            // 
            // summaryLabel
            // 
            this.summaryLabel.Location = new System.Drawing.Point(7, 58);
            this.summaryLabel.Name = "summaryLabel";
            this.summaryLabel.Size = new System.Drawing.Size(57, 13);
            this.summaryLabel.TabIndex = 2;
            this.summaryLabel.Text = "Summary:";
            // 
            // summaryField
            // 
            this.summaryField.Location = new System.Drawing.Point(70, 55);
            this.summaryField.Name = "summaryField";
            this.summaryField.Size = new System.Drawing.Size(251, 20);
            this.summaryField.TabIndex = 3;
            // 
            // startDateLabel
            // 
            this.startDateLabel.Location = new System.Drawing.Point(7, 84);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(57, 13);
            this.startDateLabel.TabIndex = 4;
            this.startDateLabel.Text = "Start date:";
            // 
            // dueDateLabel
            // 
            this.dueDateLabel.Location = new System.Drawing.Point(166, 84);
            this.dueDateLabel.Name = "dueDateLabel";
            this.dueDateLabel.Size = new System.Drawing.Size(57, 13);
            this.dueDateLabel.TabIndex = 7;
            this.dueDateLabel.Text = "Due date:";
            // 
            // importanceComboBox
            // 
            this.importanceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.importanceComboBox.Items.AddRange(new object[] {
            "High",
            "Medium",
            "Low"});
            this.importanceComboBox.Location = new System.Drawing.Point(70, 3);
            this.importanceComboBox.Name = "importanceComboBox";
            this.importanceComboBox.Size = new System.Drawing.Size(92, 21);
            this.importanceComboBox.TabIndex = 8;
            // 
            // importanceLabel
            // 
            this.importanceLabel.AutoSize = true;
            this.importanceLabel.Location = new System.Drawing.Point(7, 7);
            this.importanceLabel.Name = "importanceLabel";
            this.importanceLabel.Size = new System.Drawing.Size(63, 13);
            this.importanceLabel.TabIndex = 9;
            this.importanceLabel.Text = "Importance:";
            // 
            // priorityLabel
            // 
            this.priorityLabel.AutoSize = true;
            this.priorityLabel.Location = new System.Drawing.Point(166, 6);
            this.priorityLabel.Name = "priorityLabel";
            this.priorityLabel.Size = new System.Drawing.Size(50, 13);
            this.priorityLabel.TabIndex = 10;
            this.priorityLabel.Text = "Urgency:";
            // 
            // categoryLabel
            // 
            this.categoryLabel.Location = new System.Drawing.Point(7, 110);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(57, 13);
            this.categoryLabel.TabIndex = 11;
            this.categoryLabel.Text = "Category:";
            // 
            // urgencyComboBox
            // 
            this.urgencyComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "Low",
            "Normal",
            "High"});
            this.urgencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.urgencyComboBox.Items.AddRange(new object[] {
            "High",
            "Normal",
            "Low"});
            this.urgencyComboBox.Location = new System.Drawing.Point(229, 4);
            this.urgencyComboBox.Name = "urgencyComboBox";
            this.urgencyComboBox.Size = new System.Drawing.Size(92, 21);
            this.urgencyComboBox.TabIndex = 12;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionTextBox.Location = new System.Drawing.Point(3, 137);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(325, 116);
            this.descriptionTextBox.TabIndex = 13;
            this.descriptionTextBox.Text = "";
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.Location = new System.Drawing.Point(70, 107);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(106, 21);
            this.categoryComboBox.TabIndex = 15;
            // 
            // reminderCheckBox
            // 
            this.reminderCheckBox.AutoSize = true;
            this.reminderCheckBox.Location = new System.Drawing.Point(7, 30);
            this.reminderCheckBox.Name = "reminderCheckBox";
            this.reminderCheckBox.Size = new System.Drawing.Size(74, 17);
            this.reminderCheckBox.TabIndex = 16;
            this.reminderCheckBox.Text = "Reminder:";
            this.reminderCheckBox.UseVisualStyleBackColor = true;
            this.reminderCheckBox.CheckedChanged += new System.EventHandler(this.reminderCheckBox_CheckedChanged);
            // 
            // reminderDate
            // 
            this.reminderDate.Enabled = false;
            this.reminderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.reminderDate.Location = new System.Drawing.Point(84, 27);
            this.reminderDate.Name = "reminderDate";
            this.reminderDate.Size = new System.Drawing.Size(92, 20);
            this.reminderDate.TabIndex = 17;
            // 
            // reminderTime
            // 
            this.reminderTime.Enabled = false;
            this.reminderTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.reminderTime.Location = new System.Drawing.Point(198, 27);
            this.reminderTime.Name = "reminderTime";
            this.reminderTime.Size = new System.Drawing.Size(92, 20);
            this.reminderTime.TabIndex = 18;
            // 
            // eventToolStrip
            // 
            this.eventToolStrip.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.eventToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.eventToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveButton,
            this.deleteButton});
            this.eventToolStrip.Location = new System.Drawing.Point(0, 0);
            this.eventToolStrip.Name = "eventToolStrip";
            this.eventToolStrip.Size = new System.Drawing.Size(331, 25);
            this.eventToolStrip.TabIndex = 20;
            this.eventToolStrip.Text = "Event Toolbar";
            // 
            // saveButton
            // 
            this.saveButton.Image = global::MultiDesktop.Properties.Resources.Save;
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(106, 22);
            this.saveButton.Text = "Save and Close";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Image = global::MultiDesktop.Properties.Resources.Delete;
            this.deleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(60, 22);
            this.deleteButton.Text = "Delete";
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // privateCheckBox
            // 
            this.privateCheckBox.AutoSize = true;
            this.privateCheckBox.Location = new System.Drawing.Point(262, 109);
            this.privateCheckBox.Name = "privateCheckBox";
            this.privateCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.privateCheckBox.Size = new System.Drawing.Size(59, 17);
            this.privateCheckBox.TabIndex = 21;
            this.privateCheckBox.Text = "Private";
            this.privateCheckBox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.descriptionTextBox, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.bottomPanel, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.topPanel, 0, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 134F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(331, 318);
            this.tableLayoutPanel.TabIndex = 22;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.reminderCheckBox);
            this.bottomPanel.Controls.Add(this.alarmButton);
            this.bottomPanel.Controls.Add(this.reminderDate);
            this.bottomPanel.Controls.Add(this.reminderTime);
            this.bottomPanel.Controls.Add(this.importanceComboBox);
            this.bottomPanel.Controls.Add(this.priorityLabel);
            this.bottomPanel.Controls.Add(this.urgencyComboBox);
            this.bottomPanel.Controls.Add(this.importanceLabel);
            this.bottomPanel.Location = new System.Drawing.Point(3, 259);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(325, 55);
            this.bottomPanel.TabIndex = 14;
            // 
            // alarmButton
            // 
            this.alarmButton.Enabled = false;
            this.alarmButton.Image = global::MultiDesktop.Properties.Resources.Alarm;
            this.alarmButton.Location = new System.Drawing.Point(296, 26);
            this.alarmButton.Name = "alarmButton";
            this.alarmButton.Size = new System.Drawing.Size(23, 23);
            this.alarmButton.TabIndex = 19;
            this.alarmButton.UseVisualStyleBackColor = true;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.goalLabel);
            this.topPanel.Controls.Add(this.goalComboBox);
            this.topPanel.Controls.Add(this.completedCheckBox);
            this.topPanel.Controls.Add(this.calendarLabel);
            this.topPanel.Controls.Add(this.privateCheckBox);
            this.topPanel.Controls.Add(this.categoryLabel);
            this.topPanel.Controls.Add(this.calendarComboBox);
            this.topPanel.Controls.Add(this.summaryLabel);
            this.topPanel.Controls.Add(this.categoryComboBox);
            this.topPanel.Controls.Add(this.summaryField);
            this.topPanel.Controls.Add(this.startDateLabel);
            this.topPanel.Controls.Add(this.startDateBox);
            this.topPanel.Controls.Add(this.dueDateBox);
            this.topPanel.Controls.Add(this.dueDateLabel);
            this.topPanel.Location = new System.Drawing.Point(3, 3);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(325, 128);
            this.topPanel.TabIndex = 0;
            // 
            // goalLabel
            // 
            this.goalLabel.Location = new System.Drawing.Point(7, 6);
            this.goalLabel.Name = "goalLabel";
            this.goalLabel.Size = new System.Drawing.Size(57, 13);
            this.goalLabel.TabIndex = 23;
            this.goalLabel.Text = "Goal:";
            // 
            // goalComboBox
            // 
            this.goalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.goalComboBox.Location = new System.Drawing.Point(70, 3);
            this.goalComboBox.Name = "goalComboBox";
            this.goalComboBox.Size = new System.Drawing.Size(251, 21);
            this.goalComboBox.TabIndex = 24;
            // 
            // completedCheckBox
            // 
            this.completedCheckBox.AutoSize = true;
            this.completedCheckBox.Location = new System.Drawing.Point(180, 109);
            this.completedCheckBox.Name = "completedCheckBox";
            this.completedCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.completedCheckBox.Size = new System.Drawing.Size(76, 17);
            this.completedCheckBox.TabIndex = 22;
            this.completedCheckBox.Text = "Completed";
            this.completedCheckBox.UseVisualStyleBackColor = true;
            // 
            // startDateBox
            // 
            this.startDateBox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDateBox.Location = new System.Drawing.Point(70, 81);
            this.startDateBox.Name = "startDateBox";
            this.startDateBox.Size = new System.Drawing.Size(92, 20);
            this.startDateBox.TabIndex = 5;
            // 
            // dueDateBox
            // 
            this.dueDateBox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dueDateBox.Location = new System.Drawing.Point(229, 81);
            this.dueDateBox.Name = "dueDateBox";
            this.dueDateBox.Size = new System.Drawing.Size(92, 20);
            this.dueDateBox.TabIndex = 6;
            // 
            // TaskForm
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(331, 346);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.eventToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "TaskForm";
            this.Text = "Task";
            this.eventToolStrip.ResumeLayout(false);
            this.eventToolStrip.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public TaskForm()
        {
            InitializeComponent();

            goalComboBox.DisplayMember = "Summary";
            goalComboBox.ValueMember = "ID";
            goalComboBox.DataSource = SettingController.GoalManager.SGoalTable;

            calendarComboBox.DisplayMember = "Name";
            calendarComboBox.ValueMember = "ID";
            calendarComboBox.DataSource = SettingController.CalendarManager.CalendarTable;
            //calendarComboBox.SelectedItem = "Personal";
            
            importanceComboBox.SelectedIndex = 1;
            urgencyComboBox.SelectedIndex = 1;
            
            foreach (string categoryName in SettingController.CategoryManager.getCategoryList())
            {
                categoryComboBox.Items.Add(categoryName);
            }
            categoryComboBox.SelectedIndex = 0;
            
            deleteButton.Enabled = false;

            startDateBox.ValueChanged += new EventHandler(startDateBox_ValueChanged);
            dueDateBox.ValueChanged += new EventHandler(dueDateBox_ValueChanged);
        }

        public TaskForm(ITodo todo)
        {
            InitializeComponent();
            m_todo = todo;

            goalComboBox.DisplayMember = "Summary";
            goalComboBox.ValueMember = "ID";
            goalComboBox.DataSource = SettingController.GoalManager.SGoalTable;

            calendarComboBox.DisplayMember = "Name";
            calendarComboBox.ValueMember = "ID";
            calendarComboBox.DataSource = SettingController.CalendarManager.CalendarTable;
            calendarComboBox.SelectedValue = SettingController.CalendarManager.findCalendarID(todo.Calendar);

            summaryField.Text = m_todo.Summary;
            if (m_todo.Start != null && m_todo.Start.Date != DateTime.MinValue)
                startDateBox.Value = m_todo.Start.Date;
            if (m_todo.Due != null && m_todo.Due.Date != DateTime.MinValue)
                dueDateBox.Value = m_todo.Due.Date;
            if (startDateBox.Value <= dueDateBox.Value)
                m_duration = m_todo.Due.Date - m_todo.Start.Date;
            completedCheckBox.Checked = m_todo.Status == TodoStatus.Completed;

            if (m_todo.Priority != 0)
            {
                importanceComboBox.SelectedIndex = (m_todo.Priority - 1) / 3;
                urgencyComboBox.SelectedIndex = (m_todo.Priority - 1) % 3;
            }
            else
            {
                importanceComboBox.SelectedIndex = 1;
                urgencyComboBox.SelectedIndex = 1;
            }

            descriptionTextBox.Text = m_todo.Description;
            
            foreach (string categoryName in SettingController.CategoryManager.getCategoryList())
            {
                categoryComboBox.Items.Add(categoryName);
            }
            if (m_todo.Categories.Count != 0)
                categoryComboBox.SelectedItem = m_todo.Categories[0];
            else
                categoryComboBox.SelectedItem = "Personal";
            
            privateCheckBox.Checked = (m_todo.Class != null && m_todo.Class.ToUpper() == "PRIVATE");
            deleteButton.Enabled = false;

            startDateBox.ValueChanged += new EventHandler(startDateBox_ValueChanged);
            dueDateBox.ValueChanged += new EventHandler(dueDateBox_ValueChanged);
        }

        public TaskForm(GTask task)
        {
            InitializeComponent();
            m_gtask = task;
            
            goalComboBox.DataSource = SettingController.GoalManager.SGoalTable;
            goalComboBox.DisplayMember = "Summary";
            goalComboBox.ValueMember = "ID";
            goalComboBox.SelectedValue = m_gtask.RelatedGoalID;

            calendarComboBox.DisplayMember = "Name";
            calendarComboBox.ValueMember = "ID";
            calendarComboBox.DataSource = SettingController.CalendarManager.CalendarTable;
            calendarComboBox.SelectedValue = SettingController.CalendarManager.findCalendarID(m_gtask.Todo.Calendar);

            summaryField.Text = m_gtask.Todo.Summary;
            if (m_gtask.Todo.Start != null && m_gtask.Todo.Start.Date != DateTime.MinValue)
                startDateBox.Value = m_gtask.Todo.Start.Date;
            if (m_gtask.Todo.Due != null && m_gtask.Todo.Due.Date != DateTime.MinValue)
                dueDateBox.Value = m_gtask.Todo.Due.Date;
            if (startDateBox.Value <= dueDateBox.Value)
                m_duration = m_gtask.Todo.Due.Date - m_gtask.Todo.Start.Date;
            completedCheckBox.Checked = m_gtask.Todo.Status == TodoStatus.Completed;

            if (m_gtask.Todo.Priority != 0)
            {
                importanceComboBox.SelectedIndex = (m_gtask.Todo.Priority - 1) / 3;
                urgencyComboBox.SelectedIndex = (m_gtask.Todo.Priority - 1) % 3;
            }
            else
            {
                importanceComboBox.SelectedIndex = 1;
                urgencyComboBox.SelectedIndex = 1;
            }

            descriptionTextBox.Text = m_gtask.Todo.Description;

            foreach (string categoryName in SettingController.CategoryManager.getCategoryList())
            {
                categoryComboBox.Items.Add(categoryName);
            }
            if (m_gtask.Todo.Categories.Count != 0)
                categoryComboBox.SelectedItem = m_gtask.Todo.Categories[0];
            else
                categoryComboBox.SelectedItem = "Personal";

            privateCheckBox.Checked = (m_gtask.Todo.Class != null && m_gtask.Todo.Class.ToUpper() == "PRIVATE");

            startDateBox.ValueChanged += new EventHandler(startDateBox_ValueChanged);
            dueDateBox.ValueChanged += new EventHandler(dueDateBox_ValueChanged);
        }

        public TaskForm(string uid, string summary, DateTime start, DateTime due, bool complete, int sGoalID)
        {
            InitializeComponent();

            goalComboBox.DataSource = SettingController.GoalManager.SGoalTable;
            goalComboBox.DisplayMember = "Summary";
            goalComboBox.ValueMember = "ID";

            calendarComboBox.DisplayMember = "Name";
            calendarComboBox.ValueMember = "ID";
            calendarComboBox.DataSource = SettingController.CalendarManager.CalendarTable;
            //calendarComboBox.SelectedItem = "Personal";

            oldUID = uid;
            summaryField.Text = summary;
            startDateBox.Value = start;
            dueDateBox.Value = due;
            m_duration = due - start;
            completedCheckBox.Checked = complete;

            importanceComboBox.SelectedIndex = 1;
            urgencyComboBox.SelectedIndex = 1;

            foreach (string categoryName in SettingController.CategoryManager.getCategoryList())
            {
                categoryComboBox.Items.Add(categoryName);
            }
            deleteButton.Enabled = false;

            if (complete)
            {
                saveButton.Enabled = false;
                completedCheckBox.CheckedChanged += new EventHandler(completedCheckBox_CheckedChanged);
            }
        }

        private void completedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (completedCheckBox.Checked)
                saveButton.Enabled = false;
            else
                saveButton.Enabled = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int goalID = Int32.Parse(goalComboBox.SelectedValue.ToString());

            SGoal relatedGoal = (SGoal)SettingController.GoalManager.GoalList[goalID];
            if (startDateBox.Value < DateTime.Today.AddDays(relatedGoal.Start))
                MessageBox.Show("The start date of this task cannot occur earlier than the start date of its related goal, which is " + DateTime.Today.AddDays(relatedGoal.Start).ToString("d") + ".");
            else if (dueDateBox.Value > DateTime.Today.AddDays(relatedGoal.End))
                MessageBox.Show("The due date of this task cannot occur later than the due date of its related goal, which is " + DateTime.Today.AddDays(relatedGoal.End).ToString("d") + ".");
            else if (m_gtask == null)
            {
                GTask newTask;
                
                if (m_todo != null)
                    newTask = new GTask(m_todo, goalID);
                else
                    newTask = TaskController.createGTask(goalID);

                newTask.Todo.Summary = summaryField.Text;
                newTask.Todo.Start = new iCalDateTime(startDateBox.Value);
                if (startDateBox.Value == dueDateBox.Value)
                    newTask.Todo.Due = new iCalDateTime(dueDateBox.Value.Add(new TimeSpan(1, 0, 0)));
                else
                    newTask.Todo.Due = new iCalDateTime(dueDateBox.Value);

                if (completedCheckBox.Checked)
                    newTask.Todo.Status = TodoStatus.Completed;
                else
                    newTask.Todo.Status = TodoStatus.NeedsAction;

                newTask.Todo.Priority = importanceComboBox.SelectedIndex * 3 + urgencyComboBox.SelectedIndex + 1;

                newTask.Todo.Description = descriptionTextBox.Text;
                newTask.Todo.Categories.Add(categoryComboBox.SelectedItem.ToString());
                if (privateCheckBox.Checked)
                    newTask.Todo.Class = "PRIVATE";
                else
                    newTask.Todo.Class = "PUBLIC";

                if (oldUID != null)
                {
                    TaskController.replaceGTaskID(oldUID, newTask.Todo.UID);
                    TaskController.updateGTask(newTask);
                }
                else
                    TaskController.addGTask(newTask);
                Close();
            }
            else
            {
                m_gtask.RelatedGoalID = goalID;
                m_gtask.Todo.Summary = summaryField.Text;
                m_gtask.Todo.Start = new iCalDateTime(startDateBox.Value);
                m_gtask.Todo.Due = new iCalDateTime(dueDateBox.Value);
                
                if (completedCheckBox.Checked)
                    m_gtask.Todo.Status = TodoStatus.Completed;
                else
                    m_gtask.Todo.Status = TodoStatus.NeedsAction;

                m_gtask.Todo.Priority = importanceComboBox.SelectedIndex * 3 + urgencyComboBox.SelectedIndex + 1;
                m_gtask.Todo.Description = descriptionTextBox.Text;
                m_gtask.Todo.Categories.Clear();
                m_gtask.Todo.Categories.Add(categoryComboBox.SelectedItem.ToString());
                if(privateCheckBox.Checked)
                    m_gtask.Todo.Class = "PRIVATE";
                else
                    m_gtask.Todo.Class = "PUBLIC";

                TaskController.updateGTask(m_gtask);
                Close();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            TaskController.removeGTask(m_gtask.Todo.UID);
            Close();
        }

        private void reminderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (reminderCheckBox.Checked)
            {
                reminderDate.Enabled = true;
                reminderTime.Enabled = true;
                alarmButton.Enabled = true;
            }
            else
            {
                reminderDate.Enabled = false;
                reminderTime.Enabled = false;
                alarmButton.Enabled = false;
            }
        }

        private void startDateBox_ValueChanged(object sender, EventArgs e)
        {
            dueDateBox.Value = startDateBox.Value.Add(m_duration);
        }

        private void dueDateBox_ValueChanged(object sender, EventArgs e)
        {
            if (startDateBox.Value != DateTime.MinValue && dueDateBox.Value != DateTime.MinValue)
            {
                if (dueDateBox.Value >= startDateBox.Value)
                    m_duration = dueDateBox.Value - startDateBox.Value;
                else
                {
                    MessageBox.Show("The due date of a task cannot occur before its start date.");
                    dueDateBox.Value = startDateBox.Value.Add(m_duration);
                }
            }
        }
    }
}
