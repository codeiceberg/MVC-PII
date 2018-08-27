using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PII.Models
{
    public class CityMunicipality
    {
        public int Id { get; set; }
        public int ProvinceId { get; set; }
        public int Zip { get; set; }
        [Required]
        public string Name { get; set; }

        public string WebLink { get; set; }
    }
}