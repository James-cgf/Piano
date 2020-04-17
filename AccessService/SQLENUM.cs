namespace AccessService {
    /// <summary>
    /// 定义了查询的类型
    /// </summary>
    public enum SQLENUM {
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
    }
}
