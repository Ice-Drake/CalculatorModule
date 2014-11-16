using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DDay.iCal;
using DDay.iCal.Serialization.iCalendar;
using Library;
using PluginSDK;

namespace MultiDesktop
{
    public class MultiDesktopBar : Form
    {
        #region Component Designer variables

        private ToolStripButton computerButton;
        private ToolStripButton documentButton;
        private ToolStripButton pictureButton;
        private ToolStripButton musicButton;
        private ToolStripSeparator computerToolSeparator;
        private ToolStripButton newEventButton;
        private ToolStripButton newTodoButton;
        private ToolStripSeparator userToolSeparator;
        private ToolStripButton settingButton;
        private ToolStripButton aboutButton;
        private ToolStripButton exitButton;
        private ToolStripDropDownButton configDropDownButton;
        private ToolStrip sideToolbar;
        private ToolStripDropDownButton panelDropDownButton;
        private ToolStripButton desktopButton;
        private ToolStripMenuItem calculatorMenu;
        private ToolStripMenuItem musicPlayerMenu;
        private ToolStripMenuItem pictureGalleryMenu;
        private ToolStripMenuItem rssFeedMenu;
        private ToolStripSeparator menuToolSeparator;
        private ToolStripDropDownButton pluginDropDownButton;
        private ToolStripMenuItem weatherMenu;
        private ToolStripButton newJournalButton;
        private ToolStripButton newCalendarButton;

        #endregion

        private SettingManager settingManager;
        private SettingDialog settingDialog;
        private List<IProjDBManager> projectPlugins;
        private List<IPanelPlugin> panelPlugins;

        //Member variables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiDesktopBar));
            this.computerToolSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.userToolSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.configDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.sideToolbar = new System.Windows.Forms.ToolStrip();
            this.desktopButton = new System.Windows.Forms.ToolStripButton();
            this.computerButton = new System.Windows.Forms.ToolStripButton();
            this.documentButton = new System.Windows.Forms.ToolStripButton();
            this.pictureButton = new System.Windows.Forms.ToolStripButton();
            this.musicButton = new System.Windows.Forms.ToolStripButton();
            this.newEventButton = new System.Windows.Forms.ToolStripButton();
            this.newTodoButton = new System.Windows.Forms.ToolStripButton();
            this.newJournalButton = new System.Windows.Forms.ToolStripButton();
            this.newCalendarButton = new System.Windows.Forms.ToolStripButton();
            this.panelDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.calculatorMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.musicPlayerMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureGalleryMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.rssFeedMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.weatherMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuToolSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.settingButton = new System.Windows.Forms.ToolStripButton();
            this.aboutButton = new System.Windows.Forms.ToolStripButton();
            this.exitButton = new System.Windows.Forms.ToolStripButton();
            this.sideToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // computerToolSeparator
            // 
            this.computerToolSeparator.Name = "computerToolSeparator";
            this.computerToolSeparator.Size = new System.Drawing.Size(24, 6);
            this.computerToolSeparator.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
            // 
            // userToolSeparator
            // 
            this.userToolSeparator.Name = "userToolSeparator";
            this.userToolSeparator.Size = new System.Drawing.Size(24, 6);
            this.userToolSeparator.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
            // 
            // configDropDownButton
            // 
            this.configDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.configDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.configDropDownButton.Name = "configDropDownButton";
            this.configDropDownButton.Size = new System.Drawing.Size(24, 60);
            this.configDropDownButton.Text = "Settings";
            // 
            // sideToolbar
            // 
            this.sideToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.sideToolbar.AutoSize = false;
            this.sideToolbar.BackColor = System.Drawing.Color.Transparent;
            this.sideToolbar.Dock = System.Windows.Forms.DockStyle.None;
            this.sideToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.sideToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.desktopButton,
            this.computerButton,
            this.documentButton,
            this.pictureButton,
            this.musicButton,
            this.computerToolSeparator,
            this.newEventButton,
            this.newTodoButton,
            this.newJournalButton,
            this.newCalendarButton,
            this.userToolSeparator,
            this.panelDropDownButton,
            this.pluginDropDownButton,
            this.configDropDownButton,
            this.menuToolSeparator,
            this.settingButton,
            this.aboutButton,
            this.exitButton});
            this.sideToolbar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.sideToolbar.Location = new System.Drawing.Point(0, 0);
            this.sideToolbar.Name = "sideToolbar";
            this.sideToolbar.Padding = new System.Windows.Forms.Padding(0);
            this.sideToolbar.Size = new System.Drawing.Size(25, 738);
            this.sideToolbar.TabIndex = 1;
            this.sideToolbar.Text = "Side Toolbar";
            this.sideToolbar.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
            // 
            // desktopButton
            // 
            this.desktopButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.desktopButton.Image = global::MultiDesktop.Properties.Resources.Desktop;
            this.desktopButton.Name = "desktopButton";
            this.desktopButton.Size = new System.Drawing.Size(24, 20);
            this.desktopButton.Text = "Desktop";
            this.desktopButton.Click += new System.EventHandler(this.desktopButton_Click);
            // 
            // computerButton
            // 
            this.computerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.computerButton.Image = global::MultiDesktop.Properties.Resources.MyComputer;
            this.computerButton.Name = "computerButton";
            this.computerButton.Size = new System.Drawing.Size(24, 20);
            this.computerButton.Text = "My Computer";
            this.computerButton.Click += new System.EventHandler(this.computerButton_Click);
            // 
            // documentButton
            // 
            this.documentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.documentButton.Image = global::MultiDesktop.Properties.Resources.MyDocuments;
            this.documentButton.Name = "documentButton";
            this.documentButton.Size = new System.Drawing.Size(24, 20);
            this.documentButton.Text = "My Documents";
            this.documentButton.Click += new System.EventHandler(this.documentButton_Click);
            // 
            // pictureButton
            // 
            this.pictureButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pictureButton.Image = global::MultiDesktop.Properties.Resources.MyPictures;
            this.pictureButton.Name = "pictureButton";
            this.pictureButton.Size = new System.Drawing.Size(24, 20);
            this.pictureButton.Text = "My Pictures";
            this.pictureButton.Click += new System.EventHandler(this.pictureButton_Click);
            // 
            // musicButton
            // 
            this.musicButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.musicButton.Image = global::MultiDesktop.Properties.Resources.MyMusic;
            this.musicButton.Name = "musicButton";
            this.musicButton.Size = new System.Drawing.Size(24, 20);
            this.musicButton.Text = "My Music";
            this.musicButton.Click += new System.EventHandler(this.musicButton_Click);
            // 
            // newEventButton
            // 
            this.newEventButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newEventButton.Image = global::MultiDesktop.Properties.Resources.NewEvent;
            this.newEventButton.Name = "newEventButton";
            this.newEventButton.Size = new System.Drawing.Size(24, 20);
            this.newEventButton.Text = "New Event";
            this.newEventButton.Click += new System.EventHandler(this.newEventButton_Click);
            // 
            // newTodoButton
            // 
            this.newTodoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newTodoButton.Image = global::MultiDesktop.Properties.Resources.NewTodo;
            this.newTodoButton.Name = "newTodoButton";
            this.newTodoButton.Size = new System.Drawing.Size(24, 20);
            this.newTodoButton.Text = "New To-do";
            this.newTodoButton.Click += new System.EventHandler(this.newTodoButton_Click);
            // 
            // newJournalButton
            // 
            this.newJournalButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newJournalButton.Image = global::MultiDesktop.Properties.Resources.NewJournal;
            this.newJournalButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newJournalButton.Name = "newJournalButton";
            this.newJournalButton.Size = new System.Drawing.Size(24, 20);
            this.newJournalButton.Text = "New Journal";
            // 
            // newCalendarButton
            // 
            this.newCalendarButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newCalendarButton.Image = global::MultiDesktop.Properties.Resources.NewCalendar;
            this.newCalendarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newCalendarButton.Name = "newCalendarButton";
            this.newCalendarButton.Size = new System.Drawing.Size(24, 20);
            this.newCalendarButton.Text = "New Calendar";
            this.newCalendarButton.Click += new System.EventHandler(this.newCalendarButton_Click);
            // 
            // panelDropDownButton
            // 
            this.panelDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.panelDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calculatorMenu,
            this.musicPlayerMenu,
            this.pictureGalleryMenu,
            this.rssFeedMenu,
            this.weatherMenu});
            this.panelDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.panelDropDownButton.Name = "panelDropDownButton";
            this.panelDropDownButton.Size = new System.Drawing.Size(24, 47);
            this.panelDropDownButton.Text = "Panel";
            // 
            // calculatorMenu
            // 
            this.calculatorMenu.CheckOnClick = true;
            this.calculatorMenu.Name = "calculatorMenu";
            this.calculatorMenu.Size = new System.Drawing.Size(152, 22);
            this.calculatorMenu.Text = "Calculator";
            this.calculatorMenu.Click += new System.EventHandler(this.calculatorMenu_Click);
            // 
            // musicPlayerMenu
            // 
            this.musicPlayerMenu.CheckOnClick = true;
            this.musicPlayerMenu.Name = "musicPlayerMenu";
            this.musicPlayerMenu.Size = new System.Drawing.Size(152, 22);
            this.musicPlayerMenu.Text = "Music Player";
            this.musicPlayerMenu.Click += new System.EventHandler(this.musicPlayerMenu_Click);
            // 
            // pictureGalleryMenu
            // 
            this.pictureGalleryMenu.CheckOnClick = true;
            this.pictureGalleryMenu.Name = "pictureGalleryMenu";
            this.pictureGalleryMenu.Size = new System.Drawing.Size(152, 22);
            this.pictureGalleryMenu.Text = "Picture Gallery";
            this.pictureGalleryMenu.Click += new System.EventHandler(this.pictureGalleryMenu_Click);
            // 
            // rssFeedMenu
            // 
            this.rssFeedMenu.CheckOnClick = true;
            this.rssFeedMenu.Name = "rssFeedMenu";
            this.rssFeedMenu.Size = new System.Drawing.Size(152, 22);
            this.rssFeedMenu.Text = "RSS Feed";
            this.rssFeedMenu.Click += new System.EventHandler(this.rssFeedMenu_Click);
            // 
            // weatherMenu
            // 
            this.weatherMenu.Name = "weatherMenu";
            this.weatherMenu.Size = new System.Drawing.Size(152, 22);
            this.weatherMenu.Text = "Weather";
            this.weatherMenu.Click += new System.EventHandler(this.weatherMenu_Click);
            // 
            // pluginDropDownButton
            // 
            this.pluginDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.pluginDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("pluginDropDownButton.Image")));
            this.pluginDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pluginDropDownButton.Name = "pluginDropDownButton";
            this.pluginDropDownButton.Size = new System.Drawing.Size(24, 52);
            this.pluginDropDownButton.Text = "Plugin";
            // 
            // menuToolSeparator
            // 
            this.menuToolSeparator.Name = "menuToolSeparator";
            this.menuToolSeparator.Size = new System.Drawing.Size(24, 6);
            this.menuToolSeparator.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
            // 
            // settingButton
            // 
            this.settingButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.settingButton.Image = global::MultiDesktop.Properties.Resources.Setting;
            this.settingButton.Name = "settingButton";
            this.settingButton.Size = new System.Drawing.Size(24, 20);
            this.settingButton.Text = "Setting";
            this.settingButton.Click += new System.EventHandler(this.settingButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.aboutButton.Image = global::MultiDesktop.Properties.Resources.Info;
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(24, 20);
            this.aboutButton.Text = "About";
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exitButton.Image = global::MultiDesktop.Properties.Resources.Exit;
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(24, 20);
            this.exitButton.Text = "Exit";
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // MultiDesktopBar
            // 
            this.ClientSize = new System.Drawing.Size(25, 738);
            this.ControlBox = false;
            this.Controls.Add(this.sideToolbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MultiDesktopBar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.sideToolbar.ResumeLayout(false);
            this.sideToolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        #region SetBottom method

        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X,
           int Y, int cx, int cy, uint uFlags);

        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 SWP_NOACTIVATE = 0x0010;
        const int WM_WINDOWPOSCHANGING = 0x0046;

        protected override void WndProc(ref Message m)
        {
            // Listen for operating system messages.
            switch (m.Msg)
            {
                // The WM_WINDOWPOSCHANGING message occurs when a window whose
                // size, position, or place in the Z order is about to change.
                case WM_WINDOWPOSCHANGING:
                    //SetWindowPos(this.Handle, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOMOVE | SWP_NOACTIVATE);
                    break;
            }
            base.WndProc(ref m);
        }

        #endregion

        public MultiDesktopBar()
        {
            SetWindowPos(this.Handle, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOMOVE | SWP_NOACTIVATE);

            InitializeComponent();
            Height = Screen.PrimaryScreen.WorkingArea.Size.Height;
            Location = new System.Drawing.Point(Screen.PrimaryScreen.WorkingArea.Width - Width, 0);
        }

        public void loadSetting()
        {
            settingManager = new SettingManager();
            settingManager.loadDatabase();
            settingManager.CategoryManager.loadDatabase();
        }

        public void loadCalendars()
        {
            settingManager.CalendarManager.loadDatabase();
        }

        public void loadGoals()
        {
            settingManager.GoalManager.loadDatabase();
        }

        public void loadPanels()
        {
            CalendarManager calendarManager = settingManager.CalendarManager;
            GoalPlanner goalPlanner = settingManager.GoalManager;

            settingDialog = new SettingDialog(settingManager);            

            CalendarPanel calendarPanel = new CalendarPanel(calendarManager.EventManager);
            panelDropDownButton.DropDownItems.Add(calendarPanel.MenuItem);

            TodoPanel todoPanel = new TodoPanel(calendarManager.TodoManager);
            panelDropDownButton.DropDownItems.Add(todoPanel.MenuItem);
            
            PlannerPanel plannerPanel = new PlannerPanel(calendarManager.EventManager, calendarManager.TodoManager, settingManager.GoalManager.TaskManager);
            panelDropDownButton.DropDownItems.Add(plannerPanel.MenuItem);

            GoalPanel goalPanel = new GoalPanel(goalPlanner);
            panelDropDownButton.DropDownItems.Add(goalPanel.MenuItem);

            CalendarForm.SettingController = settingManager;
            TodoForm.SettingController = settingManager;
            EventForm.SettingController = settingManager;
            VisionForm.Controller = goalPlanner.VisionManager;
            LGoalForm.GoalController = goalPlanner;
            LGoalForm.CategoryController = settingManager.CategoryManager;
            SGoalForm.GoalController = goalPlanner;
            SGoalForm.CategoryController = settingManager.CategoryManager;
            TaskForm.TaskController = goalPlanner.TaskManager;
            TaskForm.SettingController = settingManager;
        }


        #region LoadPlugins

        public void loadPlugins()
        {
            //Retrieve a plugin collection using our custom Configuration section handler
            Dictionary<string, ArrayList> plugins = (Dictionary<string, ArrayList>)System.Configuration.ConfigurationManager.GetSection("plugins");
            projectPlugins = new List<IProjDBManager>();
            panelPlugins = new List<IPanelPlugin>();

            pluginDropDownButton.DropDownItems.Clear();

            //Create the delegate right from the start
            //no need to create one for each menu item separately
            EventHandler projectHandler = new EventHandler(OnProjectPluginClick);
            EventHandler panelHandler = new EventHandler(OnPanelPluginClick);

            foreach (IProjDBManager plugin in plugins["IProjDBManager"])
            {
                projectPlugins.Add(plugin);
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Name = plugin.PanelName;
                item.CheckOnClick = true;
                item.Size = new System.Drawing.Size(152, 22);
                item.Text = plugin.PanelName;
                item.Click += new System.EventHandler(projectHandler);
                pluginDropDownButton.DropDownItems.Add(item);
                plugin.PanelClosing += new FormClosingEventHandler(plugin_PanelClosing);
            }

            foreach (IPanelPlugin plugin in plugins["IPanelPlugin"])
            {
                panelPlugins.Add(plugin);
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Name = plugin.PanelName;
                item.CheckOnClick = true;
                item.Size = new System.Drawing.Size(152, 22);
                item.Text = plugin.PanelName;
                item.Click += new System.EventHandler(panelHandler);
                pluginDropDownButton.DropDownItems.Add(item);
                plugin.PanelClosing += new FormClosingEventHandler(plugin_PanelClosing);
            }
        }

        #endregion

        public void loadPluginDatabase()
        {
            foreach (IProjDBManager plugin in projectPlugins)
            {
                plugin.LoadDatabase();
            }
        }

        #region Plugin Event Handler

        private void OnProjectPluginClick(object sender, EventArgs args)
        {
            string pluginName = ((ToolStripMenuItem)sender).Text;

            foreach (IProjDBManager plugin in projectPlugins)
            {
                if (plugin.PanelName == pluginName)
                {
                    if (((ToolStripMenuItem)sender).Checked)
                    {
                        plugin.showPanel();
                    }
                    else
                    {
                        plugin.hidePanel();
                    }
                }
            }
        }

        private void OnPanelPluginClick(object sender, EventArgs args)
        {
            string pluginName = ((ToolStripMenuItem)sender).Text;

            foreach (IPanelPlugin plugin in panelPlugins)
            {
                if (plugin.PanelName == pluginName)
                {
                    if (((ToolStripMenuItem)sender).Checked)
                    {
                        plugin.showPanel();
                    }
                    else
                    {
                        plugin.hidePanel();
                    }
                }
            }
        }

        private void plugin_PanelClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            ((IPanelPlugin)sender).hidePanel();
            ((ToolStripMenuItem)pluginDropDownButton.DropDownItems[((IPanelPlugin)sender).PanelName]).Checked = false;
        }

        #endregion

        #region Sidebar Event Handlers

        private void desktopButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
        }

        private void computerButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("::{20d04fe0-3aea-1069-a2d8-08002b30309d}");
        }

        private void documentButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
        }

        private void pictureButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
        }

        private void musicButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
        }

        private void newCalendarButton_Click(object sender, EventArgs e)
        {
            CalendarForm newForm = new CalendarForm();
            newForm.Show();
        }

        private void newEventButton_Click(object sender, EventArgs e)
        {
            EventForm newForm = new EventForm();
            newForm.Show();
        }

        private void newTodoButton_Click(object sender, EventArgs e)
        {
            TodoForm newForm = new TodoForm();
            newForm.Show();
        }

        private void calculatorMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented till Beta Version");
            calculatorMenu.Checked = false;
        }

        private void musicPlayerMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented till Gamma Version");
            musicPlayerMenu.Checked = false;
        }

        private void pictureGalleryMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented till Gamma Version");
            pictureGalleryMenu.Checked = false;
        }

        private void rssFeedMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented till Delta Version");
            rssFeedMenu.Checked = false;
        }

        private void weatherMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented till Beta Version");
            weatherMenu.Checked = false;
        }

        private void settingButton_Click(object sender, EventArgs e)
        {
            if (settingDialog.ShowDialog() == DialogResult.OK)
            {
                //Save changed settings
            }
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}