using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace MultiDesktop
{
    public class CalendarForm : Form
    {
        public static SettingManager SettingController { private get; set; }

        private Calendar m_calendar;

        private ToolStrip eventToolStrip;
        private ToolStripButton saveButton;
        private ToolStripButton deleteButton;
        private Panel topPanel;
        private Button browseButton;
        private TextBox filenameField;
        private Label nameLabel;
        private Label filenameLabel;
        private TextBox nameField;
        private CheckBox includedCheckBox;

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
            this.browseButton = new System.Windows.Forms.Button();
            this.filenameField = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.filenameLabel = new System.Windows.Forms.Label();
            this.nameField = new System.Windows.Forms.TextBox();
            this.includedCheckBox = new System.Windows.Forms.CheckBox();
            this.eventToolStrip.SuspendLayout();
            this.topPanel.SuspendLayout();
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
            this.topPanel.Controls.Add(this.browseButton);
            this.topPanel.Controls.Add(this.filenameField);
            this.topPanel.Controls.Add(this.nameLabel);
            this.topPanel.Controls.Add(this.filenameLabel);
            this.topPanel.Controls.Add(this.nameField);
            this.topPanel.Controls.Add(this.includedCheckBox);
            this.topPanel.Location = new System.Drawing.Point(1, 28);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(239, 86);
            this.topPanel.TabIndex = 31;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(202, 29);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(25, 23);
            this.browseButton.TabIndex = 28;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // filenameField
            // 
            this.filenameField.Location = new System.Drawing.Point(78, 29);
            this.filenameField.Name = "filenameField";
            this.filenameField.Size = new System.Drawing.Size(118, 20);
            this.filenameField.TabIndex = 27;
            // 
            // nameLabel
            // 
            this.nameLabel.Location = new System.Drawing.Point(12, 6);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(62, 13);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Name:";
            // 
            // filenameLabel
            // 
            this.filenameLabel.Location = new System.Drawing.Point(12, 32);
            this.filenameLabel.Name = "filenameLabel";
            this.filenameLabel.Size = new System.Drawing.Size(62, 13);
            this.filenameLabel.TabIndex = 26;
            this.filenameLabel.Text = "Filename:";
            this.filenameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nameField
            // 
            this.nameField.Location = new System.Drawing.Point(78, 3);
            this.nameField.Name = "nameField";
            this.nameField.Size = new System.Drawing.Size(149, 20);
            this.nameField.TabIndex = 3;
            // 
            // includedCheckBox
            // 
            this.includedCheckBox.AutoSize = true;
            this.includedCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.includedCheckBox.Checked = true;
            this.includedCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includedCheckBox.Location = new System.Drawing.Point(12, 57);
            this.includedCheckBox.Name = "includedCheckBox";
            this.includedCheckBox.Size = new System.Drawing.Size(67, 17);
            this.includedCheckBox.TabIndex = 24;
            this.includedCheckBox.Text = "Included";
            this.includedCheckBox.UseVisualStyleBackColor = true;
            // 
            // CalendarForm
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(240, 114);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.eventToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "CalendarForm";
            this.Text = "Calendar";
            this.eventToolStrip.ResumeLayout(false);
            this.eventToolStrip.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public CalendarForm()
        {
            InitializeComponent();
            deleteButton.Enabled = false;
        }

        public CalendarForm(Calendar calendar)
        {
            InitializeComponent();
            filenameField.Enabled = false;
            browseButton.Enabled = false;
            m_calendar = calendar;

            nameField.Text = m_calendar.Name;
            filenameField.Text = m_calendar.Filename;
            includedCheckBox.Checked = m_calendar.Included;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (m_calendar == null)
            {
                string path = Path.GetDirectoryName(filenameField.Text);
                if (path.Equals(""))
                    path = SettingController.CalendarManager.CalendarAbsPath;
                string filename = Path.GetFileName(filenameField.Text);

                if (filename.Equals(""))
                    MessageBox.Show("Filename cannot be empty. Please enter a filename.");
                else if (!Path.GetExtension(filename).Equals(".ics"))
                    MessageBox.Show("Invalid file extension! Required *.ics extension.");
                else if (File.Exists(SettingController.CalendarManager.CalendarAbsPath + "\\" + filename) && !path.Equals(SettingController.CalendarManager.CalendarAbsPath))
                {
                    MessageBox.Show("Filename already existed. Please move, rename, or delete it and try again or add that file instead.");
                    System.Diagnostics.Process.Start(SettingController.CalendarManager.CalendarAbsPath);
                }
                else
                {
                    if (path.Equals(SettingController.CalendarManager.CalendarAbsPath))
                    {
                        if (!SettingController.CalendarManager.createCalendar(nameField.Text, filename, includedCheckBox.Checked))
                            MessageBox.Show("Name or filename already existed on database. Please use a different name or filename.");
                        else
                            Close();
                    }
                    else if (File.Exists(path + "\\" + filename))
                    {
                        File.Copy(path + "\\" + filename, SettingController.CalendarManager.CalendarAbsPath + "\\" + filename);

                        if (!SettingController.CalendarManager.createCalendar(nameField.Text, filename, includedCheckBox.Checked, false))
                            MessageBox.Show("Name or filename already existed on database. Please use a different name or filename.");
                        else
                            Close();
                    }
                    else
                        MessageBox.Show("Invalid file path or filename! Please correct and try again.");
                }
            }
            else
            {
                if (m_calendar.Included != includedCheckBox.Checked)
                {
                    if (includedCheckBox.Checked)
                        SettingController.CalendarManager.loadCalendar(m_calendar);
                    else
                        SettingController.CalendarManager.unloadCalendar(m_calendar);
                }

                if (!m_calendar.Name.Equals(nameField.Text) && !SettingController.CalendarManager.renameCalendar(m_calendar.ID, nameField.Text))
                {
                    MessageBox.Show("The new calendar name already exists. Enter a different one.");
                }
                else
                    Close();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            SettingController.CalendarManager.deleteCalendar(m_calendar);
            Close();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = SettingController.CalendarAbsPath;
            dialog.Filter = "ical files (*.ics)|*.ics";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filenameField.Text = dialog.FileName;
                filenameField.Enabled = false;
            }
        }
    }
}
