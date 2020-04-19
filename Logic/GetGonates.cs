using System;
using System.Collections.Generic;
using System.Text;
using AccessService;
using MySql.Data.MySqlClient;

namespace LogicManager {
    public class GetGonates {
        /// <summary>
        /// 以捐献金额为准，从高到低获取所有的捐献这的ID:捐献金额
        /// </summary>
        ///  <returns>捐献者ID:捐献金额</returns>
        public static Dictionary<object, object> getDonateID() {
            Dictionary<object, object> dic = new Dictionary<object, object>();
            MySqlConnection conn = null;
            MySqlCommand comm = null;
            MySqlDataReader read = null;

            try {
                conn = new MySqlConnection(SqlMain.SqlInfo);
                conn.Open();
                comm = new MySqlCommand(SqlMain.getDonaceIdAndMoney(), conn);
                read = comm.ExecuteReader();
                while (read.Read()) {
                    dic.Add(read[0].ToString(), read[1].ToString());
                }
            } catch {

            }
            return dic;
        }
        /// <summary>
        /// 以捐献金额为准，从高到低获取指定数量的捐献者ID:捐献金额
        /// </summary>
        /// <returns>捐献者ID:捐献金额</returns>
        public static Dictionary<object, object> getDonateID(int count) {
            Dictionary<object, object> dic = new Dictionary<object, object>();
            MySqlConnection conn = null;
            MySqlCommand comm = null;
            MySqlDataReader read = null;
            try {
                conn = new MySqlConnection(SqlMain.SqlInfo);
                conn.Open();
                comm = new MySqlCommand(SqlMain.getDonaceIdAndMoney(), conn);
                read = comm.ExecuteReader();
                int index = 0;
                while (read.Read()) {
                    dic.Add(read[0].ToString(), read[1].ToString());
                    index++;
                    if (index == count) {
                        break;
                    }
                }
            } catch {

            }
            return dic;
        }
        //---------------
        /// <summary>
        /// 以捐献金额为准，从高到低获取指定数量的捐献者邮箱
        /// </summary>
        ///  <returns>捐献者ID:捐献金额</returns>
        public static Dictionary<object, object> getDonateEmail() {
            Dictionary<object, object> dic = new Dictionary<object, object>();
            MySqlConnection conn = null;
            MySqlCommand comm = null;
            MySqlDataReader read = null;

            try {
                conn = new MySqlConnection(SqlMain.SqlInfo);
                conn.Open();
                comm = new MySqlCommand(SqlMain.getDonaceEmail(), conn);
                read = comm.ExecuteReader();
                while (read.Read()) {
                    dic.Add(read[0].ToString(), read[1].ToString());
                }
            } catch {

            }
            return dic;
        }
        /// <summary>
        /// 以捐献金额为准，从高到低获取指定数量的捐献者邮箱
        /// </summary>
        /// <returns>捐献者ID:捐献金额</returns>
        public static List<object> getDonateEmail(int count) {
            List<object> list = new List<object>();
            MySqlConnection conn = null;
            MySqlCommand comm = null;
            MySqlDataReader read = null;
            try {
                conn = new MySqlConnection(SqlMain.SqlInfo);
                conn.Open();
                comm = new MySqlCommand(SqlMain.getDonaceEmail(), conn);
                read = comm.ExecuteReader();
                int index = 0;
                while (read.Read()) {
                    list.Add(read[0].ToString());
                    index++;
                    if (index == count) {
                        break;
                    }
                }
            } catch {

            }
            return list;
        }
    }
}
