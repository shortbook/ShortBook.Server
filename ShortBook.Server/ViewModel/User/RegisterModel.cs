namespace ShortBook.Server.ViewModel.User
{
    /// <summary>
    /// 用户注册模型
    /// </summary>
    public class RegisterModel
    {
        /// <summary>
        /// 名
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 姓
        /// </summary>
        public string LastName { get; set; }

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