using System.ComponentModel.DataAnnotations;

namespace ListaTracker.Entities
{
    public class AuditableBaseEntity
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CreatedBy { get; set; } = "Test";
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
