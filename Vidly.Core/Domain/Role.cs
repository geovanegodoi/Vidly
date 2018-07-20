using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Core.Domain
{
    [Table("ROLES")]
    public class Role
    {
        [Column("ID")]
        public long Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        public ICollection<Permission> Permissions { get; set; }
    }
}
