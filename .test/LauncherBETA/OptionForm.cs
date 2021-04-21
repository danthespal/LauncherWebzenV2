using Microsoft.Win32;
using LauncherKG.Source;
using LauncherKG.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LauncherKG
{
    public class OptionForm : Form
    {
        private IContainer components;
        private PictureBox Btn_Accept;
        private PictureBox Btn_Exit;
        private ComboBox F49;
        private ComboBox Language_TextBox;
        private TextBox AccountId_TextBox;
        private CheckBox Sound;
        private CheckBox Music;
        private RadioButton MinColor;
        private RadioButton MaxColor;
        private Label CopyRight;
        private Label AccountId;
        private Label Resolution;
        private Label Language;
        public ComboBox Resolution_TextBox;
        private Label BITS16;
        private Label BITS32;
        private Label sOnOff;
        private Label mOnOff;
        private Label ServerName;
        private Label Msg1;
        private Label Msg2;
        private Label Msg3;
        private Label Msg4;

        public OptionForm()
        {
            this.InitializeComponent();
            this.ServerName.Text = Import.launcherName;
            this.Msg1.Text = "If have problems with Launcher run it in Administrator Mode.";
            this.Msg2.Text = "MU is populated by a large variety of monsters.";
            this.Msg3.Text = "Characters in MU can use many different kinds.";
            this.Msg4.Text = "PTYNetwork.com Contact: arsenicromania@gmail.com";
            if (Import.Stance)
            {
                this.F49.Visible = false;
                this.Resolution_TextBox.Visible = true;
            }
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Webzen\\Mu\\Config");
            if (registryKey != null)
            {
                if (registryKey.GetValue("MusicOnOff") != null && registryKey.GetValue("SoundOnOff") != null && (registryKey.GetValue("Resolution") != null && registryKey.GetValue("ColorDepth") != null) && (registryKey.GetValue("ID") != null && registryKey.GetValue("LangSelection") != null))
                {
                    int num1 = (int) registryKey.GetValue("MusicOnOff");
                    int num2 = (int) registryKey.GetValue("SoundOnOff");
                    int num3 = (int) registryKey.GetValue("Resolution");
                    int num4 = (int) registryKey.GetValue("ColorDepth");
                    string str1 = (string) registryKey.GetValue("ID");
                    string str2 = (string) registryKey.GetValue("LangSelection");
                    if (num1 == 1)
                        this.Music.Checked = true;
                    if (num2 == 1)
                        this.Sound.Checked = true;
                    if (!Import.Stance)
                    {
                        this.AccountId_TextBox.Text = str1;
                        switch (num3)
                        {
                            case 0:
                                this.F49.SelectedIndex = 0;
                                break;
                            case 1:
                                this.F49.SelectedIndex = 0;
                                break;
                            case 2:
                                this.F49.SelectedIndex = 1;
                                break;
                            case 3:
                                this.F49.SelectedIndex = 2;
                                break;
                            case 4:
                                this.F49.SelectedIndex = 3;
                                break;
                            case 5:
                                this.F49.SelectedIndex = 4;
                                break;
                            case 6:
                                this.F49.SelectedIndex = 5;
                                break;
                            case 7:
                                this.F49.SelectedIndex = 6;
                                break;
                        }
                    }
                    else
                    {
                        if (!File.Exists(".\\\\LauncherOption.if"))
                        {
                            try
                            {
                                File.Create(".\\\\LauncherOption.if");
                            }
                            catch
                            {
                            }
                            try
                            {
                                File.WriteAllLines(".\\\\LauncherOption.if", new string[3]
                                {
                                    "DevModeIndex:1",
                                    "WindowMode:1",
                                    "ID:"
                                });
                            }
                            catch
                            {
                            }
                        }
                        try
                        {
                            string[] strArray = File.ReadAllLines(".\\\\LauncherOption.if");
                            switch (strArray[0])
                            {
                                case "DevModeIndex:1":
                                    this.Resolution_TextBox.SelectedIndex = 0;
                                    break;
                                case "DevModeIndex:10":
                                    this.Resolution_TextBox.SelectedIndex = 9;
                                    break;
                                case "DevModeIndex:2":
                                    this.Resolution_TextBox.SelectedIndex = 1;
                                    break;
                                case "DevModeIndex:3":
                                    this.Resolution_TextBox.SelectedIndex = 2;
                                    break;
                                case "DevModeIndex:4":
                                    this.Resolution_TextBox.SelectedIndex = 3;
                                    break;
                                case "DevModeIndex:5":
                                    this.Resolution_TextBox.SelectedIndex = 4;
                                    break;
                                case "DevModeIndex:6":
                                    this.Resolution_TextBox.SelectedIndex = 5;
                                    break;
                                case "DevModeIndex:7":
                                    this.Resolution_TextBox.SelectedIndex = 6;
                                    break;
                                case "DevModeIndex:8":
                                    this.Resolution_TextBox.SelectedIndex = 7;
                                    break;
                                case "DevModeIndex:9":
                                    this.Resolution_TextBox.SelectedIndex = 8;
                                    break;
                            }
                            this.AccountId_TextBox.Text = strArray[2].Remove(0, 3);
                        }
                        catch
                        {
                        }
                    }
                    if (str2 == "Eng")
                        this.Language_TextBox.SelectedIndex = 0;
                    if (str2 == "Spn")
                        this.Language_TextBox.SelectedIndex = 1;
                    if (str2 == "Por")
                        this.Language_TextBox.SelectedIndex = 2;
                    if (num4 == 0)
                        this.MinColor.Checked = true;
                    if (num4 == 1)
                        this.MaxColor.Checked = true;
                }
                else
                {
                    registryKey = Registry.CurrentUser.CreateSubKey("Software\\Webzen\\Mu\\Config");
                    registryKey.CreateSubKey("MusicOnOFF");
                    registryKey.CreateSubKey("SoundOnOFF");
                    registryKey.CreateSubKey("ID");
                    registryKey.CreateSubKey("Resolution");
                    registryKey.CreateSubKey("LangSelection");
                    registryKey.CreateSubKey("ColorDepth");
                    registryKey.SetValue("MusicOnOFF", (object) 0, RegistryValueKind.DWord);
                    registryKey.SetValue("SoundOnOFF", (object) 0, RegistryValueKind.DWord);
                    registryKey.SetValue("ID", (object) "", RegistryValueKind.String);
                    registryKey.SetValue("Resolution", (object) 0, RegistryValueKind.DWord);
                    registryKey.SetValue("LangSelection", (object) "", RegistryValueKind.String);
                    registryKey.SetValue("ColorDepth", (object) 0, RegistryValueKind.DWord);
                }
            }
            else
                registryKey = Registry.CurrentUser.CreateSubKey("Software\\Webzen\\Mu\\Config");
            registryKey.Close();
        }

        private void Btn_Accept_Click(object sender, EventArgs e)
        {
            this.Btn_Accept.Cursor = Cursors.Hand;
            this.DialogResult = DialogResult.OK;
            RegistryKey subKey = Registry.CurrentUser.CreateSubKey("Software\\Webzen\\Mu\\Config");
            if (subKey != null)
            {
                if (this.Music.Checked)
                    subKey.SetValue("MusicOnOFF", (object) 1, RegistryValueKind.DWord);
                else
                    subKey.SetValue("MusicOnOFF", (object) 0, RegistryValueKind.DWord);
                if (this.Sound.Checked)
                    subKey.SetValue("SoundOnOFF", (object) 1, RegistryValueKind.DWord);
                else
                    subKey.SetValue("SoundOnOFF", (object) 0, RegistryValueKind.DWord);
                if (!Import.Stance)
                {
                    if (this.AccountId_TextBox.Text != null)
                        subKey.SetValue("ID", (object) this.AccountId_TextBox.Text, RegistryValueKind.String);
                    else
                        subKey.SetValue("ID", (object) "", RegistryValueKind.String);
                    switch (this.F49.SelectedIndex)
                    {
                        case 0:
                            subKey.SetValue("Resolution", (object) 1, RegistryValueKind.DWord);
                            break;
                        case 1:
                            subKey.SetValue("Resolution", (object) 2, RegistryValueKind.DWord);
                            break;
                        case 2:
                            subKey.SetValue("Resolution", (object) 3, RegistryValueKind.DWord);
                            break;
                        case 3:
                            subKey.SetValue("Resolution", (object) 4, RegistryValueKind.DWord);
                            break;
                        case 4:
                            subKey.SetValue("Resolution", (object) 5, RegistryValueKind.DWord);
                            break;
                        case 5:
                            subKey.SetValue("Resolution", (object) 6, RegistryValueKind.DWord);
                            break;
                        case 6:
                            subKey.SetValue("Resolution", (object) 7, RegistryValueKind.DWord);
                            break;
                        default:
                            subKey.SetValue("Resolution", (object) 1, RegistryValueKind.DWord);
                            break;
                    }
                }
                else
                {
                    string newText = "DevModeIndex:1";
                    if (this.Resolution_TextBox.SelectedIndex != -1)
                        newText = "DevModeIndex:" + (object) (this.Resolution_TextBox.SelectedIndex + 1);
                    string fileName = ".\\\\LauncherOption.if";
                    Common.M109(newText, fileName, 1);
                    Common.M109("ID:" + this.AccountId_TextBox.Text, fileName, 3);
                }
                if (this.MinColor.Checked)
                    subKey.SetValue("ColorDepth", (object) 0, RegistryValueKind.DWord);
                else if (this.MaxColor.Checked)
                    subKey.SetValue("ColorDepth", (object) 1, RegistryValueKind.DWord);
                switch (this.Language_TextBox.SelectedIndex)
                {
                    case 0:
                        subKey.SetValue("LangSelection", (object) "Eng", RegistryValueKind.String);
                        break;
                    case 1:
                        subKey.SetValue("LangSelection", (object) "Spn", RegistryValueKind.String);
                        break;
                    case 2:
                        subKey.SetValue("LangSelection", (object) "Por", RegistryValueKind.String);
                        break;
                    default:
                        subKey.SetValue("LangSelection", (object) "Eng", RegistryValueKind.String);
                        break;
                }
            }
            else
            {
                subKey.CreateSubKey("MusicOnOFF");
                subKey.CreateSubKey("SoundOnOFF");
                subKey.CreateSubKey("ID");
                subKey.CreateSubKey("Resolution");
                subKey.CreateSubKey("LangSelection");
                subKey.CreateSubKey("ColorDepth");
                subKey.SetValue("MusicOnOFF", (object) 0, RegistryValueKind.DWord);
                subKey.SetValue("SoundOnOFF", (object) 0, RegistryValueKind.DWord);
                subKey.SetValue("ID", (object) "", RegistryValueKind.String);
                subKey.SetValue("Resolution", (object) 1, RegistryValueKind.DWord);
                subKey.SetValue("LangSelection", (object) "Eng", RegistryValueKind.String);
                subKey.SetValue("ColorDepth", (object) 0, RegistryValueKind.DWord);
            }
            subKey.Close();
        }

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            this.Btn_Exit.Cursor = Cursors.Hand;
            this.DialogResult = DialogResult.Cancel;
        }

        private void OptionForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            Common.ReleaseCapture();
            Common.SendMessage(this.Handle, 161, 2, 0);
        }

        private void M51(object sender, EventArgs e)
        {
        }

        private void Btn_Exit_MouseDown(object sender, MouseEventArgs e) => this.Btn_Exit.BackgroundImage = (Image) Resources.exit_3;

        private void Btn_Exit_MouseHover(object sender, EventArgs e) => this.Btn_Exit.BackgroundImage = (Image) Resources.exit_2;

        private void Btn_Exit_MouseLeave(object sender, EventArgs e) => this.Btn_Exit.BackgroundImage = (Image) Resources.exit_1;

        private void Btn_Exit_MouseUp(object sender, MouseEventArgs e) => this.Btn_Exit.BackgroundImage = (Image) Resources.exit_1;

        private void Btn_Accept_MouseDown(object sender, MouseEventArgs e) => this.Btn_Accept.BackgroundImage = (Image) Resources.accept_3;

        private void Btn_Accept_MouseHover(object sender, EventArgs e) => this.Btn_Accept.BackgroundImage = (Image) Resources.accept_2;

        private void Btn_Accept_MouseLeave(object sender, EventArgs e) => this.Btn_Accept.BackgroundImage = (Image) Resources.accept_1;

        private void Btn_Accept_MouseUp(object sender, MouseEventArgs e) => this.Btn_Accept.BackgroundImage = (Image) Resources.accept_1;

        private void CopyRight_Click(object sender, EventArgs e) => Process.Start("https://www.ptynetwork.com/");

        protected override void Dispose(bool disposing)
        {
            if ((!disposing ? 0 : (this.components != null ? 1 : 0)) != 0)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.Btn_Accept = new System.Windows.Forms.PictureBox();
            this.Btn_Exit = new System.Windows.Forms.PictureBox();
            this.F49 = new System.Windows.Forms.ComboBox();
            this.Language_TextBox = new System.Windows.Forms.ComboBox();
            this.AccountId_TextBox = new System.Windows.Forms.TextBox();
            this.Sound = new System.Windows.Forms.CheckBox();
            this.Music = new System.Windows.Forms.CheckBox();
            this.MinColor = new System.Windows.Forms.RadioButton();
            this.MaxColor = new System.Windows.Forms.RadioButton();
            this.CopyRight = new System.Windows.Forms.Label();
            this.AccountId = new System.Windows.Forms.Label();
            this.Resolution = new System.Windows.Forms.Label();
            this.Language = new System.Windows.Forms.Label();
            this.Resolution_TextBox = new System.Windows.Forms.ComboBox();
            this.BITS16 = new System.Windows.Forms.Label();
            this.BITS32 = new System.Windows.Forms.Label();
            this.sOnOff = new System.Windows.Forms.Label();
            this.mOnOff = new System.Windows.Forms.Label();
            this.ServerName = new System.Windows.Forms.Label();
            this.Msg1 = new System.Windows.Forms.Label();
            this.Msg2 = new System.Windows.Forms.Label();
            this.Msg3 = new System.Windows.Forms.Label();
            this.Msg4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Accept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Exit)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Accept
            // 
            this.Btn_Accept.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Accept.BackgroundImage = global::LauncherKG.Properties.Resources.accept_1;
            this.Btn_Accept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Accept.Location = new System.Drawing.Point(170, 412);
            this.Btn_Accept.Name = "Btn_Accept";
            this.Btn_Accept.Size = new System.Drawing.Size(108, 43);
            this.Btn_Accept.TabIndex = 11;
            this.Btn_Accept.TabStop = false;
            this.Btn_Accept.Click += new System.EventHandler(this.Btn_Accept_Click);
            this.Btn_Accept.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_Accept_MouseDown);
            this.Btn_Accept.MouseLeave += new System.EventHandler(this.Btn_Accept_MouseLeave);
            this.Btn_Accept.MouseHover += new System.EventHandler(this.Btn_Accept_MouseHover);
            this.Btn_Accept.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_Accept_MouseUp);
            // 
            // Btn_Exit
            // 
            this.Btn_Exit.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Exit.BackgroundImage = global::LauncherKG.Properties.Resources.exit_1;
            this.Btn_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Exit.Location = new System.Drawing.Point(426, 2);
            this.Btn_Exit.Name = "Btn_Exit";
            this.Btn_Exit.Size = new System.Drawing.Size(18, 18);
            this.Btn_Exit.TabIndex = 10;
            this.Btn_Exit.TabStop = false;
            this.Btn_Exit.Click += new System.EventHandler(this.Btn_Exit_Click);
            this.Btn_Exit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_Exit_MouseDown);
            this.Btn_Exit.MouseLeave += new System.EventHandler(this.Btn_Exit_MouseLeave);
            this.Btn_Exit.MouseHover += new System.EventHandler(this.Btn_Exit_MouseHover);
            this.Btn_Exit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_Exit_MouseUp);
            // 
            // F49
            // 
            this.F49.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.F49.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.F49.FormattingEnabled = true;
            this.F49.Items.AddRange(new object[] {
            "1:   800x600   [4:3]",
            "2:  1024x768   [4:3]",
            "3: 1280x1024   [4:3]",
            "4:  1280x800  [16:9]",
            "5:  1360x768 [16:10]",
            "6:  1440x900 [16:10]",
            "7:  1600x900  [16:9]",
            "8: 1680x1050 [16:10]",
            "9: 1920x1080  [16:9]"});
            this.F49.Location = new System.Drawing.Point(193, 130);
            this.F49.Name = "F49";
            this.F49.Size = new System.Drawing.Size(148, 23);
            this.F49.TabIndex = 20;
            // 
            // Language_TextBox
            // 
            this.Language_TextBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Language_TextBox.FormattingEnabled = true;
            this.Language_TextBox.Items.AddRange(new object[] {
            "English",
            "Español",
            "Português"});
            this.Language_TextBox.Location = new System.Drawing.Point(193, 169);
            this.Language_TextBox.Name = "Language_TextBox";
            this.Language_TextBox.Size = new System.Drawing.Size(148, 21);
            this.Language_TextBox.TabIndex = 21;
            // 
            // AccountId_TextBox
            // 
            this.AccountId_TextBox.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountId_TextBox.ForeColor = System.Drawing.Color.Maroon;
            this.AccountId_TextBox.Location = new System.Drawing.Point(193, 89);
            this.AccountId_TextBox.MaxLength = 20;
            this.AccountId_TextBox.Name = "AccountId_TextBox";
            this.AccountId_TextBox.Size = new System.Drawing.Size(148, 26);
            this.AccountId_TextBox.TabIndex = 22;
            // 
            // Sound
            // 
            this.Sound.AutoSize = true;
            this.Sound.BackColor = System.Drawing.Color.Transparent;
            this.Sound.ForeColor = System.Drawing.Color.Chocolate;
            this.Sound.Location = new System.Drawing.Point(105, 243);
            this.Sound.Name = "Sound";
            this.Sound.Size = new System.Drawing.Size(57, 17);
            this.Sound.TabIndex = 23;
            this.Sound.Text = "Sound";
            this.Sound.UseVisualStyleBackColor = false;
            // 
            // Music
            // 
            this.Music.AutoSize = true;
            this.Music.BackColor = System.Drawing.Color.Transparent;
            this.Music.ForeColor = System.Drawing.Color.Chocolate;
            this.Music.Location = new System.Drawing.Point(232, 243);
            this.Music.Name = "Music";
            this.Music.Size = new System.Drawing.Size(54, 17);
            this.Music.TabIndex = 24;
            this.Music.Text = "Music";
            this.Music.UseVisualStyleBackColor = false;
            // 
            // MinColor
            // 
            this.MinColor.AutoSize = true;
            this.MinColor.BackColor = System.Drawing.Color.Transparent;
            this.MinColor.ForeColor = System.Drawing.Color.Chocolate;
            this.MinColor.Location = new System.Drawing.Point(105, 214);
            this.MinColor.Name = "MinColor";
            this.MinColor.Size = new System.Drawing.Size(69, 17);
            this.MinColor.TabIndex = 25;
            this.MinColor.TabStop = true;
            this.MinColor.Text = "Min Color";
            this.MinColor.UseVisualStyleBackColor = false;
            // 
            // MaxColor
            // 
            this.MaxColor.AutoSize = true;
            this.MaxColor.BackColor = System.Drawing.Color.Transparent;
            this.MaxColor.ForeColor = System.Drawing.Color.Chocolate;
            this.MaxColor.Location = new System.Drawing.Point(232, 214);
            this.MaxColor.Name = "MaxColor";
            this.MaxColor.Size = new System.Drawing.Size(72, 17);
            this.MaxColor.TabIndex = 26;
            this.MaxColor.TabStop = true;
            this.MaxColor.Text = "Max Color";
            this.MaxColor.UseVisualStyleBackColor = false;
            this.MaxColor.CheckedChanged += new System.EventHandler(this.M51);
            // 
            // CopyRight
            // 
            this.CopyRight.AutoSize = true;
            this.CopyRight.BackColor = System.Drawing.Color.Transparent;
            this.CopyRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CopyRight.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopyRight.ForeColor = System.Drawing.Color.SeaShell;
            this.CopyRight.Location = new System.Drawing.Point(305, 436);
            this.CopyRight.Name = "CopyRight";
            this.CopyRight.Size = new System.Drawing.Size(102, 13);
            this.CopyRight.TabIndex = 42;
            this.CopyRight.Text = "PTYNetwork.com";
            this.CopyRight.Visible = false;
            this.CopyRight.Click += new System.EventHandler(this.CopyRight_Click);
            // 
            // AccountId
            // 
            this.AccountId.AutoSize = true;
            this.AccountId.BackColor = System.Drawing.Color.Transparent;
            this.AccountId.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.AccountId.ForeColor = System.Drawing.Color.DarkOrange;
            this.AccountId.Location = new System.Drawing.Point(102, 91);
            this.AccountId.Name = "AccountId";
            this.AccountId.Size = new System.Drawing.Size(84, 18);
            this.AccountId.TabIndex = 43;
            this.AccountId.Text = "AccountId :";
            // 
            // Resolution
            // 
            this.Resolution.AutoSize = true;
            this.Resolution.BackColor = System.Drawing.Color.Transparent;
            this.Resolution.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.Resolution.ForeColor = System.Drawing.Color.DarkOrange;
            this.Resolution.Location = new System.Drawing.Point(102, 130);
            this.Resolution.Name = "Resolution";
            this.Resolution.Size = new System.Drawing.Size(83, 18);
            this.Resolution.TabIndex = 44;
            this.Resolution.Text = "Resolution :";
            // 
            // Language
            // 
            this.Language.AutoSize = true;
            this.Language.BackColor = System.Drawing.Color.Transparent;
            this.Language.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.Language.ForeColor = System.Drawing.Color.DarkOrange;
            this.Language.Location = new System.Drawing.Point(102, 169);
            this.Language.Name = "Language";
            this.Language.Size = new System.Drawing.Size(81, 18);
            this.Language.TabIndex = 45;
            this.Language.Text = "Language :";
            // 
            // Resolution_TextBox
            // 
            this.Resolution_TextBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Resolution_TextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Resolution_TextBox.FormattingEnabled = true;
            this.Resolution_TextBox.Items.AddRange(new object[] {
            " 1:  800x600   [4:3]",
            " 2: 1024x768   [4:3]",
            " 3: 1152x864   [4:3]",
            " 4: 1280x720  [16:9]",
            " 5: 1280x800 [16:10]",
            " 6: 1280x960   [4:3]",
            " 7: 1600x900  [16:9]",
            " 8:1680x1050 [16:10]",
            " 9:1920x1080  [16:9]",
            "10: 1440x900 [16:10]"});
            this.Resolution_TextBox.Location = new System.Drawing.Point(193, 130);
            this.Resolution_TextBox.Name = "Resolution_TextBox";
            this.Resolution_TextBox.Size = new System.Drawing.Size(148, 23);
            this.Resolution_TextBox.TabIndex = 46;
            this.Resolution_TextBox.Visible = false;
            // 
            // BITS16
            // 
            this.BITS16.AutoSize = true;
            this.BITS16.BackColor = System.Drawing.Color.Transparent;
            this.BITS16.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.BITS16.ForeColor = System.Drawing.Color.Peru;
            this.BITS16.Location = new System.Drawing.Point(169, 216);
            this.BITS16.Name = "BITS16";
            this.BITS16.Size = new System.Drawing.Size(47, 13);
            this.BITS16.TabIndex = 47;
            this.BITS16.Text = "[16 bits]";
            // 
            // BITS32
            // 
            this.BITS32.AutoSize = true;
            this.BITS32.BackColor = System.Drawing.Color.Transparent;
            this.BITS32.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.BITS32.ForeColor = System.Drawing.Color.Peru;
            this.BITS32.Location = new System.Drawing.Point(299, 216);
            this.BITS32.Name = "BITS32";
            this.BITS32.Size = new System.Drawing.Size(47, 13);
            this.BITS32.TabIndex = 48;
            this.BITS32.Text = "[32 bits]";
            // 
            // sOnOff
            // 
            this.sOnOff.AutoSize = true;
            this.sOnOff.BackColor = System.Drawing.Color.Transparent;
            this.sOnOff.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.sOnOff.ForeColor = System.Drawing.Color.Peru;
            this.sOnOff.Location = new System.Drawing.Point(155, 244);
            this.sOnOff.Name = "sOnOff";
            this.sOnOff.Size = new System.Drawing.Size(61, 13);
            this.sOnOff.TabIndex = 49;
            this.sOnOff.Text = "[On]^[Off]";
            // 
            // mOnOff
            // 
            this.mOnOff.AutoSize = true;
            this.mOnOff.BackColor = System.Drawing.Color.Transparent;
            this.mOnOff.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.mOnOff.ForeColor = System.Drawing.Color.Peru;
            this.mOnOff.Location = new System.Drawing.Point(279, 244);
            this.mOnOff.Name = "mOnOff";
            this.mOnOff.Size = new System.Drawing.Size(61, 13);
            this.mOnOff.TabIndex = 50;
            this.mOnOff.Text = "[On]^[Off]";
            // 
            // ServerName
            // 
            this.ServerName.BackColor = System.Drawing.Color.Transparent;
            this.ServerName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerName.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.ServerName.Location = new System.Drawing.Point(35, 27);
            this.ServerName.Name = "ServerName";
            this.ServerName.Size = new System.Drawing.Size(380, 18);
            this.ServerName.TabIndex = 51;
            this.ServerName.Text = "ServerName";
            this.ServerName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Msg1
            // 
            this.Msg1.BackColor = System.Drawing.Color.Transparent;
            this.Msg1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Msg1.ForeColor = System.Drawing.Color.OliveDrab;
            this.Msg1.Location = new System.Drawing.Point(12, 310);
            this.Msg1.Name = "Msg1";
            this.Msg1.Size = new System.Drawing.Size(422, 18);
            this.Msg1.TabIndex = 52;
            this.Msg1.Text = "Msg1";
            this.Msg1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Msg2
            // 
            this.Msg2.BackColor = System.Drawing.Color.Transparent;
            this.Msg2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Msg2.ForeColor = System.Drawing.Color.OliveDrab;
            this.Msg2.Location = new System.Drawing.Point(12, 330);
            this.Msg2.Name = "Msg2";
            this.Msg2.Size = new System.Drawing.Size(422, 18);
            this.Msg2.TabIndex = 53;
            this.Msg2.Text = "Msg2";
            this.Msg2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Msg3
            // 
            this.Msg3.BackColor = System.Drawing.Color.Transparent;
            this.Msg3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Msg3.ForeColor = System.Drawing.Color.OliveDrab;
            this.Msg3.Location = new System.Drawing.Point(12, 350);
            this.Msg3.Name = "Msg3";
            this.Msg3.Size = new System.Drawing.Size(422, 18);
            this.Msg3.TabIndex = 54;
            this.Msg3.Text = "Msg3";
            this.Msg3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Msg4
            // 
            this.Msg4.BackColor = System.Drawing.Color.Transparent;
            this.Msg4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Msg4.ForeColor = System.Drawing.Color.OliveDrab;
            this.Msg4.Location = new System.Drawing.Point(12, 371);
            this.Msg4.Name = "Msg4";
            this.Msg4.Size = new System.Drawing.Size(422, 18);
            this.Msg4.TabIndex = 55;
            this.Msg4.Text = "Msg4";
            this.Msg4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // OptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LauncherKG.Properties.Resources.setting_back;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(446, 461);
            this.Controls.Add(this.Msg4);
            this.Controls.Add(this.Msg3);
            this.Controls.Add(this.Msg2);
            this.Controls.Add(this.Msg1);
            this.Controls.Add(this.ServerName);
            this.Controls.Add(this.mOnOff);
            this.Controls.Add(this.sOnOff);
            this.Controls.Add(this.BITS32);
            this.Controls.Add(this.BITS16);
            this.Controls.Add(this.Resolution_TextBox);
            this.Controls.Add(this.Language);
            this.Controls.Add(this.Resolution);
            this.Controls.Add(this.AccountId);
            this.Controls.Add(this.CopyRight);
            this.Controls.Add(this.MaxColor);
            this.Controls.Add(this.MinColor);
            this.Controls.Add(this.Music);
            this.Controls.Add(this.Sound);
            this.Controls.Add(this.AccountId_TextBox);
            this.Controls.Add(this.Language_TextBox);
            this.Controls.Add(this.F49);
            this.Controls.Add(this.Btn_Accept);
            this.Controls.Add(this.Btn_Exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Opcoes";
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OptionForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Accept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Exit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
