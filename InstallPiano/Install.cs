using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using IWshRuntimeLibrary;

namespace InstallPiano {
    public partial class Install : Form {

        public Install() {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void Install_Load(object sender, EventArgs e) {
            InstallMain ma = new InstallMain();
            ma.TopLevel = false;
            panel1.Controls.Add(ma);
            ma.Show();
            InstallYes yes = new InstallYes();
            yes.TopLevel = false;
            panel1.Controls.Add(yes);
            yes.Show();
        }
    }
}
