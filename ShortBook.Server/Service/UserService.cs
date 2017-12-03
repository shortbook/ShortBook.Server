using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using ShortBook.Server.ViewModel.User;

namespace ShortBook.Server.Service
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public class UserService : ShortBookServiceBase, IUserService
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="model">用户注册模型</param>
        public void Register(RegisterModel model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model">用户登录模型</param>
        public void Login(LoginModel model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="id">用户Id</param>
        public void Logout(long id)
        {
            // TODO 调查Session怎么用
        }

        /// <summary>
        /// 修改登录口令
        /// </summary>
        /// <param name="model">修改登录口令模型</param>
        public void ChangePassword(ChangePasswordModel model)
        {
            throw new NotImplementedException();
        }

        private string GetMd5(string input)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
                var strResult = BitConverter.ToString(result);
                return strResult.Replace("-", "");
            }
        }
    }
}