namespace Portfolio.Core.Models.BaseModels
{
    public class BaseEntity
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
