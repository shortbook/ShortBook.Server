using System;
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
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="model">用户注册模型</param>
        public void Register(RegisterModel model)
        {
            IUserRepository repo = RepositoryFactory.Create<IUserRepository>();
            if (repo.EmailRegistered(model.Email))
            {
                throw new ShortBookServerException("该邮箱已经注册，请登录。");
            }

            User user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
                LogonDate = DateTime.Now
            };
            user.Validate();
            repo.AddUser(user);
        }

        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserInfoModel GetUserInfo(long id)
        {
            IUserRepository repo = RepositoryFactory.Create<IUserRepository>();
            var user = repo.GetUser(id);
            return new UserInfoModel
            {
                Id = user.Id,
                Name = string.Format("{0} {1}", user.LastName, user.FirstName),
                LogonDate = user.LogonDate.Date
            };
        }
    }
}