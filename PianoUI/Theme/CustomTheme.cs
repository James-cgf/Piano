using CCWin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PinaoUI.Theme {
    public partial class CustomTheme : Skin_DevExpress {
        private static ColorDialog color = new ColorDialog();
        private static OpenFileDialog open = new OpenFileDialog();
        private static List<PictureBox> whiteList = new List<PictureBox>();
        private static List<PictureBox> blackList = new List<PictureBox>();
        private static string nowPath = Directory.GetCurrentDirectory();
        private static string topWhitePatterm = "^[b]";//上边白色正则表达式
        private static string topBlackPatterm = "^[a]";//上边黑色正则表达式
        static CustomTheme() {
            open.Filter = "png图片|*.png|jpg|*.jpg";
            open.Title = "请选择背景";
        }
        /// <summary>
        /// 初始化白色
        /// </summary>
        private void iniWhite() {
            whiteList.Add(w1);
            whiteList.Add(w2);
            whiteList.Add(w3);
            whiteList.Add(w4);
            whiteList.Add(w5);
            whiteList.Add(w6);
            whiteList.Add(w7);
        }
        /// <summary>
        /// 初始化黑色
        /// </summary>
        private void iniBlack() {
            blackList.Add(bc1);
            blackList.Add(bc2);
            blackList.Add(bc3);
            blackList.Add(bc4);
            blackList.Add(bc5);
        }
        /// <summary>
        /// 是否已修改
        /// </summary>
        public bool modIFY { get; set; } = false;

        private Color whiteBtn = Color.White;
        private Color blackBtn = Color.Black;

        private string whitePic = nowPath + "\\CustomTheme\\white.png";
        private string blackPic = nowPath + "\\CustomTheme\\black.png";
        public CustomTheme() {
            InitializeComponent();
            iniWhite();
            iniBlack();
        }
        /// <summary>
        /// 修改白色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWhite_Click(object sender, EventArgs e) {
            string showText = wbcStyle(open, rbWhiteDi.Checked, whitePic, ref whiteBtn);
            Color showColor;
            try {
                showColor = ColorTranslator.FromHtml(showText);
                showText = ColorTranslator.ToHtml(Color.FromArgb(showColor.ToArgb()));
            } catch (Exception err) {

            }
            tbWhite.Text = showText;
            if (Regex.IsMatch(showText.Substring(0, 1), "[A-Z]{1,}")) {
                //符合上图片
                foreach (var item in whiteList) {
                    item.BackgroundImage = Image.FromFile(whitePic);
                }
                panalControls(topPanal, topWhitePatterm, whitePic);
            } else {
                //不符合上底色
                foreach (var item in whiteList) {
                    item.BackColor = whiteBtn;
                }
                panalControls(topPanal, topWhitePatterm, whiteBtn);
            }
        }
        /// <summary>
        /// 修改黑色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBlack_Click(object sender, EventArgs e) {
            string showText = wbcStyle(open, rbWhiteDi.Checked, blackPic, ref blackBtn);
            Color showColor;
            try {
                showColor = ColorTranslator.FromHtml(showText);
                showText = ColorTranslator.ToHtml(Color.FromArgb(showColor.ToArgb()));
            } catch (Exception err) {

            }
            tbBlack.Text = showText;
            if (Regex.IsMatch(showText.Substring(0, 1), "[A-Z]{1,}")) {
                //符合上图片
                foreach (var item in blackList) {
                    item.BackgroundImage = Image.FromFile(blackPic);
                }
                panalControls(topPanal, topBlackPatterm, blackPic);
            } else {
                //不符合上底色
                foreach (var item in blackList) {
                    item.BackColor = blackBtn;
                }
                panalControls(topPanal, topBlackPatterm, blackBtn);
            }
        }
        /// <summary>
        /// 返回底图路径或底图颜色
        /// </summary>
        /// <param name="open">打开文件对话框</param>
        /// <param name="rbCheck">单选框是否选中某一个</param>
        /// <param name="copyPath">复制文件到目录</param>
        /// <param name="c">颜色</param>
        public string wbcStyle(OpenFileDialog open, bool rbCheck, string copyPath, ref Color c) {
            ColorDialog color = new ColorDialog();
            string text = "";
            if (rbCheck) {
                DialogResult dialogResult = color.ShowDialog();
                if (dialogResult == DialogResult.OK) {
                    c = color.Color;
                    text = ColorTranslator.ToHtml(c);
                }
            } else {
                DialogResult dialogResult = open.ShowDialog();
                string clickFile = open.FileName;
                string fileName = Path.GetFileName(clickFile);
                if (dialogResult == DialogResult.OK && clickFile != null && clickFile != "") {
                    File.Copy(clickFile, copyPath, true);
                    text = copyPath;
                }
            }
            return text;
        }
        /// <summary>
        /// 换颜色
        /// </summary>
        /// <param name="panel">控件</param>
        /// <param name="patterm">正则表达式</param>
        /// <param name="color">换成的颜色</param>
        public void panalControls(Panel panel, string patterm, Color color) {
            foreach (Control item in panel.Controls) {
                if (Regex.IsMatch(item.Name, patterm)) {
                    item.BackColor = color;
                }
            }
        }/// <summary>
         /// 换图片
         /// </summary>
         /// <param name="panel">控件</param>
         /// <param name="patterm">正则表达式</param>
         /// <param name="color">图片路径</param>
        public void panalControls(Panel panel, string patterm, string color) {
            foreach (Control item in panel.Controls) {
                if (Regex.IsMatch(item.Name, patterm)) {
                    item.BackgroundImage = Image.FromFile(color);
                }
            }
        }

    }
}
