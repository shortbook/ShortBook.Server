using ShortBook.Server.Domain;

namespace ShortBook.Server.Repository
{
    public abstract class RepositoryBase<T> where T : Entity
    {
        public void Add(T entity)
        {
            // TODO Entity Framework
            throw new System.NotImplementedException();
        }

        public T Get(long id)
        {
            // TODO Entity Framework
            throw new System.NotImplementedException();
        }

        public void Modify(T entity)
        {
            // TODO Entity Framework
            throw new System.NotImplementedException();
        }
    }
}