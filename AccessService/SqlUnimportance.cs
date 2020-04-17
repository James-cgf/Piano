namespace AccessService {
    public class SqlUnimportance {
        /// <summary>
        /// 返回查询最后一行公告
        /// </summary>
        /// <returns></returns>
        public static string selectNotice() {
            return enumIMPLMethod(SQLUNIMPORTANCEENUM.NOTICELASTLINK);
        }

        /// <summary>
        /// 返回查询版本号
        /// </summary>
        /// <returns></returns>
        public static string selectEdition() {
            return enumIMPLMethod(SQLUNIMPORTANCEENUM.EDITION);
        }
        /// <summary>
        /// 返回当前版本号
        /// </summary>
        /// <returns></returns>
        public static string selectNowEdition() {
            return enumIMPLMethod(SQLUNIMPORTANCEENUM.VERSION);
        }

        /// <summary>
        /// 枚举实现
        /// </summary>
        /// <param name="sQLUNIMPORTANCEENUM"></param>
        /// <returns></returns>
        private static string enumIMPLMethod(SQLUNIMPORTANCEENUM sQLUNIMPORTANCEENUM) {
            string type = "";
            switch (sQLUNIMPORTANCEENUM) {
                case SQLUNIMPORTANCEENUM.NOTICELASTLINK:
                    type = SQLUnimportanceResources.NOTICELASTLINK;
                    break;
                case SQLUNIMPORTANCEENUM.EDITION:
                    type = SQLUnimportanceResources.EDITION;
                    break;
                case SQLUNIMPORTANCEENUM.VERSION:
                    type = SQLUnimportanceResources.VERSION;
                    break;
            }
            return type;
        }
    }
}
