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
    public class CalculatorPanel : Form// MainPanel
    {
        private Calculator calculator;
        private Converter converter;

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
            this.calendarContextMenu.SuspendLayout();
            this.SuspendLayout();
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
            // 
            // previousYearToolStripMenuItem
            // 
            this.previousYearToolStripMenuItem.Name = "previousYearToolStripMenuItem";
            this.previousYearToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            // 
            // nextYearToolStripMenuItem
            // 
            this.nextYearToolStripMenuItem.Name = "nextYearToolStripMenuItem";
            this.nextYearToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
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
            // CalculatorPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(458, 300);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalculatorPanel";
            this.ShowInTaskbar = false;
            this.Text = "Calculator Panel";
            this.calendarContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public CalculatorPanel()// : base("Calculator")
        {
            InitializeComponent();
            
        }
    }
}
