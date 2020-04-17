using System;
using System.Collections.Generic;
using System.Text;

namespace Middleware {
    public class ParseString {
        /// <summary>
        /// 解析语句
        /// <para>抛出异常原因有：</para>
        /// <pare>1.数组长度与查找的语句字符数量不一致</pare>
        /// </summary>
        /// <param name="replace"></param>
        /// <param name="character"></param>
        /// <returns></returns>
        public static string parse(string origStr, string[] replace, char character) {
            string str = null;
            string s = null;
            int index = 0;
            foreach (char item in origStr) {
                if (item.Equals(character)) {
                    s = replace[index];
                    index++;
                } else {
                    s = item.ToString();
                }
                str += s;
            }
            return str;
        }
    }
}
