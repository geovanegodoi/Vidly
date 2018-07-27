using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Core.Domain
{
    [Table("MEMBERSHIPTYPES")]
    public class MembershipType : BaseEntity<long>
    {
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