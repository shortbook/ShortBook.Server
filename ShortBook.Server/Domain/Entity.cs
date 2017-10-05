namespace ShortBook.Server.Domain
{
    public abstract class Entity
    {
        public long Id { get; set; }

        protected bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}