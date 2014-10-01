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
        private ToolStripMenuItem calendarMenu;
        private ToolStripMenuItem musicPlayerMenu;
        private ToolStripMenuItem pictureGalleryMenu;
        private ToolStripMenuItem rssFeedMenu;
        private ToolStripMenuItem todosMenu;
        private ToolStripSeparator menuToolSeparator;
        private ToolStripDropDownButton pluginDropDownButton;
        private ToolStripMenuItem weatherMenu;
        private ToolStripButton newJournalButton;
        private ToolStripButton newCalendarButton;
        private ToolStripMenuItem schedulerMenu;
        private ToolStripMenuItem plannerMenu;

        private SettingDialog settingDialog;
        private PlannerPanel plannerPanel;
        private CalendarPanel calendarPanel;
        private TodoPanel todoPanel;
        private List<IProjectPlugin> projectPlugins;
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
            foreach (IProjectPlugin plugin in projectPlugins)
            {
                plugin.CloseDatabase();
            }

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
            this.calendarMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.musicPlayerMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureGalleryMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.rssFeedMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.schedulerMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.todosMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.weatherMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuToolSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.settingButton = new System.Windows.Forms.ToolStripButton();
            this.aboutButton = new System.Windows.Forms.ToolStripButton();
            this.exitButton = new System.Windows.Forms.ToolStripButton();
            this.plannerMenu = new System.Windows.Forms.ToolStripMenuItem();
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
            this.calendarMenu,
            this.musicPlayerMenu,
            this.pictureGalleryMenu,
            this.plannerMenu,
            this.rssFeedMenu,
            /*this.schedulerMenu,*/
            this.todosMenu,
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
            // calendarMenu
            // 
            this.calendarMenu.CheckOnClick = true;
            this.calendarMenu.Name = "calendarMenu";
            this.calendarMenu.Size = new System.Drawing.Size(152, 22);
            this.calendarMenu.Text = "Calendar";
            this.calendarMenu.Click += new System.EventHandler(this.calendarMenu_Click);
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
            // schedulerMenu
            // 
            this.schedulerMenu.CheckOnClick = true;
            this.schedulerMenu.Name = "schedulerMenu";
            this.schedulerMenu.Size = new System.Drawing.Size(152, 22);
            this.schedulerMenu.Text = "Scheduler";
            this.schedulerMenu.Click += new System.EventHandler(this.schedulerMenu_Click);
            // 
            // todosMenu
            // 
            this.todosMenu.CheckOnClick = true;
            this.todosMenu.Name = "todosMenu";
            this.todosMenu.Size = new System.Drawing.Size(152, 22);
            this.todosMenu.Text = "To-dos";
            this.todosMenu.Click += new System.EventHandler(this.todosMenu_Click);
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
            this.settingButton.Click += new EventHandler(settingButton_Click);
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
            // plannerMenu
            // 
            this.plannerMenu.CheckOnClick = true;
            this.plannerMenu.Name = "plannerMenu";
            this.plannerMenu.Size = new System.Drawing.Size(152, 22);
            this.plannerMenu.Text = "Planner";
            this.plannerMenu.Click += new EventHandler(plannerMenu_Click);
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

            SplashScreen.SetStatus("now initializing calendar panel");
            SplashScreen.Progress = 0.12;
            calendarPanel = new CalendarPanel(CalendarManager.Calendar);
            calendarPanel.FormClosing += new FormClosingEventHandler(calendarPanel_Closing);

            SplashScreen.SetStatus("now initializing todo panel");
            SplashScreen.Progress = 0.14;
            todoPanel = new TodoPanel();
            todoPanel.FormClosing += new FormClosingEventHandler(todoPanel_Closing);

            //SchedulerPanel.initialize();
            //SchedulerPanel.Panel.FormClosing += new FormClosingEventHandler(schedulerPanel_FormClosing);

            SplashScreen.SetStatus("now initializing remaining panels");
            SplashScreen.Progress = 0.45;

            settingDialog = new SettingDialog();

            plannerPanel = new PlannerPanel();
            plannerPanel.FormClosing += new FormClosingEventHandler(plannerPanel_FormClosing);

            SplashScreen.SetStatus("now loading plugins");
            SplashScreen.Progress = 0.55;
            LoadPlugins();

            SplashScreen.SetStatus("now loading plugin database");
            SplashScreen.Progress = 0.75;
            foreach (IProjectPlugin plugin in projectPlugins)
            {
                plugin.LoadDatabase();
            }

            SplashScreen.SetStatus("now opening schedule panel");
            SplashScreen.Progress = 0.95;

            SplashScreen.SetStatus("now updating the schedule for today");
            SplashScreen.Progress = 0.96;

            SplashScreen.Progress = 1;
            SplashScreen.CloseForm();

            //Remove all eventhandlers associated with IDatabasePlugins
        }


        #region LoadPlugins

        private void LoadPlugins()
        {
            //Retrieve a plugin collection using our custom Configuration section handler
            Dictionary<string, ArrayList> plugins = (Dictionary<string, ArrayList>)System.Configuration.ConfigurationManager.GetSection("plugins");
            projectPlugins = new List<IProjectPlugin>();
            panelPlugins = new List<IPanelPlugin>();

            pluginDropDownButton.DropDownItems.Clear();

            //Create the delegate right from the start
            //no need to create one for each menu item separately
            EventHandler projectHandler = new EventHandler(OnProjectPluginClick);
            EventHandler panelHandler = new EventHandler(OnPanelPluginClick);

            foreach (IProjectPlugin plugin in plugins["IProjectPlugin"])
            {
                projectPlugins.Add(plugin);
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Name = plugin.PanelName;
                item.CheckOnClick = true;
                item.Size = new System.Drawing.Size(152, 22);
                item.Text = plugin.PanelName;
                item.Click += new System.EventHandler(projectHandler);
                pluginDropDownButton.DropDownItems.Add(item);
                plugin.LoadingStatusChanged += new LoadingStatusChangedHandler(plugin_LoadingStatusChanged);
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

        private void plugin_LoadingStatusChanged(object sender, StatusArgs e)
        {
            SplashScreen.AddStatusDetail(e.Progress);
        }

        #endregion

        #region Plugin Event Handler

        private void OnProjectPluginClick(object sender, EventArgs args)
        {
            string pluginName = ((ToolStripMenuItem)sender).Text;

            foreach (IProjectPlugin plugin in projectPlugins)
            {
                if (plugin.PanelName == pluginName)
                {
                    if (((ToolStripMenuItem)sender).Checked)
                    {
                        plugin.ShowPanel();
                    }
                    else
                    {
                        plugin.HidePanel();
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
                        plugin.ShowPanel();
                    }
                    else
                    {
                        plugin.HidePanel();
                    }
                }
            }
        }

        private void plugin_PanelClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            ((IPanelPlugin)sender).HidePanel();
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
            MessageBox.Show("Not implemented till Beta Version");
            calendarMenu.Checked = false;
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

        private void calendarMenu_Click(object sender, EventArgs e)
        {
            if (calendarMenu.Checked)
            {
                calendarPanel.Show();
            }
            else
            {
                calendarPanel.Hide();
            }
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

        private void schedulerMenu_Click(object sender, EventArgs e)
        {
            if (schedulerMenu.Checked)
            {
                //SchedulerPanel.Panel.Show();
            }
            else
            {
                //SchedulerPanel.Panel.Hide();
            }
        }

        private void schedulerPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*e.Cancel = true;
            SchedulerPanel.Panel.Hide();
            schedulerMenu.Checked = false;*/
        }

        private void plannerMenu_Click(object sender, EventArgs e)
        {
            if (plannerMenu.Checked)
            {
                plannerPanel.Show();
            }
            else
            {
                plannerPanel.Hide();
            }
        }

        private void plannerPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            plannerPanel.Hide();
            plannerMenu.Checked = false;
        }

        private void weatherMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented till Beta Version");
            weatherMenu.Checked = false;
        }

        private void todosMenu_Click(object sender, EventArgs e)
        {
            if (todosMenu.Checked)
            {
                todoPanel.Show();
            }
            else
            {
                todoPanel.Hide();
            }
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

        #region Calendar Panel Event Handler

        private void calendarPanel_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            calendarPanel.Hide();
            calendarMenu.Checked = false;
        }

        #endregion

        #region Todo Panel Event Handler

        private void todoPanel_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            todoPanel.Hide();
            todosMenu.Checked = false;
        }

        #endregion
    }
}