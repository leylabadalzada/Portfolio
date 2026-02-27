namespace Portfolio.Core.Constants
{
    public static class TimeConstants
    {
        public static DateTime AzerbaijaniTime { get { return DateTime.UtcNow.AddHours(4); } }
        public static DateOnly AzerbaijaniDate { get { return new DateOnly(AzerbaijaniTime.Year, AzerbaijaniTime.Month, AzerbaijaniTime.Day); } }
    }
}
