using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PII.Models
{
    public class Province
    {
        public int Id { get; set; }
        public int? CountryId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}