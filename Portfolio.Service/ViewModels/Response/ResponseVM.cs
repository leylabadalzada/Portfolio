namespace Portfolio.Service.ViewModels.Response
{
    public class ResponseVM<T>
    {
        public bool Result { get; set; } = true;
        public string? Message { get; set; }
        public T? Data { get; set; }
    }

    public class ResponseVM
    {
        public bool Result { get; set; } = true;
        public string? Message { get; set; }
    }
}
