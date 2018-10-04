using PII.Models;
using System.Collections.Generic;
using System.Linq;

namespace PII.ViewModels
{
    public class RelationshipConnectionViewModel
    {
        public Person Person { get; set; }
        public IEnumerable<RelationshipChart> RelationshipChart { get; set; }
        public IQueryable<RelationshipConnection> RelationshipConnections { get; set; }
    }
}