using System;
using System.Collections.Generic;

#nullable disable

namespace BiografAPI.Web.Models
{
    public partial class Screening
    {
        public Screening()
        {
            Reservations = new HashSet<Reservation>();
            SeatReserveds = new HashSet<SeatReserved>();
        }

        public int Id { get; set; }
        public int? MovieId { get; set; }
        public int? AuditoriumId { get; set; }
        public DateTime? ScreeningStart { get; set; }

        public virtual Auditorium Auditorium { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<SeatReserved> SeatReserveds { get; set; }
    }
}
