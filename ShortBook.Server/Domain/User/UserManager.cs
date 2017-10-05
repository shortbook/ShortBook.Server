using ShortBook.Server.Repository;

namespace ShortBook.Server.Domain.User
{
    public class UserManager
    {
        private readonly IUserRepository _repository;

        public UserManager(IUserRepository repository)
        {
            _repository = repository;
        }

        public User Login(string username, string password)
        {
            return _repository.Get(username, password);
        }

        public void Register(User user)
        {
            _repository.Add(user);
        }
    }
}