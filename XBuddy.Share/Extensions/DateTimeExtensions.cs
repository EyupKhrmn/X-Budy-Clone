namespace XBuddy.Share.Extensions;

public static class DateTimeExtensions
{
    public static string GetFormattedPostedTime(this DateTime dateTime)
    {
        var timeSpan = DateTime.Now - dateTime;

        if ((int)timeSpan.TotalDays > 0)
        {
            return $"{timeSpan.Days}d";
        }
        else if ((int)timeSpan.TotalHours > 0)
        {
            return $"{timeSpan.Hours}h";
        }
        else if ((int)timeSpan.TotalMinutes > 0)
        {
            return $"{timeSpan.Minutes}m";
        }
        else
        {
            return "just now";
        }
    }
}