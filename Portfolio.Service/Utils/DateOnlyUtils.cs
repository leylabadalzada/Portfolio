using Portfolio.Core.Constants;

namespace Portfolio.Service.Utils
{
    public static class DateOnlyUtils
    {
        public static DateOnly GenerateDate(int day, int month, int year)
        {
            DateOnly date;
            int maxDays;
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 10:
                case 12:
                    maxDays = 31;
                    break;
                case 2:
                    maxDays = DateTime.IsLeapYear(year) ? 29 : 28;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    maxDays = 30;
                    break;
                default:
                    throw new Exception("Month is out of range!");
            }

            if (day < 1 || day > maxDays)
            {
                var monthName = month.ToString("MMM");
                throw new Exception($"{monthName} does not contain day {day}");
            }
            if (year > TimeConstants.AzerbaijaniDate.Year || year < TimeConstants.AzerbaijaniDate.Year - 100) throw new Exception("Year is not correct!");
            date = new DateOnly(year, month, day);
            return date;
        }
    }
}
