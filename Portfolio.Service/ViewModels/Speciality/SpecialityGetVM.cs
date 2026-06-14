namespace Portfolio.Service.ViewModels.Speciality
{
    public class SpecialityGetVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
