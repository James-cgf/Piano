using System;

namespace LogicManager {
    public class IniWindowsSize {
        private int x;
        private int y;
        /// <summary>
        /// 获取屏幕分辨率X
        /// </summary>
        /// <returns></returns>
        public int getX() {
            return x;
        }
        /// <summary>
        /// 获取屏幕分辨率Y
        /// </summary>
        /// <returns></returns>
        public int getY() {
            return y;
        }
        private void setX(int x) {
            this.x = x;
        }
        private void setY(int y) {
            this.y = y;
        }
        /// <summary>
        /// 判断分辨率是否于预期相等
        /// </summary>
        /// <returns></returns>
        public bool windowsSize(int x, int y) {
            setX(System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width);//获取显示器屏幕宽度
            setY(System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height);//高度
            if (getX() != x || getY() != y) {
                return false;
            } else {
                return true;
            }
        }
    }
}
