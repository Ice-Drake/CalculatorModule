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
        private ITodo m_todo;
        private TimeSpan m_duration;

        #region Component Designer variables

        private IContainer components = null;
        private Label calendarLabel;
        private ComboBox calendarComboBox;
        private Label summaryLabel;
        private TextBox summaryField;
        private Label startDateLabel;
        private Library.NullableDateTimePicker startDateBox;
        private Library.NullableDateTimePicker dueDateBox;
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
            this.alarmButton = new System.Windows.Forms.Button();
            this.eventToolStrip = new System.Windows.Forms.ToolStrip();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.deleteButton = new System.Windows.Forms.ToolStripButton();
            this.privateCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.completedCheckBox = new System.Windows.Forms.CheckBox();
            this.startDateBox = new Library.NullableDateTimePicker();
            this.dueDateBox = new Library.NullableDateTimePicker();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.goalLabel = new System.Windows.Forms.Label();
            this.goalComboBox = new System.Windows.Forms.ComboBox();
            this.eventToolStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
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
            this.startDateBox.CustomFormat = "None";
            this.startDateBox.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDateBox.Location = new System.Drawing.Point(70, 81);
            this.startDateBox.Name = "startDateBox";
            this.startDateBox.Size = new System.Drawing.Size(92, 20);
            this.startDateBox.TabIndex = 5;
            this.startDateBox.Value = new System.DateTime(((long)(0)));
            this.startDateBox.ValueChanged += new System.EventHandler(this.startDateBox_ValueChanged);
            // 
            // dueDateBox
            // 
            this.dueDateBox.CustomFormat = "None";
            this.dueDateBox.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dueDateBox.Location = new System.Drawing.Point(229, 81);
            this.dueDateBox.Name = "dueDateBox";
            this.dueDateBox.Size = new System.Drawing.Size(92, 20);
            this.dueDateBox.TabIndex = 6;
            this.dueDateBox.Value = new System.DateTime(((long)(0)));
            this.dueDateBox.ValueChanged += new System.EventHandler(this.dueDateBox_ValueChanged);
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
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public TaskForm(ITodo todo)
        {
            InitializeComponent();

            foreach (string calendarName in Setting.CalendarList.Keys)
            {
                calendarComboBox.Items.Add(calendarName);
            }
            calendarComboBox.SelectedItem = "Personal";
            importanceComboBox.SelectedIndex = 1;
            urgencyComboBox.SelectedIndex = 1;
            foreach(Category category in Setting.CategoryList)
            {
                categoryComboBox.Items.Add(category.Name);
            }
            categoryComboBox.SelectedIndex = 0;
            deleteButton.Enabled = false;
        }

        public TaskForm(string name, DateTime start, DateTime due, bool complete, int sGoalID, ITodo todo = null)
        {
            InitializeComponent();
            m_todo = todo;
            
            foreach (string calendarName in Setting.CalendarList.Keys)
            {
                calendarComboBox.Items.Add(calendarName);
            }
            calendarComboBox.SelectedItem = Setting.findCalendarName(CalendarManager.findCalendarFileName(m_todo.Calendar));

            calendarComboBox.Enabled = false;
            summaryField.Text = m_todo.Summary;
            if(m_todo.Start != null)
                startDateBox.Value = m_todo.Start.Date;
            else
                startDateBox.Value = DateTime.MinValue;
            if (m_todo.Due != null)
                dueDateBox.Value = m_todo.Due.Date;
            else
                dueDateBox.Value = DateTime.MinValue;
            if (startDateBox.Value != DateTime.MinValue && dueDateBox.Value != DateTime.MinValue)
                m_duration = dueDateBox.Value - startDateBox.Value;
            
            if (m_todo.Status == TodoStatus.Completed)
                completedCheckBox.Checked = true;

            importanceComboBox.SelectedIndex = (m_todo.Priority - 1) / 3;
            
            urgencyComboBox.SelectedIndex = (m_todo.Priority - 1) % 3;

            descriptionTextBox.Text = m_todo.Description;
            foreach (Category category in Setting.CategoryList)
            {
                categoryComboBox.Items.Add(category.Name);
            }
            if (m_todo.Categories.Count != 0)
                categoryComboBox.SelectedItem = m_todo.Categories[0];
            else
                categoryComboBox.SelectedItem = "Personal";
            privateCheckBox.Checked = (m_todo.Class != null && m_todo.Class.ToUpper() == "PRIVATE");
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string calendarName = Setting.CalendarList.Keys[calendarComboBox.SelectedIndex];
            if (m_todo == null)
            {
                ITodo newTodo = CalendarManager.createTodo(Setting.CalendarList[calendarName]);
                newTodo.Summary = summaryField.Text;
                if (startDateBox.Value != DateTime.MinValue)
                    newTodo.Start = new iCalDateTime(startDateBox.Value);
                if (dueDateBox.Value != DateTime.MinValue)
                {
                    if(startDateBox.Value == dueDateBox.Value)
                        newTodo.Due = new iCalDateTime(dueDateBox.Value.Add(new TimeSpan(1, 0, 0)));
                    else
                        newTodo.Due = new iCalDateTime(dueDateBox.Value);
                }

                if (completedCheckBox.Checked)
                    newTodo.Status = TodoStatus.Completed;
                else
                    newTodo.Status = TodoStatus.NeedsAction;

                newTodo.Priority = importanceComboBox.SelectedIndex * 3 + urgencyComboBox.SelectedIndex + 1;

                newTodo.Description = descriptionTextBox.Text;
                newTodo.Categories.Add(categoryComboBox.SelectedItem.ToString());
                if (privateCheckBox.Checked)
                    newTodo.Class = "PRIVATE";
                else
                    newTodo.Class = "PUBLIC";

                CalendarManager.addTodo(newTodo);
            }
            else
            {
                m_todo.Summary = summaryField.Text;
                if (startDateBox.Value != DateTime.MinValue)
                    m_todo.Start = new iCalDateTime(startDateBox.Value);
                else
                    m_todo.Start = null;
                if (dueDateBox.Value != DateTime.MinValue)
                {
                    if (startDateBox.Value == dueDateBox.Value)
                        m_todo.Due = new iCalDateTime(dueDateBox.Value.Add(new TimeSpan(1, 0, 0)));
                    else
                        m_todo.Due = new iCalDateTime(dueDateBox.Value);
                }
                else
                    m_todo.Due = null;
                
                if (completedCheckBox.Checked)
                    m_todo.Status = TodoStatus.Completed;
                else
                    m_todo.Status = TodoStatus.NeedsAction;

                m_todo.Priority = importanceComboBox.SelectedIndex * 3 + urgencyComboBox.SelectedIndex + 1;
                m_todo.Description = descriptionTextBox.Text;
                m_todo.Categories.Clear();
                m_todo.Categories.Add(categoryComboBox.SelectedItem.ToString());
                if(privateCheckBox.Checked)
                    m_todo.Class = "PRIVATE";
                else
                    m_todo.Class = "PUBLIC";

                CalendarManager.updateTodo(m_todo.UID);
            }

            CalendarManager.saveCalendar(Setting.CalendarList[calendarName]);

            Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string filename = CalendarManager.findCalendarFileName(m_todo.Calendar);
            CalendarManager.removeTodo(m_todo.UID);
            m_todo.Calendar.RemoveChild(m_todo);

            CalendarManager.saveCalendar(filename);

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
            if (startDateBox.Value != DateTime.MinValue && dueDateBox.Value != DateTime.MinValue)
            {
                dueDateBox.Value = startDateBox.Value.Add(m_duration);
            }
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
