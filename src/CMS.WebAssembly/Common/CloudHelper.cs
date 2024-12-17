using KLPVN.Core.Helper;
using Microsoft.AspNetCore.Components.Forms;

namespace CMS.WebAssembly.Common;

public static class CloudHelper
{
  public static async Task<UploadImagesResult> UploadFileAsync(string url, IBrowserFile file)
  {
    var content = new MultipartFormDataContent();
    try
    {
      var stream = file.OpenReadStream(maxAllowedSize: 5 * 1024 * 1024);
      content.Add(new StreamContent(stream), "file", file.Name);
    }
    catch (IOException ex)
    {
      return FUploadImageResult.Failure("File khong qua 5mb");
    }
    catch (Exception ex)
    {
      return FUploadImageResult.Failure("Có lỗi trong quá trình xử lý");
    }
    using var client = new HttpClient();
    try
    {
      var response = await client.PostAsync(url, content);
      if (!response.IsSuccessStatusCode)
      {
        return FUploadImageResult.Failure("Có lỗi trong quá trình xử lý");
      }

      var fileInfor = await response.Content.DecodeAsync<dynamic>();
      return FUploadImageResult.Success(fileInfor["secure_url"].ToString());
    }
    catch (Exception ex)
    {
      return FUploadImageResult.Failure("Có lỗi trong quá trình xử lý");
    }

  }
}
public record UploadImagesResult(bool IsSuccess, string Data);

public static class FUploadImageResult
{
  public static UploadImagesResult Failure(string data)
  {
    return new (false, data);
  }

  public static UploadImagesResult Success(string data)
  {
    return new (true, data);
  }
}
