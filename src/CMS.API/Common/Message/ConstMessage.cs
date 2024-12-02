namespace CMS.API.Common.Message;

public abstract class ConstMessage
{
  public const string USER_NAME_NOT_EXITS = "Tài khoản không đúng";
  public const string CODE_IS_EMPTY = "Mã không được để trống";
  public const string PASSORD_NOT_CORRECT = "Mật khẩu không đúng";
  public const string NAME_IS_EMPTY = "Tên không được để trống";
  public const string CODE_LENGTH_MAX_50 = "Mã không lớn hơn 50 ký tự";
  public const string NAME_LENGTH_MAX_50 = "Tên không lớn hơn 50 ký tự";
  public const string NAME_LENGTH_MAX_75 = "Tên không lớn hơn 75 ký tự";
  public const string NAME_LENGTH_MAX_100 = "Tên không lớn hơn 100 ký tự";
  public const string NAME_LENGTH_MAX_200 = "Tên không lớn hơn 200 ký tự";
  public const string USER_NAME_EMPTY = "User name không được để trống";
  public const string USER_NAME_MAX_LENGTH_50 = "User name  không lớn hơn 50 ký tự";
  public const string PASSWORD_EMPTY = "Mật khẩu không được để trống";
  public const string CONTENT_INVALID_SUBJECT = "Chủ đề chưa chọn hoặc đã không còn hoạt động";
  public const string TITLE_MAX_LENGTH_500 = "Tiêu đề không lớn hơn 500 kí tự";
  public const string TITLE_MAX_LENGTH_100 = "Tiêu đề không lớn hơn 100 kí tự";
  public const string DESCRIPTION_MAX_LENGTH_500 = "Mô tả không lớn hơn 500 kí tự";
  public const string TITLE_EMPTY = "Tiêu đề không được để trống";
  public const string CONTENT_EMPTY = "Nội dung không được để trống";
  public const string IN_VALID_PHONE_VN = "Số điện thoại không đúng định dạng";
  public const string IN_VALID_EMAIL = "Email không đúng định dạng";
  public const string ADDRESS_MAX_LENGTH_100 = "Địa chỉ không quá 100 ký tự";
  public const string ADDRESS_MAX_LENGTH_200 = "Địa chỉ không quá 200 ký tự";
  public const string ADDRESS_MAX_LENGTH_150 = "Địa chỉ không quá 150 ký tự";
  public const string ADDRESS_EMPTY = "Địa chỉ không được để trống";
  public const string IN_VALID_PASSWORD = "Mât khẩu không đúng định dạng, mật khẩu cần có 8 kí tự, có kí tự hoa, kí tự thường, số và kí tự đặc biệt";
  public const string DUPLICATE_PASSWORD = "Mật khẩu cũ không được trùng với mật khẩu mới";
  public const string NOT_DUPLICATE_PASSWORD = "Mật khẩu mới và mật khẩu xác nhận không khớp";
  public const string EMAIL_MAX_LENGTH_100 = "Địa chỉ email không lớn hơn 100 kí tự";
  public const string SUBJECT_IN_VALIDATION_OR_NOT_HAS_ACTIVE_BEFORE = "Có chủ đề không hợp lễ hoặc đã không hoạt động trước đấy";
  public const string INFORMATION_ORGANIZATION_HAS_ACTIVE_BEFORE = "Đang có thông tin của tổ chức đang hoạt động trước đó rồi hãy tắt cái cũ trước khi bật lại";
  public const string PARENT_SUBJECT_NOT_SUPPORT = "chủ đề cha hoặc đã không còn hỗ trợ";
  public const string USER_HAS_ROLE = "User này đã có quyền này rồi";
  public const string NOT_FOUND_OBJECT = "Không tìm thấy đối tượng";
  public const string NAME_MENU_EMPTY = "Tên của menu không được để trống";
  public const string NAME_MENU_MAX_LENGTH_50 = "Tên của menu không lớn hơn 50 ký tự";
}
