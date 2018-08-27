using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PII.Models
{
    public class PersonalInformation
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Title { get; set; }
        public string LastName { get; set; }
        public string FistName { get; set; }
        public string MiddleName { get; set; }
        public string NameExtension { get; set; }
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Place of Birth")]
        public int? PlateOfBirthAddressId { get; set; }
        public string Gender { get; set; }
        public string CivilStatus { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string BloodType { get; set; }
        public string GsisNo { get; set; }
        public string PagibigNo { get; set; }
        public string PhilhealthNo { get; set; }
        public string SssNo { get; set; }
        public string TinNo { get; set; }
        public string AgencyEmployeeNo { get; set; }
        public string Citizenship { get; set; }
        public int ResidentialAddressId { get; set; }
        public int PermanentAddressId { get; set; }
        public int BusinessAddressId { get; set; }
        public int TelephoneNo { get; set; }
        public int MobileNo { get; set; }
        public string EmailAddress { get; set; }
        public int ParentId { get; set; }
        public string WhoChange { get; set; }
        public DateTime? WhenChange { get; set; }
        public string WhoAdd { get; set; }
        public DateTime? WhenAdd { get; set; }

    }
}