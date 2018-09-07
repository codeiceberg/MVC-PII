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
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        public Province Province { get; set; }
        public int ProvinceId { get; set; }
        public int Zip { get; set; }
        public string WebLink { get; set; }
    }
}