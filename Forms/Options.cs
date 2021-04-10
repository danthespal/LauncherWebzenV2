// Options.cs
// decrypted by Arsenic for KG-Emulator

using LauncherWebzenV2.Properties;
using LauncherWebzenV2.Source;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LauncherWebzenV2.Forms
{
    public class Options : Form
    {
        private int language;
        private IContainer components;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private CheckBox musicON;
        private CheckBox soundON;
        private ComboBox LanguageList;
        private RadioButton color1;
        private RadioButton color2;
        private Button Btn_Cancel;
        private Button Btn_Save;
        private Label Language_txt;
        private CheckBox windowMode;
        private Label Account_txt;
        private Panel panel1;
        private TextBox Account_Box;
        private Panel panel5;
        private Label Resolution_txt;
        private ComboBox ResolutionList;
        private Label Configurations_txt;
        private TrackBar VolumeLevel;
        private Label Volume_txt;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public Options() => this.InitializeComponent();

        private void Options_Load(object sender, EventArgs e)
        {
            this.LanguageList.Items.Clear();
            this.LanguageList.DataSource = (object) new BindingSource((object) Import.Lang, (string) null);
            this.LanguageList.DisplayMember = "Value";
            this.LanguageList.ValueMember = "Key";
            this.ResolutionList.DataSource = (object) new BindingSource((object) Import.Resolution, (string) null);
            this.ResolutionList.DisplayMember = "Value";
            this.ResolutionList.ValueMember = "Key";
            this.LanguageList.SelectedIndex = 0;
            
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Webzen\\Mu\\Config");
          
            if (registryKey == null)
                return;
          
            if (registryKey.GetValue("ID") != null)
                this.Account_Box.Text = registryKey.GetValue("ID").ToString();
          
            if (registryKey.GetValue("LangSelection") != null)
            {
                this.LanguageList.SelectedValue = (object) registryKey.GetValue("LangSelection").ToString();
                Import.LauncherLanguage = this.LanguageList.SelectedIndex;
            }
          
            if (registryKey.GetValue("Resolution") != null)
                this.ResolutionList.SelectedIndex = int.Parse(registryKey.GetValue("Resolution").ToString());
          
            if (registryKey.GetValue("WindowMode") != null)
                this.windowMode.Checked = int.Parse(registryKey.GetValue("WindowMode").ToString()) != 0;
          
            if (registryKey.GetValue("ColorDepth") != null)
            {
                if (int.Parse(registryKey.GetValue("ColorDepth").ToString()) == 0)
                    this.color1.Checked = true;
                else
                    this.color2.Checked = true;
            }
          
            if (registryKey.GetValue("MusicOnOFF") != null)
                this.musicON.Checked = int.Parse(registryKey.GetValue("MusicOnOFF").ToString()) != 0;
          
            if (registryKey.GetValue("SoundOnOFF") != null)
                this.soundON.Checked = int.Parse(registryKey.GetValue("SoundOnOFF").ToString()) != 0;
          
            if (registryKey.GetValue("VolumeLevel") != null)
                this.VolumeLevel.Value = int.Parse(registryKey.GetValue("VolumeLevel").ToString());
          
            registryKey.Close();
        }

        private void LanguageList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.language = this.LanguageList.SelectedIndex;
            this.LanguageChanged();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e) => this.Dispose();

        private void Btn_Cancel_MouseHover(object sender, EventArgs e) => this.Btn_Cancel.BackgroundImage = (Image) Resources.Cerrar_h;

        private void Btn_Cancel_MouseLeave(object sender, EventArgs e) => this.Btn_Cancel.BackgroundImage = (Image) Resources.Cerrar_n;

        private void Btn_Cancel_MouseDown(object sender, MouseEventArgs e) => this.Btn_Cancel.BackgroundImage = (Image) Resources.Cerrar_c;

        private void Btn_Cancel_MouseUp(object sender, MouseEventArgs e) => this.Btn_Cancel.BackgroundImage = (Image) Resources.Cerrar_h;

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            RegistryKey subKey = Registry.CurrentUser.CreateSubKey("Software\\Webzen\\Mu\\Config");
            
            if (subKey != null)
            {
                subKey.SetValue("ID", (object) this.Account_Box.Text.Trim(), RegistryValueKind.String);
                subKey.SetValue("LangSelection", (object) ((KeyValuePair<string, string>) this.LanguageList.SelectedItem).Key, RegistryValueKind.String);
                Import.LauncherLanguage = this.LanguageList.SelectedIndex;
                subKey.SetValue("Resolution", (object) this.ResolutionList.SelectedIndex, RegistryValueKind.DWord);
                subKey.SetValue("WindowMode", (object) (this.windowMode.Checked ? 1 : 0));
                subKey.SetValue("ColorDepth", (object) (this.color1.Checked ? 0 : 1), RegistryValueKind.DWord);
                subKey.SetValue("MusicOnOFF", (object) (this.musicON.Checked ? 1 : 0), RegistryValueKind.DWord);
                subKey.SetValue("SoundOnOFF", (object) (this.soundON.Checked ? 1 : 0), RegistryValueKind.DWord);
                subKey.SetValue("VolumeLevel", (object) this.VolumeLevel.Value, RegistryValueKind.DWord);
                subKey.Close();
                Import.gMain.Status.Text = Texts.ReloadString();
            }
            else
            {
                int num = (int) MessageBox.Show("There was an error saving data!");
            }
            this.Dispose();
        }

        private void Btn_Save_MouseHover(object sender, EventArgs e) => this.Btn_Save.BackgroundImage = (Image) Resources.Accept_h;

        private void Btn_Save_MouseLeave(object sender, EventArgs e) => this.Btn_Save.BackgroundImage = (Image) Resources.Accept_n;

        private void Btn_Save_MouseDown(object sender, MouseEventArgs e) => this.Btn_Save.BackgroundImage = (Image) Resources.Accept_c;

        private void Btn_Save_MouseUp(object sender, MouseEventArgs e) => this.Btn_Save.BackgroundImage = (Image) Resources.Accept_h;

        private void LanguageChanged()
        {
            if (this.language == 0)
            {
                this.Account_txt.Text = "Account";
                this.Language_txt.Text = "Language";
                this.Resolution_txt.Text = "Resolution";
                this.windowMode.Text = "Window Mode";
                this.soundON.Text = "Sound";
                this.musicON.Text = "Music";
                this.Volume_txt.Text = "Volume";
                this.Configurations_txt.Text = "Configurations of the game";
            }
            else if (this.language == 1)
            {
                this.Account_txt.Text = "Usuario";
                this.Language_txt.Text = "Lenguaje";
                this.Resolution_txt.Text = "Resolución";
                this.windowMode.Text = "Modo Ventana";
                this.soundON.Text = "Sonido";
                this.musicON.Text = "Música";
                this.Volume_txt.Text = "Volumen";
                this.Configurations_txt.Text = "Configuraciones del juego";
            }
            else if (this.language != 2)
            {
                this.Account_txt.Text = "Usuário";
                this.Language_txt.Text = "Linguagem";
                this.Resolution_txt.Text = "Resolução";
                this.windowMode.Text = "Modo janela";
                this.soundON.Text = "Som";
                this.musicON.Text = "Música";
                this.Volume_txt.Text = "Volume";
                this.Configurations_txt.Text = "Configurações do jogo";
            }
            return;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.color1 = new System.Windows.Forms.RadioButton();
            this.color2 = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.VolumeLevel = new System.Windows.Forms.TrackBar();
            this.Volume_txt = new System.Windows.Forms.Label();
            this.musicON = new System.Windows.Forms.CheckBox();
            this.soundON = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Language_txt = new System.Windows.Forms.Label();
            this.LanguageList = new System.Windows.Forms.ComboBox();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.windowMode = new System.Windows.Forms.CheckBox();
            this.Account_txt = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Account_Box = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Resolution_txt = new System.Windows.Forms.Label();
            this.ResolutionList = new System.Windows.Forms.ComboBox();
            this.Configurations_txt = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeLevel)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.color1);
            this.panel2.Controls.Add(this.color2);
            this.panel2.Location = new System.Drawing.Point(44, 218);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(361, 40);
            this.panel2.TabIndex = 12;
            // 
            // color1
            // 
            this.color1.AutoSize = true;
            this.color1.BackColor = System.Drawing.Color.Transparent;
            this.color1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.color1.FlatAppearance.BorderSize = 0;
            this.color1.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.color1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.color1.Location = new System.Drawing.Point(18, 9);
            this.color1.Margin = new System.Windows.Forms.Padding(0);
            this.color1.Name = "color1";
            this.color1.Size = new System.Drawing.Size(131, 20);
            this.color1.TabIndex = 11;
            this.color1.TabStop = true;
            this.color1.Text = "Color Depth 16bits";
            this.color1.UseVisualStyleBackColor = false;
            // 
            // color2
            // 
            this.color2.AutoSize = true;
            this.color2.BackColor = System.Drawing.Color.Transparent;
            this.color2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.color2.FlatAppearance.BorderSize = 0;
            this.color2.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.color2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.color2.Location = new System.Drawing.Point(185, 9);
            this.color2.Margin = new System.Windows.Forms.Padding(0);
            this.color2.Name = "color2";
            this.color2.Size = new System.Drawing.Size(131, 20);
            this.color2.TabIndex = 12;
            this.color2.TabStop = true;
            this.color2.Text = "Color Depth 32bits";
            this.color2.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.VolumeLevel);
            this.panel3.Controls.Add(this.Volume_txt);
            this.panel3.Controls.Add(this.musicON);
            this.panel3.Controls.Add(this.soundON);
            this.panel3.Location = new System.Drawing.Point(44, 272);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(361, 68);
            this.panel3.TabIndex = 13;
            // 
            // VolumeLevel
            // 
            this.VolumeLevel.AutoSize = false;
            this.VolumeLevel.BackColor = System.Drawing.Color.Black;
            this.VolumeLevel.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.VolumeLevel.LargeChange = 1;
            this.VolumeLevel.Location = new System.Drawing.Point(177, 31);
            this.VolumeLevel.Maximum = 9;
            this.VolumeLevel.Name = "VolumeLevel";
            this.VolumeLevel.Size = new System.Drawing.Size(165, 28);
            this.VolumeLevel.TabIndex = 49;
            // 
            // Volume_txt
            // 
            this.Volume_txt.AutoSize = true;
            this.Volume_txt.BackColor = System.Drawing.Color.Transparent;
            this.Volume_txt.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.Volume_txt.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.Volume_txt.Location = new System.Drawing.Point(17, 37);
            this.Volume_txt.Name = "Volume_txt";
            this.Volume_txt.Size = new System.Drawing.Size(94, 18);
            this.Volume_txt.TabIndex = 48;
            this.Volume_txt.Text = "Volume Level";
            // 
            // musicON
            // 
            this.musicON.AutoSize = true;
            this.musicON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.musicON.Cursor = System.Windows.Forms.Cursors.Hand;
            this.musicON.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.musicON.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.musicON.Location = new System.Drawing.Point(185, 7);
            this.musicON.Margin = new System.Windows.Forms.Padding(0);
            this.musicON.Name = "musicON";
            this.musicON.Size = new System.Drawing.Size(63, 22);
            this.musicON.TabIndex = 22;
            this.musicON.Text = "Music";
            this.musicON.UseVisualStyleBackColor = true;
            // 
            // soundON
            // 
            this.soundON.AutoSize = true;
            this.soundON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.soundON.Cursor = System.Windows.Forms.Cursors.Hand;
            this.soundON.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.soundON.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.soundON.Location = new System.Drawing.Point(20, 7);
            this.soundON.Margin = new System.Windows.Forms.Padding(0);
            this.soundON.Name = "soundON";
            this.soundON.Size = new System.Drawing.Size(67, 22);
            this.soundON.TabIndex = 23;
            this.soundON.Text = "Sound";
            this.soundON.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.Language_txt);
            this.panel4.Controls.Add(this.LanguageList);
            this.panel4.Location = new System.Drawing.Point(44, 92);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(361, 33);
            this.panel4.TabIndex = 14;
            // 
            // Language_txt
            // 
            this.Language_txt.AutoSize = true;
            this.Language_txt.BackColor = System.Drawing.Color.Transparent;
            this.Language_txt.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.Language_txt.ForeColor = System.Drawing.Color.DarkOrange;
            this.Language_txt.Location = new System.Drawing.Point(15, 6);
            this.Language_txt.Name = "Language_txt";
            this.Language_txt.Size = new System.Drawing.Size(71, 18);
            this.Language_txt.TabIndex = 45;
            this.Language_txt.Text = "Language";
            // 
            // LanguageList
            // 
            this.LanguageList.Cursor = System.Windows.Forms.Cursors.Default;
            this.LanguageList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguageList.FormattingEnabled = true;
            this.LanguageList.Location = new System.Drawing.Point(185, 5);
            this.LanguageList.Name = "LanguageList";
            this.LanguageList.Size = new System.Drawing.Size(150, 21);
            this.LanguageList.TabIndex = 0;
            this.LanguageList.SelectedIndexChanged += new System.EventHandler(this.LanguageList_SelectedIndexChanged);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.BackgroundImage = global::LauncherWebzenV2.Properties.Resources.Cerrar_n;
            this.Btn_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Cancel.FlatAppearance.BorderSize = 0;
            this.Btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Cancel.Location = new System.Drawing.Point(426, 2);
            this.Btn_Cancel.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(18, 18);
            this.Btn_Cancel.TabIndex = 15;
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            this.Btn_Cancel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_Cancel_MouseDown);
            this.Btn_Cancel.MouseEnter += new System.EventHandler(this.Btn_Cancel_MouseHover);
            this.Btn_Cancel.MouseLeave += new System.EventHandler(this.Btn_Cancel_MouseLeave);
            this.Btn_Cancel.MouseHover += new System.EventHandler(this.Btn_Cancel_MouseHover);
            this.Btn_Cancel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_Cancel_MouseUp);
            // 
            // Btn_Save
            // 
            this.Btn_Save.BackgroundImage = global::LauncherWebzenV2.Properties.Resources.Accept_n;
            this.Btn_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Save.FlatAppearance.BorderSize = 0;
            this.Btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Save.Location = new System.Drawing.Point(170, 412);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(108, 43);
            this.Btn_Save.TabIndex = 16;
            this.Btn_Save.UseVisualStyleBackColor = true;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            this.Btn_Save.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_Save_MouseDown);
            this.Btn_Save.MouseEnter += new System.EventHandler(this.Btn_Save_MouseHover);
            this.Btn_Save.MouseLeave += new System.EventHandler(this.Btn_Save_MouseLeave);
            this.Btn_Save.MouseHover += new System.EventHandler(this.Btn_Save_MouseHover);
            this.Btn_Save.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_Save_MouseUp);
            // 
            // windowMode
            // 
            this.windowMode.AutoSize = true;
            this.windowMode.BackColor = System.Drawing.Color.Transparent;
            this.windowMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.windowMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.windowMode.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.windowMode.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.windowMode.Location = new System.Drawing.Point(20, 36);
            this.windowMode.Margin = new System.Windows.Forms.Padding(0);
            this.windowMode.Name = "windowMode";
            this.windowMode.Size = new System.Drawing.Size(118, 22);
            this.windowMode.TabIndex = 17;
            this.windowMode.Text = "Window Mode";
            this.windowMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.windowMode.UseVisualStyleBackColor = false;
            // 
            // Account_txt
            // 
            this.Account_txt.AutoSize = true;
            this.Account_txt.BackColor = System.Drawing.Color.Transparent;
            this.Account_txt.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.Account_txt.ForeColor = System.Drawing.Color.DarkOrange;
            this.Account_txt.Location = new System.Drawing.Point(17, 7);
            this.Account_txt.Name = "Account_txt";
            this.Account_txt.Size = new System.Drawing.Size(60, 18);
            this.Account_txt.TabIndex = 44;
            this.Account_txt.Text = "Account";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.Account_Box);
            this.panel1.Controls.Add(this.Account_txt);
            this.panel1.Location = new System.Drawing.Point(44, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(361, 33);
            this.panel1.TabIndex = 15;
            // 
            // Account_Box
            // 
            this.Account_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Account_Box.Location = new System.Drawing.Point(185, 5);
            this.Account_Box.MaxLength = 20;
            this.Account_Box.Name = "Account_Box";
            this.Account_Box.Size = new System.Drawing.Size(150, 23);
            this.Account_Box.TabIndex = 45;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.Resolution_txt);
            this.panel5.Controls.Add(this.ResolutionList);
            this.panel5.Controls.Add(this.windowMode);
            this.panel5.Location = new System.Drawing.Point(44, 139);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(361, 63);
            this.panel5.TabIndex = 46;
            // 
            // Resolution_txt
            // 
            this.Resolution_txt.AutoSize = true;
            this.Resolution_txt.BackColor = System.Drawing.Color.Transparent;
            this.Resolution_txt.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.Resolution_txt.ForeColor = System.Drawing.Color.DarkOrange;
            this.Resolution_txt.Location = new System.Drawing.Point(15, 7);
            this.Resolution_txt.Name = "Resolution_txt";
            this.Resolution_txt.Size = new System.Drawing.Size(73, 18);
            this.Resolution_txt.TabIndex = 45;
            this.Resolution_txt.Text = "Resolution";
            // 
            // ResolutionList
            // 
            this.ResolutionList.Cursor = System.Windows.Forms.Cursors.Default;
            this.ResolutionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ResolutionList.FormattingEnabled = true;
            this.ResolutionList.Location = new System.Drawing.Point(185, 5);
            this.ResolutionList.Name = "ResolutionList";
            this.ResolutionList.Size = new System.Drawing.Size(150, 21);
            this.ResolutionList.TabIndex = 0;
            // 
            // Configurations_txt
            // 
            this.Configurations_txt.AutoSize = true;
            this.Configurations_txt.BackColor = System.Drawing.Color.Transparent;
            this.Configurations_txt.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.Configurations_txt.ForeColor = System.Drawing.Color.DarkOrange;
            this.Configurations_txt.Location = new System.Drawing.Point(116, 372);
            this.Configurations_txt.Name = "Configurations_txt";
            this.Configurations_txt.Size = new System.Drawing.Size(216, 18);
            this.Configurations_txt.TabIndex = 47;
            this.Configurations_txt.Text = "Configurations of the game";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LauncherWebzenV2.Properties.Resources.OptionsBackground;
            this.ClientSize = new System.Drawing.Size(446, 461);
            this.Controls.Add(this.Configurations_txt);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Options_MouseDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeLevel)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Options_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
