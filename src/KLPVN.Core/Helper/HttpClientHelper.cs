using System.Net.Http.Headers;
using KLPVN.Core.Commons.Enums;
using KLPVN.Core.Models;

namespace KLPVN.Core.Helper;

public static class HttpClientHelper
{
  public static void UseBearerToken(this HttpClient client, string token)
    => client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

  public static async Task<ResponseInfor> SendRequestAsync(this HttpClient client, CoreHttpMethod method, string url,
    RequestInfor? request)
  {
    if (!string.IsNullOrWhiteSpace(request?.Token))
    {
      client.UseBearerToken(request.Token);
    }

    if (!string.IsNullOrWhiteSpace(request?.ContentType))
    {
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(request.ContentType));
    }
    HttpResponseMessage httpResponse = method switch
    {
      CoreHttpMethod.GET => await client.GetAsync(url, request?.Data),
      CoreHttpMethod.PUT => await client.PutAsync(url,request?.Data),
      CoreHttpMethod.POST => await client.PostAsync(url,request?.Data),
      CoreHttpMethod.DELETE => await client.DeleteAsync(url,request?.Data),
      _ => throw new ArgumentException("Invalid method")
    };
    return new ResponseInfor(httpResponse.StatusCode, httpResponse.Content, httpResponse.IsSuccessStatusCode);
  }
}
