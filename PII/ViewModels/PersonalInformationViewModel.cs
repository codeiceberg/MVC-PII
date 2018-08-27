using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PII.Models;

namespace PII.ViewModels
{
    public class PersonalInformationViewModel
    {
        public PersonalInformation PersonalInformation { get; set; }
        public IEnumerable<CivilStatus>  CivilStatus { get; set; }
        public Address Address { get; set; }
    }
}