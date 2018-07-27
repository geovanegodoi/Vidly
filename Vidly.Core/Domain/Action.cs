using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Core.Domain
{
    [Table("ACTIONS")]
    public class Action : BaseEntity<long>
    {
        [Column("NAME")]
        public string Name { get; set; }
    }
}
