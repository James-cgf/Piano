namespace LogicManager {
    public class LimitKey {
        /// <summary>
        /// 限制文本框只能输入数字
        /// </summary>
        /// <param name="sender">文本框</param>
        /// <param name="e">按下按键</param>
        /// <param name="loginOrLogon">状态</param>
        public static void limitKey(System.Windows.Forms.TextBox sender, System.Windows.Forms.KeyPressEventArgs e) {
            if (e.KeyChar == 0x20)
                e.KeyChar = (char)0;  //禁止空格键
            if ((e.KeyChar == 0x2D) && ((sender).Text.Length == 0))
                return;   //处理负数
            if (e.KeyChar > 0x20) {
                try {
                    double.Parse((sender).Text + e.KeyChar.ToString());
                } catch {
                    e.KeyChar = (char)0;   //处理非法字符
                }
            }
        }
    }
}
