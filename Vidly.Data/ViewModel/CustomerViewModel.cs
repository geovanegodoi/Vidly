using System;
using System.Collections.Generic;
using Vidly.TO;

namespace Vidly.ViewModel
{
    public class CustomerViewModel
    {
        public IEnumerable<MembershipTypeTO> MembershipTypes { get; set; }

        public CustomerTO Customer { get; set; }
    }
}
