using System;
using System.Collections.Generic;
using System.IO;

/**
 * 如果你不幸修改了源码，那么抱歉，你改不回来了
 * 请别找我，我都不知道这一堆是什么玩意
 *                          --cctvadmin
 */
namespace AccessService {
    public class SqlMain {
        /// <summary>
        /// 链接数据库语句
        /// </summary>
        public static string SqlInfo { get; set; } = sqlInfoFile();
        /// <summary>
        /// id查询昵称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static string selectNickName(int id, string pwd) {
            string sql = completeSql(new Object[] { id, pwd }, '$', SQLMAINENUM.SELECTNICKNAME);
            return sql;
        }
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static string insertUser(string NickName, string pwd, string JoinTime, string Email) {
            string sql = completeSql(new Object[] { NickName, pwd, JoinTime, Email }, '$', SQLMAINENUM.INSERT);
            return sql;
        }
        /// <summary>
        /// 查询注册的id
        /// </summary>
        /// <param name="JoinTime"></param>
        /// <param name="pwd"></param>
        /// <param name="NickName"></param>
        /// <returns></returns>
        public static string selectId(string Email) {
            string sql = completeSql(new Object[] { Email }, '$', SQLMAINENUM.SELECTID);
            return sql;
        }
        /// <summary>
        /// 查询注册的时间
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static string selectLogonTime(string Id) {
            string sql = completeSql(new Object[] { Id }, '$', SQLMAINENUM.SELECTLOGONTIME);
            return sql;
        }
        /// <summary>
        /// 查询邮箱是否存在
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public static string selectEmail(string Email) {
            string sql = completeSql(new Object[] { Email }, '$', SQLMAINENUM.SELECTEMAIL);
            return sql;
        }
        /// <summary>
        /// 查询符合id和Email的数量
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Email"></param>
        /// <returns></returns>
        public static string verIdAndEmail(string Id, string Email, string NickName) {
            string sql = completeSql(new Object[] { Id, Email, NickName }, '$', SQLMAINENUM.VERIDANDEMAIL);
            return sql;
        }
        /// <summary>
        /// 存入新(%45)表
        /// </summary>
        /// <param name="Id">账号</param>
        /// <param name="Email">邮箱</param>
        /// <param name="Password">密码</param>
        /// <param name="Time">时间</param>
        /// <returns></returns>
        public static string insertForget(string Id, string Email, string Password, string Time) {
            string sql = completeSql(new Object[] { Id, Email, Password, Time }, '$', SQLMAINENUM.INSERTFORGET);
            return sql;
        }
        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Email"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public static string updatePassword(string newPassword, string Id, string Email, string NickName) {
            string sql = completeSql(new Object[] { newPassword, Id, Email, NickName }, '$', SQLMAINENUM.UPDATEPWD);
            return sql;
        }
        /// <summary>
        /// 返回链接数据库语句
        /// </summary>
        /// <returns></returns>
        private static string sqlInfoFile() {
            string sqlInfo = enumIMPLMethod(SQLMAINENUM.SQLINFO);
            return sqlInfo;
        }
        /// <summary>
        /// 不可说
        /// </summary>
        /// <returns></returns>
        public static string EmainPwd() {
            string EmalPwd = enumIMPLMethod(SQLMAINENUM.EMAIL);
            return EmalPwd;
        }
        /// <summary>
        /// 从高到底排行捐献榜
        /// </summary>
        /// <returns></returns>
        public static string getDonaceIdAndMoney() {
            string sql = completeSql(new Object[] { }, '$', SQLMAINENUM.GETDONATEIDANDMONEY);
            return sql;
        }
        /// <summary>
        /// 从高到底排行捐献榜
        /// </summary>
        /// <returns></returns>
        public static string getDonaceEmail() {
            string sql = completeSql(new Object[] { }, '$', SQLMAINENUM.GETDONATEEMAIL);
            return sql;
        }
        /// <summary>
        /// 写出关于用户
        /// </summary>
        /// <returns></returns>
        public static bool aboutUser(string NickName, string logonTime) {
            bool Success = false;
            FileStream fs = null;
            StreamWriter sw = null;
            try {
                fs = new FileStream("AboutUser.html", FileMode.Create);
                FileInfo file = new FileInfo("AboutUser.html");//创建文件
                sw = new StreamWriter(fs);
                sw.Write(AboutUserHtml.aboutUser(NickName, logonTime));
                sw.Flush();
                Success = true;
            } catch {
            } finally {
                if (sw != null) {
                    sw.Close();
                }
                if (fs != null) {
                    fs.Close();
                }
            }
            return Success;
        }
        /*        /// <summary>
                /// 查询关键字
                /// </summary>
                /// <param name="home">开头</param>
                /// <param name="end">结尾</param>
                /// <returns>指定关键字的查询语句</returns>
                private static string sqlFile(string home, string end) {
                    string all;
                    string Appoint;
                    FileStream fs = null;
                    StreamReader sr = null;
                    try {
                        fs = new FileStream("sqlLanguage.sql", FileMode.Open);
                        sr = new StreamReader(fs);
                        all = sr.ReadToEnd();
                        int head = all.IndexOf(home) + home.Length;
                        string a = all.Substring(all.IndexOf(home));
                        string b = all.Substring(all.IndexOf(end));
                        int footer = all.IndexOf(end);
                        Appoint = all.Substring(head, footer - head);
                    } catch (Exception error) {
                        WriteError.write(error.Message);
                        return null;
                    } finally {
                        if (sr != null) {
                            sr.Close();
                        }
                        if (fs != null) {
                            fs.Close();
                        }
                    }
                    return Appoint;
                }*/
        /// <summary>
        /// 枚举实现方法
        /// </summary>
        /// <param name="E"></param>
        /// <returns></returns>
        private static string enumIMPLMethod(SQLMAINENUM E) {
            string type = null;
            switch (E) {
                case SQLMAINENUM.SELECTNICKNAME:
                    type = SQLMAINResources.SELECTNickName;
                    break;
                case SQLMAINENUM.INSERT:
                    type = SQLMAINResources.INSERT;
                    break;
                case SQLMAINENUM.SELECTID:
                    type = SQLMAINResources.SELECTID;
                    break;
                case SQLMAINENUM.SELECTEMAIL:
                    type = SQLMAINResources.SELECTEMAIL;
                    break;
                case SQLMAINENUM.SELECTLOGONTIME:
                    type = SQLMAINResources.SELECTLOGONTIME;
                    break;
                case SQLMAINENUM.NOTICE:
                    type = SQLMAINResources.NOTICE;
                    break;
                case SQLMAINENUM.VERSIONS:
                    type = SQLMAINResources.VERSIONS;
                    break;
                case SQLMAINENUM.EMAIL:
                    type = SQLMAINResources.EMAIL;
                    break;
                case SQLMAINENUM.SQLINFO:
                    type = SQLMAINResources.SQLINFO;
                    break;
                // ->2020/3/6 Author:cctvadmin
                case SQLMAINENUM.VERIDANDEMAIL:
                    type = SQLMAINResources.VERIDANDEMAIL;
                    break;
                case SQLMAINENUM.INSERTFORGET:
                    type = SQLMAINResources.INSERTFORGET;
                    break;
                case SQLMAINENUM.UPDATEPWD:
                    type = SQLMAINResources.UPDATEPWD;
                    break;
                case SQLMAINENUM.GETDONATEIDANDMONEY:
                    type = SQLMAINResources.GETDONATEIDANDMONEY;
                    break;
                case SQLMAINENUM.GETDONATEEMAIL:
                    type = SQLMAINResources.GETDONATEEMAIL;
                    break;
                default:
                    break;
            }
            return type;
        }
        /// <summary>
        /// 解析语句
        /// <para>抛出异常原因有：</para>
        /// <pare>1.数组长度与查找的语句字符数量不一致</pare>
        /// </summary>
        /// <param name="obj">数值的数量</param>
        /// <param name="cha">掩盖的字符</param>
        /// <param name="sQLMAINENUM">查找的语句</param>
        /// <returns>格式化后的字符串</returns>
        private static string completeSql(Object[] obj, Char cha, SQLMAINENUM sQLMAINENUM) {
            List<Char> list = new List<Char>();
            string selectsql = enumIMPLMethod(sQLMAINENUM);
            string sql = "";
            string str = "";
            int index = 0;
            try {
                foreach (Char item in selectsql) {
                    list.Add(item);
                }
                foreach (var item in list) {
                    str = item.ToString();
                    if (item.Equals(cha)) {
                        //拒绝sql注入，人人有责
                        str = obj[index].ToString();
                        index++;
                    }
                    sql += str;
                }
            } catch {
                return null;
            }
            return sql;
        }
    }
}
