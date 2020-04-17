namespace LogicManager {
    public enum ErrorENUM {
        /// <summary>
        /// 数据为空
        /// </summary>
        NULL,
        /// <summary>
        /// 已存在
        /// </summary>
        ALREADYEXIST,
        /// <summary>
        /// 登录错误
        /// <para>1.账号错误</para>
        /// <para>2.密码错误</para>
        /// </summary>
        LOGINERROR,
        /// <summary>
        /// 未知错误
        /// </summary>
        UNLNOWNERROR,
        /// <summary>
        /// 复制信息到(%45)错误
        /// </summary>
        COPYFORGETERROR,
        /// <summary>
        /// 没有一个符合的信息
        /// </summary>
        NOONEINFO,
        /// <summary>
        /// 邮件发送失败
        /// </summary>
        EMAILERROR,
        /// <summary>
        /// 登录成功
        /// </summary>
        OK,
        /// <summary>
        /// 注册成功
        /// </summary>
        INOK,
        /// <summary>
        /// 更新成功
        /// </summary>
        UPOK,
        /// <summary>
        /// 更新密码失败
        /// </summary>
        UPDATEERRR,
    }
}
