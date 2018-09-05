using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PII.Models;
using PII.ViewModels;

namespace PII.Controllers
{
    public class PersonalInformationController : Controller
    {
        private ApplicationDbContext _context;

        public PersonalInformationController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: PersonalInformation
        public ActionResult Index()
        {
            var personalInformation = _context.Persons.ToList();
            return View(personalInformation);
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

        public List<AddressType> GetAddressTypes()
        {
            return new List<AddressType>
          {
              new AddressType {Id = 1, Type = "Residential"},
              new AddressType {Id = 2, Type = "Permanent"},
              new AddressType {Id = 3, Type = "Business"}
          };
        }

        public ActionResult PersonalForm(int id)
        {
            var personalInformation = _context.Persons.SingleOrDefault(c => c.Id == id);

            var viewModel = new PersonalInformationViewModel
            {
                Person = personalInformation,
                CivilStatus = GetCivilStatus(),
                Genders = GetGenders(),
                Suffixes = GetSuffixes()
            };
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var person = _context.Persons.SingleOrDefault(c => c.Id == id);
            var residentialAddress = _context.Address.SingleOrDefault(r => r.PersonalInformationId == person.Id && r.AddressTypeId == 1);
            var permanentAddress = _context.Address.SingleOrDefault(p => p.PersonalInformationId == person.Id && p.AddressTypeId == 2);

            var viewModel = new PersonalInformationViewModel
            {
                Person = person,
                CivilStatus = GetCivilStatus(),
                Genders = GetGenders(),
                ResidentialAddress = residentialAddress,
                PermanentAddress = permanentAddress,
                Suffixes = GetSuffixes()
            };
            return View(viewModel);
        }

        public ActionResult AddressForm(int ownersId, byte addressTypeId)
        {
            var person = _context.Persons.SingleOrDefault(c => c.Id == ownersId);
            var address = _context.Address.SingleOrDefault(r => r.PersonalInformationId == person.Id && r.AddressTypeId == addressTypeId);
            var viewModel = new AddressViewModel()
            {
                Person = person,
                AddressType = GetAddressTypes(),
                Address = address
            };
            return View(viewModel);
        }

    }
}