namespace Portfolio.Core.Models.BaseModels
{
    public class BaseEntity
    {
        public Guid ID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool isDeleted { get; set; }
    }
}
