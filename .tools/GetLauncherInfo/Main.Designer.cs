
namespace GetLauncherInfo
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.LauncherWindowName = new System.Windows.Forms.Label();
            this.ExecutableName = new System.Windows.Forms.Label();
            this.textBoxLauncher = new System.Windows.Forms.TextBox();
            this.textBoxExe = new System.Windows.Forms.TextBox();
            this.textBoxServerURL = new System.Windows.Forms.TextBox();
            this.ServerURL = new System.Windows.Forms.Label();
            this.textBoxWebPageURL = new System.Windows.Forms.TextBox();
            this.WebPanelURL = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxMutex = new System.Windows.Forms.TextBox();
            this.MutexName = new System.Windows.Forms.Label();
            this.textBoxPatchlist = new System.Windows.Forms.TextBox();
            this.PatchlistName = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // LauncherWindowName
            // 
            this.LauncherWindowName.AutoSize = true;
            this.LauncherWindowName.Location = new System.Drawing.Point(12, 20);
            this.LauncherWindowName.Name = "LauncherWindowName";
            this.LauncherWindowName.Size = new System.Drawing.Size(42, 15);
            this.LauncherWindowName.TabIndex = 0;
            this.LauncherWindowName.Text = "Name:";
            this.toolTip.SetToolTip(this.LauncherWindowName, "Launcher Window Name");
            // 
            // ExecutableName
            // 
            this.ExecutableName.AutoSize = true;
            this.ExecutableName.Location = new System.Drawing.Point(12, 49);
            this.ExecutableName.Name = "ExecutableName";
            this.ExecutableName.Size = new System.Drawing.Size(63, 15);
            this.ExecutableName.TabIndex = 1;
            this.ExecutableName.Text = "Exe Name:";
            this.toolTip.SetToolTip(this.ExecutableName, "Name of your executable. Exmaples: \"Main.exe\", \"Play.exe\", \"Game.exe\", etc.");
            // 
            // textBoxLauncher
            // 
            this.textBoxLauncher.Location = new System.Drawing.Point(108, 17);
            this.textBoxLauncher.Name = "textBoxLauncher";
            this.textBoxLauncher.Size = new System.Drawing.Size(176, 23);
            this.textBoxLauncher.TabIndex = 2;
            this.textBoxLauncher.Text = "Launcher";
            // 
            // textBoxExe
            // 
            this.textBoxExe.Location = new System.Drawing.Point(108, 46);
            this.textBoxExe.Name = "textBoxExe";
            this.textBoxExe.Size = new System.Drawing.Size(176, 23);
            this.textBoxExe.TabIndex = 3;
            this.textBoxExe.Text = "main.exe";
            // 
            // textBoxServerURL
            // 
            this.textBoxServerURL.Location = new System.Drawing.Point(108, 133);
            this.textBoxServerURL.Name = "textBoxServerURL";
            this.textBoxServerURL.Size = new System.Drawing.Size(176, 23);
            this.textBoxServerURL.TabIndex = 4;
            this.textBoxServerURL.Text = "http://YOUR_WEBSITE/launcher/update/";
            // 
            // ServerURL
            // 
            this.ServerURL.AutoSize = true;
            this.ServerURL.Location = new System.Drawing.Point(12, 136);
            this.ServerURL.Name = "ServerURL";
            this.ServerURL.Size = new System.Drawing.Size(63, 15);
            this.ServerURL.TabIndex = 5;
            this.ServerURL.Text = "ServerURL:";
            this.toolTip.SetToolTip(this.ServerURL, "URL for the updates. Example: \"http://YOUR_WEBSITE/launcher/updates/\"");
            // 
            // textBoxWebPageURL
            // 
            this.textBoxWebPageURL.Location = new System.Drawing.Point(108, 162);
            this.textBoxWebPageURL.Name = "textBoxWebPageURL";
            this.textBoxWebPageURL.Size = new System.Drawing.Size(176, 23);
            this.textBoxWebPageURL.TabIndex = 6;
            this.textBoxWebPageURL.Text = "http://YOUR_WEBSITE/launcher/";
            // 
            // WebPanelURL
            // 
            this.WebPanelURL.AutoSize = true;
            this.WebPanelURL.Location = new System.Drawing.Point(12, 165);
            this.WebPanelURL.Name = "WebPanelURL";
            this.WebPanelURL.Size = new System.Drawing.Size(81, 15);
            this.WebPanelURL.TabIndex = 7;
            this.WebPanelURL.Text = "WebPageURL:";
            this.toolTip.SetToolTip(this.WebPanelURL, "URL for the Web Panel. Example: \"http://YOUR_WEBSITE/launcher/\"");
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(123, 206);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.SaveClick);
            // 
            // textBoxMutex
            // 
            this.textBoxMutex.Location = new System.Drawing.Point(108, 75);
            this.textBoxMutex.Name = "textBoxMutex";
            this.textBoxMutex.Size = new System.Drawing.Size(176, 23);
            this.textBoxMutex.TabIndex = 9;
            this.textBoxMutex.Text = "Launcher";
            // 
            // MutexName
            // 
            this.MutexName.AutoSize = true;
            this.MutexName.Location = new System.Drawing.Point(12, 78);
            this.MutexName.Name = "MutexName";
            this.MutexName.Size = new System.Drawing.Size(79, 15);
            this.MutexName.TabIndex = 10;
            this.MutexName.Text = "Mutex Name:";
            this.toolTip.SetToolTip(this.MutexName, "Name of the Launcher to block executing main. (You have to put the same name in M" +
        "ainInfo -> LauncherName)");
            // 
            // textBoxPatchlist
            // 
            this.textBoxPatchlist.Location = new System.Drawing.Point(108, 104);
            this.textBoxPatchlist.Name = "textBoxPatchlist";
            this.textBoxPatchlist.Size = new System.Drawing.Size(176, 23);
            this.textBoxPatchlist.TabIndex = 11;
            this.textBoxPatchlist.Text = "update.txt";
            // 
            // PatchlistName
            // 
            this.PatchlistName.AutoSize = true;
            this.PatchlistName.Location = new System.Drawing.Point(12, 108);
            this.PatchlistName.Name = "PatchlistName";
            this.PatchlistName.Size = new System.Drawing.Size(90, 15);
            this.PatchlistName.TabIndex = 12;
            this.PatchlistName.Text = "Patchlist Name:";
            this.toolTip.SetToolTip(this.PatchlistName, "Name of the update file. Example: \"update.txt\"");
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 0;
            this.toolTip.AutoPopDelay = 0;
            this.toolTip.InitialDelay = 0;
            this.toolTip.IsBalloon = true;
            this.toolTip.ReshowDelay = 100;
            this.toolTip.ShowAlways = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 241);
            this.Controls.Add(this.PatchlistName);
            this.Controls.Add(this.textBoxPatchlist);
            this.Controls.Add(this.MutexName);
            this.Controls.Add(this.textBoxMutex);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.WebPanelURL);
            this.Controls.Add(this.textBoxWebPageURL);
            this.Controls.Add(this.ServerURL);
            this.Controls.Add(this.textBoxServerURL);
            this.Controls.Add(this.textBoxExe);
            this.Controls.Add(this.textBoxLauncher);
            this.Controls.Add(this.ExecutableName);
            this.Controls.Add(this.LauncherWindowName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "GetLauncherInfo";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LauncherWindowName;
        private System.Windows.Forms.Label ExecutableName;
        private System.Windows.Forms.TextBox textBoxLauncher;
        private System.Windows.Forms.TextBox textBoxExe;
        private System.Windows.Forms.TextBox textBoxServerURL;
        private System.Windows.Forms.Label ServerURL;
        private System.Windows.Forms.TextBox textBoxWebPageURL;
        private System.Windows.Forms.Label WebPanelURL;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxMutex;
        private System.Windows.Forms.Label MutexName;
        private System.Windows.Forms.TextBox textBoxPatchlist;
        private System.Windows.Forms.Label PatchlistName;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

