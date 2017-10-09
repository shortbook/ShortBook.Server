using ShortBook.Server.Domain.User;
using System.Linq;

namespace ShortBook.Server.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public User Get(string username, string password)
        {
            return Entities.FirstOrDefault(e =>
                e.Username == username &&
                e.Password == password);
        }
    }
}