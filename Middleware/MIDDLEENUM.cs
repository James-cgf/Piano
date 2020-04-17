namespace Middleware {
    /// <summary>
    /// 解读逻辑层下的Signin的singinMethod的返回值
    /// </summary>
    public enum MIDDLEENUM {
        //登录注册
        内容不允许为空,
        邮箱已存在,
        发送邮件错误,
        账号或密码错误,
        未知错误,
        登录成功,
        注册成功,
        //找回密码
        数据不存在,
        复制表_45错误,
        更新密码失败,
        更新密码成功,
    }
}
