// Main.cs
// decrypted by Arsenic for KG-Emulator

using LauncherWebzenV2.Forms;
using LauncherWebzenV2.Properties;
using LauncherWebzenV2.Source;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LauncherWebzenV2
{
    public class Main : Form
    {
        private readonly IContainer components;
        public Label Status;
        public Button Btn_Run;
        public Button Btn_Quit;
        public Button Btn_Options;
        public Label completeProgressText;
        public Label currentProgressText;
        public PictureBox completeBar;
        public PictureBox currentBar;
        public Panel UpdatePanel;
        private WebBrowser webPanel;
        private Label WindowName_txt;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();

        public Main()
        {
            InitializeComponent();
            Import.gMain = this;
            Protect.ReadInfo();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Text = Import.windowName;
            WindowName_txt.Text = Import.windowName;
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Webzen\\Mu\\Config");
            
            if (registryKey != null)
            {
                if (registryKey.GetValue("LangSelection") != null)
                {
                    string strA = registryKey.GetValue("LangSelection").ToString();
                    Import.LauncherLanguage = string.Compare(strA, "Eng") != 0 ? (string.Compare(strA, "Spn") != 0 ? 2 : 1) : 0;
                }
                registryKey.Close();
            }
            if (Import.webPanelURL != "")
            {
                webPanel.Visible = true;
                webPanel.Navigate(Import.webPanelURL);
            }
            Status.Text = Texts.ReloadString();
        }

        private void Btn_Quit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void Btn_Quit_MouseHover(object sender, EventArgs e)
        {
            Btn_Quit.BackgroundImage = Resources.Cerrar_h;
        }

        private void Btn_Quit_MouseLeave(object sender, EventArgs e)
        {
            Btn_Quit.BackgroundImage = Resources.Cerrar_n;
        }

        private void Btn_Quit_MouseDown(object sender, MouseEventArgs e)
        {
            Btn_Quit.BackgroundImage = Resources.Cerrar_c;
        }

        private void Btn_Quit_MouseUp(object sender, MouseEventArgs e)
        {
            Btn_Quit.BackgroundImage = Resources.Cerrar_h;
        }

        private void Btn_Options_Click(object sender, EventArgs e)
        {
            Opacity = 0.5;
            Options options = new Options();
            _ = (int)options.ShowDialog();
            options.Dispose();
            Opacity = 1.0;
        }

        private void Btn_Options_MouseHover(object sender, EventArgs e)
        {
            Btn_Options.BackgroundImage = Resources.Config_h;
        }

        private void Btn_Options_MouseLeave(object sender, EventArgs e)
        {
            Btn_Options.BackgroundImage = Resources.Config_n;
        }

        private void Btn_Options_MouseDown(object sender, MouseEventArgs e)
        {
            Btn_Options.BackgroundImage = Resources.Config_c;
        }

        private void Btn_Options_MouseUp(object sender, MouseEventArgs e)
        {
            Btn_Options.BackgroundImage = Resources.Config_h;
        }

        private void Btn_Run_Click(object sender, EventArgs e)
        {
            if (!Btn_Run.Enabled)
                return;
            ListDownloader.DownloadList();
        }

        /*
        private void Btn_Run_Click(object sender, EventArgs e)
        {
            Starter.Start();
        }
        */

        private void Btn_Run_MouseHover(object sender, EventArgs e)
        {
            if (!Btn_Run.Enabled)
            {
                return;
            }

            Btn_Run.BackgroundImage = Resources.Jugar_h;
        }

        private void Btn_Run_MouseLeave(object sender, EventArgs e)
        {
            if (!Btn_Run.Enabled)
            {
                return;
            }

            Btn_Run.BackgroundImage = Resources.Jugar_n;
        }

        private void Btn_Run_MouseDown(object sender, MouseEventArgs e)
        {
            if (!Btn_Run.Enabled)
            {
                return;
            }

            Btn_Run.BackgroundImage = Resources.Jugar_c;
        }

        private void Btn_Run_MouseUp(object sender, MouseEventArgs e)
        {
            if (!Btn_Run.Enabled)
            {
                return;
            }

            Btn_Run.BackgroundImage = Resources.Jugar_h;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Main));
            Status = new Label();
            Btn_Run = new Button();
            Btn_Quit = new Button();
            Btn_Options = new Button();
            completeProgressText = new Label();
            currentProgressText = new Label();
            completeBar = new PictureBox();
            currentBar = new PictureBox();
            UpdatePanel = new Panel();
            WindowName_txt = new Label();
            webPanel = new WebBrowser();
            ((ISupportInitialize)completeBar).BeginInit();
            ((ISupportInitialize)currentBar).BeginInit();
            UpdatePanel.SuspendLayout();
            SuspendLayout();
            // 
            // Status
            // 
            Status.AutoSize = true;
            Status.BackColor = Color.Transparent;
            Status.Font = new Font("Tahoma", 8.75F);
            Status.ForeColor = Color.White;
            Status.Location = new Point(9, 3);
            Status.Margin = new Padding(0);
            Status.Name = "Status";
            Status.Size = new Size(42, 14);
            Status.TabIndex = 3;
            Status.Text = "Status";
            // 
            // Btn_Run
            // 
            Btn_Run.BackgroundImage = Resources.Jugar_n;
            Btn_Run.BackgroundImageLayout = ImageLayout.Stretch;
            Btn_Run.Cursor = Cursors.Hand;
            Btn_Run.FlatAppearance.BorderSize = 0;
            Btn_Run.FlatStyle = FlatStyle.Flat;
            Btn_Run.Font = new Font("Arial", 12F, FontStyle.Bold);
            Btn_Run.Location = new Point(840, 503);
            Btn_Run.Name = "Btn_Run";
            Btn_Run.Size = new Size(146, 53);
            Btn_Run.TabIndex = 28;
            Btn_Run.UseVisualStyleBackColor = true;
            Btn_Run.Click += new EventHandler(Btn_Run_Click);
            Btn_Run.MouseDown += new MouseEventHandler(Btn_Run_MouseDown);
            Btn_Run.MouseEnter += new EventHandler(Btn_Run_MouseHover);
            Btn_Run.MouseLeave += new EventHandler(Btn_Run_MouseLeave);
            Btn_Run.MouseHover += new EventHandler(Btn_Run_MouseHover);
            Btn_Run.MouseUp += new MouseEventHandler(Btn_Run_MouseUp);
            // 
            // Btn_Quit
            // 
            Btn_Quit.BackgroundImage = Resources.Cerrar_n;
            Btn_Quit.BackgroundImageLayout = ImageLayout.Stretch;
            Btn_Quit.Cursor = Cursors.Hand;
            Btn_Quit.FlatAppearance.BorderSize = 0;
            Btn_Quit.FlatStyle = FlatStyle.Flat;
            Btn_Quit.Font = new Font("Arial", 12F, FontStyle.Bold);
            Btn_Quit.Location = new Point(968, 3);
            Btn_Quit.Name = "Btn_Quit";
            Btn_Quit.Size = new Size(18, 18);
            Btn_Quit.TabIndex = 29;
            Btn_Quit.UseVisualStyleBackColor = true;
            Btn_Quit.Click += new EventHandler(Btn_Quit_Click);
            Btn_Quit.MouseDown += new MouseEventHandler(Btn_Quit_MouseDown);
            Btn_Quit.MouseEnter += new EventHandler(Btn_Quit_MouseHover);
            Btn_Quit.MouseLeave += new EventHandler(Btn_Quit_MouseLeave);
            Btn_Quit.MouseHover += new EventHandler(Btn_Quit_MouseHover);
            Btn_Quit.MouseUp += new MouseEventHandler(Btn_Quit_MouseUp);
            // 
            // Btn_Options
            // 
            Btn_Options.BackgroundImage = Resources.Config_n;
            Btn_Options.BackgroundImageLayout = ImageLayout.Stretch;
            Btn_Options.Cursor = Cursors.Hand;
            Btn_Options.FlatAppearance.BorderSize = 0;
            Btn_Options.FlatStyle = FlatStyle.Flat;
            Btn_Options.Font = new Font("Arial", 12F, FontStyle.Bold);
            Btn_Options.Location = new Point(947, 3);
            Btn_Options.Name = "Btn_Options";
            Btn_Options.Size = new Size(18, 18);
            Btn_Options.TabIndex = 30;
            Btn_Options.UseVisualStyleBackColor = true;
            Btn_Options.Click += new EventHandler(Btn_Options_Click);
            Btn_Options.MouseDown += new MouseEventHandler(Btn_Options_MouseDown);
            Btn_Options.MouseEnter += new EventHandler(Btn_Options_MouseHover);
            Btn_Options.MouseLeave += new EventHandler(Btn_Options_MouseLeave);
            Btn_Options.MouseHover += new EventHandler(Btn_Options_MouseHover);
            Btn_Options.MouseUp += new MouseEventHandler(Btn_Options_MouseUp);
            // 
            // completeProgressText
            // 
            completeProgressText.AutoSize = true;
            completeProgressText.BackColor = Color.Transparent;
            completeProgressText.Font = new Font("Tahoma", 8.75F);
            completeProgressText.ForeColor = Color.White;
            completeProgressText.Location = new Point(667, 18);
            completeProgressText.Margin = new Padding(0);
            completeProgressText.Name = "completeProgressText";
            completeProgressText.Size = new Size(26, 14);
            completeProgressText.TabIndex = 31;
            completeProgressText.Text = "0%";
            // 
            // currentProgressText
            // 
            currentProgressText.AutoSize = true;
            currentProgressText.BackColor = Color.Transparent;
            currentProgressText.Font = new Font("Tahoma", 8.75F);
            currentProgressText.ForeColor = Color.White;
            currentProgressText.Location = new Point(667, 32);
            currentProgressText.Margin = new Padding(0);
            currentProgressText.Name = "currentProgressText";
            currentProgressText.Size = new Size(26, 14);
            currentProgressText.TabIndex = 32;
            currentProgressText.Text = "0%";
            // 
            // completeBar
            // 
            completeBar.BackColor = Color.FromArgb(12, 15, 12);
            completeBar.BackgroundImage = Resources.CompleteProgress;
            completeBar.BackgroundImageLayout = ImageLayout.Stretch;
            completeBar.Location = new Point(12, 21);
            completeBar.Name = "completeBar";
            completeBar.Size = new Size(650, 11);
            completeBar.TabIndex = 35;
            completeBar.TabStop = false;
            // 
            // currentBar
            // 
            currentBar.BackColor = Color.FromArgb(12, 15, 12);
            currentBar.BackgroundImage = Resources.CurrentProgress;
            currentBar.BackgroundImageLayout = ImageLayout.Stretch;
            currentBar.Location = new Point(12, 35);
            currentBar.Name = "currentBar";
            currentBar.Size = new Size(650, 8);
            currentBar.TabIndex = 36;
            currentBar.TabStop = false;
            // 
            // UpdatePanel
            // 
            UpdatePanel.BackColor = Color.Transparent;
            UpdatePanel.Controls.Add(completeBar);
            UpdatePanel.Controls.Add(currentBar);
            UpdatePanel.Controls.Add(Status);
            UpdatePanel.Controls.Add(completeProgressText);
            UpdatePanel.Controls.Add(currentProgressText);
            UpdatePanel.Location = new Point(119, 503);
            UpdatePanel.Name = "UpdatePanel";
            UpdatePanel.Size = new Size(715, 53);
            UpdatePanel.TabIndex = 37;
            // 
            // WindowName_txt
            // 
            WindowName_txt.AutoSize = true;
            WindowName_txt.BackColor = Color.Transparent;
            WindowName_txt.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            WindowName_txt.ForeColor = Color.LightSteelBlue;
            WindowName_txt.Location = new Point(30, 3);
            WindowName_txt.Name = "WindowName_txt";
            WindowName_txt.Size = new Size(86, 14);
            WindowName_txt.TabIndex = 38;
            WindowName_txt.Text = "MU Launcher";
            // 
            // webPanel
            // 
            webPanel.Location = new Point(5, 23);
            webPanel.MinimumSize = new Size(20, 20);
            webPanel.Name = "webPanel";
            webPanel.Size = new Size(980, 475);
            webPanel.TabIndex = 33;
            webPanel.Url = new Uri("", UriKind.Relative);
            webPanel.Visible = false;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 15, 12);
            BackgroundImage = Resources.Background;
            ClientSize = new Size(990, 560);
            Controls.Add(WindowName_txt);
            Controls.Add(UpdatePanel);
            Controls.Add(webPanel);
            Controls.Add(Btn_Options);
            Controls.Add(Btn_Quit);
            Controls.Add(Btn_Run);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$Icon");
            MaximizeBox = false;
            MaximumSize = new Size(990, 560);
            MinimumSize = new Size(990, 560);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Launcher";
            TransparencyKey = Color.FromArgb(12, 15, 12);
            Load += new EventHandler(Main_Load);
            MouseDown += new MouseEventHandler(Main_MouseDown);
            ((ISupportInitialize)completeBar).EndInit();
            ((ISupportInitialize)currentBar).EndInit();
            UpdatePanel.ResumeLayout(false);
            UpdatePanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _ = ReleaseCapture();
                _ = SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
