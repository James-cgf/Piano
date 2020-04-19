using AccessService;
using MySql.Data.MySqlClient;
using System;

namespace LogicManager {
    /// <summary>
    /// 主方法的杂物
    /// </summary>
    public class Impurity : ImpurityIMPL {
        /// <summary>
        /// 当前版本号
        /// </summary>
        public string nowEdition() {
            return SqlUnimportance.selectNowEdition();
        }
        /// <summary>
        /// 获取数据库版本号
        /// </summary>
        /// <returns></returns>
        public string getEdition() {
            string ed = "1.0.0.0";
            //sql语句
            string sql = SqlUnimportance.selectEdition();
            //读取当前版本号
            string nowEdition = SqlUnimportance.selectNowEdition();
            //获取数据库版本号
            MySqlConnection conn = null;
            MySqlCommand comm = null;
            try {
                conn = new MySqlConnection(SqlMain.SqlInfo);
                conn.Open();
                comm = new MySqlCommand(sql, conn);
                ed = Convert.ToString(comm.ExecuteScalar());
            } catch {

            }
            return ed;
        }
        /// <summary>
        /// 比较是否需要升级
        /// <para>需要升级返回true</para>
        /// <para>不需要返回false</para>
        /// </summary>
        /// <param name="nowEdition">当前版本号</param>
        /// <param name="Edtion">数据版本号</param>
        /// <returns>是否需要升级</returns>
        public bool compareEditon(string nowEdition, string Edtion) {
            bool compare = false;
            char[] a = nowEdition.ToCharArray();
            char[] b = Edtion.ToCharArray();
            for (int i = 0; i < a.Length; i++) {
                if (a[i] < b[i]) {
                    compare = true;
                    break;
                } else {
                    compare = false;
                }
            }
            return compare;
        }
    }
}
