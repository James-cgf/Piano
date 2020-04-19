using AccessService;
using System;
using System.IO;

namespace LogicManager {
    public class WriteIP {
        /// <summary>
        /// 账号存放位置
        /// </summary>
        public static readonly string idPath = "id.PianoIP1";
        /// <summary>
        /// 密码存放位置
        /// </summary>
        public static readonly string passwordPath = "pass.PianoIP2";
        /// <summary>
        /// 读取账号
        /// </summary>
        /// <returns></returns>
        public static string getId() {
            return iniIdAndPwd(idPath);
        }
        /// <summary>
        /// 读取密码
        /// </summary>
        /// <returns></returns>
        public static string getPassword() {
            return iniIdAndPwd(passwordPath);
        }

        /// <summary>
        /// 写出账号密码
        /// </summary>
        /// <param name="id">账号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public static bool writeIdAndPwd(string id, string password) {
            try {
                write(id, idPath);
                write(password, passwordPath);
                return true;
            } catch (Exception) {
                return false;
            }
        }
        private static void write(string str, string path) {
            FileStream fs = null;
            StreamWriter sw = null;
            try {
                fs = new FileStream(path, FileMode.Create);
                FileInfo file = new FileInfo(path);//创建文件
                sw = new StreamWriter(fs);
                sw.Write(str);
                sw.Flush();
            } catch {
            } finally {
                if (sw != null) {
                    sw.Close();
                }
                if (fs != null) {
                    fs.Close();
                }
            }
        }
        /// <summary>
        /// 读取指定文件到末尾
        /// </summary>
        /// <param name="name"></param>
        /// <param name="name2"></param>
        private static string iniIdAndPwd(string path) {
            string str = null;
            if (!File.Exists(path)) {
                return str;
            }
            FileStream fs = null;
            StreamReader sr = null;
            try {
                fs = new FileStream(path, FileMode.Open);
                sr = new StreamReader(fs);
                str = sr.ReadToEnd();
            } catch {
            } finally {
                if (sr != null) {
                    sr.Close();
                }
                if (fs != null) {
                    fs.Close();
                }
            }
            return str;
        }
    }
}
