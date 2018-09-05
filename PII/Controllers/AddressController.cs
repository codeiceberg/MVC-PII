using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PII.Models;
using PII.ViewModels;


namespace PII.Controllers
{
    public class AddressController : Controller
    {
        private ApplicationDbContext _context;

        public AddressController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Address
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddressForm(int ownersId, byte addressTypeId)
        {
            var person = _context.Persons.SingleOrDefault(c => c.Id == ownersId);
            var address = _context.Address.SingleOrDefault(r => r.PersonalInformationId == person.Id && r.AddressTypeId == addressTypeId);
            var addressType = _context.AddressTypes.ToList();
            var viewModel = new AddressViewModel()
            {
                Person = person,
                AddressType = addressType,
                Address = address
            };
            return View(viewModel);
        }
    }
}