using System;
using System.Collections.Generic;

#nullable disable

namespace BiografAPI.Web.Models
{
    public partial class Employee
    {
        public Employee()
        {
            ReservationEmployeePaids = new HashSet<Reservation>();
            ReservationEmployeeReserveds = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Reservation> ReservationEmployeePaids { get; set; }
        public virtual ICollection<Reservation> ReservationEmployeeReserveds { get; set; }
    }
}
