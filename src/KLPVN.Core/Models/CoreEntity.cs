using KLPVN.Core.Commons.Const;

namespace KLPVN.Core.Models;

/// <summary>
///     username make foreign key and username is unique
/// </summary>
/// <typeparam name="TKey"></typeparam>
public abstract class CoreEntity<TKey> : BaseEntity<TKey>
{
  public string CreatedBy { get; set; }
  public DateTimeOffset CreatedDatetime { get; set; }
  public string UpdatedBy { get; set; }
  public DateTimeOffset UpdatedDateTime{ get; set; } 
}
