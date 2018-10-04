using PII.Models;
using PII.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace PII.Controllers
{
    public class RelationshipConnectionController : Controller
    {
        private ApplicationDbContext _dbContext;

        public RelationshipConnectionController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        // GET: RelationshipConnection
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RelationshipMapper(int personId)
        {
            var person = _dbContext.Persons.SingleOrDefault(m => m.Id == personId);
            var relationship = _dbContext.RelationshipChart.ToList();
            var familyMembers =
                _dbContext.RelationshipConnection.Include(c => c.RelationshipChart)
                    .Include(r => r.Person2)
                    .Where(p => p.PersonId == personId);

            var viewmodel = new RelationshipConnectionViewModel
            {
                Person = person,
                RelationshipChart = relationship,
                RelationshipConnections = familyMembers
            };
            return View(viewmodel);
        }
    }
}