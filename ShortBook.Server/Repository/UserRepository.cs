using ShortBook.Server.Domain.User;

namespace ShortBook.Server.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public User Get(string username, string password)
        {
            // TODO Entity Framework
            throw new System.NotImplementedException();
        }
    }
}