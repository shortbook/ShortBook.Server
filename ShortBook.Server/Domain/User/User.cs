using ShortBook.Server.Exception;
using ShortBook.Server.Repository;

namespace ShortBook.Server.Domain.User
{
    public class User : Entity
    {
        private readonly IUserRepository _repository;

        public User()
        {
            _repository = RepositoryFactory.Create<IUserRepository>();
        }
        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public User Login(string username, string password)
        {
            return _repository.Get(username, password);
        }

        public void Register(User user)
        {
            _repository.Add(user);
        }

        public void ChangePassword(string newPassword)
        {
            if (string.CompareOrdinal(Password, newPassword) == 0)
            {
                throw new ShortBookServerException("新密码不能与旧密码相同。");
            }
            _repository.Modify(this);
        }
    }
}