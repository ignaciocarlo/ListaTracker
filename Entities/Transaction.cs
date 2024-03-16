namespace ListaTracker.Entities
{
    public class Transaction : AuditableBaseEntity
    {
        public decimal Amount { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public string? Note { get; set; }
    }
}
