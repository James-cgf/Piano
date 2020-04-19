using LogicManager;
using System;

namespace Middleware {
    /// <summary>
    /// 用户缓冲逻辑层的数据
    /// </summary>
    public class LogonMiddle {
        /// <summary>
        /// 返回注册的ID
        /// </summary>
        public string reId { get; set; } = "ERROR";

        private MIDDLEENUM middleSignin(ErrorENUM errorEnum, Signin signin) {
            MIDDLEENUM notice = new MIDDLEENUM();
            switch (errorEnum) {
                case ErrorENUM.NULL:
                    notice = MIDDLEENUM.内容不允许为空;
                    break;
                case ErrorENUM.ALREADYEXIST:
                    notice = MIDDLEENUM.邮箱已存在;
                    break;
                case ErrorENUM.LOGINERROR:
                    notice = MIDDLEENUM.账号或密码错误;
                    break;
                case ErrorENUM.UNLNOWNERROR:
                    notice = MIDDLEENUM.未知错误;
                    break;
                case ErrorENUM.OK:
                    notice = MIDDLEENUM.登录成功;
                    break;
                case ErrorENUM.INOK:
                    this.reId = signin.reId;
                    notice = MIDDLEENUM.注册成功;
                    break;
                default:
                    break;
            }
            return notice;
        }
        private MIDDLEENUM middleSignin(ErrorENUM errorEnum) {
            MIDDLEENUM notice = new MIDDLEENUM();
            switch (errorEnum) {
                case ErrorENUM.LOGINERROR:
                    notice = MIDDLEENUM.账号或密码错误;
                    break;
                case ErrorENUM.UNLNOWNERROR:
                    notice = MIDDLEENUM.未知错误;
                    break;
                case ErrorENUM.OK:
                    notice = MIDDLEENUM.登录成功;
                    break;
                default:
                    break;
            }
            return notice;
        }

        private MIDDLEENUM forgetPWD(ErrorENUM errorEnum) {
            MIDDLEENUM notice = new MIDDLEENUM();
            switch (errorEnum) {
                case ErrorENUM.LOGINERROR:
                    notice = MIDDLEENUM.更新密码失败;
                    break;
                case ErrorENUM.UNLNOWNERROR:
                    notice = MIDDLEENUM.未知错误;
                    break;
                case ErrorENUM.UPOK:
                    notice = MIDDLEENUM.更新密码成功;
                    break;
                case ErrorENUM.COPYFORGETERROR:
                    notice = MIDDLEENUM.复制表_45错误;
                    break;
                default:
                    break;
            }
            return notice;
        }
        /// <summary>
        /// 登录或注册方法
        /// </summary>
        /// <param name="tbId">ID的文本框</param>
        /// <param name="tbPwd">密码文本框</param>
        /// <param name="tbEmail">邮箱文本框</param>
        /// <param name="loginOrLogon">[false/true]登录还是注册</param>
        /// <param name="NickName">昵称</param>
        /// <param name="LogonTime">登录时间</param>
        /// <param name="LoginInfo">登录状态</param>
        /// <returns>字符串</returns>
        public MIDDLEENUM unscrambleSigninToLogin(string tbId, string tbPwd, string tbEmail, bool loginOrLogon, ref string NickName, ref string LogonTime, ref bool LoginInfo) {
            Signin signin = new Signin();
            MIDDLEENUM mess = middleSignin(signin.signinMethod(tbId, tbPwd, tbEmail, loginOrLogon, ref NickName, ref LogonTime, ref LoginInfo), signin);
            return mess;
        }
        /// <summary>
        /// 登录方法
        /// </summary>
        /// <param name="id">账号</param>
        /// <param name="pwd">密码</param>
        /// <param name="NickName">昵称</param>
        /// <param name="LogonTime">登录时间</param>
        /// <param name="LoginInfo">登录状态</param>
        /// <returns></returns>
        public MIDDLEENUM unscrambleSigninToLogin(int id, string pwd, ref string NickName, ref string LogonTime, ref bool LoginInfo) {
            MIDDLEENUM mess = middleSignin(new Signin().iniSignMethod(id, pwd, ref NickName, ref LogonTime, ref LoginInfo));
            return mess;
        }

        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Email"></param>
        /// <param name="NickName"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public MIDDLEENUM forgetPassword(string id, string Email, string NickName, string newPassword) {
            MIDDLEENUM mess = forgetPWD(new Signin().updatePassword(id, Email, NickName, newPassword));
            return mess;
        }
    }
}
