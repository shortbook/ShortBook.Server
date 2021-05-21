using Dapper;
using ShortBook.Server.Domain.User;

namespace ShortBook.Server.Repository.Npgsql
{
    /// <summary>
    /// 用户存储
    /// </summary>
    public class UserRepository : NpgsqlRepository,  IUserRepository
    {
        static UserRepository()
        {
            SqlMapper.SetTypeMap(typeof(User), new CustomPropertyTypeMap(typeof(User), (type, name) =>
            {
                switch (name)
                {
                    case "id": return type.GetProperty("Id");
                    case "first_name": return type.GetProperty("FirstName");
                    case "last_name": return type.GetProperty("LastName");
                    case "password": return type.GetProperty("Password");
                    case "logon_date": return type.GetProperty("LogonDate");
                    case "email": return type.GetProperty("Email");
                    default: return type.GetProperty(name);
                }
            }));
        }
        
        /// <summary>
        /// 添加一个用户
        /// </summary>
        /// <param name="user">新用户</param>
        public void AddUser(User user)
        {
            using (var conn = CreateConnection())
            {
                conn.Execute("INSERT INTO t_user (first_name, last_name, password, logon_date, email) VALUES (@FirstName, @LastName, @Password, @LogonDate, @Email); ", user);
            }
        }

        /// <summary>
        /// 判断电子邮件地址是否已经被注册
        /// </summary>
        /// <param name="email">电子邮件地址</param>
        /// <returns>如果已经被注册，则返回true；否则返回false。</returns>
        public bool EmailRegistered(string email)
        {
            using (var conn = CreateConnection())
            {
                return conn.ExecuteScalar<int>("SELECT COUNT(id) FROM t_user WHERE email = @Email", new {Email = email}) > 0;
            }
        }

        /// <summary>
        /// 获取指定Id的用户
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <returns>如果存在指定Id的用户，则返回该用户对象；否则返回null。</returns>
        public User GetUser(long id)
        {
            using (var conn = CreateConnection())
            {
                return conn.QuerySingle<User>("SELECT * FROM t_user WHERE id = @Id", new {Id = id});
            }
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="email">电子邮件地址</param>
        /// <returns>如果存在符合指定电子邮件和登录口令的用户，则返回该用户对象；否则返回null。</returns>
        public User GetUser(string email)
        {
            using (var conn = CreateConnection())
            {
                return conn.QueryFirst<User>("SELECT * FROM t_user WHERE email = @Email", new {Email = email});
            }
        }

        /// <summary>
        /// 更新用户的登录口令
        /// </summary>
        /// <param name="user">待更新用户</param>
        public void SetPassword(User user)
        {
            using (var conn = CreateConnection())
            {
                conn.Execute("UPDATE t_user SET password = @Password WHERE id = @Id", user);
            }
        }
    }
}