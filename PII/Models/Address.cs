using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PII.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Display(Name = "House/Block No.")]
        public string HouseBlockLotNo { get; set; }

        public string Street { get; set; }

        [Display(Name = "Subdivision/Village")]
        public string SubdivisionVillage { get; set; }

        [Display(Name = "Barangay")]
        public Barangay Barangay { get; set; }
        public int BarangayId { get; set; }

        [Display(Name = "City/Municipality")]
        public CityMunicipality CityMunicipality { get; set; }
        public int CityMunicipalityId { get; set; }

        [Display(Name = "Province")]
        public Province Province { get; set; }
        public int ProvinceId { get; set; }

        public int? Zip { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public byte AddressTypeId { get; set; }

        public Person Person { get; set; }
        public int? PersonId { get; set; }

    }
}