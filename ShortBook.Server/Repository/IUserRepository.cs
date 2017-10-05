using ShortBook.Server.Domain.User;

namespace ShortBook.Server.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User Get(string username, string password);
    }
}