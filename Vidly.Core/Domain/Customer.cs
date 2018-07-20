using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Core.Domain
{
    [Table("CUSTOMERS")]
    public class Customer
    {
        [Column("ID")]
        public long Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        [Column("SUBSCRIBED")]
        public bool IsSubscribedToNewsletter { get; set; }

        [Column("MEMBERSHIPTYPEID")]
        public long MembershipTypeId { get; set; }

        [Column("BIRTHDATE")]
        public Nullable<DateTime> Birthdate { get; set; }

        [Column("LOGIN")]
        public string Login { get; set; }

        [Column("PASSWORD")]
        public string Password { get; set; }

        [Column("ROLEID")]
        public long RoleId { get; set; }

        public MembershipType MembershipType { get; set; }

        public Role Role { get; set; }
    }
}
