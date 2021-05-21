using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShortBook.Server.Domain
{
    /// <summary>
    /// 拥有自增ID的实体
    /// </summary>
    public abstract class AutoIdEntity
    {
        /// <summary>
        /// 标识ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
    }
}