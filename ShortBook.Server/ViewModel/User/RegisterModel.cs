using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// 姓
        /// </summary>
        [Required]
        public string LastName { get; set; }

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