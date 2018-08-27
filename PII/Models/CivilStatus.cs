using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PII.Models
{
    public class CivilStatus
    {
        public byte Id { get; set; }
        [Required]
        public string Status { get; set; }
    }
}