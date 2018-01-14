using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShortBook.Server.Domain.User
{
    /// <summary>
    /// 用户
    /// </summary>
    [Table("User")]
    public class User : Entity
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

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime LogonDate { get; set; }

        /// <summary>
        /// 验证用户信息
        /// </summary>
        public void Validate()
        {
            // TODO 验证用户信息
            
        }
    }
}