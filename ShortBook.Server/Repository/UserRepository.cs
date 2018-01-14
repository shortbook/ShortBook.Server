using ShortBook.Server.Domain.User;
using System.Linq;

namespace ShortBook.Server.Repository
{
    /// <summary>
    /// 用户存储
    /// </summary>
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        /// <summary>
        /// 添加一个用户
        /// </summary>
        /// <param name="user">新用户</param>
        public void AddUser(User user)
        {
            Add(user);
        }

        /// <summary>
        /// 判断电子邮件地址是否已经被注册
        /// </summary>
        /// <param name="email">电子邮件地址</param>
        /// <returns>如果已经被注册，则返回true；否则返回false。</returns>
        public bool EmailRegistered(string email)
        {
            return Entities.Any(e => e.Email == email);
        }

        /// <summary>
        /// 获取指定Id的用户
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <returns>如果存在指定Id的用户，则返回该用户对象；否则返回null。</returns>
        public User GetUser(long id)
        {
            return Get(id);
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="email">电子邮件地址</param>
        /// <param name="password">登录口令</param>
        /// <returns>如果存在符合指定电子邮件和登录口令的用户，则返回该用户对象；否则返回null。</returns>
        public User GetUser(string email, string password)
        {
            return Entities.FirstOrDefault(e =>
                e.Email == email &&
                e.Password == password);
        }

        /// <summary>
        /// 更新用户的登录口令
        /// </summary>
        /// <param name="user">待更新用户</param>
        public void SetPassword(User user)
        {
            Entities.Attach(user).Property(u => u.Password).IsModified = true;
            SaveChanges();
        }
    }
}