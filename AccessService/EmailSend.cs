using System;

namespace AccessService {
    public class EmailSend {
        /// <summary>
        /// 发送邮件的实现类
        /// </summary>
        /// <param name="Email">收件人</param>
        /// <param name="theme">发件主题</param>
        /// <param name="content">邮件内容</param>
        /// <param name="pwd">发送密码</param>
        public static void send(string Email, string theme, string content, string pwd) {
            try {
                //smtp.163.com
                //string senderServerIp = "123.125.50.133";
                //smtp.gmail.com
                //string senderServerIp = "74.125.127.109";
                //smtp.qq.com
                string senderServerIp = "smtp.qq.com";//qq邮箱的smtp地址
                //string senderServerIp = "smtp.sina.com";
                string toMailAddress = Email;//收件人的邮箱地址
                string fromMailAddress = "2075383131@qq.com";//发件人的邮箱地址
                string subjectInfo = theme;//主题
                string bodyInfo = content;//内容
                string mailUsername = Email.Substring(0, Email.IndexOf('@'));//邮箱的用户名
                string mailPassword = pwd; //发送邮箱的密码
                string mailPort = "25";//端口
                //string attachPath = "E:\\123123.txt; E:\\haha.pdf";//添加的附件

                MyEmail email = new MyEmail(senderServerIp, toMailAddress, fromMailAddress, subjectInfo, bodyInfo, mailUsername, mailPassword, mailPort, true, true);
                //email.AddAttachments(attachPath);
                email.Send();
            } catch (Exception error) {
                WriteError.write(error.Message);
            }
        }
        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="Receiver">邮件接收人</param>
        /// <param name="Subject">邮件主题</param>
        /// <param name="content">邮件内容</param>  
        /// <param name="pwd">密码</param>
        public static void send2_(string Receiver, string Subject, string content, string pwd) {
            MyEmail.SendEmail(Receiver, Subject, content, pwd);
        }

    }
}
