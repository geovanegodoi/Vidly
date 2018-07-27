using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Core.Domain
{
    [Table("ROLES")]
    public class Role : BaseEntity<long>
    {
        [Column("NAME")]
        public string Name { get; set; }

        public ICollection<Permission> Permissions { get; set; }

        public Role()
        {
            this.Permissions = new HashSet<Permission>();
        }
    }
}
