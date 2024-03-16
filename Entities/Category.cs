namespace ListaTracker.Entities
{
    public class Category : AuditableBaseEntity
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Type { get; set; }
    }
}
