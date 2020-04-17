using LogicManager;
using Middleware;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PinaoUI.Login {
    public partial class ForgetPwd : Form {
        private Label[] tb = new Label[4];
        private string code = "";
        public ForgetPwd() {
            InitializeComponent();
            tb[0] = v1;
            tb[1] = v2;
            tb[2] = v3;
            tb[3] = v4;
        }

        private void timer1_Tick(object sender, EventArgs e) {
            if (this.Opacity >= 0.025) {
                this.Opacity -= 0.025;
            } else {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            timer1.Start();
        }

        private void Go_Click(object sender, EventArgs e) {
            this.Go.Cursor = System.Windows.Forms.Cursors.AppStarting;
            if (!tbNewPassword.Text.Equals(textBox1.Text)) {
                MessageBox.Show("两次密码输入不一致", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                tbNewPassword.Focus();
                this.Go.Cursor = System.Windows.Forms.Cursors.Default;
                return;
            }
            if (tbValidCode.Text == "" || tbValidCode.Text == null) {
                MessageBox.Show("请填写验证码", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                tbValidCode.Focus();
                this.Go.Cursor = System.Windows.Forms.Cursors.Default;
                return;
            }
            if (!tbValidCode.Text.Equals(code)) {
                MessageBox.Show("验证码错误", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Go.Cursor = System.Windows.Forms.Cursors.Default;
                return;
            }
            string id = tbId.Text;
            string Email = tbEmail.Text;
            string NickName = tbNickName.Text;
            string newPassword = tbNewPassword.Text;
            MIDDLEENUM mess = new LogonMiddle().forgetPassword(id, Email, NickName, newPassword);
            string info = "";
            switch (mess) {
                case MIDDLEENUM.未知错误:
                    info = "未知错误";
                    break;
                case MIDDLEENUM.数据不存在:
                    info = "数据不存在";
                    break;
                case MIDDLEENUM.复制表_45错误:
                    info = "更新密码失败";
                    break;
                case MIDDLEENUM.更新密码失败:
                    info = "更新密码失败";
                    break;
                case MIDDLEENUM.更新密码成功:
                    info = "更新密码成功";
                    break;
                default:
                    break;
            }
            MessageBox.Show(info, "", MessageBoxButtons.OK, MessageBoxIcon.None);
            this.Go.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void ForgetPwd_Load(object sender, EventArgs e) {
            validCode();
        }

        private void label7_Click(object sender, EventArgs e) {
            code = "";
            validCode();
        }
        /// <summary>
        /// 验证码
        /// </summary>
        private void validCode() {
            ValidCode va = new ValidCode(4);
            string[] v = va.color();
            string[] v1 = va.validCode();
            for (int i = 0; i < v.Length; i++) {
                tb[i].Text = v1[i];
                code += v1[i];
                Color color = ColorTranslator.FromHtml(v[i]);
                tb[i].ForeColor = color;
            }
        }

        private void label3_Click(object sender, EventArgs e) {
            timer1.Start();
        }
    }
}
