using System.ComponentModel.DataAnnotations;

namespace ShortBook.Server.ViewModel.Login
{
    /// <summary>
    /// 用户登录模型
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 电子邮件
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// 登录口令
        /// </summary>
        [Required]
        [StringLength(64)]
        public string Password { get; set; }
    }
}