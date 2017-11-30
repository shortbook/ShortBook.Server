using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShortBook.Server.Domain;

namespace ShortBook.Server.Repository
{
    /// <summary>
    /// 存储基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RepositoryBase<T> : DbContext
        where T : Entity
    {
        /// <summary>
        /// 实体集合
        /// </summary>
        public DbSet<T> Entities { get; set; }

        /// <summary>
        /// 配置数据库
        /// </summary>
        /// <param name="optionsBuilder">配置构造器</param>
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

        /// <summary>
        /// 配置实体对象
        /// </summary>
        /// <param name="builder">模型构造器</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<T>();

            base.OnModelCreating(builder);
        }

        /// <summary>
        /// 添加一个对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        protected void Add(T entity)
        {
            Entities.Add(entity);
            SaveChanges();
        }

        /// <summary>
        /// 获取一个对象
        /// </summary>
        /// <param name="id">实体Id</param>
        /// <returns>如果存在指定Id的实体，则返回该实体对象；否则返回null。</returns>
        protected T Get(long id)
        {
            return Entities.FirstOrDefault(e => e.Id == id);
        }

        /// <summary>
        /// 修改一个对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        protected void Modify(T entity)
        {
            Entities.Update(entity);
            SaveChanges();
        }

        /// <summary>
        /// 删除一个对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        protected void Remove(T entity)
        {
            Entities.Remove(entity);
            SaveChanges();
        }
    }
}