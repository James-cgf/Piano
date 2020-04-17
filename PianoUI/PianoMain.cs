using AccessService;
using CCWin;
using LogicManager;
using Middleware;
using PinaoUI.As;
using PinaoUI.Donate;
using PinaoUI.Login;
using PinaoUI.Notice;
using PinaoUI.Theme;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
/*
 * @Author:CACode_cctvadmin
 * @Last modify:2020/4/18
 * @Modify:PianoMain timer3
 * @Date:2020/4/16
 */
//佛主保佑，永无BUG
/**###*###############################################################*###*
  *###*                                                               *###*
  *###*                                                               *###*
  *###*                            _ooOoo_                            *###*
  *###*                           o8888888o                           *###*
  *###*                           88" . "88                           *###*
  *###*                           (| -_- |)                           *###*
  *###*                            O\ = /O                            *###*
  *###*                        ____/`---'\____                        *###*
  *###*                      .   ' \\| |// `.                         *###*
  *###*                       / \\||| : |||// \                       *###*
  *###*                     / _||||| -:- |||||- \                     *###*
  *###*                       | | \\\ - /// | |                       *###*
  *###*                     | \_| ''\---/'' | |                       *###*
  *###*                      \ .-\__ `-` ___/-. /                     *###*
  *###*                   ___`. .' /--.--\ `. . __                    *###*
  *###*                ."" '< `.___\_<|>_/___.' >'"".                 *###*
  *###*               | | : `- \`.;`\ _ /`;.`/ - ` : | |              *###*
  *###*                 \ \ `-. \_ __\ /__ _/ .-` / /                 *###*
  *###*         ======`-.____`-.___\_____/___.-`____.-'======         *###*
  *###*                            `=---='                            *###*
  *###*                                                               *###*
  *###*         .............................................         *###*
  *###*                  佛祖保佑             永无BUG                  *###*
  *###*                                                               *###*
  *###*   .........................................................   *###*
  *###*                                                               *###*
  *###*                                                               *###*
  *###*###############################################################*###***/
namespace PinaoUI {
    public partial class PianoMain : Skin_DevExpress {
        private DonateForm donate = new DonateForm();//捐献排行
        /// <summary>
        /// 静态代码块
        /// </summary>
        static PianoMain() {
            try {
                //等待动画
                //屏幕分辨率
                IniWindowsSize windowsSize = new IniWindowsSize();
                if (!windowsSize.windowsSize(1920, 1080)) {
                    new OpenWarning().ShowDialog();
                    exit = true;
                    MessageBox.Show("当前分辨率：" + windowsSize.getX() + "px*" + windowsSize.getY() + "px\r\n点击退出", "分辨率不一致", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                string id_ = WriteIP.getId();
                string password = WriteIP.getPassword();
                if (id_ != null && password != null) {
                    id = Convert.ToInt32(id_);
                    LoginInfo = true;
                }
                //初始登录方法
                MIDDLEENUM MIDDLEENUM = new LogonMiddle().unscrambleSigninToLogin(id, password, ref NickName, ref logonTime, ref LoginInfo);
            } catch {

            }
        }
        /// <summary>
        /// 分辨率是否一致
        /// </summary>
        private static bool exit { get; set; } = false;
        /// <summary>
        /// 获取杂物类对象
        /// </summary>
        private static Impurity impurity = Integration.getImpurity;
        /// <summary>
        /// 当前版本号
        /// </summary>
        private string nowEdition { get; set; } = "@Copyright © CACode's For Piano T-" + impurity.nowEdition();
        /// <summary>
        /// 数据库版本号
        /// </summary>
        private string edition { get; set; } = "@Copyright © CACode's For Piano T-" + impurity.getEdition();
        /// <summary>
        /// 按键对应页面
        /// </summary>
        public Dictionary<Keys, PictureBox> keyPic = new Dictionary<Keys, PictureBox>();
        /// <summary>
        /// 按键对应按钮
        /// </summary>
        public Dictionary<Keys, Button> keyBtn = new Dictionary<Keys, Button>();
        /// <summary>
        /// 按钮对应音乐
        /// </summary>
        public Dictionary<Button, string> btnMusic = new Dictionary<Button, string>();

        public Dictionary<Keys, PictureBox> keyPicCopy = new Dictionary<Keys, PictureBox>();

        /**音阶方法：
         * 上面永远比下面少两节
         */

        /// <summary>
        /// 留着上面10个音阶
        /// </summary>
        public List<Label> topYin = new List<Label>();
        /// <summary>
        /// 留着下面10个音阶
        /// </summary>
        public List<Label> bottomYin = new List<Label>();
        private Thread re = new Thread(shan);//录制线程
        private static PianoMain formMain = new PianoMain();//设置线程窗口
        public static bool LoginInfo = false;//默认登录状态
        private static string NickName = "ERROR";//默认登录的昵称
        private static int id = 0;//默认登录的ID
        private static string logonTime = "2020/2/27 5:18:00";//默认注册日期

        public PianoMain() {
            InitializeComponent();
            this.EditionLB.Text = nowEdition;//设置版本信息
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;//线程通信
        }
        [DllImport("winInet.dll")]//导入window32底层网络
        private static extern bool InternetGetConnectedState(ref int dwFlag, int dwReserved);//判断是否联网
        /// <summary>
        /// 返回网络状态
        /// </summary>
        public static bool Status {
            get {
                Int32 dwFlag = new int();
                if (!InternetGetConnectedState(ref dwFlag, 0)) {
                    return false;
                } else {
                    return true;
                }
            }
        }
        /// <summary>
        /// 临时按钮
        /// </summary>
        private Button btnUp = null;
        /*/// <summary>
        /// 临时图片框
        /// </summary>
        private PictureBox picture = new PictureBox();*/
        /// <summary>
        /// 临时图片框2
        /// </summary>
        private PictureBox pictureCopy_2 = new PictureBox();
        /// <summary>
        /// 临时图片框
        /// </summary>
        private PictureBox pictureCopy = new PictureBox();
        //private KeyEventArgs key;
        /// <summary>
        /// 执行线程任务
        /// </summary>
        private int numlampIndex = 0;//num指示灯
        private int capslampIndex = 0;//cap指示灯
        private int scolllampIndex = 0;//scoll指示灯

        private object sender;//线程使用的控件
        private KeyEventArgs keyEven;//线程使用的键
        /// <summary>
        /// 播放
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="dic2"></param>
        /// <param name="key"></param>
        public void play(Dictionary<Keys, Button> dic, Dictionary<Button, string> dic2, KeyEventArgs key) {
            try {
                Button btn = dic[key.KeyCode];//取按钮
                string path = dic2[btn];//取播放地址
                btn.BackColor = Color.YellowGreen;
                new GPlayMusic(path).run();
                btnUp = btn;
            } catch {

            }
        }
        /// <summary>
        /// 线程运行按下方法
        /// </summary>
        private void runKeyDown(KeyEventArgs keyEven) {
            try {

                PicCopy.Image = keyPic[keyEven.KeyCode].Image;
                keyPic[keyEven.KeyCode].Image = null;
                /*PictureBox pictureBox = keyPic[keye.KeyCode];//取图片
                pictureCopy.Image = pictureBox.Image;
                pictureBox.Image = pictureCopy_2.Image;
                PicCopy.Image = pictureCopy.Image;*/
            } catch {

            }
            //三个指示灯
            switch (keyEven.KeyCode) {
                case Keys.NumLock:
                    if (numlampIndex == 1) {
                        numlampIndex = 0;
                        this.numlamp.Image = imageList1.Images[0];
                    } else {
                        numlampIndex++;
                        this.numlamp.Image = imageList1.Images[3];
                    }
                    break;
                case Keys.CapsLock:
                    if (capslampIndex == 1) {
                        capslampIndex = 0;
                        this.capslamp.Image = imageList1.Images[1];
                    } else {
                        capslampIndex++;
                        this.capslamp.Image = imageList1.Images[4];
                    }
                    break;
                case Keys.Scroll:
                    if (scolllampIndex == 1) {
                        scolllampIndex = 0;
                        this.scolllamp.Image = imageList1.Images[2];
                    } else {
                        scolllampIndex++;
                        this.scolllamp.Image = imageList1.Images[5];
                    }
                    break;
                default:
                    break;
            }
            play(keyBtn, btnMusic, keyEven);
            new Thread(runTopYin).Start();
            new Thread(runBottomYin).Start();
        }
        /// <summary>
        /// 键盘抬起
        /// </summary>
        private void runUp(KeyEventArgs keyEven) {
            try {
                keyPic[keyEven.KeyCode] = keyPicCopy[keyEven.KeyCode];
                if (btnUp.Name != null && btnUp.Name != "") {
                    if (btnUp.Name.Substring(0, 1).Equals("a")) {
                        btnUp.BackColor = Color.Black;
                    } else {
                        btnUp.BackColor = Color.White;
                    }
                }
            } catch (Exception error) {
                WriteError.write(error.Message);
            }
        }

        int countYin = 10;
        private void runTopYin() {
            foreach (Label item in topYin) {
                item.Visible = false;
            }
            for (int i = 0; i < countYin - 3; i++) {
                topYin[i].Visible = true;
                Thread.Sleep(50);
            }
            Thread.Sleep(700);
            foreach (Label item in topYin) {
                item.Visible = false;
                Thread.Sleep(50);
            }
        }

        private void runBottomYin() {
            foreach (Label item in bottomYin) {
                item.Visible = false;
            }
            for (int i = 0; i < countYin; i++) {
                bottomYin[i].Visible = true;
                Thread.Sleep(50);
            }
            Thread.Sleep(700);
            foreach (Label item in bottomYin) {
                item.Visible = false;
                Thread.Sleep(50);
            }
        }

        /// <summary>
        /// 按键按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e) {
            this.sender = sender;
            this.keyEven = e;
            runKeyDown(e);
        }
        /// <summary>
        /// 按键抬起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyUp(object sender, KeyEventArgs e) {
            runUp(e);
        }
        /// <summary>
        /// 运行时加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e) {
            //分辨率是否一致
            if (exit) {
                Application.Exit();
            }

            //判断是否需要升级
            if (impurity.compareEditon(impurity.nowEdition(), impurity.getEdition())) {
                this.NewVersionLLB.Visible = true;
            }
            if (LoginInfo) {
                this.LoginName.Text = NickName;
                this.HeadPic.Enabled = false;
                this.HeadPic.Visible = false;
                this.LoginName.Enabled = true;
                this.LoginName.Visible = true;
            }
            //开启公告
            if (Status) {
                new Thread(showNotice).Start();
            }
            re.Name = "RecordingAuto";//设置录制线程名称
            this.numlamp.Image = imageList1.Images[0];
            this.capslamp.Image = imageList1.Images[1];
            this.scolllamp.Image = imageList1.Images[2];

            InputLanguage a = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-US"));
            //InputMethod.IsInputMethodEnabled = true;
            //初始化参数
            initPic();
            initBtn();
            iniBtnMusic();
            iniLbYin_Top();
            iniLbYin_Bottom();
            copyPic(keyPic);
            //显示捐献排行
            donate.id = id;
            donate.TopMost = false;
            donate.TopLevel = false;
            donate.FormBorderStyle = FormBorderStyle.None;
            donate.Size = pn_donace.Size;
            donate.Dock = DockStyle.Fill;
            pn_donace.Controls.Add(donate);
            donate.Show();
        }
        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PianoMain_FormClosed(object sender, FormClosedEventArgs e) {
            timer1.Start();
            System.Environment.Exit(0);
        }
        /// <summary>
        /// 公告
        /// </summary>
        private void showNotice() {
            OpenNotice opneNotice = new OpenNotice();
            opneNotice.Activate();
            opneNotice.TopMost = true;
            opneNotice.ShowDialog();
        }
        /// <summary>
        /// 初始化103按键和视图键盘对应
        /// </summary>
        private void initPic() {
            //第一行
            keyPic.Add(Keys.Escape, esc);
            keyPic.Add(Keys.F1, f1);
            keyPic.Add(Keys.F2, f1);
            keyPic.Add(Keys.F3, f1);
            keyPic.Add(Keys.F4, f1);
            keyPic.Add(Keys.F5, f1);
            keyPic.Add(Keys.F6, f1);
            keyPic.Add(Keys.F7, f1);
            keyPic.Add(Keys.F8, f1);
            keyPic.Add(Keys.F9, f1);
            keyPic.Add(Keys.F10, f1);
            keyPic.Add(Keys.F11, f1);
            keyPic.Add(Keys.F12, f1);

            keyPic.Add(Keys.PrintScreen, printScreen);
            keyPic.Add(Keys.Scroll, scrollLock);
            keyPic.Add(Keys.Pause, pause);

            //没算上灯，第二行从右边开始

            keyPic.Add(Keys.Subtract, numsubtract);
            keyPic.Add(Keys.Multiply, nummultiply);
            keyPic.Add(Keys.Divide, numdivide);
            keyPic.Add(Keys.NumLock, numLock);

            keyPic.Add(Keys.PageUp, pageUp);
            keyPic.Add(Keys.Home, home);
            keyPic.Add(Keys.Insert, insert);
            keyPic.Add(Keys.Delete, delete);
            keyPic.Add(Keys.End, end);
            keyPic.Add(Keys.PageDown, pageDown);
            //右数字键
            keyPic.Add(Keys.NumPad7, num7);
            keyPic.Add(Keys.NumPad8, num8);
            keyPic.Add(Keys.NumPad9, num9);
            keyPic.Add(Keys.NumPad4, num4);
            keyPic.Add(Keys.NumPad5, num5);
            keyPic.Add(Keys.NumPad6, num6);
            keyPic.Add(Keys.NumPad1, num1);
            keyPic.Add(Keys.NumPad2, num2);
            keyPic.Add(Keys.NumPad3, num3);
            keyPic.Add(Keys.NumPad0, num0);
            //右加和enter
            keyPic.Add(Keys.Add, numadd);
            //keyPic.Add(Keys.Enter, numenter);
            //方向键
            keyPic.Add(Keys.Up, up);
            keyPic.Add(Keys.Down, down);
            keyPic.Add(Keys.Left, left);
            keyPic.Add(Keys.Right, right);
            //回到左边从~开始
            keyPic.Add(Keys.Oemtilde, separator);
            keyPic.Add(Keys.D1, top1);
            keyPic.Add(Keys.D2, top2);
            keyPic.Add(Keys.D3, top3);
            keyPic.Add(Keys.D4, top4);
            keyPic.Add(Keys.D5, top5);
            keyPic.Add(Keys.D6, top6);
            keyPic.Add(Keys.D7, top7);
            keyPic.Add(Keys.D8, top8);
            keyPic.Add(Keys.D9, top9);
            keyPic.Add(Keys.D0, top0);
            keyPic.Add(Keys.OemMinus, Minus);


            keyPic.Add(Keys.Oemplus, equals);//可能不对
            keyPic.Add(Keys.Back, backSpance);

            //字母第一行
            keyPic.Add(Keys.Tab, tab);
            keyPic.Add(Keys.Q, q);
            keyPic.Add(Keys.W, w);
            keyPic.Add(Keys.E, e);
            keyPic.Add(Keys.R, r);
            keyPic.Add(Keys.T, t);
            keyPic.Add(Keys.Y, y);
            keyPic.Add(Keys.U, u);
            keyPic.Add(Keys.I, i);
            keyPic.Add(Keys.O, o);
            keyPic.Add(Keys.P, p);

            keyPic.Add(Keys.OemOpenBrackets, openingBracket);
            keyPic.Add(Keys.Oem6, closingBracket);
            keyPic.Add(Keys.Oem5, backslash);//缺一个、键

            //第二行
            keyPic.Add(Keys.CapsLock, capsLK);
            keyPic.Add(Keys.A, a);
            keyPic.Add(Keys.S, s);
            keyPic.Add(Keys.D, d);
            keyPic.Add(Keys.F, f);
            keyPic.Add(Keys.G, g);
            keyPic.Add(Keys.H, h);
            keyPic.Add(Keys.J, j);
            keyPic.Add(Keys.K, k);
            keyPic.Add(Keys.L, l);
            keyPic.Add(Keys.Oem1, semicolon);
            keyPic.Add(Keys.Oem7, singleQuote);
            keyPic.Add(Keys.Return, enter);

            //第三行
            keyPic.Add(Keys.LShiftKey, shift);
            keyPic.Add(Keys.Z, z);
            keyPic.Add(Keys.X, x);
            keyPic.Add(Keys.C, c);
            keyPic.Add(Keys.V, v);
            keyPic.Add(Keys.B, b);
            keyPic.Add(Keys.N, n);
            keyPic.Add(Keys.M, m);
            keyPic.Add(Keys.Oemcomma, comma);
            keyPic.Add(Keys.OemPeriod, dot);
            keyPic.Add(Keys.OemQuestion, slash);
            keyPic.Add(Keys.RShiftKey, shiftRight);

            //最底下一行
            keyPic.Add(Keys.ControlKey, ctrl);
            keyPic.Add(Keys.LWin, win);
            keyPic.Add(Keys.LMenu, alt);
            keyPic.Add(Keys.Space, space);
            keyPic.Add(Keys.RMenu, altRight);
            keyPic.Add(Keys.RWin, winRight);
            keyPic.Add(Keys.Apps, menu);
            keyPic.Add(Keys.RControlKey, ctrlRight);
        }
        /// <summary>
        /// 初始化按键和按钮对应
        /// </summary>
        private void initBtn() {
            //第一行
            keyBtn.Add(Keys.Escape, a1);
            keyBtn.Add(Keys.F1, a2);
            keyBtn.Add(Keys.F2, a3);
            keyBtn.Add(Keys.F3, a4);
            keyBtn.Add(Keys.F4, a5);
            keyBtn.Add(Keys.F5, a6);
            keyBtn.Add(Keys.F6, a7);
            keyBtn.Add(Keys.F7, a8);
            keyBtn.Add(Keys.F8, a9);
            keyBtn.Add(Keys.F9, a10);
            keyBtn.Add(Keys.F10, a11);
            keyBtn.Add(Keys.F11, a12);
            keyBtn.Add(Keys.F12, a13);

            keyBtn.Add(Keys.PrintScreen, a14);
            keyBtn.Add(Keys.Scroll, a15);
            keyBtn.Add(Keys.Pause, a16);

            //没算上灯，第二行从右边开始

            keyBtn.Add(Keys.Subtract, a17);
            keyBtn.Add(Keys.Multiply, a18);
            keyBtn.Add(Keys.Divide, a19);
            keyBtn.Add(Keys.NumLock, a20);

            keyBtn.Add(Keys.PageUp, a21);
            keyBtn.Add(Keys.Home, a22);
            keyBtn.Add(Keys.Insert, a23);
            keyBtn.Add(Keys.Delete, a24);
            keyBtn.Add(Keys.End, a25);
            keyBtn.Add(Keys.PageDown, a26);
            //右数字键
            keyBtn.Add(Keys.NumPad7, a27);
            keyBtn.Add(Keys.NumPad8, a28);
            keyBtn.Add(Keys.NumPad9, a29);
            keyBtn.Add(Keys.NumPad4, a30);
            keyBtn.Add(Keys.NumPad5, a31);
            keyBtn.Add(Keys.NumPad6, a32);
            keyBtn.Add(Keys.NumPad1, a33);
            keyBtn.Add(Keys.NumPad2, a34);
            keyBtn.Add(Keys.NumPad3, a35);
            keyBtn.Add(Keys.NumPad0, a36);
            /*//右加和enter
            keyBtn.Add(Keys.Add, a37);
            keyBtn.Add(Keys.Enter, numenter);
            //方向键
            keyBtn.Add(Keys.Up, up);
            keyBtn.Add(Keys.Down, down);
            keyBtn.Add(Keys.Left, left);
            keyBtn.Add(Keys.Right, right);*/
            //回到左边从~开始
            keyBtn.Add(Keys.Oemtilde, b1);
            keyBtn.Add(Keys.D1, b2);
            keyBtn.Add(Keys.D2, b3);
            keyBtn.Add(Keys.D3, b4);
            keyBtn.Add(Keys.D4, b5);
            keyBtn.Add(Keys.D5, b6);
            keyBtn.Add(Keys.D6, b7);
            keyBtn.Add(Keys.D7, b8);
            keyBtn.Add(Keys.D8, b9);
            keyBtn.Add(Keys.D9, b10);
            keyBtn.Add(Keys.D0, b11);
            keyBtn.Add(Keys.OemMinus, b12);


            keyBtn.Add(Keys.Oemplus, b13);
            keyBtn.Add(Keys.Back, b14);

            //字母第一行
            //keyBtn.Add(Keys.Tab, tab);//废弃
            keyBtn.Add(Keys.Q, b15);
            keyBtn.Add(Keys.W, b16);
            keyBtn.Add(Keys.E, b17);
            keyBtn.Add(Keys.R, b18);
            keyBtn.Add(Keys.T, b19);
            keyBtn.Add(Keys.Y, b20);
            keyBtn.Add(Keys.U, b21);
            keyBtn.Add(Keys.I, b22);
            keyBtn.Add(Keys.O, b23);
            keyBtn.Add(Keys.P, b24);

            keyBtn.Add(Keys.OemOpenBrackets, b25);
            keyBtn.Add(Keys.Oem6, b26);
            keyBtn.Add(Keys.Oem5, b27);

            //第二行
            keyBtn.Add(Keys.CapsLock, b28);
            keyBtn.Add(Keys.A, b29);
            keyBtn.Add(Keys.S, b30);
            keyBtn.Add(Keys.D, b31);
            keyBtn.Add(Keys.F, b32);
            keyBtn.Add(Keys.G, b33);
            keyBtn.Add(Keys.H, b34);
            keyBtn.Add(Keys.J, b35);
            keyBtn.Add(Keys.K, b36);
            keyBtn.Add(Keys.L, b37);
            keyBtn.Add(Keys.Oem1, b38);
            keyBtn.Add(Keys.Oem7, b39);
            keyBtn.Add(Keys.Return, b40);

            //第三行
            keyBtn.Add(Keys.ShiftKey, b41);
            keyBtn.Add(Keys.Z, b42);
            keyBtn.Add(Keys.X, b43);
            keyBtn.Add(Keys.C, b44);
            keyBtn.Add(Keys.V, b45);
            keyBtn.Add(Keys.B, b46);
            keyBtn.Add(Keys.N, b47);
            keyBtn.Add(Keys.M, b48);
            keyBtn.Add(Keys.Oemcomma, b49);
            keyBtn.Add(Keys.OemPeriod, b50);
            keyBtn.Add(Keys.OemQuestion, b51);

            /*//最底下一行
            keyBtn.Add(Keys.ControlKey, b53);
            keyBtn.Add(Keys.LWin, b54);
            keyBtn.Add(Keys.LMenu, alt);
            keyBtn.Add(Keys.Space, space);
            keyBtn.Add(Keys.RMenu, altRight);
            keyBtn.Add(Keys.RWin, winRight);
            keyBtn.Add(Keys.Apps, menu);
            keyBtn.Add(Keys.RControlKey, ctrlRight);*/




        }
        /// <summary>
        /// 初始化按钮对应音乐
        /// </summary>
        private void iniBtnMusic() {
            /**
             * A
             */
            //1
            btnMusic.Add(a1, "Music/A!.wav");
            btnMusic.Add(a2, "Music/C!.wav");
            btnMusic.Add(a3, "Music/D!.wav");
            btnMusic.Add(a4, "Music/F!.wav");
            btnMusic.Add(a5, "Music/G!.wav");
            //2
            btnMusic.Add(a6, "Music/2A!.wav");
            btnMusic.Add(a7, "Music/2C!.wav");
            btnMusic.Add(a8, "Music/2D!.wav");
            btnMusic.Add(a9, "Music/2F!.wav");
            btnMusic.Add(a10, "Music/2G!.wav");
            //3
            btnMusic.Add(a11, "Music/3A!.wav");
            btnMusic.Add(a12, "Music/3C!.wav");
            btnMusic.Add(a13, "Music/3D!.wav");
            btnMusic.Add(a14, "Music/3F!.wav");
            btnMusic.Add(a15, "Music/3G!.wav");
            //4
            btnMusic.Add(a16, "Music/4A!.wav");
            btnMusic.Add(a17, "Music/4C!.wav");
            btnMusic.Add(a18, "Music/4D!.wav");
            btnMusic.Add(a19, "Music/4F!.wav");
            btnMusic.Add(a20, "Music/4G!.wav");
            //5
            btnMusic.Add(a21, "Music/5A!.wav");
            btnMusic.Add(a22, "Music/5C!.wav");
            btnMusic.Add(a23, "Music/5D!.wav");
            btnMusic.Add(a24, "Music/5F!.wav");
            btnMusic.Add(a25, "Music/5G!.wav");
            //6
            btnMusic.Add(a26, "Music/6A!.wav");
            btnMusic.Add(a27, "Music/6C!.wav");
            btnMusic.Add(a28, "Music/6D!.wav");
            btnMusic.Add(a29, "Music/6F!.wav");
            btnMusic.Add(a30, "Music/6G!.wav");
            //7
            btnMusic.Add(a31, "Music/7A!.wav");
            btnMusic.Add(a32, "Music/7C!.wav");
            btnMusic.Add(a33, "Music/7D!.wav");
            btnMusic.Add(a34, "Music/7F!.wav");
            btnMusic.Add(a35, "Music/7G!.wav");
            //8
            btnMusic.Add(a36, "Music/8A!.wav");

            /**
             * B
             */


            //1
            btnMusic.Add(b1, "Music/A.wav");
            btnMusic.Add(b2, "Music/B.wav");
            btnMusic.Add(b3, "Music/C.wav");
            btnMusic.Add(b4, "Music/D.wav");
            btnMusic.Add(b5, "Music/E.wav");
            btnMusic.Add(b6, "Music/F.wav");
            btnMusic.Add(b7, "Music/G!.wav");
            //2
            btnMusic.Add(b8, "Music/2A.wav");
            btnMusic.Add(b9, "Music/2B.wav");
            btnMusic.Add(b10, "Music/2C.wav");
            btnMusic.Add(b11, "Music/2D.wav");
            btnMusic.Add(b12, "Music/2E.wav");
            btnMusic.Add(b13, "Music/2F.wav");
            btnMusic.Add(b14, "Music/2G.wav");
            //3
            btnMusic.Add(b15, "Music/3A.wav");
            btnMusic.Add(b16, "Music/3B.wav");
            btnMusic.Add(b17, "Music/3C.wav");
            btnMusic.Add(b18, "Music/3D.wav");
            btnMusic.Add(b19, "Music/3E.wav");
            btnMusic.Add(b20, "Music/3F.wav");
            btnMusic.Add(b21, "Music/3G.wav");
            //4
            btnMusic.Add(b22, "Music/4A.wav");
            btnMusic.Add(b23, "Music/4B.wav");
            btnMusic.Add(b24, "Music/4C.wav");
            btnMusic.Add(b25, "Music/4D.wav");
            btnMusic.Add(b26, "Music/4E.wav");
            btnMusic.Add(b27, "Music/4F.wav");
            btnMusic.Add(b28, "Music/4G.wav");
            //5
            btnMusic.Add(b29, "Music/5A.wav");
            btnMusic.Add(b30, "Music/5B.wav");
            btnMusic.Add(b31, "Music/5C.wav");
            btnMusic.Add(b32, "Music/5D.wav");
            btnMusic.Add(b33, "Music/5E.wav");
            btnMusic.Add(b34, "Music/5F.wav");
            btnMusic.Add(b35, "Music/5G.wav");
            //6
            btnMusic.Add(b36, "Music/6A.wav");
            btnMusic.Add(b37, "Music/6B.wav");
            btnMusic.Add(b38, "Music/6C.wav");
            btnMusic.Add(b39, "Music/6D.wav");
            btnMusic.Add(b40, "Music/6E.wav");
            btnMusic.Add(b41, "Music/6F.wav");
            btnMusic.Add(b42, "Music/6G.wav");
            //7
            btnMusic.Add(b43, "Music/7A.wav");
            btnMusic.Add(b44, "Music/7B.wav");
            btnMusic.Add(b45, "Music/7C.wav");
            btnMusic.Add(b46, "Music/7D.wav");
            btnMusic.Add(b47, "Music/7E.wav");
            btnMusic.Add(b48, "Music/7F.wav");
            btnMusic.Add(b49, "Music/7G.wav");
            //8
            btnMusic.Add(b50, "Music/8A.wav");
            btnMusic.Add(b51, "Music/8B.wav");
            btnMusic.Add(b52, "Music/8C.wav");
        }
        /// <summary>
        /// 初始化上音阶
        /// </summary>
        private void iniLbYin_Top() {
            topYin.Add(mt1);
            topYin.Add(mt2);
            topYin.Add(mt3);
            topYin.Add(mt4);
            topYin.Add(mt5);
            topYin.Add(mt6);
            topYin.Add(mt7);
            topYin.Add(mt8);
            topYin.Add(mt9);
            topYin.Add(mt10);
        }
        /// <summary>
        /// 初始化下音阶
        /// </summary>
        private void iniLbYin_Bottom() {
            bottomYin.Add(mb1);
            bottomYin.Add(mb2);
            bottomYin.Add(mb3);
            bottomYin.Add(mb4);
            bottomYin.Add(mb5);
            bottomYin.Add(mb6);
            bottomYin.Add(mb7);
            bottomYin.Add(mb8);
            bottomYin.Add(mb9);
            bottomYin.Add(mb10);
        }
        /// <summary>
        /// 懒人法复制键值法
        /// </summary>
        /// <param name=""></param>
        private void copyPic(Dictionary<Keys, PictureBox> dic) {
            keyPicCopy = dic;
        }
        /// <summary>
        /// 关于我们
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAboutCACode_Click(object sender, EventArgs e) {
            new CACodeAbout().Show();
        }
        /// <summary>
        /// 单击登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeadPic_Click(object sender, EventArgs e) {
            PianoLogin login = new PianoLogin();
            login.ShowDialog();
            if (login.LoginInfo) {
                LoginInfo = true;
                NickName = login.NickName;
                logonTime = login.LogonTime;
                id = login.id;
                this.LoginName.Text = NickName;
                this.HeadPic.Enabled = false;
                this.HeadPic.Visible = false;
                this.LoginName.Enabled = true;
                this.LoginName.Visible = true;
                donate.id = id;
            }
        }
        /// <summary>
        /// 所有琴键按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void a29_MouseDown(object sender, MouseEventArgs e) {
            Button btn = (Button)sender;
            btn.BackColor = Color.Yellow;
            string path = "";
            foreach (var item in btnMusic) {
                if (item.Key == (Button)sender) {
                    path = item.Value;
                    break;
                }
            }
            //linked.AddLast(linked.RemoveFirst());

            new GPlayMusic(path).run();

        }
        /// <summary>
        /// 白色按键抬起事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void a29_MouseUp(object sender, MouseEventArgs e) {
            Button btn = (Button)sender;
            btn.BackColor = Color.White;
        }
        /// <summary>
        /// 黑色抬起事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void a36_MouseUp(object sender, MouseEventArgs e) {
            Button btn = (Button)sender;
            btn.BackColor = Color.Black;
        }
        /// <summary>
        /// 按键按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void a35_KeyDown(object sender, KeyEventArgs e) {
            MainForm_KeyDown(sender, e);
        }
        /// <summary>
        /// 按键抬起事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void a35_KeyUp(object sender, KeyEventArgs e) {
            MainForm_KeyUp(sender, e);
        }
        /// <summary>
        /// 更新链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewVersionLLB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start(("http://www.adminznh.ren/File/Piano" + impurity.getEdition() + ".exe"));
        }
        /// <summary>
        /// 个人信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e) {
            new AboutUser(NickName, logonTime).ShowDialog();
        }
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e) {
            try {
                logonTime = null;
                LoginInfo = false;
                NickName = null;
                id = 0;
                this.LoginName.Enabled = false;
                this.LoginName.Visible = false;
                this.HeadPic.Enabled = true;
                this.HeadPic.Visible = true;
                donate.id = id;
                if (System.IO.File.Exists(WriteIP.idPath)) {
                    System.IO.File.Delete(WriteIP.idPath);
                }
                if (System.IO.File.Exists(WriteIP.passwordPath)) {
                    System.IO.File.Delete(WriteIP.passwordPath);
                }
                this.timer3.Start();
            } catch (Exception err) {
                MessageBox.Show("请已管理员身份打开Piano！错误信息：" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }
        /// <summary>
        /// 动画调出菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginName_Click(object sender, EventArgs e) {
            timer2.Start();
        }
        /// <summary>
        /// 菜单到右
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toLeft_Click(object sender, EventArgs e) {
            timer3.Start();
        }
        int menuX = 1930, menuY = 42;
        /// <summary>
        /// 定时器1->实现窗口关闭动画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e) {
            if (this.Opacity >= 0.025) {
                this.Opacity -= 0.025;
            } else {
                Application.Exit();
            }
        }
        /// <summary>
        /// 定时器2->实现菜单栏动画->隐藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e) {
            this.pnUserInfo.Location = new System.Drawing.Point(menuX, menuY);
            if (menuX >= 1803) {
                menuX -= 20;
            } else {
                timer2.Stop();
            }
        }
        /// <summary>
        /// 定时器3->实现菜单栏动画->显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer3_Tick(object sender, EventArgs e) {
            this.pnUserInfo.Location = new System.Drawing.Point(menuX, menuY);
            if (menuX <= 1930) {
                menuX += 20;
            } else {
                this.timer3.Stop();
            }
        }
        /// <summary>
        /// 放入琴谱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPutPianoScore_Click_1(object sender, EventArgs e) {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "") {
                try {
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                } catch {
                }
            }
        }
        /// <summary>
        /// 开始录制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartRecording_Click(object sender, EventArgs e) {
            formMain = this;
            try {
                re.Start();
            } catch {
            }
        }
        /// <summary>
        /// 录制按钮闪烁
        /// </summary>
        private static void shan() {
            while (true) {
                formMain.RecordingInfo.BackColor = Color.Maroon;
                Thread.Sleep(700);
                formMain.RecordingInfo.BackColor = Color.Green;
                Thread.Sleep(700);
            }
        }


        /// <summary>
        /// 停止录制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStopRecording_Click(object sender, EventArgs e) {
            try {
                re.Abort();
            } catch {

            }
            this.RecordingInfo.BackColor = Color.Transparent;
        }
        /// <summary>
        /// 自定义主题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiyTheme_Click(object sender, EventArgs e) {
            //MessageBox.Show("请等待开放......");
            CustomTheme custom = new CustomTheme();
            custom.ShowDialog();
        }

        /// <summary>
        /// 自定义按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e) {
            //MessageBox.Show("请等待开放......");
            CustomKey custom = new CustomKey();
            custom.ShowDialog();
        }


    }
}