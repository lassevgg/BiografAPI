using System;
using System.Collections.Generic;

#nullable disable

namespace BiografAPI.Web.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Screenings = new HashSet<Screening>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? GenreId { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }
        public int? DurationMin { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual ICollection<Screening> Screenings { get; set; }
    }
}
