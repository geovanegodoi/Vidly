﻿using System;
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
        public DateTime Birthdate { get; set; }

        public MembershipType MembershipType { get; set; }
    }
}
