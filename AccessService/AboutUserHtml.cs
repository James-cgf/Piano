using System;

namespace AccessService {
    public class AboutUserHtml {
        public static string aboutUser(string NickName, string logonTime) {
            int day_ = 24 * 60 * 60;
            int hour_ = 60 * 60;
            int minute_ = 60;
            DateTime dt1 = DateTime.Parse(logonTime);
            DateTime dt2 = DateTime.Parse(DateTime.Now.ToString());
            TimeSpan ts1 = new TimeSpan(dt1.Ticks);
            TimeSpan ts2 = new TimeSpan(dt2.Ticks);
            TimeSpan ts3 = ts2.Subtract(ts1); //ts2-ts1
            int sumSeconds = int.Parse(ts3.TotalSeconds.ToString()); //得到相差秒数
            int day = sumSeconds / day_;
            int hour = (sumSeconds - (day * day_)) / hour_;
            int minute = (sumSeconds - (day * day_) - (hour * hour_)) / minute_;
            int second = (sumSeconds - (day * day_) - (hour * hour_) - (minute * minute_));
            string time = day + "天" + hour + "小时" + minute + "分钟" + second + "秒";
            return "<!DOCTYPE html>\n" +
                    "<html lang=\"en\">\n" +
                    "\n" +
                    "<head>\n" +
                    "    <meta charset=\"UTF-8\">\n" +
                    "    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n" +
                    "    <title>AboutUser</title>\n" +
                    "    <style>\n" +
                    "        body {\n" +
                    "            margin: 0;\n" +
                    "            padding: 0;\n" +
                    "            text-align: center;\n" +
                    "        }\n" +
                    "    </style>\n" +
                    "</head>\n" +
                    "\n" +
                    "<body>\n" +
                    "    " + NickName + " <br>\n" +
                    "    您的信息如下：<br>\n" +
                    "    昵称：" + NickName + "<br>\n" +
                    "    注册日期：" + logonTime + "<br>\n" +
                    "    使用时长：" + time + "<br>\n" +
                    "使用TimeSpan计算时间<br>\n" +
                    "</body>\n" +
                    "\n" +
                    "</html>";
        }
    }
}
