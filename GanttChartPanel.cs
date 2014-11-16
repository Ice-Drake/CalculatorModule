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
    public class GanttChartPanel : Form
    {
        private EventManager controller;

        #region Component Designer variables

        private IContainer components = null;
        private Chart chart;

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
            this.chart = new Library.Chart();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart.FullDateStringFormat = null;
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Margin = new System.Windows.Forms.Padding(0);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(458, 300);
            this.chart.TabIndex = 1;
            // 
            // GanttChartPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(458, 300);
            this.Controls.Add(this.chart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GanttChartPanel";
            this.ShowInTaskbar = false;
            this.Text = "Gantt Chart Panel";
            this.ResumeLayout(false);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GanttChartPanel_FormClosing);
        }

        #endregion

        public GanttChartPanel(GoalPlanner goalPlanner)
        {
            InitializeComponent();
            chart.Init(goalPlanner.ProjectManager);
            goalPlanner.GoalModify += new EventHandler(updateChart);
        }

        private void GanttChartPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void updateChart(object sender, EventArgs e)
        {
            chart.Invalidate();
            chart.Update();
        }
    }
}
