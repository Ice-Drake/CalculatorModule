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
    public class JournalPanel : Form
    {
        public ToolStripMenuItem MenuItem { get; private set; }

        #region Component Designer variables

        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private JournalUserControl journalUserControl;
        private Button saveEntryButton;
        private Button removeEntryButton;

        #endregion

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
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.saveEntryButton = new System.Windows.Forms.Button();
            this.removeEntryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(12, 12);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(410, 530);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = journalUserControl;
            // 
            // saveEntryButton
            // 
            this.saveEntryButton.Location = new System.Drawing.Point(139, 548);
            this.saveEntryButton.Name = "saveEntryButton";
            this.saveEntryButton.Size = new System.Drawing.Size(75, 23);
            this.saveEntryButton.TabIndex = 1;
            this.saveEntryButton.Text = "Save Entry";
            this.saveEntryButton.UseVisualStyleBackColor = true;
            this.saveEntryButton.Click += new System.EventHandler(this.saveEntryButton_Click);
            // 
            // removeEntryButton
            // 
            this.removeEntryButton.Location = new System.Drawing.Point(220, 548);
            this.removeEntryButton.Name = "removeEntryButton";
            this.removeEntryButton.Size = new System.Drawing.Size(75, 23);
            this.removeEntryButton.TabIndex = 2;
            this.removeEntryButton.Text = "Delete Entry";
            this.removeEntryButton.UseVisualStyleBackColor = true;
            this.removeEntryButton.Click += new System.EventHandler(this.removeEntryButton_Click);
            // 
            // JournalPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(434, 583);
            this.Controls.Add(this.removeEntryButton);
            this.Controls.Add(this.saveEntryButton);
            this.Controls.Add(this.elementHost1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JournalPanel";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);

        }

        #endregion

        public JournalPanel(JournalBook journalBook)
        {
            journalUserControl = new JournalUserControl(journalBook);

            InitializeComponent();

            this.Name = journalBook.Name;
            MenuItem = new ToolStripMenuItem(journalBook.Name);
            MenuItem.CheckOnClick = true;         

            journalBook.NameChange += new EventHandler(journalBook_NameChange);
            journalBook.JournalDisable += new EventHandler(journalBook_JournalDisable);
            MenuItem.Click += new EventHandler(MenuItem_Click);
            this.FormClosing += new FormClosingEventHandler(MainPanel_FormClosing);
        }

        private void journalBook_NameChange(object sender, EventArgs e)
        {
            this.Name = journalUserControl.JournalBook.Name;
            MenuItem.Name = journalUserControl.JournalBook.Name;
        }

        private void journalBook_JournalDisable(object sender, EventArgs e)
        {
            Hide();
            MenuItem.Checked = false;
            saveEntryButton.Enabled = false;
            removeEntryButton.Enabled = false;
        }

        private void saveEntryButton_Click(object sender, EventArgs e)
        {
            journalUserControl.saveJournalEntry();
        }

        private void removeEntryButton_Click(object sender, EventArgs e)
        {
            journalUserControl.removeJournalEntry();
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            if (!journalUserControl.JournalBook.Enabled)
            {
                MessageBox.Show("This journal has been locked since the calendar associated to it is either missing or disabled. Please correct this problem and try again.");
            }
            else
            {
                if (!saveEntryButton.Enabled)
                    saveEntryButton.Enabled = true;
                if (!removeEntryButton.Enabled)
                    removeEntryButton.Enabled = true;

                if (!MenuItem.Checked)
                {
                    Hide();
                }
                else if (journalUserControl.JournalBook.Private)
                {
                    PasswordDialog dialog = new PasswordDialog();
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        if (dialog.Password.Equals(journalUserControl.JournalBook.Password))
                        {
                            Show();
                        }
                        else
                            MessageBox.Show("The password you enter is incorrect. Please try again.");
                    }
                }
                else
                {
                    Show();
                }
            }
        }

        private void MainPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            MenuItem.Checked = false;
        }
    }
}
