using AccessService;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

/**
 * 年轻人，喜欢这个代码吗？
 * 喜欢？
 * 那你有本事改一行代码。
 * 
 * Young man, do you like this code?
 * Like it?
 * Then you can change a line of code
 * 
 */
namespace LogicManager {
    public class Signin {
        public string reId { get; set; } = "ERROR";

        /// <summary>
        /// 登录或注册方法
        /// <para>返回列表：</para>
        /// <para>空指针</para>
        /// <para>ErrorENUM.NULL</para>
        /// <para>邮箱已存在</para>
        /// <para>ErrorENUM.ALREADYEXIST</para>
        /// <para>注册成功</para>
        /// <para>ErrorENUM.INOK</para>
        /// <para>登录错误</para>
        /// <para>ErrorENUM.LOGINERROR</para>
        /// <para>未知错误</para>
        /// <para>ErrorENUM.UNLNOWNERROR</para>
        /// <para>登录成功</para>
        /// <para>ErrorENUM.OK</para>
        /// </summary>
        /// <param name="tbId">ID的文本框</param>
        /// <param name="tbPwd">密码文本框</param>
        /// <param name="tbEmail">邮箱文本框</param>
        /// <param name="loginOrLogon">登录还是注册</param>
        /// <param name="NickName">昵称</param>
        /// <param name="LogonTime">登录时间</param>
        /// <param name="LoginInfo">登录状态</param>
        /// <returns>字符串</returns>
        /// <returns></returns>
        public ErrorENUM signinMethod(string tbId, string tbPwd, string tbEmail, bool loginOrLogon, ref string NickName, ref string LogonTime, ref bool LoginInfo) {
            if (tbId == "") {
                return ErrorENUM.NULL;//空指针
            }
            if (tbPwd == "") {
                return ErrorENUM.NULL;//空指针
            }
            MySqlConnection mysqlconn = null;
            MySqlCommand mySqlCommand = null;
            Object idOrNickName = null;
            if (loginOrLogon) {
                idOrNickName = tbId;
            } else {
                try {
                    idOrNickName = int.Parse(tbId);
                } catch {

                }
            }
            string pwd = tbPwd;
            string time = DateTime.Now.ToString();
            string Email = tbEmail.ToLower();
            if (loginOrLogon) {
                if (tbEmail == "") {
                    return ErrorENUM.NULL;//空指针
                }
                try {
                    mysqlconn = new MySqlConnection(SqlMain.SqlInfo);
                    mysqlconn.Open();
                    mySqlCommand = new MySqlCommand(SqlMain.selectEmail(Email), mysqlconn);
                    if (Convert.ToInt32(mySqlCommand.ExecuteScalar()) >= 1) {
                        return ErrorENUM.ALREADYEXIST;//邮箱已存在
                    }
                    mySqlCommand = new MySqlCommand(SqlMain.insertUser(idOrNickName.ToString(), pwd, time, Email), mysqlconn);
                    if (mySqlCommand.ExecuteNonQuery() <= 0) {
                        return ErrorENUM.UNLNOWNERROR;//未知错误
                    } else {
                        mySqlCommand = new MySqlCommand(SqlMain.selectEmail(Email), mysqlconn);
                        mySqlCommand = new MySqlCommand(SqlMain.selectId(Email), mysqlconn);
                        this.reId = Convert.ToString(mySqlCommand.ExecuteScalar());
                        return ErrorENUM.INOK;//注册成功
                    }
                } catch {
                    return ErrorENUM.UNLNOWNERROR;//未知错误
                } finally {
                    if (mysqlconn != null) {
                        mysqlconn.Close();
                    }
                }
            } else {
                return iniSignMethod(Convert.ToInt32(tbId), pwd, ref NickName, ref LogonTime, ref LoginInfo);
            }
        }

        /// <summary>
        /// 登录方法
        /// <para>返回列表：</para>
        /// <para>登录错误</para>
        /// <para>ErrorENUM.LOGINERROR</para>
        /// <para>未知错误</para>
        /// <para>ErrorENUM.UNLNOWNERROR</para>
        /// <para>登录成功</para>
        /// <para>ErrorENUM.OK</para>
        /// </summary>
        /// <param name="id">输入的账号</param>
        /// <param name="pwd">输入的密码</param>
        /// <param name="NickName">返回的昵称</param>
        /// <param name="LogonTime">返回的注册日期</param>
        /// <param name="LoginInfo">返回登录状态</param>
        /// <returns></returns>
        public ErrorENUM iniSignMethod(int id, string pwd, ref string NickName, ref string LogonTime, ref bool LoginInfo) {
            MySqlConnection mysqlconn = null;
            MySqlCommand mySqlCommand = null;
            try {
                mysqlconn = new MySqlConnection(SqlMain.SqlInfo);
                mysqlconn.Open();
                mySqlCommand = new MySqlCommand(SqlMain.selectNickName(id, pwd), mysqlconn);
                try {
                    NickName = mySqlCommand.ExecuteScalar().ToString();
                } catch {
                }
                if (NickName != null) {
                    mySqlCommand = new MySqlCommand(SqlMain.selectLogonTime(id.ToString()), mysqlconn);
                    LogonTime = mySqlCommand.ExecuteScalar().ToString();
                    LoginInfo = true;
                    return ErrorENUM.OK;//登录成功
                } else {
                    return ErrorENUM.LOGINERROR;//登录错误
                }
            } catch (Exception err) {
                return ErrorENUM.UNLNOWNERROR;//未知错误
            } finally {
                if (mysqlconn != null) {
                    mysqlconn.Close();
                }
            }
        }

        /// <summary>
        /// 更新密码
        /// <para>返回列表：</para>
        /// <para>数据不存在</para>
        /// <para>ErrorENUM.NOONEINFO;</para>
        /// <para>复制表(%45)错误</para>
        /// <para>ErrorENUM.COPYFORGETERROR;</para>
        /// <para>更新失败</para>
        /// <para>ErrorENUM.UPDATEERRR;</para>
        /// <para>未知错误</para>
        /// <para>ErrorENUM.UNLNOWNERROR;</para>
        /// <para>更新成功</para>
        /// <para>ErrorENUM.UPOK;</para>
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="Email">邮箱</param>
        /// <param name="NickName">昵称</param>
        /// <param name="newPassword">新密码</param>
        /// <returns></returns>
        public ErrorENUM updatePassword(string id, string Email, string NickName, string newPassword) {
            string sql_ver = SqlMain.verIdAndEmail(id, Email, NickName);//查询条件是否符合
            string sql_forget = SqlMain.insertForget(id, Email, newPassword, DateTime.Now.ToString());//更新(%45)表
            string sql_update = SqlMain.updatePassword(newPassword, id, Email, NickName);//更新密码
            List<List<UserTable>> list = new List<List<UserTable>>();
            int index = 0;
            MySqlConnection conn = null;
            MySqlCommand comm = null;
            MySqlDataReader read = null;
            try {
                //阶段1
                conn = new MySqlConnection(SqlMain.SqlInfo);
                conn.Open();
                comm = new MySqlCommand(sql_ver, conn);
                read = comm.ExecuteReader();
                while (read.Read()) {
                    list.Add(new List<UserTable>());
                    list[index].Add(new UserTable(read[0], read[1], read[2], read[3], read[4]));
                    index++;
                }
                try {
                    read.Close();
                } catch (Exception) {
                }
                if (list.Count <= 0) {
                    return ErrorENUM.NOONEINFO;
                }
                //阶段2
                comm = new MySqlCommand(sql_forget, conn);
                int v = comm.ExecuteNonQuery();
                if (v <= 0) {
                    return ErrorENUM.COPYFORGETERROR;
                }
                //阶段3
                comm = new MySqlCommand(sql_update, conn);
                int v1 = comm.ExecuteNonQuery();
                if (v1 <= 0) {
                    return ErrorENUM.UPDATEERRR;
                }
                return ErrorENUM.UPOK;
            } catch {
                return ErrorENUM.UNLNOWNERROR;
            } finally {
                if (conn != null) {
                    conn.Close();
                }
            }
        }
    }
}
