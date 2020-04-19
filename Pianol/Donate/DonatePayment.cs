using CCWin;
using System;
using System.Drawing;

namespace PinaoUI.Donate {
    public partial class DonacePayment : Skin_DevExpress {
        private static string tx_banner = "捐献备注您的ID或者昵称，转账姓名：**辉";
        private char[] char_banner = tx_banner.ToCharArray();
        private string _text_ = "";
        private int index = 0;
        private int index_ = 0;
        private int index_color = 0;
        private Color[] color = new Color[] { Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Cyan, Color.Blue, Color.Violet };
        public DonacePayment(int id) {
            InitializeComponent();
        }

        private void tm_banner_Tick(object sender, EventArgs e) {
            if (index == tx_banner.Length) {
                index_++;
                _text_ = "";
                if (index_ > 16) {
                    index = 0;
                    index_ = 0;
                    this.label2.ForeColor = Color.Black;
                } else {
                    this.label2.ForeColor = color[index_color];
                    index_color++;
                    if (index_color == color.Length - 1) {
                        index_color = 0;
                    }
                    if (this.label2.Text.IndexOf('|') == char_banner.Length) {
                        this.label2.Text = this.label2.Text.Substring(0, char_banner.Length);
                    } else {
                        this.label2.Text += '|';
                    }
                }
            } else {
                _text_ += char_banner[index];
                index++;
                this.label2.Text = _text_ + '|';
            }
        }
    }
}
