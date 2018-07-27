using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly.Core.Domain
{
    public abstract class BaseEntity<TKey>
    {
        [Key]
        [Column("ID")]
        public TKey Id { get; set; }
    }
}
