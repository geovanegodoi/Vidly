using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Validation;

namespace Vidly.TO
{
    public class CustomerTO
    {
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }

        public MembershipTypeTO MembershipType { get; set; }

        [Min18YearsIfAMember]
        public Nullable<DateTime> Birthdate { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public IEnumerable<PermissionTO> Permissions { get; set; }
    }
}
