using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly.Domain
{
    [Table("MEMBERSHIPTYPES")]
    public class MembershipType
    {
        [Column("ID")]
        public byte Id { get; set; }

        [Column("SIGNUPFEE")]
        public short SignUpFee { get; set; }

        [Column("DURATIONINMONTHS")]
        public byte DurationInMonths { get; set; }

        [Column("DISCOUNTRATE")]
        public byte DiscountRate { get; set; }

        [Column("NAME")]
        public string Name { get; set; }
    }
}