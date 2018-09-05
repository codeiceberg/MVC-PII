using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PII.Models;

namespace PII.ViewModels
{
    public class PersonViewModel
    {
        public Person Person { get; set; }
        public IEnumerable<CivilStatus> CivilStatus { get; set; }
        public IEnumerable<Gender> Genders { get; set; }
        public IEnumerable<Suffix> Suffixes { get; set; }
    }
}