using System;
using System.Collections.Generic;
using Vidly.TO;

namespace Vidly.ViewModel
{
    public class MovieViewModel
    {
        public IEnumerable<GenderTO> Genders { get; set; }

        public MovieTO Movie { get; set; }
    }
}
