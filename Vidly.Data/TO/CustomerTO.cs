using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public DateTime Birthdate { get; set; }
    }
}
