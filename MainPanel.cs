using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultiDesktop
{
    public class MainPanel : Form
    {
        public ToolStripMenuItem MenuItem { get; private set; }

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
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.components = new System.ComponentModel.Container();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "MainPanel";
        }

        #endregion

        public MainPanel(string name)
        {
            MenuItem = new ToolStripMenuItem(name);
            MenuItem.CheckOnClick = true;
            MenuItem.Click += new EventHandler(MenuItem_Click);
            this.FormClosing += new FormClosingEventHandler(MainPanel_FormClosing);
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            if (MenuItem.Checked)
            {
                Show();
            }
            else
            {
                Hide();
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
