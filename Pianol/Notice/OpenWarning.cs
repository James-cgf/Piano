using CCWin;
using System;

namespace PinaoUI.Notice {
    public partial class OpenWarning : Skin_DevExpress {
        public OpenWarning() {
            InitializeComponent();
        }

        private void OpenNotice_Load(object sender, EventArgs e) {
            this.webBrowser1.Url = new Uri("http://www.adminznh.ren/PianoNotice/PianoOpenNotice.html");
            System.Threading.Thread.Sleep(3000);
        }
    }
}
