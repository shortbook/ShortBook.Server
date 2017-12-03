namespace ShortBook.Server.ViewModel.User
{
    /// <summary>
    /// 修改登录口令模型
    /// </summary>
    public class ChangePasswordModel
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 旧口令
        /// </summary>
        public string OldPassword { get; set; }

        /// <summary>
        /// 新口令
        /// </summary>
        public string NewPassword { get; set; }
    }
}