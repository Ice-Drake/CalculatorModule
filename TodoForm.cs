using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DDay.iCal;
using DDay.iCal.Serialization.iCalendar;

namespace MultiDesktop
{
    public class TodoForm : Form
    {
        private ITodo m_todo;
        private IRecurrencePattern m_recurrence;
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
        private ComboBox statusComboBox;
        private Label statusLabel;
        private Label priorityLabel;
        private Label categoryLabel;
        private ComboBox priorityComboBox;
        private RichTextBox descriptionTextBox;
        private ComboBox categoryComboBox;
        private CheckBox reminderCheckBox;
        private DateTimePicker reminderDate;
        private DateTimePicker reminderTime;
        private Button alarmButton;
        private ToolStrip eventToolStrip;
        private ToolStripButton saveButton;
        private ToolStripButton recurrenceButton;
        private CheckBox privateCheckBox;
        private ToolStripButton deleteButton;
        private TableLayoutPanel tableLayoutPanel;
        private Panel topPanel;
        private Panel bottomPanel;
        private Label recurLabel;

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
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.priorityLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.priorityComboBox = new System.Windows.Forms.ComboBox();
            this.descriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.reminderCheckBox = new System.Windows.Forms.CheckBox();
            this.reminderDate = new System.Windows.Forms.DateTimePicker();
            this.reminderTime = new System.Windows.Forms.DateTimePicker();
            this.alarmButton = new System.Windows.Forms.Button();
            this.eventToolStrip = new System.Windows.Forms.ToolStrip();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.deleteButton = new System.Windows.Forms.ToolStripButton();
            this.recurrenceButton = new System.Windows.Forms.ToolStripButton();
            this.privateCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.recurLabel = new System.Windows.Forms.Label();
            this.topPanel = new System.Windows.Forms.Panel();
            this.startDateBox = new Library.NullableDateTimePicker();
            this.dueDateBox = new Library.NullableDateTimePicker();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.eventToolStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // calendarLabel
            // 
            this.calendarLabel.Location = new System.Drawing.Point(7, 6);
            this.calendarLabel.Name = "calendarLabel";
            this.calendarLabel.Size = new System.Drawing.Size(71, 13);
            this.calendarLabel.TabIndex = 0;
            this.calendarLabel.Text = "Calendar:";
            // 
            // calendarComboBox
            // 
            this.calendarComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.calendarComboBox.Location = new System.Drawing.Point(84, 3);
            this.calendarComboBox.Name = "calendarComboBox";
            this.calendarComboBox.Size = new System.Drawing.Size(237, 21);
            this.calendarComboBox.TabIndex = 1;
            // 
            // summaryLabel
            // 
            this.summaryLabel.Location = new System.Drawing.Point(7, 33);
            this.summaryLabel.Name = "summaryLabel";
            this.summaryLabel.Size = new System.Drawing.Size(71, 13);
            this.summaryLabel.TabIndex = 2;
            this.summaryLabel.Text = "Summary:";
            // 
            // summaryField
            // 
            this.summaryField.Location = new System.Drawing.Point(84, 30);
            this.summaryField.Name = "summaryField";
            this.summaryField.Size = new System.Drawing.Size(237, 20);
            this.summaryField.TabIndex = 3;
            // 
            // startDateLabel
            // 
            this.startDateLabel.Location = new System.Drawing.Point(7, 59);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(71, 13);
            this.startDateLabel.TabIndex = 4;
            this.startDateLabel.Text = "Start date:";
            // 
            // dueDateLabel
            // 
            this.dueDateLabel.Location = new System.Drawing.Point(7, 85);
            this.dueDateLabel.Name = "dueDateLabel";
            this.dueDateLabel.Size = new System.Drawing.Size(71, 13);
            this.dueDateLabel.TabIndex = 7;
            this.dueDateLabel.Text = "Due date:";
            // 
            // statusComboBox
            // 
            this.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusComboBox.Items.AddRange(new object[] {
            "Not Started",
            "In Progress",
            "Completed"});
            this.statusComboBox.Location = new System.Drawing.Point(229, 56);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(92, 21);
            this.statusComboBox.TabIndex = 8;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(183, 59);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(40, 13);
            this.statusLabel.TabIndex = 9;
            this.statusLabel.Text = "Status:";
            // 
            // priorityLabel
            // 
            this.priorityLabel.AutoSize = true;
            this.priorityLabel.Location = new System.Drawing.Point(182, 85);
            this.priorityLabel.Name = "priorityLabel";
            this.priorityLabel.Size = new System.Drawing.Size(41, 13);
            this.priorityLabel.TabIndex = 10;
            this.priorityLabel.Text = "Priority:";
            // 
            // categoryLabel
            // 
            this.categoryLabel.Location = new System.Drawing.Point(7, 3);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(71, 13);
            this.categoryLabel.TabIndex = 11;
            this.categoryLabel.Text = "Category:";
            // 
            // priorityComboBox
            // 
            this.priorityComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "Low",
            "Normal",
            "High"});
            this.priorityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.priorityComboBox.Items.AddRange(new object[] {
            "Low",
            "Normal",
            "High"});
            this.priorityComboBox.Location = new System.Drawing.Point(229, 83);
            this.priorityComboBox.Name = "priorityComboBox";
            this.priorityComboBox.Size = new System.Drawing.Size(92, 21);
            this.priorityComboBox.TabIndex = 12;
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
            this.categoryComboBox.Items.AddRange(new object[] {
            "Personal",
            "Business",
            "Education",
            "Family/Friends",
            "Contact",
            "Entertainment"});
            this.categoryComboBox.Location = new System.Drawing.Point(84, 0);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(172, 21);
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
            this.deleteButton,
            this.recurrenceButton});
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
            // recurrenceButton
            // 
            this.recurrenceButton.Image = global::MultiDesktop.Properties.Resources.Recurrence;
            this.recurrenceButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.recurrenceButton.Name = "recurrenceButton";
            this.recurrenceButton.Size = new System.Drawing.Size(86, 22);
            this.recurrenceButton.Text = "Recurrence";
            this.recurrenceButton.Click += new System.EventHandler(this.recurrenceButton_Click);
            // 
            // privateCheckBox
            // 
            this.privateCheckBox.AutoSize = true;
            this.privateCheckBox.Location = new System.Drawing.Point(262, 2);
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
            this.tableLayoutPanel.Controls.Add(this.recurLabel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.topPanel, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.descriptionTextBox, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.bottomPanel, 0, 3);
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(331, 318);
            this.tableLayoutPanel.TabIndex = 22;
            // 
            // recurLabel
            // 
            this.recurLabel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.recurLabel.Location = new System.Drawing.Point(3, 0);
            this.recurLabel.Name = "recurLabel";
            this.recurLabel.Size = new System.Drawing.Size(325, 20);
            this.recurLabel.TabIndex = 15;
            this.recurLabel.Text = "Recur Label";
            this.recurLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.calendarLabel);
            this.topPanel.Controls.Add(this.calendarComboBox);
            this.topPanel.Controls.Add(this.summaryLabel);
            this.topPanel.Controls.Add(this.summaryField);
            this.topPanel.Controls.Add(this.startDateLabel);
            this.topPanel.Controls.Add(this.startDateBox);
            this.topPanel.Controls.Add(this.dueDateBox);
            this.topPanel.Controls.Add(this.dueDateLabel);
            this.topPanel.Controls.Add(this.statusComboBox);
            this.topPanel.Controls.Add(this.priorityComboBox);
            this.topPanel.Controls.Add(this.statusLabel);
            this.topPanel.Controls.Add(this.priorityLabel);
            this.topPanel.Location = new System.Drawing.Point(3, 23);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(325, 108);
            this.topPanel.TabIndex = 0;
            // 
            // startDateBox
            // 
            this.startDateBox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDateBox.Location = new System.Drawing.Point(84, 56);
            this.startDateBox.Name = "startDateBox";
            this.startDateBox.Size = new System.Drawing.Size(92, 20);
            this.startDateBox.TabIndex = 5;
            this.startDateBox.Value = DateTime.MinValue;
            this.startDateBox.ValueChanged += new System.EventHandler(this.startDateBox_ValueChanged);
            // 
            // dueDateBox
            // 
            this.dueDateBox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dueDateBox.Location = new System.Drawing.Point(84, 82);
            this.dueDateBox.Name = "dueDateBox";
            this.dueDateBox.Size = new System.Drawing.Size(92, 20);
            this.dueDateBox.TabIndex = 6;
            this.dueDateBox.Value = DateTime.MinValue;
            this.dueDateBox.ValueChanged += new System.EventHandler(this.dueDateBox_ValueChanged);
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.categoryLabel);
            this.bottomPanel.Controls.Add(this.privateCheckBox);
            this.bottomPanel.Controls.Add(this.categoryComboBox);
            this.bottomPanel.Controls.Add(this.reminderCheckBox);
            this.bottomPanel.Controls.Add(this.alarmButton);
            this.bottomPanel.Controls.Add(this.reminderDate);
            this.bottomPanel.Controls.Add(this.reminderTime);
            this.bottomPanel.Location = new System.Drawing.Point(3, 259);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(325, 55);
            this.bottomPanel.TabIndex = 14;
            // 
            // TodoForm
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(331, 346);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.eventToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "TodoForm";
            this.Text = "Todo";
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

        public TodoForm()
        {
            InitializeComponent();
            
            recurLabel.Hide();
            tableLayoutPanel.RowStyles[0].Height = 0F;
            tableLayoutPanel.RowStyles[2].Height = 142F;

            foreach (string calendarName in Setting.CalendarList.Keys)
            {
                calendarComboBox.Items.Add(calendarName);
            }
            calendarComboBox.SelectedItem = "Personal";
            statusComboBox.SelectedIndex = 0;
            priorityComboBox.SelectedIndex = 0;
            foreach (Category category in Setting.CategoryList)
            {
                categoryComboBox.Items.Add(category.Name);
            }
            categoryComboBox.SelectedIndex = 0;
            deleteButton.Enabled = false;
        }

        public TodoForm(ITodo todo)
        {
            InitializeComponent();
            m_todo = todo;

            if (todo.RecurrenceRules.Count > 0)
            {
                m_recurrence = m_todo.RecurrenceRules[0];
                recurLabel.Text = m_recurrence.ToString();
            }
            else
            {
                recurLabel.Hide();
                tableLayoutPanel.RowStyles[0].Height = 0F;
                tableLayoutPanel.RowStyles[2].Height = 142F;
            }

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
            switch (m_todo.Status)
            {
                case TodoStatus.NeedsAction:
                    statusComboBox.SelectedIndex = 0;
                    break;
                case TodoStatus.InProcess:
                    statusComboBox.SelectedIndex = 1;
                    break;
                case TodoStatus.Completed:
                    statusComboBox.SelectedIndex = 2;
                    break;
                case TodoStatus.Cancelled:
                    statusComboBox.SelectedIndex = 0;
                    break;
            }
            if (m_todo.Priority != 0 && m_todo.Priority <= 3)
                priorityComboBox.SelectedIndex = 2;
            else if (m_todo.Priority != 0 && m_todo.Priority <= 6)
                priorityComboBox.SelectedIndex = 1;
            else
                priorityComboBox.SelectedIndex = 0;
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
                switch (statusComboBox.SelectedItem.ToString())
                {
                    case "Not Started":
                        newTodo.Status = TodoStatus.NeedsAction;
                        break;
                    case "In Progress":
                        newTodo.Status = TodoStatus.InProcess;
                        break;
                    case "Completed":
                        newTodo.Status = TodoStatus.Completed;
                        break;
                }
                if (priorityComboBox.SelectedIndex == 0)
                    newTodo.Priority = 8;
                else if (priorityComboBox.SelectedIndex == 1)
                    newTodo.Priority = 5;
                else
                    newTodo.Priority = 2;
                newTodo.Description = descriptionTextBox.Text;
                newTodo.Categories.Add(categoryComboBox.SelectedItem.ToString());
                if (privateCheckBox.Checked)
                    newTodo.Class = "PRIVATE";
                else
                    newTodo.Class = "PUBLIC";
                if (m_recurrence != null)
                    newTodo.RecurrenceRules.Add(m_recurrence);

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
                switch (statusComboBox.SelectedItem.ToString())
                {
                    case "Not Started":
                        m_todo.Status = TodoStatus.NeedsAction;
                        break;
                    case "In Progress":
                        m_todo.Status = TodoStatus.InProcess;
                        break;
                    case "Completed":
                        m_todo.Status = TodoStatus.Completed;
                        break;
                }
                if (priorityComboBox.SelectedIndex == 0)
                    m_todo.Priority = 8;
                else if (priorityComboBox.SelectedIndex == 1)
                    m_todo.Priority = 5;
                else
                    m_todo.Priority = 2;
                m_todo.Description = descriptionTextBox.Text;
                m_todo.Categories.Clear();
                m_todo.Categories.Add(categoryComboBox.SelectedItem.ToString());
                if(privateCheckBox.Checked)
                    m_todo.Class = "PRIVATE";
                else
                    m_todo.Class = "PUBLIC";
                m_todo.RecurrenceRules.Clear();
                if (m_recurrence != null)
                {
                    m_todo.RecurrenceRules.Add(m_recurrence);
                }

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

        private void recurrenceButton_Click(object sender, EventArgs e)
        {
            RecurrenceDialog dialog;
            if (m_todo == null)
            {
                if (startDateBox.Value != DateTime.MinValue)
                    dialog = new RecurrenceDialog(startDateBox.Value);
                else
                    dialog = new RecurrenceDialog();
            }
            else if (m_recurrence != null)
            {
                dialog = new RecurrenceDialog(m_recurrence, startDateBox.Value);
            }
            else
            {
                if (m_todo.RecurrenceRules.Count > 0)
                    dialog = new RecurrenceDialog(m_todo.RecurrenceRules[0], m_todo.Start.Date);
                else if (m_todo.Start != null)
                    dialog = new RecurrenceDialog(m_todo.Start.Date);
                else
                    dialog = new RecurrenceDialog();
            }

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                m_recurrence = dialog.Pattern;
                startDateBox.Value = dialog.Start;

                if (m_recurrence != null)
                {
                    recurLabel.Show();
                    recurLabel.Text = m_recurrence.ToString();
                    tableLayoutPanel.RowStyles[0].Height = 20F;
                    tableLayoutPanel.RowStyles[2].Height = 122F;
                }
                else
                {
                    recurLabel.Hide();
                    tableLayoutPanel.RowStyles[0].Height = 0F;
                    tableLayoutPanel.RowStyles[2].Height = 142F;
                }
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
