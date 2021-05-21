using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using ShortBook.Server.Domain.User;
using ShortBook.Server.Exceptions;
using ShortBook.Server.Repository;
using ShortBook.Server.ViewModel.Login;

namespace ShortBook.Server.Service
{
    /// <summary>
    /// Login service
    /// </summary>
    public class LoginService : ShortBookServiceBase, ILoginService
    {
        private const string LoginInfo = "user";

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model">用户登录模型</param>
        public void Login(LoginModel model)
        {
            if (Context.Session.Keys.Contains(LoginInfo))
            {
                // TODO 单点登录验证
                throw new ShortBookServerUnauthorizedException("用户已经登录，不允许重复登录。");
            }

            IUserRepository repo = RepositoryFactory.Create<IUserRepository>();
            User user = repo.GetUser(model.Email);
            if (user == null)
            {
                throw new ShortBookServerUnauthorizedException("用户登录名或登录口令错误，请确认。");
            }

            user.Login(model.Password);
            Context.Session.SetObject(LoginInfo, user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, string.Format("{0} {1}", user.LastName, user.FirstName))
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);
            Context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="id">用户Id</param>
        public void Logout(long id)
        {
            Context.Session.Remove(LoginInfo);
            Context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        /// <summary>
        /// 修改登录口令
        /// </summary>
        /// <param name="model">修改登录口令模型</param>
        public void ChangePassword(ChangePasswordModel model)
        {
            throw new NotImplementedException();
        }
    }
}