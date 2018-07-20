using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Core.Domain
{
    [Table("RENTALS")]
    public class Rental
    {
        [Column("ID")]
        public long Id { get; set; }

        [Column("CUSTOMERID")]
        public long CustomerId { get; set; }

        [Column("DATERENT")]
        public Nullable<DateTime> DateRent { get; set; }

        [Column("DATERETURN")]
        public Nullable<DateTime> DateReturn { get; set; }

        public Customer Customer { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
