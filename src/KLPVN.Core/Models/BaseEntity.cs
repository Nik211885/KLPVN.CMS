namespace KLPVN.Core.Models;

public abstract class BaseEntity<TKey>(TKey id)
{
  public TKey Id { get; set; } = id;
}
