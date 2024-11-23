namespace KLPVN.Core.Interface;

public interface INotification
{
  Task SendNotificationAsync(string from, string to, string subject, string body);
}
