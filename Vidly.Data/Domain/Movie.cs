using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly.Domain
{
    [Table("MOVIES")]
    public class Movie
    {
        [Column("ID")]
        public long Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        [Column("GENDERID")]
        public long GenderId { get; set; }

        [Column("RELEASEDATE")]
        public DateTime ReleaseDate { get; set; }

        [Column("ADDED")]
        public DateTime Added { get; set; }

        [Column("STOCK")]
        public int Stock { get; set; }

        public Gender Gender { get; set; }
    }
}
