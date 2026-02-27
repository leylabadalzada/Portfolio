namespace Portfolio.Service.DTOs.Author
{
    public record AuthorGetDto
    {
        public string FullName { get; set; }
        public string? ImageURL { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Location { get; set; }
        public string Info { get; set; } //homepage introduction
        public string Description { get; set; } //aboutpage 
        public bool isFreelanceAvailable { get; set; }
    }
}
