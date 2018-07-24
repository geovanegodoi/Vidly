using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Validation;

namespace Vidly.TO
{
    public class RentalTO
    {
        public long Id { get; set; }

        public long CustomerId { get; set; }

        public CustomerTO Customer { get; set; }

        public ICollection<long> MoviesId { get; set; }

        public ICollection<MovieTO> Movies { get; set; }

        [Display(Name = "Date Rented")]
        public DateTime? DateRent { get; set; }

        [Display(Name = "Date Returned")]
        public DateTime? DateReturn { get; set; }
    }
}
