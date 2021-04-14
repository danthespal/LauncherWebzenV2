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
using System.Runtime.InteropServices;

namespace LauncherWebzenV2.Forms
{
    public class Options : Form
    {
        private int language;
        private readonly IContainer components;
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

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public Options()
        {
            InitializeComponent();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            LanguageList.Items.Clear();
            LanguageList.DataSource = new BindingSource(Import.Lang, null);
            LanguageList.DisplayMember = "Value";
            LanguageList.ValueMember = "Key";
            ResolutionList.DataSource = new BindingSource(Import.Resolution, null);
            ResolutionList.DisplayMember = "Value";
            ResolutionList.ValueMember = "Key";
            LanguageList.SelectedIndex = 0;
            
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Webzen\\Mu\\Config");
          
            if (registryKey == null)
            {
                return;
            }

            if (registryKey.GetValue("ID") != null)
            {
                Account_Box.Text = registryKey.GetValue("ID").ToString();
            }

            if (registryKey.GetValue("LangSelection") != null)
            {
                LanguageList.SelectedValue = registryKey.GetValue("LangSelection").ToString();
                Import.LauncherLanguage = LanguageList.SelectedIndex;
            }
          
            if (registryKey.GetValue("Resolution") != null)
            {
                ResolutionList.SelectedIndex = int.Parse(registryKey.GetValue("Resolution").ToString());
            }

            if (registryKey.GetValue("WindowMode") != null)
            {
                windowMode.Checked = int.Parse(registryKey.GetValue("WindowMode").ToString()) != 0;
            }

            if (registryKey.GetValue("ColorDepth") != null)
            {
                if (int.Parse(registryKey.GetValue("ColorDepth").ToString()) == 0)
                {
                    color1.Checked = true;
                }
                else
                {
                    color2.Checked = true;
                }
            }
          
            if (registryKey.GetValue("MusicOnOFF") != null)
            {
                musicON.Checked = int.Parse(registryKey.GetValue("MusicOnOFF").ToString()) != 0;
            }
          
            if (registryKey.GetValue("SoundOnOFF") != null)
            {
                soundON.Checked = int.Parse(registryKey.GetValue("SoundOnOFF").ToString()) != 0;
            }
          
            if (registryKey.GetValue("VolumeLevel") != null)
            {
                VolumeLevel.Value = int.Parse(registryKey.GetValue("VolumeLevel").ToString());
            }
          
            registryKey.Close();
        }

        private void LanguageList_SelectedIndexChanged(object sender, EventArgs e)
        {
            language = LanguageList.SelectedIndex;
            LanguageChanged();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void Btn_Cancel_MouseHover(object sender, EventArgs e)
        {
            Btn_Cancel.BackgroundImage = Resources.Cerrar_h;
        }

        private void Btn_Cancel_MouseLeave(object sender, EventArgs e)
        {
            Btn_Cancel.BackgroundImage = Resources.Cerrar_n;
        }

        private void Btn_Cancel_MouseDown(object sender, MouseEventArgs e)
        {
            Btn_Cancel.BackgroundImage = Resources.Cerrar_c;
        }

        private void Btn_Cancel_MouseUp(object sender, MouseEventArgs e)
        {
            Btn_Cancel.BackgroundImage = Resources.Cerrar_h;
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            RegistryKey subKey = Registry.CurrentUser.CreateSubKey("Software\\Webzen\\Mu\\Config");
            
            if (subKey != null)
            {
                subKey.SetValue("ID", Account_Box.Text.Trim(), RegistryValueKind.String);
                subKey.SetValue("LangSelection", ((KeyValuePair<string, string>)LanguageList.SelectedItem).Key, RegistryValueKind.String);
                Import.LauncherLanguage = LanguageList.SelectedIndex;
                subKey.SetValue("Resolution", ResolutionList.SelectedIndex, RegistryValueKind.DWord);
                subKey.SetValue("WindowMode", windowMode.Checked ? 1 : 0);
                subKey.SetValue("ColorDepth", color1.Checked ? 0 : 1, RegistryValueKind.DWord);
                subKey.SetValue("MusicOnOFF", musicON.Checked ? 1 : 0, RegistryValueKind.DWord);
                subKey.SetValue("SoundOnOFF", soundON.Checked ? 1 : 0, RegistryValueKind.DWord);
                subKey.SetValue("VolumeLevel", VolumeLevel.Value, RegistryValueKind.DWord);
                subKey.Close();
                Import.gMain.Status.Text = Texts.ReloadString();
            }
            else
            {
                _ = (int)MessageBox.Show("There was an error saving data!");
            }
            Dispose();
        }

        private void Btn_Save_MouseHover(object sender, EventArgs e)
        {
            Btn_Save.BackgroundImage = Resources.Accept_h;
        }

        private void Btn_Save_MouseLeave(object sender, EventArgs e)
        {
            Btn_Save.BackgroundImage = Resources.Accept_n;
        }

        private void Btn_Save_MouseDown(object sender, MouseEventArgs e)
        {
            Btn_Save.BackgroundImage = Resources.Accept_c;
        }

        private void Btn_Save_MouseUp(object sender, MouseEventArgs e)
        {
            Btn_Save.BackgroundImage = Resources.Accept_h;
        }

        private void LanguageChanged()
        {
            if (language == 0)
            {
                Account_txt.Text = "Account";
                Language_txt.Text = "Language";
                Resolution_txt.Text = "Resolution";
                windowMode.Text = "Window Mode";
                soundON.Text = "Sound";
                musicON.Text = "Music";
                Volume_txt.Text = "Volume";
                Configurations_txt.Text = "Configurations of the game";
            }
            else if (language == 1)
            {
                Account_txt.Text = "Usuario";
                Language_txt.Text = "Lenguaje";
                Resolution_txt.Text = "Resolución";
                windowMode.Text = "Modo Ventana";
                soundON.Text = "Sonido";
                musicON.Text = "Música";
                Volume_txt.Text = "Volumen";
                Configurations_txt.Text = "Configuraciones del juego";
            }
            else if (language != 2)
            {
                Account_txt.Text = "Usuário";
                Language_txt.Text = "Linguagem";
                Resolution_txt.Text = "Resolução";
                windowMode.Text = "Modo janela";
                soundON.Text = "Som";
                musicON.Text = "Música";
                Volume_txt.Text = "Volume";
                Configurations_txt.Text = "Configurações do jogo";
            }
            return;
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Options));
            panel2 = new Panel();
            color1 = new RadioButton();
            color2 = new RadioButton();
            panel3 = new Panel();
            VolumeLevel = new TrackBar();
            Volume_txt = new Label();
            musicON = new CheckBox();
            soundON = new CheckBox();
            panel4 = new Panel();
            Language_txt = new Label();
            LanguageList = new ComboBox();
            Btn_Cancel = new Button();
            Btn_Save = new Button();
            windowMode = new CheckBox();
            Account_txt = new Label();
            panel1 = new Panel();
            Account_Box = new TextBox();
            panel5 = new Panel();
            Resolution_txt = new Label();
            ResolutionList = new ComboBox();
            Configurations_txt = new Label();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((ISupportInitialize)VolumeLevel).BeginInit();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(color1);
            panel2.Controls.Add(color2);
            panel2.Location = new Point(44, 218);
            panel2.Name = "panel2";
            panel2.Size = new Size(361, 40);
            panel2.TabIndex = 12;
            // 
            // color1
            // 
            color1.AutoSize = true;
            color1.BackColor = Color.Transparent;
            color1.Cursor = Cursors.Hand;
            color1.FlatAppearance.BorderSize = 0;
            color1.Font = new Font("Tahoma", 9.25F);
            color1.ForeColor = Color.CornflowerBlue;
            color1.Location = new Point(18, 9);
            color1.Margin = new Padding(0);
            color1.Name = "color1";
            color1.Size = new Size(131, 20);
            color1.TabIndex = 11;
            color1.TabStop = true;
            color1.Text = "Color Depth 16bits";
            color1.UseVisualStyleBackColor = false;
            // 
            // color2
            // 
            color2.AutoSize = true;
            color2.BackColor = Color.Transparent;
            color2.Cursor = Cursors.Hand;
            color2.FlatAppearance.BorderSize = 0;
            color2.Font = new Font("Tahoma", 9.25F);
            color2.ForeColor = Color.CornflowerBlue;
            color2.Location = new Point(185, 9);
            color2.Margin = new Padding(0);
            color2.Name = "color2";
            color2.Size = new Size(131, 20);
            color2.TabIndex = 12;
            color2.TabStop = true;
            color2.Text = "Color Depth 32bits";
            color2.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.Controls.Add(VolumeLevel);
            panel3.Controls.Add(Volume_txt);
            panel3.Controls.Add(musicON);
            panel3.Controls.Add(soundON);
            panel3.Location = new Point(44, 272);
            panel3.Name = "panel3";
            panel3.Size = new Size(361, 68);
            panel3.TabIndex = 13;
            // 
            // VolumeLevel
            // 
            VolumeLevel.AutoSize = false;
            VolumeLevel.BackColor = Color.Black;
            VolumeLevel.Cursor = Cursors.NoMoveHoriz;
            VolumeLevel.LargeChange = 1;
            VolumeLevel.Location = new Point(177, 31);
            VolumeLevel.Maximum = 9;
            VolumeLevel.Name = "VolumeLevel";
            VolumeLevel.Size = new Size(165, 28);
            VolumeLevel.TabIndex = 49;
            // 
            // Volume_txt
            // 
            Volume_txt.AutoSize = true;
            Volume_txt.BackColor = Color.Transparent;
            Volume_txt.Font = new Font("Tahoma", 11.25F);
            Volume_txt.ForeColor = Color.CornflowerBlue;
            Volume_txt.Location = new Point(17, 37);
            Volume_txt.Name = "Volume_txt";
            Volume_txt.Size = new Size(94, 18);
            Volume_txt.TabIndex = 48;
            Volume_txt.Text = "Volume Level";
            // 
            // musicON
            // 
            musicON.AutoSize = true;
            musicON.BackgroundImageLayout = ImageLayout.Stretch;
            musicON.Cursor = Cursors.Hand;
            musicON.Font = new Font("Tahoma", 11.25F);
            musicON.ForeColor = Color.CornflowerBlue;
            musicON.Location = new Point(185, 7);
            musicON.Margin = new Padding(0);
            musicON.Name = "musicON";
            musicON.Size = new Size(63, 22);
            musicON.TabIndex = 22;
            musicON.Text = "Music";
            musicON.UseVisualStyleBackColor = true;
            // 
            // soundON
            // 
            soundON.AutoSize = true;
            soundON.BackgroundImageLayout = ImageLayout.None;
            soundON.Cursor = Cursors.Hand;
            soundON.Font = new Font("Tahoma", 11.25F);
            soundON.ForeColor = Color.CornflowerBlue;
            soundON.Location = new Point(20, 7);
            soundON.Margin = new Padding(0);
            soundON.Name = "soundON";
            soundON.Size = new Size(67, 22);
            soundON.TabIndex = 23;
            soundON.Text = "Sound";
            soundON.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Transparent;
            panel4.Controls.Add(Language_txt);
            panel4.Controls.Add(LanguageList);
            panel4.Location = new Point(44, 92);
            panel4.Name = "panel4";
            panel4.Size = new Size(361, 33);
            panel4.TabIndex = 14;
            // 
            // Language_txt
            // 
            Language_txt.AutoSize = true;
            Language_txt.BackColor = Color.Transparent;
            Language_txt.Font = new Font("Tahoma", 11.25F);
            Language_txt.ForeColor = Color.DarkOrange;
            Language_txt.Location = new Point(15, 6);
            Language_txt.Name = "Language_txt";
            Language_txt.Size = new Size(71, 18);
            Language_txt.TabIndex = 45;
            Language_txt.Text = "Language";
            // 
            // LanguageList
            // 
            LanguageList.Cursor = Cursors.Default;
            LanguageList.DropDownStyle = ComboBoxStyle.DropDownList;
            LanguageList.FormattingEnabled = true;
            LanguageList.Location = new Point(185, 5);
            LanguageList.Name = "LanguageList";
            LanguageList.Size = new Size(150, 21);
            LanguageList.TabIndex = 0;
            LanguageList.SelectedIndexChanged += new EventHandler(LanguageList_SelectedIndexChanged);
            // 
            // Btn_Cancel
            // 
            Btn_Cancel.BackgroundImage = Resources.Cerrar_n;
            Btn_Cancel.BackgroundImageLayout = ImageLayout.Stretch;
            Btn_Cancel.Cursor = Cursors.Hand;
            Btn_Cancel.FlatAppearance.BorderSize = 0;
            Btn_Cancel.FlatStyle = FlatStyle.Flat;
            Btn_Cancel.Location = new Point(426, 2);
            Btn_Cancel.Margin = new Padding(0);
            Btn_Cancel.Name = "Btn_Cancel";
            Btn_Cancel.Size = new Size(18, 18);
            Btn_Cancel.TabIndex = 15;
            Btn_Cancel.UseVisualStyleBackColor = true;
            Btn_Cancel.Click += new EventHandler(Btn_Cancel_Click);
            Btn_Cancel.MouseDown += new MouseEventHandler(Btn_Cancel_MouseDown);
            Btn_Cancel.MouseEnter += new EventHandler(Btn_Cancel_MouseHover);
            Btn_Cancel.MouseLeave += new EventHandler(Btn_Cancel_MouseLeave);
            Btn_Cancel.MouseHover += new EventHandler(Btn_Cancel_MouseHover);
            Btn_Cancel.MouseUp += new MouseEventHandler(Btn_Cancel_MouseUp);
            // 
            // Btn_Save
            // 
            Btn_Save.BackgroundImage = Resources.Accept_n;
            Btn_Save.BackgroundImageLayout = ImageLayout.Stretch;
            Btn_Save.Cursor = Cursors.Hand;
            Btn_Save.FlatAppearance.BorderSize = 0;
            Btn_Save.FlatStyle = FlatStyle.Flat;
            Btn_Save.Location = new Point(170, 412);
            Btn_Save.Name = "Btn_Save";
            Btn_Save.Size = new Size(108, 43);
            Btn_Save.TabIndex = 16;
            Btn_Save.UseVisualStyleBackColor = true;
            Btn_Save.Click += new EventHandler(Btn_Save_Click);
            Btn_Save.MouseDown += new MouseEventHandler(Btn_Save_MouseDown);
            Btn_Save.MouseEnter += new EventHandler(Btn_Save_MouseHover);
            Btn_Save.MouseLeave += new EventHandler(Btn_Save_MouseLeave);
            Btn_Save.MouseHover += new EventHandler(Btn_Save_MouseHover);
            Btn_Save.MouseUp += new MouseEventHandler(Btn_Save_MouseUp);
            // 
            // windowMode
            // 
            windowMode.AutoSize = true;
            windowMode.BackColor = Color.Transparent;
            windowMode.BackgroundImageLayout = ImageLayout.Stretch;
            windowMode.Cursor = Cursors.Hand;
            windowMode.Font = new Font("Tahoma", 11.25F);
            windowMode.ForeColor = Color.CornflowerBlue;
            windowMode.Location = new Point(20, 36);
            windowMode.Margin = new Padding(0);
            windowMode.Name = "windowMode";
            windowMode.Size = new Size(118, 22);
            windowMode.TabIndex = 17;
            windowMode.Text = "Window Mode";
            windowMode.TextAlign = ContentAlignment.MiddleCenter;
            windowMode.UseVisualStyleBackColor = false;
            // 
            // Account_txt
            // 
            Account_txt.AutoSize = true;
            Account_txt.BackColor = Color.Transparent;
            Account_txt.Font = new Font("Tahoma", 11.25F);
            Account_txt.ForeColor = Color.DarkOrange;
            Account_txt.Location = new Point(17, 7);
            Account_txt.Name = "Account_txt";
            Account_txt.Size = new Size(60, 18);
            Account_txt.TabIndex = 44;
            Account_txt.Text = "Account";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(Account_Box);
            panel1.Controls.Add(Account_txt);
            panel1.Location = new Point(44, 45);
            panel1.Name = "panel1";
            panel1.Size = new Size(361, 33);
            panel1.TabIndex = 15;
            // 
            // Account_Box
            // 
            Account_Box.Font = new Font("Microsoft Sans Serif", 10.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Account_Box.Location = new Point(185, 5);
            Account_Box.MaxLength = 20;
            Account_Box.Name = "Account_Box";
            Account_Box.Size = new Size(150, 23);
            Account_Box.TabIndex = 45;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Transparent;
            panel5.Controls.Add(Resolution_txt);
            panel5.Controls.Add(ResolutionList);
            panel5.Controls.Add(windowMode);
            panel5.Location = new Point(44, 139);
            panel5.Name = "panel5";
            panel5.Size = new Size(361, 63);
            panel5.TabIndex = 46;
            // 
            // Resolution_txt
            // 
            Resolution_txt.AutoSize = true;
            Resolution_txt.BackColor = Color.Transparent;
            Resolution_txt.Font = new Font("Tahoma", 11.25F);
            Resolution_txt.ForeColor = Color.DarkOrange;
            Resolution_txt.Location = new Point(15, 7);
            Resolution_txt.Name = "Resolution_txt";
            Resolution_txt.Size = new Size(73, 18);
            Resolution_txt.TabIndex = 45;
            Resolution_txt.Text = "Resolution";
            // 
            // ResolutionList
            // 
            ResolutionList.Cursor = Cursors.Default;
            ResolutionList.DropDownStyle = ComboBoxStyle.DropDownList;
            ResolutionList.FormattingEnabled = true;
            ResolutionList.Location = new Point(185, 5);
            ResolutionList.Name = "ResolutionList";
            ResolutionList.Size = new Size(150, 21);
            ResolutionList.TabIndex = 0;
            // 
            // Configurations_txt
            // 
            Configurations_txt.AutoSize = true;
            Configurations_txt.BackColor = Color.Transparent;
            Configurations_txt.Font = new Font("Consolas", 11.25F);
            Configurations_txt.ForeColor = Color.DarkOrange;
            Configurations_txt.Location = new Point(116, 372);
            Configurations_txt.Name = "Configurations_txt";
            Configurations_txt.Size = new Size(216, 18);
            Configurations_txt.TabIndex = 47;
            Configurations_txt.Text = "Configurations of the game";
            // 
            // Options
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Resources.OptionsBackground;
            ClientSize = new Size(446, 461);
            Controls.Add(Configurations_txt);
            Controls.Add(panel5);
            Controls.Add(panel1);
            Controls.Add(Btn_Save);
            Controls.Add(Btn_Cancel);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$Icon");
            Name = "Options";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Options";
            Load += new EventHandler(Options_Load);
            MouseDown += new MouseEventHandler(Options_MouseDown);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((ISupportInitialize)VolumeLevel).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        private void Options_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _ = ReleaseCapture();
                _ = SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
