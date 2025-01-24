namespace ETLProject.Data.Helpers
{
    public class DateTimeConverter
    {
        public static DateTime ConvertESTToUTC(DateTime estDateTime)
        {
            TimeZoneInfo estTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime utcDateTime = TimeZoneInfo.ConvertTimeToUtc(estDateTime, estTimeZone);
            return utcDateTime;
        }
    }
}
