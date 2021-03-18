using System;
using System.Collections.Generic;

#nullable disable

namespace BiografAPI.Web.Models
{
    public partial class ReservationType
    {
        public ReservationType()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
