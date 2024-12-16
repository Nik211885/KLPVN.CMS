namespace KLPVN.Core.Interface;

public interface IUserProvider
{
  bool IsAuthenticated { get; }

  Guid UserId { get; }

  string UserName { get; }
}
