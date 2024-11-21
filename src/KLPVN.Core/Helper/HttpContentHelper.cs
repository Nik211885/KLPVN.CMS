using Newtonsoft.Json;

namespace KLPVN.Core.Helper;
public static class HttpContentHelper
{
    public static async Task<TObject?> DecodeAsync<TObject>(this HttpContent content)
    {
      try
      {
        var jsonData = await content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<TObject>(jsonData);
        return data;
      }
      finally
      {
        content.Dispose();
      }
    }
}
