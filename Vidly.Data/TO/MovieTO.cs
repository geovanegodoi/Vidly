using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly.TO
{
    public class MovieTO
    {
        public long Id              { get; set; }

        public string Name          { get; set; }

        public long GenderId        { get; set; }

        public GenderTO Gender      { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Addded Date")]
        public DateTime Added       { get; set; }

        [Display(Name = "Number In Stock")]
        public int Stock            { get; set; }
    }
}
