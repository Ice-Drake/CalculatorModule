using System;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MultiDesktop
{
    public class SplashScreen : Form
    {
        private Panel titlePanel;
        private System.Windows.Forms.Timer timer;
        private Panel progressPanel;
        private Label statusLabel;

        private string m_sStatus;

        private double m_dblCompletionFraction = 0;
        private Rectangle m_rProgress;
        private double m_dblOpacityIncrement = .05;
        private double m_dblOpacityDecrement = .1;
        private const int TIMER_INTERVAL = 50;
        static SplashScreen ms_frmSplash = null;

        // A static entry point to launch SplashScreen.
        static Thread ms_oThread = null;

        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);

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
            this.titlePanel = new System.Windows.Forms.Panel();
            this.progressPanel = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.progressPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.Color.Transparent;
            this.titlePanel.BackgroundImage = global::MultiDesktop.Properties.Resources.title;
            this.titlePanel.Location = new System.Drawing.Point(40, 74);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(359, 67);
            this.titlePanel.TabIndex = 0;
            // 
            // progressPanel
            // 
            this.progressPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.progressPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.progressPanel.Controls.Add(this.statusLabel);
            this.progressPanel.Location = new System.Drawing.Point(75, 147);
            this.progressPanel.Name = "progressPanel";
            this.progressPanel.Size = new System.Drawing.Size(290, 18);
            this.progressPanel.TabIndex = 1;
            this.progressPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.progressPanel_Paint);
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.Color.Transparent;
            this.statusLabel.Location = new System.Drawing.Point(3, 1);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(280, 13);
            this.statusLabel.TabIndex = 2;
            this.statusLabel.Text = "now loading: ...";
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MultiDesktop.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(440, 240);
            this.Controls.Add(this.progressPanel);
            this.Controls.Add(this.titlePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.progressPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public SplashScreen()
        {
            this.components = new System.ComponentModel.Container();
            InitializeComponent();
            this.Opacity = .0;
            
            timer = new System.Windows.Forms.Timer(this.components);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = TIMER_INTERVAL;
            timer.Start();
        }

        static private void ShowForm()
        {
            ms_frmSplash = new SplashScreen();
            Application.Run(ms_frmSplash);
        }

        // A static method to close the SplashScreen
        static public void CloseForm()
        {
            if (ms_frmSplash != null)
            {
                // Make it start going away.

                ms_frmSplash.m_dblOpacityIncrement = -ms_frmSplash.m_dblOpacityDecrement;
            }
            ms_oThread = null;  // we do not need these any more.

            ms_frmSplash = null;
        }


        static public void ShowSplashScreen()
        {
            // Make sure it is only launched once.

            if (ms_frmSplash != null)
                return;
            ms_oThread = new Thread(new ThreadStart(SplashScreen.ShowForm));
            ms_oThread.IsBackground = true;
            ms_oThread.SetApartmentState(ApartmentState.STA);
            ms_oThread.Start();
        }

        
        private void timer_Tick(object sender, System.EventArgs e)
        {
            if (m_dblOpacityIncrement > 0)
            {
                if (this.Opacity < 1)
                    this.Opacity += m_dblOpacityIncrement;
            }
            else
            {
                if (this.Opacity > 0)
                    this.Opacity += m_dblOpacityIncrement;
                else
                    this.Close();
            }

            int width = (int)Math.Floor(progressPanel.ClientRectangle.Width * m_dblCompletionFraction);
            int height = progressPanel.ClientRectangle.Height;
            int x = progressPanel.ClientRectangle.X;
            int y = progressPanel.ClientRectangle.Y;
            if (width > 0 && height > 0)
            {
                m_rProgress = new Rectangle(x, y, width, height);
                progressPanel.Invalidate(m_rProgress);
            }
        }

        // Static method for updating the progress percentage.
        static public double Progress
        {
            get
            {
                if (ms_frmSplash != null)
                    return ms_frmSplash.m_dblCompletionFraction;
                return 1.00;
            }
            set
            {
                if (ms_frmSplash != null)
                    ms_frmSplash.m_dblCompletionFraction = value;
            }
        }

        private void progressPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (e.ClipRectangle.Width > 0 && m_rProgress.Height > 0 && m_rProgress.Width > 0)
            {
                LinearGradientBrush brBackground =
                  new LinearGradientBrush(m_rProgress,
                                          Color.FromArgb(127, 180, 255),
                                          Color.FromArgb(99, 141, 200),
                                          LinearGradientMode.Horizontal);
                e.Graphics.FillRectangle(brBackground, m_rProgress);
            }
        }

        // A static method to set the status.
        static public void SetStatus(string newStatus)
        {
            if (ms_frmSplash != null)
            {
                ms_frmSplash.m_sStatus = newStatus;
                ms_frmSplash.SetText(ms_frmSplash.m_sStatus);
            }
        }

        // A static method to add additional status details.
        static public void AddStatusDetail(string newDetail)
        {
            if (ms_frmSplash != null)
                ms_frmSplash.SetText(ms_frmSplash.m_sStatus + ": " + newDetail);
        }

        // If the calling thread is different from the thread that
        // created the TextBox control, this method creates a
        // SetTextCallback and calls itself asynchronously using the
        // Invoke method.
        //
        // If the calling thread is the same as the thread that created
        // the Form, the Text property of its Label control is set directly. 
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (ms_frmSplash.statusLabel.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                ms_frmSplash.statusLabel.Text = text;
            }
        }
    }
}