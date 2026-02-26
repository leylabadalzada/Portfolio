namespace Portfolio.Core.Models.BaseModels
{
    public class BaseEntity
    {
        public Guid ID { get; set; }
        public DateTime Createdat { get; set; }
        public DateTime? Updatedat { get; set; }
        public DateTime? Deletedat { get; set; }
        public bool isDeleted { get; set; }
    }
}
