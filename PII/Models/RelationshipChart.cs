using System.ComponentModel.DataAnnotations;

namespace PII.Models
{
    public class RelationshipChart
    {
        public byte Id { get; set; }
        [Required]
        [MaxLength(32)]
        public string Relationship { get; set; }
        [MaxLength(256)]
        public string Description { get; set; }

    }
}