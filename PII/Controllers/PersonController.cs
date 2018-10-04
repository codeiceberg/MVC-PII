using PII.Models;
using PII.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PII.Controllers
{
    public class PersonController : Controller
    {
        private ApplicationDbContext _context;

        public PersonController()
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

        // GET: Person


        public ActionResult PersonForm(int id)
        {
            var personalInformation = _context.Persons.SingleOrDefault(c => c.Id == id);
            var viewModel = new PersonViewModel()
            {
                Person = personalInformation,
                CivilStatus = GetCivilStatus(),
                Genders = GetGenders(),
                Suffixes = GetSuffixes()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(Person person)
        {
            if (person.Id == 0)
            {
                _context.Persons.Add(person);
            }
            else
            {
                var personInDb = _context.Persons.Single(p => p.Id == person.Id);
                personInDb.Title = person.Title;
                personInDb.Gender = person.Gender;
                personInDb.FirstName = person.FirstName;
                personInDb.LastName = person.LastName;
                personInDb.MiddleName = person.MiddleName;
                personInDb.NameExtension = person.NameExtension;
                personInDb.DateOfBirth = person.DateOfBirth;
                personInDb.CivilStatus = person.CivilStatus;
                personInDb.Citizenship = person.Citizenship;

                personInDb.MobileNo = person.MobileNo;
                personInDb.TelephoneNo = person.TelephoneNo;
                personInDb.EmailAddress = person.EmailAddress;

                personInDb.BloodType = person.BloodType;
                personInDb.Weight = person.Weight;
                personInDb.Height = person.Height;

                personInDb.PagibigNo = person.PagibigNo;
                personInDb.PhilhealthNo = person.PhilhealthNo;
                personInDb.GsisNo = person.GsisNo;
                personInDb.TinNo = person.TinNo;

            }

            _context.SaveChanges();

            return RedirectToAction("Details", "PersonalDataSheet", new { id = person.Id });

        }

        [HttpGet]
        public ActionResult Find(string searchText)
        {
            var model = _context.Persons;
            if (string.IsNullOrEmpty(searchText)) return View(model);

            var person = _context.Persons.Where(p => p.FirstName.Contains(searchText)).ToList();
            return View(person);
        }

        //public List<PersonFamilyMember> GetFamilyMembers(int personId)
        //{
        //    var thisPerson = _context.Persons;
        //    var relatedto = _context.RelationshipConnection;
        //    var relationShip = _context.RelationshipChart;
        //    var result = thisPerson.Join(relatedto, person2 => person2.Id, related => related.PersonId,
        //            (person2, related) => new
        //            {
        //                id = person2.Id,
        //                firstName = person2.FirstName,
        //                lastName = person2.LastName,
        //                middleName = person2.MiddleName,
        //                suffix = person2.NameExtension,
        //                ocupation = person2.Title,
        //                dateOfBirth = person2.DateOfBirth,
        //                relationshipId = related.RelationshipChartId

        //            }).Join(relationShip, pr => pr.relationshipId, relationName => relationName.Id,
        //            (pr, relationName) => new
        //            {
        //                id = pr.id,
        //                name = pr.firstName + " " + pr.lastName + " " + pr.middleName,
        //                suffix = pr.suffix,
        //                ocupation = pr.ocupation,
        //                dateOfBirth = pr.dateOfBirth,
        //                Relationship = relationName.Relationship
        //            })
        //        .Where(c => c.id == personId).ToList();

        //    return new List<PersonFamilyMember>();

        //var relatedto = _context.RelationshipConnection;
        //var relationShip = _context.RelationshipChart;
        //var result = thisPerson.Join(relatedto, person2 => person2.Id, related => related.Person2Id,
        //        (person2, related) => new
        //        {
        //            id = person2.Id,
        //            firstName = person2.FirstName,
        //            lastName = person2.LastName,
        //            middleName = person2.MiddleName,
        //            suffix = person2.NameExtension,
        //            ocupation = person2.Title,
        //            dateOfBirth = person2.DateOfBirth,
        //            relationshipId = related.RelationshipChartId,
        //            parentId = related.PersonId

        //        })
        //    .Join(relationShip, pr => pr.relationshipId, relationName => relationName.Id,
        //        (pr, relationName) => new
        //        {
        //            id = pr.id,
        //            name = pr.firstName + " " + pr.lastName + " " + pr.middleName,
        //            suffix = pr.suffix,
        //            ocupation = pr.ocupation,
        //            dateOfBirth = pr.dateOfBirth,
        //            Relationship = relationName.Relationship,
        //            parentId = pr.parentId
        //        })
        //    .Where(c => c.parentId == id);

        //}
    }
}