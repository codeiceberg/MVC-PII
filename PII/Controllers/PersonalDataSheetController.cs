using PII.Models;
using PII.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace PII.Controllers
{
    public class PersonalDataSheetController : Controller
    {
        private ApplicationDbContext _context;

        public PersonalDataSheetController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public List<CivilStatus> GetCivilStatus()
        {
            return new List<CivilStatus>
            {
                new CivilStatus {Id = 1, Status = "Single"},
                new CivilStatus {Id = 2, Status = "Married"},
                new CivilStatus {Id = 3, Status = "Widowed"},
                new CivilStatus {Id = 4, Status = "Separated"},
                new CivilStatus {Id = 5, Status = "Others"}
            };
        }

        public List<Gender> GetGenders()
        {
            return new List<Gender>
            {
                new Gender {Id = 1, Type = "Male"},
                new Gender {Id = 2, Type = "Female"}
            };
        }

        public List<Suffix> GetSuffixes()
        {
            return new List<Suffix>
            {
                new Suffix {Id = 1, Type = ""},
                new Suffix {Id = 2, Type = "Jr"},
                new Suffix {Id = 3, Type = "Sr"},
                new Suffix {Id = 4, Type = "II"},
                new Suffix {Id = 5, Type = "III"},
                new Suffix {Id = 6, Type = "IV"}
            };
        }

        public ActionResult Index()
        {
            var personalInformation = _context.Persons.ToList();
            return View(personalInformation);
        }

        public ActionResult Details(int id)
        {
            var person = _context.Persons.SingleOrDefault(c => c.Id == id);
            var residentialAddressObject = _context.Address.SingleOrDefault(r => r.PersonId == person.Id && r.AddressTypeId == 1);
            var permanentAddressObject = _context.Address.SingleOrDefault(p => p.PersonId == person.Id && p.AddressTypeId == 2);
            var residentialAddress = new AddressController().GetFullAddress(person.Id, 1);
            var permanentAddress = new AddressController().GetFullAddress(person.Id, 2);
            var familyMembers = _context.RelationshipConnection.Include(m => m.RelationshipChart).Include(d => d.Person2).Where(c => c.PersonId == id);
            var relationshipChart = _context.RelationshipChart.ToList();

            var viewModel = new PersonalInformationViewModel
            {
                Person = person,
                CivilStatus = GetCivilStatus(),
                Genders = GetGenders(),
                ResidentialAddressObject = residentialAddressObject,
                PermanentAddressObject = permanentAddressObject,
                ResidentialAddress = residentialAddress,
                PermanentAddress = permanentAddress,
                Suffixes = GetSuffixes(),
                FamilyMembers = familyMembers,
                RelationshipChart = relationshipChart

                //PersonFamilyMembers = result,
            };
            return View(viewModel);
        }




    }
}