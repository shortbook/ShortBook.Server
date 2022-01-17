using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using ShortBook.Server.Exceptions;
using ShortBook.Server.Properties;

namespace ShortBook.Server.Domain.User
{
    /// <summary>
    /// 用户
    /// </summary>
    [Table("User")]
    public class User : AutoIdEntity
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
        /// 登录口令
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime LogonDate { get; set; }
        
        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 验证用户信息
        /// </summary>
        public void Validate()
        {
            // TODO 验证用户信息
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="password"></param>
        public void Login(string password)
        {
            var saltPassword = (password + Resources.Salt).Substring(0, 64);
            using SHA512 shaM = SHA512.Create();
            var hash = shaM.ComputeHash(Encoding.Unicode.GetBytes(saltPassword));
            var hashedInputStringBuilder = new StringBuilder(128);
            foreach (var b in hash)
            {
                hashedInputStringBuilder.Append(b.ToString("X2"));
            }

            var sha512Password = hashedInputStringBuilder.ToString();
            if (sha512Password != Password)
            {
                throw new ShortBookServerUnauthorizedException("用户登录名或登录口令错误，请确认。");
            }
        }
    }
}