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
    public class EventForm : Form
    {
        private Label calendarLabel;
        private ComboBox calendarComboBox;
        private Label summaryLabel;
        private TextBox summaryField;
        private Label startTimeLabel;
        private DateTimePicker startDateBox;
        private DateTimePicker endDateBox;
        private Label endTimeLabel;
        private Label categoryLabel;
        private RichTextBox descriptionTextBox;
        private ComboBox categoryComboBox;
        private CheckBox reminderCheckBox;
        private Button alarmButton;
        private ToolStrip eventToolStrip;
        private ToolStripButton saveButton;
        private ToolStripButton recurrenceButton;
        private CheckBox privateCheckBox;
        private ToolStripButton deleteButton;
        private DateTimePicker startTimeBox;
        private DateTimePicker endTimeBox;
        private CheckBox allDayBox;
        private ComboBox reminderTimeBox;
        private Label locationLabel;
        private TextBox locationField;
        private Label recurLabel;
        private TableLayoutPanel tableLayoutPanel;
        private Panel topPanel;
        private Panel bottomPanel;

        private Library.DateItem m_dateItem;
        private IRecurrencePattern m_recurrence;
        private TimeSpan m_duration;

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
            this.calendarLabel = new System.Windows.Forms.Label();
            this.calendarComboBox = new System.Windows.Forms.ComboBox();
            this.summaryLabel = new System.Windows.Forms.Label();
            this.summaryField = new System.Windows.Forms.TextBox();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.startDateBox = new System.Windows.Forms.DateTimePicker();
            this.endDateBox = new System.Windows.Forms.DateTimePicker();
            this.endTimeLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.reminderCheckBox = new System.Windows.Forms.CheckBox();
            this.alarmButton = new System.Windows.Forms.Button();
            this.eventToolStrip = new System.Windows.Forms.ToolStrip();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.deleteButton = new System.Windows.Forms.ToolStripButton();
            this.recurrenceButton = new System.Windows.Forms.ToolStripButton();
            this.privateCheckBox = new System.Windows.Forms.CheckBox();
            this.startTimeBox = new System.Windows.Forms.DateTimePicker();
            this.endTimeBox = new System.Windows.Forms.DateTimePicker();
            this.allDayBox = new System.Windows.Forms.CheckBox();
            this.reminderTimeBox = new System.Windows.Forms.ComboBox();
            this.locationLabel = new System.Windows.Forms.Label();
            this.locationField = new System.Windows.Forms.TextBox();
            this.recurLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.eventToolStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // calendarLabel
            // 
            this.calendarLabel.Location = new System.Drawing.Point(10, 6);
            this.calendarLabel.Name = "calendarLabel";
            this.calendarLabel.Size = new System.Drawing.Size(71, 13);
            this.calendarLabel.TabIndex = 0;
            this.calendarLabel.Text = "Calendar:";
            // 
            // calendarComboBox
            // 
            this.calendarComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.calendarComboBox.FormattingEnabled = true;
            this.calendarComboBox.Location = new System.Drawing.Point(87, 3);
            this.calendarComboBox.Name = "calendarComboBox";
            this.calendarComboBox.Size = new System.Drawing.Size(255, 21);
            this.calendarComboBox.TabIndex = 1;
            // 
            // summaryLabel
            // 
            this.summaryLabel.Location = new System.Drawing.Point(10, 33);
            this.summaryLabel.Name = "summaryLabel";
            this.summaryLabel.Size = new System.Drawing.Size(71, 13);
            this.summaryLabel.TabIndex = 2;
            this.summaryLabel.Text = "Summary:";
            // 
            // summaryField
            // 
            this.summaryField.Location = new System.Drawing.Point(87, 30);
            this.summaryField.Name = "summaryField";
            this.summaryField.Size = new System.Drawing.Size(255, 20);
            this.summaryField.TabIndex = 3;
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.Location = new System.Drawing.Point(10, 85);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(71, 13);
            this.startTimeLabel.TabIndex = 4;
            this.startTimeLabel.Text = "Start time:";
            // 
            // startDateBox
            // 
            this.startDateBox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDateBox.Location = new System.Drawing.Point(87, 82);
            this.startDateBox.Name = "startDateBox";
            this.startDateBox.Size = new System.Drawing.Size(92, 20);
            this.startDateBox.TabIndex = 5;
            this.startDateBox.ValueChanged += new System.EventHandler(this.startDateBox_ValueChanged);
            // 
            // endDateBox
            // 
            this.endDateBox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDateBox.Location = new System.Drawing.Point(87, 108);
            this.endDateBox.Name = "endDateBox";
            this.endDateBox.Size = new System.Drawing.Size(92, 20);
            this.endDateBox.TabIndex = 6;
            this.endDateBox.ValueChanged += new System.EventHandler(this.endDateBox_ValueChanged);
            // 
            // endTimeLabel
            // 
            this.endTimeLabel.Location = new System.Drawing.Point(10, 110);
            this.endTimeLabel.Name = "endTimeLabel";
            this.endTimeLabel.Size = new System.Drawing.Size(71, 13);
            this.endTimeLabel.TabIndex = 7;
            this.endTimeLabel.Text = "End time:";
            // 
            // categoryLabel
            // 
            this.categoryLabel.Location = new System.Drawing.Point(10, 6);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(71, 13);
            this.categoryLabel.TabIndex = 11;
            this.categoryLabel.Text = "Category:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionTextBox.Location = new System.Drawing.Point(3, 162);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(348, 116);
            this.descriptionTextBox.TabIndex = 13;
            this.descriptionTextBox.Text = "";
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.Location = new System.Drawing.Point(87, 3);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(190, 21);
            this.categoryComboBox.TabIndex = 15;
            // 
            // reminderCheckBox
            // 
            this.reminderCheckBox.AutoSize = true;
            this.reminderCheckBox.Location = new System.Drawing.Point(7, 32);
            this.reminderCheckBox.Name = "reminderCheckBox";
            this.reminderCheckBox.Size = new System.Drawing.Size(74, 17);
            this.reminderCheckBox.TabIndex = 16;
            this.reminderCheckBox.Text = "Reminder:";
            this.reminderCheckBox.UseVisualStyleBackColor = true;
            this.reminderCheckBox.CheckedChanged += new System.EventHandler(this.reminderCheckBox_CheckedChanged);
            // 
            // alarmButton
            // 
            this.alarmButton.Enabled = false;
            this.alarmButton.Image = global::MultiDesktop.Properties.Resources.Alarm;
            this.alarmButton.Location = new System.Drawing.Point(185, 30);
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
            this.eventToolStrip.Size = new System.Drawing.Size(354, 25);
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
            this.privateCheckBox.Location = new System.Drawing.Point(283, 5);
            this.privateCheckBox.Name = "privateCheckBox";
            this.privateCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.privateCheckBox.Size = new System.Drawing.Size(59, 17);
            this.privateCheckBox.TabIndex = 21;
            this.privateCheckBox.Text = "Private";
            this.privateCheckBox.UseVisualStyleBackColor = true;
            // 
            // startTimeBox
            // 
            this.startTimeBox.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.startTimeBox.Location = new System.Drawing.Point(185, 82);
            this.startTimeBox.Name = "startTimeBox";
            this.startTimeBox.Size = new System.Drawing.Size(92, 20);
            this.startTimeBox.TabIndex = 22;
            // 
            // endTimeBox
            // 
            this.endTimeBox.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.endTimeBox.Location = new System.Drawing.Point(185, 108);
            this.endTimeBox.Name = "endTimeBox";
            this.endTimeBox.Size = new System.Drawing.Size(92, 20);
            this.endTimeBox.TabIndex = 23;
            // 
            // allDayBox
            // 
            this.allDayBox.AutoSize = true;
            this.allDayBox.Location = new System.Drawing.Point(283, 84);
            this.allDayBox.Name = "allDayBox";
            this.allDayBox.Size = new System.Drawing.Size(59, 17);
            this.allDayBox.TabIndex = 24;
            this.allDayBox.Text = "All Day";
            this.allDayBox.UseVisualStyleBackColor = true;
            this.allDayBox.CheckedChanged += new System.EventHandler(this.allDayBox_CheckedChanged);
            // 
            // reminderTimeBox
            // 
            this.reminderTimeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reminderTimeBox.Enabled = false;
            this.reminderTimeBox.FormattingEnabled = true;
            this.reminderTimeBox.Items.AddRange(new object[] {
            "5 minutes",
            "10 minutes",
            "15 minutes",
            "20 minutes",
            "30 minutes",
            "45 minutes",
            "1 hour",
            "2 hours",
            "3 hours",
            "12 hours",
            "1 day",
            "2 days",
            "1 week"});
            this.reminderTimeBox.Location = new System.Drawing.Point(87, 30);
            this.reminderTimeBox.Name = "reminderTimeBox";
            this.reminderTimeBox.Size = new System.Drawing.Size(92, 21);
            this.reminderTimeBox.TabIndex = 25;
            // 
            // locationLabel
            // 
            this.locationLabel.Location = new System.Drawing.Point(10, 59);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(71, 13);
            this.locationLabel.TabIndex = 26;
            this.locationLabel.Text = "Location:";
            this.locationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // locationField
            // 
            this.locationField.Location = new System.Drawing.Point(87, 56);
            this.locationField.Name = "locationField";
            this.locationField.Size = new System.Drawing.Size(253, 20);
            this.locationField.TabIndex = 27;
            // 
            // recurLabel
            // 
            this.recurLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.recurLabel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.recurLabel.Location = new System.Drawing.Point(3, 0);
            this.recurLabel.Name = "recurLabel";
            this.recurLabel.Size = new System.Drawing.Size(348, 20);
            this.recurLabel.TabIndex = 28;
            this.recurLabel.Text = "Recur Label";
            this.recurLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.bottomPanel, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.recurLabel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.descriptionTextBox, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.topPanel, 0, 1);
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(354, 344);
            this.tableLayoutPanel.TabIndex = 29;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.categoryComboBox);
            this.bottomPanel.Controls.Add(this.categoryLabel);
            this.bottomPanel.Controls.Add(this.reminderTimeBox);
            this.bottomPanel.Controls.Add(this.reminderCheckBox);
            this.bottomPanel.Controls.Add(this.privateCheckBox);
            this.bottomPanel.Controls.Add(this.alarmButton);
            this.bottomPanel.Location = new System.Drawing.Point(3, 284);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(348, 57);
            this.bottomPanel.TabIndex = 31;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.calendarComboBox);
            this.topPanel.Controls.Add(this.calendarLabel);
            this.topPanel.Controls.Add(this.locationField);
            this.topPanel.Controls.Add(this.summaryLabel);
            this.topPanel.Controls.Add(this.locationLabel);
            this.topPanel.Controls.Add(this.summaryField);
            this.topPanel.Controls.Add(this.startTimeLabel);
            this.topPanel.Controls.Add(this.allDayBox);
            this.topPanel.Controls.Add(this.startDateBox);
            this.topPanel.Controls.Add(this.endTimeBox);
            this.topPanel.Controls.Add(this.endDateBox);
            this.topPanel.Controls.Add(this.startTimeBox);
            this.topPanel.Controls.Add(this.endTimeLabel);
            this.topPanel.Location = new System.Drawing.Point(3, 23);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(348, 133);
            this.topPanel.TabIndex = 30;
            // 
            // EventForm
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(354, 372);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.eventToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "EventForm";
            this.Text = "Event";
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

        public EventForm()
        {
            InitializeComponent();

            recurLabel.Hide();
            tableLayoutPanel.RowStyles[0].Height = 0F;
            tableLayoutPanel.RowStyles[2].Height = 142F;

            foreach(string calendarName in Setting.CalendarList.Keys)
            {
                calendarComboBox.Items.Add(calendarName);
            }
            calendarComboBox.SelectedItem = "Personal";

            Setting.fillCategory(categoryComboBox);
            categoryComboBox.Items.Add("Anniversary");
            categoryComboBox.Items.Add("Birthday");
            categoryComboBox.Items.Add("Holiday");
            categoryComboBox.SelectedIndex = 0;
            reminderTimeBox.SelectedIndex = 0;
            deleteButton.Enabled = false;
        }

        public EventForm(Library.DateItem dateItem)
        {
            InitializeComponent();
            m_dateItem = dateItem;

            if (m_dateItem.Event.RecurrenceRules.Count > 0)
            {
                m_recurrence = m_dateItem.Event.RecurrenceRules[0];
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
            calendarComboBox.SelectedItem = Setting.findCalendarName(CalendarManager.findCalendarFileName(m_dateItem.Event.Calendar));

            calendarComboBox.Enabled = false;
            summaryField.Text = m_dateItem.Event.Summary;
            locationField.Text = m_dateItem.Event.Location;
            
            if (m_dateItem.Event.Start != null)
                startDateBox.Value = m_dateItem.Event.Start.Date;
            else
                startDateBox.Value = DateTime.Now;
            if (m_dateItem.Event.End != null)
                endDateBox.Value = m_dateItem.Event.End.Date;
            else
                endDateBox.Value = DateTime.Now;
            m_duration = endDateBox.Value - startDateBox.Value;

            if (m_dateItem.Event.IsAllDay)
                allDayBox.Checked = true;
            else
            {
                if (m_dateItem.Event.Start != null)
                    startTimeBox.Value = m_dateItem.Event.Start.Date;
                else
                    startTimeBox.Value = DateTime.Now;
                if (m_dateItem.Event.End != null)
                    endTimeBox.Value = m_dateItem.Event.End.Date;
                else
                    endTimeBox.Value = DateTime.Now;
            }

            descriptionTextBox.Text = m_dateItem.Event.Description;

            Setting.fillCategory(categoryComboBox);
            categoryComboBox.Items.Add("Anniversary");
            categoryComboBox.Items.Add("Birthday");
            categoryComboBox.Items.Add("Holiday");
            if (m_dateItem.Event.Categories.Count != 0)
                categoryComboBox.SelectedItem = m_dateItem.Event.Categories[0];
            else
                categoryComboBox.SelectedItem = "Personal";
            privateCheckBox.Checked = (m_dateItem.Event.Class != null && m_dateItem.Event.Class.ToUpper() == "PRIVATE");
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string calendarName = Setting.CalendarList.Keys[calendarComboBox.SelectedIndex];

            if (m_dateItem == null)
            {
                Event newEvent = CalendarManager.createEvent(Setting.CalendarList[calendarName]);
                
                newEvent.Summary = summaryField.Text;
                newEvent.Location = locationField.Text;

                newEvent.Start = new iCalDateTime(startDateBox.Value);
                newEvent.End = new iCalDateTime(endDateBox.Value);
                if (allDayBox.Checked)
                    newEvent.IsAllDay = true;
                else
                {
                    newEvent.Start.Add(startTimeBox.Value.TimeOfDay);
                    newEvent.End.Add(endTimeBox.Value.TimeOfDay);
                }
                
                newEvent.Description = descriptionTextBox.Text;
                newEvent.Categories.Add(categoryComboBox.SelectedItem.ToString());
                if (privateCheckBox.Checked)
                    newEvent.Class = "PRIVATE";
                else
                    newEvent.Class = "PUBLIC";
                if (m_recurrence != null)
                    newEvent.RecurrenceRules.Add(m_recurrence);
                m_dateItem = new Library.DateItem(newEvent);
                CalendarManager.Calendar.AddDateInfo(m_dateItem);
            }
            else
            {
                m_dateItem.Event.Summary = summaryField.Text;
                m_dateItem.Event.Location = locationField.Text;

                m_dateItem.Event.Start = new iCalDateTime(startDateBox.Value);
                m_dateItem.Event.End = new iCalDateTime(endDateBox.Value);
                if (allDayBox.Checked)
                    m_dateItem.Event.IsAllDay = true;
                else
                {
                    m_dateItem.Event.Start.Add(startTimeBox.Value.TimeOfDay);
                    m_dateItem.Event.End.Add(endTimeBox.Value.TimeOfDay);
                }

                m_dateItem.Event.Description = descriptionTextBox.Text;
                m_dateItem.Event.Categories.Clear();
                m_dateItem.Event.Categories.Add(categoryComboBox.SelectedItem.ToString());
                if(privateCheckBox.Checked)
                    m_dateItem.Event.Class = "PRIVATE";
                else
                    m_dateItem.Event.Class = "PUBLIC";
                m_dateItem.Event.RecurrenceRules.Clear();
                if (m_recurrence != null)
                {
                    m_dateItem.Event.RecurrenceRules.Add(m_recurrence);
                }

                m_dateItem.Update();
            }
            CalendarManager.saveCalendar(Setting.CalendarList[calendarName]);

            Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string filename = CalendarManager.findCalendarFileName(m_dateItem.Event.Calendar);
            CalendarManager.Calendar.RemoveDateInfo(m_dateItem);
            m_dateItem.Event.Calendar.RemoveChild(m_dateItem.Event);

            CalendarManager.saveCalendar(filename);

            Close();
        }

        private void reminderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (reminderCheckBox.Checked)
            {
                reminderTimeBox.Enabled = true;
                alarmButton.Enabled = true;
            }
            else
            {
                reminderTimeBox.Enabled = false;
                alarmButton.Enabled = false;
            }
        }

        private void allDayBox_CheckedChanged(object sender, EventArgs e)
        {
            if (allDayBox.Checked)
            {
                startTimeBox.Enabled = false;
                endTimeBox.Enabled = false;
            }
            else
            {
                startTimeBox.Enabled = true;
                endTimeBox.Enabled = true;
            }
        }

        private void recurrenceButton_Click(object sender, EventArgs e)
        {
            RecurrenceDialog dialog;
            if (m_dateItem == null)
            {
                dialog = new RecurrenceDialog(startDateBox.Value);
            }
            else if (m_recurrence != null)
            {
                dialog = new RecurrenceDialog(m_recurrence, startDateBox.Value);
            }
            else
            {
                if (m_dateItem.Event.RecurrenceRules.Count > 0)
                    dialog = new RecurrenceDialog(m_dateItem.Event.RecurrenceRules[0], m_dateItem.Event.Start.Date);
                else if (m_dateItem.Event.Start != null)
                    dialog = new RecurrenceDialog(m_dateItem.Event.Start.Date);
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
            endDateBox.Value = startDateBox.Value.Add(m_duration);
        }

        private void endDateBox_ValueChanged(object sender, EventArgs e)
        {
            if (endDateBox.Value < startDateBox.Value)
            {
                MessageBox.Show("The end date of an event cannot occur before its start date.");
                endDateBox.Value = startDateBox.Value.Add(m_duration);
            }
            else
            {
                m_duration = endDateBox.Value - startDateBox.Value;
            }
        }
    }
}
