using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace MultiDesktop
{
    public class SettingDialog : Form
    {
        private SettingManager controller;

        private TreeView treeView;
        private Label nameLabel;
        private TextBox categoryNameField;
        private Button deleteButton;
        private Button newButton;
        private Button saveButton;
        private TabControl tabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GroupBox groupBox1;
        private TabPage tabPage3;
        private GroupBox groupBox2;
        private DataGridView calendarGridView;
        private DataGridViewTextBoxColumn NameColumn1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewCheckBoxColumn Column2;
        private DataGridViewTextBoxColumn ID;
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
            this.treeView = new System.Windows.Forms.TreeView();
            this.nameLabel = new System.Windows.Forms.Label();
            this.categoryNameField = new System.Windows.Forms.TextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.newButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.calendarGridView = new System.Windows.Forms.DataGridView();
            this.NameColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calendarGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.HideSelection = false;
            this.treeView.Location = new System.Drawing.Point(6, 19);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(217, 238);
            this.treeView.TabIndex = 0;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(6, 266);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Name";
            // 
            // categoryNameField
            // 
            this.categoryNameField.Location = new System.Drawing.Point(47, 263);
            this.categoryNameField.Name = "categoryNameField";
            this.categoryNameField.Size = new System.Drawing.Size(176, 20);
            this.categoryNameField.TabIndex = 2;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(148, 289);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(6, 289);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(61, 23);
            this.newButton.TabIndex = 4;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(73, 289);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(69, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(254, 356);
            this.tabControl.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(246, 330);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(246, 330);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Categories";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeView);
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Controls.Add(this.saveButton);
            this.groupBox1.Controls.Add(this.categoryNameField);
            this.groupBox1.Controls.Add(this.newButton);
            this.groupBox1.Controls.Add(this.nameLabel);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 318);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Categories";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(246, 330);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Database";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.calendarGridView);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 318);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "iCal Files";
            // 
            // calendarGridView
            // 
            this.calendarGridView.AllowUserToAddRows = false;
            this.calendarGridView.AllowUserToDeleteRows = false;
            this.calendarGridView.AllowUserToResizeColumns = false;
            this.calendarGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.calendarGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.calendarGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.calendarGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn1,
            this.Column1,
            this.Column2,
            this.ID});
            this.calendarGridView.Location = new System.Drawing.Point(6, 19);
            this.calendarGridView.MultiSelect = false;
            this.calendarGridView.Name = "calendarGridView";
            this.calendarGridView.RowHeadersVisible = false;
            this.calendarGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.calendarGridView.Size = new System.Drawing.Size(222, 293);
            this.calendarGridView.TabIndex = 0;
            this.calendarGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.calendarGridView_CellContentClick);
            // 
            // NameColumn1
            // 
            this.NameColumn1.DataPropertyName = "Name";
            this.NameColumn1.HeaderText = "Name";
            this.NameColumn1.Name = "NameColumn1";
            this.NameColumn1.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Filename";
            this.Column1.HeaderText = "Filename";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 70;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Included";
            this.Column2.FalseValue = "false";
            this.Column2.HeaderText = "Included";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.TrueValue = "true";
            this.Column2.Width = 50;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // SettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 380);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting Dialog";
            this.tabControl.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.calendarGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public SettingDialog(SettingManager settingManager)
        {
            InitializeComponent();

            controller = settingManager;
            
            foreach (TreeNode newNode in settingManager.CategoryManager.CategoryNodeList)
            {
                treeView.Nodes.Add(newNode);
            }

            calendarGridView.DataSource = controller.CalendarManager.CalendarTable;
        }

        private XmlNodeList getXmlNodeList(string filename, string expression)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            XmlNodeList nodes = doc.SelectNodes(expression);
            return nodes;
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            categoryNameField.Text = treeView.SelectedNode.Text;
            if (treeView.SelectedNode.Level == 0)
            {
                newButton.Enabled = true;
                saveButton.Enabled = false;
                deleteButton.Enabled = false;
            }
            else
            {
                newButton.Enabled = false;
                saveButton.Enabled = true;
                deleteButton.Enabled = true;
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {   
            List<string> categoryList = controller.CategoryManager.getCategoryList();
            
            if (categoryNameField.Text.Length == 0)
            {
                MessageBox.Show("Please input a name for the new category.");
            }
            else if(!categoryList.Contains(categoryNameField.Text))
            {
                Category category = controller.CategoryManager.getCategory(treeView.SelectedNode.Text);
                controller.CategoryManager.addSubcategory(new Subcategory(categoryNameField.Text, category));
                
                TreeNode newNode = new TreeNode(categoryNameField.Text);
                treeView.SelectedNode.Nodes.Add(newNode);
            }
            else
            {
                MessageBox.Show("The new category cannot have the same name as any of the existing ones.");
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (categoryNameField.Text.Length == 0)
            {
                MessageBox.Show("Please input a new name for the selected category.");
            }
            else if (controller.CategoryManager.renameSubcategory(categoryNameField.Text, treeView.SelectedNode.Text))
            {
                int nodeIndex = treeView.Nodes.IndexOf(treeView.SelectedNode);
                treeView.Nodes.RemoveAt(nodeIndex);
                TreeNode newNode = new TreeNode(categoryNameField.Text);
                treeView.Nodes.Insert(nodeIndex, newNode);
            }
            else
            {
                MessageBox.Show("The new name cannot be the same as any of the existing ones.");
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            controller.CategoryManager.deleteSubcategory(treeView.SelectedNode.Text);
            treeView.SelectedNode.Remove();
        }

        private void calendarGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Int32.Parse(calendarGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
            CalendarForm newForm = new CalendarForm(controller.CalendarManager.CalendarList[id]);
            newForm.Show();
        }
    }
}