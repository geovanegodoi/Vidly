using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Core.Domain
{
    [Table("PERMISSIONS")]
    public class Permission
    {
        [Key]
        [Column("ROLEID", Order = 1)]
        public long RoleId { get; set; }

        [Key]
        [Column("FORMID", Order = 2)]
        public long FormId { get; set; }

        [Key]
        [Column("ACTIONID", Order = 3)]
        public long ActionId { get; set; }

        public Role Role { get; set; }

        public Domain.Form Form { get; set; }

        public Domain.Action Action { get; set; }
    }
}
