using Cyclic.Redundancy.Check;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Update.Maker
{
    public class Form : System.Windows.Forms.Form
    {
        private string[] Files;
        private readonly IContainer components;
        private Button BrowseButton;
        private ProgressBar Progress;
        private Button saveButton;
        private BackgroundWorker backgroundWorker;
        private FolderBrowserDialog folderBrowserDialog;
        private TextBox TextBox1;
        private Button Button1;
        private SaveFileDialog saveFileDialog;
        private GroupBox Group1;
        private TextBox Results;
        private GroupBox Bar1;

        public Form()
        {
            InitializeComponent();
        }

        private void BrowseButton_click(object sender, EventArgs e)
        {
            _ = Directory.CreateDirectory(".\\\\update");
            StartBrowsing();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveList();
        }

        private void button1_click(object sender, EventArgs e)
        {
            RemoveFromPath(TextBox1.Text);
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Files = GetFiles(e.Argument);
            for (int index = 0; index < Files.Length; ++index)
            {
                backgroundWorker.ReportProgress(index + 1, GetFileData(Files[index]));
            }
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UpdateResult(e.UserState);
            UpdateProgressBar(ComputeProgress(e.ProgressPercentage));
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EnableButtons();
        }

        private void DisableButtons()
        {
            Progress.Value = 0;
            Results.Clear();
            saveButton.Enabled = false;
            Button1.Enabled = false;
            BrowseButton.Enabled = false;
        }

        private void EnableButtons()
        {
            saveButton.Enabled = true;
            Button1.Enabled = true;
            BrowseButton.Enabled = true;
        }

        public string[] GetFiles(object Path)
        {
            return Directory.GetFiles(Path.ToString(), "*.*", SearchOption.AllDirectories);
        }

        public int Length(string[] Files)
        {
            return Files.Length;
        }

        public string GetFileData(string File)
        {
            FileInfo fileInfo = new FileInfo(File);
            return File + ".rar;" + GetHash(File) + ";" + fileInfo.Length;
        }

        private string GetHash(string Name)
        {
            if (Name == string.Empty)
            {
                return null;
            }
            CRC crc = new CRC();
            string empty = string.Empty;
            try
            {
                using (FileStream fileStream = File.Open(Name, FileMode.Open))
                {
                    foreach (byte num in crc.ComputeHash(fileStream))
                    {
                        empty += num.ToString("x2").ToUpper();
                    }
                }
            }
            catch
            {
                _ = (int)MessageBox.Show("Can't open: " + Name);
            }
            return empty;
        }

        private void UpdateResult(object Data)
        {
            if (Results.IsDisposed)
            {
                return;
            }

            string path = Data.ToString().Replace("\\", "/").Split(';')[0].Replace(TextBox1.Text, string.Empty);
            if (path.Contains("/"))
            {
                _ = Directory.CreateDirectory("./update/" + Path.GetDirectoryName(path));
            }
            
            File.Copy(Data.ToString().Replace("\\", "/").Split(';')[0].Replace(".rar", string.Empty), Directory.GetCurrentDirectory() + "/update/" + path, true);
            Results.AppendText(Data.ToString().Replace("\\", "/").Replace(TextBox1.Text, string.Empty) + Environment.NewLine);
        }

        private int ComputeProgress(int Percent)
        {
            return 100 * Percent / Files.Length;
        }

        private void UpdateProgressBar(int Percent)
        {
            if (Percent < 0 || Percent > 100 || Progress.IsDisposed)
            {
                return;
            }
            Progress.Value = Percent;
        }

        private void RemoveFromPath(string Remove)
        {
            if (Remove == string.Empty)
            {
                return;
            }
            Results.Text = Results.Text.Replace(Remove, string.Empty);
            TextBox1.Text = TextBox1.Text.Replace(Remove, string.Empty);
        }

        private void StartBrowsing()
        {
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            
            DisableButtons();
            TextBox1.Text = folderBrowserDialog.SelectedPath.Replace("\\", "/") + "/";
            
            if (backgroundWorker.IsBusy)
            {
                return;
            }
            
            backgroundWorker.RunWorkerAsync(folderBrowserDialog.SelectedPath);
        }

        private void SaveList()
        {
            saveFileDialog.FileName = "update.txt";
            saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + "\\update\\";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|Every file (*.*)|*.*";
            
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            
            using (StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName))
            {
                streamWriter.Write(Results.Text);
            }
        }

        private void ProgressBar_click(object sender, EventArgs e)
        {
        }

        private void TextBox1_changed(object sender, EventArgs e)
        {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.BrowseButton = new System.Windows.Forms.Button();
            this.Progress = new System.Windows.Forms.ProgressBar();
            this.saveButton = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.Button1 = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.Group1 = new System.Windows.Forms.GroupBox();
            this.Bar1 = new System.Windows.Forms.GroupBox();
            this.Results = new System.Windows.Forms.TextBox();
            this.Group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(25, 28);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(154, 47);
            this.BrowseButton.TabIndex = 1;
            this.BrowseButton.Text = "1. Select The Folder";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_click);
            // 
            // Progress
            // 
            this.Progress.BackColor = System.Drawing.SystemColors.Control;
            this.Progress.Location = new System.Drawing.Point(224, 305);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(457, 19);
            this.Progress.TabIndex = 2;
            this.Progress.Click += new System.EventHandler(this.ProgressBar_click);
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(25, 92);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(154, 44);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "2. Save Update List";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(25, 227);
            this.TextBox1.MaxLength = 256;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(154, 20);
            this.TextBox1.TabIndex = 4;
            this.TextBox1.Visible = false;
            this.TextBox1.TextChanged += new System.EventHandler(this.TextBox1_changed);
            // 
            // Button1
            // 
            this.Button1.Enabled = false;
            this.Button1.Location = new System.Drawing.Point(71, 253);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(58, 23);
            this.Button1.TabIndex = 5;
            this.Button1.Text = "Xóa";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Visible = false;
            this.Button1.Click += new System.EventHandler(this.button1_click);
            // 
            // Group1
            // 
            this.Group1.Controls.Add(this.Bar1);
            this.Group1.Controls.Add(this.Results);
            this.Group1.Controls.Add(this.Button1);
            this.Group1.Controls.Add(this.saveButton);
            this.Group1.Controls.Add(this.Progress);
            this.Group1.Controls.Add(this.BrowseButton);
            this.Group1.Controls.Add(this.TextBox1);
            this.Group1.Location = new System.Drawing.Point(15, 5);
            this.Group1.Name = "Group1";
            this.Group1.Size = new System.Drawing.Size(703, 332);
            this.Group1.TabIndex = 100;
            this.Group1.TabStop = false;
            // 
            // Bar1
            // 
            this.Bar1.Location = new System.Drawing.Point(203, 10);
            this.Bar1.Name = "Bar1";
            this.Bar1.Size = new System.Drawing.Size(5, 314);
            this.Bar1.TabIndex = 6;
            this.Bar1.TabStop = false;
            // 
            // Results
            // 
            this.Results.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Results.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Results.Location = new System.Drawing.Point(224, 19);
            this.Results.Multiline = true;
            this.Results.Name = "Results";
            this.Results.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Results.Size = new System.Drawing.Size(473, 280);
            this.Results.TabIndex = 0;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 349);
            this.Controls.Add(this.Group1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(746, 388);
            this.MinimumSize = new System.Drawing.Size(746, 388);
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Generator - KG-Emulator";
            this.Group1.ResumeLayout(false);
            this.Group1.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
