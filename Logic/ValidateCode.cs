using System;

namespace LogicManager {
    /// <summary>
    /// 验证码生成类
    /// </summary>
    public class ValidCode {
        private static Random random = new Random();
        //150个颜色对照表
        private static string[] color_str = new string[] {
            "#171717",      "#141414",      "#121212",      "#104E8B",
            "#0F0F0F",      "#0D0D0D",      "#0A0A0A",      "#080808",
            "#050505",      "#030303",      "#00FFFF",      "#00FF7F",
            "#00FF00",      "#00FA9A",      "#00F5FF",      "#00EEEE",
            "#00EE76",      "#00EE00",      "#00E5EE",      "#00CED1",
            "#00CDCD",      "#00CD66",      "#00CD00",      "#00C5CD",
            "#00BFFF",      "#00B2EE",      "#009ACD",      "#008B8B",
            "#008B45",      "#008B00",      "#00868B",      "#00688B",
            "#006400",      "#0000FF",      "#0000EE",      "#0000CD",
            "#0000AA",      "#7B68EE",      "#7AC5CD",      "#7A8B8B",
            "#7A67EE",      "#7A378B",      "#79CDCD",      "#787878",
            "#778899",      "#76EEC6",      "#76EE00",      "#757575",
            "#737373",      "#71C671",      "#7171C6",      "#708090",
            "#707070",      "#6E8B3D",      "#6E7B8B",      "#6E6E6E",
            "#6CA6CD",      "#6C7B8B",      "#6B8E23",      "#6B6B6B",
            "#6A5ACD",      "#698B69",      "#698B22",      "#696969",
            "#6959CD",      "#68838B",      "#68228B",      "#66CDAA",
            "#66CD00",      "#668B8B",      "#666666",      "#6495ED",
            "#B4EEB4",      "#B4CDCD",      "#B452CD",      "#B3EE3A",
            "#B3B3B3",      "#B2DFEE",      "#B23AEE",      "#B22222",
            "#B0E2FF",      "#B0E0E6",      "#B0C4DE",      "#B0B0B0",
            "#B03060",      "#AEEEEE",      "#ADFF2F",      "#ADD8E6",
            "#ADADAD",      "#ABABAB",      "#AB82FF",      "#AAAAAA",
            "#A9A9A9",      "#A8A8A8",      "#A6A6A6",      "#A52A2A",
            "#A4D3EE",      "#A3A3A3",      "#A2CD5A",      "#A2B5CD",
            "#A1A1A1",      "#A0522D",      "#A020F0",      "#9FB6CD",
            "#9F79EE",      "#9E9E9E",      "#9C9C9C",      "#9BCD9B",
            "#9B30FF",      "#9AFF9A",      "#9ACD32",      "#9AC0CD",
            "#9A32CD",      "#999999",      "#9932CC",      "#98FB98",
            "#98F5FF",      "#97FFFF",      "#96CDCD",      "#969696",
            "#949494",      "#FFC1C1",      "#FFC125",      "#FFC0CB",
            "#FFB90F",      "#FFB6C1",      "#FFB5C5",      "#FFAEB9",
            "#FFA54F",      "#FFA500",      "#FFA07A",      "#FF8C69",
            "#FF8C00",      "#FF83FA",      "#FF82AB",      "#FF8247",
            "#FF7F50",      "#FF7F24",      "#FF7F00",      "#FF7256",
            "#FF6EB4",      "#FF6A6A",      "#FF69B4",      "#FF6347",
            "#FF4500",      "#FF4040",      "#FF3E96",      "#FF34B3",
            "#EEE8AA",      "#EEE685"
        };
        //不能有数字0和字母O,34个
        private static Object[] code = new Object[] {
            1,2,3,4,5,6,7,8,9,
            "a","b","c","d","e","f","g","h","i","j","k","l","m","n","p","q","r","s","t","u","v","w","x","y","z"
        };
        private int count;
        public ValidCode(int count) {
            this.count = count;
        }
        /// <summary>
        /// 验证码
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public string[] validCode() {
            string[] ra = new string[count];
            for (int i = 0; i < count; i++) {
                ra[i] = code[(random.Next(0, 33))].ToString();
            }
            return ra;
        }
        /// <summary>
        /// 随机颜色
        /// </summary>
        /// <returns></returns>
        public string[] color() {
            string[] str = new string[count];
            for (int i = 0; i < count; i++) {
                int a = random.Next(0, 149);
                str[i] = color_str[a];
            }
            return str;
        }
    }
}