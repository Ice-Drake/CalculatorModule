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
    public class GoalPanel : MainPanel
    {
        private GoalPlanner controller;
        private GanttChartPanel ganttPanel;
        private DataView lGoalView;
        private DataView sGoalView;
        private DataView taskView;

        #region Component Designer variables

        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGridView visionGridView;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private DataGridView sGoalGridView;
        private DataGridView lGoalGridView;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem visionToolStripMenuItem;
        private ToolStripMenuItem longTermGoalToolStripMenuItem;
        private ToolStripMenuItem sMARTERGoalToolStripMenuItem;
        private ToolStripMenuItem taskToolStripMenuItem;
        private ToolStripButton ganttChartButton;
        private TabPage tabPage4;
        private Label label1;
        private ComboBox visionComboBox;
        private RadioButton selectVisionRadioButton;
        private RadioButton noneVisionRadioButton;
        private DataGridView taskGridView;
        private Label label2;
        private ComboBox lGoalComboBox;
        private RadioButton selectLGoalRadioButton;
        private RadioButton noneLGoalRadioButton;
        private Label label3;
        private ComboBox sGoalComboBox;
        private RadioButton selectSGoalRadioButton;
        private RadioButton noneSGoalRadioButton;
        private DataGridViewTextBoxColumn summaryColumn;
        private DataGridViewTextBoxColumn descColumn;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewCheckBoxColumn dataGridViewImageColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewCheckBoxColumn dataGridViewImageColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewCheckBoxColumn dataGridViewImageColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.visionGridView = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.visionComboBox = new System.Windows.Forms.ComboBox();
            this.selectVisionRadioButton = new System.Windows.Forms.RadioButton();
            this.noneVisionRadioButton = new System.Windows.Forms.RadioButton();
            this.lGoalGridView = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.lGoalComboBox = new System.Windows.Forms.ComboBox();
            this.selectLGoalRadioButton = new System.Windows.Forms.RadioButton();
            this.noneLGoalRadioButton = new System.Windows.Forms.RadioButton();
            this.sGoalGridView = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.sGoalComboBox = new System.Windows.Forms.ComboBox();
            this.selectSGoalRadioButton = new System.Windows.Forms.RadioButton();
            this.noneSGoalRadioButton = new System.Windows.Forms.RadioButton();
            this.taskGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.visionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.longTermGoalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sMARTERGoalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ganttChartButton = new System.Windows.Forms.ToolStripButton();
            this.summaryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visionGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lGoalGridView)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sGoalGridView)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(378, 221);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.visionGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(370, 195);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Vision";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // visionGridView
            // 
            this.visionGridView.AllowUserToAddRows = false;
            this.visionGridView.AllowUserToDeleteRows = false;
            this.visionGridView.AllowUserToOrderColumns = true;
            this.visionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.visionGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.summaryColumn,
            this.descColumn,
            this.Column1});
            this.visionGridView.Location = new System.Drawing.Point(6, 6);
            this.visionGridView.Name = "visionGridView";
            this.visionGridView.ReadOnly = true;
            this.visionGridView.RowHeadersVisible = false;
            this.visionGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.visionGridView.Size = new System.Drawing.Size(358, 183);
            this.visionGridView.TabIndex = 1;
            this.visionGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.visionGridView_CellContentClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.visionComboBox);
            this.tabPage2.Controls.Add(this.selectVisionRadioButton);
            this.tabPage2.Controls.Add(this.noneVisionRadioButton);
            this.tabPage2.Controls.Add(this.lGoalGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(370, 195);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Long-Term Goal";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Related Vision:";
            // 
            // visionComboBox
            // 
            this.visionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.visionComboBox.Enabled = false;
            this.visionComboBox.FormattingEnabled = true;
            this.visionComboBox.Location = new System.Drawing.Point(167, 6);
            this.visionComboBox.Name = "visionComboBox";
            this.visionComboBox.Size = new System.Drawing.Size(121, 21);
            this.visionComboBox.TabIndex = 5;
            this.visionComboBox.SelectedIndexChanged += new System.EventHandler(this.visionComboBox_SelectedIndexChanged);
            // 
            // selectVisionRadioButton
            // 
            this.selectVisionRadioButton.AutoSize = true;
            this.selectVisionRadioButton.Location = new System.Drawing.Point(147, 9);
            this.selectVisionRadioButton.Name = "selectVisionRadioButton";
            this.selectVisionRadioButton.Size = new System.Drawing.Size(14, 13);
            this.selectVisionRadioButton.TabIndex = 4;
            this.selectVisionRadioButton.TabStop = true;
            this.selectVisionRadioButton.UseVisualStyleBackColor = true;
            this.selectVisionRadioButton.CheckedChanged += new System.EventHandler(this.visionRadioButton_CheckedChanged);
            // 
            // noneVisionRadioButton
            // 
            this.noneVisionRadioButton.AutoSize = true;
            this.noneVisionRadioButton.Checked = true;
            this.noneVisionRadioButton.Location = new System.Drawing.Point(90, 7);
            this.noneVisionRadioButton.Name = "noneVisionRadioButton";
            this.noneVisionRadioButton.Size = new System.Drawing.Size(51, 17);
            this.noneVisionRadioButton.TabIndex = 3;
            this.noneVisionRadioButton.TabStop = true;
            this.noneVisionRadioButton.Text = "None";
            this.noneVisionRadioButton.UseVisualStyleBackColor = true;
            this.noneVisionRadioButton.CheckedChanged += new System.EventHandler(this.visionRadioButton_CheckedChanged);
            // 
            // lGoalGridView
            // 
            this.lGoalGridView.AllowUserToAddRows = false;
            this.lGoalGridView.AllowUserToDeleteRows = false;
            this.lGoalGridView.AllowUserToOrderColumns = true;
            this.lGoalGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lGoalGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn9});
            this.lGoalGridView.Location = new System.Drawing.Point(6, 33);
            this.lGoalGridView.Name = "lGoalGridView";
            this.lGoalGridView.ReadOnly = true;
            this.lGoalGridView.RowHeadersVisible = false;
            this.lGoalGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lGoalGridView.Size = new System.Drawing.Size(358, 156);
            this.lGoalGridView.TabIndex = 2;
            this.lGoalGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.lGoalGridView_CellContentClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.lGoalComboBox);
            this.tabPage3.Controls.Add(this.selectLGoalRadioButton);
            this.tabPage3.Controls.Add(this.noneLGoalRadioButton);
            this.tabPage3.Controls.Add(this.sGoalGridView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(370, 195);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "SMARTER Goal";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Related Long-Term Goal:";
            // 
            // lGoalComboBox
            // 
            this.lGoalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lGoalComboBox.Enabled = false;
            this.lGoalComboBox.FormattingEnabled = true;
            this.lGoalComboBox.Location = new System.Drawing.Point(215, 6);
            this.lGoalComboBox.Name = "lGoalComboBox";
            this.lGoalComboBox.Size = new System.Drawing.Size(121, 21);
            this.lGoalComboBox.TabIndex = 9;
            this.lGoalComboBox.SelectedIndexChanged += new System.EventHandler(this.lGoalComboBox_SelectedIndexChanged);
            // 
            // selectLGoalRadioButton
            // 
            this.selectLGoalRadioButton.AutoSize = true;
            this.selectLGoalRadioButton.Location = new System.Drawing.Point(195, 9);
            this.selectLGoalRadioButton.Name = "selectLGoalRadioButton";
            this.selectLGoalRadioButton.Size = new System.Drawing.Size(14, 13);
            this.selectLGoalRadioButton.TabIndex = 8;
            this.selectLGoalRadioButton.TabStop = true;
            this.selectLGoalRadioButton.UseVisualStyleBackColor = true;
            this.selectLGoalRadioButton.CheckedChanged += new System.EventHandler(this.lGoalRadioButton_CheckedChanged);
            // 
            // noneLGoalRadioButton
            // 
            this.noneLGoalRadioButton.AutoSize = true;
            this.noneLGoalRadioButton.Checked = true;
            this.noneLGoalRadioButton.Location = new System.Drawing.Point(138, 7);
            this.noneLGoalRadioButton.Name = "noneLGoalRadioButton";
            this.noneLGoalRadioButton.Size = new System.Drawing.Size(51, 17);
            this.noneLGoalRadioButton.TabIndex = 7;
            this.noneLGoalRadioButton.TabStop = true;
            this.noneLGoalRadioButton.Text = "None";
            this.noneLGoalRadioButton.UseVisualStyleBackColor = true;
            this.noneLGoalRadioButton.CheckedChanged += new System.EventHandler(this.lGoalRadioButton_CheckedChanged);
            // 
            // sGoalGridView
            // 
            this.sGoalGridView.AllowUserToAddRows = false;
            this.sGoalGridView.AllowUserToDeleteRows = false;
            this.sGoalGridView.AllowUserToOrderColumns = true;
            this.sGoalGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sGoalGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn2,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn8,
            this.Column3});
            this.sGoalGridView.Location = new System.Drawing.Point(6, 33);
            this.sGoalGridView.Name = "sGoalGridView";
            this.sGoalGridView.ReadOnly = true;
            this.sGoalGridView.RowHeadersVisible = false;
            this.sGoalGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sGoalGridView.Size = new System.Drawing.Size(358, 156);
            this.sGoalGridView.TabIndex = 4;
            this.sGoalGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sGoalGridView_CellContentClick);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.sGoalComboBox);
            this.tabPage4.Controls.Add(this.selectSGoalRadioButton);
            this.tabPage4.Controls.Add(this.noneSGoalRadioButton);
            this.tabPage4.Controls.Add(this.taskGridView);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(370, 195);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Task";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Related SMARTER Goal:";
            // 
            // sGoalComboBox
            // 
            this.sGoalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sGoalComboBox.Enabled = false;
            this.sGoalComboBox.FormattingEnabled = true;
            this.sGoalComboBox.Location = new System.Drawing.Point(218, 6);
            this.sGoalComboBox.Name = "sGoalComboBox";
            this.sGoalComboBox.Size = new System.Drawing.Size(121, 21);
            this.sGoalComboBox.TabIndex = 13;
            this.sGoalComboBox.SelectedIndexChanged += new System.EventHandler(this.sGoalComboBox_SelectedIndexChanged);
            // 
            // selectSGoalRadioButton
            // 
            this.selectSGoalRadioButton.AutoSize = true;
            this.selectSGoalRadioButton.Location = new System.Drawing.Point(198, 9);
            this.selectSGoalRadioButton.Name = "selectSGoalRadioButton";
            this.selectSGoalRadioButton.Size = new System.Drawing.Size(14, 13);
            this.selectSGoalRadioButton.TabIndex = 12;
            this.selectSGoalRadioButton.TabStop = true;
            this.selectSGoalRadioButton.UseVisualStyleBackColor = true;
            this.selectSGoalRadioButton.CheckedChanged += new System.EventHandler(this.sGoalRadioButton_CheckedChanged);
            // 
            // noneSGoalRadioButton
            // 
            this.noneSGoalRadioButton.AutoSize = true;
            this.noneSGoalRadioButton.Checked = true;
            this.noneSGoalRadioButton.Location = new System.Drawing.Point(141, 7);
            this.noneSGoalRadioButton.Name = "noneSGoalRadioButton";
            this.noneSGoalRadioButton.Size = new System.Drawing.Size(51, 17);
            this.noneSGoalRadioButton.TabIndex = 11;
            this.noneSGoalRadioButton.TabStop = true;
            this.noneSGoalRadioButton.Text = "None";
            this.noneSGoalRadioButton.UseVisualStyleBackColor = true;
            this.noneSGoalRadioButton.CheckedChanged += new System.EventHandler(this.sGoalRadioButton_CheckedChanged);
            // 
            // taskGridView
            // 
            this.taskGridView.AllowUserToAddRows = false;
            this.taskGridView.AllowUserToDeleteRows = false;
            this.taskGridView.AllowUserToOrderColumns = true;
            this.taskGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.taskGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn3,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn4});
            this.taskGridView.Location = new System.Drawing.Point(6, 33);
            this.taskGridView.Name = "taskGridView";
            this.taskGridView.ReadOnly = true;
            this.taskGridView.RowHeadersVisible = false;
            this.taskGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.taskGridView.Size = new System.Drawing.Size(358, 156);
            this.taskGridView.TabIndex = 2;
            this.taskGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.taskGridView_CellContentClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.ganttChartButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(402, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visionToolStripMenuItem,
            this.longTermGoalToolStripMenuItem,
            this.sMARTERGoalToolStripMenuItem,
            this.taskToolStripMenuItem});
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(44, 22);
            this.toolStripDropDownButton1.Text = "New";
            // 
            // visionToolStripMenuItem
            // 
            this.visionToolStripMenuItem.Name = "visionToolStripMenuItem";
            this.visionToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.visionToolStripMenuItem.Text = "Vision";
            this.visionToolStripMenuItem.Click += new System.EventHandler(this.visionToolStripMenuItem_Click);
            // 
            // longTermGoalToolStripMenuItem
            // 
            this.longTermGoalToolStripMenuItem.Name = "longTermGoalToolStripMenuItem";
            this.longTermGoalToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.longTermGoalToolStripMenuItem.Text = "Long-Term Goal";
            this.longTermGoalToolStripMenuItem.Click += new System.EventHandler(this.longTermGoalToolStripMenuItem_Click);
            // 
            // sMARTERGoalToolStripMenuItem
            // 
            this.sMARTERGoalToolStripMenuItem.Name = "sMARTERGoalToolStripMenuItem";
            this.sMARTERGoalToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.sMARTERGoalToolStripMenuItem.Text = "SMARTER Goal";
            this.sMARTERGoalToolStripMenuItem.Click += new System.EventHandler(this.sMARTERGoalToolStripMenuItem_Click);
            // 
            // taskToolStripMenuItem
            // 
            this.taskToolStripMenuItem.Name = "taskToolStripMenuItem";
            this.taskToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.taskToolStripMenuItem.Text = "Task";
            this.taskToolStripMenuItem.Click += new System.EventHandler(this.taskToolStripMenuItem_Click);
            // 
            // ganttChartButton
            // 
            this.ganttChartButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ganttChartButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ganttChartButton.Name = "ganttChartButton";
            this.ganttChartButton.Size = new System.Drawing.Size(72, 22);
            this.ganttChartButton.Text = "Gantt Chart";
            this.ganttChartButton.Click += new System.EventHandler(this.ganttChartButton_Click);
            // 
            // summaryColumn
            // 
            this.summaryColumn.DataPropertyName = "Summary";
            this.summaryColumn.HeaderText = "Summary";
            this.summaryColumn.Name = "summaryColumn";
            this.summaryColumn.ReadOnly = true;
            // 
            // descColumn
            // 
            this.descColumn.DataPropertyName = "Description";
            this.descColumn.HeaderText = "Description";
            this.descColumn.Name = "descColumn";
            this.descColumn.ReadOnly = true;
            this.descColumn.Width = 255;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ID";
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "Complete";
            this.dataGridViewImageColumn1.HeaderText = "Complete";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Summary";
            this.dataGridViewTextBoxColumn1.HeaderText = "Summary";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Category";
            this.dataGridViewTextBoxColumn2.HeaderText = "Category";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 95;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Start";
            this.dataGridViewTextBoxColumn3.HeaderText = "Start";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn9.HeaderText = "ID";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.DataPropertyName = "Complete";
            this.dataGridViewImageColumn2.FalseValue = "false";
            this.dataGridViewImageColumn2.HeaderText = "Complete";
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn2.TrueValue = "true";
            this.dataGridViewImageColumn2.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Summary";
            this.dataGridViewTextBoxColumn5.HeaderText = "Summary";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Category";
            this.dataGridViewTextBoxColumn6.HeaderText = "Category";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 95;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Due";
            this.dataGridViewTextBoxColumn8.HeaderText = "Due";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ID";
            this.Column3.HeaderText = "ID";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.DataPropertyName = "Complete";
            this.dataGridViewImageColumn3.HeaderText = "Complete";
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.ReadOnly = true;
            this.dataGridViewImageColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Summary";
            this.dataGridViewTextBoxColumn10.HeaderText = "Summary";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 95;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Start";
            this.dataGridViewTextBoxColumn12.HeaderText = "Start";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Due";
            this.dataGridViewTextBoxColumn13.HeaderText = "Due";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "UID";
            this.dataGridViewTextBoxColumn4.HeaderText = "UID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // GoalPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(402, 261);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GoalPanel";
            this.ShowInTaskbar = false;
            this.Text = "Goal Panel";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.visionGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lGoalGridView)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sGoalGridView)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public GoalPanel(GoalPlanner goalPlanner) : base("Goal Planner")
        {
            InitializeComponent();
            controller = goalPlanner;

            ganttPanel = new GanttChartPanel(goalPlanner);

            lGoalView = new DataView();
            lGoalView.Table = controller.LGoalTable;

            sGoalView = new DataView();
            sGoalView.Table = controller.SGoalTable;

            taskView = new DataView();
            taskView.Table = controller.TaskManager.TaskTable;

            visionGridView.AutoGenerateColumns = false;
            visionGridView.DataSource = controller.VisionManager.VisionTable;

            lGoalGridView.AutoGenerateColumns = false;
            lGoalGridView.DataSource = lGoalView;

            sGoalGridView.AutoGenerateColumns = false;
            sGoalGridView.DataSource = sGoalView;

            taskGridView.AutoGenerateColumns = false;
            taskGridView.DataSource = taskView;

            visionComboBox.DataSource = controller.VisionManager.VisionTable;
            visionComboBox.DisplayMember = "Summary";
            visionComboBox.ValueMember = "ID";

            lGoalComboBox.DataSource = controller.LGoalTable;
            lGoalComboBox.DisplayMember = "Summary";
            lGoalComboBox.ValueMember = "ID";

            sGoalComboBox.DataSource = controller.SGoalTable;
            sGoalComboBox.DisplayMember = "Summary";
            sGoalComboBox.ValueMember = "ID";
        }

        private void visionGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Int32.Parse(visionGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
            VisionForm newForm = new VisionForm(controller.VisionManager.VisionList[id]);
            newForm.Show();
        }

        private void lGoalGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Int32.Parse(lGoalGridView.Rows[e.RowIndex].Cells[4].Value.ToString());
            LGoalForm newForm = new LGoalForm((LGoal)controller.GoalList[id]);
            newForm.Show();
        }

        private void sGoalGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Int32.Parse(sGoalGridView.Rows[e.RowIndex].Cells[4].Value.ToString());
            SGoalForm newForm = new SGoalForm((SGoal)controller.GoalList[id]);
            newForm.Show();
        }

        private void taskGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string uid = taskGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
            TaskForm newForm;

            if (controller.TaskManager.GTaskList.ContainsKey(uid))
            {
                newForm = new TaskForm(controller.TaskManager.GTaskList[uid]);
            }
            else
            {
                string summary = taskGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                DateTime start = DateTime.Parse(taskGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                DateTime due = DateTime.Parse(taskGridView.Rows[e.RowIndex].Cells[3].Value.ToString());
                bool complete = (bool)taskGridView.Rows[e.RowIndex].Cells[0].Value;
                int goalID = Int32.Parse(sGoalComboBox.SelectedValue.ToString());
                newForm = new TaskForm(summary, start, due, complete, goalID);
            }
            newForm.Show();
        }

        private void visionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisionForm newForm = new VisionForm();
            newForm.Show();
        }

        private void longTermGoalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LGoalForm newForm = new LGoalForm();
            newForm.Show();
        }

        private void sMARTERGoalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SGoalForm newForm = new SGoalForm();
            newForm.Show();
        }

        private void taskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskForm newForm = new TaskForm();
            newForm.Show();
        }

        private void ganttChartButton_Click(object sender, EventArgs e)
        {
            ganttPanel.Show();
        }

        private void visionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (selectVisionRadioButton.Checked && visionComboBox.SelectedValue != null)
            {
                lGoalView.RowFilter = String.Format(System.Globalization.DateTimeFormatInfo.InvariantInfo, "VisionID = {0}", visionComboBox.SelectedValue);
                visionComboBox.Enabled = true;
            }
            else
            {
                lGoalView.RowFilter = "VisionID = 0";
                if (noneVisionRadioButton.Checked)
                    visionComboBox.Enabled = false;                
            }
        }

        private void visionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            lGoalView.RowFilter = String.Format(System.Globalization.DateTimeFormatInfo.InvariantInfo, "VisionID = {0}", visionComboBox.SelectedValue);
        }

        private void lGoalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (selectLGoalRadioButton.Checked && lGoalComboBox.SelectedValue != null)
            {
                sGoalView.RowFilter = String.Format(System.Globalization.DateTimeFormatInfo.InvariantInfo, "LGoalID = {0}", lGoalComboBox.SelectedValue);
                lGoalComboBox.Enabled = true;
            }
            else
            {
                sGoalView.RowFilter = "LGoalID = 0";
                if (noneLGoalRadioButton.Checked)
                    lGoalComboBox.Enabled = false;
            }
        }

        private void lGoalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            sGoalView.RowFilter = String.Format(System.Globalization.DateTimeFormatInfo.InvariantInfo, "LGoalID = {0}", lGoalComboBox.SelectedValue);
        }

        private void sGoalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (selectSGoalRadioButton.Checked && sGoalComboBox.SelectedValue != null)
            {
                taskView.RowFilter = String.Format(System.Globalization.DateTimeFormatInfo.InvariantInfo, "GoalID = {0}", sGoalComboBox.SelectedValue);
                sGoalComboBox.Enabled = true;
            }
            else
            {
                taskView.RowFilter = "GoalID = 0";
                if (noneSGoalRadioButton.Checked)
                    sGoalComboBox.Enabled = false;
            }
        }

        private void sGoalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sGoalComboBox.SelectedValue != null)
                taskView.RowFilter = String.Format(System.Globalization.DateTimeFormatInfo.InvariantInfo, "GoalID = {0}", sGoalComboBox.SelectedValue);
            else
                taskView.RowFilter = "GoalID = 0";
        }
    }
}
