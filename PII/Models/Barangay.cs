﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PII.Models
{
    public class Barangay
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        public City City { get; set; }
        public int CityId { get; set; }
        public int Zip { get; set; }
        public string WebLink { get; set; }
    }
}