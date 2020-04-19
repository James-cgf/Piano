using AccessService;
using CCWin;
using System;

namespace PinaoUI.Login {
    public partial class AboutUser : Skin_DevExpress {
        string nickName;
        string logonTime;

        public AboutUser() {
            InitializeComponent();
        }

        public AboutUser(string nickName, string logonTime) {
            InitializeComponent();
            this.nickName = nickName;
            this.logonTime = logonTime;
        }

        private void AboutUser_Load(object sender, EventArgs e) {
            if (SqlMain.aboutUser(nickName, logonTime)) {
                System.IO.FileStream fs = new System.IO.FileStream("AboutUser.html", System.IO.FileMode.Open);
                this.webBrowser1.Url = new Uri(fs.Name);
                fs.Close();
            } else {
                this.label1.Visible = true;
            }
        }
    }
}
