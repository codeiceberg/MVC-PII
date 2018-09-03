using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PII.Models;

namespace PII.ViewModels
{
    public class EmploymentViewModel
    {
        public EmploymentInformation EmploymentInformations { get; set; }
        public IEnumerable<EmploymentType> EmploymentTypes { get; set; }
        public IEnumerable<EmploymentRank> EmploymentRanks { get; set; }
        public IEnumerable<NatureOfBusiness> NatureOfBusinesses { get; set; }

    }
}