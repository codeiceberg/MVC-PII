using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PII.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string HouseBlockLotNo { get; set; }
        public string Street { get; set; }
        public string SubdivisionVillage { get; set; }
        public int? BarangayId { get; set; }
        public int? CityMunicipalityId { get; set; }
        public int? ProvinceId { get; set; }
        public int? Zip { get; set; }
    }
}