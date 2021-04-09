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
      else
      {
        if (this.language != 2)
          return;
        this.Account_txt.Text = "Usuário";
        this.Language_txt.Text = "Linguagem";
        this.Resolution_txt.Text = "Resolução";
        this.windowMode.Text = "Modo janela";
        this.soundON.Text = "Som";
        this.musicON.Text = "Música";
        this.Volume_txt.Text = "Volume";
        this.Configurations_txt.Text = "Configurações do jogo";
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Options));
      this.panel2 = new Panel();
      this.color1 = new RadioButton();
      this.color2 = new RadioButton();
      this.panel3 = new Panel();
      this.VolumeLevel = new TrackBar();
      this.Volume_txt = new Label();
      this.musicON = new CheckBox();
      this.soundON = new CheckBox();
      this.panel4 = new Panel();
      this.Language_txt = new Label();
      this.LanguageList = new ComboBox();
      this.Btn_Cancel = new Button();
      this.Btn_Save = new Button();
      this.windowMode = new CheckBox();
      this.Account_txt = new Label();
      this.panel1 = new Panel();
      this.Account_Box = new TextBox();
      this.panel5 = new Panel();
      this.Resolution_txt = new Label();
      this.ResolutionList = new ComboBox();
      this.Configurations_txt = new Label();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.VolumeLevel.BeginInit();
      this.panel4.SuspendLayout();
      this.panel1.SuspendLayout();
      this.panel5.SuspendLayout();
      this.SuspendLayout();
      this.panel2.BackColor = System.Drawing.Color.Transparent;
      this.panel2.Controls.Add((Control) this.color1);
      this.panel2.Controls.Add((Control) this.color2);
      this.panel2.Location = new Point(44, 218);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(361, 40);
      this.panel2.TabIndex = 12;
      this.color1.AutoSize = true;
      this.color1.BackColor = System.Drawing.Color.Transparent;
      this.color1.Cursor = Cursors.Hand;
      this.color1.FlatAppearance.BorderSize = 0;
      this.color1.Font = new Font("Tahoma", 9.25f);
      this.color1.ForeColor = System.Drawing.Color.CornflowerBlue;
      this.color1.Location = new Point(18, 9);
      this.color1.Margin = new Padding(0);
      this.color1.Name = "color1";
      this.color1.Size = new Size(131, 20);
      this.color1.TabIndex = 11;
      this.color1.TabStop = true;
      this.color1.Text = "Color Depth 16bits";
      this.color1.UseVisualStyleBackColor = false;
      this.color2.AutoSize = true;
      this.color2.BackColor = System.Drawing.Color.Transparent;
      this.color2.Cursor = Cursors.Hand;
      this.color2.FlatAppearance.BorderSize = 0;
      this.color2.Font = new Font("Tahoma", 9.25f);
      this.color2.ForeColor = System.Drawing.Color.CornflowerBlue;
      this.color2.Location = new Point(185, 9);
      this.color2.Margin = new Padding(0);
      this.color2.Name = "color2";
      this.color2.Size = new Size(131, 20);
      this.color2.TabIndex = 12;
      this.color2.TabStop = true;
      this.color2.Text = "Color Depth 32bits";
      this.color2.UseVisualStyleBackColor = false;
      this.panel3.BackColor = System.Drawing.Color.Transparent;
      this.panel3.Controls.Add((Control) this.VolumeLevel);
      this.panel3.Controls.Add((Control) this.Volume_txt);
      this.panel3.Controls.Add((Control) this.musicON);
      this.panel3.Controls.Add((Control) this.soundON);
      this.panel3.Location = new Point(44, 272);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(361, 68);
      this.panel3.TabIndex = 13;
      this.VolumeLevel.AutoSize = false;
      this.VolumeLevel.BackColor = System.Drawing.Color.Black;
      this.VolumeLevel.Cursor = Cursors.NoMoveHoriz;
      this.VolumeLevel.LargeChange = 1;
      this.VolumeLevel.Location = new Point(177, 31);
      this.VolumeLevel.Maximum = 9;
      this.VolumeLevel.Name = "VolumeLevel";
      this.VolumeLevel.Size = new Size(165, 28);
      this.VolumeLevel.TabIndex = 49;
      this.Volume_txt.AutoSize = true;
      this.Volume_txt.BackColor = System.Drawing.Color.Transparent;
      this.Volume_txt.Font = new Font("Tahoma", 11.25f);
      this.Volume_txt.ForeColor = System.Drawing.Color.CornflowerBlue;
      this.Volume_txt.Location = new Point(17, 37);
      this.Volume_txt.Name = "Volume_txt";
      this.Volume_txt.Size = new Size(94, 18);
      this.Volume_txt.TabIndex = 48;
      this.Volume_txt.Text = "Volume Level";
      this.musicON.AutoSize = true;
      this.musicON.BackgroundImageLayout = ImageLayout.Stretch;
      this.musicON.Cursor = Cursors.Hand;
      this.musicON.Font = new Font("Tahoma", 11.25f);
      this.musicON.ForeColor = System.Drawing.Color.CornflowerBlue;
      this.musicON.Location = new Point(185, 7);
      this.musicON.Margin = new Padding(0);
      this.musicON.Name = "musicON";
      this.musicON.Size = new Size(63, 22);
      this.musicON.TabIndex = 22;
      this.musicON.Text = "Music";
      this.musicON.UseVisualStyleBackColor = true;
      this.soundON.AutoSize = true;
      this.soundON.BackgroundImageLayout = ImageLayout.None;
      this.soundON.Cursor = Cursors.Hand;
      this.soundON.Font = new Font("Tahoma", 11.25f);
      this.soundON.ForeColor = System.Drawing.Color.CornflowerBlue;
      this.soundON.Location = new Point(20, 7);
      this.soundON.Margin = new Padding(0);
      this.soundON.Name = "soundON";
      this.soundON.Size = new Size(67, 22);
      this.soundON.TabIndex = 23;
      this.soundON.Text = "Sound";
      this.soundON.UseVisualStyleBackColor = true;
      this.panel4.BackColor = System.Drawing.Color.Transparent;
      this.panel4.Controls.Add((Control) this.Language_txt);
      this.panel4.Controls.Add((Control) this.LanguageList);
      this.panel4.Location = new Point(44, 92);
      this.panel4.Name = "panel4";
      this.panel4.Size = new Size(361, 33);
      this.panel4.TabIndex = 14;
      this.Language_txt.AutoSize = true;
      this.Language_txt.BackColor = System.Drawing.Color.Transparent;
      this.Language_txt.Font = new Font("Tahoma", 11.25f);
      this.Language_txt.ForeColor = System.Drawing.Color.DarkOrange;
      this.Language_txt.Location = new Point(15, 6);
      this.Language_txt.Name = "Language_txt";
      this.Language_txt.Size = new Size(71, 18);
      this.Language_txt.TabIndex = 45;
      this.Language_txt.Text = "Language";
      this.LanguageList.Cursor = Cursors.Default;
      this.LanguageList.DropDownStyle = ComboBoxStyle.DropDownList;
      this.LanguageList.FormattingEnabled = true;
      this.LanguageList.Location = new Point(185, 5);
      this.LanguageList.Name = "LanguageList";
      this.LanguageList.Size = new Size(150, 21);
      this.LanguageList.TabIndex = 0;
      this.LanguageList.SelectedIndexChanged += new EventHandler(this.LanguageList_SelectedIndexChanged);
      this.Btn_Cancel.BackgroundImage = (Image) Resources.Cerrar_n;
      this.Btn_Cancel.BackgroundImageLayout = ImageLayout.Stretch;
      this.Btn_Cancel.Cursor = Cursors.Hand;
      this.Btn_Cancel.FlatAppearance.BorderSize = 0;
      this.Btn_Cancel.FlatStyle = FlatStyle.Flat;
      this.Btn_Cancel.Location = new Point(426, 2);
      this.Btn_Cancel.Margin = new Padding(0);
      this.Btn_Cancel.Name = "Btn_Cancel";
      this.Btn_Cancel.Size = new Size(18, 18);
      this.Btn_Cancel.TabIndex = 15;
      this.Btn_Cancel.UseVisualStyleBackColor = true;
      this.Btn_Cancel.Click += new EventHandler(this.Btn_Cancel_Click);
      this.Btn_Cancel.MouseDown += new MouseEventHandler(this.Btn_Cancel_MouseDown);
      this.Btn_Cancel.MouseEnter += new EventHandler(this.Btn_Cancel_MouseHover);
      this.Btn_Cancel.MouseLeave += new EventHandler(this.Btn_Cancel_MouseLeave);
      this.Btn_Cancel.MouseHover += new EventHandler(this.Btn_Cancel_MouseHover);
      this.Btn_Cancel.MouseUp += new MouseEventHandler(this.Btn_Cancel_MouseUp);
      this.Btn_Save.BackgroundImage = (Image) Resources.Accept_n;
      this.Btn_Save.BackgroundImageLayout = ImageLayout.Stretch;
      this.Btn_Save.Cursor = Cursors.Hand;
      this.Btn_Save.FlatAppearance.BorderSize = 0;
      this.Btn_Save.FlatStyle = FlatStyle.Flat;
      this.Btn_Save.Location = new Point(170, 412);
      this.Btn_Save.Name = "Btn_Save";
      this.Btn_Save.Size = new Size(108, 43);
      this.Btn_Save.TabIndex = 16;
      this.Btn_Save.UseVisualStyleBackColor = true;
      this.Btn_Save.Click += new EventHandler(this.Btn_Save_Click);
      this.Btn_Save.MouseDown += new MouseEventHandler(this.Btn_Save_MouseDown);
      this.Btn_Save.MouseEnter += new EventHandler(this.Btn_Save_MouseHover);
      this.Btn_Save.MouseLeave += new EventHandler(this.Btn_Save_MouseLeave);
      this.Btn_Save.MouseHover += new EventHandler(this.Btn_Save_MouseHover);
      this.Btn_Save.MouseUp += new MouseEventHandler(this.Btn_Save_MouseUp);
      this.windowMode.AutoSize = true;
      this.windowMode.BackColor = System.Drawing.Color.Transparent;
      this.windowMode.BackgroundImageLayout = ImageLayout.Stretch;
      this.windowMode.Cursor = Cursors.Hand;
      this.windowMode.Font = new Font("Tahoma", 11.25f);
      this.windowMode.ForeColor = System.Drawing.Color.CornflowerBlue;
      this.windowMode.Location = new Point(20, 36);
      this.windowMode.Margin = new Padding(0);
      this.windowMode.Name = "windowMode";
      this.windowMode.Size = new Size(118, 22);
      this.windowMode.TabIndex = 17;
      this.windowMode.Text = "Window Mode";
      this.windowMode.TextAlign = ContentAlignment.MiddleCenter;
      this.windowMode.UseVisualStyleBackColor = false;
      this.Account_txt.AutoSize = true;
      this.Account_txt.BackColor = System.Drawing.Color.Transparent;
      this.Account_txt.Font = new Font("Tahoma", 11.25f);
      this.Account_txt.ForeColor = System.Drawing.Color.DarkOrange;
      this.Account_txt.Location = new Point(17, 7);
      this.Account_txt.Name = "Account_txt";
      this.Account_txt.Size = new Size(60, 18);
      this.Account_txt.TabIndex = 44;
      this.Account_txt.Text = "Account";
      this.panel1.BackColor = System.Drawing.Color.Transparent;
      this.panel1.Controls.Add((Control) this.Account_Box);
      this.panel1.Controls.Add((Control) this.Account_txt);
      this.panel1.Location = new Point(44, 45);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(361, 33);
      this.panel1.TabIndex = 15;
      this.Account_Box.Font = new Font("Microsoft Sans Serif", 10.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Account_Box.Location = new Point(185, 5);
      this.Account_Box.MaxLength = 20;
      this.Account_Box.Name = "Account_Box";
      this.Account_Box.Size = new Size(150, 23);
      this.Account_Box.TabIndex = 45;
      this.panel5.BackColor = System.Drawing.Color.Transparent;
      this.panel5.Controls.Add((Control) this.Resolution_txt);
      this.panel5.Controls.Add((Control) this.ResolutionList);
      this.panel5.Controls.Add((Control) this.windowMode);
      this.panel5.Location = new Point(44, 139);
      this.panel5.Name = "panel5";
      this.panel5.Size = new Size(361, 63);
      this.panel5.TabIndex = 46;
      this.Resolution_txt.AutoSize = true;
      this.Resolution_txt.BackColor = System.Drawing.Color.Transparent;
      this.Resolution_txt.Font = new Font("Tahoma", 11.25f);
      this.Resolution_txt.ForeColor = System.Drawing.Color.DarkOrange;
      this.Resolution_txt.Location = new Point(15, 7);
      this.Resolution_txt.Name = "Resolution_txt";
      this.Resolution_txt.Size = new Size(73, 18);
      this.Resolution_txt.TabIndex = 45;
      this.Resolution_txt.Text = "Resolution";
      this.ResolutionList.Cursor = Cursors.Default;
      this.ResolutionList.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ResolutionList.FormattingEnabled = true;
      this.ResolutionList.Location = new Point(185, 5);
      this.ResolutionList.Name = "ResolutionList";
      this.ResolutionList.Size = new Size(150, 21);
      this.ResolutionList.TabIndex = 0;
      this.Configurations_txt.AutoSize = true;
      this.Configurations_txt.BackColor = System.Drawing.Color.Transparent;
      this.Configurations_txt.Font = new Font("Consolas", 11.25f);
      this.Configurations_txt.ForeColor = System.Drawing.Color.DarkOrange;
      this.Configurations_txt.Location = new Point(116, 372);
      this.Configurations_txt.Name = "Configurations_txt";
      this.Configurations_txt.Size = new Size(216, 18);
      this.Configurations_txt.TabIndex = 47;
      this.Configurations_txt.Text = "Configurations of the game";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImage = (Image) Resources.OptionsBackground;
      this.ClientSize = new Size(446, 461);
      this.Controls.Add((Control) this.Configurations_txt);
      this.Controls.Add((Control) this.panel5);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.Btn_Save);
      this.Controls.Add((Control) this.Btn_Cancel);
      this.Controls.Add((Control) this.panel4);
      this.Controls.Add((Control) this.panel3);
      this.Controls.Add((Control) this.panel2);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = "Options";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Options";
      this.Load += new EventHandler(this.Options_Load);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.VolumeLevel.EndInit();
      this.panel4.ResumeLayout(false);
      this.panel4.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel5.ResumeLayout(false);
      this.panel5.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
