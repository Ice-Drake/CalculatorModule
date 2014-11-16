using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MultiDesktop
{
    public class LGoalForm : Form
    {
        public static GoalPlanner GoalController { private get; set; }
        public static CategoryManager CategoryController { private get; set; }

        private LGoal m_goal;
        private string m_predecessors;
        private TimeSpan m_duration;

        #region Component Designer variables

        private IContainer components = null;
        private Label calendarLabel;
        private ComboBox visionComboBox;
        private Label summaryLabel;
        private TextBox summaryField;
        private Label startDateLabel;
        private DateTimePicker startDateBox;
        private Library.NullableDateTimePicker dueDateBox;
        private Label dueDateLabel;
        private Label schemeLabel;
        private Label categoryLabel;
        private ComboBox schemeComboBox;
        private RichTextBox descriptionTextBox;
        private ComboBox categoryComboBox;
        private ToolStrip eventToolStrip;
        private ToolStripButton saveButton;
        private ToolStripButton predecessorButton;
        private ToolStripButton deleteButton;
        private TableLayoutPanel tableLayoutPanel;
        private Panel topPanel;
        private Panel bottomPanel;
        private CheckBox completedCheckBox;
        private RadioButton selectButton;
        private RadioButton noneButton;

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
            this.visionComboBox = new System.Windows.Forms.ComboBox();
            this.summaryLabel = new System.Windows.Forms.Label();
            this.summaryField = new System.Windows.Forms.TextBox();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.dueDateLabel = new System.Windows.Forms.Label();
            this.schemeLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.schemeComboBox = new System.Windows.Forms.ComboBox();
            this.descriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.eventToolStrip = new System.Windows.Forms.ToolStrip();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.deleteButton = new System.Windows.Forms.ToolStripButton();
            this.predecessorButton = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.selectButton = new System.Windows.Forms.RadioButton();
            this.noneButton = new System.Windows.Forms.RadioButton();
            this.completedCheckBox = new System.Windows.Forms.CheckBox();
            this.startDateBox = new System.Windows.Forms.DateTimePicker();
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
            this.calendarLabel.Size = new System.Drawing.Size(80, 13);
            this.calendarLabel.TabIndex = 0;
            this.calendarLabel.Text = "Related Vision:";
            // 
            // visionComboBox
            // 
            this.visionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.visionComboBox.Location = new System.Drawing.Point(161, 3);
            this.visionComboBox.Name = "visionComboBox";
            this.visionComboBox.Size = new System.Drawing.Size(153, 21);
            this.visionComboBox.TabIndex = 1;
            // 
            // summaryLabel
            // 
            this.summaryLabel.Location = new System.Drawing.Point(7, 33);
            this.summaryLabel.Name = "summaryLabel";
            this.summaryLabel.Size = new System.Drawing.Size(57, 13);
            this.summaryLabel.TabIndex = 2;
            this.summaryLabel.Text = "Summary:";
            // 
            // summaryField
            // 
            this.summaryField.Location = new System.Drawing.Point(70, 30);
            this.summaryField.Name = "summaryField";
            this.summaryField.Size = new System.Drawing.Size(244, 20);
            this.summaryField.TabIndex = 3;
            // 
            // startDateLabel
            // 
            this.startDateLabel.Location = new System.Drawing.Point(7, 59);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(57, 13);
            this.startDateLabel.TabIndex = 4;
            this.startDateLabel.Text = "Start date:";
            // 
            // dueDateLabel
            // 
            this.dueDateLabel.Location = new System.Drawing.Point(166, 59);
            this.dueDateLabel.Name = "dueDateLabel";
            this.dueDateLabel.Size = new System.Drawing.Size(57, 13);
            this.dueDateLabel.TabIndex = 7;
            this.dueDateLabel.Text = "Due date:";
            // 
            // schemeLabel
            // 
            this.schemeLabel.AutoSize = true;
            this.schemeLabel.Location = new System.Drawing.Point(7, 6);
            this.schemeLabel.Name = "schemeLabel";
            this.schemeLabel.Size = new System.Drawing.Size(49, 13);
            this.schemeLabel.TabIndex = 10;
            this.schemeLabel.Text = "Scheme:";
            // 
            // categoryLabel
            // 
            this.categoryLabel.Location = new System.Drawing.Point(7, 85);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(57, 13);
            this.categoryLabel.TabIndex = 11;
            this.categoryLabel.Text = "Category:";
            // 
            // schemeComboBox
            // 
            this.schemeComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "Back-To-Back",
            "Slack Buffer"});
            this.schemeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.schemeComboBox.Items.AddRange(new object[] {
            "Back-To-Back",
            "Slack Buffer"});
            this.schemeComboBox.Location = new System.Drawing.Point(70, 3);
            this.schemeComboBox.Name = "schemeComboBox";
            this.schemeComboBox.Size = new System.Drawing.Size(146, 21);
            this.schemeComboBox.TabIndex = 12;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionTextBox.Location = new System.Drawing.Point(3, 117);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(317, 116);
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
            this.categoryComboBox.Location = new System.Drawing.Point(70, 82);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(146, 21);
            this.categoryComboBox.TabIndex = 15;
            // 
            // eventToolStrip
            // 
            this.eventToolStrip.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.eventToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.eventToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveButton,
            this.deleteButton,
            this.predecessorButton});
            this.eventToolStrip.Location = new System.Drawing.Point(0, 0);
            this.eventToolStrip.Name = "eventToolStrip";
            this.eventToolStrip.Size = new System.Drawing.Size(323, 25);
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
            // predecessorButton
            // 
            this.predecessorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.predecessorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.predecessorButton.Name = "predecessorButton";
            this.predecessorButton.Size = new System.Drawing.Size(74, 22);
            this.predecessorButton.Text = "Predecessor";
            this.predecessorButton.Click += new System.EventHandler(this.predecessorButton_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.topPanel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.descriptionTextBox, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.bottomPanel, 0, 2);
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(323, 271);
            this.tableLayoutPanel.TabIndex = 22;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.selectButton);
            this.topPanel.Controls.Add(this.noneButton);
            this.topPanel.Controls.Add(this.completedCheckBox);
            this.topPanel.Controls.Add(this.calendarLabel);
            this.topPanel.Controls.Add(this.categoryLabel);
            this.topPanel.Controls.Add(this.visionComboBox);
            this.topPanel.Controls.Add(this.summaryLabel);
            this.topPanel.Controls.Add(this.categoryComboBox);
            this.topPanel.Controls.Add(this.summaryField);
            this.topPanel.Controls.Add(this.startDateLabel);
            this.topPanel.Controls.Add(this.startDateBox);
            this.topPanel.Controls.Add(this.dueDateBox);
            this.topPanel.Controls.Add(this.dueDateLabel);
            this.topPanel.Location = new System.Drawing.Point(3, 3);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(317, 108);
            this.topPanel.TabIndex = 0;
            // 
            // selectButton
            // 
            this.selectButton.AutoSize = true;
            this.selectButton.Location = new System.Drawing.Point(141, 6);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(14, 13);
            this.selectButton.TabIndex = 24;
            this.selectButton.TabStop = true;
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // noneButton
            // 
            this.noneButton.AutoSize = true;
            this.noneButton.Location = new System.Drawing.Point(84, 4);
            this.noneButton.Name = "noneButton";
            this.noneButton.Size = new System.Drawing.Size(51, 17);
            this.noneButton.TabIndex = 23;
            this.noneButton.TabStop = true;
            this.noneButton.Text = "None";
            this.noneButton.UseVisualStyleBackColor = true;
            this.noneButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // completedCheckBox
            // 
            this.completedCheckBox.AutoSize = true;
            this.completedCheckBox.Location = new System.Drawing.Point(232, 84);
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
            this.startDateBox.Location = new System.Drawing.Point(70, 56);
            this.startDateBox.Name = "startDateBox";
            this.startDateBox.Size = new System.Drawing.Size(92, 20);
            this.startDateBox.TabIndex = 5;
            // 
            // dueDateBox
            // 
            this.dueDateBox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dueDateBox.Location = new System.Drawing.Point(222, 56);
            this.dueDateBox.Name = "dueDateBox";
            this.dueDateBox.Size = new System.Drawing.Size(92, 20);
            this.dueDateBox.TabIndex = 6;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.schemeComboBox);
            this.bottomPanel.Controls.Add(this.schemeLabel);
            this.bottomPanel.Location = new System.Drawing.Point(3, 239);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(317, 29);
            this.bottomPanel.TabIndex = 14;
            // 
            // LGoalForm
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(323, 299);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.eventToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "LGoalForm";
            this.Text = "Long-Term Goal";
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

        public LGoalForm()
        {
            InitializeComponent();
            m_predecessors = "";
            noneButton.Checked = true;
            visionComboBox.DataSource = GoalController.VisionManager.VisionTable;
            visionComboBox.DisplayMember = "Summary";
            visionComboBox.ValueMember = "ID";

            foreach (string categoryName in CategoryController.getCategoryList())
            {
                categoryComboBox.Items.Add(categoryName);
            }
            categoryComboBox.SelectedIndex = 0;
            dueDateBox.Value = DateTime.MinValue;
            m_duration = TimeSpan.FromDays(365);
            schemeComboBox.SelectedIndex = 0;
            deleteButton.Enabled = false;

            startDateBox.ValueChanged += new EventHandler(startDateBox_ValueChanged);
            dueDateBox.ValueChanged += new EventHandler(dueDateBox_ValueChanged);
        }

        public LGoalForm(LGoal existingGoal)
        {
            InitializeComponent();
            m_goal = existingGoal;
            m_predecessors = existingGoal.Predecessors;

            visionComboBox.DataSource = GoalController.VisionManager.VisionTable;
            visionComboBox.DisplayMember = "Summary";
            visionComboBox.ValueMember = "ID";

            if (m_goal.VisionID != 0)
            {
                selectButton.Checked = true;
                visionComboBox.SelectedValue = m_goal.VisionID;
            }
            else
                noneButton.Checked = true;

            foreach (string categoryName in CategoryController.getCategoryList())
            {
                categoryComboBox.Items.Add(categoryName);
            }
            categoryComboBox.SelectedItem = m_goal.Category;

            summaryField.Text = m_goal.Name;
            startDateBox.Value = m_goal.StartDate;
            dueDateBox.Value = m_goal.DueDate;

            if (m_goal.DueDate != DateTime.MinValue)
                m_duration = dueDateBox.Value - startDateBox.Value;
            else
                m_duration = TimeSpan.FromDays(365);
            
            completedCheckBox.Checked = m_goal.Complete == 1.0f;
            descriptionTextBox.Text = m_goal.Desc;
            schemeComboBox.SelectedIndex = m_goal.Scheme;

            startDateBox.ValueChanged += new EventHandler(startDateBox_ValueChanged);
            dueDateBox.ValueChanged += new EventHandler(dueDateBox_ValueChanged);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int visionID = 0;
            if (selectButton.Checked)
            {
                visionID = Int32.Parse(visionComboBox.SelectedValue.ToString());
            }

            if (m_goal == null)
            {
                GoalController.createLGoal(summaryField.Text, completedCheckBox.Checked, categoryComboBox.SelectedItem.ToString(), descriptionTextBox.Text, m_predecessors, startDateBox.Value, dueDateBox.Value, schemeComboBox.SelectedIndex, visionID);
            }
            else
            {
                m_goal.Name = summaryField.Text;
                m_goal.StartDate = startDateBox.Value;
                m_goal.DueDate = dueDateBox.Value;
                m_goal.Complete = completedCheckBox.Checked ? 1.0f : 0.0f;
                m_goal.Category = categoryComboBox.SelectedItem.ToString();
                m_goal.Desc = descriptionTextBox.Text;
                m_goal.Predecessors = m_predecessors;
                m_goal.Scheme = schemeComboBox.SelectedIndex;
                m_goal.VisionID = visionID;
                
                GoalController.updateLGoal(m_goal);
            }

            Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            GoalController.removeLGoal(m_goal.ID);
            Close();
        }

        private void predecessorButton_Click(object sender, EventArgs e)
        {
            PredecessorDialog dialog = new PredecessorDialog(GoalController.findPossiblePredecessors(m_goal));
            
            if (dialog.ShowDialog() == DialogResult.OK)
                m_predecessors = dialog.Predecessors;
        }

        private void startDateBox_ValueChanged(object sender, EventArgs e)
        {
            if (dueDateBox.Value != DateTime.MinValue)
            {
                dueDateBox.Value = startDateBox.Value.Add(m_duration);
            }
        }

        private void dueDateBox_ValueChanged(object sender, EventArgs e)
        {
            if (dueDateBox.Value != DateTime.MinValue)
            {
                if (dueDateBox.Value >= startDateBox.Value)
                {
                    TimeSpan duration = dueDateBox.Value - startDateBox.Value;
                    if (duration.Days >= 365)
                        m_duration = duration;
                    else
                    {
                        MessageBox.Show("The duration of a long-term goal cannot be shorter than a year.");
                        if (m_duration.Days == 365)
                            dueDateBox.Value = DateTime.MinValue;
                        else
                            dueDateBox.Value = startDateBox.Value.Add(m_duration);
                    }
                }
                else
                {
                    MessageBox.Show("The due date of a goal cannot occur before its start date.");
                    dueDateBox.Value = startDateBox.Value.Add(m_duration);
                }
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (noneButton.Checked)
                visionComboBox.Enabled = false;
            else
                visionComboBox.Enabled = true;
        }
    }
}
