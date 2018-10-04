namespace PII.Models
{
    public class RelationshipConnection
    {
        public int Id { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }

        public byte RelationshipChartId { get; set; }
        public RelationshipChart RelationshipChart { get; set; }

        public int Person2Id { get; set; }
        public Person Person2 { get; set; }


    }
}