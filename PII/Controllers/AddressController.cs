using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PII.Models;
using PII.ViewModels;
using System.Web.Script.Serialization;


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

        [HttpGet]
        public ActionResult GetCity(int provinceId)
        {
            var cities = _context.CityMunicipality.Where(m => m.ProvinceId == provinceId).Select(m => new { m.Id, m.Name }).ToList();
            var json = new JavaScriptSerializer().Serialize(cities);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddressForm(int ownersId, byte addressTypeId)
        {
            var person = _context.Persons.SingleOrDefault(c => c.Id == ownersId);
            var addressType = _context.AddressTypes.ToList();
            var address = _context.Address.SingleOrDefault(c => c.PersonId == person.Id && c.AddressTypeId == addressTypeId);
            var province = _context.Province.Where(c => c.Id == address.ProvinceId);
            var cityMunicipality = _context.CityMunicipality.Where(c => c.ProvinceId == address.ProvinceId);
            var barangay = _context.Barangays.Where(c => c.CityMunicipalityId == address.CityMunicipalityId);
            var viewModel = new AddressViewModel()
            {
                Person = person,
                AddressTypes = addressType,
                Address = address,
                Provinces = province,
                CityMunicipalities = cityMunicipality,
                Barangays = barangay

            };
            return View(viewModel);
        }
    }
}