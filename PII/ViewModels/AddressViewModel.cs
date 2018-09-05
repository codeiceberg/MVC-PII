using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PII.Models;

namespace PII.ViewModels
{
    public class AddressViewModel
    {
        public Person Person { get; set; }
        public IEnumerable<AddressType> AddressType { get; set; }
        public Address Address { get; set; }
    }
}