using PII.Models;
using System.Collections.Generic;

namespace PII.ViewModels
{
    public class PersonalInformationViewModel
    {
        public Person Person { get; set; }
        public IEnumerable<CivilStatus> CivilStatus { get; set; }
        public IEnumerable<Gender> Genders { get; set; }
        public IEnumerable<Suffix> Suffixes { get; set; }
        public Address ResidentialAddressObject { get; set; }
        public Address PermanentAddressObject { get; set; }
        public string ResidentialAddress { get; set; }
        public string PermanentAddress { get; set; }
        public IEnumerable<RelationshipConnection> FamilyMembers { get; set; }
        public IEnumerable<RelationshipChart> RelationshipChart { get; set; }
        

    }
}