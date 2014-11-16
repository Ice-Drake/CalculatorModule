using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Library;

namespace MultiDesktop
{
    public class CalendarPanel : MainPanel
    {
        private EventManager controller;
        private Library.MonthCalendar monthCalendar;
        private List<DateItem> eventList;

        #region Component Designer variables

        private IContainer components = null;
        private ContextMenuStrip calendarContextMenu;
        private ToolStripMenuItem gotoTodayToolStripMenuItem;
        private ToolStripMenuItem previousYearToolStripMenuItem;
        private ToolStripMenuItem nextYearToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem manageCalendarsToolStripMenuItem;
        private ToolStripMenuItem calendarsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private GroupBox eventGroupBox;
        private ListBox eventListBox;
        private ToolStripMenuItem hideToolStripMenuItem;

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
            this.components = new System.ComponentModel.Container();
            this.calendarContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gotoTodayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previousYearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextYearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.manageCalendarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calendarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventGroupBox = new System.Windows.Forms.GroupBox();
            this.eventListBox = new System.Windows.Forms.ListBox();
            this.calendarContextMenu.SuspendLayout();
            this.eventGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // monthCalendar
            // 
            this.monthCalendar.ContextMenuStrip = this.calendarContextMenu;
            this.monthCalendar.Culture = new System.Globalization.CultureInfo("en-US");
            this.monthCalendar.Footer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.monthCalendar.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.monthCalendar.Header.TextColor = System.Drawing.Color.White;
            this.monthCalendar.ImageList = null;
            this.monthCalendar.Location = new System.Drawing.Point(0, 0);
            this.monthCalendar.MaxDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.monthCalendar.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.monthCalendar.Month.BackgroundImage = null;
            this.monthCalendar.Month.DateAlign = Library.mcItemAlign.TopRight;
            this.monthCalendar.Month.DateFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar.Month.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.SelectionMode = Library.mcSelectionMode.One;
            this.monthCalendar.ShowFooter = false;
            this.monthCalendar.Size = new System.Drawing.Size(300, 300);
            this.monthCalendar.TabIndex = 0;
            this.monthCalendar.Weekdays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar.Weeknumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar.DaySelected += new Library.DaySelectedEventHandler(this.monthCalendar_DaySelected);
            // 
            // calendarContextMenu
            // 
            this.calendarContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gotoTodayToolStripMenuItem,
            this.previousYearToolStripMenuItem,
            this.nextYearToolStripMenuItem,
            this.toolStripSeparator1,
            this.manageCalendarsToolStripMenuItem,
            this.calendarsToolStripMenuItem,
            this.toolStripSeparator2,
            this.hideToolStripMenuItem});
            this.calendarContextMenu.Name = "calendarContextMenu";
            this.calendarContextMenu.Size = new System.Drawing.Size(173, 148);
            // 
            // gotoTodayToolStripMenuItem
            // 
            this.gotoTodayToolStripMenuItem.Name = "gotoTodayToolStripMenuItem";
            this.gotoTodayToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.gotoTodayToolStripMenuItem.Text = "Goto Today";
            this.gotoTodayToolStripMenuItem.Click += new System.EventHandler(this.gotoTodayToolStripMenuItem_Click);
            // 
            // previousYearToolStripMenuItem
            // 
            this.previousYearToolStripMenuItem.Name = "previousYearToolStripMenuItem";
            this.previousYearToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.previousYearToolStripMenuItem.Text = "Previous Year";
            this.previousYearToolStripMenuItem.Click += new System.EventHandler(this.previousYearToolStripMenuItem_Click);
            // 
            // nextYearToolStripMenuItem
            // 
            this.nextYearToolStripMenuItem.Name = "nextYearToolStripMenuItem";
            this.nextYearToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.nextYearToolStripMenuItem.Text = "Next Year";
            this.nextYearToolStripMenuItem.Click += new System.EventHandler(this.nextYearToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // manageCalendarsToolStripMenuItem
            // 
            this.manageCalendarsToolStripMenuItem.Name = "manageCalendarsToolStripMenuItem";
            this.manageCalendarsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.manageCalendarsToolStripMenuItem.Text = "Manage Calendars";
            // 
            // calendarsToolStripMenuItem
            // 
            this.calendarsToolStripMenuItem.Name = "calendarsToolStripMenuItem";
            this.calendarsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.calendarsToolStripMenuItem.Text = "Calendars";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(169, 6);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            // 
            // eventGroupBox
            // 
            this.eventGroupBox.Controls.Add(this.eventListBox);
            this.eventGroupBox.Location = new System.Drawing.Point(306, 0);
            this.eventGroupBox.Name = "eventGroupBox";
            this.eventGroupBox.Size = new System.Drawing.Size(147, 300);
            this.eventGroupBox.TabIndex = 1;
            this.eventGroupBox.TabStop = false;
            this.eventGroupBox.Text = "Date";
            // 
            // eventListBox
            // 
            this.eventListBox.FormattingEnabled = true;
            this.eventListBox.Location = new System.Drawing.Point(6, 12);
            this.eventListBox.Name = "eventListBox";
            this.eventListBox.Size = new System.Drawing.Size(135, 277);
            this.eventListBox.TabIndex = 0;
            this.eventListBox.MouseDoubleClick += new MouseEventHandler(eventListBox_MouseDoubleClick);
            // 
            // CalendarPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(458, 300);
            this.Controls.Add(this.eventGroupBox);
            this.Controls.Add(this.monthCalendar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalendarPanel";
            this.ShowInTaskbar = false;
            this.Text = "Calendar Panel";
            this.calendarContextMenu.ResumeLayout(false);
            this.eventGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public CalendarPanel(EventManager eventManager) : base("Calendar")
        {
            controller = eventManager;
            monthCalendar = controller.Calendar;
            InitializeComponent();
            eventList = new List<DateItem>();
        }

        private void monthCalendar_DaySelected(object sender, DaySelectedEventArgs e)
        {
            DateTime date = DateTime.Parse(e.Days[0]);
            eventList.Clear();
            eventList.AddRange(monthCalendar.GetDateInfo(date));

            eventListBox.Items.Clear();
            foreach(DateItem dateItem in eventList)
            {
                eventListBox.Items.Add(dateItem.Event.Summary);
            }
        }

        private void eventListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (eventListBox.SelectedIndex != -1)
            {
                var rect = eventListBox.GetItemRectangle(eventListBox.SelectedIndex);
                if (rect.Contains(e.Location))
                {
                    EventForm form = new EventForm(eventList[eventListBox.SelectedIndex]);
                    form.Show();
                }
            }
        }

        private void gotoTodayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            monthCalendar.ActiveMonth.Month = DateTime.Now.Month;
            monthCalendar.ActiveMonth.Year = DateTime.Now.Year;
            monthCalendar.SelectDate(DateTime.Now);
        }

        private void previousYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            monthCalendar.ActiveMonth.Year -= 1;
        }

        private void nextYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            monthCalendar.ActiveMonth.Year += 1;
        }
    }
}
