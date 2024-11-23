using System.Globalization;

namespace KLPVN.Core.Helper;

public static class DateTimeHelper
{
  public static DateTime ConvertStringToDateTimeFormat(string dateTime)
  {
      var isDate = DateTime.TryParseExact(dateTime, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var result);
      return isDate ? result : throw new ArgumentException("Invalid date format dd/MM/yyyy");
  }
}
