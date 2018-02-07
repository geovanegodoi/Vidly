using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Domain
{
    [Table("GENDERS")]
    public class Gender
    {
        [Column("ID")]
        public long Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }
    }
}
