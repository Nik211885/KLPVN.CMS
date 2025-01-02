namespace CMS.WEB.Common;

public abstract class ConstRequestUri
{
  //au
  public const string AuLogin = "au/login";
  public const string AuRefresh = "au/refresh";
  public const string AuLogout = "au/logout";
  public const string AuSample = "sample";
  public const string AuUser = "au/user";
  public const string AuUploadFile = "au/upload-file";
  // user
  public const string UserMenu = "user/menu";
  public const string UserChangePassword = "user/change-password";
  public const string UserInformation = "user/information";
  public const string UserUploadAvatar = "user/upload-avatar";
  public const string UserUpdateProfile = "user/update";
  public const string UserAll = "user/all";
  public const string GetUserDetailByUserName = "user/detail?userName={0}";
  public const string PutActiveUser = "user/active?userName={0}";
  public const string PutUpdateUserByUserName = "user/update-by-user-name?userName={0}";
  public const string PostCreateUser = "user/create";
  public const string DeleteUser = "user/delete?userName={0}";
  
  //feedbacks
  public const string FeedBacks = "feed-back/all";
}
