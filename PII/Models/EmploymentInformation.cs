using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace PII.Models
{
    public class EmploymentInformation
    {
        public int Id { get; set; }
        public string EmploymentType { get; set; }
        public string Otheres { get; set; }
        public short? YearsWithPrecentEmployer { get; set; }
        public short? PositionId { get; set; }
        public short? NatureOfBusinessId { get; set; }
        public short? WorkTenureYears { get; set; }
        public short? WorkTenureMonths { get; set; }
        public string NameOfBusiness { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public string EmailAddress { get; set; }
        public int? GrossAnnualIncome { get; set; }
        public int? AddressId { get; set; }
    }
}