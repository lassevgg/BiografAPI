using System;
using System.Collections.Generic;

#nullable disable

namespace BiografAPI.Web.Models
{
    public partial class Reservation
    {
        public Reservation()
        {
            SeatReserveds = new HashSet<SeatReserved>();
        }

        public int Id { get; set; }
        public int? ScreeningId { get; set; }
        public int? EmployeeReservedId { get; set; }
        public int? ReservationTypeId { get; set; }
        public string ReservationContactName { get; set; }
        public bool? Reserved { get; set; }
        public int? EmployeePaidId { get; set; }
        public bool? Paid { get; set; }
        public bool? Active { get; set; }

        public virtual Employee EmployeePaid { get; set; }
        public virtual Employee EmployeeReserved { get; set; }
        public virtual ReservationType ReservationType { get; set; }
        public virtual Screening Screening { get; set; }
        public virtual ICollection<SeatReserved> SeatReserveds { get; set; }
    }
}
