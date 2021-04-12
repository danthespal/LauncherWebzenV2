using ConfigCreator;
using System;
using System.IO;
using System.Windows.Forms;

namespace GetLauncherInfo
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void SaveClick(object sender, EventArgs e)
        {
            string dir = Environment.CurrentDirectory + "\\Data\\Launcher\\Settings";

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            try
            {
                File.WriteAllText(Path.Combine(dir, ".\\LauncherInfo.bmd"), SecureStringManager.Encrypt(textBoxServerURL.Text + "\r\n" + textBoxPatchlist.Text + "\r\n" + textBoxExe.Text + "\r\n" + textBoxMutex.Text + "\r\n" + textBoxWebPageURL.Text + "\r\n" + textBoxLauncher.Text + "\r\n", "WhyAreYouReadingThis"));
                MessageBox.Show("LauncherInfo.bmd created", "NOTICE");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
