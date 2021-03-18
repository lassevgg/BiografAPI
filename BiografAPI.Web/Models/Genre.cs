﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BiografAPI.Web.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
