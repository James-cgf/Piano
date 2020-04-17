using CCWin;
using LogicManager;

namespace PinaoUI.Notice {
    public partial class OpenNotice : Skin_DevExpress {
        private static string notice = NoticeALL.noticeText();
        public OpenNotice() {
            InitializeComponent();
            this.label1.Text = notice;
        }
    }
}
