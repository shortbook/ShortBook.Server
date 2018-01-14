using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShortBook.Server.Domain
{
    /// <summary>
    /// 抽象实体对象
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// 标识ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        /// <summary>
        /// 判断两个实体对象是否是同一个实例
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}