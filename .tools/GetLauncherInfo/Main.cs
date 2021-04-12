using ConfigCreator;
using System;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GetLauncherInfo
{
    public partial class Main : Form
    {
        public static string LauncherInfo = ".\\Data\\Launcher\\Settings\\LauncherInfo.bmd";

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

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                string[] strArray = System.IO.File.Exists(LauncherInfo) ? Regex.Split(SecureStringManager.Decrypt(System.IO.File.ReadAllText(LauncherInfo), "WhyAreYouReadingThis"), "\r\n") : throw new Exception();
                textBoxServerURL.Text = strArray[0];
                textBoxPatchlist.Text = strArray[1];
                textBoxExe.Text = strArray[2];
                textBoxMutex.Text = strArray[3];
                textBoxWebPageURL.Text = strArray[4];
                textBoxLauncher.Text = strArray[5];
            }
            catch
            {
            }
        }
    }
}
