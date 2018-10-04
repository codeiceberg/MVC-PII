using PII.Models;
using PII.ViewModels;
using System.Linq;
using System.Text;
using System.Web.Mvc;
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
            var cities = _context.Cities.Where(m => m.ProvinceId == provinceId).Select(m => new { m.Id, m.Name });
            var json = new JavaScriptSerializer().Serialize(cities);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetBarangay(int cityId)
        {
            var barangay = _context.Barangays.Where(c => c.CityId == cityId).Select(c => new { c.Id, c.Name });
            var json = new JavaScriptSerializer().Serialize(barangay);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddressForm(int ownersId, byte addressTypeId)
        {
            var person = _context.Persons.SingleOrDefault(c => c.Id == ownersId);
            var addressType = _context.AddressTypes.ToList();
            var address = _context.Address.SingleOrDefault(c => c.PersonId == person.Id && c.AddressTypeId == addressTypeId);
            var province = _context.Province.Where(c => c.Id == address.ProvinceId);
            var cityMunicipality = _context.Cities.Where(c => c.ProvinceId == address.ProvinceId);
            var barangay = _context.Barangays.Where(c => c.CityId == address.CityId);

            var viewModel = new AddressViewModel()
            {
                Person = person,
                AddressTypes = addressType,
                Address = address,
                Provinces = province,
                Cities = cityMunicipality,
                Barangays = barangay

            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(Address address)
        {
            if (address.Id == 0)
            {
                _context.Address.Add(address);
            }
            else
            {
                var addressInDb = _context.Address.Single(m => m.Id == address.Id);
                addressInDb.ProvinceId = address.ProvinceId;
                addressInDb.CityId = address.CityId;
                addressInDb.BarangayId = address.BarangayId;
                addressInDb.Street = address.Street;
                addressInDb.SubdivisionVillage = address.SubdivisionVillage;
                addressInDb.HouseBlockLotNo = address.HouseBlockLotNo;
                addressInDb.Latitude = address.Latitude;
                addressInDb.Longitude = address.Longitude;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "PersonalDataSheet");
        }

        [HttpGet]
        public string GetFullAddress(int personId, byte addressTypeId)
        {
            var addresses = _context.Address;
            var provinces = _context.Province;
            var cities = _context.Cities;
            var barangays = _context.Barangays;
            var fullAddress = new StringBuilder();

            var query = addresses.Join(provinces, adr => adr.ProvinceId, prov => prov.Id,
                    (adr, prov) => new { _location = adr, _province = prov })
                .Join(cities, adrProv => adrProv._location.CityId, cty => cty.Id,
                    (provLoc, cty) => new { _provLoc = provLoc, _city = cty })
                .Join(barangays, adrProvCity => adrProvCity._provLoc._location.BarangayId, brgy => brgy.Id,
                    (adrProvCity, brgy) => new { _adrProvCity = adrProvCity, _brgy = brgy })
                .Where(
                    c =>
                        c._adrProvCity._provLoc._location.PersonId == personId &&
                        c._adrProvCity._provLoc._location.AddressTypeId == addressTypeId);

            foreach (var location in query)
            {
                fullAddress.Append(location._adrProvCity._provLoc._location.HouseBlockLotNo + " " +
                                   location._adrProvCity._provLoc._location.Street + ", " +
                                   location._adrProvCity._provLoc._location.SubdivisionVillage + ", " +
                                   location._brgy.Name + ", " +
                                   location._adrProvCity._city.Name + " " +
                                   location._adrProvCity._provLoc._province.Name);
            }
            return fullAddress.ToString();
        }
    }
}