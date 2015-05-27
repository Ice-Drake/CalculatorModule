using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Library;
using DDay.iCal;

namespace MultiDesktop
{
    public class PlannerPanel : MainPanel
    {
        private EventManager eventController;
        private TodoManager todoController;
        private GoalPlanner goalController;
        private IProjectManager projectController;

        #region Component Designer variables

        private Point mouseDownPos;
        private TableLayoutPanel tableLayoutPanel;
        private Label dateLabel1;
        private DataGridView eventDataGridView1;
        private Label dateLabel2;
        private Label dateLabel3;
        private Label dateLabel4;
        private Library.MonthCalendar monthCalendar;
        private Panel planningPanel;
        private DataGridView todoDataGridView3;
        private DataGridView todoDataGridView2;
        private DataGridView todoDataGridView1;
        private DataGridView todoDataGridView4;
        private DataGridView todoDataGridView7;
        private DataGridView todoDataGridView6;
        private DataGridView todoDataGridView5;
        private Label dateLabel5;
        private Label dateLabel6;
        private Label dateLabel7;
        private DataGridView eventDataGridView2;
        private DataGridView eventDataGridView3;
        private DataGridView eventDataGridView4;
        private DataGridView eventDataGridView5;
        private DataGridView eventDataGridView6;
        private DataGridView eventDataGridView7;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridView lateTodoDataGridView;
        private GroupBox groupBox3;
        private DataGridView goalDataGridView;
        private DataGridViewCheckBoxColumn dataGridViewTextBoxColumn45;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;
        private DataGridViewCheckBoxColumn dataGridViewTextBoxColumn44;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        private DataGridViewCheckBoxColumn dataGridViewTextBoxColumn43;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private DataGridViewCheckBoxColumn dataGridViewTextBoxColumn46;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private DataGridViewCheckBoxColumn dataGridViewTextBoxColumn49;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private DataGridViewCheckBoxColumn dataGridViewTextBoxColumn48;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private DataGridViewCheckBoxColumn dataGridViewTextBoxColumn47;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private DataGridViewTextBoxColumn summaryColumn1;
        private DataGridViewTextBoxColumn UIDColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn timeColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private DataGridViewTextBoxColumn timeColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private DataGridViewCheckBoxColumn dataGridViewTextBoxColumn50;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn42;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn41;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn40;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn53;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn51;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.todoDataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn45 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.todoDataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn44 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.todoDataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn43 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.todoDataGridView4 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn46 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.todoDataGridView7 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn49 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.todoDataGridView6 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn48 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.todoDataGridView5 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn47 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateLabel1 = new System.Windows.Forms.Label();
            this.eventDataGridView1 = new System.Windows.Forms.DataGridView();
            this.summaryColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UIDColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateLabel2 = new System.Windows.Forms.Label();
            this.dateLabel3 = new System.Windows.Forms.Label();
            this.dateLabel4 = new System.Windows.Forms.Label();
            this.dateLabel5 = new System.Windows.Forms.Label();
            this.dateLabel6 = new System.Windows.Forms.Label();
            this.dateLabel7 = new System.Windows.Forms.Label();
            this.eventDataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventDataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventDataGridView4 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventDataGridView5 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventDataGridView6 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventDataGridView7 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planningPanel = new System.Windows.Forms.Panel();
            //this.monthCalendar = new Library.MonthCalendar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lateTodoDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn50 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.goalDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn53 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn51 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.todoDataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.todoDataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.todoDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.todoDataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.todoDataGridView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.todoDataGridView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.todoDataGridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventDataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventDataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventDataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventDataGridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventDataGridView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventDataGridView7)).BeginInit();
            this.planningPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lateTodoDataGridView)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.goalDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 7;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel.Controls.Add(this.todoDataGridView3, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.todoDataGridView2, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.todoDataGridView1, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.todoDataGridView4, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.todoDataGridView7, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.todoDataGridView6, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.todoDataGridView5, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.dateLabel1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.eventDataGridView1, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.dateLabel2, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.dateLabel3, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.dateLabel4, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.dateLabel5, 4, 0);
            this.tableLayoutPanel.Controls.Add(this.dateLabel6, 5, 0);
            this.tableLayoutPanel.Controls.Add(this.dateLabel7, 6, 0);
            this.tableLayoutPanel.Controls.Add(this.eventDataGridView2, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.eventDataGridView3, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.eventDataGridView4, 3, 1);
            this.tableLayoutPanel.Controls.Add(this.eventDataGridView5, 4, 1);
            this.tableLayoutPanel.Controls.Add(this.eventDataGridView6, 5, 1);
            this.tableLayoutPanel.Controls.Add(this.eventDataGridView7, 6, 1);
            this.tableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 203F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1050, 337);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // todoDataGridView3
            // 
            this.todoDataGridView3.AllowDrop = true;
            this.todoDataGridView3.AllowUserToAddRows = false;
            this.todoDataGridView3.AllowUserToDeleteRows = false;
            this.todoDataGridView3.AllowUserToResizeColumns = false;
            this.todoDataGridView3.AllowUserToResizeRows = false;
            this.todoDataGridView3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.todoDataGridView3.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.todoDataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.todoDataGridView3.ColumnHeadersVisible = false;
            this.todoDataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn45,
            this.dataGridViewTextBoxColumn39,
            this.dataGridViewTextBoxColumn38,
            this.dataGridViewTextBoxColumn37});
            this.todoDataGridView3.Location = new System.Drawing.Point(303, 137);
            this.todoDataGridView3.MultiSelect = false;
            this.todoDataGridView3.Name = "todoDataGridView3";
            this.todoDataGridView3.RowHeadersVisible = false;
            this.todoDataGridView3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.todoDataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.todoDataGridView3.Size = new System.Drawing.Size(144, 197);
            this.todoDataGridView3.TabIndex = 21;
            this.todoDataGridView3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.todoDataGridView3.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            this.todoDataGridView3.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView_DragDrop);
            this.todoDataGridView3.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView_DragEnter);
            this.todoDataGridView3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView_MouseDown);
            this.todoDataGridView3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView_MouseMove);
            // 
            // dataGridViewTextBoxColumn45
            // 
            this.dataGridViewTextBoxColumn45.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn45.FalseValue = "false";
            this.dataGridViewTextBoxColumn45.HeaderText = "Status";
            this.dataGridViewTextBoxColumn45.Name = "dataGridViewTextBoxColumn45";
            this.dataGridViewTextBoxColumn45.TrueValue = "true";
            this.dataGridViewTextBoxColumn45.Width = 20;
            // 
            // dataGridViewTextBoxColumn39
            // 
            this.dataGridViewTextBoxColumn39.DataPropertyName = "Summary";
            this.dataGridViewTextBoxColumn39.HeaderText = "Summary";
            this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
            this.dataGridViewTextBoxColumn39.ReadOnly = true;
            this.dataGridViewTextBoxColumn39.Width = 145;
            // 
            // dataGridViewTextBoxColumn38
            // 
            this.dataGridViewTextBoxColumn38.DataPropertyName = "Priority";
            this.dataGridViewTextBoxColumn38.HeaderText = "Priority";
            this.dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
            this.dataGridViewTextBoxColumn38.Visible = false;
            // 
            // dataGridViewTextBoxColumn37
            // 
            this.dataGridViewTextBoxColumn37.DataPropertyName = "UID";
            this.dataGridViewTextBoxColumn37.HeaderText = "UID";
            this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
            this.dataGridViewTextBoxColumn37.Visible = false;
            // 
            // todoDataGridView2
            // 
            this.todoDataGridView2.AllowDrop = true;
            this.todoDataGridView2.AllowUserToAddRows = false;
            this.todoDataGridView2.AllowUserToDeleteRows = false;
            this.todoDataGridView2.AllowUserToResizeColumns = false;
            this.todoDataGridView2.AllowUserToResizeRows = false;
            this.todoDataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.todoDataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.todoDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.todoDataGridView2.ColumnHeadersVisible = false;
            this.todoDataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn44,
            this.dataGridViewTextBoxColumn36,
            this.dataGridViewTextBoxColumn35,
            this.dataGridViewTextBoxColumn34});
            this.todoDataGridView2.Location = new System.Drawing.Point(153, 137);
            this.todoDataGridView2.MultiSelect = false;
            this.todoDataGridView2.Name = "todoDataGridView2";
            this.todoDataGridView2.RowHeadersVisible = false;
            this.todoDataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.todoDataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.todoDataGridView2.Size = new System.Drawing.Size(144, 197);
            this.todoDataGridView2.TabIndex = 20;
            this.todoDataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.todoDataGridView2.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            this.todoDataGridView2.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView_DragDrop);
            this.todoDataGridView2.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView_DragEnter);
            this.todoDataGridView2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView_MouseDown);
            this.todoDataGridView2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView_MouseMove);
            // 
            // dataGridViewTextBoxColumn44
            // 
            this.dataGridViewTextBoxColumn44.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn44.FalseValue = "false";
            this.dataGridViewTextBoxColumn44.HeaderText = "Status";
            this.dataGridViewTextBoxColumn44.Name = "dataGridViewTextBoxColumn44";
            this.dataGridViewTextBoxColumn44.TrueValue = "true";
            this.dataGridViewTextBoxColumn44.Width = 20;
            // 
            // dataGridViewTextBoxColumn36
            // 
            this.dataGridViewTextBoxColumn36.DataPropertyName = "Summary";
            this.dataGridViewTextBoxColumn36.HeaderText = "Summary";
            this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
            this.dataGridViewTextBoxColumn36.ReadOnly = true;
            this.dataGridViewTextBoxColumn36.Width = 145;
            // 
            // dataGridViewTextBoxColumn35
            // 
            this.dataGridViewTextBoxColumn35.DataPropertyName = "Priority";
            this.dataGridViewTextBoxColumn35.HeaderText = "Priority";
            this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            this.dataGridViewTextBoxColumn35.Visible = false;
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.DataPropertyName = "UID";
            this.dataGridViewTextBoxColumn34.HeaderText = "UID";
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            this.dataGridViewTextBoxColumn34.Visible = false;
            // 
            // todoDataGridView1
            // 
            this.todoDataGridView1.AllowUserToAddRows = false;
            this.todoDataGridView1.AllowUserToDeleteRows = false;
            this.todoDataGridView1.AllowUserToResizeColumns = false;
            this.todoDataGridView1.AllowUserToResizeRows = false;
            this.todoDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.todoDataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.todoDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.todoDataGridView1.ColumnHeadersVisible = false;
            this.todoDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn43,
            this.dataGridViewTextBoxColumn33,
            this.dataGridViewTextBoxColumn32,
            this.dataGridViewTextBoxColumn31});
            this.todoDataGridView1.Location = new System.Drawing.Point(3, 137);
            this.todoDataGridView1.MultiSelect = false;
            this.todoDataGridView1.Name = "todoDataGridView1";
            this.todoDataGridView1.RowHeadersVisible = false;
            this.todoDataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.todoDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.todoDataGridView1.Size = new System.Drawing.Size(144, 197);
            this.todoDataGridView1.TabIndex = 19;
            this.todoDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.todoDataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            this.todoDataGridView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView_DragDrop);
            this.todoDataGridView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView_DragEnter);
            this.todoDataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView_MouseDown);
            this.todoDataGridView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView_MouseMove);
            // 
            // dataGridViewTextBoxColumn43
            // 
            this.dataGridViewTextBoxColumn43.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn43.FalseValue = "false";
            this.dataGridViewTextBoxColumn43.HeaderText = "Status";
            this.dataGridViewTextBoxColumn43.Name = "dataGridViewTextBoxColumn43";
            this.dataGridViewTextBoxColumn43.TrueValue = "true";
            this.dataGridViewTextBoxColumn43.Width = 20;
            // 
            // dataGridViewTextBoxColumn33
            // 
            this.dataGridViewTextBoxColumn33.DataPropertyName = "Summary";
            this.dataGridViewTextBoxColumn33.HeaderText = "Summary";
            this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            this.dataGridViewTextBoxColumn33.ReadOnly = true;
            this.dataGridViewTextBoxColumn33.Width = 145;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.DataPropertyName = "Priority";
            this.dataGridViewTextBoxColumn32.HeaderText = "Priority";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.Visible = false;
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.DataPropertyName = "UID";
            this.dataGridViewTextBoxColumn31.HeaderText = "UID";
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.Visible = false;
            // 
            // todoDataGridView4
            // 
            this.todoDataGridView4.AllowDrop = true;
            this.todoDataGridView4.AllowUserToAddRows = false;
            this.todoDataGridView4.AllowUserToDeleteRows = false;
            this.todoDataGridView4.AllowUserToResizeColumns = false;
            this.todoDataGridView4.AllowUserToResizeRows = false;
            this.todoDataGridView4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.todoDataGridView4.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.todoDataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.todoDataGridView4.ColumnHeadersVisible = false;
            this.todoDataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn46,
            this.dataGridViewTextBoxColumn30,
            this.dataGridViewTextBoxColumn29,
            this.dataGridViewTextBoxColumn28});
            this.todoDataGridView4.Location = new System.Drawing.Point(453, 137);
            this.todoDataGridView4.MultiSelect = false;
            this.todoDataGridView4.Name = "todoDataGridView4";
            this.todoDataGridView4.RowHeadersVisible = false;
            this.todoDataGridView4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.todoDataGridView4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.todoDataGridView4.Size = new System.Drawing.Size(144, 197);
            this.todoDataGridView4.TabIndex = 18;
            this.todoDataGridView4.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.todoDataGridView4.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            this.todoDataGridView4.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView_DragDrop);
            this.todoDataGridView4.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView_DragEnter);
            this.todoDataGridView4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView_MouseDown);
            this.todoDataGridView4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView_MouseMove);
            // 
            // dataGridViewTextBoxColumn46
            // 
            this.dataGridViewTextBoxColumn46.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn46.FalseValue = "false";
            this.dataGridViewTextBoxColumn46.HeaderText = "Status";
            this.dataGridViewTextBoxColumn46.Name = "dataGridViewTextBoxColumn46";
            this.dataGridViewTextBoxColumn46.TrueValue = "true";
            this.dataGridViewTextBoxColumn46.Width = 20;
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.DataPropertyName = "Summary";
            this.dataGridViewTextBoxColumn30.HeaderText = "Summary";
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            this.dataGridViewTextBoxColumn30.ReadOnly = true;
            this.dataGridViewTextBoxColumn30.Width = 145;
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.DataPropertyName = "Priority";
            this.dataGridViewTextBoxColumn29.HeaderText = "Priority";
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn29.Visible = false;
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.DataPropertyName = "UID";
            this.dataGridViewTextBoxColumn28.HeaderText = "UID";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.Visible = false;
            // 
            // todoDataGridView7
            // 
            this.todoDataGridView7.AllowDrop = true;
            this.todoDataGridView7.AllowUserToAddRows = false;
            this.todoDataGridView7.AllowUserToDeleteRows = false;
            this.todoDataGridView7.AllowUserToResizeColumns = false;
            this.todoDataGridView7.AllowUserToResizeRows = false;
            this.todoDataGridView7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.todoDataGridView7.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.todoDataGridView7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.todoDataGridView7.ColumnHeadersVisible = false;
            this.todoDataGridView7.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn49,
            this.dataGridViewTextBoxColumn27,
            this.dataGridViewTextBoxColumn26,
            this.dataGridViewTextBoxColumn25});
            this.todoDataGridView7.Location = new System.Drawing.Point(903, 137);
            this.todoDataGridView7.MultiSelect = false;
            this.todoDataGridView7.Name = "todoDataGridView7";
            this.todoDataGridView7.RowHeadersVisible = false;
            this.todoDataGridView7.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.todoDataGridView7.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.todoDataGridView7.Size = new System.Drawing.Size(144, 197);
            this.todoDataGridView7.TabIndex = 17;
            this.todoDataGridView7.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.todoDataGridView7.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            this.todoDataGridView7.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView_DragDrop);
            this.todoDataGridView7.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView_DragEnter);
            this.todoDataGridView7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView_MouseDown);
            this.todoDataGridView7.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView_MouseMove);
            // 
            // dataGridViewTextBoxColumn49
            // 
            this.dataGridViewTextBoxColumn49.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn49.FalseValue = "false";
            this.dataGridViewTextBoxColumn49.HeaderText = "Status";
            this.dataGridViewTextBoxColumn49.Name = "dataGridViewTextBoxColumn49";
            this.dataGridViewTextBoxColumn49.TrueValue = "true";
            this.dataGridViewTextBoxColumn49.Width = 20;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.DataPropertyName = "Summary";
            this.dataGridViewTextBoxColumn27.HeaderText = "Summary";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.ReadOnly = true;
            this.dataGridViewTextBoxColumn27.Width = 145;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.DataPropertyName = "Priority";
            this.dataGridViewTextBoxColumn26.HeaderText = "Priority";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.Visible = false;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "UID";
            this.dataGridViewTextBoxColumn25.HeaderText = "UID";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.Visible = false;
            // 
            // todoDataGridView6
            // 
            this.todoDataGridView6.AllowDrop = true;
            this.todoDataGridView6.AllowUserToAddRows = false;
            this.todoDataGridView6.AllowUserToDeleteRows = false;
            this.todoDataGridView6.AllowUserToResizeColumns = false;
            this.todoDataGridView6.AllowUserToResizeRows = false;
            this.todoDataGridView6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.todoDataGridView6.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.todoDataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.todoDataGridView6.ColumnHeadersVisible = false;
            this.todoDataGridView6.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn48,
            this.dataGridViewTextBoxColumn24,
            this.dataGridViewTextBoxColumn23,
            this.dataGridViewTextBoxColumn22});
            this.todoDataGridView6.Location = new System.Drawing.Point(753, 137);
            this.todoDataGridView6.MultiSelect = false;
            this.todoDataGridView6.Name = "todoDataGridView6";
            this.todoDataGridView6.RowHeadersVisible = false;
            this.todoDataGridView6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.todoDataGridView6.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.todoDataGridView6.Size = new System.Drawing.Size(144, 197);
            this.todoDataGridView6.TabIndex = 16;
            this.todoDataGridView6.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.todoDataGridView6.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            this.todoDataGridView6.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView_DragDrop);
            this.todoDataGridView6.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView_DragEnter);
            this.todoDataGridView6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView_MouseDown);
            this.todoDataGridView6.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView_MouseMove);
            // 
            // dataGridViewTextBoxColumn48
            // 
            this.dataGridViewTextBoxColumn48.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn48.FalseValue = "false";
            this.dataGridViewTextBoxColumn48.HeaderText = "Status";
            this.dataGridViewTextBoxColumn48.Name = "dataGridViewTextBoxColumn48";
            this.dataGridViewTextBoxColumn48.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn48.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn48.TrueValue = "true";
            this.dataGridViewTextBoxColumn48.Width = 20;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.DataPropertyName = "Summary";
            this.dataGridViewTextBoxColumn24.HeaderText = "Summary";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            this.dataGridViewTextBoxColumn24.Width = 145;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "Priority";
            this.dataGridViewTextBoxColumn23.HeaderText = "Priority";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.Visible = false;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "UID";
            this.dataGridViewTextBoxColumn22.HeaderText = "UID";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.Visible = false;
            // 
            // todoDataGridView5
            // 
            this.todoDataGridView5.AllowDrop = true;
            this.todoDataGridView5.AllowUserToAddRows = false;
            this.todoDataGridView5.AllowUserToDeleteRows = false;
            this.todoDataGridView5.AllowUserToResizeColumns = false;
            this.todoDataGridView5.AllowUserToResizeRows = false;
            this.todoDataGridView5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.todoDataGridView5.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.todoDataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.todoDataGridView5.ColumnHeadersVisible = false;
            this.todoDataGridView5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn47,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn19});
            this.todoDataGridView5.Location = new System.Drawing.Point(603, 137);
            this.todoDataGridView5.MultiSelect = false;
            this.todoDataGridView5.Name = "todoDataGridView5";
            this.todoDataGridView5.RowHeadersVisible = false;
            this.todoDataGridView5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.todoDataGridView5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.todoDataGridView5.Size = new System.Drawing.Size(144, 197);
            this.todoDataGridView5.TabIndex = 15;
            this.todoDataGridView5.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.todoDataGridView5.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            this.todoDataGridView5.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView_DragDrop);
            this.todoDataGridView5.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView_DragEnter);
            this.todoDataGridView5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView_MouseDown);
            this.todoDataGridView5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView_MouseMove);
            // 
            // dataGridViewTextBoxColumn47
            // 
            this.dataGridViewTextBoxColumn47.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn47.FalseValue = "false";
            this.dataGridViewTextBoxColumn47.HeaderText = "Status";
            this.dataGridViewTextBoxColumn47.Name = "dataGridViewTextBoxColumn47";
            this.dataGridViewTextBoxColumn47.TrueValue = "true";
            this.dataGridViewTextBoxColumn47.Width = 20;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "Summary";
            this.dataGridViewTextBoxColumn21.HeaderText = "Summary";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            this.dataGridViewTextBoxColumn21.Width = 145;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "Priority";
            this.dataGridViewTextBoxColumn20.HeaderText = "Priority";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.Visible = false;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "UID";
            this.dataGridViewTextBoxColumn19.HeaderText = "UID";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.Visible = false;
            // 
            // dateLabel1
            // 
            this.dateLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateLabel1.Location = new System.Drawing.Point(3, 0);
            this.dateLabel1.Name = "dateLabel1";
            this.dateLabel1.Size = new System.Drawing.Size(144, 18);
            this.dateLabel1.TabIndex = 0;
            this.dateLabel1.Text = "Date Label 1";
            this.dateLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // eventDataGridView1
            // 
            this.eventDataGridView1.AllowUserToAddRows = false;
            this.eventDataGridView1.AllowUserToDeleteRows = false;
            this.eventDataGridView1.AllowUserToResizeColumns = false;
            this.eventDataGridView1.AllowUserToResizeRows = false;
            this.eventDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventDataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.eventDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventDataGridView1.ColumnHeadersVisible = false;
            this.eventDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.summaryColumn1,
            this.UIDColumn1});
            this.eventDataGridView1.Location = new System.Drawing.Point(3, 21);
            this.eventDataGridView1.MultiSelect = false;
            this.eventDataGridView1.Name = "eventDataGridView1";
            this.eventDataGridView1.RowHeadersVisible = false;
            this.eventDataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eventDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.eventDataGridView1.Size = new System.Drawing.Size(144, 110);
            this.eventDataGridView1.TabIndex = 2;
            this.eventDataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // summaryColumn1
            // 
            this.summaryColumn1.DataPropertyName = "Summary";
            this.summaryColumn1.HeaderText = "Summary";
            this.summaryColumn1.Name = "summaryColumn1";
            this.summaryColumn1.ReadOnly = true;
            this.summaryColumn1.Width = 145;
            // 
            // UIDColumn1
            // 
            this.UIDColumn1.DataPropertyName = "UID";
            this.UIDColumn1.HeaderText = "UID";
            this.UIDColumn1.Name = "UIDColumn1";
            this.UIDColumn1.Visible = false;
            // 
            // dateLabel2
            // 
            this.dateLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateLabel2.Location = new System.Drawing.Point(153, 0);
            this.dateLabel2.Name = "dateLabel2";
            this.dateLabel2.Size = new System.Drawing.Size(144, 18);
            this.dateLabel2.TabIndex = 3;
            this.dateLabel2.Text = "Date Label 2";
            this.dateLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateLabel3
            // 
            this.dateLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateLabel3.Location = new System.Drawing.Point(303, 0);
            this.dateLabel3.Name = "dateLabel3";
            this.dateLabel3.Size = new System.Drawing.Size(144, 18);
            this.dateLabel3.TabIndex = 4;
            this.dateLabel3.Text = "Date Label 3";
            this.dateLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateLabel4
            // 
            this.dateLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateLabel4.Location = new System.Drawing.Point(453, 0);
            this.dateLabel4.Name = "dateLabel4";
            this.dateLabel4.Size = new System.Drawing.Size(144, 18);
            this.dateLabel4.TabIndex = 5;
            this.dateLabel4.Text = "Date Label 4";
            this.dateLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateLabel5
            // 
            this.dateLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateLabel5.Location = new System.Drawing.Point(603, 0);
            this.dateLabel5.Name = "dateLabel5";
            this.dateLabel5.Size = new System.Drawing.Size(144, 18);
            this.dateLabel5.TabIndex = 6;
            this.dateLabel5.Text = "Date Label 5";
            this.dateLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateLabel6
            // 
            this.dateLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateLabel6.Location = new System.Drawing.Point(753, 0);
            this.dateLabel6.Name = "dateLabel6";
            this.dateLabel6.Size = new System.Drawing.Size(144, 18);
            this.dateLabel6.TabIndex = 7;
            this.dateLabel6.Text = "Date Label 6";
            this.dateLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateLabel7
            // 
            this.dateLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateLabel7.Location = new System.Drawing.Point(903, 0);
            this.dateLabel7.Name = "dateLabel7";
            this.dateLabel7.Size = new System.Drawing.Size(144, 18);
            this.dateLabel7.TabIndex = 8;
            this.dateLabel7.Text = "Date Label 7";
            this.dateLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // eventDataGridView2
            // 
            this.eventDataGridView2.AllowUserToAddRows = false;
            this.eventDataGridView2.AllowUserToDeleteRows = false;
            this.eventDataGridView2.AllowUserToResizeColumns = false;
            this.eventDataGridView2.AllowUserToResizeRows = false;
            this.eventDataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventDataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.eventDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventDataGridView2.ColumnHeadersVisible = false;
            this.eventDataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn1});
            this.eventDataGridView2.Location = new System.Drawing.Point(153, 21);
            this.eventDataGridView2.MultiSelect = false;
            this.eventDataGridView2.Name = "eventDataGridView2";
            this.eventDataGridView2.RowHeadersVisible = false;
            this.eventDataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eventDataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.eventDataGridView2.Size = new System.Drawing.Size(144, 110);
            this.eventDataGridView2.TabIndex = 9;
            this.eventDataGridView2.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Summary";
            this.dataGridViewTextBoxColumn3.HeaderText = "Summary";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 145;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "UID";
            this.dataGridViewTextBoxColumn1.HeaderText = "UID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // eventDataGridView3
            // 
            this.eventDataGridView3.AllowUserToAddRows = false;
            this.eventDataGridView3.AllowUserToDeleteRows = false;
            this.eventDataGridView3.AllowUserToResizeColumns = false;
            this.eventDataGridView3.AllowUserToResizeRows = false;
            this.eventDataGridView3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventDataGridView3.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.eventDataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventDataGridView3.ColumnHeadersVisible = false;
            this.eventDataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn4});
            this.eventDataGridView3.Location = new System.Drawing.Point(303, 21);
            this.eventDataGridView3.MultiSelect = false;
            this.eventDataGridView3.Name = "eventDataGridView3";
            this.eventDataGridView3.RowHeadersVisible = false;
            this.eventDataGridView3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eventDataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.eventDataGridView3.Size = new System.Drawing.Size(144, 110);
            this.eventDataGridView3.TabIndex = 10;
            this.eventDataGridView3.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Summary";
            this.dataGridViewTextBoxColumn6.HeaderText = "Summary";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 145;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "UID";
            this.dataGridViewTextBoxColumn4.HeaderText = "UID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // eventDataGridView4
            // 
            this.eventDataGridView4.AllowUserToAddRows = false;
            this.eventDataGridView4.AllowUserToDeleteRows = false;
            this.eventDataGridView4.AllowUserToResizeColumns = false;
            this.eventDataGridView4.AllowUserToResizeRows = false;
            this.eventDataGridView4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventDataGridView4.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.eventDataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventDataGridView4.ColumnHeadersVisible = false;
            this.eventDataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn7});
            this.eventDataGridView4.Location = new System.Drawing.Point(453, 21);
            this.eventDataGridView4.MultiSelect = false;
            this.eventDataGridView4.Name = "eventDataGridView4";
            this.eventDataGridView4.RowHeadersVisible = false;
            this.eventDataGridView4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eventDataGridView4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.eventDataGridView4.Size = new System.Drawing.Size(144, 110);
            this.eventDataGridView4.TabIndex = 11;
            this.eventDataGridView4.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Summary";
            this.dataGridViewTextBoxColumn9.HeaderText = "Summary";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 145;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "UID";
            this.dataGridViewTextBoxColumn7.HeaderText = "UID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // eventDataGridView5
            // 
            this.eventDataGridView5.AllowUserToAddRows = false;
            this.eventDataGridView5.AllowUserToDeleteRows = false;
            this.eventDataGridView5.AllowUserToResizeColumns = false;
            this.eventDataGridView5.AllowUserToResizeRows = false;
            this.eventDataGridView5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventDataGridView5.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.eventDataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventDataGridView5.ColumnHeadersVisible = false;
            this.eventDataGridView5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn10});
            this.eventDataGridView5.Location = new System.Drawing.Point(603, 21);
            this.eventDataGridView5.MultiSelect = false;
            this.eventDataGridView5.Name = "eventDataGridView5";
            this.eventDataGridView5.RowHeadersVisible = false;
            this.eventDataGridView5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eventDataGridView5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.eventDataGridView5.Size = new System.Drawing.Size(144, 110);
            this.eventDataGridView5.TabIndex = 12;
            this.eventDataGridView5.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Summary";
            this.dataGridViewTextBoxColumn12.HeaderText = "Summary";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 145;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "UID";
            this.dataGridViewTextBoxColumn10.HeaderText = "UID";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // eventDataGridView6
            // 
            this.eventDataGridView6.AllowUserToAddRows = false;
            this.eventDataGridView6.AllowUserToDeleteRows = false;
            this.eventDataGridView6.AllowUserToResizeColumns = false;
            this.eventDataGridView6.AllowUserToResizeRows = false;
            this.eventDataGridView6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventDataGridView6.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.eventDataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventDataGridView6.ColumnHeadersVisible = false;
            this.eventDataGridView6.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn14,
            this.timeColumn6,
            this.dataGridViewTextBoxColumn13});
            this.eventDataGridView6.Location = new System.Drawing.Point(753, 21);
            this.eventDataGridView6.MultiSelect = false;
            this.eventDataGridView6.Name = "eventDataGridView6";
            this.eventDataGridView6.RowHeadersVisible = false;
            this.eventDataGridView6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eventDataGridView6.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.eventDataGridView6.Size = new System.Drawing.Size(144, 110);
            this.eventDataGridView6.TabIndex = 13;
            this.eventDataGridView6.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Summary";
            this.dataGridViewTextBoxColumn15.HeaderText = "Summary";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 145;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Location";
            this.dataGridViewTextBoxColumn14.HeaderText = "Location";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // timeColumn6
            // 
            this.timeColumn6.DataPropertyName = "Time";
            this.timeColumn6.HeaderText = "Time";
            this.timeColumn6.Name = "timeColumn6";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "UID";
            this.dataGridViewTextBoxColumn13.HeaderText = "UID";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Visible = false;
            // 
            // eventDataGridView7
            // 
            this.eventDataGridView7.AllowUserToAddRows = false;
            this.eventDataGridView7.AllowUserToDeleteRows = false;
            this.eventDataGridView7.AllowUserToResizeColumns = false;
            this.eventDataGridView7.AllowUserToResizeRows = false;
            this.eventDataGridView7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventDataGridView7.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.eventDataGridView7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventDataGridView7.ColumnHeadersVisible = false;
            this.eventDataGridView7.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn17,
            this.timeColumn7,
            this.dataGridViewTextBoxColumn16});
            this.eventDataGridView7.Location = new System.Drawing.Point(903, 21);
            this.eventDataGridView7.MultiSelect = false;
            this.eventDataGridView7.Name = "eventDataGridView7";
            this.eventDataGridView7.RowHeadersVisible = false;
            this.eventDataGridView7.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eventDataGridView7.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.eventDataGridView7.Size = new System.Drawing.Size(144, 110);
            this.eventDataGridView7.TabIndex = 14;
            this.eventDataGridView7.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "Summary";
            this.dataGridViewTextBoxColumn18.HeaderText = "Summary";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Width = 145;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "Location";
            this.dataGridViewTextBoxColumn17.HeaderText = "Location";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            // 
            // timeColumn7
            // 
            this.timeColumn7.DataPropertyName = "Time";
            this.timeColumn7.HeaderText = "Time";
            this.timeColumn7.Name = "timeColumn7";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "UID";
            this.dataGridViewTextBoxColumn16.HeaderText = "UID";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Visible = false;
            // 
            // planningPanel
            // 
            this.planningPanel.AutoScroll = true;
            this.planningPanel.BackColor = System.Drawing.SystemColors.Window;
            this.planningPanel.Controls.Add(this.tableLayoutPanel);
            this.planningPanel.Location = new System.Drawing.Point(6, 18);
            this.planningPanel.Name = "planningPanel";
            this.planningPanel.Size = new System.Drawing.Size(757, 360);
            this.planningPanel.TabIndex = 0;
            // 
            // monthCalendar
            // 
            this.monthCalendar.Culture = new System.Globalization.CultureInfo("en-US");
            this.monthCalendar.Footer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.monthCalendar.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.monthCalendar.Header.TextColor = System.Drawing.Color.White;
            this.monthCalendar.ImageList = null;
            this.monthCalendar.Location = new System.Drawing.Point(177, 402);
            this.monthCalendar.Month.BackgroundImage = null;
            this.monthCalendar.Month.DateFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar.Month.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.Size = new System.Drawing.Size(222, 222);
            this.monthCalendar.TabIndex = 8;
            this.monthCalendar.Weekdays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar.Weeknumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.planningPanel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(769, 384);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Schedule";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lateTodoDataGridView);
            this.groupBox2.Location = new System.Drawing.Point(12, 402);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(159, 222);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Late Todos";
            // 
            // lateTodoDataGridView
            // 
            this.lateTodoDataGridView.AllowUserToAddRows = false;
            this.lateTodoDataGridView.AllowUserToDeleteRows = false;
            this.lateTodoDataGridView.AllowUserToResizeColumns = false;
            this.lateTodoDataGridView.AllowUserToResizeRows = false;
            this.lateTodoDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.lateTodoDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.lateTodoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lateTodoDataGridView.ColumnHeadersVisible = false;
            this.lateTodoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn50,
            this.dataGridViewTextBoxColumn42,
            this.dataGridViewTextBoxColumn41,
            this.dataGridViewTextBoxColumn40});
            this.lateTodoDataGridView.Location = new System.Drawing.Point(6, 19);
            this.lateTodoDataGridView.MultiSelect = false;
            this.lateTodoDataGridView.Name = "lateTodoDataGridView";
            this.lateTodoDataGridView.RowHeadersVisible = false;
            this.lateTodoDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lateTodoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lateTodoDataGridView.Size = new System.Drawing.Size(147, 197);
            this.lateTodoDataGridView.TabIndex = 20;
            this.lateTodoDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.lateTodoDataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView_MouseDown);
            this.lateTodoDataGridView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView_MouseMove);
            // 
            // dataGridViewTextBoxColumn50
            // 
            this.dataGridViewTextBoxColumn50.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn50.FalseValue = "false";
            this.dataGridViewTextBoxColumn50.HeaderText = "Status";
            this.dataGridViewTextBoxColumn50.Name = "dataGridViewTextBoxColumn50";
            this.dataGridViewTextBoxColumn50.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn50.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn50.TrueValue = "true";
            this.dataGridViewTextBoxColumn50.Width = 20;
            // 
            // dataGridViewTextBoxColumn42
            // 
            this.dataGridViewTextBoxColumn42.DataPropertyName = "Summary";
            this.dataGridViewTextBoxColumn42.HeaderText = "Summary";
            this.dataGridViewTextBoxColumn42.Name = "dataGridViewTextBoxColumn42";
            this.dataGridViewTextBoxColumn42.ReadOnly = true;
            this.dataGridViewTextBoxColumn42.Width = 145;
            // 
            // dataGridViewTextBoxColumn41
            // 
            this.dataGridViewTextBoxColumn41.DataPropertyName = "Priority";
            this.dataGridViewTextBoxColumn41.HeaderText = "Priority";
            this.dataGridViewTextBoxColumn41.Name = "dataGridViewTextBoxColumn41";
            this.dataGridViewTextBoxColumn41.Visible = false;
            // 
            // dataGridViewTextBoxColumn40
            // 
            this.dataGridViewTextBoxColumn40.DataPropertyName = "UID";
            this.dataGridViewTextBoxColumn40.HeaderText = "UID";
            this.dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
            this.dataGridViewTextBoxColumn40.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.goalDataGridView);
            this.groupBox3.Location = new System.Drawing.Point(405, 402);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(376, 222);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Current Goals";
            // 
            // goalDataGridView
            // 
            this.goalDataGridView.AllowUserToAddRows = false;
            this.goalDataGridView.AllowUserToDeleteRows = false;
            this.goalDataGridView.AllowUserToResizeColumns = false;
            this.goalDataGridView.AllowUserToResizeRows = false;
            this.goalDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.goalDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.goalDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.goalDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn53,
            this.Column1,
            this.Column2,
            this.dataGridViewTextBoxColumn51});
            this.goalDataGridView.Location = new System.Drawing.Point(6, 19);
            this.goalDataGridView.MultiSelect = false;
            this.goalDataGridView.Name = "goalDataGridView";
            this.goalDataGridView.RowHeadersVisible = false;
            this.goalDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.goalDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.goalDataGridView.Size = new System.Drawing.Size(364, 197);
            this.goalDataGridView.TabIndex = 20;
            this.goalDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.goalDataGridView_CellContentClick);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "Complete";
            this.dataGridViewCheckBoxColumn1.FalseValue = "false";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Status";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn1.TrueValue = "true";
            this.dataGridViewCheckBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn53
            // 
            this.dataGridViewTextBoxColumn53.DataPropertyName = "Summary";
            this.dataGridViewTextBoxColumn53.HeaderText = "Summary";
            this.dataGridViewTextBoxColumn53.Name = "dataGridViewTextBoxColumn53";
            this.dataGridViewTextBoxColumn53.ReadOnly = true;
            this.dataGridViewTextBoxColumn53.Width = 155;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Start";
            this.Column1.HeaderText = "Start";
            this.Column1.Name = "Column1";
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Days Remaining";
            this.Column2.HeaderText = "Days Left";
            this.Column2.Name = "Column2";
            this.Column2.Width = 80;
            // 
            // dataGridViewTextBoxColumn51
            // 
            this.dataGridViewTextBoxColumn51.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn51.HeaderText = "ID";
            this.dataGridViewTextBoxColumn51.Name = "dataGridViewTextBoxColumn51";
            this.dataGridViewTextBoxColumn51.Visible = false;
            // 
            // PlannerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 636);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.monthCalendar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PlannerPanel";
            this.ShowInTaskbar = false;
            this.Text = "Planner Panel";
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.todoDataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.todoDataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.todoDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.todoDataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.todoDataGridView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.todoDataGridView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.todoDataGridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventDataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventDataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventDataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventDataGridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventDataGridView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventDataGridView7)).EndInit();
            this.planningPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lateTodoDataGridView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.goalDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public PlannerPanel(EventManager eventManager, TodoManager todoManager, GoalPlanner goalManager) : base("Planner")
        {
            eventController = eventManager;
            todoController = todoManager;
            goalController = goalManager;

            monthCalendar = new Library.MonthCalendar(eventController.Calendar.Dates);

            InitializeComponent();

            dateLabel1.BackColor = weeklyColor(DateTime.Today.DayOfWeek);
            eventDataGridView1.BackgroundColor = weeklyColor(DateTime.Today.DayOfWeek);
            eventDataGridView1.DefaultCellStyle.BackColor = weeklyColor(DateTime.Today.DayOfWeek);
            todoDataGridView1.BackgroundColor = weeklyColor(DateTime.Today.DayOfWeek);
            todoDataGridView1.DefaultCellStyle.BackColor = weeklyColor(DateTime.Today.DayOfWeek);

            dateLabel2.BackColor = weeklyColor(DateTime.Today.AddDays(1).DayOfWeek);
            eventDataGridView2.BackgroundColor = weeklyColor(DateTime.Today.AddDays(1).DayOfWeek);
            eventDataGridView2.DefaultCellStyle.BackColor = weeklyColor(DateTime.Today.AddDays(1).DayOfWeek);
            todoDataGridView2.BackgroundColor = weeklyColor(DateTime.Today.AddDays(1).DayOfWeek);
            todoDataGridView2.DefaultCellStyle.BackColor = weeklyColor(DateTime.Today.AddDays(1).DayOfWeek);
            
            dateLabel3.BackColor = weeklyColor(DateTime.Today.AddDays(2).DayOfWeek);
            eventDataGridView3.BackgroundColor = weeklyColor(DateTime.Today.AddDays(2).DayOfWeek);
            eventDataGridView3.DefaultCellStyle.BackColor = weeklyColor(DateTime.Today.AddDays(2).DayOfWeek);
            todoDataGridView3.BackgroundColor = weeklyColor(DateTime.Today.AddDays(2).DayOfWeek);
            todoDataGridView3.DefaultCellStyle.BackColor = weeklyColor(DateTime.Today.AddDays(2).DayOfWeek);
            
            dateLabel4.BackColor = weeklyColor(DateTime.Today.AddDays(3).DayOfWeek);
            eventDataGridView4.BackgroundColor = weeklyColor(DateTime.Today.AddDays(3).DayOfWeek);
            eventDataGridView4.DefaultCellStyle.BackColor = weeklyColor(DateTime.Today.AddDays(3).DayOfWeek);
            todoDataGridView4.BackgroundColor = weeklyColor(DateTime.Today.AddDays(3).DayOfWeek);
            todoDataGridView4.DefaultCellStyle.BackColor = weeklyColor(DateTime.Today.AddDays(3).DayOfWeek);
            
            dateLabel5.BackColor = weeklyColor(DateTime.Today.AddDays(4).DayOfWeek);
            eventDataGridView5.BackgroundColor = weeklyColor(DateTime.Today.AddDays(4).DayOfWeek);
            eventDataGridView5.DefaultCellStyle.BackColor = weeklyColor(DateTime.Today.AddDays(4).DayOfWeek);
            todoDataGridView5.BackgroundColor = weeklyColor(DateTime.Today.AddDays(4).DayOfWeek);
            todoDataGridView5.DefaultCellStyle.BackColor = weeklyColor(DateTime.Today.AddDays(4).DayOfWeek);
            
            dateLabel6.BackColor = weeklyColor(DateTime.Today.AddDays(5).DayOfWeek);
            eventDataGridView6.BackgroundColor = weeklyColor(DateTime.Today.AddDays(5).DayOfWeek);
            eventDataGridView6.DefaultCellStyle.BackColor = weeklyColor(DateTime.Today.AddDays(5).DayOfWeek);
            todoDataGridView6.BackgroundColor = weeklyColor(DateTime.Today.AddDays(5).DayOfWeek);
            todoDataGridView6.DefaultCellStyle.BackColor = weeklyColor(DateTime.Today.AddDays(5).DayOfWeek);
            
            dateLabel7.BackColor = weeklyColor(DateTime.Today.AddDays(6).DayOfWeek);
            eventDataGridView7.BackgroundColor = weeklyColor(DateTime.Today.AddDays(6).DayOfWeek);
            eventDataGridView7.DefaultCellStyle.BackColor = weeklyColor(DateTime.Today.AddDays(6).DayOfWeek);
            todoDataGridView7.BackgroundColor = weeklyColor(DateTime.Today.AddDays(6).DayOfWeek);
            todoDataGridView7.DefaultCellStyle.BackColor = weeklyColor(DateTime.Today.AddDays(6).DayOfWeek);

            dateLabel1.Text = DateTime.Today.ToString("dddd, MMMM d");
            dateLabel2.Text = DateTime.Today.AddDays(1).ToString("dddd, MMMM d");
            dateLabel3.Text = DateTime.Today.AddDays(2).ToString("dddd, MMMM d");
            dateLabel4.Text = DateTime.Today.AddDays(3).ToString("dddd, MMMM d");
            dateLabel5.Text = DateTime.Today.AddDays(4).ToString("dddd, MMMM d");
            dateLabel6.Text = DateTime.Today.AddDays(5).ToString("dddd, MMMM d");
            dateLabel7.Text = DateTime.Today.AddDays(6).ToString("dddd, MMMM d");

            DataView todayEventView = new DataView();
            todayEventView.Table = eventController.EventTable;
            todayEventView.RowFilter = String.Format(System.Globalization.DateTimeFormatInfo.InvariantInfo, "Convert(Date, System.DateTime) = #{0}#", DateTime.Today);
            
            DataView tomorrowEventView = new DataView();
            tomorrowEventView.Table = eventController.EventTable;
            tomorrowEventView.RowFilter = String.Format(System.Globalization.DateTimeFormatInfo.InvariantInfo, "Convert(Date, System.DateTime) = #{0}#", DateTime.Today.AddDays(1));

            DataView day3EventView = new DataView();
            day3EventView.Table = eventController.EventTable;
            day3EventView.RowFilter = String.Format(System.Globalization.DateTimeFormatInfo.InvariantInfo, "Convert(Date, System.DateTime) = #{0}#", DateTime.Today.AddDays(2));

            DataView day4EventView = new DataView();
            day4EventView.Table = eventController.EventTable;
            day4EventView.RowFilter = String.Format(System.Globalization.DateTimeFormatInfo.InvariantInfo, "Convert(Date, System.DateTime) = #{0}#", DateTime.Today.AddDays(3));

            DataView day5EventView = new DataView();
            day5EventView.Table = eventController.EventTable;
            day5EventView.RowFilter = String.Format(System.Globalization.DateTimeFormatInfo.InvariantInfo, "Convert(Date, System.DateTime) = #{0}#", DateTime.Today.AddDays(4));

            DataView day6EventView = new DataView();
            day6EventView.Table = eventController.EventTable;
            day6EventView.RowFilter = String.Format(System.Globalization.DateTimeFormatInfo.InvariantInfo, "Convert(Date, System.DateTime) = #{0}#", DateTime.Today.AddDays(5));

            DataView day7EventView = new DataView();
            day7EventView.Table = eventController.EventTable;
            day7EventView.RowFilter = String.Format(System.Globalization.DateTimeFormatInfo.InvariantInfo, "Convert(Date, System.DateTime) = #{0}#", DateTime.Today.AddDays(6));

            eventDataGridView1.AutoGenerateColumns = false;
            eventDataGridView1.DataSource = todayEventView;
            
            eventDataGridView2.AutoGenerateColumns = false;
            eventDataGridView2.DataSource = tomorrowEventView;

            eventDataGridView3.AutoGenerateColumns = false;
            eventDataGridView3.DataSource = day3EventView;

            eventDataGridView4.AutoGenerateColumns = false;
            eventDataGridView4.DataSource = day4EventView;

            eventDataGridView5.AutoGenerateColumns = false;
            eventDataGridView5.DataSource = day5EventView;

            eventDataGridView6.AutoGenerateColumns = false;
            eventDataGridView6.DataSource = day6EventView;

            eventDataGridView7.AutoGenerateColumns = false;
            eventDataGridView7.DataSource = day6EventView;

            DataView todayTodoView = new DataView();
            todayTodoView.Table = todoController.TodoTable;
            todayTodoView.RowFilter = String.Format(System.Globalization.DateTimeFormatInfo.InvariantInfo, "IIF(DueDate = 'None', IIF(StartDate = 'None', false, Convert(StartDate, System.DateTime) = #{0}#), IIF(StartDate = 'None', Convert(DueDate, System.DateTime) = #{0}#, Convert(StartDate, System.DateTime) <= #{0}# And Convert(DueDate, System.DateTime) >= #{0}#))", DateTime.Today);
            todayTodoView.Sort = "Priority ASC";

            DataView tomorrowTodoView = new DataView();
            tomorrowTodoView.Table = todoController.TodoTable;
            tomorrowTodoView.RowFilter = String.Format(System.Globalization.DateTimeFormatInfo.InvariantInfo, "IIF(DueDate = 'None', IIF(StartDate = 'None', false, Convert(StartDate, System.DateTime) = #{0}#), IIF(StartDate = 'None', Convert(DueDate, System.DateTime) = #{0}#, Convert(StartDate, System.DateTime) <= #{0}# And Convert(DueDate, System.DateTime) >= #{0}#))", DateTime.Today.AddDays(1));
            tomorrowTodoView.Sort = "Priority ASC";

            DataView day3TodoView = new DataView();
            day3TodoView.Table = todoController.TodoTable;
            day3TodoView.RowFilter = String.Format(System.Globalization.DateTimeFormatInfo.InvariantInfo, "IIF(DueDate = 'None', IIF(StartDate = 'None', false, Convert(StartDate, System.DateTime) = #{0}#), IIF(StartDate = 'None', Convert(DueDate, System.DateTime) = #{0}#, Convert(StartDate, System.DateTime) <= #{0}# And Convert(DueDate, System.DateTime) >= #{0}#))", DateTime.Today.AddDays(2));
            day3TodoView.Sort = "Priority ASC";

            DataView day4TodoView = new DataView();
            day4TodoView.Table = todoController.TodoTable;
            day4TodoView.RowFilter = String.Format(System.Globalization.DateTimeFormatInfo.InvariantInfo, "IIF(DueDate = 'None', IIF(StartDate = 'None', false, Convert(StartDate, System.DateTime) = #{0}#), IIF(StartDate = 'None', Convert(DueDate, System.DateTime) = #{0}#, Convert(StartDate, System.DateTime) <= #{0}# And Convert(DueDate, System.DateTime) >= #{0}#))", DateTime.Today.AddDays(3));
            day4TodoView.Sort = "Priority ASC";

            DataView day5TodoView = new DataView();
            day5TodoView.Table = todoController.TodoTable;
            day5TodoView.RowFilter = String.Format(System.Globalization.DateTimeFormatInfo.InvariantInfo, "IIF(DueDate = 'None', IIF(StartDate = 'None', false, Convert(StartDate, System.DateTime) = #{0}#), IIF(StartDate = 'None', Convert(DueDate, System.DateTime) = #{0}#, Convert(StartDate, System.DateTime) <= #{0}# And Convert(DueDate, System.DateTime) >= #{0}#))", DateTime.Today.AddDays(4));
            day5TodoView.Sort = "Priority ASC";

            DataView day6TodoView = new DataView();
            day6TodoView.Table = todoController.TodoTable;
            day6TodoView.RowFilter = String.Format(System.Globalization.DateTimeFormatInfo.InvariantInfo, "IIF(DueDate = 'None', IIF(StartDate = 'None', false, Convert(StartDate, System.DateTime) = #{0}#), IIF(StartDate = 'None', Convert(DueDate, System.DateTime) = #{0}#, Convert(StartDate, System.DateTime) <= #{0}# And Convert(DueDate, System.DateTime) >= #{0}#))", DateTime.Today.AddDays(5));
            day6TodoView.Sort = "Priority ASC";

            DataView day7TodoView = new DataView();
            day7TodoView.Table = todoController.TodoTable;
            day7TodoView.RowFilter = String.Format(System.Globalization.DateTimeFormatInfo.InvariantInfo, "IIF(DueDate = 'None', IIF(StartDate = 'None', false, Convert(StartDate, System.DateTime) = #{0}#), IIF(StartDate = 'None', Convert(DueDate, System.DateTime) = #{0}#, Convert(StartDate, System.DateTime) <= #{0}# And Convert(DueDate, System.DateTime) >= #{0}#))", DateTime.Today.AddDays(6));
            day7TodoView.Sort = "Priority ASC";

            DataView lateTodoView = new DataView();
            lateTodoView.Table = todoController.TodoTable;
            lateTodoView.RowFilter = String.Format(System.Globalization.DateTimeFormatInfo.InvariantInfo, "Status = false AND IIF(DueDate = 'None', IIF(StartDate = 'None', false, Convert(StartDate, System.DateTime) < #{0}#), Convert(DueDate, System.DateTime) < #{0}#)", DateTime.Today);
            lateTodoView.Sort = "Priority ASC";

            todoDataGridView1.AutoGenerateColumns = false;
            todoDataGridView1.DataSource = todayTodoView;
            todoDataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView_CellFormatting);
            
            todoDataGridView2.AutoGenerateColumns = false;
            todoDataGridView2.DataSource = tomorrowTodoView;
            todoDataGridView2.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView_CellFormatting);

            todoDataGridView3.AutoGenerateColumns = false;
            todoDataGridView3.DataSource = day3TodoView;
            todoDataGridView3.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView_CellFormatting);

            todoDataGridView4.AutoGenerateColumns = false;
            todoDataGridView4.DataSource = day4TodoView;
            todoDataGridView4.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView_CellFormatting);

            todoDataGridView5.AutoGenerateColumns = false;
            todoDataGridView5.DataSource = day5TodoView;
            todoDataGridView5.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView_CellFormatting);

            todoDataGridView6.AutoGenerateColumns = false;
            todoDataGridView6.DataSource = day6TodoView;
            todoDataGridView6.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView_CellFormatting);

            todoDataGridView7.AutoGenerateColumns = false;
            todoDataGridView7.DataSource = day7TodoView;
            todoDataGridView7.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView_CellFormatting);

            lateTodoDataGridView.AutoGenerateColumns = false;
            lateTodoDataGridView.DataSource = lateTodoView;
            lateTodoDataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView_CellFormatting);

            DataView currentGoalView = new DataView();
            currentGoalView.Table = goalController.SGoalTable;
            currentGoalView.RowFilter = String.Format(System.Globalization.DateTimeFormatInfo.InvariantInfo, "Complete = false AND (Convert(Start, System.DateTime) <= #{0}# OR Convert(Due, System.DateTime) <= #{0}#)", DateTime.Today.AddDays(6));
            currentGoalView.Sort = "Start ASC";

            goalDataGridView.AutoGenerateColumns = false;
            goalDataGridView.DataSource = currentGoalView;
        }

        public void expandPanel(IProjectManager projectManager)
        {
            projectController = projectManager;

            planningPanel.Size = new Size(757, 476);
            tableLayoutPanel.Size = new Size(1050, 337);
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 116F));

            for (int i = 0; i < 7; i++)
            {
                DataView dataView = new DataView();
                dataView.Table = projectController.ITaskTable;
                dataView.RowFilter = String.Format(System.Globalization.DateTimeFormatInfo.InvariantInfo, "Convert(StartDate, System.DateTime) <= #{0}# And Convert(DueDate, System.DateTime) >= #{0}#)", DateTime.Today.AddDays(i));
                dataView.Sort = "Start ASC";

                DataGridView dataGridView = getITaskDataGridView();
                dataGridView.AutoGenerateColumns = false;
                dataGridView.BackgroundColor = weeklyColor(DateTime.Today.AddDays(i).DayOfWeek);
                dataGridView.DataSource = dataView;
                dataGridView.DefaultCellStyle.BackColor = weeklyColor(DateTime.Today.AddDays(i).DayOfWeek);

                tableLayoutPanel.Controls.Add(dataGridView, 0, 3);
            }
        }

        private DataGridView getITaskDataGridView()
        {
            DataGridViewCheckBoxColumn statusGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            statusGridViewCheckBoxColumn.DataPropertyName = "Complete";
            statusGridViewCheckBoxColumn.FalseValue = "false";
            statusGridViewCheckBoxColumn.HeaderText = "Status";
            statusGridViewCheckBoxColumn.TrueValue = "true";
            statusGridViewCheckBoxColumn.Width = 20;

            DataGridViewTextBoxColumn summaryGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            summaryGridViewTextBoxColumn.DataPropertyName = "Summary";
            summaryGridViewTextBoxColumn.HeaderText = "Summary";
            summaryGridViewTextBoxColumn.ReadOnly = true;
            summaryGridViewTextBoxColumn.Width = 145;

            DataGridViewTextBoxColumn idGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idGridViewTextBoxColumn.DataPropertyName = "ID";
            idGridViewTextBoxColumn.HeaderText = "ID";
            idGridViewTextBoxColumn.Visible = false;

            DataGridView iTaskDataGridView = new DataGridView();
            iTaskDataGridView.AllowUserToAddRows = false;
            iTaskDataGridView.AllowUserToDeleteRows = false;
            iTaskDataGridView.AllowUserToResizeColumns = false;
            iTaskDataGridView.AllowUserToResizeRows = false;
            iTaskDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            iTaskDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            iTaskDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            iTaskDataGridView.ColumnHeadersVisible = false;
            iTaskDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            statusGridViewCheckBoxColumn,
            summaryGridViewTextBoxColumn,
            idGridViewTextBoxColumn});
            iTaskDataGridView.Location = new System.Drawing.Point(3, 137);
            iTaskDataGridView.MultiSelect = false;
            iTaskDataGridView.RowHeadersVisible = false;
            iTaskDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            iTaskDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            iTaskDataGridView.Size = new System.Drawing.Size(144, 197);
            iTaskDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            iTaskDataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            
            return iTaskDataGridView;
        }

        private Color weeklyColor(DayOfWeek day)
        {
            switch(day)
            {
                case DayOfWeek.Monday: return Color.LightSkyBlue;
                case DayOfWeek.Tuesday: return Color.Turquoise;
                case DayOfWeek.Wednesday: return Color.PaleGreen;
                case DayOfWeek.Thursday: return Color.LightSalmon;
                case DayOfWeek.Friday: return Color.PaleTurquoise;
                case DayOfWeek.Saturday: return Color.LightGoldenrodYellow;
                default: return Color.Pink;
            }
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView source = (DataGridView)sender;
            source.SelectionChanged -= dataGridView_SelectionChanged;
            source.ClearSelection();
            source.SelectionChanged += dataGridView_SelectionChanged;
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                int priority = Int32.Parse(row.Cells[2].Value.ToString());
                
                if (priority == 1)
                {
                    row.Cells[3].Style.ForeColor = Color.Red;
                }
                else if (priority == 2)
                {
                    row.Cells[3].Style.ForeColor = Color.OrangeRed;
                }
                else if (priority == 3)
                {
                    row.Cells[3].Style.ForeColor = Color.Orange;
                }
                else if (priority == 4)
                {
                    row.Cells[3].Style.ForeColor = Color.Yellow;
                }
                else if (priority == 5)
                {
                    row.Cells[3].Style.ForeColor = Color.Green;
                }
                else if (priority == 6 || priority == 7)
                {
                    row.Cells[3].Style.ForeColor = Color.Teal;
                }
                else
                {
                    row.Cells[3].Style.ForeColor = Color.Blue;
                }
            }

            dataGridView.Update();
        }

        private void dataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownPos = e.Location;
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridView source = (DataGridView)sender;
                string uid = source.Rows[e.RowIndex].Cells[3].Value.ToString();

                if (!goalController.TaskManager.GTaskList.ContainsKey(uid))
                {
                    ITodo todo = todoController.TodoList[uid];
                    if (todo.Status == TodoStatus.Completed)
                        todo.Status = TodoStatus.NeedsAction;
                    else
                    {
                        if (todo.RecurrenceRules.Count > 0)
                            todoController.setNextOccurrence(todo);
                        else
                            todo.Status = TodoStatus.Completed;
                    }
                    todoController.updateTodo(todo);
                }
                else
                {
                    GTask task = goalController.TaskManager.GTaskList[uid];
                    if (task.Todo.Status == TodoStatus.Completed)
                        task.Todo.Status = TodoStatus.NeedsAction;
                    else
                        task.Todo.Status = TodoStatus.Completed;
                    goalController.TaskManager.updateGTask(task);
                }
            }
        }

        private void dataGridView_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                int dx = e.X - mouseDownPos.X;
                int dy = e.Y - mouseDownPos.Y;
                if(Math.Abs(dx) >= SystemInformation.DoubleClickSize.Width || Math.Abs(dy) >= SystemInformation.DoubleClickSize.Height)
                {
                    DataGridView source = (DataGridView)sender;
                    DataGridView.HitTestInfo info = source.HitTest(e.X, e.Y);
                    if (info.RowIndex >= 0)
                    {
                        string uid = (string)source.Rows[info.RowIndex].Cells[3].Value;
                        if (!goalController.TaskManager.GTaskList.ContainsKey(uid))
                            source.DoDragDrop(uid, DragDropEffects.Move);
                    }
                }
            }
        }

        private void dataGridView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void dataGridView_DragDrop(object sender, DragEventArgs e)
        {
            DataGridView destination = (DataGridView)sender;

            if (e.Data.GetDataPresent(typeof(string)))
            {
                string uid = (string)e.Data.GetData(typeof(string));

                if (uid.Length != 0)
                {
                    DateTime newDate;

                    if (destination == todoDataGridView2)
                    {
                        newDate = DateTime.Today.AddDays(1).Date;
                    }
                    else if (destination == todoDataGridView3)
                    {
                        newDate = DateTime.Today.AddDays(2).Date;
                    }
                    else if (destination == todoDataGridView4)
                    {
                        newDate = DateTime.Today.AddDays(3).Date;
                    }
                    else if (destination == todoDataGridView5)
                    {
                        newDate = DateTime.Today.AddDays(4).Date;
                    }
                    else if (destination == todoDataGridView6)
                    {
                        newDate = DateTime.Today.AddDays(5).Date;
                    }
                    else if (destination == todoDataGridView7)
                    {
                        newDate = DateTime.Today.AddDays(6).Date;
                    }
                    else /*if (destination == todoDataGridView1)*/
                    {
                        newDate = DateTime.Today;
                    }

                    ITodo todo = todoController.TodoList[uid];

                    if (todo.Due != null)
                    {
                        if (todo.Start == null)
                            todo.Due = new iCalDateTime(newDate);
                        else
                        {
                            TimeSpan duration = todo.Due.Value - todo.Start.Value;
                            todo.Start = new iCalDateTime(newDate);
                            todo.Due = new iCalDateTime(newDate.Date.Add(duration));
                        }
                    }
                    else
                        todo.Start = new iCalDateTime(newDate);
                    todoController.updateTodo(todo);
                }
            }
        }

        private void goalDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int id = Int32.Parse(goalDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString());
                bool check = (bool)goalDataGridView.Rows[e.RowIndex].Cells[0].Value;
                DialogResult option;

                if (check)
                    option = MessageBox.Show("Are you sure that you complete this goal? Completing this goal will complete all of its associated tasks.", "Complete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else
                    option = MessageBox.Show("Are you sure that you did not complete this goal? By doing so will set the status of all of its associated tasks to be incomplete.", "Complete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (option == DialogResult.Yes)
                {
                    Goal goal = goalController.GoalList[id];
                    goal.Complete = check ? 1.0f : 0.0f;
                    if (goal.GetType() == typeof(LGoal))
                        goalController.updateLGoal((LGoal)goal);
                    else
                        goalController.updateSGoal((SGoal)goal);

                    foreach (GTask task in goalController.TaskManager.GTaskList.Values)
                    {
                        if (task.RelatedGoalID == goal.ID)
                        {
                            if (task.Todo.Status == TodoStatus.Completed && !check)
                            {
                                task.Todo.Status = TodoStatus.NeedsAction;
                                goalController.TaskManager.updateGTask(task);
                            }
                            else if (task.Todo.Status == TodoStatus.NeedsAction && check)
                            {
                                task.Todo.Status = TodoStatus.Completed;
                                goalController.TaskManager.updateGTask(task);
                            }
                        }
                    }
                }
            }
        }
    }
}