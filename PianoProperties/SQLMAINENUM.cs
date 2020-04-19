namespace AccessService {
    /// <summary>
    /// 定义了查询的类型
    /// </summary>
    public enum SQLMAINENUM {
        /// <summary>
        /// 查询昵称
        /// </summary>
        SELECTNICKNAME,
        /// <summary>
        /// 注册用户
        /// </summary>
        INSERT,
        /// <summary>
        /// 查询ID
        /// </summary>
        SELECTID,
        /// <summary>
        /// 查询邮箱
        /// </summary>
        SELECTEMAIL,
        /// <summary>
        /// 查询注册日期
        /// </summary>
        SELECTLOGONTIME,
        /// <summary>
        /// 公告
        /// </summary>
        NOTICE,
        /// <summary>
        /// 更新消息
        /// </summary>
        VERSIONS,
        /// <summary>
        /// 不可说
        /// </summary>
        EMAIL,
        /// <summary>
        /// 连接服务器
        /// </summary>
        SQLINFO,
        /// <summary>
        /// 登录
        /// </summary>
        SIGNIN,
        /// <summary>
        /// 查询符合条件的Id,NickName和Email
        /// </summary>
        VERIDANDEMAIL,
        /// <summary>
        /// 存入原(%45)新表
        /// </summary>
        INSERTFORGET,
        /// <summary>
        /// 更新密码
        /// </summary>
        UPDATEPWD,
        /// <summary>
        /// 获取排行
        /// </summary>
        GETDONATEIDANDMONEY,
        /// <summary>
        /// 获取排行的邮箱，从大到小排行邮箱
        /// </summary>
        GETDONATEEMAIL,
    }
}
