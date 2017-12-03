namespace ShortBook.Server.ViewModel.User
{
    /// <summary>
    /// 用户登录模型
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 登录口令
        /// </summary>
        public string Password { get; set; }
    }
}