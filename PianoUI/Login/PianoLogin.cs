using LogicManager;
using Middleware;
using System;
using System.Windows.Forms;
/**
*                      江城子 . 程序员之歌
*
*                  十年生死两茫茫，写程序，到天亮。
*                      千行代码，Bug何处藏。
*                  纵使上线又怎样，朝令改，夕断肠。
*
*                  领导每天新想法，天天改，日日忙。
*                      相顾无言，惟有泪千行。
*                  每晚灯火阑珊处，夜难寐，加班狂。
*/
/*
 * Last revision time: 2020/4/18 1:30
 * Modifier: CACode_cctvadmin
 * 
 * 修改时间：2020/4/18 1:30
 * 修改人：CACode_cctvadmin
 */
namespace PinaoUI.Login {
    public partial class PianoLogin : Form {
        private static string idPath = WriteIP.idPath;
        private static string passwordPath = WriteIP.passwordPath;
        public PianoLogin() {
            InitializeComponent();
        }
        /// <summary>
        /// 登录状态，用于返回给主窗体
        /// </summary>
        public bool LoginInfo = false;
        /// <summary>
        /// 昵称，用于返回给主窗体
        /// </summary>
        public string NickName = null;
        /// <summary>
        /// 注册时间，用于返回给主窗体
        /// </summary>
        public string LogonTime = null;
        /// <summary>
        /// 用户ID
        /// </summary>
        public int id = 0;
        /// <summary>
        /// 登录或注册状态
        /// </summary>
        private static bool loginOrLogon { get; set; } = false;
        /// <summary>
        /// 是否被单击
        /// </summary>
        private static int clickIndex { get; set; } = 0;
        /// <summary>
        /// 点击GO按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Go_Click(object sender, EventArgs e) {
            this.id = Convert.ToInt32(tbId.Text);
            this.Go.Cursor = Cursors.AppStarting;
            if (RememberCB.Checked) {
                WriteIP.writeIdAndPwd(tbId.Text, tbPwd.Text);
            } else {
                if (System.IO.File.Exists(idPath)) {
                    System.IO.File.Delete(idPath);
                }
                if (System.IO.File.Exists(passwordPath)) {
                    System.IO.File.Delete(passwordPath);
                }
            }
            if (loginOrLogon) {

                if (EmailIsMath.emailIsMath(tbEmail.Text, "^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+(.[a-zA-Z0-9-]+)*.[a-zA-Z0-9]{2,6}$")) {
                    //为了不对主线程造成阻塞
                    new System.Threading.Thread(sw).Start();
                } else {
                    MessageBox.Show("邮箱格式不正确", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            } else {
                //为了不对主线程造成阻塞
                new System.Threading.Thread(sw).Start();
            }
            this.Go.Cursor = Cursors.Default;
        }
        /// <summary>
        /// 线程执行方法
        /// </summary>
        private void sw() {
            string mess = "ERROR";
            bool close = false;
            LogonMiddle middle = new LogonMiddle();
            switch (middle.unscrambleSigninToLogin(id.ToString(), tbPwd.Text, tbEmail.Text, loginOrLogon, ref NickName, ref LogonTime, ref LoginInfo)) {
                case MIDDLEENUM.内容不允许为空:
                    mess = "内容不允许为空";
                    break;
                case MIDDLEENUM.邮箱已存在:
                    mess = "邮箱已存在";
                    break;
                case MIDDLEENUM.发送邮件错误:
                    mess = "发送邮件错误";
                    break;
                case MIDDLEENUM.账号或密码错误:
                    mess = "账号或密码错误";
                    break;
                case MIDDLEENUM.未知错误:
                    mess = "未知错误";
                    break;
                case MIDDLEENUM.登录成功:
                    mess = "登录成功";
                    close = true;
                    break;
                case MIDDLEENUM.注册成功:
                    mess = "注册成功,请记住你的ID，这将是你以后的唯一登录方式:\r\n" + middle.reId;
                    break;
                default:
                    break;
            }
            MessageBox.Show(mess, "", MessageBoxButtons.OK, MessageBoxIcon.None);
            if (close) {
                this.Close();
            }
            this.Go.Cursor = System.Windows.Forms.Cursors.Default;
        }
        /// <summary>
        /// 限制只能输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbId_KeyPress(object sender, KeyPressEventArgs e) {
            if (!loginOrLogon) {
                LimitKey.limitKey((TextBox)sender, e);
            }
        }
        /// <summary>
        /// 密码禁用空格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPwd_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 0x20)
                e.KeyChar = (char)0;  //禁止空格键
        }
        /// <summary>
        /// 邮箱禁用空格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbEmail_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 0x20)
                e.KeyChar = (char)0;  //禁止空格键
        }
        /// <summary>
        /// 窗体多用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label3_Click(object sender, EventArgs e) {
            switch (clickIndex) {
                case 0:
                    clickIndex++;
                    this.tbEmail.Visible = true;
                    this.label4.Visible = true;
                    this.RememberCB.Visible = false;
                    labText(clickIndex, label1);
                    label3.Text = "已有账号？点击登录";
                    break;
                case 1:
                    clickIndex--;
                    this.tbEmail.Visible = false;
                    this.label4.Visible = false;
                    this.RememberCB.Visible = true;
                    labText(clickIndex, label1);
                    label3.Text = "没有账号？点击注册";
                    break;
                default:
                    break;
            }
        }
        private static void labText(int index, Label lab) {
            if (index == 0) {
                lab.Text = "账号:";
                loginOrLogon = false;
            }
            if (index == 1) {
                lab.Text = "昵称:";
                loginOrLogon = true;
            }
        }

        private void label5_Click(object sender, EventArgs e) {
            new ForgetPwd().ShowDialog();
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
    }
}
