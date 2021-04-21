using Microsoft.Win32;
using N1;
using N1.N3;
using LauncherKG.Source;
using LauncherKG.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Management;
using System.Threading;
using System.Windows.Forms;

namespace LauncherKG
{
    public class Main : Form
    {
        private static Mutex mutex;
        private static string launcheritself = "#launcheritself";
        private bool Button;
        private bool EnableBtn = true;
        private IContainer componentss;
        public Label Status;
        public PictureBox Btn_Start;
        public PictureBox Btn_Quit;
        public PictureBox Btn_Options;
        public PictureBox Btn_WindowMode;
        private Label WindowModes;
        private Label Title;
        private Label CopyRight;
        private System.Windows.Forms.Timer Timer;
        public PictureBox Background;
        public PictureBox Background2;
        private Label WindowMode;
        public PictureBox Btn_HomePage;
        private IContainer components;
        public WebBrowser WebPage;
        public PictureBox Btn_Minimize;

        public Main()
        {
            this.InitializeComponent();
            T6 t6 = new T1().M2("mu.ini");
            string str1 = "0";
            string str2 = t6.get_Item("LAUNCHER").get_Item("Update_URL");
            string str3 = t6.get_Item("LAUNCHER").get_Item("Launcher_URL");
            string str4 = t6.get_Item("LAUNCHER").get_Item("Home_URL");
            t6.get_Item("LAUNCHER").get_Item("Server_Name");
            Import.UpdateURL = str2;
            Import.HomeURL = str4;
            this.Title.Text = Import.launcherName;
            this.WebPage.Url = new Uri(str3 + "index.php");
            if (str1 == "1")
            Import.Stance = true;
            Import.gMain = this;
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            Common.ChangeStatus("CONNECTING");
            DateTime now = DateTime.Now;
            do
            {
                Application.DoEvents();
            }
            while (now.AddSeconds(1.0) > DateTime.Now);
            this.BeginInvoke((Delegate) new Main.Delegate(this.NetCheck));
            this.Timer.Interval = 600;
            this.Timer.Start();
        }

        public void NetCheck() => Networking.CheckNetwork();

        public string M64()
        {
            foreach (ManagementObject managementObject in new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia").Get())
            {
                if (managementObject["SerialNumber"] != null)
                    return managementObject["SerialNumber"].ToString();
            }
            return string.Empty;
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            Main.mutex = new Mutex(true, "#32770");
            Starter.Start();
        }

        private void Btn_Quit_Click(object sender, EventArgs e) => this.Close();

        private void Btn_WindowMode_Click(object sender, EventArgs e)
        {
            if (!Import.Stance)
            {
                try
                {
                    RegistryKey subKey = Registry.CurrentUser.CreateSubKey("Software\\Webzen\\Mu\\Config");
                    int num = (int) subKey.GetValue("WindowMode");
                    subKey.CreateSubKey("WindowMode");
                    if (num == 1)
                    {
                        subKey.SetValue("WindowMode", (object) 0, RegistryValueKind.DWord);
                        subKey.SetValue("FullScreenMode", (object) 1, RegistryValueKind.DWord);
                        this.Btn_WindowMode.BackgroundImage = (Image) Resources.windowmode_uncheck;
                    }
                    else
                    {
                        subKey.SetValue("WindowMode", (object) 1, RegistryValueKind.DWord);
                        subKey.SetValue("FullScreenMode", (object) 0, RegistryValueKind.DWord);
                        this.Btn_WindowMode.BackgroundImage = (Image) Resources.windowmode;
                    }
                    subKey.Close();
                }
                catch
                {
                }
            }
            else
            {
                string str = ".\\\\LauncherOption.if";
                try
                {
                    if (File.ReadAllLines(str)[1] == "WindowMode:1")
                    {
                        Common.M109("WindowMode:0", str, 2);
                        this.Btn_WindowMode.BackgroundImage = (Image) Resources.windowmode_uncheck;
                    }
                    else
                    {
                        Common.M109("WindowMode:1", str, 2);
                        this.Btn_WindowMode.BackgroundImage = (Image) Resources.windowmode;
                    }
                }
                catch
                {
                    if (!File.Exists(str))
                    {
                        string[] contents = new string[3]
                        {
                            "DevModeIndex:1",
                            "WindowMode:1",
                            "ID:"
                        };
                        File.WriteAllLines(str, contents);
                    }
                    else
                        Common.M109("WindowMode:1", str, 2);
                    this.Btn_WindowMode.BackgroundImage = (Image) Resources.windowmode;
                }
            }
        }

        private void Btn_Options_Click(object sender, EventArgs e)
        {
            OptionForm t19 = new OptionForm();
            int num = (int) t19.ShowDialog();
            t19.Dispose();
        }

        private void M69(object sender, EventArgs e)
        {
        }

        private void M70(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            Common.ReleaseCapture();
            Common.SendMessage(this.Handle, 161, 2, 0);
        }

        private static bool M72()
        {
            try
            {
                Mutex.OpenExisting(Main.launcheritself);
            }
            catch
            {
                Main.mutex = new Mutex(true, Main.launcheritself);
                return true;
            }
            return false;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (!Main.M72() && MessageBox.Show("Another Autoupdate is running.\nDo you want to continue?", Import.windowName, MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                this.Close();
            if (!Import.Stance)
            {
                try
                {
                    RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Webzen\\Mu\\Config");
                    if (registryKey != null)
                    {
                        if (registryKey.GetValue("WindowMode") != null)
                        {
                            if ((int) registryKey.GetValue("WindowMode") == 1)
                                this.Btn_WindowMode.BackgroundImage = (Image) Resources.windowmode;
                        }
                        else
                        {
                            registryKey = Registry.CurrentUser.CreateSubKey("Software\\Webzen\\Mu\\Config");
                            registryKey.CreateSubKey("WindowMode");
                            registryKey.SetValue("WindowMode", (object) 0, RegistryValueKind.DWord);
                        }
                    }
                    else
                    {
                        registryKey = Registry.CurrentUser.CreateSubKey("Software\\Webzen\\Mu\\Config");
                        registryKey.CreateSubKey("WindowMode");
                        registryKey.SetValue("WindowMode", (object) 0, RegistryValueKind.DWord);
                        registryKey.CreateSubKey("FullScreenMode");
                        registryKey.SetValue("FullScreenMode", (object) 1, RegistryValueKind.DWord);
                    }
                    registryKey.Close();
                }
                catch
                {
                }
            }
            else
            {
                try
                {
                    if (!(File.ReadAllLines("LauncherOption.if")[1] == "WindowMode:1"))
                        return;
                    this.Btn_WindowMode.BackgroundImage = (Image) Resources.windowmode;
                }
                catch
                {
                }
            }
        }

        private void Btn_Start_MouseDown(object sender, MouseEventArgs e) => this.Btn_Start.BackgroundImage = (Image) Resources.start_3;

        private void Btn_Start_MouseHover(object sender, EventArgs e)
        {
            this.Btn_Start.BackgroundImage = (Image) Resources.start_2;
            this.Button = true;
        }

        private void Btn_Start_MouseLeave(object sender, EventArgs e)
        {
            this.Btn_Start.BackgroundImage = (Image) Resources.start_1;
            this.Button = false;
        }

        private void Btn_Start_MouseUp(object sender, MouseEventArgs e) => this.Btn_Start.BackgroundImage = (Image) Resources.start_1;

        private void Btn_Options_MouseDown(object sender, MouseEventArgs e) => this.Btn_Options.BackgroundImage = (Image) Resources.setting_3;

        private void Btn_Options_MouseUp(object sender, MouseEventArgs e) => this.Btn_Options.BackgroundImage = (Image) Resources.setting_1;

        private void CopyRight_Click(object sender, EventArgs e) => Process.Start("mailto:arsenicromania@gmail.com");

        private void Btn_Quit_MouseDown(object sender, MouseEventArgs e) => this.Btn_Quit.BackgroundImage = (Image) Resources.exit_3;

        private void Btn_Quit_MouseHover(object sender, EventArgs e) => this.Btn_Quit.BackgroundImage = (Image) Resources.exit_2;

        private void Btn_Quit_MouseLeave(object sender, EventArgs e) => this.Btn_Quit.BackgroundImage = (Image) Resources.exit_1;

        private void Btn_Quit_MouseUp(object sender, MouseEventArgs e) => this.Btn_Quit.BackgroundImage = (Image) Resources.exit_1;

        private void Btn_Options_MouseHover(object sender, EventArgs e) => this.Btn_Options.BackgroundImage = (Image) Resources.setting_2;

        private void Btn_Options_MouseLeave(object sender, EventArgs e) => this.Btn_Options.BackgroundImage = (Image) Resources.setting_1;

        private void WebPage_DocumentComplete(object sender, WebBrowserDocumentCompletedEventArgs e) => this.WebPage.Visible = true;

        private void Btn_HomePage_Click(object sender, EventArgs e) => Process.Start(Import.HomeURL);

        private void Btn_HomePage_MouseHover(object sender, EventArgs e) => this.Btn_HomePage.BackgroundImage = (Image) Resources.home_2;

        private void Btn_HomePage_MouseUp(object sender, MouseEventArgs e) => this.Btn_HomePage.BackgroundImage = (Image) Resources.home_2;

        private void Btn_HomePage_MouseLeave(object sender, EventArgs e) => this.Btn_HomePage.BackgroundImage = (Image) Resources.home_1;

        private void Btn_HomePage_MouseDown(object sender, MouseEventArgs e) => this.Btn_HomePage.BackgroundImage = (Image) Resources.home_3;

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.Button || !Import.FalseStance)
                return;
            if (this.EnableBtn)
                this.Btn_Start.BackgroundImage = (Image) Resources.start_2;
            else
                this.Btn_Start.BackgroundImage = (Image) Resources.start_1;
            this.EnableBtn = !this.EnableBtn;
        }

        private void M94(object sender, EventArgs e)
        {
        }

        private void Btn_Minimize_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

        private void Btn_Minimize_MouseDown(object sender, MouseEventArgs e) => this.Btn_Minimize.BackgroundImage = (Image) Resources.minimize_3;

        private void Btn_Minimize_MouseHover(object sender, EventArgs e) => this.Btn_Minimize.BackgroundImage = (Image) Resources.minimize_2;

        private void Btn_Minimize_MouseLeave(object sender, EventArgs e) => this.Btn_Minimize.BackgroundImage = (Image) Resources.minimize_1;

        private void Btn_Minimize_MouseUp(object sender, MouseEventArgs e) => this.Btn_Minimize.BackgroundImage = (Image) Resources.minimize_2;

        protected override void Dispose(bool disposing)
        {
            if ((!disposing ? 0 : (this.componentss != null ? 1 : 0)) != 0)
                this.componentss.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Status = new System.Windows.Forms.Label();
            this.Btn_Start = new System.Windows.Forms.PictureBox();
            this.Btn_Quit = new System.Windows.Forms.PictureBox();
            this.Btn_Options = new System.Windows.Forms.PictureBox();
            this.Btn_WindowMode = new System.Windows.Forms.PictureBox();
            this.WindowModes = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.CopyRight = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.Background = new System.Windows.Forms.PictureBox();
            this.Background2 = new System.Windows.Forms.PictureBox();
            this.WindowMode = new System.Windows.Forms.Label();
            this.Btn_HomePage = new System.Windows.Forms.PictureBox();
            this.Btn_Minimize = new System.Windows.Forms.PictureBox();
            this.WebPage = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Start)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Quit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Options)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_WindowMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Background)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Background2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_HomePage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Minimize)).BeginInit();
            this.SuspendLayout();
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.BackColor = System.Drawing.Color.Transparent;
            this.Status.Font = new System.Drawing.Font("Tahoma", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status.ForeColor = System.Drawing.Color.White;
            this.Status.Location = new System.Drawing.Point(126, 537);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(42, 14);
            this.Status.TabIndex = 6;
            this.Status.Text = "Status";
            // 
            // Btn_Start
            // 
            this.Btn_Start.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Start.BackgroundImage = global::LauncherKG.Properties.Resources.start_3;
            this.Btn_Start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Start.Enabled = false;
            this.Btn_Start.Location = new System.Drawing.Point(840, 503);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(146, 53);
            this.Btn_Start.TabIndex = 7;
            this.Btn_Start.TabStop = false;
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            this.Btn_Start.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_Start_MouseDown);
            this.Btn_Start.MouseLeave += new System.EventHandler(this.Btn_Start_MouseLeave);
            this.Btn_Start.MouseHover += new System.EventHandler(this.Btn_Start_MouseHover);
            this.Btn_Start.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_Start_MouseUp);
            // 
            // Btn_Quit
            // 
            this.Btn_Quit.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Quit.BackgroundImage = global::LauncherKG.Properties.Resources.exit_1;
            this.Btn_Quit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Quit.Location = new System.Drawing.Point(968, 3);
            this.Btn_Quit.Name = "Btn_Quit";
            this.Btn_Quit.Size = new System.Drawing.Size(18, 18);
            this.Btn_Quit.TabIndex = 8;
            this.Btn_Quit.TabStop = false;
            this.Btn_Quit.Click += new System.EventHandler(this.Btn_Quit_Click);
            this.Btn_Quit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_Quit_MouseDown);
            this.Btn_Quit.MouseLeave += new System.EventHandler(this.Btn_Quit_MouseLeave);
            this.Btn_Quit.MouseHover += new System.EventHandler(this.Btn_Quit_MouseHover);
            this.Btn_Quit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_Quit_MouseUp);
            // 
            // Btn_Options
            // 
            this.Btn_Options.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Options.BackgroundImage = global::LauncherKG.Properties.Resources.setting_1;
            this.Btn_Options.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Options.Enabled = false;
            this.Btn_Options.Location = new System.Drawing.Point(924, 3);
            this.Btn_Options.Name = "Btn_Options";
            this.Btn_Options.Size = new System.Drawing.Size(18, 18);
            this.Btn_Options.TabIndex = 9;
            this.Btn_Options.TabStop = false;
            this.Btn_Options.Click += new System.EventHandler(this.Btn_Options_Click);
            this.Btn_Options.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_Options_MouseDown);
            this.Btn_Options.MouseLeave += new System.EventHandler(this.Btn_Options_MouseLeave);
            this.Btn_Options.MouseHover += new System.EventHandler(this.Btn_Options_MouseHover);
            this.Btn_Options.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_Options_MouseUp);
            // 
            // Btn_WindowMode
            // 
            this.Btn_WindowMode.BackColor = System.Drawing.Color.Transparent;
            this.Btn_WindowMode.BackgroundImage = global::LauncherKG.Properties.Resources.windowmode_uncheck;
            this.Btn_WindowMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_WindowMode.Enabled = false;
            this.Btn_WindowMode.Location = new System.Drawing.Point(812, 533);
            this.Btn_WindowMode.Name = "Btn_WindowMode";
            this.Btn_WindowMode.Size = new System.Drawing.Size(18, 18);
            this.Btn_WindowMode.TabIndex = 10;
            this.Btn_WindowMode.TabStop = false;
            this.Btn_WindowMode.Click += new System.EventHandler(this.Btn_WindowMode_Click);
            // 
            // WindowModes
            // 
            this.WindowModes.AutoSize = true;
            this.WindowModes.BackColor = System.Drawing.Color.Transparent;
            this.WindowModes.ForeColor = System.Drawing.Color.Black;
            this.WindowModes.Location = new System.Drawing.Point(760, 517);
            this.WindowModes.Name = "WindowModes";
            this.WindowModes.Size = new System.Drawing.Size(76, 13);
            this.WindowModes.TabIndex = 13;
            this.WindowModes.Text = "Window Mode";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.Title.Location = new System.Drawing.Point(28, 4);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(170, 14);
            this.Title.TabIndex = 14;
            this.Title.Text = "PTYNetwork.com Launcher";
            // 
            // CopyRight
            // 
            this.CopyRight.AutoSize = true;
            this.CopyRight.BackColor = System.Drawing.Color.Transparent;
            this.CopyRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CopyRight.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopyRight.ForeColor = System.Drawing.Color.SeaShell;
            this.CopyRight.Location = new System.Drawing.Point(656, 538);
            this.CopyRight.Name = "CopyRight";
            this.CopyRight.Size = new System.Drawing.Size(88, 13);
            this.CopyRight.TabIndex = 41;
            this.CopyRight.Text = "PTYNetwork.com";
            this.CopyRight.Click += new System.EventHandler(this.CopyRight_Click);
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // Background
            // 
            this.Background.BackgroundImage = global::LauncherKG.Properties.Resources.BITMAP154_1;
            this.Background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Background.Location = new System.Drawing.Point(128, 517);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(619, 11);
            this.Background.TabIndex = 47;
            this.Background.TabStop = false;
            // 
            // Background2
            // 
            this.Background2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Background2.Image = global::LauncherKG.Properties.Resources.BITMAP155_1;
            this.Background2.Location = new System.Drawing.Point(130, 521);
            this.Background2.Name = "Background2";
            this.Background2.Size = new System.Drawing.Size(0, 3);
            this.Background2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Background2.TabIndex = 50;
            this.Background2.TabStop = false;
            // 
            // WindowMode
            // 
            this.WindowMode.AutoSize = true;
            this.WindowMode.BackColor = System.Drawing.Color.Transparent;
            this.WindowMode.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.WindowMode.Location = new System.Drawing.Point(758, 515);
            this.WindowMode.Name = "WindowMode";
            this.WindowMode.Size = new System.Drawing.Size(76, 13);
            this.WindowMode.TabIndex = 51;
            this.WindowMode.Text = "Window Mode";
            // 
            // Btn_HomePage
            // 
            this.Btn_HomePage.BackColor = System.Drawing.Color.Transparent;
            this.Btn_HomePage.BackgroundImage = global::LauncherKG.Properties.Resources.home_1;
            this.Btn_HomePage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_HomePage.Enabled = false;
            this.Btn_HomePage.Location = new System.Drawing.Point(946, 3);
            this.Btn_HomePage.Name = "Btn_HomePage";
            this.Btn_HomePage.Size = new System.Drawing.Size(18, 18);
            this.Btn_HomePage.TabIndex = 52;
            this.Btn_HomePage.TabStop = false;
            this.Btn_HomePage.Click += new System.EventHandler(this.Btn_HomePage_Click);
            this.Btn_HomePage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_HomePage_MouseDown);
            this.Btn_HomePage.MouseLeave += new System.EventHandler(this.Btn_HomePage_MouseLeave);
            this.Btn_HomePage.MouseHover += new System.EventHandler(this.Btn_HomePage_MouseHover);
            this.Btn_HomePage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_HomePage_MouseUp);
            // 
            // Btn_Minimize
            // 
            this.Btn_Minimize.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Minimize.BackgroundImage = global::LauncherKG.Properties.Resources.minimize_1;
            this.Btn_Minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Minimize.Enabled = false;
            this.Btn_Minimize.Location = new System.Drawing.Point(902, 3);
            this.Btn_Minimize.Name = "Btn_Minimize";
            this.Btn_Minimize.Size = new System.Drawing.Size(18, 18);
            this.Btn_Minimize.TabIndex = 53;
            this.Btn_Minimize.TabStop = false;
            this.Btn_Minimize.Click += new System.EventHandler(this.Btn_Minimize_Click);
            this.Btn_Minimize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_Minimize_MouseDown);
            this.Btn_Minimize.MouseLeave += new System.EventHandler(this.Btn_Minimize_MouseLeave);
            this.Btn_Minimize.MouseHover += new System.EventHandler(this.Btn_Minimize_MouseHover);
            this.Btn_Minimize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_Minimize_MouseUp);
            // 
            // WebPage
            // 
            this.WebPage.IsWebBrowserContextMenuEnabled = false;
            this.WebPage.Location = new System.Drawing.Point(5, 23);
            this.WebPage.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebPage.Name = "WebPage";
            this.WebPage.ScrollBarsEnabled = false;
            this.WebPage.Size = new System.Drawing.Size(979, 475);
            this.WebPage.TabIndex = 44;
            this.WebPage.Url = new System.Uri("https://www.google.com", System.UriKind.Absolute);
            this.WebPage.Visible = false;
            this.WebPage.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebPage_DocumentComplete);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LauncherKG.Properties.Resources.BITMAP129_1;
            this.ClientSize = new System.Drawing.Size(990, 560);
            this.Controls.Add(this.Btn_Minimize);
            this.Controls.Add(this.Btn_HomePage);
            this.Controls.Add(this.WindowMode);
            this.Controls.Add(this.Background2);
            this.Controls.Add(this.Background);
            this.Controls.Add(this.WebPage);
            this.Controls.Add(this.CopyRight);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.WindowModes);
            this.Controls.Add(this.Btn_WindowMode);
            this.Controls.Add(this.Btn_Options);
            this.Controls.Add(this.Btn_Quit);
            this.Controls.Add(this.Btn_Start);
            this.Controls.Add(this.Status);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(990, 560);
            this.MinimumSize = new System.Drawing.Size(990, 560);
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MU Auto Update";
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Start)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Quit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Options)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_WindowMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Background)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Background2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_HomePage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Minimize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public delegate void Delegate();
    }
}
