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
        private IContainer components;
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

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();

        public Main()
        {
            this.InitializeComponent();
            Import.gMain = this;
            Protect.ReadInfo();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Text = Import.windowName;
            this.WindowName_txt.Text = Import.windowName;
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
                this.webPanel.Visible = true;
                this.webPanel.Navigate(Import.webPanelURL);
            }
            this.Status.Text = Texts.ReloadString();
        }

        private void Btn_Quit_Click(object sender, EventArgs e) => this.Dispose();

        private void Btn_Quit_MouseHover(object sender, EventArgs e) => this.Btn_Quit.BackgroundImage = (Image)Resources.Cerrar_h;

        private void Btn_Quit_MouseLeave(object sender, EventArgs e) => this.Btn_Quit.BackgroundImage = (Image)Resources.Cerrar_n;

        private void Btn_Quit_MouseDown(object sender, MouseEventArgs e) => this.Btn_Quit.BackgroundImage = (Image)Resources.Cerrar_c;

        private void Btn_Quit_MouseUp(object sender, MouseEventArgs e) => this.Btn_Quit.BackgroundImage = (Image)Resources.Cerrar_h;

        private void Btn_Options_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.5;
            Options options = new Options();
            int num = (int) options.ShowDialog();
            options.Dispose();
            this.Opacity = 1.0;
        }

        private void Btn_Options_MouseHover(object sender, EventArgs e) => this.Btn_Options.BackgroundImage = (Image)Resources.Config_h;

        private void Btn_Options_MouseLeave(object sender, EventArgs e) => this.Btn_Options.BackgroundImage = (Image)Resources.Config_n;

        private void Btn_Options_MouseDown(object sender, MouseEventArgs e) => this.Btn_Options.BackgroundImage = (Image)Resources.Config_c;

        private void Btn_Options_MouseUp(object sender, MouseEventArgs e) => this.Btn_Options.BackgroundImage = (Image)Resources.Config_h;

        private void Btn_Run_Click(object sender, EventArgs e)
        {
            if (!this.Btn_Run.Enabled)
                return;
            ListDownloader.DownloadList();
        }

        private void Btn_Run_MouseHover(object sender, EventArgs e)
        {
            if (!this.Btn_Run.Enabled)
                return;
            this.Btn_Run.BackgroundImage = (Image)Resources.Jugar_h;
        }

        private void Btn_Run_MouseLeave(object sender, EventArgs e)
        {
            if (!this.Btn_Run.Enabled)
                return;
            this.Btn_Run.BackgroundImage = (Image)Resources.Jugar_n;
        }

        private void Btn_Run_MouseDown(object sender, MouseEventArgs e)
        {
            if (!this.Btn_Run.Enabled)
                return;
            this.Btn_Run.BackgroundImage = (Image)Resources.Jugar_c;
        }

        private void Btn_Run_MouseUp(object sender, MouseEventArgs e)
        {
            if (!this.Btn_Run.Enabled)
                return;
            this.Btn_Run.BackgroundImage = (Image)Resources.Jugar_h;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.Status = new System.Windows.Forms.Label();
            this.Btn_Run = new System.Windows.Forms.Button();
            this.Btn_Quit = new System.Windows.Forms.Button();
            this.Btn_Options = new System.Windows.Forms.Button();
            this.completeProgressText = new System.Windows.Forms.Label();
            this.currentProgressText = new System.Windows.Forms.Label();
            this.completeBar = new System.Windows.Forms.PictureBox();
            this.currentBar = new System.Windows.Forms.PictureBox();
            this.UpdatePanel = new System.Windows.Forms.Panel();
            this.WindowName_txt = new System.Windows.Forms.Label();
            this.webPanel = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.completeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentBar)).BeginInit();
            this.UpdatePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.BackColor = System.Drawing.Color.Transparent;
            this.Status.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.Status.ForeColor = System.Drawing.Color.White;
            this.Status.Location = new System.Drawing.Point(9, 3);
            this.Status.Margin = new System.Windows.Forms.Padding(0);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(42, 14);
            this.Status.TabIndex = 3;
            this.Status.Text = "Status";
            // 
            // Btn_Run
            // 
            this.Btn_Run.BackgroundImage = global::LauncherWebzenV2.Properties.Resources.Jugar_n;
            this.Btn_Run.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Run.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Run.FlatAppearance.BorderSize = 0;
            this.Btn_Run.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Run.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.Btn_Run.Location = new System.Drawing.Point(840, 503);
            this.Btn_Run.Name = "Btn_Run";
            this.Btn_Run.Size = new System.Drawing.Size(146, 53);
            this.Btn_Run.TabIndex = 28;
            this.Btn_Run.UseVisualStyleBackColor = true;
            this.Btn_Run.Click += new System.EventHandler(this.Btn_Run_Click);
            this.Btn_Run.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_Run_MouseDown);
            this.Btn_Run.MouseEnter += new System.EventHandler(this.Btn_Run_MouseHover);
            this.Btn_Run.MouseLeave += new System.EventHandler(this.Btn_Run_MouseLeave);
            this.Btn_Run.MouseHover += new System.EventHandler(this.Btn_Run_MouseHover);
            this.Btn_Run.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_Run_MouseUp);
            // 
            // Btn_Quit
            // 
            this.Btn_Quit.BackgroundImage = global::LauncherWebzenV2.Properties.Resources.Cerrar_n;
            this.Btn_Quit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Quit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Quit.FlatAppearance.BorderSize = 0;
            this.Btn_Quit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Quit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.Btn_Quit.Location = new System.Drawing.Point(968, 3);
            this.Btn_Quit.Name = "Btn_Quit";
            this.Btn_Quit.Size = new System.Drawing.Size(18, 18);
            this.Btn_Quit.TabIndex = 29;
            this.Btn_Quit.UseVisualStyleBackColor = true;
            this.Btn_Quit.Click += new System.EventHandler(this.Btn_Quit_Click);
            this.Btn_Quit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_Quit_MouseDown);
            this.Btn_Quit.MouseEnter += new System.EventHandler(this.Btn_Quit_MouseHover);
            this.Btn_Quit.MouseLeave += new System.EventHandler(this.Btn_Quit_MouseLeave);
            this.Btn_Quit.MouseHover += new System.EventHandler(this.Btn_Quit_MouseHover);
            this.Btn_Quit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_Quit_MouseUp);
            // 
            // Btn_Options
            // 
            this.Btn_Options.BackgroundImage = global::LauncherWebzenV2.Properties.Resources.Config_n;
            this.Btn_Options.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Options.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Options.FlatAppearance.BorderSize = 0;
            this.Btn_Options.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Options.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.Btn_Options.Location = new System.Drawing.Point(947, 3);
            this.Btn_Options.Name = "Btn_Options";
            this.Btn_Options.Size = new System.Drawing.Size(18, 18);
            this.Btn_Options.TabIndex = 30;
            this.Btn_Options.UseVisualStyleBackColor = true;
            this.Btn_Options.Click += new System.EventHandler(this.Btn_Options_Click);
            this.Btn_Options.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_Options_MouseDown);
            this.Btn_Options.MouseEnter += new System.EventHandler(this.Btn_Options_MouseHover);
            this.Btn_Options.MouseLeave += new System.EventHandler(this.Btn_Options_MouseLeave);
            this.Btn_Options.MouseHover += new System.EventHandler(this.Btn_Options_MouseHover);
            this.Btn_Options.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_Options_MouseUp);
            // 
            // completeProgressText
            // 
            this.completeProgressText.AutoSize = true;
            this.completeProgressText.BackColor = System.Drawing.Color.Transparent;
            this.completeProgressText.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.completeProgressText.ForeColor = System.Drawing.Color.White;
            this.completeProgressText.Location = new System.Drawing.Point(667, 18);
            this.completeProgressText.Margin = new System.Windows.Forms.Padding(0);
            this.completeProgressText.Name = "completeProgressText";
            this.completeProgressText.Size = new System.Drawing.Size(26, 14);
            this.completeProgressText.TabIndex = 31;
            this.completeProgressText.Text = "0%";
            // 
            // currentProgressText
            // 
            this.currentProgressText.AutoSize = true;
            this.currentProgressText.BackColor = System.Drawing.Color.Transparent;
            this.currentProgressText.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.currentProgressText.ForeColor = System.Drawing.Color.White;
            this.currentProgressText.Location = new System.Drawing.Point(667, 32);
            this.currentProgressText.Margin = new System.Windows.Forms.Padding(0);
            this.currentProgressText.Name = "currentProgressText";
            this.currentProgressText.Size = new System.Drawing.Size(26, 14);
            this.currentProgressText.TabIndex = 32;
            this.currentProgressText.Text = "0%";
            // 
            // completeBar
            // 
            this.completeBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(15)))), ((int)(((byte)(12)))));
            this.completeBar.BackgroundImage = global::LauncherWebzenV2.Properties.Resources.CompleteProgress;
            this.completeBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.completeBar.Location = new System.Drawing.Point(12, 21);
            this.completeBar.Name = "completeBar";
            this.completeBar.Size = new System.Drawing.Size(650, 11);
            this.completeBar.TabIndex = 35;
            this.completeBar.TabStop = false;
            // 
            // currentBar
            // 
            this.currentBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(15)))), ((int)(((byte)(12)))));
            this.currentBar.BackgroundImage = global::LauncherWebzenV2.Properties.Resources.CurrentProgress;
            this.currentBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.currentBar.Location = new System.Drawing.Point(12, 35);
            this.currentBar.Name = "currentBar";
            this.currentBar.Size = new System.Drawing.Size(650, 8);
            this.currentBar.TabIndex = 36;
            this.currentBar.TabStop = false;
            // 
            // UpdatePanel
            // 
            this.UpdatePanel.BackColor = System.Drawing.Color.Transparent;
            this.UpdatePanel.Controls.Add(this.completeBar);
            this.UpdatePanel.Controls.Add(this.currentBar);
            this.UpdatePanel.Controls.Add(this.Status);
            this.UpdatePanel.Controls.Add(this.completeProgressText);
            this.UpdatePanel.Controls.Add(this.currentProgressText);
            this.UpdatePanel.Location = new System.Drawing.Point(119, 503);
            this.UpdatePanel.Name = "UpdatePanel";
            this.UpdatePanel.Size = new System.Drawing.Size(715, 53);
            this.UpdatePanel.TabIndex = 37;
            // 
            // WindowName_txt
            // 
            this.WindowName_txt.AutoSize = true;
            this.WindowName_txt.BackColor = System.Drawing.Color.Transparent;
            this.WindowName_txt.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WindowName_txt.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.WindowName_txt.Location = new System.Drawing.Point(30, 3);
            this.WindowName_txt.Name = "WindowName_txt";
            this.WindowName_txt.Size = new System.Drawing.Size(86, 14);
            this.WindowName_txt.TabIndex = 38;
            this.WindowName_txt.Text = "MU Launcher";
            // 
            // webPanel
            // 
            this.webPanel.Location = new System.Drawing.Point(5, 23);
            this.webPanel.MinimumSize = new System.Drawing.Size(20, 20);
            this.webPanel.Name = "webPanel";
            this.webPanel.Size = new System.Drawing.Size(980, 475);
            this.webPanel.TabIndex = 33;
            this.webPanel.Url = new System.Uri("", System.UriKind.Relative);
            this.webPanel.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(15)))), ((int)(((byte)(12)))));
            this.BackgroundImage = global::LauncherWebzenV2.Properties.Resources.Background;
            this.ClientSize = new System.Drawing.Size(990, 560);
            this.Controls.Add(this.WindowName_txt);
            this.Controls.Add(this.UpdatePanel);
            this.Controls.Add(this.webPanel);
            this.Controls.Add(this.Btn_Options);
            this.Controls.Add(this.Btn_Quit);
            this.Controls.Add(this.Btn_Run);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(990, 560);
            this.MinimumSize = new System.Drawing.Size(990, 560);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher - decrypted by Arsenic";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(15)))), ((int)(((byte)(12)))));
            this.Load += new System.EventHandler(this.Main_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.completeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentBar)).EndInit();
            this.UpdatePanel.ResumeLayout(false);
            this.UpdatePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
