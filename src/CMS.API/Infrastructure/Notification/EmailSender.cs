using KLPVN.Core.Interface;

namespace CMS.API.Infrastructure.Notification;

public class EmailSender : INotification
{
  public Task SendNotificationAsync(string from, string to, string subject, string body)
  {
    throw new NotImplementedException();
  }
}
