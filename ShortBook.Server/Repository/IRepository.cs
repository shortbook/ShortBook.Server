using ShortBook.Server.Domain;

namespace ShortBook.Server.Repository
{
    public interface IRepository<T> where T : Entity
    {
        void Add(T entity);

        T Get(long id);

        void Modify(T entity);
    }
}