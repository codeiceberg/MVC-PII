using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using PII.Models;

namespace PII.ViewModels
{
    public class AddressViewModel
    {
        public Person Person { get; set; }
        public Address Address { get; set; }
        public IEnumerable<AddressType> AddressTypes { get; set; }
        public IEnumerable<Province> Provinces { get; set; }
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<Barangay> Barangays { get; set; }
    }
}