using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ShortBook.Server.Domain.User;
using ShortBook.Server.Exceptions;
using ShortBook.Server.Repository;
using ShortBook.Server.ViewModel.User;

namespace ShortBook.Server.Service
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public class UserService : ShortBookServiceBase, IUserService
    {
        private const string LOGIN_INFO = "user";

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="model">用户注册模型</param>
        public void Register(RegisterModel model)
        {
            try
            {
                IUserRepository repo = RepositoryFactory.Create<IUserRepository>();
                if (repo.EmailRegistered(model.Email))
                {
                    throw new ShortBookServerException("");
                }
                User user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = GetMd5(model.Password),
                    LogonDate = DateTime.Now
                };
                user.Validate();
                repo.AddUser(user);
            }
            catch (ShortBookServerException)
            {
                throw;
            }
            catch (Exception ex)
            {
                // TODO NLog
                throw new ShortBookServerException("用户注册过程中发生意外错误。", ex);
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model">用户登录模型</param>
        public void Login(LoginModel model)
        {
            try
            {
                if (Context.Session.Keys.Contains(LOGIN_INFO))
                {
                    // TODO 单点登录验证
                    throw new ShortBookServerUnauthorizedException("用户已经登录，不允许重复登录。");
                }

                IUserRepository repo = RepositoryFactory.Create<IUserRepository>();
                User user = repo.GetUser(model.Email, GetMd5(model.Password));
                Context.Session.SetObject(LOGIN_INFO, user);
            }
            catch (ShortBookServerException)
            {
                throw;
            }
            catch (Exception ex)
            {
                // TODO NLog
                throw new ShortBookServerException("用户登录名或登录口令错误，请确认。", ex);
            }   
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="id">用户Id</param>
        public void Logout(long id)
        {
            Context.Session.Remove(LOGIN_INFO);
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