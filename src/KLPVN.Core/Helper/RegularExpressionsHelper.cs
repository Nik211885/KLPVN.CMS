using System.Text.RegularExpressions;

namespace KLPVN.Core.Helper;

public partial class RegularExpressionsHelper
{
  public static bool IsValidEmail(string email)
  {
    if (string.IsNullOrWhiteSpace(email))
    {
      return false;
    }
    try
    {
      return RegexEmailAddress().IsMatch(email);
    }
    catch (RegexMatchTimeoutException)
    {
      return false;
    }
  }

  public static bool IsValidPhoneNumberInVietNam(string phoneNumber)
  {
    if (string.IsNullOrWhiteSpace(phoneNumber))
    {
      return false;
    }
    try
    {
      return RegexPhoneNumberInVietNam().IsMatch(phoneNumber);
    }
    catch (RegexMatchTimeoutException)
    {
      return false;
    }
  }

  public static bool IsValidPassword(string password)
  {
    if (string.IsNullOrWhiteSpace(password))
    {
      return false;
    }
    try
    {
      return RegexPassword().IsMatch(password);
    }
    catch (RegexMatchTimeoutException)
    {
      return false;
    }
  }
  [GeneratedRegex(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")]
  private static partial Regex RegexEmailAddress();
  [GeneratedRegex("(84|0[3|5|7|8|9])+([0-9]{8})")]
  private static partial Regex RegexPhoneNumberInVietNam();
  [GeneratedRegex(@"^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$")]
  private static partial Regex RegexPassword();
}
