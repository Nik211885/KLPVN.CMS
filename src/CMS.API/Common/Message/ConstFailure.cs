namespace CMS.API.Common.Message;

public abstract class ConstFailure
{
  public const string LOGIN_FAILURE_USER_NAME = "Tài khoản không đúng";
  public const string LOGIN_FAILURE_PASSWORD = "Mật khẩu không đúng";
  public const string IN_VALID_PHONE_NUMBER = "Số điện thoại không hợp lệ";
  public const string IN_VALID_EMAIL = "Email không đúng định dạng";

  public const string IN_VALID_PASSWORD = "Mật khẩu không đúng định dạng cần có chữ thường, in hoa, kí tự đặc biệt và kí tự số";
  public const string IN_DUPLICATE_PASSWORD = "Mật khẩu mới không được trùng với mật khẩu cũ";
  public const string IN_MATCH_PASSWORD = "Mật khẩu mới và mật khẩu xác nhận không giống nhau ";
  public const string USER_NAME_HAS_EXIT = "Đã có tài khoản có user name này rồi";
}
