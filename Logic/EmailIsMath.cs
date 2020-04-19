using System.Text.RegularExpressions;

namespace LogicManager {
    public class EmailIsMath {
        /// <summary>
        /// 判断字符串是否符合格式
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="patern">正则表达式</param>
        /// <returns></returns>
        public static bool emailIsMath(string str, string patern) {
            return Regex.IsMatch(str, patern);
        }
    }
}
