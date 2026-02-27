namespace Portfolio.Service.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string? message) : base($"{message} was not found!")
        {
        }
    }
}
