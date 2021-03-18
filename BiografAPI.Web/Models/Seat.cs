using System;
using System.Collections.Generic;

#nullable disable

namespace BiografAPI.Web.Models
{
    public partial class Seat
    {
        public Seat()
        {
            SeatReserveds = new HashSet<SeatReserved>();
        }

        public int Id { get; set; }
        public int? Row { get; set; }
        public int? Number { get; set; }
        public int? AuditoriumId { get; set; }

        public virtual Auditorium Auditorium { get; set; }
        public virtual ICollection<SeatReserved> SeatReserveds { get; set; }
    }
}
