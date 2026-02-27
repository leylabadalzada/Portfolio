namespace Portfolio.Service.DTOs.General
{
    public record DateDto
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
