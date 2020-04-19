using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstallPiano {
    public partial class InstallMain : Form {
        const string zipFilePath = "Piano.zip";
        public enum err {
            NOAGREE,
            DICERROR,
            UNKNOWNERROR,
        }
        public InstallMain() {
            InitializeComponent();
        }
        /// <summary>
        /// 选择安装路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e) {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == DialogResult.OK) {
                this.textBox1.Text = fd.SelectedPath;
            }
        }
        /// <summary>
        /// 确定安装
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e) {
            try {
                if (!checkBox1.Checked) {
                    MessageBox.Show("ERROR VALUES:" + err.NOAGREE);
                    checkBox1.Focus();
                    return;
                }
                if (!checkBox2.Checked) {
                    MessageBox.Show("ERROR VALUES:" + err.NOAGREE);
                    checkBox2.Focus();
                    return;
                }

                if (!Directory.Exists(textBox1.Text)) {
                    Directory.CreateDirectory(textBox1.Text);
                }
                long dirLength = 0;
                GetDirSizeByPath(textBox1.Text, ref dirLength);
                //判断正则表达式,并判断文件夹是否为空
                if (dirLength == 0) {
                    //解压安装包
                    ZipFile.ExtractToDirectory(zipFilePath, textBox1.Text);
                    //创建快捷方式
                    //CreateShortcutOnDesktop();
                    this.Close();
                } else {
                    MessageBox.Show("ERROR VALUES:" + err.DICERROR);
                }
            } catch (Exception) {
                MessageBox.Show("ERROR VALUES:" + err.UNKNOWNERROR);
            }
        }
        /// <summary>
        /// 创建桌面快捷方式
        /// </summary>
        private void CreateShortcutOnDesktop() {
            String shortcutPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "Piano.lnk");
            if (System.IO.File.Exists(shortcutPath)) {
                System.IO.File.Delete(shortcutPath);
            }
            // 获取当前应用程序目录地址
            String exePath = textBox1.Text + "/Piano/Pinao.exe";
            IWshShell shell = new WshShell();
            // 确定是否已经创建的快捷键被改名了
            foreach (var item in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "*.lnk")) {
                WshShortcut tempShortcut = (WshShortcut)shell.CreateShortcut(item);
                if (tempShortcut.TargetPath == exePath) {
                    return;
                }
            }
            WshShortcut shortcut = (WshShortcut)shell.CreateShortcut(shortcutPath);
            shortcut.TargetPath = exePath;
            shortcut.Arguments = "";// 参数  
            shortcut.Description = "CACode's For Piano";
            shortcut.WorkingDirectory = Environment.CurrentDirectory;//程序所在文件夹，在快捷方式图标点击右键可以看到此属性  
            shortcut.IconLocation = exePath;//图标，该图标是应用程序的资源文件  
                                            //shortcut.Hotkey = "CTRL+SHIFT+W";//热键，发现没作用，大概需要注册一下  
            shortcut.WindowStyle = 1;
            shortcut.Save();
        }

        /// <summary>
        /// 获取某一文件夹的大小
        /// </summary>
        /// <param name="dir">文件夹目录</param>
        /// <param name="dirSize">文件夹大小</param>
        public static void GetDirSizeByPath(string dir, ref long dirSize) {
            try {
                DirectoryInfo dirInfo = new DirectoryInfo(dir);

                DirectoryInfo[] dirs = dirInfo.GetDirectories();
                FileInfo[] files = dirInfo.GetFiles();

                foreach (var item in dirs) {
                    GetDirSizeByPath(item.FullName, ref dirSize);
                }

                foreach (var item in files) {
                    dirSize += item.Length;
                }
            } catch (Exception ex) {
                Console.WriteLine("获取文件大小失败" + ex.Message);
            }
        }
    }
}
