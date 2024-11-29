using System.Security.Cryptography;
using System.Text;
using KLPVN.Core.Commons.Enums;
using Newtonsoft.Json;

namespace KLPVN.Core.Helper;

public static class StringHelper
{
  public static string RandomKeyFormatDateTime(string? code = null, bool start = true)
  {
    var date = DateTimeOffset.UtcNow.ToString("yyyyMMddHHmmssfff");
    code = code ?? GeneratorStringBase64(10);
    return start ? string.Concat(date, code) : string.Concat(code, date);
  }

  private static string ConcatDateTime(int date, string code)
    => string.Concat(date, " ", code, " trước");
  public static string ConvertDateTimeToString(DateTimeOffset date)
  {
    var hh = date.Hour;
    var mm = date.Minute;
    var ss = date.Second;
    if (hh != 0) return ConcatDateTime(hh, " giờ");
    return mm != 0 ? ConcatDateTime(mm, "phút") : ConcatDateTime(ss, "giây");
  }
  public static string ConvertDateToString(DateTime dateTime)
    => dateTime.ToString("dd/MM/yyyy");
  public static TObject? AsObject<TObject>(this string str)
    => JsonConvert.DeserializeObject<TObject>(str);
  public static string GeneratorStringBase64(int bytes)
  {
    // one character in base 64 equals 6 bits , one byte = 8 bits
    var rands = new byte[bytes];
    using (var random = RandomNumberGenerator.Create())
    {
      random.GetBytes(rands);
    }
    return Convert.ToBase64String(rands);
  }
  public static char GeneratorCharacter(CharacterTypes type)
  {
    var rand = new Random();
    // have 4 container have special character in asscii :)
    var containerSpecialCharacter = new List<(int, int)>{(33, 48), (58, 65),(91,97),(123,127)};
    // min <= random < max 
    var (start, end) = type switch
    {
      CharacterTypes.UpperCase => (65, 91),
      CharacterTypes.LowerCase => (97, 123),
      CharacterTypes.Number => (48, 58),
      CharacterTypes.SpecialCharacter => containerSpecialCharacter.ElementAt(rand.Next(0,3)),
      _ => throw new ArgumentException("Don't support character in random"),
    };
    return Convert.ToChar(rand.Next(start, end));
  }
  public static string GeneratorRandomPassword(int minLength = 8, bool isUpper = true,
    bool isLower = true, bool isNumber = true, bool isSpecial = true)
  {
    // random index and pass index in return value in element at :)
    var charTypes = new List<CharacterTypes>();
    if (isUpper) charTypes.Add(CharacterTypes.UpperCase);
    if (isLower) charTypes.Add(CharacterTypes.LowerCase);
    if(isNumber) charTypes.Add(CharacterTypes.Number);
    if(isSpecial) charTypes.Add(CharacterTypes.SpecialCharacter);
    var typeLength = charTypes.Count;
    if (typeLength == 0) return ":)) my name is ninh";
    var flags = new HashSet<int>();
    var random = new Random();
    var password = new StringBuilder();
    // flags check has random character
    for (int i = 0; i < minLength; i++)
    {
      var randType = random.Next(0, typeLength);
      flags.Add(randType);
      password.Append(GeneratorCharacter(charTypes[randType]));
    }

    if (flags.Count != typeLength)
    {
      for (var i = 0; i < typeLength; i++)
      {
        if (!flags.Contains(i))
        {
          password.Append(GeneratorCharacter(charTypes[i]));
        }
      }
    }
    return password.ToString();
  }
}
