using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MultiDesktop
{
    public class JournalBookForm : Form
    {
        public static CalendarManager CalendarController { private get; set; }

        private JournalBook m_journalBook;

        private ToolStrip eventToolStrip;
        private ToolStripButton saveButton;
        private ToolStripButton deleteButton;
        private Panel topPanel;
        private Label nameLabel;
        private Label calendarLabel;
        private TextBox nameField;
        private CheckBox privateCheckBox;
        private ComboBox calendarComboBox;
        private GroupBox passwordBox;
        private TextBox passwordField2;
        private Label passwordLabel2;
        private TextBox passwordField1;
        private Label passwordLabel1;

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
            this.eventToolStrip = new System.Windows.Forms.ToolStrip();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.deleteButton = new System.Windows.Forms.ToolStripButton();
            this.topPanel = new System.Windows.Forms.Panel();
            this.passwordBox = new System.Windows.Forms.GroupBox();
            this.passwordField1 = new System.Windows.Forms.TextBox();
            this.passwordLabel1 = new System.Windows.Forms.Label();
            this.passwordField2 = new System.Windows.Forms.TextBox();
            this.passwordLabel2 = new System.Windows.Forms.Label();
            this.calendarComboBox = new System.Windows.Forms.ComboBox();
            this.privateCheckBox = new System.Windows.Forms.CheckBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.calendarLabel = new System.Windows.Forms.Label();
            this.nameField = new System.Windows.Forms.TextBox();
            this.eventToolStrip.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.passwordBox.SuspendLayout();
            this.SuspendLayout();
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
            this.eventToolStrip.Size = new System.Drawing.Size(240, 25);
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
            // topPanel
            // 
            this.topPanel.Controls.Add(this.passwordBox);
            this.topPanel.Controls.Add(this.calendarComboBox);
            this.topPanel.Controls.Add(this.privateCheckBox);
            this.topPanel.Controls.Add(this.nameLabel);
            this.topPanel.Controls.Add(this.calendarLabel);
            this.topPanel.Controls.Add(this.nameField);
            this.topPanel.Location = new System.Drawing.Point(1, 28);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(239, 158);
            this.topPanel.TabIndex = 31;
            // 
            // passwordBox
            // 
            this.passwordBox.Controls.Add(this.passwordField1);
            this.passwordBox.Controls.Add(this.passwordLabel1);
            this.passwordBox.Controls.Add(this.passwordField2);
            this.passwordBox.Controls.Add(this.passwordLabel2);
            this.passwordBox.Location = new System.Drawing.Point(3, 80);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(233, 76);
            this.passwordBox.TabIndex = 30;
            this.passwordBox.TabStop = false;
            this.passwordBox.Text = "Password";
            // 
            // passwordField1
            // 
            this.passwordField1.Enabled = false;
            this.passwordField1.Location = new System.Drawing.Point(97, 17);
            this.passwordField1.Name = "passwordField1";
            this.passwordField1.PasswordChar = '*';
            this.passwordField1.Size = new System.Drawing.Size(126, 20);
            this.passwordField1.TabIndex = 31;
            // 
            // passwordLabel1
            // 
            this.passwordLabel1.AutoSize = true;
            this.passwordLabel1.Location = new System.Drawing.Point(7, 20);
            this.passwordLabel1.Name = "passwordLabel1";
            this.passwordLabel1.Size = new System.Drawing.Size(84, 13);
            this.passwordLabel1.TabIndex = 30;
            this.passwordLabel1.Text = "Enter Password:";
            // 
            // passwordField2
            // 
            this.passwordField2.Enabled = false;
            this.passwordField2.Location = new System.Drawing.Point(97, 43);
            this.passwordField2.Name = "passwordField2";
            this.passwordField2.PasswordChar = '*';
            this.passwordField2.Size = new System.Drawing.Size(126, 20);
            this.passwordField2.TabIndex = 29;
            // 
            // passwordLabel2
            // 
            this.passwordLabel2.Location = new System.Drawing.Point(6, 46);
            this.passwordLabel2.Name = "passwordLabel2";
            this.passwordLabel2.Size = new System.Drawing.Size(85, 13);
            this.passwordLabel2.TabIndex = 28;
            this.passwordLabel2.Text = "Verify Password:";
            // 
            // calendarComboBox
            // 
            this.calendarComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.calendarComboBox.FormattingEnabled = true;
            this.calendarComboBox.Location = new System.Drawing.Point(77, 2);
            this.calendarComboBox.Name = "calendarComboBox";
            this.calendarComboBox.Size = new System.Drawing.Size(149, 21);
            this.calendarComboBox.TabIndex = 27;
            // 
            // privateCheckBox
            // 
            this.privateCheckBox.AutoSize = true;
            this.privateCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.privateCheckBox.Location = new System.Drawing.Point(11, 57);
            this.privateCheckBox.Name = "privateCheckBox";
            this.privateCheckBox.Size = new System.Drawing.Size(59, 17);
            this.privateCheckBox.TabIndex = 24;
            this.privateCheckBox.Text = "Private";
            this.privateCheckBox.UseVisualStyleBackColor = true;
            this.privateCheckBox.CheckedChanged += new System.EventHandler(this.privateCheckBox_CheckedChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.Location = new System.Drawing.Point(11, 32);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(62, 13);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Name:";
            // 
            // calendarLabel
            // 
            this.calendarLabel.Location = new System.Drawing.Point(11, 5);
            this.calendarLabel.Name = "calendarLabel";
            this.calendarLabel.Size = new System.Drawing.Size(59, 13);
            this.calendarLabel.TabIndex = 26;
            this.calendarLabel.Text = "Calendar:";
            this.calendarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nameField
            // 
            this.nameField.Location = new System.Drawing.Point(77, 29);
            this.nameField.Name = "nameField";
            this.nameField.Size = new System.Drawing.Size(149, 20);
            this.nameField.TabIndex = 3;
            // 
            // JournalBookForm
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(240, 186);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.eventToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "JournalBookForm";
            this.Text = "Journal";
            this.eventToolStrip.ResumeLayout(false);
            this.eventToolStrip.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.passwordBox.ResumeLayout(false);
            this.passwordBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public JournalBookForm()
        {
            InitializeComponent();
            calendarComboBox.DisplayMember = "Name";
            calendarComboBox.ValueMember = "ID";
            calendarComboBox.DataSource = CalendarController.CalendarTable;

            deleteButton.Enabled = false;
        }

        public JournalBookForm(JournalBook journalBook)
        {
            InitializeComponent();
            m_journalBook = journalBook;

            calendarComboBox.DisplayMember = "Name";
            calendarComboBox.ValueMember = "ID";
            calendarComboBox.DataSource = CalendarController.CalendarTable;
            calendarComboBox.SelectedValue = journalBook.CalendarID;
            calendarComboBox.Enabled = false;

            nameField.Text = m_journalBook.Name;
            privateCheckBox.Checked = m_journalBook.Private;
            if (m_journalBook.Private)
            {
                passwordField1.Text = m_journalBook.Password;
                passwordField2.Text = m_journalBook.Password;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (privateCheckBox.Checked && !passwordField1.Text.Equals(passwordField2.Text))
            {
                MessageBox.Show("Two passwords do not match. Please correct and try again.");
            }
            else if (CalendarController.JournalManager.containsJournal(nameField.Text) && (m_journalBook == null || (m_journalBook != null && !m_journalBook.Name.Equals(nameField.Text))))
            {
                MessageBox.Show("The name for the journal already existed. Please enter a different one.");
            }
            else if (m_journalBook != null)
            {
                m_journalBook.Name = nameField.Text;
                if (m_journalBook.Private)
                    m_journalBook.Password = passwordField1.Text;
                
                CalendarController.JournalManager.updateJournal(m_journalBook);
                Close();
            }
            else
            {
                int calendarID = Int32.Parse(calendarComboBox.SelectedValue.ToString());
                if (privateCheckBox.Checked)
                    CalendarController.JournalManager.createJournal(calendarID, nameField.Text, privateCheckBox.Checked, passwordField1.Text);
                else
                    CalendarController.JournalManager.createJournal(calendarID, nameField.Text, privateCheckBox.Checked);
                Close();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            CalendarController.JournalManager.removeJournal(m_journalBook);
            Close();
        }

        private void privateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (privateCheckBox.Checked)
            {
                passwordField1.Enabled = true;
                passwordField2.Enabled = true;
            }
            else
            {
                passwordField1.Enabled = false;
                passwordField2.Enabled = false;
            }
        }
    }
}
