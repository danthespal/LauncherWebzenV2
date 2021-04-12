using ConfigCreator;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetLauncherInfo
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void textBoxServerURL_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaveClick(object sender, EventArgs e)
        {
            string ServerURL = textBoxServerURL.Text;
            string PatchList = textBoxPatchlist.Text;
            string Exe = textBoxExe.Text;
            string Mutex = textBoxMutex.Text;
            string WebPageURL = textBoxWebPageURL.Text;
            string Launcher = textBoxLauncher.Text;

            try
            {
                File.WriteAllText(Environment.CurrentDirectory + "\\LauncherInfo.bmd", SecureStringManager.Encrypt(ServerURL + "\r\n" + PatchList + "\r\n" + Exe + "\r\n" + Mutex + "\r\n" + WebPageURL + "\r\n" + Launcher + "\r\n", "WhyAreYouReadingThis"));
                MessageBox.Show("LauncherInfo.bmd created", "NOTICE");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
