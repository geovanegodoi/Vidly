using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly.TO
{
    public class MembershipTypeTO
    {
        public byte Id { get; set; }

        public short SignUpFee { get; set; }

        public byte DurationInMonths { get; set; }

        public byte DiscountRate { get; set; }

        public string Name { get; set; }

        public static readonly byte Unknown    = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}
