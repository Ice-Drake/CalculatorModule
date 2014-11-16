using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MultiDesktop
{
    public class VisionForm : Form
    {
        public static VisionManager Controller { private get; set; }

        private Vision m_vision;

        private ToolStrip eventToolStrip;
        private ToolStripButton saveButton;
        private ToolStripButton deleteButton;
        private Panel topPanel;
        private Label summaryLabel;
        private TextBox summaryField;
        private GroupBox groupBox1;
        private RichTextBox visionDescBox;

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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.visionDescBox = new System.Windows.Forms.RichTextBox();
            this.summaryLabel = new System.Windows.Forms.Label();
            this.summaryField = new System.Windows.Forms.TextBox();
            this.eventToolStrip.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.topPanel.Controls.Add(this.groupBox1);
            this.topPanel.Controls.Add(this.summaryLabel);
            this.topPanel.Controls.Add(this.summaryField);
            this.topPanel.Location = new System.Drawing.Point(1, 28);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(239, 152);
            this.topPanel.TabIndex = 31;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.visionDescBox);
            this.groupBox1.Location = new System.Drawing.Point(11, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 120);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Description";
            // 
            // visionDescBox
            // 
            this.visionDescBox.Location = new System.Drawing.Point(6, 19);
            this.visionDescBox.Name = "visionDescBox";
            this.visionDescBox.Size = new System.Drawing.Size(204, 95);
            this.visionDescBox.TabIndex = 0;
            this.visionDescBox.Text = "";
            // 
            // summaryLabel
            // 
            this.summaryLabel.Location = new System.Drawing.Point(12, 6);
            this.summaryLabel.Name = "summaryLabel";
            this.summaryLabel.Size = new System.Drawing.Size(62, 13);
            this.summaryLabel.TabIndex = 2;
            this.summaryLabel.Text = "Summary:";
            // 
            // summaryField
            // 
            this.summaryField.Location = new System.Drawing.Point(78, 3);
            this.summaryField.Name = "summaryField";
            this.summaryField.Size = new System.Drawing.Size(149, 20);
            this.summaryField.TabIndex = 3;
            // 
            // VisionForm
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(240, 180);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.eventToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "VisionForm";
            this.Text = "Vision";
            this.eventToolStrip.ResumeLayout(false);
            this.eventToolStrip.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public VisionForm()
        {
            InitializeComponent();
            deleteButton.Enabled = false;
        }

        public VisionForm(Vision existingVision)
        {
            InitializeComponent();
            m_vision = existingVision;

            summaryField.Text = m_vision.Summary;
            visionDescBox.Text = m_vision.Desc;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (m_vision == null)
            {
                Controller.createVision(summaryField.Text, visionDescBox.Text);
                Close();
            }
            else
            {
                m_vision.Summary = summaryField.Text;
                m_vision.Desc = visionDescBox.Text;
                Controller.updateVision(m_vision);
                Close();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Controller.removeVision(m_vision.ID);
            Close();
        }
    }
}
