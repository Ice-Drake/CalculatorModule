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
        private TreeView treeView;
        private Label nameLabel;
        private TextBox categoryName;
        private Button deleteButton;
        private Button newButton;
        private Button saveButton;
        private TabControl tabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GroupBox groupBox1;
        private TabPage tabPage3;
        private Button button1;
        private GroupBox groupBox2;
        private Button button2;
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
            this.categoryName = new System.Windows.Forms.TextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.newButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
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
            // categoryName
            // 
            this.categoryName.Location = new System.Drawing.Point(47, 263);
            this.categoryName.Name = "categoryName";
            this.categoryName.Size = new System.Drawing.Size(176, 20);
            this.categoryName.TabIndex = 2;
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
            this.groupBox1.Controls.Add(this.categoryName);
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
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.button1);
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
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 125);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "iCal Files";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(87, 301);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save Changes";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 301);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Import";
            this.button2.UseVisualStyleBackColor = true;
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
            this.ResumeLayout(false);

        }

        #endregion

        public SettingDialog()
        {
            InitializeComponent();
            
            foreach (Category category in Setting.CategoryList)
            {
                TreeNode newNode = new TreeNode(category.Name);
                if (category.Subcategories.Count != 0)
                {
                    foreach (Subcategory subcategory in category.Subcategories)
                    {
                        TreeNode newSubNode = new TreeNode(subcategory.Name);
                        newNode.Nodes.Add(newSubNode);
                    }
                }
                treeView.Nodes.Add(newNode);
            }
        }

        private XmlNodeList getXmlNodeList(string filename, string expression)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            XmlNodeList nodes = doc.SelectNodes(expression);
            return nodes;
        }

        void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            categoryName.Text = treeView.SelectedNode.Text;
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
            int index = 0;
            while (Setting.CategoryList[index].Name != treeView.SelectedNode.Text && ++index <= Setting.CategoryList.Count) ;
            Subcategory newSubcategory = new Subcategory(Setting.CategoryList.Count + 1, Setting.CategoryList[index]);
            newSubcategory.Name = categoryName.Text;
            Setting.CategoryList[index].Subcategories.Add(newSubcategory);
            
            TreeNode newNode = new TreeNode(categoryName.Text);
            treeView.SelectedNode.Nodes.Add(newNode);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int i = 0, j = 0;
            while (Setting.CategoryList[i].Name != treeView.SelectedNode.Parent.Text && ++i <= Setting.CategoryList.Count) ;
            while (Setting.CategoryList[i].Subcategories[j].Name != treeView.SelectedNode.Text && ++i <= Setting.CategoryList[i].Subcategories.Count) ;
            Setting.CategoryList[i].Subcategories[j].Name = categoryName.Text;
            treeView.SelectedNode.Text = categoryName.Text;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int i = 0, j = 0;
            while (Setting.CategoryList[i].Name != treeView.SelectedNode.Parent.Text && ++i <= Setting.CategoryList.Count) ;
            while (Setting.CategoryList[i].Subcategories[j].Name != treeView.SelectedNode.Text && ++i <= Setting.CategoryList[i].Subcategories.Count) ;
            Setting.CategoryList[i].Subcategories.RemoveAt(j);
            treeView.SelectedNode.Remove();
        }
    }
}