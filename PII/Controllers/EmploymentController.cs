using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PII.Models;
using PII.ViewModels;

namespace PII.Controllers
{
    public class EmploymentController : Controller
    {
        private ApplicationDbContext _context;
        public EmploymentController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public List<EmploymentType> GetEmploymentTypes()
        {
            return new List<EmploymentType>
            {
                new EmploymentType {Id = 1, Type = "Employed"},
                new EmploymentType {Id = 2, Type = "None"},
                new EmploymentType {Id = 3, Type = "Self-Employed"},
                new EmploymentType {Id = 4, Type = "OFW"},
                new EmploymentType {Id = 5, Type = "Retired"}
            };
        }
        // GET: Employment
        public ActionResult Index()
        {
            var employment = _context.EmploymentInformations.ToList();
            return View(employment);
        }
        public ActionResult EmploymentForm( int id)
        {
            var employmentInformation = _context.EmploymentInformations.SingleOrDefault(e => e.Id == id);
            var employmentType = GetEmploymentTypes();
            var employmentRank = _context.EmploymentRanks.ToList();
            var employmentBussinesType = _context.NatureOfBusinesses.ToList();

            var viewmodel = new EmploymentViewModel
            {
                EmploymentInformations = employmentInformation,
                EmploymentTypes = employmentType,
                EmploymentRanks = employmentRank,
                NatureOfBusinesses = employmentBussinesType
            };

            return View(viewmodel);
        }

    }
}