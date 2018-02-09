using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Domain
{
    [Table("CUSTOMERS")]
    public class Customer
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        [Column("SUBSCRIBED")]
        public bool IsSubscribedToNewsletter { get; set; }

        [Column("MEMBERSHIPTYPEID")]
        public byte MembershipTypeId { get; set; }

        [Column("BIRTHDATE")]
<<<<<<< HEAD
        public DateTime Birthdate { get; set; }
=======
        public Nullable<DateTime> Birthdate { get; set; }
>>>>>>> dev

        public MembershipType MembershipType { get; set; }
    }
}
