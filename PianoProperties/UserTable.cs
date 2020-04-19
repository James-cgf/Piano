using System;

namespace AccessService {
    /// <summary>
    /// 临时存放，垃圾回收机制
    /// </summary>
    public class UserTable {
        public Object Id { get; set; }
        public Object NickName { get; set; }
        public Object Email { get; set; }
        public Object Password { get; set; }
        public Object JoinTime { get; set; }

        public UserTable(object id, object nickName, object email, object password, object joinTime) {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            NickName = nickName ?? throw new ArgumentNullException(nameof(nickName));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            JoinTime = joinTime ?? throw new ArgumentNullException(nameof(joinTime));
        }

        public UserTable() {
        }
    }
}
