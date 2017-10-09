using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShortBook.Server.Domain;

namespace ShortBook.Server.Repository
{
    public abstract class RepositoryBase<T> : DbContext
        where T : Entity
    {
        public DbSet<T> Entities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string conn = config.GetConnectionString("DataAccessPostgreSqlProvider");
            optionsBuilder.UseNpgsql(conn);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<T>();

            base.OnModelCreating(builder);
        }

        public void Add(T entity)
        {
            Entities.Add(entity);
            SaveChanges();
        }

        public T Get(long id)
        {
            return Entities.FirstOrDefault(e => e.Id == id);
        }

        public void Modify(T entity)
        {
            Entities.Update(entity);
            SaveChanges();
        }
    }
}