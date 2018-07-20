using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Validation;

namespace Vidly.TO
{
    public class RentalTO
    {
        public long Id { get; set; }

        public string CustomerName { get; set; }

        public int MoviesRented { get; set; }

        public DateTime DateRent { get; set; }

        public DateTime DateReturn { get; set; }
    }
}
