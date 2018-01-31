using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Domain
{
    [Table("CUSTOMERS", Schema="VIDLY")]
    public class Customer
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }
    }
}
