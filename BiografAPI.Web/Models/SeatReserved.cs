using System;
using System.Collections.Generic;

#nullable disable

namespace BiografAPI.Web.Models
{
    public partial class SeatReserved
    {
        public int Id { get; set; }
        public int? SeatId { get; set; }
        public int? ReservationId { get; set; }
        public int? ScreeningId { get; set; }

        public virtual Reservation Reservation { get; set; }
        public virtual Screening Screening { get; set; }
        public virtual Seat Seat { get; set; }
    }
}
