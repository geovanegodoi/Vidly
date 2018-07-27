using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Core.Domain
{
    [Table("GENDERS")]
    public class Gender : BaseEntity<long>
    {
        [Column("NAME")]
        public string Name { get; set; }
    }
}
