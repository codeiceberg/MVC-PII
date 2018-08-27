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
            var personalInformation = _context.PersonalInformations.ToList();
            return View(personalInformation);
        }

        public ActionResult PersonalInformationForm(int id)
        {
            var personalInformation = _context.PersonalInformations.SingleOrDefault(c => c.Id == id);
            var civilStatus = GetCivilStatus();
            var gender = GetGenders();
            var residentialAddress = _context.Address.SingleOrDefault(c => c.Id == personalInformation.ResidentialAddressId);
            var permanentAddress = _context.Address.SingleOrDefault(c => c.Id == personalInformation.PermanentAddressId);

            var viewModel = new PersonalInformationViewModel
            {
                PersonalInformation = personalInformation,
                CivilStatus = civilStatus,
                Genders =gender,
                ResidentialAddress = residentialAddress,
                PermanentAddress = permanentAddress
            };
            return View(viewModel);
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
    }
}