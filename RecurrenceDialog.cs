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
    public class RecurrenceDialog : Form
    {
        private GroupBox recurrencePatternGroup;
        private TableLayoutPanel recurrencePatternLayout;
        private Panel dailyPanel;
        private Panel weeklyPanel;
        private Panel monthlyPanel;
        private Panel yearlyPanel;
        private CheckBox sundayCheckBox;
        private CheckBox thursdayCheckBox;
        private CheckBox mondayCheckBox;
        private CheckBox fridayCheckBox;
        private CheckBox tuesdayCheckBox;
        private CheckBox saturdayCheckBox;
        private CheckBox wednesdayCheckBox;
        private RadioButton dailyRadioButton;
        private RadioButton weeklyRadioButton;
        private RadioButton monthlyRadioButton;
        private RadioButton yearlyRadioButton;
        private Panel patternPanel;
        private Label weeklyRecurLabel;
        private Label weeklyLabel;
        private TextBox numWeekField;
        private RadioButton everyWeekdayRadioButton;
        private RadioButton everyIntervalDayRadioButton;
        private TextBox numDayField;
        private Label dailyLabel;
        private TextBox monthDayField;
        private RadioButton monthRadioButton;
        private RadioButton dayMonthRadioButton;
        private ComboBox monthOrderBox;
        private Label monthLabel1;
        private TextBox numMonthField1;
        private Label everyMonthLabel1;
        private Label monthLabel2;
        private TextBox numMonthField2;
        private Label everyMonthLabel2;
        private ComboBox monthDayBox;
        private GroupBox recurrenceRangeGroup;
        private RadioButton endByRadioButton;
        private RadioButton endAfterRadioButton;
        private RadioButton noEndDateRadioButton;
        private DateTimePicker startDateBox;
        private Label startDateLabel;
        private Label occurrencesLabel;
        private TextBox numOccurrencesField;
        private DateTimePicker endDateBox;
        private Button okButton;
        private Button cancelButton;
        private Button removeRecurrenceButton;
        private Label endDateLabel;
        private RadioButton yearRadioButton;
        private RadioButton recurYearlyRadioButton;
        private ComboBox monthBox1;
        private ComboBox monthBox2;
        private Label yearOfLabel;
        private ComboBox yearDayBox;
        private ComboBox yearDayOrderBox;
        private TextBox yearDayField;
        private Label yearLabel;
        private TextBox numYearField;
        private Label yearEveryLabel;

        private IRecurrencePattern m_pattern;

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
            this.recurrencePatternGroup = new System.Windows.Forms.GroupBox();
            this.recurrencePatternLayout = new System.Windows.Forms.TableLayoutPanel();
            this.patternPanel = new System.Windows.Forms.Panel();
            this.yearlyRadioButton = new System.Windows.Forms.RadioButton();
            this.dailyRadioButton = new System.Windows.Forms.RadioButton();
            this.weeklyRadioButton = new System.Windows.Forms.RadioButton();
            this.monthlyRadioButton = new System.Windows.Forms.RadioButton();
            this.yearlyPanel = new System.Windows.Forms.Panel();
            this.yearLabel = new System.Windows.Forms.Label();
            this.numYearField = new System.Windows.Forms.TextBox();
            this.yearEveryLabel = new System.Windows.Forms.Label();
            this.yearDayField = new System.Windows.Forms.TextBox();
            this.monthBox2 = new System.Windows.Forms.ComboBox();
            this.yearOfLabel = new System.Windows.Forms.Label();
            this.yearDayBox = new System.Windows.Forms.ComboBox();
            this.yearDayOrderBox = new System.Windows.Forms.ComboBox();
            this.monthBox1 = new System.Windows.Forms.ComboBox();
            this.yearRadioButton = new System.Windows.Forms.RadioButton();
            this.recurYearlyRadioButton = new System.Windows.Forms.RadioButton();
            this.monthlyPanel = new System.Windows.Forms.Panel();
            this.monthLabel2 = new System.Windows.Forms.Label();
            this.numMonthField2 = new System.Windows.Forms.TextBox();
            this.everyMonthLabel2 = new System.Windows.Forms.Label();
            this.monthDayBox = new System.Windows.Forms.ComboBox();
            this.monthOrderBox = new System.Windows.Forms.ComboBox();
            this.monthLabel1 = new System.Windows.Forms.Label();
            this.numMonthField1 = new System.Windows.Forms.TextBox();
            this.everyMonthLabel1 = new System.Windows.Forms.Label();
            this.monthDayField = new System.Windows.Forms.TextBox();
            this.monthRadioButton = new System.Windows.Forms.RadioButton();
            this.dayMonthRadioButton = new System.Windows.Forms.RadioButton();
            this.weeklyPanel = new System.Windows.Forms.Panel();
            this.weeklyLabel = new System.Windows.Forms.Label();
            this.numWeekField = new System.Windows.Forms.TextBox();
            this.weeklyRecurLabel = new System.Windows.Forms.Label();
            this.wednesdayCheckBox = new System.Windows.Forms.CheckBox();
            this.saturdayCheckBox = new System.Windows.Forms.CheckBox();
            this.sundayCheckBox = new System.Windows.Forms.CheckBox();
            this.tuesdayCheckBox = new System.Windows.Forms.CheckBox();
            this.thursdayCheckBox = new System.Windows.Forms.CheckBox();
            this.fridayCheckBox = new System.Windows.Forms.CheckBox();
            this.mondayCheckBox = new System.Windows.Forms.CheckBox();
            this.dailyPanel = new System.Windows.Forms.Panel();
            this.dailyLabel = new System.Windows.Forms.Label();
            this.numDayField = new System.Windows.Forms.TextBox();
            this.everyWeekdayRadioButton = new System.Windows.Forms.RadioButton();
            this.everyIntervalDayRadioButton = new System.Windows.Forms.RadioButton();
            this.recurrenceRangeGroup = new System.Windows.Forms.GroupBox();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.occurrencesLabel = new System.Windows.Forms.Label();
            this.numOccurrencesField = new System.Windows.Forms.TextBox();
            this.endDateBox = new System.Windows.Forms.DateTimePicker();
            this.endByRadioButton = new System.Windows.Forms.RadioButton();
            this.endAfterRadioButton = new System.Windows.Forms.RadioButton();
            this.noEndDateRadioButton = new System.Windows.Forms.RadioButton();
            this.startDateBox = new System.Windows.Forms.DateTimePicker();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.removeRecurrenceButton = new System.Windows.Forms.Button();
            this.recurrencePatternGroup.SuspendLayout();
            this.recurrencePatternLayout.SuspendLayout();
            this.patternPanel.SuspendLayout();
            this.yearlyPanel.SuspendLayout();
            this.monthlyPanel.SuspendLayout();
            this.weeklyPanel.SuspendLayout();
            this.dailyPanel.SuspendLayout();
            this.recurrenceRangeGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // recurrencePatternGroup
            // 
            this.recurrencePatternGroup.Controls.Add(this.recurrencePatternLayout);
            this.recurrencePatternGroup.Location = new System.Drawing.Point(12, 12);
            this.recurrencePatternGroup.Name = "recurrencePatternGroup";
            this.recurrencePatternGroup.Size = new System.Drawing.Size(454, 121);
            this.recurrencePatternGroup.TabIndex = 1;
            this.recurrencePatternGroup.TabStop = false;
            this.recurrencePatternGroup.Text = "Recurrence Pattern";
            // 
            // recurrencePatternLayout
            // 
            this.recurrencePatternLayout.ColumnCount = 2;
            this.recurrencePatternLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.51584F));
            this.recurrencePatternLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.48416F));
            this.recurrencePatternLayout.Controls.Add(this.patternPanel, 0, 0);
            this.recurrencePatternLayout.Controls.Add(this.weeklyPanel, 1, 0);
            this.recurrencePatternLayout.Location = new System.Drawing.Point(6, 19);
            this.recurrencePatternLayout.Name = "recurrencePatternLayout";
            this.recurrencePatternLayout.RowCount = 1;
            this.recurrencePatternLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.recurrencePatternLayout.Size = new System.Drawing.Size(442, 96);
            this.recurrencePatternLayout.TabIndex = 0;
            // 
            // patternPanel
            // 
            this.patternPanel.Controls.Add(this.yearlyRadioButton);
            this.patternPanel.Controls.Add(this.dailyRadioButton);
            this.patternPanel.Controls.Add(this.weeklyRadioButton);
            this.patternPanel.Controls.Add(this.monthlyRadioButton);
            this.patternPanel.Location = new System.Drawing.Point(3, 3);
            this.patternPanel.Name = "patternPanel";
            this.patternPanel.Size = new System.Drawing.Size(66, 90);
            this.patternPanel.TabIndex = 9;
            // 
            // yearlyRadioButton
            // 
            this.yearlyRadioButton.AutoSize = true;
            this.yearlyRadioButton.Location = new System.Drawing.Point(3, 70);
            this.yearlyRadioButton.Name = "yearlyRadioButton";
            this.yearlyRadioButton.Size = new System.Drawing.Size(54, 17);
            this.yearlyRadioButton.TabIndex = 3;
            this.yearlyRadioButton.TabStop = true;
            this.yearlyRadioButton.Text = "Yearly";
            this.yearlyRadioButton.UseVisualStyleBackColor = true;
            this.yearlyRadioButton.CheckedChanged += new System.EventHandler(this.yearlyRadioButton_CheckedChanged);
            // 
            // dailyRadioButton
            // 
            this.dailyRadioButton.AutoSize = true;
            this.dailyRadioButton.Location = new System.Drawing.Point(3, 3);
            this.dailyRadioButton.Name = "dailyRadioButton";
            this.dailyRadioButton.Size = new System.Drawing.Size(48, 17);
            this.dailyRadioButton.TabIndex = 0;
            this.dailyRadioButton.TabStop = true;
            this.dailyRadioButton.Text = "Daily";
            this.dailyRadioButton.UseVisualStyleBackColor = true;
            this.dailyRadioButton.CheckedChanged += new System.EventHandler(this.dailyRadioButton_CheckedChanged);
            // 
            // weeklyRadioButton
            // 
            this.weeklyRadioButton.AutoSize = true;
            this.weeklyRadioButton.Checked = true;
            this.weeklyRadioButton.Location = new System.Drawing.Point(3, 26);
            this.weeklyRadioButton.Name = "weeklyRadioButton";
            this.weeklyRadioButton.Size = new System.Drawing.Size(61, 17);
            this.weeklyRadioButton.TabIndex = 1;
            this.weeklyRadioButton.TabStop = true;
            this.weeklyRadioButton.Text = "Weekly";
            this.weeklyRadioButton.UseVisualStyleBackColor = true;
            this.weeklyRadioButton.CheckedChanged += new System.EventHandler(this.weeklyRadioButton_CheckedChanged);
            // 
            // monthlyRadioButton
            // 
            this.monthlyRadioButton.AutoSize = true;
            this.monthlyRadioButton.Location = new System.Drawing.Point(3, 49);
            this.monthlyRadioButton.Name = "monthlyRadioButton";
            this.monthlyRadioButton.Size = new System.Drawing.Size(62, 17);
            this.monthlyRadioButton.TabIndex = 2;
            this.monthlyRadioButton.TabStop = true;
            this.monthlyRadioButton.Text = "Monthly";
            this.monthlyRadioButton.UseVisualStyleBackColor = true;
            this.monthlyRadioButton.CheckedChanged += new System.EventHandler(this.monthlyRadioButton_CheckedChanged);
            // 
            // yearlyPanel
            // 
            this.yearlyPanel.Controls.Add(this.yearLabel);
            this.yearlyPanel.Controls.Add(this.numYearField);
            this.yearlyPanel.Controls.Add(this.yearEveryLabel);
            this.yearlyPanel.Controls.Add(this.yearDayField);
            this.yearlyPanel.Controls.Add(this.monthBox2);
            this.yearlyPanel.Controls.Add(this.yearOfLabel);
            this.yearlyPanel.Controls.Add(this.yearDayBox);
            this.yearlyPanel.Controls.Add(this.yearDayOrderBox);
            this.yearlyPanel.Controls.Add(this.monthBox1);
            this.yearlyPanel.Controls.Add(this.yearRadioButton);
            this.yearlyPanel.Controls.Add(this.recurYearlyRadioButton);
            this.yearlyPanel.Location = new System.Drawing.Point(76, 3);
            this.yearlyPanel.Name = "yearlyPanel";
            this.yearlyPanel.Size = new System.Drawing.Size(363, 90);
            this.yearlyPanel.TabIndex = 0;
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Location = new System.Drawing.Point(274, 5);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(38, 13);
            this.yearLabel.TabIndex = 12;
            this.yearLabel.Text = "year(s)";
            // 
            // numYearField
            // 
            this.numYearField.Location = new System.Drawing.Point(241, 2);
            this.numYearField.Name = "numYearField";
            this.numYearField.Size = new System.Drawing.Size(27, 20);
            this.numYearField.TabIndex = 11;
            this.numYearField.Text = "1";
            // 
            // yearEveryLabel
            // 
            this.yearEveryLabel.AutoSize = true;
            this.yearEveryLabel.Location = new System.Drawing.Point(190, 5);
            this.yearEveryLabel.Name = "yearEveryLabel";
            this.yearEveryLabel.Size = new System.Drawing.Size(45, 13);
            this.yearEveryLabel.TabIndex = 10;
            this.yearEveryLabel.Text = "of every";
            // 
            // yearDayField
            // 
            this.yearDayField.Location = new System.Drawing.Point(157, 2);
            this.yearDayField.Name = "yearDayField";
            this.yearDayField.Size = new System.Drawing.Size(27, 20);
            this.yearDayField.TabIndex = 9;
            // 
            // monthBox2
            // 
            this.monthBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthBox2.FormattingEnabled = true;
            this.monthBox2.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.monthBox2.Location = new System.Drawing.Point(263, 25);
            this.monthBox2.Name = "monthBox2";
            this.monthBox2.Size = new System.Drawing.Size(88, 21);
            this.monthBox2.TabIndex = 6;
            // 
            // yearOfLabel
            // 
            this.yearOfLabel.AutoSize = true;
            this.yearOfLabel.Location = new System.Drawing.Point(241, 28);
            this.yearOfLabel.Name = "yearOfLabel";
            this.yearOfLabel.Size = new System.Drawing.Size(16, 13);
            this.yearOfLabel.TabIndex = 5;
            this.yearOfLabel.Text = "of";
            // 
            // yearDayBox
            // 
            this.yearDayBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearDayBox.FormattingEnabled = true;
            this.yearDayBox.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
            this.yearDayBox.Location = new System.Drawing.Point(147, 25);
            this.yearDayBox.Name = "yearDayBox";
            this.yearDayBox.Size = new System.Drawing.Size(88, 21);
            this.yearDayBox.TabIndex = 4;
            // 
            // yearDayOrderBox
            // 
            this.yearDayOrderBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearDayOrderBox.FormattingEnabled = true;
            this.yearDayOrderBox.Items.AddRange(new object[] {
            "first",
            "second",
            "third",
            "fourth",
            "last"});
            this.yearDayOrderBox.Location = new System.Drawing.Point(53, 25);
            this.yearDayOrderBox.Name = "yearDayOrderBox";
            this.yearDayOrderBox.Size = new System.Drawing.Size(88, 21);
            this.yearDayOrderBox.TabIndex = 3;
            // 
            // monthBox1
            // 
            this.monthBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthBox1.FormattingEnabled = true;
            this.monthBox1.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.monthBox1.Location = new System.Drawing.Point(63, 2);
            this.monthBox1.Name = "monthBox1";
            this.monthBox1.Size = new System.Drawing.Size(88, 21);
            this.monthBox1.TabIndex = 2;
            // 
            // yearRadioButton
            // 
            this.yearRadioButton.AutoSize = true;
            this.yearRadioButton.Location = new System.Drawing.Point(3, 26);
            this.yearRadioButton.Name = "yearRadioButton";
            this.yearRadioButton.Size = new System.Drawing.Size(44, 17);
            this.yearRadioButton.TabIndex = 1;
            this.yearRadioButton.Text = "The";
            this.yearRadioButton.UseVisualStyleBackColor = true;
            // 
            // recurYearlyRadioButton
            // 
            this.recurYearlyRadioButton.AutoSize = true;
            this.recurYearlyRadioButton.Checked = true;
            this.recurYearlyRadioButton.Location = new System.Drawing.Point(3, 3);
            this.recurYearlyRadioButton.Name = "recurYearlyRadioButton";
            this.recurYearlyRadioButton.Size = new System.Drawing.Size(54, 17);
            this.recurYearlyRadioButton.TabIndex = 0;
            this.recurYearlyRadioButton.TabStop = true;
            this.recurYearlyRadioButton.Text = "Recur";
            this.recurYearlyRadioButton.UseVisualStyleBackColor = true;
            // 
            // monthlyPanel
            // 
            this.monthlyPanel.Controls.Add(this.monthLabel2);
            this.monthlyPanel.Controls.Add(this.numMonthField2);
            this.monthlyPanel.Controls.Add(this.everyMonthLabel2);
            this.monthlyPanel.Controls.Add(this.monthDayBox);
            this.monthlyPanel.Controls.Add(this.monthOrderBox);
            this.monthlyPanel.Controls.Add(this.monthLabel1);
            this.monthlyPanel.Controls.Add(this.numMonthField1);
            this.monthlyPanel.Controls.Add(this.everyMonthLabel1);
            this.monthlyPanel.Controls.Add(this.monthDayField);
            this.monthlyPanel.Controls.Add(this.monthRadioButton);
            this.monthlyPanel.Controls.Add(this.dayMonthRadioButton);
            this.monthlyPanel.Location = new System.Drawing.Point(76, 3);
            this.monthlyPanel.Name = "monthlyPanel";
            this.monthlyPanel.Size = new System.Drawing.Size(363, 90);
            this.monthlyPanel.TabIndex = 0;
            // 
            // monthLabel2
            // 
            this.monthLabel2.AutoSize = true;
            this.monthLabel2.Location = new System.Drawing.Point(309, 28);
            this.monthLabel2.Name = "monthLabel2";
            this.monthLabel2.Size = new System.Drawing.Size(47, 13);
            this.monthLabel2.TabIndex = 10;
            this.monthLabel2.Text = "month(s)";
            // 
            // numMonthField2
            // 
            this.numMonthField2.Location = new System.Drawing.Point(276, 25);
            this.numMonthField2.Name = "numMonthField2";
            this.numMonthField2.Size = new System.Drawing.Size(27, 20);
            this.numMonthField2.TabIndex = 9;
            this.numMonthField2.Text = "1";
            // 
            // everyMonthLabel2
            // 
            this.everyMonthLabel2.AutoSize = true;
            this.everyMonthLabel2.Location = new System.Drawing.Point(225, 28);
            this.everyMonthLabel2.Name = "everyMonthLabel2";
            this.everyMonthLabel2.Size = new System.Drawing.Size(45, 13);
            this.everyMonthLabel2.TabIndex = 8;
            this.everyMonthLabel2.Text = "of every";
            // 
            // monthDayBox
            // 
            this.monthDayBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthDayBox.FormattingEnabled = true;
            this.monthDayBox.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
            this.monthDayBox.Location = new System.Drawing.Point(128, 25);
            this.monthDayBox.Name = "monthDayBox";
            this.monthDayBox.Size = new System.Drawing.Size(91, 21);
            this.monthDayBox.TabIndex = 7;
            // 
            // monthOrderBox
            // 
            this.monthOrderBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthOrderBox.FormattingEnabled = true;
            this.monthOrderBox.Items.AddRange(new object[] {
            "first",
            "second",
            "third",
            "fourth",
            "last"});
            this.monthOrderBox.Location = new System.Drawing.Point(53, 25);
            this.monthOrderBox.Name = "monthOrderBox";
            this.monthOrderBox.Size = new System.Drawing.Size(69, 21);
            this.monthOrderBox.TabIndex = 6;
            // 
            // monthLabel1
            // 
            this.monthLabel1.AutoSize = true;
            this.monthLabel1.Location = new System.Drawing.Point(170, 5);
            this.monthLabel1.Name = "monthLabel1";
            this.monthLabel1.Size = new System.Drawing.Size(47, 13);
            this.monthLabel1.TabIndex = 5;
            this.monthLabel1.Text = "month(s)";
            // 
            // numMonthField1
            // 
            this.numMonthField1.Location = new System.Drawing.Point(137, 2);
            this.numMonthField1.Name = "numMonthField1";
            this.numMonthField1.Size = new System.Drawing.Size(27, 20);
            this.numMonthField1.TabIndex = 4;
            this.numMonthField1.Text = "1";
            // 
            // everyMonthLabel1
            // 
            this.everyMonthLabel1.AutoSize = true;
            this.everyMonthLabel1.Location = new System.Drawing.Point(86, 5);
            this.everyMonthLabel1.Name = "everyMonthLabel1";
            this.everyMonthLabel1.Size = new System.Drawing.Size(45, 13);
            this.everyMonthLabel1.TabIndex = 3;
            this.everyMonthLabel1.Text = "of every";
            // 
            // monthDayField
            // 
            this.monthDayField.Location = new System.Drawing.Point(53, 2);
            this.monthDayField.Name = "monthDayField";
            this.monthDayField.Size = new System.Drawing.Size(27, 20);
            this.monthDayField.TabIndex = 2;
            // 
            // monthRadioButton
            // 
            this.monthRadioButton.AutoSize = true;
            this.monthRadioButton.Location = new System.Drawing.Point(3, 26);
            this.monthRadioButton.Name = "monthRadioButton";
            this.monthRadioButton.Size = new System.Drawing.Size(44, 17);
            this.monthRadioButton.TabIndex = 1;
            this.monthRadioButton.Text = "The";
            this.monthRadioButton.UseVisualStyleBackColor = true;
            // 
            // dayMonthRadioButton
            // 
            this.dayMonthRadioButton.AutoSize = true;
            this.dayMonthRadioButton.Checked = true;
            this.dayMonthRadioButton.Location = new System.Drawing.Point(3, 3);
            this.dayMonthRadioButton.Name = "dayMonthRadioButton";
            this.dayMonthRadioButton.Size = new System.Drawing.Size(44, 17);
            this.dayMonthRadioButton.TabIndex = 0;
            this.dayMonthRadioButton.TabStop = true;
            this.dayMonthRadioButton.Text = "Day";
            this.dayMonthRadioButton.UseVisualStyleBackColor = true;
            // 
            // weeklyPanel
            // 
            this.weeklyPanel.Controls.Add(this.weeklyLabel);
            this.weeklyPanel.Controls.Add(this.numWeekField);
            this.weeklyPanel.Controls.Add(this.weeklyRecurLabel);
            this.weeklyPanel.Controls.Add(this.wednesdayCheckBox);
            this.weeklyPanel.Controls.Add(this.saturdayCheckBox);
            this.weeklyPanel.Controls.Add(this.sundayCheckBox);
            this.weeklyPanel.Controls.Add(this.tuesdayCheckBox);
            this.weeklyPanel.Controls.Add(this.thursdayCheckBox);
            this.weeklyPanel.Controls.Add(this.fridayCheckBox);
            this.weeklyPanel.Controls.Add(this.mondayCheckBox);
            this.weeklyPanel.Location = new System.Drawing.Point(76, 3);
            this.weeklyPanel.Name = "weeklyPanel";
            this.weeklyPanel.Size = new System.Drawing.Size(363, 90);
            this.weeklyPanel.TabIndex = 0;
            // 
            // weeklyLabel
            // 
            this.weeklyLabel.AutoSize = true;
            this.weeklyLabel.Location = new System.Drawing.Point(107, 5);
            this.weeklyLabel.Name = "weeklyLabel";
            this.weeklyLabel.Size = new System.Drawing.Size(62, 13);
            this.weeklyLabel.TabIndex = 11;
            this.weeklyLabel.Text = "week(s) on:";
            // 
            // numWeekField
            // 
            this.numWeekField.Location = new System.Drawing.Point(74, 2);
            this.numWeekField.Name = "numWeekField";
            this.numWeekField.Size = new System.Drawing.Size(27, 20);
            this.numWeekField.TabIndex = 10;
            this.numWeekField.Text = "1";
            // 
            // weeklyRecurLabel
            // 
            this.weeklyRecurLabel.AutoSize = true;
            this.weeklyRecurLabel.Location = new System.Drawing.Point(3, 5);
            this.weeklyRecurLabel.Name = "weeklyRecurLabel";
            this.weeklyRecurLabel.Size = new System.Drawing.Size(65, 13);
            this.weeklyRecurLabel.TabIndex = 9;
            this.weeklyRecurLabel.Text = "Recur every";
            // 
            // wednesdayCheckBox
            // 
            this.wednesdayCheckBox.AutoSize = true;
            this.wednesdayCheckBox.Location = new System.Drawing.Point(279, 27);
            this.wednesdayCheckBox.Name = "wednesdayCheckBox";
            this.wednesdayCheckBox.Size = new System.Drawing.Size(83, 17);
            this.wednesdayCheckBox.TabIndex = 8;
            this.wednesdayCheckBox.Text = "Wednesday";
            this.wednesdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // saturdayCheckBox
            // 
            this.saturdayCheckBox.AutoSize = true;
            this.saturdayCheckBox.Location = new System.Drawing.Point(193, 50);
            this.saturdayCheckBox.Name = "saturdayCheckBox";
            this.saturdayCheckBox.Size = new System.Drawing.Size(68, 17);
            this.saturdayCheckBox.TabIndex = 7;
            this.saturdayCheckBox.Text = "Saturday";
            this.saturdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // sundayCheckBox
            // 
            this.sundayCheckBox.AutoSize = true;
            this.sundayCheckBox.Location = new System.Drawing.Point(21, 27);
            this.sundayCheckBox.Name = "sundayCheckBox";
            this.sundayCheckBox.Size = new System.Drawing.Size(62, 17);
            this.sundayCheckBox.TabIndex = 2;
            this.sundayCheckBox.Text = "Sunday";
            this.sundayCheckBox.UseVisualStyleBackColor = true;
            // 
            // tuesdayCheckBox
            // 
            this.tuesdayCheckBox.AutoSize = true;
            this.tuesdayCheckBox.Location = new System.Drawing.Point(193, 26);
            this.tuesdayCheckBox.Name = "tuesdayCheckBox";
            this.tuesdayCheckBox.Size = new System.Drawing.Size(67, 17);
            this.tuesdayCheckBox.TabIndex = 6;
            this.tuesdayCheckBox.Text = "Tuesday";
            this.tuesdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // thursdayCheckBox
            // 
            this.thursdayCheckBox.AutoSize = true;
            this.thursdayCheckBox.Location = new System.Drawing.Point(21, 50);
            this.thursdayCheckBox.Name = "thursdayCheckBox";
            this.thursdayCheckBox.Size = new System.Drawing.Size(70, 17);
            this.thursdayCheckBox.TabIndex = 3;
            this.thursdayCheckBox.Text = "Thursday";
            this.thursdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // fridayCheckBox
            // 
            this.fridayCheckBox.AutoSize = true;
            this.fridayCheckBox.Location = new System.Drawing.Point(107, 49);
            this.fridayCheckBox.Name = "fridayCheckBox";
            this.fridayCheckBox.Size = new System.Drawing.Size(54, 17);
            this.fridayCheckBox.TabIndex = 5;
            this.fridayCheckBox.Text = "Friday";
            this.fridayCheckBox.UseVisualStyleBackColor = true;
            // 
            // mondayCheckBox
            // 
            this.mondayCheckBox.AutoSize = true;
            this.mondayCheckBox.Location = new System.Drawing.Point(107, 26);
            this.mondayCheckBox.Name = "mondayCheckBox";
            this.mondayCheckBox.Size = new System.Drawing.Size(64, 17);
            this.mondayCheckBox.TabIndex = 4;
            this.mondayCheckBox.Text = "Monday";
            this.mondayCheckBox.UseVisualStyleBackColor = true;
            // 
            // dailyPanel
            // 
            this.dailyPanel.Controls.Add(this.dailyLabel);
            this.dailyPanel.Controls.Add(this.numDayField);
            this.dailyPanel.Controls.Add(this.everyWeekdayRadioButton);
            this.dailyPanel.Controls.Add(this.everyIntervalDayRadioButton);
            this.dailyPanel.Location = new System.Drawing.Point(76, 3);
            this.dailyPanel.Name = "dailyPanel";
            this.dailyPanel.Size = new System.Drawing.Size(363, 90);
            this.dailyPanel.TabIndex = 0;
            // 
            // dailyLabel
            // 
            this.dailyLabel.AutoSize = true;
            this.dailyLabel.Location = new System.Drawing.Point(95, 5);
            this.dailyLabel.Name = "dailyLabel";
            this.dailyLabel.Size = new System.Drawing.Size(35, 13);
            this.dailyLabel.TabIndex = 3;
            this.dailyLabel.Text = "day(s)";
            // 
            // numDayField
            // 
            this.numDayField.Location = new System.Drawing.Point(62, 2);
            this.numDayField.Name = "numDayField";
            this.numDayField.Size = new System.Drawing.Size(27, 20);
            this.numDayField.TabIndex = 2;
            this.numDayField.Text = "1";
            // 
            // everyWeekdayRadioButton
            // 
            this.everyWeekdayRadioButton.AutoSize = true;
            this.everyWeekdayRadioButton.Location = new System.Drawing.Point(4, 26);
            this.everyWeekdayRadioButton.Name = "everyWeekdayRadioButton";
            this.everyWeekdayRadioButton.Size = new System.Drawing.Size(98, 17);
            this.everyWeekdayRadioButton.TabIndex = 1;
            this.everyWeekdayRadioButton.Text = "Every weekday";
            this.everyWeekdayRadioButton.UseVisualStyleBackColor = true;
            // 
            // everyIntervalDayRadioButton
            // 
            this.everyIntervalDayRadioButton.AutoSize = true;
            this.everyIntervalDayRadioButton.Checked = true;
            this.everyIntervalDayRadioButton.Location = new System.Drawing.Point(4, 3);
            this.everyIntervalDayRadioButton.Name = "everyIntervalDayRadioButton";
            this.everyIntervalDayRadioButton.Size = new System.Drawing.Size(52, 17);
            this.everyIntervalDayRadioButton.TabIndex = 0;
            this.everyIntervalDayRadioButton.TabStop = true;
            this.everyIntervalDayRadioButton.Text = "Every";
            this.everyIntervalDayRadioButton.UseVisualStyleBackColor = true;
            // 
            // recurrenceRangeGroup
            // 
            this.recurrenceRangeGroup.Controls.Add(this.endDateLabel);
            this.recurrenceRangeGroup.Controls.Add(this.occurrencesLabel);
            this.recurrenceRangeGroup.Controls.Add(this.numOccurrencesField);
            this.recurrenceRangeGroup.Controls.Add(this.endDateBox);
            this.recurrenceRangeGroup.Controls.Add(this.endByRadioButton);
            this.recurrenceRangeGroup.Controls.Add(this.endAfterRadioButton);
            this.recurrenceRangeGroup.Controls.Add(this.noEndDateRadioButton);
            this.recurrenceRangeGroup.Controls.Add(this.startDateBox);
            this.recurrenceRangeGroup.Controls.Add(this.startDateLabel);
            this.recurrenceRangeGroup.Location = new System.Drawing.Point(12, 139);
            this.recurrenceRangeGroup.Name = "recurrenceRangeGroup";
            this.recurrenceRangeGroup.Size = new System.Drawing.Size(454, 112);
            this.recurrenceRangeGroup.TabIndex = 2;
            this.recurrenceRangeGroup.TabStop = false;
            this.recurrenceRangeGroup.Text = "Range of recurrence";
            // 
            // endDateLabel
            // 
            this.endDateLabel.AutoSize = true;
            this.endDateLabel.Location = new System.Drawing.Point(6, 42);
            this.endDateLabel.Name = "endDateLabel";
            this.endDateLabel.Size = new System.Drawing.Size(29, 13);
            this.endDateLabel.TabIndex = 8;
            this.endDateLabel.Text = "End:";
            // 
            // occurrencesLabel
            // 
            this.occurrencesLabel.AutoSize = true;
            this.occurrencesLabel.Location = new System.Drawing.Point(154, 65);
            this.occurrencesLabel.Name = "occurrencesLabel";
            this.occurrencesLabel.Size = new System.Drawing.Size(66, 13);
            this.occurrencesLabel.TabIndex = 7;
            this.occurrencesLabel.Text = "occurrences";
            // 
            // numOccurrencesField
            // 
            this.numOccurrencesField.Location = new System.Drawing.Point(121, 62);
            this.numOccurrencesField.Name = "numOccurrencesField";
            this.numOccurrencesField.Size = new System.Drawing.Size(27, 20);
            this.numOccurrencesField.TabIndex = 6;
            this.numOccurrencesField.Text = "10";
            // 
            // endDateBox
            // 
            this.endDateBox.Location = new System.Drawing.Point(111, 86);
            this.endDateBox.Name = "endDateBox";
            this.endDateBox.Size = new System.Drawing.Size(179, 20);
            this.endDateBox.TabIndex = 5;
            // 
            // endByRadioButton
            // 
            this.endByRadioButton.AutoSize = true;
            this.endByRadioButton.Location = new System.Drawing.Point(44, 86);
            this.endByRadioButton.Name = "endByRadioButton";
            this.endByRadioButton.Size = new System.Drawing.Size(61, 17);
            this.endByRadioButton.TabIndex = 4;
            this.endByRadioButton.TabStop = true;
            this.endByRadioButton.Text = "End by:";
            this.endByRadioButton.UseVisualStyleBackColor = true;
            // 
            // endAfterRadioButton
            // 
            this.endAfterRadioButton.AutoSize = true;
            this.endAfterRadioButton.Location = new System.Drawing.Point(44, 63);
            this.endAfterRadioButton.Name = "endAfterRadioButton";
            this.endAfterRadioButton.Size = new System.Drawing.Size(71, 17);
            this.endAfterRadioButton.TabIndex = 3;
            this.endAfterRadioButton.TabStop = true;
            this.endAfterRadioButton.Text = "End after:";
            this.endAfterRadioButton.UseVisualStyleBackColor = true;
            // 
            // noEndDateRadioButton
            // 
            this.noEndDateRadioButton.AutoSize = true;
            this.noEndDateRadioButton.Checked = true;
            this.noEndDateRadioButton.Location = new System.Drawing.Point(44, 40);
            this.noEndDateRadioButton.Name = "noEndDateRadioButton";
            this.noEndDateRadioButton.Size = new System.Drawing.Size(84, 17);
            this.noEndDateRadioButton.TabIndex = 2;
            this.noEndDateRadioButton.TabStop = true;
            this.noEndDateRadioButton.Text = "No end date";
            this.noEndDateRadioButton.UseVisualStyleBackColor = true;
            // 
            // startDateBox
            // 
            this.startDateBox.Location = new System.Drawing.Point(44, 14);
            this.startDateBox.Name = "startDateBox";
            this.startDateBox.Size = new System.Drawing.Size(179, 20);
            this.startDateBox.TabIndex = 1;
            // 
            // startDateLabel
            // 
            this.startDateLabel.AutoSize = true;
            this.startDateLabel.Location = new System.Drawing.Point(6, 16);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(32, 13);
            this.startDateLabel.TabIndex = 0;
            this.startDateLabel.Text = "Start:";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(123, 257);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(204, 257);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // removeRecurrenceButton
            // 
            this.removeRecurrenceButton.Location = new System.Drawing.Point(285, 257);
            this.removeRecurrenceButton.Name = "removeRecurrenceButton";
            this.removeRecurrenceButton.Size = new System.Drawing.Size(134, 23);
            this.removeRecurrenceButton.TabIndex = 5;
            this.removeRecurrenceButton.Text = "Remove Recurrence";
            this.removeRecurrenceButton.UseVisualStyleBackColor = true;
            this.removeRecurrenceButton.Click += new System.EventHandler(this.removeRecurrenceButton_Click);
            // 
            // RecurrenceDialog
            // 
            this.AcceptButton = this.okButton;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(476, 292);
            this.Controls.Add(this.removeRecurrenceButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.recurrenceRangeGroup);
            this.Controls.Add(this.recurrencePatternGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecurrenceDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Recurrence";
            this.recurrencePatternGroup.ResumeLayout(false);
            this.recurrencePatternLayout.ResumeLayout(false);
            this.patternPanel.ResumeLayout(false);
            this.patternPanel.PerformLayout();
            this.yearlyPanel.ResumeLayout(false);
            this.yearlyPanel.PerformLayout();
            this.monthlyPanel.ResumeLayout(false);
            this.monthlyPanel.PerformLayout();
            this.weeklyPanel.ResumeLayout(false);
            this.weeklyPanel.PerformLayout();
            this.dailyPanel.ResumeLayout(false);
            this.dailyPanel.PerformLayout();
            this.recurrenceRangeGroup.ResumeLayout(false);
            this.recurrenceRangeGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public RecurrenceDialog() : this(DateTime.Now) {}

        public RecurrenceDialog(DateTime startDate)
        {
            InitializeComponent();
            m_pattern = new RecurrencePattern();
            removeRecurrenceButton.Hide();

            //Weekly Panel
            switch (startDate.DayOfWeek)
            {
                case DayOfWeek.Sunday: sundayCheckBox.Checked = true; break;
                case DayOfWeek.Monday: mondayCheckBox.Checked = true; break;
                case DayOfWeek.Tuesday: tuesdayCheckBox.Checked = true; break;
                case DayOfWeek.Wednesday: wednesdayCheckBox.Checked = true; break;
                case DayOfWeek.Thursday: thursdayCheckBox.Checked = true; break;
                case DayOfWeek.Friday: fridayCheckBox.Checked = true; break;
                case DayOfWeek.Saturday: saturdayCheckBox.Checked = true; break;
            }

            //Monthly Panel
            monthDayField.Text = startDate.Day.ToString();
            monthOrderBox.SelectedIndex = startDate.Day / 7;
            switch (startDate.DayOfWeek)
            {
                case DayOfWeek.Sunday: monthDayBox.SelectedIndex = 0; break;
                case DayOfWeek.Monday: monthDayBox.SelectedIndex = 1; break;
                case DayOfWeek.Tuesday: monthDayBox.SelectedIndex = 2; break;
                case DayOfWeek.Wednesday: monthDayBox.SelectedIndex = 3; break;
                case DayOfWeek.Thursday: monthDayBox.SelectedIndex = 4; break;
                case DayOfWeek.Friday: monthDayBox.SelectedIndex = 5; break;
                case DayOfWeek.Saturday: monthDayBox.SelectedIndex = 6; break;
            }

            //Yearly Panel
            monthBox1.SelectedIndex = startDate.Month - 1;
            yearDayField.Text = startDate.Day.ToString();
            yearDayOrderBox.SelectedIndex = startDate.Day / 7;
            switch (startDate.DayOfWeek)
            {
                case DayOfWeek.Sunday: yearDayBox.SelectedIndex = 0; break;
                case DayOfWeek.Monday: yearDayBox.SelectedIndex = 1; break;
                case DayOfWeek.Tuesday: yearDayBox.SelectedIndex = 2; break;
                case DayOfWeek.Wednesday: yearDayBox.SelectedIndex = 3; break;
                case DayOfWeek.Thursday: yearDayBox.SelectedIndex = 4; break;
                case DayOfWeek.Friday: yearDayBox.SelectedIndex = 5; break;
                case DayOfWeek.Saturday: yearDayBox.SelectedIndex = 6; break;
            }
            monthBox2.SelectedIndex = startDate.Month - 1;

            startDateBox.Value = startDate;
            endDateBox.Value = startDate.AddMonths(2);
        }

        public RecurrenceDialog(IRecurrencePattern pattern, DateTime startDate) : this(startDate)
        {
            removeRecurrenceButton.Show();

            switch (pattern.Frequency)
            {
                case FrequencyType.Daily:
                    dailyRadioButton.Checked = true;
                    if (pattern.ByDay.Count == 5
                        && pattern.ByDay[0].DayOfWeek == DayOfWeek.Monday
                        && pattern.ByDay[1].DayOfWeek == DayOfWeek.Tuesday
                        && pattern.ByDay[2].DayOfWeek == DayOfWeek.Wednesday
                        && pattern.ByDay[3].DayOfWeek == DayOfWeek.Thursday
                        && pattern.ByDay[4].DayOfWeek == DayOfWeek.Friday)
                    {
                        everyWeekdayRadioButton.Checked = true;
                    }
                    else
                    {
                        everyIntervalDayRadioButton.Checked = true;
                        numDayField.Text = pattern.Interval.ToString();
                    }
                    break;

                case FrequencyType.Weekly:
                    weeklyRadioButton.Checked = true;
                    numWeekField.Text = pattern.Interval.ToString();

                    switch (startDate.DayOfWeek)
                    {
                        case DayOfWeek.Sunday: sundayCheckBox.Checked = false; break;
                        case DayOfWeek.Monday: mondayCheckBox.Checked = false; break;
                        case DayOfWeek.Tuesday: tuesdayCheckBox.Checked = false; break;
                        case DayOfWeek.Wednesday: wednesdayCheckBox.Checked = false; break;
                        case DayOfWeek.Thursday: thursdayCheckBox.Checked = false; break;
                        case DayOfWeek.Friday: fridayCheckBox.Checked = false; break;
                        case DayOfWeek.Saturday: saturdayCheckBox.Checked = false; break;
                    }
                    
                    for (int i = 0; i < pattern.ByDay.Count; i++)
                    {
                        switch (pattern.ByDay[i].DayOfWeek)
                        {
                            case DayOfWeek.Sunday: sundayCheckBox.Checked = true; break;
                            case DayOfWeek.Monday: mondayCheckBox.Checked = true; break;
                            case DayOfWeek.Tuesday: tuesdayCheckBox.Checked = true; break;
                            case DayOfWeek.Wednesday: wednesdayCheckBox.Checked = true; break;
                            case DayOfWeek.Thursday: thursdayCheckBox.Checked = true; break;
                            case DayOfWeek.Friday: fridayCheckBox.Checked = true; break;
                            case DayOfWeek.Saturday: saturdayCheckBox.Checked = true; break;
                        }
                    }
                    break;

                case FrequencyType.Monthly:
                    monthlyRadioButton.Checked = true;
                    if (pattern.ByMonthDay.Count > 0)
                    {
                        dayMonthRadioButton.Checked = true;
                        monthDayField.Text = pattern.ByMonthDay[0].ToString();
                        numMonthField1.Text = pattern.Interval.ToString();
                    }
                    else if (pattern.ByDay.Count > 0)
                    {
                        monthRadioButton.Checked = true;
                        if (pattern.ByDay[0].Offset != -1)
                            monthOrderBox.SelectedIndex = pattern.ByDay[0].Offset - 1;
                        else
                            monthOrderBox.SelectedIndex = 4;
                        switch (pattern.ByDay[0].DayOfWeek)
                        {
                            case DayOfWeek.Sunday: monthDayBox.SelectedIndex = 0; break;
                            case DayOfWeek.Monday: monthDayBox.SelectedIndex = 1; break;
                            case DayOfWeek.Tuesday: monthDayBox.SelectedIndex = 2; break;
                            case DayOfWeek.Wednesday: monthDayBox.SelectedIndex = 3; break;
                            case DayOfWeek.Thursday: monthDayBox.SelectedIndex = 4; break;
                            case DayOfWeek.Friday: monthDayBox.SelectedIndex = 5; break;
                            case DayOfWeek.Saturday: monthDayBox.SelectedIndex = 6; break;
                        }
                        numMonthField2.Text = pattern.Interval.ToString();
                    }
                    break;

                case FrequencyType.Yearly:
                    yearlyRadioButton.Checked = true;
                    if (pattern.ByMonth.Count > 0 && pattern.ByMonthDay.Count > 0)
                    {
                        recurYearlyRadioButton.Checked = true;
                        monthBox1.SelectedIndex = pattern.ByMonth[0] - 1;
                        yearDayField.Text = pattern.ByMonthDay[0].ToString();
                        numYearField.Text = pattern.Interval.ToString();
                    }
                    else if (pattern.ByDay.Count > 0 && pattern.ByMonth.Count > 0)
                    {
                        yearRadioButton.Checked = true;
                        if (pattern.ByDay[0].Offset == -1)
                            yearDayOrderBox.SelectedIndex = 4;
                        else
                            yearDayOrderBox.SelectedIndex = pattern.ByDay[0].Offset - 1;
                        switch (pattern.ByDay[0].DayOfWeek)
                        {
                            case DayOfWeek.Sunday: yearDayBox.SelectedIndex = 0; break;
                            case DayOfWeek.Monday: yearDayBox.SelectedIndex = 1; break;
                            case DayOfWeek.Tuesday: yearDayBox.SelectedIndex = 2; break;
                            case DayOfWeek.Wednesday: yearDayBox.SelectedIndex = 3; break;
                            case DayOfWeek.Thursday: yearDayBox.SelectedIndex = 4; break;
                            case DayOfWeek.Friday: yearDayBox.SelectedIndex = 5; break;
                            case DayOfWeek.Saturday: yearDayBox.SelectedIndex = 6; break;
                        }
                        monthBox2.SelectedIndex = pattern.ByMonth[0] - 1;
                    }
                    else
                    {
                        recurYearlyRadioButton.Checked = true;
                        numYearField.Text = pattern.Interval.ToString();
                    }
                    break;
            }

            if (pattern.Count > 0)
            {
                endAfterRadioButton.Checked = true;
                numOccurrencesField.Text = pattern.Count.ToString();
            }
            else if (pattern.Until.Year != 1)
            {
                endByRadioButton.Checked = true;
                endDateBox.Value = pattern.Until;
            }
        }

        public IRecurrencePattern Pattern
        {
            get
            {
                return m_pattern;
            }
        }

        public DateTime Start
        {
            get
            {
                return startDateBox.Value;
            }
        }

        private void dailyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.recurrencePatternLayout.Controls.Contains(this.dailyPanel))
            {
                this.recurrencePatternLayout.Controls.Clear();
                this.recurrencePatternLayout.Controls.Add(this.patternPanel, 0, 0);
                this.recurrencePatternLayout.Controls.Add(this.dailyPanel, 1, 0);
            }
        }

        private void weeklyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.recurrencePatternLayout.Controls.Contains(this.weeklyPanel))
            {
                this.recurrencePatternLayout.Controls.Clear();
                this.recurrencePatternLayout.Controls.Add(this.patternPanel, 0, 0);
                this.recurrencePatternLayout.Controls.Add(this.weeklyPanel, 1, 0);
            }
        }

        private void monthlyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.recurrencePatternLayout.Controls.Contains(this.monthlyPanel))
            {
                this.recurrencePatternLayout.Controls.Clear();
                this.recurrencePatternLayout.Controls.Add(this.patternPanel, 0, 0);
                this.recurrencePatternLayout.Controls.Add(this.monthlyPanel, 1, 0);
            }
        }

        private void yearlyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.recurrencePatternLayout.Controls.Contains(this.yearlyPanel))
            {
                this.recurrencePatternLayout.Controls.Clear();
                this.recurrencePatternLayout.Controls.Add(this.patternPanel, 0, 0);
                this.recurrencePatternLayout.Controls.Add(this.yearlyPanel, 1, 0);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (dailyRadioButton.Checked)
            {
                m_pattern.Frequency = FrequencyType.Daily;
                if (everyIntervalDayRadioButton.Checked)
                {
                    m_pattern.Interval = Int32.Parse(numDayField.Text);
                }
                else
                {
                    m_pattern.ByDay.Clear();
                    WeekDay weekday1 = new WeekDay();
                    weekday1.DayOfWeek = DayOfWeek.Monday;
                    WeekDay weekday2 = new WeekDay();
                    weekday2.DayOfWeek = DayOfWeek.Tuesday;
                    WeekDay weekday3 = new WeekDay();
                    weekday3.DayOfWeek = DayOfWeek.Wednesday;
                    WeekDay weekday4 = new WeekDay();
                    weekday4.DayOfWeek = DayOfWeek.Thursday;
                    WeekDay weekday5 = new WeekDay();
                    weekday5.DayOfWeek = DayOfWeek.Friday;
                    m_pattern.ByDay.Add(weekday1);
                    m_pattern.ByDay.Add(weekday2);
                    m_pattern.ByDay.Add(weekday3);
                    m_pattern.ByDay.Add(weekday4);
                    m_pattern.ByDay.Add(weekday5);
                }
            }
            else if (weeklyRadioButton.Checked)
            {
                m_pattern.Frequency = FrequencyType.Weekly;
                m_pattern.Interval = Int32.Parse(numWeekField.Text);
                if (sundayCheckBox.Checked)
                {
                    WeekDay sunday = new WeekDay();
                    sunday.DayOfWeek = DayOfWeek.Sunday;
                    m_pattern.ByDay.Add(sunday);
                }
                if (mondayCheckBox.Checked)
                {
                    WeekDay monday = new WeekDay();
                    monday.DayOfWeek = DayOfWeek.Monday;
                    m_pattern.ByDay.Add(monday);
                }
                if (tuesdayCheckBox.Checked)
                {
                    WeekDay tuesday = new WeekDay();
                    tuesday.DayOfWeek = DayOfWeek.Tuesday;
                    m_pattern.ByDay.Add(tuesday);
                }
                if (wednesdayCheckBox.Checked)
                {
                    WeekDay wednesday = new WeekDay();
                    wednesday.DayOfWeek = DayOfWeek.Wednesday;
                    m_pattern.ByDay.Add(wednesday);
                }
                if (thursdayCheckBox.Checked)
                {
                    WeekDay thursday = new WeekDay();
                    thursday.DayOfWeek = DayOfWeek.Thursday;
                    m_pattern.ByDay.Add(thursday);
                }
                if (fridayCheckBox.Checked)
                {
                    WeekDay friday = new WeekDay();
                    friday.DayOfWeek = DayOfWeek.Friday;
                    m_pattern.ByDay.Add(friday);
                }
                if (saturdayCheckBox.Checked)
                {
                    WeekDay saturday = new WeekDay();
                    saturday.DayOfWeek = DayOfWeek.Saturday;
                    m_pattern.ByDay.Add(saturday);
                }
            }
            else if (monthlyRadioButton.Checked)
            {
                m_pattern.Frequency = FrequencyType.Monthly;
                if (dayMonthRadioButton.Checked)
                {
                    m_pattern.ByMonthDay.Add(Int32.Parse(monthDayField.Text));
                    m_pattern.Interval = Int32.Parse(numMonthField1.Text);
                }
                else
                {
                    WeekDay weekday = new WeekDay();
                    if (monthOrderBox.SelectedIndex == 4)
                        weekday.Offset = -1;
                    else
                        weekday.Offset = monthOrderBox.SelectedIndex + 1;
                    switch (monthDayBox.SelectedIndex)
                    {
                        case 0: weekday.DayOfWeek = DayOfWeek.Sunday; break;
                        case 1: weekday.DayOfWeek = DayOfWeek.Monday; break;
                        case 2: weekday.DayOfWeek = DayOfWeek.Tuesday; break;
                        case 3: weekday.DayOfWeek = DayOfWeek.Wednesday; break;
                        case 4: weekday.DayOfWeek = DayOfWeek.Thursday; break;
                        case 5: weekday.DayOfWeek = DayOfWeek.Friday; break;
                        case 6: weekday.DayOfWeek = DayOfWeek.Saturday; break;
                    }
                    m_pattern.ByDay.Add(weekday);
                    m_pattern.Interval = Int32.Parse(numMonthField2.Text);
                }
            }
            else
            {
                m_pattern.Frequency = FrequencyType.Yearly;
                if (recurYearlyRadioButton.Checked)
                {
                    m_pattern.ByMonth.Add(monthBox1.SelectedIndex + 1);
                    m_pattern.ByMonthDay.Add(Int32.Parse(yearDayField.Text));
                    m_pattern.Interval = Int32.Parse(numYearField.Text);
                }
                else
                {
                    WeekDay weekday = new WeekDay();
                    if (yearDayOrderBox.SelectedIndex == 4)
                        weekday.Offset = -1;
                    else
                        weekday.Offset = yearDayOrderBox.SelectedIndex + 1;
                    switch (yearDayBox.SelectedIndex)
                    {
                        case 0: weekday.DayOfWeek = DayOfWeek.Sunday; break;
                        case 1: weekday.DayOfWeek = DayOfWeek.Monday; break;
                        case 2: weekday.DayOfWeek = DayOfWeek.Tuesday; break;
                        case 3: weekday.DayOfWeek = DayOfWeek.Wednesday; break;
                        case 4: weekday.DayOfWeek = DayOfWeek.Thursday; break;
                        case 5: weekday.DayOfWeek = DayOfWeek.Friday; break;
                        case 6: weekday.DayOfWeek = DayOfWeek.Saturday; break;
                    }
                    m_pattern.ByDay.Add(weekday);
                    m_pattern.ByMonth.Add(monthBox2.SelectedIndex + 1);
                }
            }

            if (endAfterRadioButton.Checked)
                m_pattern.Count = Int32.Parse(numOccurrencesField.Text);
            else if (endByRadioButton.Checked)
                m_pattern.Until = endDateBox.Value;
            this.DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void removeRecurrenceButton_Click(object sender, EventArgs e)
        {
            m_pattern = null;
            this.DialogResult = DialogResult.OK;
        }
    }
}
