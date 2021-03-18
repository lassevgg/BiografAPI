using System;
using System.Collections.Generic;

#nullable disable

namespace BiografAPI.Web.Models
{
    public partial class Auditorium
    {
        public Auditorium()
        {
            Screenings = new HashSet<Screening>();
            Seats = new HashSet<Seat>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? SeatsNumber { get; set; }

        public virtual ICollection<Screening> Screenings { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
    }
}
