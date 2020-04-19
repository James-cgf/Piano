using AccessService;
using MySql.Data.MySqlClient;
using System;

namespace LogicManager {
    public class NoticeALL {
        /// <summary>
        /// 返回公告文本
        /// </summary>
        /// <returns></returns>
        public static string noticeText() {
            string notice = "";
            MySqlConnection conn = null;
            MySqlCommand comm = null;
            string sql = SqlUnimportance.selectNotice();
            try {
                conn = new MySqlConnection(SqlMain.SqlInfo);
                conn.Open();
                comm = new MySqlCommand(sql, conn);
                notice = Convert.ToString(comm.ExecuteScalar());
            } catch (Exception) {

            }
            return notice;
        }
        /// <summary>
        /// 获取更新
        /// </summary>
        /// <returns></returns>
        public static string edition() {
            string ed = "";

            MySqlConnection conn = null;
            MySqlCommand comm = null;
            string sql = SqlUnimportance.selectEdition();
            try {
                conn = new MySqlConnection(SqlMain.SqlInfo);
                conn.Open();
                comm = new MySqlCommand(sql, conn);
                ed = Convert.ToString(comm.ExecuteScalar());
            } catch (Exception) {

            }

            return ed;
        }
    }
}
