using KLPVN.Core.Commons.Const;

namespace KLPVN.Core.Models;

/// <summary>
///     username make foreign key and username is unique
/// </summary>
/// <param name="id"></param>
/// <param name="userName"></param>
/// <typeparam name="TKey"></typeparam>
public abstract class CoreEntity<TKey>
  (TKey id, string? userName) : BaseEntity<TKey>(id)
{
  public string CreatedBy { get; } = userName ?? Variables.DEFAULT_USER_NAME;
  public DateTimeOffset CreatedDatetime { get; } = DateTimeOffset.UtcNow;
  public string UpdatedBy { get; private set; } = userName ?? Variables.DEFAULT_USER_NAME; 
  public DateTimeOffset UpdatedDateTime{ get; private set; } = DateTimeOffset.UtcNow;

  public void UpdateCoreEntity(string? updatedBy)
  {
    UpdatedBy = updatedBy ?? Variables.DEFAULT_USER_NAME;
    UpdatedDateTime = DateTimeOffset.UtcNow;
  }
}
