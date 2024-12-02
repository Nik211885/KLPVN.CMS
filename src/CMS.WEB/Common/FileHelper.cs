using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CMS.API.Exceptions;
using dotenv.net;
namespace CMS.WEB.Common;

public static class FileHelper
{
  public static async Task<string> UploadFileAsync(IFormFile file)
  {
    if (file is null || file.Length == 0 || file.Length >= 5000000)
    {
      throw new BadRequestException("Eroros process image imager bigger 5mb");
    }
    var filePath = Path.GetTempFileName();
    DotEnv.Load(options: new DotEnvOptions(probeForEnv: true));
    Cloudinary cloudinary = new Cloudinary(Environment.GetEnvironmentVariable("CLOUDINARY_URL")) { Api =
    {
      Secure = true
    } };
    var uploadParams = new ImageUploadParams()
    {
      File = new FileDescription(filePath),
      UseFilename = true,
      UniqueFilename = false,
      Overwrite = true
    };
    var uploadResult = await cloudinary.UploadAsync(uploadParams);
    return uploadResult.SecureUrl.ToString();
  }
}
